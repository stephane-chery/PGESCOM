using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace PGESCOM
{
    public partial class disp_RPT : Form
    {
        private string in_p1, in_p2;
        private ConnectionInfo crConnectionInfo = new ConnectionInfo();

        public disp_RPT(string x_p1, string x_p2)
        {
            InitializeComponent();

            in_p1 = x_p1;
            in_p2 = x_p2;
         
            crConnectionInfo.ServerName = "NTSERVER2";
            crConnectionInfo.DatabaseName = "Orig_PSM_FDB";
            crConnectionInfo.UserID = "pgc_25";
            crConnectionInfo.Password = "25_hada_pgc";
        }

        private void disp_RPT_Load(object sender, EventArgs e)
        {
            disp_crConfig(in_p1 ,in_p2 );
        }
        private void disp_crConfig(string _confNm,string _irrevLID)
        {

            ReportDocument RDoc = new ReportDocument();
            ParameterField Paramf = new ParameterField();
            ParameterFields ParamFlds = new ParameterFields();
            ParameterDiscreteValue ParamDV = new ParameterDiscreteValue();

            Paramf.Name = "@CFNM";
            ParamDV.Value = _confNm;
            Paramf.CurrentValues.Add(ParamDV);
            ParamFlds.Add(Paramf);

            Paramf = new ParameterField();
            Paramf.Name = "@IRRevLID";
            ParamDV = new ParameterDiscreteValue();
            ParamDV.Value = _irrevLID;
            Paramf.CurrentValues.Add(ParamDV);
            ParamFlds.Add(Paramf);





            CRV_C.ParameterFieldInfo = ParamFlds;
            //     string repPath = Application.StartupPath + @"\..\..\CR_Reports\crstl_Config.rpt";
            string repPath = Application.StartupPath + @"\CR_Reports\crstl_Config.rpt";
            RDoc.Load(repPath);
            CRV_C.ReportSource = RDoc;
            for (int i = 0; i < CRV_C.LogOnInfo.Count; i++) CRV_C.LogOnInfo[i].ConnectionInfo = crConnectionInfo;
/*
            string FNword=Application.StartupPath + @"\CF_RPWord.doc";
            RDoc.ExportToDisk(ExportFormatType.WordForWindows, FNword);
 * */

            /*
            {
                
                ExportOptions CRexOP = new ExportOptions();


                CRexOP.ExportDestinationType = ExportDestinationType.DiskFile;
                DiskFileDestinationOptions CRDiskFileDestinationOptions = new DiskFileDestinationOptions();
                CRDiskFileDestinationOptions.DiskFileName = Application.StartupPath + @"\CF_RPWord.doc";
                CRexOP.ExportFormatType = ExportFormatType.WordForWindows;
                CRexOP.ExportFormatOptions = ExportOptions.CreatePdfRtfWordFormatOptions(); 
                CRexOP.ExportDestinationOptions = CRDiskFileDestinationOptions;
                
                               RDoc.Export(CRexOP);
            }
             */








            //     RDoc.SetDatabaseLogon("sa", "primax", "NTSERVER2", "Orig_PSM_FDB");
            /*
                        Database crDB;
                        Tables crTables;
                        Table crTable;
                        TableLogOnInfo crTableLogOnInfo;
                        ConnectionInfo crConnectionInfo = new ConnectionInfo();
                        crConnectionInfo.ServerName = "NTSERVER2";
                        crConnectionInfo.DatabaseName = "Orig_PSM_FDB";
                        crConnectionInfo.UserID = "sa";
                        crConnectionInfo.Password = "primax";
                        crDB = RDoc.Database;
                        crTables = crDB.Tables;
                        for (int i = 0; i < crTables.Count; i++)
                        {
                            crTable = crTables[i];
                            crTableLogOnInfo = crTable.LogOnInfo;
                            crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                            crTable.ApplyLogOnInfo(crTableLogOnInfo);
                        }

            */




            //    string rptPath = Application.StartupPath + @"\CR_config.rpt";
            //    CRV_C.ReportSource = rptPath;
        }

        private void CRV_C_DoubleClick(object sender, EventArgs e)
        {
              
        }
    }
}