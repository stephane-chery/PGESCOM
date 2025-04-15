using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using EAHLibs;
using System.IO;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;


namespace PBsizing.Controllers
{
    public class MainMDI
    {

        //public static string MainMDI_stMsgXP = "";
        public static Lib1 Tools = new Lib1();
        //      public static string stXP = "", stMsgXP = "";
        public static readonly string VIDE = "n/a";
        //public static string stati_cond = "(cedulo_trs.cur_inv = '4') ";
        public static string stati_cond = "(cedulo_trs.cur_inv = '4' and ended is null) ";
        static string DBusrNm = "sa";

        //hom TU database
    //       private static string dbpwd = "darasam", SQLDB = @"HAKIM-LT\TU_BD_PRX", currDB = "Orig_PSM_FDB";

        //PRX TU database
        // private static string dbpwd = "darasam", SQLDB = @"U-HAKIM-DT\SQLEXPRESS", currDB = "Orig_PSM_FDB";

        //PROD database
         private static string dbpwd = "darasam", SQLDB = @"ERPSERVER\PSM_DB2K8K", currDB = "Orig_PSM_FDB";


        //      private static string dbpwd = "P4500F-3-125-50", SQLDB = @"P-HV0-SQL\PXCHARGERS", currDB = "Orig_PSM_FDB";
        //    private static string dbpwd = "dara", SQLDB = @"HAKIM-LT\PSM_DB2K14_LOC", currDB = "Orig_PSM_FDB";
        public static readonly int MAX_XLlines_XPRT = 800;
        public static string M_stCon_PL_SYSPRO = @"user id=sa;password=prim@x1;server=ERPSERVER\PGESCOM;Trusted_Connection=No;database=SysproCompanyP;connection timeout=30";
      
        public static string M_stCon = @"user id=" + DBusrNm + ";password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + currDB + ";connection timeout=30";
        //   public static string t_SeekTBL6 = "";
        //   public static string t_tbl6Col = "";
        //   public static string t_tbl6ColDBL = "";
        //   public static string t_Det_OL = "";
        public static int Lang = 0;
        //    public static string KAac = "", KAdc = "";
        public static string[,] arr_EFSdict = new string[200, 3];
        //     public static string C_Style = "103";
        //    public static int myCFID=0;
        //
        // GET: /MainMDI/

        //17032020

        public static bool Creat_TempTbls(int UserID)
        {
            string errmsg = "";

            if (UserID > 0)
            {
                System.Web.HttpContext.Current.Session["t_Det_OL"] = "pgm_Det_OL" + UserID;

                System.Web.HttpContext.Current.Session["t_SeekTBL6"] = "pgm_SeekTBL6" + UserID;

                System.Web.HttpContext.Current.Session["t_tbl6Col"] = "pgm_tbl6Col" + UserID;

                System.Web.HttpContext.Current.Session["t_tbl6ColDBL"] = "pgm_tbl6ColDBL" + UserID;

                bool TempTbl = true;
                if (!Table_exists(System.Web.HttpContext.Current.Session["t_Det_OL"].ToString())) TempTbl = MainMDI.ExecSql("select * into " + System.Web.HttpContext.Current.Session["t_Det_OL"].ToString() + " from pgm_Det_OL_empty ", ref errmsg);
                if (!Table_exists(System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString())) TempTbl = TempTbl && MainMDI.ExecSql("select * into " + System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString() + " from pgm_SeekTBL6_empty ", ref errmsg);
                //	if (!Table_exists(t_tbl6Col)) TempTbl=MainMDI.ExecSql("select * into " + t_tbl6Col + " from pgm_tbl6Col_empty ");  
                //	if (!Table_exists(t_tbl6ColDBL)) TempTbl=MainMDI.ExecSql("select * into " + t_tbl6ColDBL + " from pgm_tbl6ColDBL_empty ");  

                return TempTbl;
            }
            else return false;
        }
        private void Drop_TempTbls()
        {
            string errmsg = "";
            if (Table_exists(System.Web.HttpContext.Current.Session["t_Det_OL"].ToString())) MainMDI.ExecSql("drop TABLE " + System.Web.HttpContext.Current.Session["t_Det_OL"].ToString(), ref errmsg);
            if (Table_exists(System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString())) MainMDI.ExecSql("drop TABLE " + System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString(), ref errmsg);
            //	if (Table_exists(t_tbl6Col))  MainMDI.ExecSql("drop TABLE " + t_tbl6Col ); 
            //	if (Table_exists(t_tbl6ColDBL)) MainMDI.ExecSql("drop TABLE " + t_tbl6ColDBL); 

        }









        //17032020

        public static string optDesc(int l, string EFDesc)
        {
            string eng = "", fr = "";
            int ipos = EFDesc.IndexOf(" ~ ", 0);
            if (ipos == -1) eng = EFDesc;
            else
            {
                if (ipos == 0) fr = EFDesc;
                else
                {
                    eng = EFDesc.Substring(0, ipos);
                    fr = EFDesc.Substring(ipos + 3, EFDesc.Length - ipos - 3);
                }
            }
            if (l == 0) return eng;
            if (l == 1) return fr;
            return "";


        }

        public static string A00(int ii, int Lnt)
        {
            //if (ii==0 ) return "00";
            string st = ii.ToString();
            for (int j = st.Length; j < Lnt; j++)
                st = "0" + st;
            return st;
        }
        public static string A00(string ii, int Lnt)
        {
            //if (ii==0 ) return "00";
            string st = ii;
            for (int j = st.Length; j < Lnt; j++)
                st = "0" + st;
            return st;
        }
        public static string A00(long ii, int Lnt)
        {
            //if (ii==0 ) return "00";
            string st = ii.ToString();
            for (int j = st.Length; j < Lnt; j++)
                st = "0" + st;
            return st;
        }

        public static class StringCipher
        {
            private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

            private const int keysize = 256;

            public static string Encrypt(string plainText, string passPhrase)
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    byte[] cipherTextBytes = memoryStream.ToArray();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public static string Decrypt(string cipherText, string passPhrase)
            {
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
        }




        public static string Find_One_Field_SYSPRO(string stSql,ref string retMsg)
        {
            //string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            // tst
            stSql.Replace("'", "''");
            //tst
            retMsg = "OK";
            try
            {

                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read()) return Oreadr[0].ToString();
                return VIDE;
            }
            catch (Exception ex)
            {
              retMsg="F1F_SYSPRO_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSql;
                return VIDE;
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }


        }

        public static string Find_One_Field(string stSql)
        {
            string stMsgXP = "";
            //string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            // tst
            stSql.Replace("'", "''");
            //tst

            try
            {

                OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read()) return Oreadr[0].ToString().TrimEnd();
                return VIDE;
            }
            catch (Exception ex)
            {
                stMsgXP = "F1F-ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSql;
                return VIDE;
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }


        }
        public static string init_Dict()
        {
            SqlDataReader Oreadr = null;
            SqlConnection OConn = null;
            bool res = true;
            string msgerror = "";
            try
            {
                OConn = new SqlConnection(M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = "select * from  PSM_EFSDict order by Rnk";
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    int y = Convert.ToInt32(Oreadr[3].ToString());
                    arr_EFSdict[y, 0] = Oreadr[0].ToString();
                    arr_EFSdict[y, 1] = Oreadr[1].ToString();
                    arr_EFSdict[y, 2] = Oreadr[2].ToString();
                }
            }
            catch (Exception ex)
            {

                msgerror = "init-Dict ERROR= Cannot connect to Database ..... check your network OR contact your Admin  \n" + ex.Message + "  \n" + SQLDB;
                res = false;

            }
            finally
            {
                if (Oreadr != null) Oreadr.Close();
                OConn.Close();

            }

            return msgerror;
        }
        public static bool Table_exists(string Tnme)
        {
            return (MainMDI.Find_One_Field("IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES   WHERE TABLE_TYPE='BASE TABLE' " +
                " AND TABLE_NAME='" + Tnme + "')      SELECT 'Y' ELSE  SELECT 'N' ") == "Y");
        }
        public static bool Creat_TempTblsold(int UserID)
        {
            //string errmsg = "";

            //if (UserID >0)
            //{
            //    t_Det_OL = "pgm_Det_OL" + UserID;
            //    t_SeekTBL6 = "pgm_SeekTBL6" +UserID;
            //    t_tbl6Col = "pgm_tbl6Col" +UserID;
            //    t_tbl6ColDBL = "pgm_tbl6ColDBL" +UserID;
            //    bool TempTbl = true;
            //    if (!Table_exists(t_Det_OL)) TempTbl = MainMDI.ExecSql("select * into " + t_Det_OL + " from pgm_Det_OL_empty ",ref errmsg);
            //    if (!Table_exists(t_SeekTBL6)) TempTbl = TempTbl && MainMDI.ExecSql("select * into " + t_SeekTBL6 + " from pgm_SeekTBL6_empty ",ref errmsg);
            //    //	if (!Table_exists(t_tbl6Col)) TempTbl=MainMDI.ExecSql("select * into " + t_tbl6Col + " from pgm_tbl6Col_empty ");  
            //    //	if (!Table_exists(t_tbl6ColDBL)) TempTbl=MainMDI.ExecSql("select * into " + t_tbl6ColDBL + " from pgm_tbl6ColDBL_empty ");  

            //    return TempTbl;
            //}
            //else return false;

            return false;
        }

        public static bool Creat_TempTblsOLD(int UserID)
        {
            string errmsg = "";

            if (UserID > 0)
            {
                System.Web.HttpContext.Current.Session["t_Det_OL"] = "pgm_Det_OL" + UserID;

                System.Web.HttpContext.Current.Session["t_SeekTBL6"] = "pgm_SeekTBL6" + UserID;

                System.Web.HttpContext.Current.Session["t_tbl6Col"] = "pgm_tbl6Col" + UserID;

                System.Web.HttpContext.Current.Session["t_tbl6ColDBL"] = "pgm_tbl6ColDBL" + UserID;

                bool TempTbl = true;
                if (!Table_exists(System.Web.HttpContext.Current.Session["t_Det_OL"].ToString())) TempTbl = MainMDI.ExecSql("select * into " + System.Web.HttpContext.Current.Session["t_Det_OL"].ToString() + " from pgm_Det_OL_empty ", ref errmsg);
                if (!Table_exists(System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString())) TempTbl = TempTbl && MainMDI.ExecSql("select * into " + System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString() + " from pgm_SeekTBL6_empty ", ref errmsg);
                //	if (!Table_exists(t_tbl6Col)) TempTbl=MainMDI.ExecSql("select * into " + t_tbl6Col + " from pgm_tbl6Col_empty ");  
                //	if (!Table_exists(t_tbl6ColDBL)) TempTbl=MainMDI.ExecSql("select * into " + t_tbl6ColDBL + " from pgm_tbl6ColDBL_empty ");  

                return TempTbl;
            }
            else return false;
        }
        private void Drop_TempTblsOLD()
        {
            string errmsg = "";
            if (Table_exists(System.Web.HttpContext.Current.Session["t_Det_OL"].ToString())) MainMDI.ExecSql("drop TABLE " + System.Web.HttpContext.Current.Session["t_Det_OL"].ToString(), ref errmsg);
            if (Table_exists(System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString())) MainMDI.ExecSql("drop TABLE " + System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString(), ref errmsg);
            //	if (Table_exists(t_tbl6Col))  MainMDI.ExecSql("drop TABLE " + t_tbl6Col ); 
            //	if (Table_exists(t_tbl6ColDBL)) MainMDI.ExecSql("drop TABLE " + t_tbl6ColDBL); 

        }

  

        public static double Ceil(string S1, string sig)
        {
            double d1 = Tools.Conv_Dbl(S1), dSig = Tools.Conv_Dbl(sig);
            if (d1 == 0 || dSig == 0) return 0;
            else
            {
                int deb = Convert.ToInt32(d1 / dSig);
                bool fin = false;
                for (int i = 0; i < 4; i++) if (dSig * deb > d1) return (dSig * deb);
                    else deb++;
                return 0;
            }

        }
        public static string SSV_SMLdate(string sdate)
        {
            return "Convert(smalldatetime,'" + sdate + "'," + "103" + ")";


        }
        public static string SSV_Bigdate(string sdate)
        {
            
            return "Convert(datetime,'" + sdate + "'," + "103" + ")";


        }
        public static void Write_JFS(string stSql, string usr)
        {
            string noerrmsg = "";
            ExecSql("INSERT INTO PSM_JFS ([stsql],[dateOpera],[userNm]) VALUES ('" + stSql.Replace("'", ".") + "', " + MainMDI.SSV_SMLdate(System.DateTime.Now.ToShortDateString()) + ", '" + usr + "')", ref noerrmsg);
        }

        public static void Exec_SQL_JFS(string SQL_st, string JFS_st, string usr)
        {

            string myerrmsg = "";
            MainMDI.ExecSql(SQL_st, ref myerrmsg);
            if (JFS_st.Length > 0) MainMDI.Write_JFS(JFS_st + "    stSql= " + SQL_st + "  ERRmsg: " + myerrmsg, usr);
        }
        public static void Exec_SQL_JFS(string SQL_st, string JFS_st, string usr,ref string errmsg)
        {

            string myerrmsg = "";
            MainMDI.ExecSql(SQL_st, ref myerrmsg);
            errmsg = myerrmsg;
            if (JFS_st.Length > 0) MainMDI.Write_JFS(JFS_st + "    stSql= " + SQL_st + "  ERRmsg: " + myerrmsg, usr);
        }
        public static bool ExecSql(string stSql, ref string errmsg)
        {
            // tst
            //	stSql.Replace("'","''");
            //tst

            SqlConnection OConn = new SqlConnection(M_stCon);
            OConn.Open();
            try
            {
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.ExecuteNonQuery();

                errmsg = MainMDI.VIDE;
                return true;
            }
            catch (SqlException Oexp)
            {
                errmsg = "sql= " + stSql+"  err=" + Oexp.Message;

                string toto = writeERRsql("stsql= " + stSql + "   errmsg= " + errmsg);
                //   MainMDI.stMsgXP = "STSQL= " + stSql + "\n" + "Msg= " + stXP;
                //   Write_JFS("Configo...SQL ERROR: "+ stXP+"  sql: "+stSql, "ede");
                return false;
            }
            finally
            {
                OConn.Close();
            }
        }



        public static void Exec_SQL_JFS_SYSPRO(string SQL_st, string JFS_st, string usr)
        {

            string myerrmsg = "";
            MainMDI.ExecSql_SYSPRO(SQL_st, ref myerrmsg);
            if (JFS_st.Length > 0) MainMDI.Write_JFS(JFS_st + "    stSql= " + SQL_st + "  ERRmsg: " + myerrmsg, usr);
        }

        public static bool ExecSql_SYSPRO(string stSql, ref string errmsg)
        {
            // tst
            //	stSql.Replace("'","''");
            //tst

            SqlConnection OConn = new SqlConnection(M_stCon_PL_SYSPRO);
            OConn.Open();
            try
            {
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.ExecuteNonQuery();

                errmsg = MainMDI.VIDE;
                return true;
            }
            catch (SqlException Oexp)
            {
                errmsg = Oexp.Message;
                string toto = writeERRsql("stsql= " + stSql + "   errmsg= " + errmsg);
                return false;
            }
            finally
            {
                OConn.Close();
            }
        }


        public static string writeERRsql(string msg)
        {

            string errmsg = "";
            SqlConnection OConn = new SqlConnection(M_stCon);
            OConn.Open();
            try
            {
                SqlCommand Ocmd = OConn.CreateCommand();
                string stSql = "INSERT INTO Configo_sqlERR ([errmsg],[date]) VALUES ('" + msg.Replace("'", ".") + "', '" + System.DateTime.Now.ToString("yyyy/MM/dd") + "')";
                Ocmd.CommandText = stSql;
                Ocmd.ExecuteNonQuery();

                return errmsg;
            }
            catch (SqlException Oexp)
            {
                errmsg = Oexp.Message;

                //   MainMDI.stMsgXP = "STSQL= " + stSql + "\n" + "Msg= " + stXP;
                //   Write_JFS("Configo...SQL ERROR: "+ stXP+"  sql: "+stSql, "ede");
                return errmsg;
            }
            finally
            {
                OConn.Close();
            }
        }

        public static void Find_n_Field(string stSql, ref string st1, ref string st2, ref string st3, ref string st4)
        {


            string MainMDI_stMsgXP = "";
            //string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            // tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;

            try
            {

                OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    st3 = Oreadr[2].ToString();
                    st4 = Oreadr[3].ToString();
                    break;
                }

            }
            catch (Exception ex)
            {
                MainMDI_stMsgXP = "FnF-ERROR= " + ex.Message;
                st1 = VIDE;st2 = MainMDI_stMsgXP;
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }


        }
        public static void Find_2_Field(string stSql, ref string st1, ref string st2, ref string st3, ref string st4)
        {



            string MainMDI_stMsgXP = "";
            //string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            // tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;

            try
            {

                OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    st3 = Oreadr[2].ToString();
                    st4 = Oreadr[3].ToString();
                    break;
                }

            }
            catch (Exception ex)
            {
                MainMDI_stMsgXP = "F3F-ERROR= " + ex.Message;

            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }


        }

        public static void Find_2_Field(string stSql, ref string st1, ref string st2, ref string st3)
        {


            string MainMDI_stMsgXP = "";
            //string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            // tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;

            try
            {

                OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    st3 = Oreadr[2].ToString();
                    break;
                }

            }
            catch (Exception ex)
            {
                MainMDI_stMsgXP = "F3F-ERROR= " + ex.Message;

            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }


        }


        public static void Find_2_Field(string stSql, ref string st1, ref string st2)
        {

            string MainMDI_stMsgXP = "";

            //string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            // tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;

            try
            {

                OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    break;
                }

            }
            catch (Exception ex)
            {
                MainMDI_stMsgXP = "F2F-ERROR= " + ex.Message;

            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }


        }


        public static string Find_2_Field_PSA(string stSql, ref string st1, ref string st2, string P_S_A)
        {
            //string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            // tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;
           string retMsg = "OK";
            try
            {
                switch (P_S_A)
                {
                    case "P":
                        OConn = new SqlConnection(MainMDI.M_stCon);
                        break;
                    case "S":
                        OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                        break;
                    case "A":
                      //  OConn = new SqlConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                        break;
                    default:
                        OConn = new SqlConnection(MainMDI.M_stCon);
                        break;

                }
                //    OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    break;
                }

            }
            catch (Exception ex)
            {
              return "F2F-ERROR= " + ex.Message;

            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            return retMsg;

        }

        public static string Find_2_Field_PSA(string stSql, ref string st1, ref string st2, ref string st3, string P_S_A)
        {
            //string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            // tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;
            string retMsg = "OK";
            try
            {
                switch (P_S_A)
                {
                    case "P":
                        OConn = new SqlConnection(MainMDI.M_stCon);
                        break;
                    case "S":
                        OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                        break;
                    case "A":
                        //  OConn = new SqlConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                        break;
                    default:
                        OConn = new SqlConnection(MainMDI.M_stCon);
                        break;

                }
                //    OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    st3 = Oreadr[2].ToString();
                    break;
                }

            }
            catch (Exception ex)
            {
                return "F2F-ERROR= " + ex.Message;

            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            return retMsg;

        }

        public static bool ALWD_USR(string User,string _mdl)
        {
            bool res = false;
            string UserID = MainMDI.Find_One_Field("select userID from PSM_users_New where user='" + User + "'");
            if (UserID != MainMDI.VIDE)
            {

                if (User == "ede") res = true;
                else res = (MainMDI.Find_One_Field("SELECT lineID FROM PSM_AS_UsrMudls INNER JOIN PSM_AS_modules ON PSM_AS_UsrMudls.mdl_LID = PSM_AS_modules.m_LID " +
                         "  WHERE PSM_AS_modules.m_ABR = '" + _mdl + "' AND PSM_AS_UsrMudls.UsrLID =" + UserID) != MainMDI.VIDE);
                //  if (msg && !res) MessageBox.Show("Access Denied....!!!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            return res;
        }

     

     //   CB1||0~~CB2||-1~~CB3||30~~CB2||-1~~CB4||-1~~CB5||-1~~CB6||-1~~CB7||-1~~
        public static string find_Value(string frml, string Flist)  
        {
            if (Flist == ";" || Flist == "~~") return "???";
            {
                string U_Flist = Flist.ToUpper();
                string sepFrml = "~~";
                string U_frml = frml.ToUpper();
                string stF = "???";
                int ipos = U_Flist.IndexOf(U_frml + "||");
                if (ipos != -1)
                {
                    int ipos2 = Flist.IndexOf(sepFrml, ipos);
                    if (ipos2 == -1) ipos2 = (Flist[Flist.Length - 1] == ';') ? Flist.Length - 2 : Flist.Length;
                    stF = Flist.Substring(ipos + frml.Length + 2, ipos2 - (ipos + frml.Length + 2));
                    //			string stF=Flist.Substring(ipos+frml.Length ,ipos2-(ipos +frml.Length ) ); 
                    if (stF == "") stF = "???";

                }

                return stF;
            }


        }


        public static string Std_VCS(string p, long Avail_ID, string VCS_NAME)
        {


            string stSql = "SELECT * FROM BGF_VCS13 WHERE (Avail_ID= " + Avail_ID + " AND phs='" + Charger.P + "' AND VCS_NAME='" + VCS_NAME + "')";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                return Oreadr["value"].ToString();
            }
            OConn.Close();
            return Charger.VIDE;

        }




    }
}