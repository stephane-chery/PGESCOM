using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace PGESCOM
{
    class X_Serial
    {
        string in_tNm = "";
        public X_Serial(string x_tNm)
        {
            in_tNm = x_tNm;
        }

        public void flag_ID(string ID,bool free)
        {
            string status = (free) ? "0" : "1";
            string stSql = "UPDATE " + "PSM_" + in_tNm + "_GenID" + " SET [flaged]=" + status + "  WHERE " + in_tNm + "ID=" + ID;
            string msg = (free) ? "Free " : "Take  ";
            MainMDI.Exec_SQL_JFS(stSql, msg + " G9_xxxx=" + ID);
        }

  
 		public long Gen_IDFinal()  
		{
			long ResID=0;
			string tblNm="PSM_" +in_tNm +"_GenID";
			string Res = MainMDI.Find_One_Field("select " + in_tNm +"ID from " + tblNm+ " where flaged=0 order by  " + in_tNm +"ID ");
			if (Res ==MainMDI.VIDE ) 
			{   
				string lastID = MainMDI.Find_One_Field(" select " + in_tNm +"ID from " + tblNm+ " order by  " + in_tNm +"ID DESC");
				ResID = (lastID != MainMDI.VIDE) ? 0 : -1;
				// 0 means PSM_Q_GenID is Full or cannot Write In.
				// -1 means PSM_Q_GenID is Empty & must be Init.
			}
			else ResID = Convert.ToInt32(Res); 
			return ResID ;
		}
        public bool addNEWIDs(int NBIds,ref string msgEX)
        {
            msgEX = "";
            string tblNm = "PSM_" + in_tNm  + "_GenID";
            try
            {
                for (int i = 0; i < NBIds; i++)  MainMDI.ExecSql("INSERT INTO " + tblNm + " ([flaged]) VALUES (0)");
                  //  laff.Text = i.ToString();
                  //  laff.Refresh();
                return true;
            }
            catch (SqlException Oexp)
            {
               msgEX = tblNm + " IDs Creation failed....." + Oexp.Message;
                return false;
            }
        }

    }
}
