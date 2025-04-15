using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using EAHLibs;

namespace PGESCOM
{
    public partial class UPS_maker : Form
    {
        Thread m_WkTHRD;
        ManualResetEvent m_EventStopThread;
        ManualResetEvent m_EventThreadStopped;
        public deleg_RepTrace m_RepTrace;
        public deleg_endTHR m_endTHR;

        public static Lib1 Tools = new Lib1();
        public const double coef_KW = 0.15;
        public char curr_PHS = '1';
        public double CH_COST = 0;

        public UPS_maker()
        {
            InitializeComponent();
        }

        private void opbattK_CheckedChanged(object sender, EventArgs e)
        {
            pnlBCap.Visible = opbattK.Checked;
            pnl_kw.Visible = !opbattK.Checked;
        }

        private void opbattU_CheckedChanged(object sender, EventArgs e)
        {
            pnlBCap.Enabled = !opbattU.Checked;
            pnl_kw.Visible = opbattU.Checked;
            txKW.Text = Math.Round(Tools.Conv_Dbl(txKVA.Text) * coef_KW, 0).ToString();

            //if (opbattU.Checked)
            //{
                //grp0.Enabled = false;
                //pnl_kw.Enabled = true;
            //}
            //else
            //{
                //grp0.Enabled = true;
                //pnl_kw.Enabled = false;
            //}
        }

        private void txKVA_TextChanged(object sender, EventArgs e)
        {
            //txPOut.Text = ToolStrip.
        }

        private void UPS_maker_Load(object sender, EventArgs e)
        {
            cbmodels.SelectedIndex = 0;
            cbphs_out.SelectedIndex = 0;
            cbphs_in.SelectedIndex = 0;
            cbKVA.SelectedIndex = 0;
            cbACoutV.SelectedIndex = 0;
            cbACinputV.SelectedIndex = 0;
            cbDCbus.SelectedIndex = 0;
            cbPF.SelectedIndex = 0;
            cbphs_Bps.SelectedIndex = 0;
            cbbps_inputV.SelectedIndex = 0;

            //set init value
            cbmodels.Text = "P850U";
            cbphs_out.Text = "1";
            cbKVA.Text = "30";
            cbACoutV.Text = "208";
            cbDCbus.Text = "240";
            cbphs_in.Text = "3";
            cbACinputV.Text = "600";
            cbphs_Bps.Text = "3";
            cbbps_inputV.Text = "600";
            cbPF.Text = "0.8";
            //txFreq.Select();
            picValid.Select();
        }

        private void TxPOut_Enter(object sender, EventArgs e)
        {

        }

        private void CbVacout_SelectedIndexChanged(object sender, EventArgs e)
        {
            txvac.Text = Math.Round(Tools.Conv_Dbl(cbACoutV.Text) / Math.Sqrt(3), 0).ToString();
        }

        bool check_para()
        {
            bool res = false, bypas = true;

            if (cbmodels.Text == "Select" || cbphs_out.Text == "Select" || cbphs_in.Text == "Select" || cbACoutV.Text == "Select" || cbACinputV.Text == "Select" || 
                cbDCbus.Text == "Select" || cbPF.Text == "Select" || cbKVA.Text == "Select") res = false;
            else res= true;
            if (chk_bypass.Checked) bypas = (cbbps_inputV.Text != "Select" && cbphs_Bps.Text != "Select");
            //MessageBox.Show("res= " + res.ToString() + "   bypas= " + bypas.ToString());

            return bypas && res;
        }

        void do_Calcul()
        {
            //double Vpri_smpl = (cbphs.Text == "3")
            if (check_para())
            {
                txModel.Text = cbmodels.Text + "-" + cbphs_out.Text + "-" + txKVA.Text + "-" + cbACoutV.Text + "-" + cbDCbus.Text;
                //lmdl_ext.Text = "-" + cbphs_in.Text + "-" + cbACinputV.Text;
                tx_locModel.Text = txModel.Text + "-" + cbphs_in.Text + "-" + cbACinputV.Text;
                if (chk_bypass.Checked) tx_locModel.Text += "-" + cbphs_Bps.Text + "-" + cbbps_inputV.Text;
                //Charger_UPS myUPS = new Charger_UPS();
                Calc_UPS_COST();
            }
            else MessageBox.Show("ERROR Selection....................");
        }

        void Display_UPSMDL()
        {
            //double Vpri_smpl = (cbphs.Text == "3")
            if (check_para())
            {
                txModel.Text = cbmodels.Text + "-" + cbphs_out.Text + "-" + txKVA.Text + "-" + cbACoutV.Text + "-" + cbDCbus.Text;
                //lmdl_ext.Text = "-" + cbphs_in.Text + "-" + cbACinputV.Text;
                tx_locModel.Text = txModel.Text + "-" + cbphs_in.Text + "-" + cbACinputV.Text;
                if (chk_bypass.Checked) tx_locModel.Text += "-" + cbphs_Bps.Text + "-" + cbbps_inputV.Text;
                //Charger_UPS myUPS = new Charger_UPS();
                //Calc_UPS_COST();
            }
            else MessageBox.Show("ERROR Selection....................");
        }

        private void chk_bypass_CheckedChanged(object sender, EventArgs e)
        {
            pnl_bps.Visible = chk_bypass.Checked;
        }

        void Calc_UPS_COST()
        {
            //curr_PHS = phs; //(toolBar1.Buttons.IndexOf(e.Button) == 1) ? '1': '3';
            m_EventStopThread.Reset();
            m_EventThreadStopped.Reset();
            m_WkTHRD = new Thread(new ThreadStart(this.P850U_cost));
            m_WkTHRD.Start();
        }

        private void P850U_cost()
        {
            Charger_UPSCOST_P850U P85i = new Charger_UPSCOST_P850U(m_EventStopThread, m_EventThreadStopped, this);
            P85i.Cal_ALL_UPS_COST13();
        }

        private void cbphs_in_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbphs_Bps.Text == "Select") cbphs_Bps.Text = cbphs_in.Text;
        }

        private void cbACinputV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbps_inputV.Text == "Select") cbbps_inputV.Text = cbACinputV.Text;
        }

        private void cbbps_inputV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picValid_Click(object sender, EventArgs e)
        {
            lvQuotes.Items.Clear();
            lv_TV.Items.Clear();
            Display_UPSMDL();
            lUPS_price.Text = seekUPSprice(cbmodels.Text, cbphs_out.Text, cbKVA.Text, cbACoutV.Text, cbDCbus.Text, cbphs_in.Text, cbACinputV.Text);

            //Cal_ALL_UPS_COST13();

            Charger_UPSCOST_P850U P85i = new Charger_UPSCOST_P850U(this);
            string phspbs = (chk_bypass.Checked) ? cbphs_Bps.Text : "0";
            string bpsinputV = (chk_bypass.Checked) ? cbbps_inputV.Text : "0";
            string battCapa = (opbattK.Checked) ? txbatt_capa.Text : "0";

            P85i.Cal_ONEUPS_ONECPT_priceList(cbmodels.Text, cbphs_out.Text, cbKVA.Text, cbACoutV.Text, cbDCbus.Text, cbphs_in.Text, cbACinputV.Text, phspbs, bpsinputV, battCapa, cbPF.Text, txbatt_TC.Text, "136.20", "139.80", "91.8", "144");

            //P85i.Cal_ONEUPS_ONECPT_priceList(cbmodels.Text, cbphs_out.Text, cbKVA.Text, cbACoutV.Text, cbDCbus.Text, cbphs_in.Text, cbACinputV.Text, phspbs, bpsinputV, battCapa, cbPF.Text, txbatt_TC.Text);
        }

        string seekUPSprice(string p850x, string phsout, string kva, string outV, string DCbus, string phsin, string inV)
        {
            string res = "0", f_outV = "", f_DCbus = "", f_inV = "", f_prc = "";

            string stSql = " SELECT outVltg,DCbus,inVltg,Price FROM PSM_UPS_Prices " +
                " where[UPS_mdl] = '" + p850x + "' and[PHSout] = '" + phsout + "' and KVA_OP = '" + kva + "' and PHSin = '" + phsin + "'";

            MainMDI.Find_2_Field(stSql, ref f_outV, ref f_DCbus, ref f_inV, ref f_prc);
            if (f_outV != MainMDI.VIDE && f_DCbus != MainMDI.VIDE && f_inV != MainMDI.VIDE && f_prc != MainMDI.VIDE)
            {
                //MessageBox.Show("OutV= " + f_outV + "  dcbus= " + f_DCbus + "  InV= " + f_inV + "  Price= " + f_prc);

                if (f_outV[0] == '!' && f_DCbus[0] == '!' && f_inV[0] == '!')
                {
                    if (Find_vV(f_outV.Substring(1, f_outV.Length - 1), outV) &&
                        Find_vV(f_DCbus.Substring(1, f_DCbus.Length - 1), DCbus) &&
                        Find_vV(f_inV.Substring(1, f_inV.Length - 1), inV)) res = f_prc;
                    else res = "0";
                }
                else res = "0";
            }
            return res;
        }

        bool Find_vV(string Vtable, string _val)
        {
            string stSql = " SELECT  PSM_UPS_Vdetails.Vvlid FROM PSM_UPS_Vdetails INNER JOIN  PSM_UPS_Vtables ON PSM_UPS_Vdetails.V_id = PSM_UPS_Vtables.V_id " +
                " WHERE PSM_UPS_Vtables.Vname = '" + Vtable + "'  AND PSM_UPS_Vdetails.value = '" + _val + "'";
            return (MainMDI.Find_One_Field(stSql) != MainMDI.VIDE);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //lvQuotes.Items.Clear();
            //lv_TV.Items.Clear();
            //Display_UPSMDL();
            //lUPS_price.Text = seekUPSprice(cbmodels.Text, cbphs_out.Text, cbKVA.Text, cbACoutV.Text, cbDCbus.Text, cbphs_in.Text, cbACinputV.Text);
            //double mnt1 = Tools.Conv_Dbl("‭0.900316‬");

            //double mnt4 = 0;
            //Double.TryParse("‭0.900316‬", out mnt4);
            //Double.TryParse("‭1.5‬", out mnt4);
            //double mnt1 = Tools.Conv_Dbl("0.900316"); //‭0.900316‬");
            //double number = Convert.ToDouble("‭1.5‬", CultureInfo.InvariantCulture);
            //double mnt3 = double.Parse("‭0.900316‬", System.Globalization.CultureInfo.InvariantCulture);

            //Cal_ALL_UPS_COST13();
            if (lv_TV.SelectedItems.Count == 1)
            {
                int ndx = lv_TV.SelectedItems[0].Index;
                Charger_UPSCOST_P850U P85i = new Charger_UPSCOST_P850U(this);
                string phspbs = (chk_bypass.Checked) ? cbphs_Bps.Text : "0";
                string bpsinputV = (chk_bypass.Checked) ? cbbps_inputV.Text : "0";
                string battCapa = (opbattK.Checked) ? txbatt_capa.Text : "0";

                string vcsName = lv_TV.Items[ndx].SubItems[0].Text;
                P85i.Cal_ONEUPS_ONECPT_FRMULAS(cbmodels.Text, cbphs_out.Text, cbKVA.Text, cbACoutV.Text, cbDCbus.Text, cbphs_in.Text, cbACinputV.Text, phspbs, bpsinputV, battCapa, cbPF.Text, txbatt_TC.Text, "147", vcsName, "136.20", "139.80", "91.8", "144");
            }
            else MessageBox.Show("select a vcs........");
        }
    }
}