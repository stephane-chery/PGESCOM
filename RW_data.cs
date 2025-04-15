using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace PGESCOM
{
    class RW_data
    {
        string in_Tblname = "";

        public RW_data(string x_TblName) //string[,] x_arr_Flds, string[] x_arr_Vals)
        {
            in_Tblname = x_TblName;
        }

        public void Insert_data(string[,] x_arr_Flds, string[,] x_arr_Vals, int ItmsNB)
        {
            string fields = "", val = " ) VALUES (", stSql = "INSERT INTO " + in_Tblname + " (";
            for (int i = 1; i < ItmsNB; i++) //x_arr_flds[0] == LID ..........x_arr_Flds[i, 0][0]....1 = update 0 = no / x_arr_Flds[i, 0][1]....1 = add "'" 0 = no
            {
                fields += (i == 1) ? " [" + x_arr_Flds[i, 0] + "]" : ", " + " [" + x_arr_Flds[i, 0] + "]";
                string _VVV = (x_arr_Flds[i, 1] == "0") ? x_arr_Vals[i, 0] : "'" + x_arr_Vals[i, 0] + "'";
                val += (i == 1) ? _VVV : ", " + _VVV;
            }
            stSql += fields + val + ")";
            MainMDI.Exec_SQL_JFS(stSql, "INSERT..." + in_Tblname);
        }

        public void Update_data(string[,] x_arr_Flds, string[,] x_arr_Vals, int ItmsNB)
        {
            string fields = "", stSql = "UPDATE " + in_Tblname + " SET ";
            for (int i = 1; i < ItmsNB; i++) //x_arr_flds[0] == LID ..........x_arr_Flds[i, 0][0]....1 = update 0 = no / x_arr_Flds[i, 0][1]....1 = add "'" 0 = no
            {
                if (x_arr_Flds[i, 0][0] == '1')
                {
                    fields = "[" + x_arr_Flds[i, 0] + "]=";
                    string _VVV = (x_arr_Vals[i, 1] == "0") ? x_arr_Vals[i, 0] : "'" + x_arr_Vals[i, 0] + "'";
                    stSql += (i == 1) ? fields + _VVV : ", " + fields + _VVV;
                }
            }
            stSql += ") where " + x_arr_Flds[0, 0] + " = " + x_arr_Vals[0, 0];
            MainMDI.Exec_SQL_JFS(stSql, "UPDATE..." + in_Tblname);
        }

        private string use_appostrof(string _typ)
        {
            string res = "3";
            switch (_typ)
            {
                case "bigint":
                case "int":
                case "float":
                case "smalldatetime":
                    res = "0";
                    break;
                case "nvarchar":
                case "varchar":
                case "nchar":
                    res = "1";
                    break;
            }
            if (res == "3") System.Windows.Forms.MessageBox.Show("Error......type=" + _typ + "  Invalid in use_appostrof.....");
            return res;
        }

        public void get_Table_Flds(ref string[,] _arr_Flds, ref int _NBfld)
        {
            string stSql = " SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + in_Tblname + "'";
            int f = 0;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int i = 0;
            while (Oreadr.Read())
            {
                _arr_Flds[i, 0] = Oreadr["COLUMN_NAME"].ToString();
                _arr_Flds[i++, 1] = use_appostrof(Oreadr["DATA_TYPE"].ToString());
            }
            Oreadr.Close();
            OConn.Close();
            _NBfld = i;
        }

        public void init_Arrs(ref string[,] _arr_Vals)
        {
            for (int i = 0; i < MainMDI.Max_Flds_Vals; i++)
                for (int j = 0; j < MainMDI.Max_Flds_Vals; j++) _arr_Vals[i, 1] = "0";
        }
    }
}