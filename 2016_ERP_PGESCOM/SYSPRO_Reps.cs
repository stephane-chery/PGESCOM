using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq ;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using EAHLibs;
using System.Xml;
using Word = Microsoft.Office.Interop.Word;

namespace PGESCOM
{
  


    public partial class SYSPRO_Reps : Form
    {

        	private Lib1 Tools = new Lib1();
            private string in_lbl1 = "", in_lbl2 = "", in_lbl3 = "";
        //    private Word.Application app = new Word.ApplicationClass();
            private object Omiss = System.Reflection.Missing.Value;
            private object start = 0;
            private object end = 0;
            private string in_prtNme = "";
            private string Tfn = "";
            private string Ofn = "";
            char in_docType = 'P';

        public SYSPRO_Reps()
        {
            InitializeComponent();


           
        }

        private void grpInv_Enter(object sender, EventArgs e)
        {

        }



        Control SetFldsByName(string Name, string VVV)
        {
            switch (in_docType )
            {
                case 'I':

                    foreach (Control c in grpINVOICE.Controls)
                        if (c.Name == Name) c.Text = VVV;
                    break;
                case 'P':

                    foreach (Control c in grpPKSLP.Controls)
                        if (c.Name == Name) c.Text = VVV;
                    break;
                case 'C':

                    foreach (Control c in grpCOMI.Controls)
                        if (c.Name == Name) c.Text = VVV;
                    break;

            }

            return null;
        }

        private void add_line_grid(string ln, string stkcode, string skd_BX_Nb, string weight, string Qty)
        {
            DataGridViewRow my_line = new DataGridViewRow();
            my_line.CreateCells(dataGridView1);
            my_line.Cells[0].Value = ln;
            my_line.Cells[1].Value = stkcode;
            my_line.Cells[2].Value = skd_BX_Nb;
            my_line.Cells[3].Value = weight;
            my_line.Cells[4].Value = Qty;
            dataGridView1.Rows.Add();
        }

        private void fill_Grid(string[,] my_arr)
        {
            for (int i = 0; i < 20; i++)
            {
                if (my_arr[i, 0] != "")
                {
                    DataGridViewRow my_line = new DataGridViewRow();
                    my_line.CreateCells(dataGridView1);
                    int g = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (j == 2) my_line.Cells[g - 1].Value += "    " + my_arr[i, j];
                        else my_line.Cells[g++].Value = my_arr[i, j];
                    }
                    dataGridView1.Rows.Add(my_line);
                }
                else i = 20;
            }
        }



        private void XML_readVARS()
        {

            openFileDialog2.Filter = "xml|*.xml|all files|*.*";
            DialogResult res = openFileDialog2.ShowDialog();
            string[,] arr_details = new string[20, 6];
            for (int i = 0; i < 20; i++) for (int j = 0; j < 6; j++) arr_details[i, j] = "";
            if (res == DialogResult.OK)
            {

                XmlDocument doc = new XmlDocument();

                //      try
                //       {
                doc.Load(openFileDialog2.FileName);

                XmlNodeList nodeListFLDS = doc.GetElementsByTagName("Field");

                string stOut = "NB= " + nodeListFLDS.Count.ToString() + "\r\n";
                int i = -1;
                foreach (XmlElement fld in nodeListFLDS)
                {

                    string fldName = fld.GetAttribute("Name");
                    switch (fldName)
                    {

                        case "DetDetailLine1":
                            arr_details[i, 0] = fld.ChildNodes[0].InnerText;
                            break;
                        case "DetOrderQty1":
                            arr_details[++i, 5] = fld.ChildNodes[0].InnerText;
                            break;

                        default:
                            SetFldsByName(fldName, fld.ChildNodes[0].InnerText);
                            break;

                    }



                }


                XmlNodeList nodeListTXTs = doc.GetElementsByTagName("Text");

                stOut = "NB= " + nodeListTXTs.Count.ToString() + "\r\n";
                i = -1;
                int j = -1;
                foreach (XmlElement fld in nodeListTXTs)
                {


                    string TT = fld.GetAttribute("Name").ToString();
                    switch (TT)
                    {

                        case "Text4":

                            arr_details[++i, 1] = fld.ChildNodes[0].InnerText;
                            break;
                        case "Text6":
                            arr_details[++j, 2] += "         " + fld.ChildNodes[0].InnerText;
                            break;

                        default:
                            SetFldsByName(TT, fld.ChildNodes[0].InnerText);
                            //   if (fld.ChildNodes.Count >0) this.Controls[TT].Text = fld.ChildNodes[0].InnerText;
                            break;

                    }
                }


                fill_Grid(arr_details);

            }
        }





        private void read_XML_direct()
        {

            openFileDialog2.Filter = "xml|*.xml|all files|*.*";
            DialogResult res = openFileDialog2.ShowDialog();
            string[,] arr_details = new string[20, 6];
            for (int i = 0; i < 20; i++) for (int j = 0; j < 6; j++) arr_details[i, j] = "";
            if (res == DialogResult.OK)
            {

                XmlDocument doc = new XmlDocument();

                //      try
                //       {
                doc.Load(openFileDialog2.FileName);

                XmlNodeList nodeListFLDS = doc.GetElementsByTagName("Field");

                string stOut = "NB= " + nodeListFLDS.Count.ToString() + "\r\n";
                int i = -1;
                foreach (XmlElement fld in nodeListFLDS)
                {

                    string fldName = fld.GetAttribute("Name");
                    switch (fldName)
                    {

                        case "DetDetailLine1":
                            arr_details[i, 0] = fld.ChildNodes[0].InnerText;
                            break;
                        case "DetOrderQty1":
                            arr_details[++i, 5] = fld.ChildNodes[0].InnerText;
                            break;

                        default:
                            SetFldsByName(fldName, fld.ChildNodes[0].InnerText);
                            break;

                    }



                }


                XmlNodeList nodeListTXTs = doc.GetElementsByTagName("Text");

                stOut = "NB= " + nodeListTXTs.Count.ToString() + "\r\n";
                i = -1;
                int j = -1;
                foreach (XmlElement fld in nodeListTXTs)
                {


                    string TT = fld.GetAttribute("Name").ToString();
                    switch (TT)
                    {

                        case "Text4":

                            arr_details[++i, 1] = fld.ChildNodes[0].InnerText;
                            break;
                        case "Text6":
                            arr_details[++j, 2] += "    " + fld.ChildNodes[0].InnerText;
                            break;

                        default:
                            SetFldsByName(TT, fld.ChildNodes[0].InnerText);
                            //   if (fld.ChildNodes.Count >0) this.Controls[TT].Text = fld.ChildNodes[0].InnerText;
                            break;

                    }
                }


                fill_Grid(arr_details);

            }
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //SELECT  Customer,InvoiceDate,CustomerPoNumber  FROM ArInvoice where Invoice='009308'  // invoice
            switch (in_docType)
            {
                case 'P':
                    init_PKSLIP();
                    read_XML_direct();
                    break;
                case 'I':
                  //  init_PKSLIP();
                    read_XML_direct();
                    break;
            }
        }

        private void tsb_InsideS_Click(object sender, EventArgs e)
        {

        }

        private void tsb_INVOICE_Click(object sender, EventArgs e)
        {
            grpINVOICE.Dock = DockStyle.Fill;
            grpINVOICE.BringToFront();
     //       lblTITR.Text = "INVOICE";
     //       lblTITR.BackColor = Color.Blue;
            in_docType = 'I';
        }

        private void tsb_COMMI_Click(object sender, EventArgs e)
        {
            grpCOMI.Dock = DockStyle.Fill;
            grpCOMI.BringToFront();
        //    lblTITR.Text = "COMMERCIAL INVOICE";
       //     lblTITR.BackColor = Color.Red;
            in_docType = 'C';
        }

        private void tsb_PKSLP_Click(object sender, EventArgs e)
        {
            grpPKSLP.Dock = DockStyle.Fill;
            grpPKSLP.BringToFront();
         //   lblTITR.Text = "PACKING SLIP";
        //    lblTITR.BackColor = Color.Maroon;
            in_docType = 'P';
        }

        private void grpPKSLP_Enter(object sender, EventArgs e)
        {

        }

        private void tsb_Add_Click(object sender, EventArgs e)
        {
            add_line_grid("", "", "", "", "");
        }

        private void tsb_Del_Click(object sender, EventArgs e)
        {
            

            if (dataGridView1.SelectedRows.Count ==1)  dataGridView1.Rows.RemoveAt ( dataGridView1.SelectedRows[0].Index);   
  
        }

        private string DDHHmnSTMP()
        {
            DateTime dt=DateTime.Now;
            return "_" + dt.DayOfYear.ToString () + dt.Hour +dt.Minute ;

        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {

      
                      
                        this.Cursor = Cursors.WaitCursor;
                        if (dataGridView1.Rows.Count > 0)
                        {
                          if (  Wexport())      MainMDI.OpenMicrosoftWord(Ofn  );
                        }
                        else MessageBox.Show("Your Shipping List is Empty.....!!!!");
                        this.Cursor = Cursors.Default;
                      
    
        }



        public bool Wexport()
        {
             Tfn = System.Environment.CurrentDirectory;
            Ofn = Tfn;

            switch (in_docType)
            {

     
                case 'P':    //packing Slip
                    Tfn += @"\SYSPRO_Pkslp.doc";
                  //  string pth = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); 

                    Ofn = @"c:\SYSPRO_REPORTS\WORD\Pkslp_"+DDHHmnSTMP();
                    PrintinWord my_Pword = new PrintinWord(Tfn, Ofn, 'P', grpPKSLP,dataGridView1  );
                    my_Pword.OpenWF();
                    my_Pword.Page_PSLIP_Details();
                    my_Pword.PrintOutDoc();
                    return true; 
                    break;
           
            }


            return false;
        }


    




        private void init_PKSLIP()
        {
            foreach (Control ctrl in grpPKSLP.Controls)
            {
                TextBox tx = ctrl as TextBox ;
                if (tx != null) tx.Clear();
                else
                {
                    RichTextBox Rtx = ctrl as RichTextBox;
                    if (Rtx != null) Rtx.Clear(); 
                }


            }
            dataGridView1.Rows.Clear();
        }

        void Init_filesSave()
        {
            
            if (!System.IO.Directory.Exists (@"c:\SYSPRO_REPORTS") ) System.IO.Directory.CreateDirectory ( @"c:\SYSPRO_REPORTS");
            if (!System.IO.Directory.Exists (@"c:\SYSPRO_REPORTS\WORD") ) System.IO.Directory.CreateDirectory ( @"c:\SYSPRO_REPORTS\WORD");
        }
        private void SYSPRO_Reps_Load(object sender, EventArgs e)
        {
            Init_filesSave();
        }







             
    }
}
