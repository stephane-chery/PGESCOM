using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PGCWEB.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using EAHLibs;
using System.Text.RegularExpressions;

namespace PGCWEB.Controllers
{
    public class AlarmsController : Controller
    {

        List<Alarms> myALarmslist = new List<Alarms>();
        public static Lib1 Tools = new Lib1();
        //
        // GET: /Alarms/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult alarms()
        {
            fill_alarms();
            return View("~/Views/alarms/alarms.cshtml",myALarmslist);

        }

        int findNBrelays(string list)
        {
            int nb = 0;

         
          //  string list = "48,R_48,49,R_49,50,R_50,51,52,53,R_58,R_59,R_60";
            String[] myarr = list.Split(',');
            int i = 0;
            while (i < myarr.Length )
            {
                if (Tools.Conv_Dbl(myarr[i]) > 0)
                {
                 ///   if (myarr[i + 1] == "R_" + myarr[i])
             
                    if (list.IndexOf("R_" + myarr[i]) >-1)
                    {
                        nb++;
                        i += 2;
                    }
                    else i++;
                }
                else i++;


            }


                return nb;
        }

        public JsonResult Save_ch_alarms(string c_al_list)
        {

            //   int nbrelays = Regex.Matches(c_al_list, "9999").Count;


          string c_err = "OK";
            string usr = HttpContext.Session["usr"].ToString();
            string confID = HttpContext.Session["cfid"].ToString();// MainMDI.cfid;
            //
            MainMDI.Exec_SQL_JFS("delete [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID="+confID +" and itmid=1", "Del configo det_alarms...",usr);
            //
            string st = MainMDI.Find_One_Field("SELECT [affID]  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " and [affID]<>'' order by [affID] desc");
            int iaffid = (st == MainMDI.VIDE) ? 1 : Int32.Parse(st);

            st = MainMDI.Find_One_Field("SELECT [rnk]  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " order by rnk desc");
            int rnk = (st == MainMDI.VIDE) ? 0 : Int32.Parse(st);
            rnk++;

            string G_al_list = "(" + c_al_list + ")";
          
            string stSql = "SELECT [Eng_desc],[Cost_Price]  FROM [Orig_PSM_FDB].[dbo].[configo_alarmslist] where id in " + G_al_list.Replace("R_","00");
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                iaffid++;
                while (Oreadr.Read())
                {

                    string st_optref = " ";
                    string st_affid = (Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()) == 0) ? " " : (iaffid++).ToString();
                    string st_DESC = Oreadr["Eng_desc"].ToString();

                    stSql = "INSERT INTO Configo_cf_details ([confID],[affID], [optref], " +
                 " [Itemdesc],[qty],[mult],[uprice], [xchng],[ext],[leadtime],[rnk],[pn] ,[tecVal],[itmgrp],[sext],[aext],[itmid]) VALUES ('" +
                 confID + "', '" +
                 st_affid + "', '" +
                st_optref + "', '" +
                 st_DESC + "', " +
                "0" + ", " +
                  "0" + ", " +
                 Oreadr["Cost_Price"].ToString() + ", " +
                    "0" + ", " +
                  Oreadr["Cost_Price"].ToString() + ", '" +
                  "" + "', " +
                        rnk++.ToString() + ", '" +
                  " " + "', '" +  //pn
                  " " + "', '" +  //tecval
                  "A" + "', " +  //itmgrp
                  "0" + ", " +  //sext
                  "0" + ", " +  //aext
                  "1" + ")";   //itmid   0:chrgr  1:alrms   2:options

                    MainMDI.Exec_SQL_JFS(stSql, " Configo insert Alarms in details...",usr);
                }
                OConn.Close();
            }
            catch (Exception ex)
            {
               c_err = ex.Message;
            }
            int nbcards=0;
            int nbrelays = findNBrelays(c_al_list);
            if (nbrelays > 1)
            {
                nbcards++;
                nbcards += (nbrelays / 7);


            }

        if (nbcards>0)    Add_options("54", nbcards.ToString ());


            string json = "OK";

            return Json(json, "application/json");



        }

        public JsonResult Save_ch_alarms_OlD(string c_al_list)
        {


            string confID= HttpContext.Session["cfid"].ToString();
            string usr = HttpContext.Session["usr"].ToString();

            string st=MainMDI.Find_One_Field("SELECT [affID]  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " and [affID]<>'' order by [affID] desc");
             int iaffid = (st==MainMDI.VIDE) ? 1 : Int32.Parse(st); 

            st=MainMDI.Find_One_Field("SELECT [rnk]  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " order by rnk desc");
            int rnk =(st==MainMDI.VIDE) ? 0 :  Int32.Parse(st); 
             rnk++;

            string G_al_list = "("+c_al_list + ")";
            string stSql = "SELECT [Eng_desc],[Cost_Price]  FROM [Orig_PSM_FDB].[dbo].[configo_alarmslist] where id in " +G_al_list;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            iaffid++;
            while (Oreadr.Read())
            {

                string st_optref = " ";
                string st_affid = (Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()) == 0) ? " " : (iaffid++).ToString();
                string st_DESC = Oreadr["Eng_desc"].ToString();

                       stSql = "INSERT INTO Configo_cf_details ([confID],[affID], [optref], " +
                    " [Itemdesc],[qty],[mult],[uprice], [xchng],[ext],[leadtime],[rnk],[pn] ,[tecVal],[itmgrp],[sext],[aext],[itmid]) VALUES ('" +
                    confID + "', '" +
                    st_affid + "', '" +
                   st_optref + "', '" +
                    st_DESC + "', " +
                   "0" + ", " +
                     "0" + ", " +
                    Oreadr["Cost_Price"].ToString() + ", " +
                       "0" + ", " +
                     Oreadr["Cost_Price"].ToString() + ", '" +
                     "" + "', " +
                           rnk++.ToString() + ", '" +
                     " " + "', '" +  //pn
                     " " + "', '" +  //tecval
                     "A" + "', " +  //itmgrp
                     "0" + ", " +  //sext
                     "0" + ", " +  //aext
                     "0" + ")";   //itmid

                MainMDI.Exec_SQL_JFS(stSql, " Configo insert Alarms in details...",usr);
            }
            OConn.Close();

            string json = "OK";

            return Json(json, "application/json");



        }


        void fill_alarms()
        {
           
         //   string TD1 = "<td style=\"border: 1px solid black;white-space: nowrap; \">", TD2 = "</td>";
          //  string TD11 = "<div class=\"checkbox checkbox-success\"><input type=\"checkbox\"",TD12=" class=\"styled\"><label></label></div>";
            string stSql = "select * FROM configo_alarmslist order by id";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //	int nb=0;
            while (Oreadr.Read())
            {
                Alarms myALRM = new Alarms();
                myALRM.alrmId = Oreadr["id"].ToString();
                myALRM.eng_desc = Oreadr["Eng_desc"].ToString();
                myALRM.code = Oreadr["code"].ToString();
                myALRM.price = Oreadr["Cost_Price"].ToString();
                myALRM.pl_code = Oreadr["PL_Code"].ToString();
                myALRM.fr_desc = Oreadr["fr_desc"].ToString();

                myALRM.relay01 = Oreadr["relay"].ToString();
                myALRM.instr = Oreadr["instr"].ToString();
            

            //    string chkd =(Oreadr["Cost_Price"].ToString() == "0") ? " checked=\"checked\"" : "";
             //   myALRM.tdchk = TD11 + chkd + TD12;
                myALarmslist.Add(myALRM);

            }
            OConn.Close();


        }


        public void  Add_options(string opt_lid, string qty)
        {


            string confID = HttpContext.Session["cfid"].ToString();// MainMDI.cfid;
            string usr = HttpContext.Session["usr"].ToString();


            string st = MainMDI.Find_One_Field("SELECT [affID]  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " and [affID]<>'' order by [affID] desc");
            int iaffid = (st == MainMDI.VIDE) ? 1 : Int32.Parse(st);

            st = MainMDI.Find_One_Field("SELECT [rnk]  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " order by rnk desc");
            int rnk = (st == MainMDI.VIDE) ? 1 : Int32.Parse(st);
            rnk++;


            string stSql = "SELECT [opt_eng_desc],[lprice]  FROM Configo_optionslist where opt_lid =" + opt_lid;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            iaffid++;
            while (Oreadr.Read())
            {

                string st_optref = " ";
                string st_DESC = Oreadr["opt_eng_desc"].ToString() + " (Qty=" + qty + ")";
                double dd = Tools.Conv_Dbl(qty) * Tools.Conv_Dbl(Oreadr["lprice"].ToString());
                string ext = Math.Round(dd, 2).ToString();
                string st_affid = (Tools.Conv_Dbl(Oreadr["lprice"].ToString()) == 0) ? " " : (iaffid++).ToString();
                stSql = "INSERT INTO Configo_cf_details ([confID],[affID], [optref], " +
             " [Itemdesc],[qty],[mult],[uprice], [xchng],[ext],[leadtime],[rnk],[pn] ,[tecVal],[itmgrp],[sext],[aext],[itmid]) VALUES ('" +
             confID + "', '" +
              st_affid + "', '" +
            st_optref + "', '" +
             st_DESC + "', '" +
            qty + "', " +
              "0" + ", " +
             Oreadr["lprice"].ToString() + ", " +
                "0" + ", " +
             ext + ", '" +
              "" + "', " +
                    rnk++.ToString() + ", '" +
              " " + "', '" +  //pn
              " " + "', '" +  //tecval
              "A" + "', " +  //itmgrp
              "0" + ", " +  //sext
              "0" + ", " +  //aext
              "0" + ")";   //itmid

                MainMDI.Exec_SQL_JFS(stSql, " Configo insert Options in details...",usr);
            }
            OConn.Close();



        }

      


	}
}