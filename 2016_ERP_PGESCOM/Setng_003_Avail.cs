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
    public partial class Setng_003_Avail : Form
    {

        private EAHLibs.Lib1 Tools=new Lib1 ();
        private int CompntSEL = -1,lCurSolNDX=-1,  lCurSPCNDX =-1, lCurALSNDX = -1;
        string ALSadded = "",lCurSoln ="",	lCurSPCn = "",	lCurALSn ="",cur_CPTid="",x_stSql="" ;
        
 
        string[] arr_CptsID=new  string[100]  ;

        public Setng_003_Avail()
        {
            InitializeComponent();
        //    toolStripComboBox1.SelectedIndex = 1;   
            sel_PHS(1);

        }


        private void fill_CptsID(string _phs)
        {


            string stSql = " select distinct Compnt_ID from dbo.link_COMPNT_AVAIL  where phs='" + _phs + "' order by Compnt_ID "; 

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int i=0;
            for (i=0;i<100;i++) arr_CptsID[i]=""; 
            i=0;
            while (Oreadr.Read()) arr_CptsID[i++] = Oreadr["Compnt_ID"].ToString();
            OConn.Close();
 

        }
      
        
        private void fill_lvCH_QTY(string _CptRef,string _Phs,string _charger, string _VDC)
        {
         
  
       
      //     string stSql = " SELECT  COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.Component_ID, TBLAVAIL" + _Phs + ".charger, CAST(TBLAVAIL" + _Phs + ".vdc AS int) AS VDC, CAST(TBLAVAIL" + _Phs + ".idc AS int) AS IDC ,link_COMPNT_AVAIL.Qty, link_COMPNT_AVAIL.Avail_ID" +
      //                           " FROM    link_COMPNT_AVAIL INNER JOIN TBLAVAIL" + _Phs +" ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + _Phs +".Avail_ID INNER JOIN  COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
      //                           " WHERE     (link_COMPNT_AVAIL.phs =" + _Phs +") ORDER BY COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + _Phs +".charger, VDC, IDC ";

            string stSql = " SELECT  COMPNT_LIST.Component_ID, CAST(TBLAVAIL" + _Phs + ".idc AS int) AS IDC, link_COMPNT_AVAIL.Qty, link_COMPNT_AVAIL.Avail_ID, link_COMPNT_AVAIL.LCA_LID " +
                          " FROM         link_COMPNT_AVAIL INNER JOIN  TBLAVAIL" + _Phs + " ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + _Phs + ".Avail_ID INNER JOIN  COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                          " WHERE     (link_COMPNT_AVAIL.phs = " + _Phs + ") AND (COMPNT_LIST.COMPONENT_REF = '" + _CptRef + "') AND (TBLAVAIL" + _Phs + ".charger = '" + _charger + "') AND (CAST(TBLAVAIL" + _Phs + ".vdc AS int)  = " + _VDC + ") " +
                          " ORDER BY IDC ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
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
                lv.SubItems.Add(_charger + "-" + _Phs + "-" + _VDC +"-" + Oreadr["IDC"].ToString());
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
                                 " FROM    link_COMPNT_AVAIL INNER JOIN TBLAVAIL" + _Phs +" ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + _Phs +".Avail_ID INNER JOIN  COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                                 " WHERE     (link_COMPNT_AVAIL.phs =" + _Phs +") ORDER BY COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + _Phs +".charger, VDC, IDC ";

                  SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                  OConn.Open();
                  SqlCommand Ocmd = OConn.CreateCommand();
                  Ocmd.CommandText = stSql;
                  SqlDataReader Oreadr = Ocmd.ExecuteReader();
                  TVavail.Nodes.Clear ();
                  TVavail.BeginUpdate();
                  while (Oreadr.Read())
                  {
                      Nsol = Oreadr["COMPONENT_REF"].ToString();
                      Nspc = Oreadr["charger"].ToString();
                      Nals = Oreadr["VDC"].ToString();
                      //   N_SpcRnk=Oreadr["p"].ToString();
                      if (Osol != Nsol)
                      {
                          ALSadded = "";
                          p = -1;
                          s++;
                          addNode_Sol(Nsol);

                          p++;
                          addNode_Spc(Nspc, s, p, Nals);
                          //	addNode_Als(Nals,s, p); 
                          Osol = Nsol;
                          Ospc = Nspc;
                         
                          //  O_SpcRnk=N_SpcRnk;
                      }
                      else
                      {

                          if (Ospc == Nspc) addNode_Als(Nals, s, p);
                          else
                          {
                              //	addNode_Als(Nals,s,p); 
                              // p++;
                              ALSadded = "";
                              addNode_Spc(Nspc, s, p, Nals);
                              Ospc = Nspc;
                              //  O_SpcRnk=N_SpcRnk;
                          }

                      }


                  }
                                //  Quote_loaded=true;
                                  TVavail.Select();  
                                  OConn.Close();

                                  for (int n = 0; n < TVavail.Nodes.Count; n++)
                                      TVavail.Nodes[n].Collapse();
                                  TVavail.EndUpdate(); 
        }


        private void addNode_Sol(string sName)
		{
            int imgI=2; 
			TVavail.Nodes.Add(sName ) ; 
			TVavail.Nodes[TVavail.Nodes.Count-1].ImageIndex = imgI;
            TVavail.Nodes[TVavail.Nodes.Count - 1].SelectedImageIndex = imgI; 
			//if (Sol_stat=="C")  tvSol.Nodes[tvSol.Nodes.Count-1].ForeColor =Color.Blue ; 

	
		}

		private void addNode_Spc(string spcName,int s,int p,string aName )
		{

            if (spcName == MainMDI.VIDE) { addNode_SPCNA(aName, s);  }
            else
            {
                TVavail.Nodes[s].Nodes.Add(spcName);
                TVavail.Nodes[s].Expand();
                TVavail.Nodes[s].Nodes[TVavail.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 1;
                TVavail.Nodes[s].Nodes[TVavail.Nodes[s].Nodes.Count - 1].ImageIndex = 1;
                addNode_Als(aName, s, p); ALSadded += " ||" + aName;

            }



		}
		private void addNode_Als(string alsName,int s,int p)
		{
            if (ALSadded.IndexOf(" ||" + alsName) == -1)
            {
                TVavail.Nodes[s].Nodes[p].Nodes.Add(alsName);
                ALSadded += " ||" + alsName;
                TVavail.Nodes[s].Expand();
                TVavail.Nodes[s].Nodes[p].Nodes[TVavail.Nodes[s].Nodes[p].Nodes.Count - 1].SelectedImageIndex = 0;
                TVavail.Nodes[s].Nodes[p].Nodes[TVavail.Nodes[s].Nodes[p].Nodes.Count - 1].ImageIndex = 0;
            }
	
		}
		private void addNode_SPCNA(string alsName,int s)
		{
			TVavail.Nodes[s].Nodes.Add(alsName  );
			TVavail.Nodes[s].Nodes[TVavail.Nodes[s].Nodes.Count -1].SelectedImageIndex =0;  
			TVavail.Nodes[s].Nodes[TVavail.Nodes[s].Nodes.Count -1].ImageIndex =0; 
		}

        private void NewItm_Click(object sender, EventArgs e)
        {
            dlg_CopyCPT_Avail _frm = new dlg_CopyCPT_Avail(toolStripComboBox1.Text[0].ToString());
            _frm.ShowDialog();
          //  fill_lvCH_QTY(lCurSoln, toolStripComboBox1.Text[0].ToString(), lCurSPCn, lCurALSn);
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
       //    CompntSEL=lvCpts.SelectedItems[0].Index ;  
/*
 Load_arr_full

 Uncheck_lstvphase
 fill_Avail_Phase
 lblphase_Change
 lblchargers_Change
 lblVDC_Change
 * */

        }

        private void TVavail_AfterSelect(object sender, TreeViewEventArgs e)
        {

            TV_Select();


        }
        private void TV_Select()
        {
            
            string[] res = new string[] { "", "", "" };
            MainMDI.Deco_path(TVavail.SelectedNode.FullPath.ToString(), ref res);
            lCurSoln = res[0];
            lCurSPCn = res[1];
            lCurALSn = res[2];

            lvCH_QTY.Items.Clear();

            switch (TVavail.SelectedNode.ImageIndex)
            {
                case 0:   //VDC
                 //   if (lCurALSNDX != -1) TVavail.Nodes[  
                  //  TVavail.SelectedNode.BackColor = Color.Yellow;
        
                    if (lCurALSn != MainMDI.VIDE && lCurALSn != "")
                    {
                        lCurSolNDX = TVavail.SelectedNode.Parent.Parent.Index;
                    }
                    else lCurSolNDX = TVavail.SelectedNode.Parent.Index;
                    lCurSPCNDX = TVavail.SelectedNode.Parent.Index;
                    lCurALSNDX = TVavail.SelectedNode.Index;
                    if (res[2] == "")
                    {
                        lCurALSn = res[1];
                        lCurSPCn = MainMDI.VIDE;
                        lCurSPCNDX = TVavail.SelectedNode.Index;
                    }

                    fill_lvCH_QTY(lCurSoln, toolStripComboBox1.Text[0].ToString (), lCurSPCn, lCurALSn); 
                    break;
                case 1:   //Charger
                    lCurSolNDX = TVavail.SelectedNode.Parent.Index;
                    lCurSPCNDX = TVavail.SelectedNode.Index;
       
                    break;
                case 2:   //Cpts

                    lCurSolNDX = TVavail.SelectedNode.Index;
                    break;
                    

            }
            TSmain.Visible = (TVavail.SelectedNode.ImageIndex == 2);
            TS_VDC.Visible = (TVavail.SelectedNode.ImageIndex == 0);
            TS_Charger.Visible = (TVavail.SelectedNode.ImageIndex == 1);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.Text)
            {
                case "Select Phase":
                    TVavail.Nodes.Clear();
                    break;
                case "1 Phase":
                case "3 Phase":
                    fill_Link_Avail(toolStripComboBox1.Text[0].ToString ());
                    break;
            }
        }

        private void Setng_003_Load(object sender, EventArgs e)
        {
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void create_Lnk_cpt_Avail(string _phs, string _idc)
        {
           string stSql = "SELECT * FROM TBLAVAIL" + _phs +" WHERE idc ='" + _idc + "' AND charger ='P4500' ORDER BY charger, cast (vdc as int), cast(idc as int) ";
                                
                  SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                  OConn.Open();
                  SqlCommand Ocmd = OConn.CreateCommand();
                  Ocmd.CommandText = stSql;
                  SqlDataReader Oreadr = Ocmd.ExecuteReader();
     
                  while (Oreadr.Read())
                  {
                     string new_avail_ID= Oreadr["Avail_ID"].ToString();
                     for (int i=0;i<100;i++)
                     {
                         textBox1.Text = new_avail_ID; 
                         if (arr_CptsID[i]!="")
                         {
                             stSql="insert into link_COMPNT_AVAIL_SIM ([Compnt_ID],[Avail_ID],[Qty],[phs]) Values ("+arr_CptsID[i] +
                                          ", " + new_avail_ID + ", 1, '" + _phs + "')";
                             MainMDI.ExecSql (stSql ); 
                           
                         }
                         else i=100;
                     }
                  }
            OConn.Close ();
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
            toolStripComboBox1.Text = phs.ToString () + " Phase";
            phs1.Visible = (phs==1);
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
                dlg_Avail davail = new dlg_Avail(toolStripComboBox1.Text[0].ToString(), cur_CPTid, lCurSoln, lCurALSn);//, x_stSql);
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
                dlg_VDC_IDC_Disable  disVDC_IDC = new dlg_VDC_IDC_Disable (toolStripComboBox1.Text[0].ToString(),"V");
                disVDC_IDC.ShowDialog();
             
        }

        private void EnDis_IDC_Click(object sender, EventArgs e)
        {

        }



    }
}