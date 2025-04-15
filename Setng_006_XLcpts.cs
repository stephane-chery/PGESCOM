using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;

namespace PGESCOM
{
    public partial class Setng_006_XLcpts : Form
    {
        private EAHLibs.Lib1 Tools = new Lib1();
        private int CompntSEL = -1, lCurSolNDX = -1, lCurSPCNDX = -1, lCurALSNDX = -1, lOldSolndx = -1;
        string ALSadded = "", lCurSoln = "", lCurCPTLID = "", lCurSPCn = "", lCurManufacLID = "", lCurALSn = "", lCurFAMLID = "", cur_CPTid = "", x_stSql = "";

        string[] arr_CptsID = new string[100];

        public Setng_006_XLcpts()
        {
            InitializeComponent();
        }

        private void fill_Cols()
        {
            string binCols = MainMDI.Find_One_Field("select CPTid from PSM_C_XLPList where Cod_op='C'");
            if (binCols != MainMDI.VIDE)
            {
                for (int i = 0; i < binCols.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            chk_Desc.Checked = binCols[i] == '1';
                            break;
                        case 1:
                            chk_cat1.Checked = binCols[i] == '1';
                            break;
                        case 2:
                            chk_cat2.Checked = binCols[i] == '1';
                            break;
                        case 3:
                            chk_cat3.Checked = binCols[i] == '1';
                            break;
                        case 4:
                            chk_SP.Checked = binCols[i] == '1';
                            break;
                        case 5:
                            chk_CP.Checked = binCols[i] == '1';
                            break;
                        case 6:
                            chk_FAM.Checked = binCols[i] == '1';
                            break;
                        case 7:
                            chk_Prio.Checked = binCols[i] == '1';
                            break;
                        case 8:
                            chk_Famid.Checked = binCols[i] == '1';
                            break;
                        case 9:
                            chk_Pxcode.Checked = binCols[i] == '1';
                            break;
                        default:
                            MessageBox.Show("binCols i=" + i.ToString() + " is Invalid.....");
                            break;
                    }
                }
            }
        }

        private void fill_TVCpts()
        {
            string Nsol = "", Nspc = "", Nals = "", Osol = "", Ospc = "";
            int s = -1, p = -1;

            string stSql = " SELECT COMPNT_LIST.Component_ID, COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.Component_Name, COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID, COMPNT_MANUFAC_FAMILY.Compnt_ID, " +
                "        COMPNT_MANUFAC_FAMILY.[Desc] as fam_Name, COMPNT_MANUFAC.MANUFAC_ID, COMPNT_MANUFAC.MANUFAC_NAME " +
                " FROM         COMPNT_LIST INNER JOIN  COMPNT_MANUFAC_FAMILY ON COMPNT_MANUFAC_FAMILY.Compnt_ID = COMPNT_LIST.Component_ID INNER JOIN COMPNT_MANUFAC ON COMPNT_MANUFAC_FAMILY.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID " +
                //" where  COMPNT_LIST.Component_ID=" + 174 +
                " ORDER BY COMPNT_LIST.Component_Name, COMPNT_MANUFAC.MANUFAC_NAME, COMPNT_MANUFAC_FAMILY.[Desc] ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            TVCpts.Nodes.Clear();
            TVCpts.BeginUpdate();
            while (Oreadr.Read())
            {
                Nsol = MainMDI.optDesc(0, Oreadr["Component_Name"].ToString()) + "         (" + Oreadr["COMPONENT_REF"].ToString() + ")"; //Oreadr["COMPONENT_REF"].ToString();
                Nspc = Oreadr["MANUFAC_NAME"].ToString();
                Nals = Oreadr["fam_Name"].ToString();
                //N_SpcRnk = Oreadr["p"].ToString();
                if (Osol != Nsol)
                {
                    ALSadded = "";
                    p = -1;
                    s++;
                    addNode_Sol(Nsol, Oreadr["Component_ID"].ToString());

                    p++;
                    addNode_Spc(Nspc, s, p, Nals, Oreadr["MANUFAC_ID"].ToString(), Oreadr["Compnt_Man_FAM_ID"].ToString(), Oreadr["Component_ID"].ToString(), Oreadr["MANUFAC_ID"].ToString());
                    //addNode_Als(Nals, s, p);
                    Osol = Nsol;
                    Ospc = Nspc;

                    //O_SpcRnk = N_SpcRnk;
                }
                else
                {
                    if (Ospc == Nspc) addNode_Als(Nals, s, p, Oreadr["Compnt_Man_FAM_ID"].ToString(), Oreadr["Component_ID"].ToString(), Oreadr["MANUFAC_ID"].ToString());
                    else
                    {
                        //addNode_Als(Nals, s, p);
                        p++; //must be corrected in availability
                        ALSadded = "";
                        addNode_Spc(Nspc, s, p, Nals, Oreadr["MANUFAC_ID"].ToString(), Oreadr["Compnt_Man_FAM_ID"].ToString(), Oreadr["Component_ID"].ToString(), Oreadr["MANUFAC_ID"].ToString());
                        Ospc = Nspc;
                        //O_SpcRnk = N_SpcRnk;
                    }
                }
            }
            //Quote_loaded = true;

            OConn.Close();

            for (int n = 0; n < TVCpts.Nodes.Count; n++) TVCpts.Nodes[n].Collapse();
            TVCpts.EndUpdate();

            //select first node and select it (next 2 lines)
            TVCpts.SelectedNode = TVCpts.Nodes[0];
            TVCpts.Select();
        }

        private bool find_inNCL(char _cod, string _cptID, string _MANid, string _FAMid, string _PriceLID)
        {
            bool res = false;
            string STwhr =" Where Cod_op='" + _cod + "' and ";
            switch (_cod)
            {
                case 'T':
                    STwhr += " CPTid='" + _cptID + "' ";
                    break;
                case 'M':
                    STwhr += " CPTid='" + _cptID + "' and MANid='" + _MANid + "' ";
                    break;
                case 'F':
                    STwhr += " CPTid='" + _cptID + "' and MANid='" + _MANid + "' and FAMid='" + _FAMid + "' ";
                    break;
                case 'P':
                    STwhr += " CPTid='" + _cptID + "' and MANid='" + _MANid + "' and FAMid='" + _FAMid + "' " + " and LPRICEid='" + _PriceLID + "' ";
                    break;
                default:
                    MessageBox.Show("find_inNCL.....cod=" + _cod);
                    STwhr = "";
                    break;
            }
            if (STwhr != "")
            {
                res = MainMDI.Find_One_Field("select cfLID from PSM_C_XLPList " + STwhr) != MainMDI.VIDE;
            }
            return res;
        }

        private void addNode_Sol(string sName, string _lID)
        {
            int imgI = 2;
            TVCpts.Nodes.Add(sName);

            TVCpts.Nodes[TVCpts.Nodes.Count - 1].Tag = _lID;

            TVCpts.Nodes[TVCpts.Nodes.Count - 1].ImageIndex = imgI;
            TVCpts.Nodes[TVCpts.Nodes.Count - 1].SelectedImageIndex = imgI;
            //checked
            TVCpts.Nodes[TVCpts.Nodes.Count - 1].Checked = !find_inNCL('T', _lID, "", "", "");

            //if (Sol_stat == "C") tvSol.Nodes[tvSol.Nodes.Count - 1].ForeColor = Color.Blue;
        }

        private void addNode_Spc(string spcName, int s, int p, string aName, string _lID, string _aLID, string CPTid, string MANid)
        {
            if (spcName == MainMDI.VIDE) { addNode_SPCNA(aName, s, _aLID, CPTid); }
            else
            {
                TVCpts.Nodes[s].Nodes.Add(spcName);
                TVCpts.Nodes[s].Expand();
                TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 1;
                TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].ImageIndex = 1;
                TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].Tag = _lID;

                TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].Checked = !find_inNCL('M', CPTid, _lID, "", "");

                addNode_Als(aName, s, p, _aLID, CPTid, MANid); ALSadded += " ||" + aName;
            }
        }

        private void addNode_Als(string alsName, int s, int p, string _lID, string CPTid, string MANid)
        {
            if (ALSadded.IndexOf(" ||" + alsName) == -1)
            {
                TVCpts.Nodes[s].Nodes[p].Nodes.Add(alsName);
                ALSadded += " ||" + alsName;
                TVCpts.Nodes[s].Expand();
                TVCpts.Nodes[s].Nodes[p].Nodes[TVCpts.Nodes[s].Nodes[p].Nodes.Count - 1].SelectedImageIndex = 0;
                TVCpts.Nodes[s].Nodes[p].Nodes[TVCpts.Nodes[s].Nodes[p].Nodes.Count - 1].ImageIndex = 0;
                TVCpts.Nodes[s].Nodes[p].Nodes[TVCpts.Nodes[s].Nodes[p].Nodes.Count - 1].Tag = _lID;

                TVCpts.Nodes[s].Nodes[p].Nodes[TVCpts.Nodes[s].Nodes[p].Nodes.Count - 1].Checked = !find_inNCL('F', CPTid, MANid, _lID, "");
            }
        }

        private void addNode_SPCNA(string alsName, int s, string _lid, string CPTid)
        {
            TVCpts.Nodes[s].Nodes.Add(alsName);
            TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 0;
            TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].ImageIndex = 0;

            TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].Checked = !find_inNCL('M', CPTid, _lid, "", "");
        }

        private void Setng_006_XLcpts_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            fill_TVCpts();
            fill_Cols();
        }

        private void TVCpts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TV_Select();
        }

        private void TV_Select()
        {
            string[] res = new string[]{ "", "", "" };
            MainMDI.Deco_path(TVCpts.SelectedNode.FullPath.ToString(), ref res);
            lCurSoln = res[0];
            lCurSPCn = res[1];
            lCurALSn = res[2];

            lv_PriceList.Items.Clear();

            switch (TVCpts.SelectedNode.ImageIndex)
            {
                case 0: //VDC
                    //if (lCurALSNDX != -1) TVavail.Nodes[
                    //TVavail.SelectedNode.BackColor = Color.Yellow;

                    if (lCurALSn != MainMDI.VIDE && lCurALSn != "")
                    {
                        lCurSolNDX = TVCpts.SelectedNode.Parent.Parent.Index;
                    }
                    else lCurSolNDX = TVCpts.SelectedNode.Parent.Index;
                    lCurSPCNDX = TVCpts.SelectedNode.Parent.Index;
                    lCurALSNDX = TVCpts.SelectedNode.Index;
                    if (res[2] == "")
                    {
                        lCurALSn = res[1];
                        lCurSPCn = MainMDI.VIDE;
                        lCurSPCNDX = TVCpts.SelectedNode.Index;
                    }
                    lCurCPTLID = TVCpts.Nodes[lCurSolNDX].Tag.ToString();
                    lCurManufacLID = TVCpts.Nodes[lCurSolNDX].Nodes[lCurSPCNDX].Tag.ToString();
                    lCurFAMLID = TVCpts.Nodes[lCurSolNDX].Nodes[lCurSPCNDX].Nodes[lCurALSNDX].Tag.ToString();

                    fill_lvPriceLines(lCurSoln, lCurCPTLID, lCurSPCn, lCurManufacLID, lCurALSn, lCurFAMLID);
                    break;
                case 1: //Charger
                    lCurSolNDX = TVCpts.SelectedNode.Parent.Index;
                    lCurSPCNDX = TVCpts.SelectedNode.Index;
                    lCurManufacLID = TVCpts.Nodes[lCurSolNDX].Nodes[lCurSPCNDX].Tag.ToString();
                    break;
                case 2: //Cpts
                    lCurSolNDX = TVCpts.SelectedNode.Index;
                    lCurCPTLID = TVCpts.Nodes[lCurSolNDX].Tag.ToString();
                    //tslCPTeng.Text = lCurCPTLID;
                    break;
            }
            tlscpt.Visible = TVCpts.SelectedNode.ImageIndex == 2;
            tlsMan.Visible = TVCpts.SelectedNode.ImageIndex == 1;
            tlsFam.Visible = TVCpts.SelectedNode.ImageIndex == 0;

            //TSmain.Visible = (TVCpts.SelectedNode.ImageIndex == 2);
            //TS_VDC.Visible = (TVCpts.SelectedNode.ImageIndex == 0);
            //TS_Charger.Visible = (TVCpts.SelectedNode.ImageIndex == 1);
        }

        private void fill_lvPriceLines(string _CptRef, string cptLID, string _MAnufac, string manufacLID, string _Family, string famLID)
        {
            string stSql = "select * from COMPNT_PRICE_LIST where COMPONENT_ID=" + cptLID + "  and Manufac_ID=" + manufacLID + " and compnt_man_Fam_ID=" + famLID;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //lvCH_QTY.Items.Clear();
            cur_CPTid = "";

            while (Oreadr.Read())
            {
                ListViewItem lvI = lv_PriceList.Items.Add("");
                string stfullD = Oreadr["CAT4_VALUE"].ToString() + ", " + Oreadr["CAT5_VALUE"].ToString() + ", " + Oreadr["CAT6_VALUE"].ToString(); //+ ", " + Oreadr["CAT7_VALUE"].ToString();

                lvI.SubItems.Add(stfullD);
                lvI.SubItems.Add(Oreadr["CAT1_VALUE"].ToString());
                lvI.SubItems.Add(Oreadr["CAT2_VALUE"].ToString());
                lvI.SubItems.Add(Oreadr["CAT3_VALUE"].ToString());
                double Sell = Math.Round(Tools.Conv_Dbl(Oreadr["Price"].ToString()), MainMDI.NB_DEC_AFF); //its sell price
                lvI.SubItems.Add(MainMDI.A00(Sell.ToString()));
                double Cost = Math.Round(Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()), MainMDI.NB_DEC_AFF);
                lvI.SubItems.Add(MainMDI.A00(Cost.ToString()));
                lvI.SubItems.Add(Oreadr["PL_CODE"].ToString());
                lvI.SubItems.Add(Oreadr["PRICE_LINE_ID"].ToString());
                lvI.Checked = !find_inNCL('P', cptLID, manufacLID, famLID, Oreadr["PRICE_LINE_ID"].ToString());
            }
            OConn.Close();
        }

        private void tslCPTeng_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {

        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void picSaveFields_Click(object sender, EventArgs e)
        {
            Save_Cols();
        }

        private void Save_Cols()
        {
            chk_Desc.Checked = true; //Description must be checked
            string binCols = (chk_Desc.Checked) ? "1" : "0";
            binCols+= (chk_cat1.Checked) ? "1" : "0";
            binCols+= (chk_cat2.Checked) ? "1" : "0";
            binCols+= (chk_cat3.Checked) ? "1" : "0";
            binCols+= (chk_SP.Checked) ? "1" : "0";
            binCols+= (chk_CP.Checked) ? "1" : "0";
            binCols+= (chk_FAM.Checked) ? "1" : "0";
            binCols+= (chk_Prio.Checked) ? "1" : "0";
            binCols+= (chk_Famid.Checked) ? "1" : "0";
            binCols+= (chk_Pxcode.Checked) ? "1" : "0";
            MainMDI.Exec_SQL_JFS("update  PSM_C_XLPList set [CPTid]='" + binCols + "' where  Cod_op='C'", "XL priceList saving Cols config ");
        }

        private void tlssav_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lv_PriceList.Items.Count; i++)
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='P' and LPRICEid='" + lv_PriceList.Items[i].SubItems[8].Text + "'", "del priceLine in PSM_C_XLPList.. ");
                if (!lv_PriceList.Items[i].Checked) Save_TMF('P', lCurCPTLID, lCurManufacLID, lCurFAMLID, lv_PriceList.Items[i].SubItems[8].Text);
            }
        }

        private void Save_TMF(char _cod, string _cptID, string _manID, string _famID, string _priceLID)
        {
            string stSql = "insert into PSM_C_XLPList ([Cod_op],[CPTid],[MANid],[FAMid],[LPRICEid]) Values ('" + _cod 
                + "', '" + _cptID
                + "', '" + _manID 
                + "', '" + _famID
                + "', '" + _priceLID + "')";
            MainMDI.Exec_SQL_JFS(stSql, "Insert PSM_C_XLPList ");
        }

        private void Save_ALL_TVcpts()
        {
            MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='T' or Cod_op='M' or Cod_op='F'  ", "del all TFM in PSM_C_XLPList.. ");

            for (int i = 0; i < TVCpts.Nodes.Count; i++)
            {
                if (TVCpts.Nodes[i].Checked)
                {
                    for (int j = 0; j < TVCpts.Nodes[i].Nodes.Count; j++)
                    {
                        if (TVCpts.Nodes[i].Nodes[j].Checked)
                        {
                            for (int k = 0; k < TVCpts.Nodes[i].Nodes[j].Nodes.Count; k++)
                            {
                                if (!TVCpts.Nodes[i].Nodes[j].Nodes[k].Checked)
                                {
                                    Save_TMF('F', TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString(), "");
                                    Uncheck_PLines(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString());
                                }
                            }
                        }
                        else
                        {
                            Save_TMF('M', TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), "", "");
                            Uncheck_Families(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString());
                        }
                    }
                }
                else
                {
                    Save_TMF('T', TVCpts.Nodes[i].Tag.ToString(), "", "", "");
                    Uncheck_MAN(TVCpts.Nodes[i].Tag.ToString());
                }
            }
        }

        private void Save_OneCPT(int i)
        {
            if (TVCpts.Nodes[i].Checked)
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='T' and CPTid='" + TVCpts.Nodes[i].Tag.ToString() + "'", "check CPT in PSM_C_XLPList.. ");
                if (chk_sub.Checked) check_MAN(TVCpts.Nodes[i].Tag.ToString());
                else
                {
                    for (int j = 0; j < TVCpts.Nodes[i].Nodes.Count; j++)
                    {
                        if (TVCpts.Nodes[i].Nodes[j].Checked)
                        {
                            MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='M' and CPTid='" + TVCpts.Nodes[i].Tag.ToString() + "' and MANid='" + TVCpts.Nodes[i].Nodes[j].Tag.ToString() + "'", "check Manufac del in PSM_C_XLPList.. ");
                            if (chk_sub.Checked) check_Families(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString());
                            else 
                            {
                                for (int k = 0; k < TVCpts.Nodes[i].Nodes[j].Nodes.Count; k++)
                                {
                                    if (TVCpts.Nodes[i].Nodes[j].Nodes[k].Checked)
                                    {
                                        MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='F' and CPTid='" + TVCpts.Nodes[i].Tag.ToString() + "' and MANid='" + TVCpts.Nodes[i].Nodes[j].Tag.ToString() + "' and FAMid='" + TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString() + "'", "check Families del in PSM_C_XLPList.. ");
                                        if (chk_sub.Checked) check_PLines(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString());
                                    }
                                    else
                                    {
                                        Save_TMF('F', TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString(), "");
                                        if (chk_sub.Checked) Uncheck_PLines(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            Save_TMF('M', TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), "", "");
                            if (chk_sub.Checked) Uncheck_Families(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString());
                        }
                    }
                }
            }
            else
            {
                Save_TMF('T', TVCpts.Nodes[i].Tag.ToString(), "", "", "");
                if (chk_sub.Checked) Uncheck_MAN(TVCpts.Nodes[i].Tag.ToString());
            }
        }

        private void Save_OneMAN(int i, int j)
        {
            if (TVCpts.Nodes[i].Nodes[j].Checked)
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='M' and CPTid='" + TVCpts.Nodes[i].Tag.ToString() + "' and MANid='" + TVCpts.Nodes[i].Nodes[j].Tag.ToString() + "'", "check Manufac del in PSM_C_XLPList.. ");
                if (chk_sub.Checked) check_Families(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString());
                else
                {
                    for (int k = 0; k < TVCpts.Nodes[i].Nodes[j].Nodes.Count; k++)
                    {
                        if (TVCpts.Nodes[i].Nodes[j].Nodes[k].Checked)
                        {
                            MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='F' and CPTid='" + TVCpts.Nodes[i].Tag.ToString() + "' and MANid='" + TVCpts.Nodes[i].Nodes[j].Tag.ToString() + "' and FAMid='" + TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString() + "'", "check Families del in PSM_C_XLPList.. ");
                            if (chk_sub.Checked) check_PLines(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString());
                        }
                        else
                        {
                            Save_TMF('F', TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString(), "");
                            if (chk_sub.Checked) Uncheck_PLines(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString());
                        }
                    }
                }
            }
            else
            {
                Save_TMF('M', TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), "", "");
                if (chk_sub.Checked) Uncheck_Families(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString());
            }
        }

        private void Save_OneFAM(int i, int j, int k)
        {
            if (TVCpts.Nodes[i].Nodes[j].Nodes[k].Checked)
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='F' and CPTid='" + TVCpts.Nodes[i].Tag.ToString() + "' and MANid='" + TVCpts.Nodes[i].Nodes[j].Tag.ToString() + "' and FAMid='" + TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString() + "'", "check Families del in PSM_C_XLPList.. ");
                if (chk_sub.Checked) check_PLines(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString());
            }
            else
            {
                Save_TMF('F', TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString(), "");
                if (chk_sub.Checked) Uncheck_PLines(TVCpts.Nodes[i].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Tag.ToString(), TVCpts.Nodes[i].Nodes[j].Nodes[k].Tag.ToString());
            }
        }

        private void check_PLines(string cptLID, string manufacLID, string famLID)
        {
            MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where Cod_op='P' and CPTid='" + cptLID + "'  and MANid='" + manufacLID + "' and FAMid='" + famLID + "'", "Uncheck_PLines del in PSM_C_XLPList.. ");
        }

        private void Uncheck_PLines(string cptLID, string manufacLID, string famLID)
        {
            string stSql = "select * from COMPNT_PRICE_LIST where COMPONENT_ID=" + cptLID + "  and Manufac_ID=" + manufacLID + " and compnt_man_Fam_ID=" + famLID;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //cur_CPTid = "";

            while (Oreadr.Read())
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='P' and LPRICEid='" + Oreadr["PRICE_LINE_ID"].ToString() + "'", "Uncheck_PLines del in PSM_C_XLPList.. ");
                Save_TMF('P', cptLID, manufacLID, famLID, Oreadr["PRICE_LINE_ID"].ToString());
            }
            OConn.Close();
        }

        private void check_Families(string cptLID, string manufacLID)
        {
            MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='F' and CPTid='" + cptLID + "' and MANid='" + manufacLID + "'", "check_all_Families del in PSM_C_XLPList.. ");
            if (chk_sub.Checked)
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='P' and CPTid='" + cptLID + "' and MANid='" + manufacLID + "'", "check_all_pricelines del in PSM_C_XLPList.. ");
            }
        }

        private void Uncheck_Families(string cptLID, string manufacLID)
        {
            string stSql = " SELECT  COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID FROM COMPNT_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_LIST.Component_ID = COMPNT_MANUFAC_FAMILY.Compnt_ID " +
                " WHERE     COMPNT_MANUFAC_FAMILY.Compnt_ID = " + cptLID + " AND COMPNT_MANUFAC_FAMILY.Manufac_ID =" + manufacLID;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='F' and CPTid='" + cptLID + "' and MANid='" + manufacLID + "' and FAMid='" + Oreadr["Compnt_Man_FAM_ID"].ToString() + "'", "Uncheck_Families del in PSM_C_XLPList.. ");
                Save_TMF('F', cptLID, manufacLID, Oreadr["Compnt_Man_FAM_ID"].ToString(), "");
                if (chk_sub.Checked) Uncheck_PLines(cptLID, manufacLID, Oreadr["Compnt_Man_FAM_ID"].ToString());
            }
            OConn.Close();
        }

        private void check_MAN(string cptLID)
        {
            MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='M' and CPTid='" + cptLID + "'", "check_MAN (del) in PSM_C_XLPList.. ");
            if (chk_sub.Checked)
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='F' and CPTid='" + cptLID + "'", "check_MAN (del) in PSM_C_XLPList.. ");
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='P' and CPTid='" + cptLID + "'", "check_MAN (del) in PSM_C_XLPList.. ");
            }
        }

        private void Uncheck_MAN(string cptLID)
        {
            string stSql = " SELECT  distinct COMPNT_MANUFAC_FAMILY.Manufac_ID FROM COMPNT_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_LIST.Component_ID = COMPNT_MANUFAC_FAMILY.Compnt_ID " +
                " WHERE     COMPNT_MANUFAC_FAMILY.Compnt_ID = " + cptLID;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                MainMDI.Exec_SQL_JFS("delete PSM_C_XLPList where  Cod_op='M' and CPTid='" + cptLID + "' and MANid='" + Oreadr["Manufac_ID"].ToString() + "'", "Uncheck_Families del in PSM_C_XLPList.. ");
                Save_TMF('M', cptLID, Oreadr["Manufac_ID"].ToString(), "", "");
                if (chk_sub.Checked) Uncheck_Families(cptLID, Oreadr["Manufac_ID"].ToString());
            }
            OConn.Close();
        }

        private void tlscpt_Click(object sender, EventArgs e)
        {
            Save_OneCPT(lCurSolNDX);
            //fill_TVCpts();
        }

        private void tlsMan_Click(object sender, EventArgs e)
        {
            Save_OneMAN(lCurSolNDX, lCurSPCNDX);
        }

        private void tlsFam_Click(object sender, EventArgs e)
        {
            Save_OneFAM(lCurSolNDX, lCurSPCNDX, lCurALSNDX);
        }

        private void tls_refresh_Click(object sender, EventArgs e)
        {
            lOldSolndx = lCurSolNDX;
            fill_TVCpts();
            TVCpts.SelectedNode = TVCpts.Nodes[lOldSolndx];
            TVCpts.Select();
        }

        /*
        private void fill_CptsID(string _phs)
        {
            string stSql = " select distinct Compnt_ID from dbo.link_COMPNT_AVAIL  where phs='" + _phs + "' order by Compnt_ID ";

            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int i = 0;
            for (i = 0; i < 100; i++) arr_CptsID[i] = "";
            i = 0;
            while (Oreadr.Read()) arr_CptsID[i++] = Oreadr["Compnt_ID"].ToString();
            OConn.Close();
        }

        private void fill_lvCH_QTY(string _CptRef, string _Phs, string _charger, string _VDC)
        {
            //string stSql = " SELECT  COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.Component_ID, TBLAVAIL" + _Phs + ".charger, CAST(TBLAVAIL" + _Phs + ".vdc AS int) AS VDC, CAST(TBLAVAIL" + _Phs + ".idc AS int) AS IDC ,link_COMPNT_AVAIL.Qty, link_COMPNT_AVAIL.Avail_ID" +
                //" FROM    link_COMPNT_AVAIL INNER JOIN TBLAVAIL" + _Phs + " ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + _Phs + ".Avail_ID INNER JOIN  COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                //" WHERE     (link_COMPNT_AVAIL.phs =" + _Phs + ") ORDER BY COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + _Phs + ".charger, VDC, IDC ";

            string stSql = " SELECT  COMPNT_LIST.Component_ID, CAST(TBLAVAIL" + _Phs + ".idc AS int) AS IDC, link_COMPNT_AVAIL.Qty, link_COMPNT_AVAIL.Avail_ID, link_COMPNT_AVAIL.LCA_LID " +
                " FROM         link_COMPNT_AVAIL INNER JOIN  TBLAVAIL" + _Phs + " ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + _Phs + ".Avail_ID INNER JOIN  COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                " WHERE     (link_COMPNT_AVAIL.phs = " + _Phs + ") AND (COMPNT_LIST.COMPONENT_REF = '" + _CptRef + "') AND (TBLAVAIL" + _Phs + ".charger = '" + _charger + "') AND (CAST(TBLAVAIL" + _Phs + ".vdc AS int)  = " + _VDC + ") " +
                " ORDER BY IDC ";
            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lvCH_QTY.Items.Clear();
            cur_CPTid ="";
            x_stSql = stSql;
            while (Oreadr.Read())
            {
                if (cur_CPTid == "") cur_CPTid = Oreadr["Component_ID"].ToString();
                ListViewItem lv = lvCH_QTY.Items.Add("");
                lv.SubItems.Add(_charger + "-" + _Phs + "-" + _VDC + "-" + Oreadr["IDC"].ToString());
                lv.SubItems.Add(Oreadr["QTY"].ToString());

                lv.SubItems.Add(Oreadr["LCA_LID"].ToString());
            }
            OConn.Close();
        }

        private void fill_Link_Avail(string _Phs)
        {
            string Nsol = "", Nspc = "", Nals = "", Osol = "", Ospc = "";
            int s = -1, p = -1;

            string stSql = " SELECT  COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.Component_ID, TBLAVAIL" + _Phs + ".charger, CAST(TBLAVAIL" + _Phs + ".vdc AS int) AS VDC, CAST(TBLAVAIL" + _Phs + ".idc AS int) AS IDC ,link_COMPNT_AVAIL.Qty, link_COMPNT_AVAIL.Avail_ID" +
                " FROM    link_COMPNT_AVAIL INNER JOIN TBLAVAIL" + _Phs + " ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + _Phs + ".Avail_ID INNER JOIN  COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                " WHERE     (link_COMPNT_AVAIL.phs =" + _Phs + ") ORDER BY COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + _Phs + ".charger, VDC, IDC ";

            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            TVCpts.Nodes.Clear();
            TVCpts.BeginUpdate();
            while (Oreadr.Read())
            {
                Nsol = Oreadr["COMPONENT_REF"].ToString();
                Nspc = Oreadr["charger"].ToString();
                Nals = Oreadr["VDC"].ToString();
                //N_SpcRnk = Oreadr["p"].ToString();
                if (Osol != Nsol)
                {
                    ALSadded = "";
                    p = -1;
                    s++;
                    addNode_Sol(Nsol);

                    p++;
                    addNode_Spc(Nspc, s, p, Nals);
                    //addNode_Als(Nals, s, p);
                    Osol = Nsol;
                    Ospc = Nspc;

                    //O_SpcRnk = N_SpcRnk;
                }
                else
                {
                    if (Ospc == Nspc) addNode_Als(Nals, s, p);
                    else
                    {
                        //addNode_Als(Nals, s, p);
                        //p++;
                        ALSadded = "";
                        addNode_Spc(Nspc, s, p, Nals);
                        Ospc = Nspc;
                        //O_SpcRnk = N_SpcRnk;
                    }
                }
            }
            //Quote_loaded = true;
            TVCpts.Select();
            OConn.Close();

            for (int n = 0; n < TVCpts.Nodes.Count; n++)
                TVCpts.Nodes[n].Collapse();
            TVCpts.EndUpdate();
        }

        private void addNode_Sol(string sName)
		{
            int imgI = 2;
			TVCpts.Nodes.Add(sName);
			TVCpts.Nodes[TVCpts.Nodes.Count - 1].ImageIndex = imgI;
            TVCpts.Nodes[TVCpts.Nodes.Count - 1].SelectedImageIndex = imgI;
			//if (Sol_stat == "C") tvSol.Nodes[tvSol.Nodes.Count - 1].ForeColor = Color.Blue;
		}

		private void addNode_Spc(string spcName, int s, int p, string aName)
		{
            if (spcName == MainMDI.VIDE) { addNode_SPCNA(aName, s); }
            else
            {
                TVCpts.Nodes[s].Nodes.Add(spcName);
                TVCpts.Nodes[s].Expand();
                TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 1;
                TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].ImageIndex = 1;
                addNode_Als(aName, s, p); ALSadded += " ||" + aName;
            }
		}

		private void addNode_Als(string alsName, int s, int p)
		{
            if (ALSadded.IndexOf(" ||" + alsName) == -1)
            {
                TVCpts.Nodes[s].Nodes[p].Nodes.Add(alsName);
                ALSadded += " ||" + alsName;
                TVCpts.Nodes[s].Expand();
                TVCpts.Nodes[s].Nodes[p].Nodes[TVCpts.Nodes[s].Nodes[p].Nodes.Count - 1].SelectedImageIndex = 0;
                TVCpts.Nodes[s].Nodes[p].Nodes[TVCpts.Nodes[s].Nodes[p].Nodes.Count - 1].ImageIndex = 0;
            }
		}

		private void addNode_SPCNA(string alsName, int s)
		{
			TVCpts.Nodes[s].Nodes.Add(alsName);
			TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 0;
			TVCpts.Nodes[s].Nodes[TVCpts.Nodes[s].Nodes.Count - 1].ImageIndex = 0;
		}

        private void NewItm_Click(object sender, EventArgs e)
        {
            dlg_CopyCPT_Avail _frm = new dlg_CopyCPT_Avail(toolStripComboBox1.Text[0].ToString());
            _frm.ShowDialog();
            //fill_lvCH_QTY(lCurSoln, toolStripComboBox1.Text[0].ToString(), lCurSPCn, lCurALSn);
        }

        private void Sav_Itm_Click(object sender, EventArgs e)
        {

        }

        private void del_BRD_Click(object sender, EventArgs e)
        {

        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lvCpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CompntSEL = lvCpts.SelectedItems[0].Index;
        }

        private void TVavail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TV_Select();
        }

        private void TV_Select()
        {
            string[] res = new string[] { "", "", "" };
            MainMDI.Deco_path(TVCpts.SelectedNode.FullPath.ToString(), ref res);
            lCurSoln = res[0];
            lCurSPCn = res[1];
            lCurALSn = res[2];

            lvCH_QTY.Items.Clear();

            switch (TVCpts.SelectedNode.ImageIndex)
            {
                case 0: //VDC
                    //if (lCurALSNDX != -1) TVavail.Nodes[
                    //TVavail.SelectedNode.BackColor = Color.Yellow;

                    if (lCurALSn != MainMDI.VIDE && lCurALSn != "")
                    {
                        lCurSolNDX = TVCpts.SelectedNode.Parent.Parent.Index;
                    }
                    else lCurSolNDX = TVCpts.SelectedNode.Parent.Index;
                    lCurSPCNDX = TVCpts.SelectedNode.Parent.Index;
                    lCurALSNDX = TVCpts.SelectedNode.Index;
                    if (res[2] == "")
                    {
                        lCurALSn = res[1];
                        lCurSPCn = MainMDI.VIDE;
                        lCurSPCNDX = TVCpts.SelectedNode.Index;
                    }
                    fill_lvCH_QTY(lCurSoln, toolStripComboBox1.Text[0].ToString(), lCurSPCn, lCurALSn);
                    break;
                case 1: //Charger
                    lCurSolNDX = TVCpts.SelectedNode.Parent.Index;
                    lCurSPCNDX = TVCpts.SelectedNode.Index;
                    break;
                case 2: //Cpts
                    lCurSolNDX = TVCpts.SelectedNode.Index;
                    break;
            }
            TSmain.Visible = (TVCpts.SelectedNode.ImageIndex == 2);
            TS_VDC.Visible = (TVCpts.SelectedNode.ImageIndex == 0);
            TS_Charger.Visible = (TVCpts.SelectedNode.ImageIndex == 1);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.Text)
            {
                case "Select Phase":
                    TVCpts.Nodes.Clear();
                    break;
                case "1 Phase":
                case "3 Phase":
                    fill_Link_Avail(toolStripComboBox1.Text[0].ToString());
                    break;
            }
        }

        private void Setng_003_Load(object sender, EventArgs e)
        {
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void create_Lnk_cpt_Avail(string _phs, string _idc)
        {
            string stSql = "SELECT * FROM TBLAVAIL" + _phs + " WHERE idc ='" + _idc + "' AND charger ='P4500' ORDER BY charger, cast (vdc as int), cast(idc as int) ";

            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                string new_avail_ID = Oreadr["Avail_ID"].ToString();
                for (int i = 0; i < 100; i++)
                {
                    textBox1.Text = new_avail_ID;
                    if (arr_CptsID[i] != "")
                    {
                        stSql = "insert into link_COMPNT_AVAIL_SIM ([Compnt_ID],[Avail_ID],[Qty],[phs]) Values (" + arr_CptsID[i] +
                            ", " + new_avail_ID + ", 1, '" + _phs + "')";
                        MainMDI.ExecSql(stSql);
                    }
                    else i = 100;
                }
            }
            OConn.Close();
        }

        private void btn_create_LCA_Click(object sender, EventArgs e)
        {
            fill_CptsID(toolStripComboBox1.Text[0].ToString());
            create_Lnk_cpt_Avail(toolStripComboBox1.Text[0].ToString(), txIDC.Text);
        }

        private void phsNew_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {

        }

        private void phs1_Click(object sender, EventArgs e)
        {
            sel_PHS(3);
        }

        private void phs3_Click(object sender, EventArgs e)
        {
            sel_PHS(1);
        }

        private void sel_PHS(int phs)
        {
            toolStripComboBox1.Text = phs.ToString() + " Phase";
            phs1.Visible = (phs == 1);
            phs3.Visible = (phs == 3);
            picphs1.Visible = (phs == 1);
            picphs3.Visible = (phs == 3);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EnaAv_VDC_Click(object sender, EventArgs e)
        {
            if (x_stSql != "")
            {
                dlg_Avail davail = new dlg_Avail(toolStripComboBox1.Text[0].ToString(), cur_CPTid, lCurSoln, lCurALSn); //, x_stSql);
                davail.ShowDialog();
                fill_lvCH_QTY(lCurSoln, toolStripComboBox1.Text[0].ToString(), lCurSPCn, lCurALSn);
            }
            else MessageBox.Show("X_StSql is empty................");
        }

        private void TSmain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {

        }

        private void tsb_DisallVDC_Click(object sender, EventArgs e)
        {

        }

        private void EnDis_VDC_Click(object sender, EventArgs e)
        {
            dlg_VDC_IDC_Disable disVDC_IDC = new dlg_VDC_IDC_Disable(toolStripComboBox1.Text[0].ToString(), "V");
            disVDC_IDC.ShowDialog();
        }

        private void EnDis_IDC_Click(object sender, EventArgs e)
        {

        }
        */
    }
}