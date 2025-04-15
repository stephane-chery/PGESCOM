using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PGCWEB.Models;
using EAHLibs;
using System.Data.Sql;
using System.Data.SqlClient;
//using Excel = Microsoft.Office.Interop.Excel;

using System.IO;



namespace PGCWEB.Controllers
{

    public class quot_info
    {
        public string qtnb { get; set; }
        public string qtlid { get; set; }
        public string err_msg { get; set; }
       
    }

    public class BfrQuoteController : Controller
    {
        //
        // GET: /BfrQuote/

        public static Lib1 Tools = new Lib1();
        List<bfrQuote> mybfrQuotelist = new List<bfrQuote>();
        List<quot_info> mylstqtinfo = new List<quot_info>();
        public ActionResult Index()
        {


            return View();
        }
        public ActionResult bfrQuote()
        {
            fill_bfrQuote();
            return View("~/Views/BfrQuote/Index.cshtml", mybfrQuotelist);

        }







        void fill_bfrQuote()
        {
            string cfid = HttpContext.Session["cfid"].ToString();
            if (cfid != "")
            {
                //   string TD1 = "<td style=\"border: 1px solid black;white-space: nowrap; \">", TD2 = "</td>";
                //  string TD11 = "<div class=\"checkbox checkbox-success\"><input type=\"checkbox\"",TD12=" class=\"styled\"><label></label></div>";
                string stSql = "select * FROM Configo_cf_details where confID=" + cfid + " order by rnk ";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                int nb = 0;
                double AmntTOT = 0;
                while (Oreadr.Read())
                {
                    bfrQuote mybfrQuote = new bfrQuote();
                    mybfrQuote.lineid = Oreadr["affID"].ToString();
                    mybfrQuote.optionref = Oreadr["optref"].ToString();
                    if (nb == 0)
                    {
                        mybfrQuote.item = Oreadr["optref"].ToString();
                        nb++;
                    }
                    else mybfrQuote.item = (Oreadr["optref"].ToString().Length > 2) ? Oreadr["optref"].ToString() + "=" + Oreadr["itemdesc"].ToString() : Oreadr["itemdesc"].ToString();
                    mybfrQuote.qty = (Oreadr["qty"].ToString() == "0") ? " " : Oreadr["qty"].ToString();
                    mybfrQuote.multy = (Oreadr["mult"].ToString() == "0") ? " " : Oreadr["mult"].ToString(); // Oreadr["mult"].ToString();
                    mybfrQuote.uprice = (Oreadr["uprice"].ToString() == "0") ? " " : Oreadr["uprice"].ToString(); // Oreadr["uprice"].ToString();
                    mybfrQuote.ext = (Oreadr["ext"].ToString() == "0") ? " " : Oreadr["ext"].ToString(); // Oreadr["ext"].ToString();
                    AmntTOT += Tools.Conv_Dbl(Oreadr["ext"].ToString());

                    mybfrQuotelist.Add(mybfrQuote);

                }
                OConn.Close();
                if (nb > 0)
                {
                    bfrQuote mybfrQuoteTOT = new bfrQuote();
                    mybfrQuoteTOT.lineid = " ";
                    mybfrQuoteTOT.optionref = " ";
                    mybfrQuoteTOT.item = "TOTAL ";
                    mybfrQuoteTOT.qty = " ";
                    mybfrQuoteTOT.multy = " ";
                    mybfrQuoteTOT.uprice = " ";
                    mybfrQuoteTOT.ext = AmntTOT.ToString();

                    mybfrQuotelist.Add(mybfrQuoteTOT);

                }
            }
            else ViewBag.error = "Sorry, this Configuration is Empty or Invalid ..................";

        }


        //        Excel

        public void ExportToExcel()
        {
            //   string Filename = "ExcelFrom" + DateTime.Now.ToString("mm_dd_yyy_hh_ss_tt") + ".xls";
            //   string FolderPath = HttpContext.Server.MapPath("/XLfiles/");
            //   string FilePath = System.IO.Path.Combine(FolderPath, Filename);

            //   //Step-1: Checking: If file name exists in server then remove from server.
            //   if (System.IO.File.Exists(FilePath))
            //   {
            //       System.IO.File.Delete(FilePath);
            //   }



            //   //Step-2: Get Html Data & Converted to String
            //   string HtmlResult = RenderRazorViewToString("~/Views/Home/GenerateExcel.cshtml", PGCWEB.Models.bfrQuote());




            //   //Step-4: Html Result store in Byte[] array
            ////   byte[] ExcelBytes = System.Text.Encoding.ASCII.GetBytes(HtmlResult);


            //   //Step-5: byte[] array converted to file Stream and save in Server
            //   using (System.IO.Stream file = System.IO.File.OpenWrite(FilePath))
            //   {
            //       file.Write(ExcelBytes, 0, ExcelBytes.Length);
            //   }

            //   //Step-6: Download Excel file 
            //   Response.ContentType = "application/vnd.ms-excel";
            //   Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(Filename));
            //   Response.WriteFile(FilePath);
            //   Response.End();
            //   Response.Flush();
        }

        protected string RenderRazorViewToString(string viewName, object model)
        {
            if (model != null)
            {
                ViewData.Model = model;
            }
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                return sw.GetStringBuilder().ToString();
            }
        }









        bool fill_Objdata(ref string[,] objData, int NBCols)
        {
            string cfid = HttpContext.Session["cfid"].ToString();
            if (cfid != "")
            {


                //   string TD1 = "<td style=\"border: 1px solid black;white-space: nowrap; \">", TD2 = "</td>";
                //  string TD11 = "<div class=\"checkbox checkbox-success\"><input type=\"checkbox\"",TD12=" class=\"styled\"><label></label></div>";
                string stSql = "select * FROM Configo_cf_details where confID=" + cfid + " order by rnk ";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                int nb = 0, i = 0;
                double AmntTOT = 0;
                while (Oreadr.Read())
                {
                    //  bfrQuote mybfrQuote = new bfrQuote();
                    objData[i, 0] = Oreadr["affID"].ToString();

                    //   mybfrQuote.optionref = Oreadr["optref"].ToString();
                    if (nb == 0)
                    {
                        objData[i, 1] = Oreadr["optref"].ToString();
                        nb++;
                    }
                    else
                    {
                        string tt = (Oreadr["optref"].ToString().Length > 2) ? Oreadr["optref"].ToString() + "=" + Oreadr["itemdesc"].ToString() : Oreadr["itemdesc"].ToString();
                        objData[i, 1] = tt;
                    }

                    objData[i, 2] = ((Oreadr["qty"].ToString() == "0") ? " " : Oreadr["qty"].ToString());
                    objData[i, 3] = ((Oreadr["uprice"].ToString() == "0") ? " " : Oreadr["uprice"].ToString());
                    objData[i, 4] = ((Oreadr["ext"].ToString() == "0") ? " " : Oreadr["ext"].ToString());

                    AmntTOT += Tools.Conv_Dbl(Oreadr["ext"].ToString());

                    i++;


                }
                OConn.Close();
                if (nb > 0)
                {
                    objData[i, 0] = " ";
                    objData[i, 1] = "TOTAL ";
                    objData[i, 2] = " ";
                    objData[i, 3] = " ";
                    objData[i, 4] = AmntTOT.ToString();


                }
                return true;
            }
            return false;

        }
        public void XL_configoold()
        {
            //bool fin = false;

            //string Fname = "Charger_CFG_" + DateTime.Now.ToString("mm_dd_yyy_hh_ss_tt") + ".xls";
            //string FolderPath = HttpContext.Server.MapPath("/XLfiles/");
            //string FilePath = System.IO.Path.Combine(FolderPath, Fname);
            //while (!fin)
            //{

            //    fin = true;
            //    int NBCols = 5;
            //    object[] objHdrs = new object[5] { "Item #", "Item description", "QTY", "Unit Price", "Extention" };


            //    string CellFM = "A1", CellTO = "E1";

            //    object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols];

            //    fill_Objdata(ref objData, NBCols);

            //    XL_EXPORT(Fname, objHdrs, NBCols, CellFM, CellTO, objData, FilePath);

            //    Response.ContentType = "application/vnd.ms-excel";
            //    Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(Fname));
            //    Response.WriteFile(FilePath);
            //    Response.End();
            //    Response.Flush();
            //}


        }





        private void XL_EXPORT(string FName, object[] objHdrs, int HdrsNB, string CellFM, string CellTO, object[,] objData, string filepath)
        {

            ////   System.IO.File.Delete(MainMDI.XL_Path + @"\" + FName);// "CMS_CALC.xls");
            //   Object m_objOpt = System.Reflection.Missing.Value;
            //   Excel.Application m_objXL = new Excel.Application();
            //   Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            //   Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            //   Excel.Sheets m_objSheets = m_objBook.Worksheets;
            //   Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);


            //   Excel.Range m_objRng = m_objSheet.get_Range(CellFM, CellTO);
            //   m_objRng.Value2 = objHdrs;
            //   Excel.Font m_objFont = m_objRng.Font;
            //   m_objFont.Bold = true;


            //   m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            //   m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, HdrsNB);
            //   m_objRng.Value2 = objData;

            //   //m_objRng = m_objSheet.get_Range("D1").EntireColumn;
            //   //m_objRng.EntireColumn.NumberFormat = "DD/MM/YYYY";


            //   m_objBook.SaveAs(filepath, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            //   m_objBook.Close(false, m_objOpt, m_objOpt);
            //   m_objXL.Quit();
            //   //  ??? NO  data
            //   //   MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\" + FName);

            // //  MainMDI.EXEC_FILE("EXCEL.exe", MainMDI.XL_Path + @"\" + FName);
        }

        public void XL_configo()
        {

            int NBCols = 5;
            string[] objHdrs = new string[5] { "Item #", "Item description", "QTY", "Unit Price", "Extension" };
            string[,] objData = new string[MainMDI.MAX_XLlines_XPRT, NBCols];

            for (int u = 0; u < MainMDI.MAX_XLlines_XPRT; u++) objData[u, 0] = "*";



            string quotnb = HttpContext.Session["quotnb"].ToString(),
            prj = HttpContext.Session["prjname"].ToString(),
            cust_ref = HttpContext.Session["cus_ref"].ToString(),
            userNM = HttpContext.Session["usrFnmLnm"].ToString();


            fill_Objdata(ref objData, NBCols);

            OfficeOpenXml.ExcelPackage mypkg = new OfficeOpenXml.ExcelPackage();
            OfficeOpenXml.ExcelWorksheet myws = mypkg.Workbook.Worksheets.Add("Charger Quote");

            myws.Cells["A1"].Value = "Quote #"; myws.Cells["B1"].Value = quotnb;

            myws.Cells["A2"].Value = "Project Name"; myws.Cells["B2"].Value = prj;

            myws.Cells["A3"].Value = "Customer Ref."; myws.Cells["B3"].Value = cust_ref;

            myws.Cells["A4"].Value = "date"; myws.Cells["B4"].Value = string.Format("{0:dd-MMMM-yyyy}", DateTimeOffset.Now);
            myws.Cells["A5"].Value = "User Name"; myws.Cells["B5"].Value = userNM;


            myws.Cells["A8"].Value = objHdrs[0];
            myws.Cells["B8"].Value = objHdrs[1];
            myws.Cells["C8"].Value = objHdrs[2];
            myws.Cells["D8"].Value = objHdrs[3];
            myws.Cells["E8"].Value = objHdrs[4];

            int deb = 9;

            for (int i = 0; i < objData.Length && objData[i, 0] != "*"; i++)
            {
                myws.Cells[string.Format("A{0}", deb)].Value = objData[i, 0];
                myws.Cells[string.Format("B{0}", deb)].Value = objData[i, 1];
                myws.Cells[string.Format("C{0}", deb)].Value = objData[i, 2];
                myws.Cells[string.Format("D{0}", deb)].Value = objData[i, 3];
                myws.Cells[string.Format("E{0}", deb)].Value = objData[i, 4];
                deb++;
            }
            myws.Cells["A:AZ"].AutoFitColumns();

            long NBdatetime = DateTime.Now.ToFileTime();
            string QtXLFNM = "XL_QT_" + NBdatetime.ToString();

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=" + QtXLFNM +".xls");
            Response.BinaryWrite(mypkg.GetAsByteArray());
            Response.End();

        }

 


        void SaveQTfrom_bfrQ(string quotnb, string userid, string cus_ref, string prjname, ref string iqlid, ref string err_msg)
        {


            err_msg = "";
            string cfid = HttpContext.Session["cfid"].ToString();
            string usr = HttpContext.Session["usr"].ToString();
            string ipa = HttpContext.Session["ipa"].ToString();

            MainMDI.Write_JFS("debug.....In SaveQTfrom_bfrQ..... cfid=" + cfid.ToString() + "  usr=" + usr + "   new Quote #.....newQTnb :" + quotnb, "configo");
            if (cfid != "")
            {



                //save quoteinfo
                string ddstr = System.DateTime.Now.ToString("yyyy/MM/dd");
                string stSql = "INSERT INTO configo_Quotes ([QID],[userid],[Customer], [C_date], [cust_ref],[f4],[prjName]) VALUES (" + quotnb + ", '" + userid + "', '" +cfid.ToString () +"', '" +
                  ddstr + "', '" + cus_ref + "', '" + ipa + "', '"+ prjname + "')";   //itmid

                HttpContext.Session["quotnb"] = quotnb;
                HttpContext.Session["prjname"] = prjname;
                HttpContext.Session["cus_ref"] = cus_ref;

                MainMDI.Exec_SQL_JFS(stSql, " Configo insert quote info...", usr);

                iqlid = MainMDI.Find_One_Field("select C_Qlid from configo_Quotes where QID=" + quotnb);
                if (Tools.Conv_Dbl(iqlid) > 0)
                {

                    stSql = "select * FROM Configo_cf_details where confID=" + cfid + " order by rnk ";
                    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                    OConn.Open();
                    SqlCommand Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSql;
                    SqlDataReader Oreadr = Ocmd.ExecuteReader();
                    int nb = 0;

                    while (Oreadr.Read())
                    {

                        string st_item = "";

                        if (nb == 0)
                        {
                            st_item = Oreadr["optref"].ToString();
                            nb++;
                        }
                        else st_item = (Oreadr["optref"].ToString().Length > 2) ? Oreadr["optref"].ToString() + "=" + Oreadr["itemdesc"].ToString() : Oreadr["itemdesc"].ToString();
                        string st_qty = Oreadr["qty"].ToString(); //(Tools.Conv_Dbl(Oreadr["qty"].ToString()) == 0) ? "1" : Oreadr["qty"].ToString();

                        string st_multy = Oreadr["mult"].ToString();// (Tools.Conv_Dbl(Oreadr["mult"].ToString()) == 0) ? "1" : Oreadr["mult"].ToString(); // Oreadr["mult"].ToString();
                        string st_uprice = Oreadr["uprice"].ToString();// (Tools.Conv_Dbl(Oreadr["uprice"].ToString()) == 0) ? "0" : Oreadr["uprice"].ToString(); // Oreadr["uprice"].ToString();
                        string st_ext = Oreadr["ext"].ToString(); //(Tools.Conv_Dbl(Oreadr["ext"].ToString()) == 0) ? "0" : Oreadr["ext"].ToString(); // Oreadr["ext"].ToString();
                                                                  //AmntTOT += Tools.Conv_Dbl(Oreadr["ext"].ToString());

                        stSql = "INSERT INTO Configo_Quotes_details ([Qlid],[affID], [optref], " +
                                " [Itemdesc],[qty],[mult],[uprice], [xchng],[ext],[leadtime],[rnk],[pn] ,[tecVal],[itmgrp],[sext],[aext],[itmid]) VALUES ('" +
                                iqlid + "', '" +
                                  Oreadr["affID"].ToString() + "', '" +
                                  " " + "', '" +
                                st_item + "', " +
                                st_qty + ", " +
                               st_multy + ", " +
                                  st_uprice + ", " +
                                      "1" + ", " +
                                     st_ext + ", '" +
                                      " " + "', " +
                                  Oreadr["rnk"].ToString() + ", '" +
                                      " " + "', '" +  //pn
                                  " " + "', '" +  //tecval
                                     "A" + "', " +  //itmgrp
                                  "0" + ", " +  //sext
                                 "0" + ", " +  //aext
                               "0" + ")";   //itmid
                        MainMDI.Exec_SQL_JFS(stSql, " Configo insert quote details...", usr);
                    }
                    OConn.Close();

                }
                else err_msg = "Sorry, can not save this quote please contact Site Administrator......stsql="+stSql +"       iqlid=" + iqlid;
            }
            else err_msg = "Sorry, this Configuration is Empty or Invalid ..................";

        } 

       public JsonResult savquote(string prjname, string cust_ref)
       {

         //   MainMDI.Write_JFS("debug.....in savquote   ....", "configo");
            long newQTnb = 0;
           string iqlid = "", err_msg = "";

           string res = MainMDI.Find_One_Field("select Qid from [dbo].[configo_Quotes] order by qid desc ");
           if (Tools.Conv_Dbl(res) > 0)
           {
               newQTnb = Int64.Parse(res) + 1;
               int t = 0;
               for (t=0; t < 3; t++)
               {
                   if (MainMDI.Find_One_Field("SELECT [C_Qlid] from configo_Quotes WHERE [QID]=" + newQTnb.ToString()) == MainMDI.VIDE) t = 999;
                   else newQTnb++;
               }
                if (t > 3) SaveQTfrom_bfrQ(newQTnb.ToString(), HttpContext.Session["usrid"].ToString(), cust_ref, prjname, ref iqlid, ref err_msg);
                else MainMDI.Write_JFS("debug.....can not create new Quote #.....newQTnb :" + newQTnb.ToString()+" t="+t.ToString (), "configo");
           }

           quot_info myqinfo = new quot_info();
           myqinfo.qtnb = newQTnb.ToString();
           myqinfo.qtlid = iqlid;
           myqinfo.err_msg = err_msg;
           mylstqtinfo.Add(myqinfo);
           return Json(mylstqtinfo, JsonRequestBehavior.AllowGet);


       }




	}
}