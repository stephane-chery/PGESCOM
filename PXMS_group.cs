using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace PGESCOM
{
    class PXMS_group
    {
        string[,] arr_cells;
        string in_hdr,in_sub_line;
        int in_Rows, in_Cols;

        public PXMS_group(int x_Rows, int x_Cols, string x_hdr, string x_sub_line)
        {
            in_hdr = x_hdr;
            in_sub_line = x_sub_line;
            in_Cols = x_Cols;
            in_Rows = x_Rows;
            arr_cells = new string[in_Rows, in_Cols];
        }

        private void init_arrCells()
        {
            string stSql = " Select Row_Name" +
                " from PXMS_Param_Rows inner join PXMS_Grp_Param on PXMS_Grp_Param.GRPPA_LID = PXMS_Param_Rows.GRPPA_LID " +
                " where PXMS_Grp_Param.G_Name='" + in_hdr + "'" +
                " order by PXMS_Param_Rows.Rnk_inGrp";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int r = 0;
            while (Oreadr.Read())
                arr_cells[r++, 0] = Oreadr["Row_Name"].ToString();
            OConn.Close();
        }

        public string[,] get_Gr_Params()
        {
            string _line=in_sub_line;

            init_arrCells();

            for (int r = 0; r < in_Rows; r++)
            {
                int iposD = _line.IndexOf(arr_cells[r, 0]);
                if (iposD != -1)
                {
                    iposD += arr_cells[r, 0].Length + 1;
                    int iposF = _line.IndexOf("||", iposD);
                    string _PLine = _line.Substring(iposD, iposF + 3 - iposD);
                    string[] arr_Val = new string[in_Cols - 1];
                    arr_Val = Find_Sub_Param(_PLine, in_Cols - 1);
                    for (int c = 1; c < in_Cols; c++) arr_cells[r, c] = arr_Val[c - 1];
                }
            }
            return arr_cells;
        }

        private string[] Find_Sub_Param(string _stLine, int _Cols)
        {
            string[] res = new string[_Cols];
            int c = 0, debV = 0;

            for (c = 0; c < _Cols; c++) res[c] = " ";

            int iposD = _stLine.IndexOf("~~");
            if (iposD != -1)
            {
                for (c = 0; c < _Cols; c++)
                {
                    debV = iposD + 2;
                    int iposF = _stLine.IndexOf("~~", debV);
                    if (iposF != -1)
                    {
                        //debV = (c == 0) ? iposD + _ParmNm.Length + 3 : iposD + 2;
                        res[c] = _stLine.Substring(debV, iposF - debV);
                        //_stLine = _stLine.Substring(iposF, _stLine.Length - iposF);
                        iposD = iposF;
                    }
                    else
                    {
                        iposF = _stLine.IndexOf("||");
                        if (iposF != -1)
                        {
                            res[c] = _stLine.Substring(debV, iposF - debV);
                            //_stLine = _stLine.Substring(iposF, _stLine.Length - iposF);
                            _stLine = "";
                        }
                        else
                        {
                            res[c] = "";
                            c = _Cols;
                        }
                    }
                }
            }
            return res;
        }
    }
}