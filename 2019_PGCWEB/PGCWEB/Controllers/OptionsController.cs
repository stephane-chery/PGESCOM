using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PGCWEB.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using EAHLibs;


namespace PGCWEB.Controllers
{
    public class OptionsController : Controller
    {

        List<Options> myOptionslist = new List<Options>();
        public static Lib1 Tools = new Lib1();

        //
        // GET: /Options/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult options()
        {
            fill_options();
            return View("~/Views/Options/options.cshtml", myOptionslist);

        }

        void fill_options()
        {

            //   string TD1 = "<td style=\"border: 1px solid black;white-space: nowrap; \">", TD2 = "</td>";
            //  string TD11 = "<div class=\"checkbox checkbox-success\"><input type=\"checkbox\"",TD12=" class=\"styled\"><label></label></div>";
            string stSql = "select * FROM Configo_optionslist where opt_lid > 54 order by opt_lid";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //	int nb=0;
            while (Oreadr.Read())
            {
                Options myOPT = new Options();
                myOPT.opt_lid = Oreadr["opt_lid"].ToString();
                myOPT.opt_eng_desc = Oreadr["opt_eng_desc"].ToString();
                myOPT.price = Oreadr["lprice"].ToString();

                myOptionslist.Add(myOPT);

            }
            OConn.Close();


        }


        public JsonResult Save_ch_options(string c_opt_list)
        {


            string confID = HttpContext.Session["cfid"].ToString() ;   //MainMDI.cfid;
            string usr = HttpContext.Session["usr"].ToString();



            //
            MainMDI.Exec_SQL_JFS("delete [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " and itmid=2", "Del configo det_options...",usr);
            //

            string st = MainMDI.Find_One_Field("SELECT [affID]  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " and [affID]<>'' order by [affID] desc");
            int iaffid = (st == MainMDI.VIDE) ? 1 : Int32.Parse(st);

            st = MainMDI.Find_One_Field("SELECT [rnk]  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where confID=" + confID + " order by rnk desc");
            int rnk = (st == MainMDI.VIDE) ? 1 : Int32.Parse(st);
            rnk++;

            string G_opt_list = "(" + c_opt_list + ")";
            string stSql = "SELECT [opt_eng_desc],[lprice]  FROM Configo_optionslist where opt_lid in " + G_opt_list;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            iaffid++;
            while (Oreadr.Read())
            {

                string st_optref = " ";
                string st_DESC = Oreadr["opt_eng_desc"].ToString();
                string st_affid = (Tools.Conv_Dbl(Oreadr["lprice"].ToString()) == 0) ? " " : (iaffid++).ToString();
                stSql = "INSERT INTO Configo_cf_details ([confID],[affID], [optref], " +
             " [Itemdesc],[qty],[mult],[uprice], [xchng],[ext],[leadtime],[rnk],[pn] ,[tecVal],[itmgrp],[sext],[aext],[itmid]) VALUES ('" +
             confID + "', '" +
              st_affid + "', '" +
            st_optref + "', '" +
             st_DESC + "', " +
            "0" + ", " +
              "0" + ", " +
             Oreadr["lprice"].ToString() + ", " +
                "0" + ", " +
              Oreadr["lprice"].ToString() + ", '" +
              "" + "', " +
                    rnk++.ToString() + ", '" +
              " " + "', '" +  //pn
              " " + "', '" +  //tecval
              "A" + "', " +  //itmgrp
              "0" + ", " +  //sext
              "0" + ", " +  //aext
              "2" + ")";   //itmid

                MainMDI.Exec_SQL_JFS(stSql, " Configo insert Options in details...",usr);
            }
            OConn.Close();

            string json = "OK";

            return Json(json, "application/json");



        }


      



	}
}