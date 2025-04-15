using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;



namespace PGESCOM
{
    public partial class Q_Single : Form
    {


        Bitmap bmp;

        int picDIODlineX = 0, picDIODlineY = 0, 
            picDCBRKRlineX = 0, picDCBRKRlineY = 0, 
            picSHNTlineX = 0, picSHNTlineY = 0;
        string in_SiteNm = "", in_SysNm = "";
        QuoteV4 in_Quote4 = null; 




        public Q_Single(QuoteV4 x_Quote4 ,string x_SiteNm, string x_SysNm)
        {
            InitializeComponent();
            in_Quote4 = x_Quote4;
            in_SiteNm = x_SiteNm;
            in_SysNm = x_SysNm;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private void DrawRectangle()
        {
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            formGraphics.DrawRectangle(myPen, new Rectangle(0, 0, 200, 300));
            myPen.Dispose();
            formGraphics.Dispose();
        }

        void fill_LineXY_orig()
        {

            picDIODlineX =picDIODline.Location.X;
            picDIODlineY =picDIODline.Location.Y;

            picDCBRKRlineX = picDCBRKRline.Location.X;
            picDCBRKRlineY = picDCBRKRline.Location.Y;

            picSHNTlineX = picSHNTline.Location.X;
            picSHNTlineY = picSHNTline.Location.Y;
   
    

        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tsItem = (ToolStripMenuItem)sender;
            var cms = (ContextMenuStrip)tsItem.Owner;
            RemoveCpt(cms.SourceControl.Name);
     
        }


        void RemoveCpt(string CptNm)
        {

            switch (CptNm)
            {
                case "picSHNT":
                case "picSHNT_lbl":

                    remove_Shint();

                    break;
                case "picDIOD":
                case "picDIOD_name":
                case "picDIOD_lbl":

                    picDIOD.Visible = false;
                    //  picDIOD.Location = new Point(picDIODline.Location.X, picDIODline.Location.Y);

                    picDIODline.Visible = true;
                    picDIODline.Location = new Point(picDIOD.Location.X, picDIOD.Location.Y);
                    picDIOD_name.Visible = false;
                    //    picDIOD_lbl.Visible = false;
                    break;
                case "picDCBRKR":
                case "picDCBRKR_name":
                case "picDCBRKR_lbl":
                    picDCBRKR.Visible = false;
                    //     picDCBRKR.Location = new Point(picDCBRKRline.Location.X, picDCBRKRline.Location.Y);

                    picDCBRKRline.Visible = true;
                    picDCBRKRline.Location = new Point(picDCBRKR.Location.X, picDCBRKR.Location.Y);
                    picDCBRKR_name.Visible = false;
                    //picDCBRKR_lbl.Visible = false;

                    break;
                case "picBatt":
                case "picBatt_lbl":

                    picBatt.Visible = false;
                    picbatt_line1.Visible = false;
                    picbatt_line2.Visible = false;
                    picBatt_lbl.Visible = false;
                    remove_Shint();

                    if (picSHNTline.Visible)
                    {

                        picSHNTline_1.Visible = false;
                        picSHNTline_2.Visible = false;
                        picSHNTline.Visible = false;
                    }

                    picDPline1.Visible = picDistrPnl.Visible;

                    break;
                case "picDistrPnl":
                case "picDistrPnl_name":
                case "picDistrPnl_lbl":
                    picDistrPnl.Visible = false;
                    picDPline4.Visible = false;
                    picDPline3.Visible = false;
                    picDPline2.Visible = false;
                    picDPline1.Width = 85;
                    picDistrPnl_name.Visible = false;
                    //   picDistrPnl_lbl.Visible = false;
                    if (!picBatt.Visible) picDPline1.Visible = false;
                    break;
                case "cadre3_H":
                case "cadre3":
                    cadre3_H.Visible = false;
                    cadre3.Visible = false;
                    break;
                case "cadre2_H":
                case "cadre2":
                    cadre2_H.Visible = false;
                    cadre2.Visible = false;
                    break;
                case "cadre1_H":
                case "cadre1":
                    cadre1_H.Visible = false;
                    cadre1.Visible = false;
                    break;
                case "cadre0_H":
        
                    cadre0_H.Visible = false;
                  //  cadre0.Visible = false;
                    break;

            }
            Make_Frml();
        }

        void remove_Shint()
        {

            picSHNT.Visible = false;
            picSHNT_lbl.Visible = false;
            //picSHNT.Location = new Point(picSHNTline.Location.X, picSHNTline.Location.Y);

            picSHNTline.Visible = true;
            picSHNTline.Location = new Point(picSHNT.Location.X, picSHNT.Location.Y);
           
        }

        void addBatteries()
        {
            if (!picBatt.Visible)
            {
                bool stat = true;
                picBatt.Visible = stat;
                picbatt_line1.Visible = stat;
                picbatt_line2.Visible = stat;
                picBatt_lbl.Visible = stat;
                picSHNTline_1.Visible = stat;
                picSHNTline_2.Visible = stat;

                remove_Shint();
                if (!picDistrPnl.Visible )
                {
                    picDPline1.Width = 85;
                   picDPline1.Visible = true;
                }
               
            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            AddShint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDiode();
        }

        private void AddDiode()
        {
            if (!picDIOD.Visible)
            {

                //int X = picDIOD.Location.X, Y = picDIOD.Location.Y;

                picDIOD.Visible = true;
                picDIOD_name.Visible = true;
                picDIODline.Visible = false;
                picDIODline.Location = new Point(picDIODlineX,picDIODlineY);
            //    picDIOD_lbl.Visible = true;

            }
        }

        private void AddDCBRKR()
        {
            if (!picDCBRKR.Visible)
            {

                picDCBRKR.Visible = true;
                picDCBRKR_name.Visible = true;
                 picDCBRKRline.Visible = false;
                picDCBRKRline.Location = new Point(picDCBRKRlineX, picDCBRKRlineY);
            //    picDCBRKR_lbl.Visible = true;

            }
        }
        void AddShint()
        {
            if (picBatt.Visible)
            {

                if (!picSHNT.Visible)
                {
                    picSHNT.Visible = true;
                    picSHNT_lbl.Visible = true;
                    picSHNTline.Visible = false;
                    picSHNTline.Location = new Point(picSHNTlineX, picSHNTlineY);
                    
                }
            }

        }
        void AddDistPanel()
        {
            if (!picDistrPnl.Visible)
            {
                    picDistrPnl.Visible = true;
                    picDPline4.Visible = true;
                    picDPline3.Visible = true;
                    picDPline2.Visible = true;
                    picDPline1.Width = 172;
                    picDPline1.Visible = true;
                    picDistrPnl_name.Visible = true;
                  //  picDistrPnl_lbl.Visible = true;
                  

               
            }

        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Bitmap bm = new Bitmap(this.panel1.Width, this.panel1.Height);
            //this.panel1.DrawToBitmap(bm, new Rectangle(50, 50, this.panel1.Width + 50, this.panel1.Height + 50));
            //e.Graphics.DrawImage(bm, 0, 0);

            //Bitmap bm = new Bitmap(this.chart1.Width, this.chart1.Height);
            //this.chart1.DrawToBitmap(bm, new Rectangle(50, 50, this.chart1.Width + 50, this.chart1.Height + 50));
            //e.Graphics.DrawImage(bm, 0, 0);

            e.Graphics.DrawImage(bmp, 0, 0);
        }

        void print_form()
        {

            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(panel1.Size.Width, panel1.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(panel1.Location.X, panel1.Location.Y+25, 0,0, panel1.Size);
            printPreviewDialog1.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            addBatteries();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            printDocument1.DefaultPageSettings.Landscape = true;
            print_form();
  
        }

        void PrintGrp()
        {



        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddDCBRKR();
        }

        private void button6_Click(object sender, EventArgs e)
        {
         //   picDPline1.Width = 85;
          //  picDistrPnl_name.Text = picDPline1.Width.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddDistPanel();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cadre3_H.Visible = true;
            cadre3.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lRect_Chrgr.Text = "Charger";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lRect_Chrgr.Text = "Rectifier";
        }

        private void picCIP_Click(object sender, EventArgs e)
        {

        }

        private void addCharger_Click(object sender, EventArgs e)
        {
           
        }

        private void tlsAddREC_Click(object sender, EventArgs e)
        {
            
        }

        private void AddDCbreaker_Click(object sender, EventArgs e)
        {
           
        }

        private void a_Charger_Click(object sender, EventArgs e)
        {
          
        }

        private void a_RECTIF_Click(object sender, EventArgs e)
        {
            
        }

        private void a_dcbreaker_Click(object sender, EventArgs e)
        {
            AddDCBRKR();
            Make_Frml();
        }

        private void shintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddShint();
            Make_Frml();
        }

        private void diodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDiode();
            Make_Frml();
        }

        private void batteriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBatteries();
            Make_Frml();
        }

        private void distributionPanelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddDistPanel();
            Make_Frml();
        }

        private void cabinetbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadre2_H.Visible = true;
            cadre2.Visible = true;

            if (cadre0.Visible) RemoveCpt("cadre0_H");
            if (cadre3.Visible) RemoveCpt("cadre3_H");
            if (cadre1.Visible) RemoveCpt("cadre1_H");
            Make_Frml();
        }

        private void a_cab_A_Click(object sender, EventArgs e)
        {
            cadre1_H.Visible = true;
            cadre1.Visible = true;

            if (cadre0.Visible) RemoveCpt("cadre0_H");
            if (cadre3.Visible ) RemoveCpt("cadre3_H");
            if (cadre2.Visible) RemoveCpt("cadre2_H");
            Make_Frml();
        }

        private void cabinetcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadre3_H.Visible = true;
            cadre3.Visible = true;

            if (cadre0.Visible) RemoveCpt("cadre0_H");
            if (cadre1.Visible) RemoveCpt("cadre1_H");
            if (cadre2.Visible) RemoveCpt("cadre2_H");
            Make_Frml();
        }

        private void ElecSC_AM_Click(object sender, EventArgs e)
        {
            lRect_Chrgr.Text = "Charger";
            Make_Frml();
        }

        private void ElecSC_List_Click(object sender, EventArgs e)
        {
            lRect_Chrgr.Text = "Rectifier";
            Make_Frml();
        }

        private void Q_Single_Load(object sender, EventArgs e)
        {
            fill_LineXY_orig();
            lSITE.Text = "Site: " + in_SiteNm;
            lSYS.Text = "System: " + in_SysNm;
            Make_Frml();
        }

        private void _exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void addContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tsItem = (ToolStripMenuItem)sender;
            var cms = (ContextMenuStrip)tsItem.Owner;
            ADDContent(cms.SourceControl.Name);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var tsItem = (ToolStripMenuItem)sender;
            var cms = (ContextMenuStrip)tsItem.Owner;
            ADDContent(cms.SourceControl.Name);
        }

        void ADDContent(string ctrlName)
        {

            //var tsItem = (ToolStripMenuItem)sender;
            //var cms = (ContextMenuStrip)tsItem.Owner;
            int X = 0, Y = 0;
            //MessageBox.Show ("control: " +);
            switch (ctrlName)
            {

                case "picSHNT":
                case "picSHNT_lbl":

                    this.Hide();

                    break;
                case "CHRGR":
                case "lRect_Chrgr":

                    MessageBox.Show("Rectifier / Charger");
                    Q_System mySYS = new Q_System(in_Quote4, lRect_Chrgr.Text,in_SysNm,"");
                    this.Hide();
                    mySYS.ShowDialog();
                    this.Visible = true;
                    break;
                case "picDIOD":
                case "picDIOD_name":
                case "picDIOD_lbl":

                    MessageBox.Show("DIOOOOOOODeeee");
                    break;
                case "picDCBRKR":
                case "picDCBRKR_name":
                case "picDCBRKR_lbl":
                    MessageBox.Show("DC Breeeeeeeeeaaaaker");

                    break;
                case "picBatt":
                case "picBatt_lbl":

                    MessageBox.Show("Batteriiiiiiiiiiiiiiiiiiiiiies");

                    break;
                case "picDistrPnl":
                case "picDistrPnl_name":
                case "picDistrPnl_lbl":
                    MessageBox.Show("Paneeeeeeeeeeeeeeeeeeeelll");
                    break;
                case "cadre3_H":
                case "cadre3":
                    MessageBox.Show("CABinet 3");
                    break;
                case "cadre2_H":
                case "cadre2":
                    MessageBox.Show("CABinet 22");
                    break;
                case "cadre1_H":
                case "cadre1":
                    MessageBox.Show("CABinet 1");
                    break;

            }

        }

        void ADDContent()
        {


          //  MessageBox.Show("Rectifier / Charger");
            Q_System mySYS = new Q_System(in_Quote4, lRect_Chrgr.Text, in_SysNm,lFRML.Text);
            this.Hide();
            mySYS.ShowDialog();
            this.Visible = true;


        }

        private void displayContentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAC_Click(object sender, EventArgs e)
        {

            ADDContent();

        }

       void Make_Frml()
        {
            lFRML.Text = etat_ACBreaker() + etat_Chrgr_Recvt() + etat_BDiode() + etat_DCBreaker() + etat_Cabinet() + etat_Shint() + etat_Batt() + etat_DP();
            this.Refresh();
           // return lFRML.Text;
        }
        string etat_ACBreaker()
        {
            return "1";
        }
        string etat_Chrgr_Recvt()
        {
            return lRect_Chrgr.Text [0].ToString ();
        }

        string etat_BDiode()
        {
            return (picDIOD.Visible) ? "1" : "0";
        }

        string etat_DCBreaker()
        {
            return (picDCBRKR.Visible) ? "1" : "0";
        }

        string etat_Shint()
        {
            return (picSHNT.Visible) ? "1" : "0";
        }
        string etat_Batt()
        {
            return (picBatt.Visible) ? "1" : "0";
        }

        string etat_DP()
        {
            return (picDistrPnl.Visible) ? "1" : "0";
        }


        string etat_Cabinet()
        {

            if (cadre0_H.Visible) return "0";
            else
            {
                if (cadre1_H.Visible) return "A";
                else
                {
                    if (cadre2_H.Visible) return "B";
                    else return "C";
                }
            }


        }

        private void DiagSave_Click(object sender, EventArgs e)
        {

        }











    }
}
