using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBsizing.Models;

namespace PBsizing.Controllers
{
    public class StatisticsController : Controller
    {
        //
        // GET: /Statistics/
        //BatListEntities2 mydb = new BatListEntities2();
        Orig_PSM_FDBEntities2 mydb = new Orig_PSM_FDBEntities2();
        public ActionResult Statistics()
        {
            return View();
        }

        public JsonResult stq07x1(string c_dtfrom, string c_dtTo)
        {
          string  json = "OK";
            Gen_STaQuote(c_dtfrom, c_dtTo);

             return Json(json, "application/json");
        }

        private void Gen_STaQuote(string c_dtfrom, string c_dtTo)
        {
            string stout = "";
            try
            {
                string myuserNm = HttpContext.Session["usr"].ToString();
                mydb.Database.ExecuteSqlCommand("delete PSM_WB_STQuote where Usr='" + myuserNm + "'");
                string stSql = " insert into PSM_WB_STQuote  (Q_date,  Sale, Quote,  Customer, Amount, curr, ProjectName, Tel1, M_Adrs, usr) " +
                               " SELECT  PSM_Q_IGen.Opndate AS Q_date,PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Sale, PSM_Q_IGen.Quote_ID as Quote,PSM_COMPANY.Cpny_Name1 as Customer,[Quotes-TOT_by_lastRevision].BigTot AS Amount,  PSM_Q_IGen.curr, PSM_Q_IGen.ProjectName,    PSM_COMPANY.Tel1, PSM_COMPANY.M_Adrs ,'" + myuserNm + "' as usr " +
                             " FROM            PSM_Q_IGen INNER JOIN  PSM_COMPANY ON PSM_Q_IGen.CPNY_ID = PSM_COMPANY.Cpny_ID INNER JOIN   PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN  PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid INNER JOIN " +
                             "                 [Quotes-TOT_by_lastRevision] ON PSM_Q_SOL.Sol_LID = [Quotes-TOT_by_lastRevision].Sol_LID GROUP BY PSM_Q_IGen.Quote_ID, PSM_Q_IGen.ProjectName, PSM_Q_IGen.Opndate, PSM_COMPANY.Cpny_Name1, PSM_COMPANY.M_Adrs, PSM_COMPANY.Tel1, " +
                             "                 PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name, PSM_Q_SOL.Sol_Name, PSM_Q_IGen.curr, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, [Quotes-TOT_by_lastRevision].BigTot,  PSM_Q_IGen.i_Quoteid " +
                             " HAVING          (PSM_Q_IGen.Opndate >= CONVERT(smalldatetime, '" + c_dtfrom + "', 102)) AND (PSM_Q_IGen.Opndate <= CONVERT(smalldatetime, '" + c_dtTo + "', 102)) " +
                             " ORDER BY PSM_Q_IGen.Quote_ID, Q_date, PSM_Q_SOL.Sol_Name DESC";
                mydb.Database.ExecuteSqlCommand(stSql);

                //  mydb.Save_Cab_Dim(inch, c_BN, decimal.Parse(c_BH), decimal.Parse(c_BL), decimal.Parse(c_BWD), CAB_A, CAB_B, CAB_C, CAB_D, CAB_HP, CAB_HCB, CAB_HD1_2, Gage, Cust_CAB_HEI, Cust_CAB_WIDTH, Cust_CAB_Depth, myuserNm);
            }
            catch (Exception ex)
            {
               stout = ex.Message;


            }
        }






    }
}
