using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class settingMenu : Form
    {
        public settingMenu()
        {
            InitializeComponent();
        }

        private void activitiesMultipliersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void degage()
        {
            if (MainMDI.currDB != "Orig_PSM_FDB")
            {
                if (MainMDI.Confirm("Still working on BACKUP-DATABASE...(want to change: go to [Princing] menu and uncheck [Connected to simulation database]) " + "\n Continue exiting ????"))
                    this.Hide();
            }
            else this.Hide(); 
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            degage();
        }

        private void xchangeRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // modif_Xrate();
        }
        private void modif_Xrate()
        {
            Setng_002 set_act = new Setng_002();
            set_act.ShowDialog();
        }

        private void activitiesMultipliersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Company_Activ();
        }
        private void Company_Activ()
        {
            Setng_001 set_act = new Setng_001();
            set_act.ShowDialog();
        }

        private void Avail()
        {
         //   Setng_003 PRC_Availability = new Setng_003();
            Setng_003_Avail  PRC_Availability = new Setng_003_Avail ();
            this.Hide();
            PRC_Availability.ShowDialog();
            this.Visible = true;
        }
        private void availabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Avail();

        }

        private void tsmPricing_Click(object sender, EventArgs e)
        {

        }

        private void Simula()
        {
            //MainMDI.currDB = "Back_PSM_FDB"; 
            Setng_004 PRC_Simula = new Setng_004();
            this.Hide();
            PRC_Simula.ShowDialog();
            this.Visible = true;
        }
        private void chargercomponentCOSTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simula();
        }

        private void settingMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
         //   MainMDI.currDB = "Orig_PSM_FDB";
          //  MainMDI.Maj_M_Con(); 
          //  MainMDI.Chng_CurrDB("Orig_PSM_FDB");
        }

        private void Enable_Options()
        {
            availabilityToolStripMenuItem.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
            chargercomponentCOSTSToolStripMenuItem.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
            pGESCOMTablesToolStripMenuItem.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
           componentsToolStripMenuItem.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
           ts_avail.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
           ts_Connect.Visible = !connectSimulationdatabaseToolStripMenuItem.Checked;
           ts_discon.Visible = connectSimulationdatabaseToolStripMenuItem.Checked;
           ts_CPts.Enabled  = connectSimulationdatabaseToolStripMenuItem.Checked;
           ts_PGCTables.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked || MainMDI.User.ToLower ()=="ede";
           ts_CPts.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
           TS_Sim.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
           EnDis_IDC.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
           EnDis_VDC.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked; 
        }
        private void connectSimulationdatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string st = (connectSimulationdatabaseToolStripMenuItem.Checked) ? "Back_PSM_FDB" : "Orig_PSM_FDB";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            Enable_Options();
           // MainMDI.Maj_M_Con(); 
            MainMDI.Chng_CurrDB(st);
           // picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void settingMenu_Load(object sender, EventArgs e)
        {
            ts_PGCTables.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked || MainMDI.User.ToLower() == "ede";
            if (MainMDI.currDB == "Back_PSM_FDB")
            {
                connectSimulationdatabaseToolStripMenuItem.Checked = true;
            //    availabilityToolStripMenuItem.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
            //    chargercomponentCOSTSToolStripMenuItem.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
           //     pGESCOMTablesToolStripMenuItem.Enabled = connectSimulationdatabaseToolStripMenuItem.Checked;
                Enable_Options ();
            }
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            if (MainMDI.currDB != "Orig_PSM_FDB")
            {
                if (MainMDI.Confirm("Still working on BACKUP-DATABASE...(want to change: go to [Princing] menu and uncheck [Connected to simulation database]) " + "\n Continue exiting ????"))
                    this.Hide();
            }
            else this.Hide();
        }

        private void PGC_TAbles()
        {
            char opera = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat") ? 'W' : 'R';
            Setng_005 set_PGC_Tables = new Setng_005(opera);
            set_PGC_Tables.ShowDialog();
        }
        private void pGESCOMTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PGC_TAbles();
        }

        private void Admin_Cpts()
        {
            Options_Admin child3 = new Options_Admin('M', "*");
            this.Hide();
            child3.ShowDialog();
            this.Visible = true;
        }
        
        private void componentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Cpts();
        }

        private void ts_Connect_Click(object sender, EventArgs e)
        {
         //   connectSimulationdatabaseToolStripMenuItem_Click(sender, e);
          //  Enable_Options();
            connectSimulationdatabaseToolStripMenuItem.Checked =true;
            connectSimulationdatabaseToolStripMenuItem_Click(sender, e);
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void ts_discon_Click(object sender, EventArgs e)
        {
            connectSimulationdatabaseToolStripMenuItem.Checked =false;
            connectSimulationdatabaseToolStripMenuItem_Click(sender, e);
        }

        private void ts_exit_Click(object sender, EventArgs e)
        {
            degage();
        }

        private void ts_avail_Click(object sender, EventArgs e)
        {
            Avail();
        }

        private void TS_Sim_Click(object sender, EventArgs e)
        {
            Simula();
        }

        private void ts_PGCTables_Click(object sender, EventArgs e)
        {
            PGC_TAbles();
        }

        private void ts_CPts_Click(object sender, EventArgs e)
        {
            Admin_Cpts();
        }

        private void QuotesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ts_Activ_Click(object sender, EventArgs e)
        {
           
        }

        private void ts_acct_Click(object sender, EventArgs e)
        {
            modif_Xrate();
        }

        
        private void admin_Click(object sender, EventArgs e)
        {
            if (MainMDI.user_Admin())
            {
                dlg_Admin child3 = new dlg_Admin();
                child3.ShowDialog();
                
            }
            else MessageBox.Show("sorry, access denied......Call your Admin........"); 
        }

        private void EnDis_VDC_Click(object sender, EventArgs e)
        {
            dlg_VDC_IDC_Disable disVDC_IDC = new dlg_VDC_IDC_Disable("1", "V");
            disVDC_IDC.ShowDialog();

        }

        private void EnDis_IDC_Click(object sender, EventArgs e)
        {
            dlg_VDC_IDC_Disable disVDC_IDC = new dlg_VDC_IDC_Disable("1", "I");
            disVDC_IDC.ShowDialog();
        }

        private void SA_Manage(char sa)
        {
            dlg_Sales_Agencies SA_gest = new dlg_Sales_Agencies(sa);
            SA_gest.ShowDialog();
            SA_gest.Dispose();
        }
        private void tsb_SAles_gest_Click(object sender, EventArgs e)
        {
            SA_Manage('S');
        }

        private void tsb_AG_gest_Click(object sender, EventArgs e)
        {
            SA_Manage('A');
        }

        private void company_Click(object sender, EventArgs e)
        {
            Company_Activ();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SA_Manage('S');
        }

        private void agenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SA_Manage('A');
        }

        private void Cpts_XLsetting()
        {
            Setng_006_XLcpts cptXL = new Setng_006_XLcpts ();
            cptXL.ShowDialog();
            cptXL.Dispose();
        }
        private void XLpricelisttlsMenuItem_Click(object sender, EventArgs e)
        {
            Cpts_XLsetting();

        }
    }
}