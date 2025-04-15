using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EAHLibs;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;	
using Outlook= Microsoft.Office.Interop.Outlook ;

namespace PGESCOM
{
    public partial class Q_System : Form
    {
        char TV_RSA = 'V';
  //    public  string lCurSoln.Text = "",lCurINDX_Text="",lcurSol_Status.Text="",lOFName.Text="",lCurALSn.Text="", lCurSolNDX.Text="";
    //       public string lCurSoln.Text = "";//lCurINDX_Text="",lcurSol_Status.Text="",lOFName.Text="",lCurALSn.Text="", lCurSolNDX.Text="";
      int LENDesc = 475;
   //     string  disp_solID_Text = "", disp_altID_Text = "", disp_alsID_Text = "";
        private static Lib1 Tools = new Lib1();
        public bool BCONV = false;
        private bool Imprt = false;
        private string in_opera = "*";
        private int ItemCount = 0;
        private string OldLabel = "", Curr_SQLMLTP = " CAN_MLTP ", STDMultp_US = "", STDMultp_CAN = "", STDMultp_EURO = "";
        private int OptionCount = 0, oldsysNDX=-1, oldspcNDX=-1, oldsolNDX=-1;
        private bool Quote_loaded = false;
        private bool Tosave = false;
        private bool Opt_added = false;
        private bool Chkable = true;
        private bool btnUnchk = false;
        private string curR_sol = "";
        private bool isDellAll = false;
        public long x_QID = -1;
        public string x_CpnyName = "*";
        public string x_opera = "*";
        private int LstNdx = -1;
        private int ndxfound = 0;
        private int ndxSelect = -1;
        private string Imp_SolID = "",in_Frml="";
        private string Imp_IQID = "";
        private string Imp_cpnyID = "";
        //private string[,] arr_clpB = new string[MainMDI.MAX_Quote_lines  ,13];  //12 subitem + 1 for Techvalue
        private string[] arr_Tech_values = new string[MainMDI.MAX_Quote_lines];
        string[] arr_Sql = new string[2000];
        string in_lCurrIQID = "", in_SYSnm="";
        QuoteV4 in_Quote4 = null;

        private const int lim0 = 4, lim1 = 9, lim2 = 19;

        public Q_System(QuoteV4 x_Quote4, string x_opera,string x_SYSnm,string x_frml)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            in_Quote4 = x_Quote4;
			in_opera=x_opera;
            in_SYSnm = x_SYSnm;
            in_Frml = x_frml;
	
		}



private void p4600P4500ChargerToolStripMenuItem_Click(object sender, EventArgs e)
{

    if (MainMDI.ALWD_USR("QT_SV", true))
    {
        //if (in_Quote4.lCurrIQID.Text != "0" && in_Quote4.tQuoteID.Text != "" && in_Quote4.lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
        if (in_Quote4.lCurrIQID.Text != "0" && in_Quote4.tQuoteID.Text != "" && MainMDI.profile != 'R')
        {
            Add_Charger();
            Tosave = true;
        }
    }
}

private void p5500EDIRectifierToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (MainMDI.ALWD_USR("QT_SV", true))
    {
      //  if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
        if (in_Quote4.lCurrIQID.Text != "0" && in_Quote4.tQuoteID.Text != "" && MainMDI.profile != 'R')
        {
            Add_Rectif();
            Tosave = true;
        }
    }
}
private void Add_Rectif()
{
    P5500 Rectifdlg = new P5500();
    Rectifdlg.ShowDialog();
    if (Rectifdlg.lsave.Text == "Y")
    {
        ItemCount++;
        //	string st =(frmchdlg.lvDefOption.Items[i].SubItems[1].Text !="") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text+ " / " : "";  
        //	add_LVO(0,ItemCount.ToString(),frmchdlg.lvDefOption.Items[i].SubItems[2].Text,frmchdlg.lvDefOption.Items[i].SubItems[3].Text,tCust_Mult.Text,frmchdlg.lvDefOption.Items[i].SubItems[4].Text,frmchdlg.lvDefOption.Items[i].SubItems[5].Text,frmchdlg.lvDefOption.Items[i].SubItems[6].Text);
        //    string st =(frmchdlg.lvDefOption.Items[i].SubItems[1].Text !="") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text+ " / " : "";  
        add_LVO(1, 0, ItemCount.ToString(), "EDI RECTIFIER " + Rectifdlg.lRecModel.Text, Rectifdlg.tIQty.Text, Rectifdlg.tSMRK.Text, Rectifdlg.tIPU.Text, Rectifdlg.tIExt.Text, Rectifdlg.tILT.Text, "", "", "A");
        if (Rectifdlg.chkEnc.Checked) add_LVO(1, 1, "", Rectifdlg.chkEnc.Text + ": " + Rectifdlg.cbEnc.Text, "", "", "", "", "", "", "", "A");
        if (Rectifdlg.chkInput.Checked) add_LVO(1, 1, "", Rectifdlg.chkInput.Text + ": " + Rectifdlg.cbInput.Text, "", "", "", "", "", "", "", "A");
        if (Rectifdlg.chkheat.Checked) add_LVO(1, 1, "", Rectifdlg.chkheat.Text + ": " + Rectifdlg.cbHeat.Text, "", "", "", "", "", "", "", "A");
        if (Rectifdlg.chkplc.Checked) add_LVO(1, 1, "", Rectifdlg.chkplc.Text + ": " + Rectifdlg.cbPLC.Text, "", "", "", "", "", "", "", "A");
        if (Rectifdlg.chkinternal.Checked) add_LVO(1, 1, "", Rectifdlg.chkinternal.Text + ": " + Rectifdlg.cbInternal.Text, "", "", "", "", "", "", "", "A");
        if (Rectifdlg.chk3PHS.Checked) add_LVO(1, 1, "", Rectifdlg.chk3PHS.Text + ": " + Rectifdlg.cb3PHS.Text, "", "", "", "", "", "", "", "A");
        if (Rectifdlg.chktermalP.Checked) add_LVO(1, 1, "", Rectifdlg.chktermalP.Text + ((Rectifdlg.ttermalP.Text == "STD") ? "" : ": " + Rectifdlg.ttermalP.Text), "", "", "", "", "", "", "", "A");
        if (Rectifdlg.chkApp.Checked) add_LVO(1, 1, "", Rectifdlg.chkApp.Text + ": " + Rectifdlg.tApp.Text, "", "", "", "", "", "", "", "A");
        Ref_ALSTOT('A');
    }

}


private void p5500ToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (MainMDI.User.ToLower() == "ede")
    {
       // if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
        if (in_Quote4.lCurrIQID.Text != "0" && in_Quote4.tQuoteID.Text != "" && MainMDI.profile != 'R')
        {
            Add_P5500();
            Tosave = true;
        }
    }
}
private void Add_P5500()
{
    Chargerdlg_P5500 frmchdlgP5500 = new Chargerdlg_P5500('0', MainMDI.M_stCon);
    this.Hide();
    frmchdlgP5500.ShowDialog();
    this.Visible = true;
    if (frmchdlgP5500.lSave.Text == "Y")
    {
        for (int i = 0; i < frmchdlgP5500.lvDefOption.Items.Count; i++)
        {
            if (i == 0)
            {
                ItemCount++;
                string lFrml = "";
                string model = frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text;
                //	int ipos= model.IndexOf("charger")+8;
                string st = MainMDI.arr_EFSdict[39, MainMDI.Lang];
                int ipos = model.IndexOf(st) + st.Length + 1;
                model = model.Substring(ipos, model.Length - ipos);
                for (int y = 0; y < Charger.NB_FRML; y++)
                {
                    if (frmchdlgP5500.dlg_arr_CAL_FRML[y] != "")
                        lFrml += " " + frmchdlgP5500.dlg_arr_CAL_FRML[y];
                    else break;
                }
                lFrml += " C_MODEL||" + model + " C_TCC||A";
                // here add TV value to TEC_Val
                lFrml += " " + frmchdlgP5500.lOth_TV;
                add_LVO(1, 0, ItemCount.ToString(), frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[3].Text,in_Quote4.tCust_Mult.Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[5].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[6].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[11].Text, lFrml, "A");
                // arr_Tech_values[lvQITEMS.Items.Count -1]=lFrml;   
            }
            else
            {
                if (frmchdlgP5500.lvDefOption.Items[i].Checked)
                {
                    string r_TecV = frmchdlgP5500.lvDefOption.Items[i].SubItems[11].Text;
                    //added on 07/12/05
                    //	string r_TecV="";
                    //	if (frmchdlg.lvDefOption.Items[i].SubItems[8].Text!="") 
                    //	{
                    //		if (frmchdlg.lvDefOption.Items[i].SubItems[10].Text=="ALRM")
                    //			r_TecV=frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                    //
                    //																
                    //							}
                    //added on 07/12/05
                    string st = frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlgP5500.lvDefOption.Items[i].SubItems[2].Text : frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlgP5500.lvDefOption.Items[i].SubItems[2].Text;
                    if (frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text != "0")
                        add_LVO(1, 1, "", st, frmchdlgP5500.lvDefOption.Items[i].SubItems[3].Text,in_Quote4.tCust_Mult.Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[5].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[6].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                    else add_LVO(1, 1, "", st, "", "", "", "", "", frmchdlgP5500.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                    if (frmchdlgP5500.lvDefOption.Items[i].ForeColor == Color.Red) lvQITEMS.Items[lvQITEMS.Items.Count - 1].ForeColor = Color.Red; ;

                }
            }
        }
        Ref_ALSTOT('A');
    }
    frmchdlgP5500.Dispose();
}


private void Add_Charger()
{
    string B_model = "";
    Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI.M_stCon);
    this.Hide();
    frmchdlg.ShowDialog();
    this.Visible = true;
    int ndxChrg = -1;
    if (frmchdlg.lSave.Text == "Y")
    {
        for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
        {
            if (i == 0)
            {
                ItemCount++;
                string lFrml = "";
                string model = frmchdlg.lvDefOption.Items[i].SubItems[1].Text;
                //	int ipos= model.IndexOf("charger")+8;
                string st = MainMDI.arr_EFSdict[39, MainMDI.Lang];
                int ipos = model.IndexOf(st) + st.Length + 1;
                model = model.Substring(ipos, model.Length - ipos);
                for (int y = 0; y < Charger.NB_FRML; y++)
                {
                    if (frmchdlg.dlg_arr_CAL_FRML[y] != "")
                        lFrml += " " + frmchdlg.dlg_arr_CAL_FRML[y];
                    else break;
                }
                B_model = model;
                lFrml += " C_MODEL||" + model + " C_TCC||A";
                // here add TV value to TEC_Val
                lFrml += " " + frmchdlg.lOth_TV;
                add_LVO(1, 0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[1].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, in_Quote4.tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[11].Text, lFrml, "A");
                // arr_Tech_values[lvQITEMS.Items.Count -1]=lFrml; 
                //30052014 ede

                ndxChrg = lvQITEMS.Items.Count - 1;
            }
            else
            {
                if (frmchdlg.lvDefOption.Items[i].Checked)
                {
                    string r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                    //added on 07/12/05
                    //	string r_TecV="";
                    //	if (frmchdlg.lvDefOption.Items[i].SubItems[8].Text!="") 
                    //	{
                    //		if (frmchdlg.lvDefOption.Items[i].SubItems[10].Text=="ALRM")
                    //			r_TecV=frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                    //
                    //																
                    //							}
                    //added on 07/12/05
                    string st = frmchdlg.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlg.lvDefOption.Items[i].SubItems[2].Text : frmchdlg.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlg.lvDefOption.Items[i].SubItems[2].Text;
                    if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text != "0")
                        add_LVO(1, 1, "", st, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, in_Quote4.tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                    else add_LVO(1, 1, "", st, "", "", "", "", "", frmchdlg.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                    if (frmchdlg.lvDefOption.Items[i].ForeColor == Color.Red) lvQITEMS.Items[lvQITEMS.Items.Count - 1].ForeColor = Color.Red; ;

                }
            }
        }
        if (B_model.IndexOf("P4600") > -1)
        {
            // ItemCount++;
            //  add_itemHidden_ITcharger();
            string _desc = (MainMDI.Lang == 0) ? @"PC23 c/w touch screen, P4600 overlay and cabinet door cutout" : "PC23 incluant écran tactil, membrane et ouverture dans la porte";
            add_LVO(1, 1, "", _desc, "", "", "", "", "", "", "", "A");
            double ddEXT = Tools.Conv_Dbl(lvQITEMS.Items[ndxChrg].SubItems[7].Text) + ((Tools.Conv_Dbl(lvQITEMS.Items[ndxChrg].SubItems[3].Text) * 250d));
            double ddPU = ddEXT / Tools.Conv_Dbl(lvQITEMS.Items[ndxChrg].SubItems[4].Text);
            lvQITEMS.Items[ndxChrg].SubItems[7].Text = Math.Round(ddEXT, 2).ToString();
            lvQITEMS.Items[ndxChrg].SubItems[5].Text = Math.Round(ddPU, 2).ToString();
        }
        Ref_ALSTOT('A');
    }
    frmchdlg.Dispose();
}
private void Ref_ALSTOT(char _op)
{
   in_Quote4.lHiDelv.Text = "4";
    if (lvQITEMS.Items.Count > 0)
    {

        int nb = 0;
        int lin = 0;
        double dtot = 0;
        for (int i = 0; i < lvQITEMS.Items.Count; i++)
        {
            if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
            if (lvQITEMS.Items[i].SubItems[1].Text == " " || (lvQITEMS.Items[i].SubItems[1].Text == "." && lvQITEMS.Items[i].BackColor == Color.WhiteSmoke)) nb++;  // item # is always==" " not ""
            else
            {
                if (i > 0) // && lvQITEMS.Items[i].BackColor == ) 
                {
                    lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                    lin = i; //if (i==lvQITEMS.Items.Count-1)  lvQITEMS.Items[lin].SubItems[9].Text ="0" ;
                    nb = 0;
                    if (Tools.Conv_Dbl(lvQITEMS.Items[lin].SubItems[8].Text) > Tools.Conv_Dbl(in_Quote4.lHiDelv.Text)) in_Quote4.lHiDelv.Text = lvQITEMS.Items[lin].SubItems[8].Text;
                }
            }
        }
        lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
        lALSTOT.Text = lCurALSn.Text + ": ";// " TOTAL :" ;  
        //		lALSnb.Text = lCurALSn.Text + " #:" ;  
        AlsTOT_orig.Text = MainMDI.A00(Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF)));
     //   lAlterTOT.Text = lCurSPCn.Text;// + " TOTAL :" ;  

    }

    ref_PXAG_Price(_op);
    MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
    menuItem9.Enabled = MNoPaste.Enabled;
}

private void ref_PXAG_Price(char opera)
{

    if (opera != 'S')  //selection
    {

        bool _conf = false;
        if (Tools.Conv_Dbl(AlsTOT.Text) > Tools.Conv_Dbl(AlsTOT_orig.Text))
        {
            if (chk_savOVRG.Checked) _conf = false;
            //       else _conf = MainMDI.Confirm("Want to Update Primax Sell Price / Agent Price: ?");
            //        !MainMDI.Confirm("Selling Price is higher than PGESCOM Price , do you want to Save current Selling Price / Agent Price: ?");
            //  removed: 25/11/2008  else _conf =  !MainMDI.Confirm("Selling Price is higher than PGESCOM Price , do you want to IMPOSE the NEW Price on all others Prices: ?");
            else _conf = true;

        }
        else _conf = (Tools.Conv_Dbl(AlsTOT.Text) < Tools.Conv_Dbl(AlsTOT_orig.Text));
        if (_conf)
        {
            AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
            tAGprice.Text = MainMDI.A00(tPxPrice.Text);
        }
        if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = MainMDI.A00(tPxPrice.Text);
    }


}

private void add_LVO(int ToBePrinted, int deb, string nb, string Desc, string Qt, string mult, string up, string ext, string LT, string stPartnb, string TecVal, string Grp)
{
    ListViewItem lvI = lvQITEMS.Items.Add(""); //order
    lvI.Checked = (ToBePrinted != 0);
    if (deb == 0 || deb == 2 || deb == 3)
    {
        if (deb == 0) lvI.BackColor = Color.Salmon;
        if (deb == 2) lvI.BackColor = Color.LightYellow;
        lvI.SubItems.Add(nb);

    }
    else lvI.SubItems.Add(" "); // //aff
    if (ext != "" && in_Quote4.tXRATE.Text != "" && ext != "0") ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(mult) * Tools.Conv_Dbl(up) * Tools.Conv_Dbl(Qt) * Tools.Conv_Dbl(in_Quote4.tXRATE.Text), MainMDI.Q_NB_DEC_AFF)); else ext = "";
    lvI.SubItems.Add(Desc);  //item
    lvI.SubItems.Add(Qt);   //Qty
    if (ext != "" && ext != "0") lvI.SubItems.Add(MainMDI.A00(mult));
    else lvI.SubItems.Add("");  //Mult
    lvI.SubItems.Add(MainMDI.A00(up)); //Unit Price
    //	if (up != "" && Qt  != "" )  ext  = Convert.ToString(Math.Round (Tools.Conv_Dbl(up ) *  Tools.Conv_Dbl(Qt  ) *  Tools.Conv_Dbl( tXRATE.Text   ),MainMDI.NB_DEC_AFF ));  
    //if (ext != "" && ext != "0" ) 
    if (ext != "" && ext != "0") lvI.SubItems.Add(Grp); else lvI.SubItems.Add(""); //Xchnge
    lvI.SubItems.Add(MainMDI.A00(ext)); //Extension
    if (ext == "0") lvI.SubItems[lvI.SubItems.Count - 1].BackColor = Color.DarkTurquoise;
    if (ext != "" && ext != "0") lvI.SubItems.Add(LT);
    else lvI.SubItems.Add("");  //LT
    lvI.SubItems.Add("");        //nbDef
    lvI.SubItems.Add(stPartnb); //PartNB
    lvI.SubItems.Add("");        //Det_LID
    lvI.SubItems.Add(TecVal);        //Tech. Values

}

private void Q_System_Load(object sender, EventArgs e)
{

    AffQNB.Text =in_Quote4.tQuoteID.Text;
    Size_desc();
    tabControl1.TabPages[0].Text = in_SYSnm;
}


void Size_desc()
{
  //  lvQITEMS.Columns[2].Width = lvQITEMS.Width - LENDesc;
    gbxSol.Height = tabControl1.Height - 84;// grpTOTA.Height - 32;
}

private void addbat_Click(object sender, EventArgs e)
{
    Add_BATT();
}


private void Add_BATT()
{
    dlg_addBatt mydlg = new dlg_addBatt();
    mydlg.ShowDialog();
    if (mydlg.Save)
    {
       int CurrBTNi = -1;
        ItemCount++;
        string st = Batt_arrTOstr(mydlg.in_arrBatt);
        st = (st == "") ? MainMDI.VIDE : st;

        string ITMNAME = find_ITEM_Name("[BATTERIES]");
      //  CurrBTNi = newbtnITEM(ITMNAME);
        add_LVO(1, 2, " ", ITMNAME, "", "", "", "", "", "", "0", "");

        add_LVO(1, 0, ItemCount.ToString(), mydlg.in_arrBatt[0, 0] + "  " + mydlg.in_arrBatt[0, 1], "1", "1", mydlg.in_arrBatt[MainMDI.batt_nbL - 1, 1], mydlg.in_arrBatt[MainMDI.batt_nbL - 1, 1], " ", " ", st, "C"); //name , price
        for (int j = 1; j < MainMDI.batt_nbL - 1; j++)
        {
            if (mydlg.in_arrBatt[j, 1] != " " && mydlg.in_arrBatt[j, 1] != "") add_LVO(1, 1, "", mydlg.in_arrBatt[j, 0] + "  " + mydlg.in_arrBatt[j, 1], "", "", "", "", "", "", "", "C");
        }
        Tosave = true;
        add_LVO(0, 2, " ", "[]", "", "", "", "", "", "", "9", "");

    }

}


string Batt_arrTOstr(string[,] arr)
{
    string rez = "";
    for (int i = 0; i < MainMDI.batt_nbL; i++)
    {
        string rr = (arr[i, 1] == " ") ? MainMDI.VIDE : arr[i, 1];
        rez += i.ToString() + "||" + rr + "~~";

    }

    return rez;

}
string Batt_strTOarr(ref string[,] arr, string str)
{
    string rez = "";
    for (int i = 0; i < MainMDI.batt_nbL; i++)
    {
        string rr = (arr[i, 1] == " ") ? MainMDI.VIDE : arr[i, 1];
        rez = i.ToString() + "||" + rr + " ";

    }

    return rez;

}

int find_ITEM_NB(string itmNM)
{
    int nb = 0;
    for (int i = 0; i < lvQITEMS.Items.Count; i++)
    {
        string tt = lvQITEMS.Items[i].SubItems[2].Text;
        if (tt.IndexOf(itmNM) > -1)
        {
            int pos = tt.IndexOf("#");
            if (pos > -1) nb += Int32.Parse(tt.Substring(pos + 1, tt.Length - pos - 1));
            else nb += 1;
        }

    }
    return nb;

}
string find_ITEM_Name(string itmNM)
{
    int nb = 1;
    for (int i = 0; i < lvQITEMS.Items.Count; i++)
    {
        if (lvQITEMS.Items[i].SubItems[12].Text == "0")
        {
            if (lvQITEMS.Items[i].SubItems[2].Text.IndexOf(itmNM) > -1)
            {
                int pos = lvQITEMS.Items[i].SubItems[2].Text.IndexOf("#");
                if (pos > -1) nb++;  //+= Int32.Parse(tt.Substring(pos + 1, tt.Length - pos - 1));
                else nb = 0;
            }
        }
    }
    return itmNM + " #" + nb.ToString();

}



















    }
}
