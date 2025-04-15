using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;

namespace PGESCOM
{
    public partial class PXMS_Charger_Setting : Form
    {
        private const int MAX_arrHtml = 500, MAX_GRPs=20;
        private int Current_GRPndx = -1;
     


        string[] arr_Html = new string[MAX_arrHtml];
        string[,] arr_Grps = new string[MAX_GRPs, 3];   //0=grpname     1=Rows#   2=Cols#

        private string[,] R_ChargerStatus,
                          R_Output,
                          R_Reference,
                          R_Equalize , 
                          R_Alarms ,
                          R_Formation ,
                          R_AHM ,
                          R_BatteryTest ,
                          R_Switch ,
                          R_Msg  ,
                          R_Time ,
                          R_TempComp,
                          R_Divers ;

        private int R_ChargerStatus_Rws, R_ChargerStatus_Cols;




        public PXMS_Charger_Setting()
        {
            InitializeComponent();
            fill_Groups();
        }

        private int find_grp(string _hdr)
        {
            // for (int r = 0; r < 6; r++) if (arr_Grps[r,0]==_hdr.Trim () ) return r; 
           for (int r = 0; r < MAX_GRPs; r++) if (arr_Grps[r,0]==_hdr.Trim () ) return r;
           return -1;
        }
        private void fill_Groups()
        {
            for (int rr = 0; rr < MAX_GRPs; rr++) for (int j = 0; j < 3; j++) arr_Grps[rr, j] = ""; //init groups array

            string stSql = " Select * from PXMS_Grp_Param order by Rnk_inWebPage";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int r=0;
            while (Oreadr.Read())
            {
                arr_Grps[r, 0] = Oreadr["G_Name"].ToString();
                arr_Grps[r, 1] = Oreadr["RowsNB"].ToString();
                arr_Grps[r++, 2] = Oreadr["ColsNB"].ToString();
            }
            OConn.Close();
      

        }

        private void init_tablesNM(string _hdr)
        {
            switch (_hdr)
            {
                case "Charger Status":
                    R_ChargerStatus[0, 0] = "Float";
                    R_ChargerStatus[1, 0] = "Equalize";
                    R_ChargerStatus[2, 0] = "Current_limit";
                    R_ChargerStatus[3, 0] = "Formation";
                    R_ChargerStatus[4, 0] = "Test_battery";
                    break;
                case "Output":
                    R_ChargerStatus[0, 0] = "Float";
                    R_ChargerStatus[1, 0] = "Equalize";
                    R_ChargerStatus[2, 0] = "Current_limit";
                    R_ChargerStatus[3, 0] = "Formation";
                    R_ChargerStatus[4, 0] = "Test_battery";
                    break;
            }


        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (thtml.Text.Length > 2)
            {
                Process_Html(thtml.Text);
            }

        }


        private void btnsend_Click(object sender, EventArgs e)
        {
            //    string Qstr = @"http://192.168.1.207/3?a14=10.0&a15=568.6&a16=10.00&a17=568.6&AC3=Apply";
            //   Charger_BWeb.Navigate(Qstr);
            // // http://192.168.1.161/Status.CGI
            // Charger_BWeb.Show();



            string strRES = send_URL(@"http://" + txChargerIP.Text + @"/3?a14=150.00&a15=568.6&a16=160.00&a17=568.6&AC3=Apply");
            if (strRES != null) Process_Html(strRES);

            else strRES = "NO data........";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string strRES = send_URL(@"http://" + txChargerIP.Text + @"/Status.CGI");
            if (strRES != null) Process_Html(strRES);

            else strRES = "NO data........";


            //    if (strRES != null) strRES = StripHTML (strRES);
        }



        private void Process_Html(string _stHtml)
        {
            _stHtml = HAK_htmlParse(_stHtml);
            Deco_strm(_stHtml);


            /*  using array of lines
                        arr_Html = div_Lines(_stHtml);
                        disp_arr(arr_Html);
                        fill_Tables(arr_Html);




                        string tmpFNM= Application.StartupPath + "\\tmpDecofile.txt";
                        WriteTo_ASCIIFile(arr_Html, tmpFNM );
 
                        System.Diagnostics.Process.Start(tmpFNM);
             */


        }
        private void Deco_strm(string _st)
        {

            int _idx = 0;
            string stLine = "", hdr = "";
            while (true)
            {
                int ipos = _st.IndexOf("]]]");
                if (ipos == -1)
                {
                    // arr_st[_idx] = _st;

                    break;
                }
                else
                {
                    stLine = _st.Substring(0, ipos + 3).TrimStart();
                    _st = _st.Substring(ipos + 3, _st.Length - ipos - 3);

                }

                ipos = stLine.IndexOf("[[[");
                if (ipos > -1)
                {
                    hdr = stLine.Substring(0, ipos).Trim ();
                  //  fill_GrpParam(hdr.TrimEnd(), stLine.Substring(ipos, stLine.Length - ipos));

                    if ((Current_GRPndx = find_grp(hdr)) != -1)
                    {
                        if (Current_GRPndx == 7) Current_GRPndx = Current_GRPndx;
                        PXMS_group Grp = new PXMS_group(Int32.Parse(arr_Grps[Current_GRPndx, 1]), Int32.Parse(arr_Grps[Current_GRPndx, 2]), hdr, stLine.Substring(ipos, stLine.Length - ipos));
                        populate_Arr(hdr, Grp.get_Gr_Params());
                    }
                    else   MessageBox.Show ("Sorry group not Found.....=" + hdr);
                   // MessageBox.Show("group Done..... =" + hdr); 
                }
                if (_st.Length == 0) break;
                _idx++;
            }

        }

        private void fill_LV( ListView _lvParam,string Grpmsg, string[,] _arr_lectures )
        {
            int _Rws=Int32.Parse (arr_Grps[Current_GRPndx ,1]);
            int _Cols=Int32.Parse (arr_Grps[Current_GRPndx ,2]);
            if (_lvParam.Items.Count == 0) 
                    {
                        for (int r=0;r<_Rws ;r++) 
                        {
                            ListViewItem lv = _lvParam.Items.Add(_arr_lectures[r, 0]);
                          for (int c=0;c<_Cols ;c++) lv.SubItems.Add (""); 
                        }
                    }
                    if (_lvParam.Items.Count > 0) for (int r = 0; r < _Rws; r++) for (int c = 1; c < _Cols; c++) _lvParam.Items[r].SubItems[c].Text = _arr_lectures[r, c];
                    else MessageBox.Show("Error in " + Grpmsg + " Rows=0....");
        }


        //Display data read from Charger on screen 
        private void populate_Arr(string _hdr, string[,] _arr_lectures)
        {
            int _Rws=Int32.Parse (arr_Grps[Current_GRPndx ,1]);
             int _Cols=Int32.Parse (arr_Grps[Current_GRPndx ,2]);
            switch (_hdr)
            {
                  case "Charger Status":

                   fill_LV (lvCStatus ,_hdr, _arr_lectures );
                    break;


                case "Output":
                    fill_LV(lvOutput, _hdr, _arr_lectures);
                      break;
                case "Reference":
                    fill_LV(lvReference, _hdr, _arr_lectures);
                    break;
                case "Equalize":
                    fill_LV(lvEq, _hdr, _arr_lectures);
                    break;
                case "Alarms":
                    fill_LV(lvAlarms , _hdr, _arr_lectures);
                    break;
                case "Formation":
                    fill_LV(lvFormation , _hdr, _arr_lectures);
                    break;
                case "Amper Hour Meter":
                    fill_LV(lvAHM, _hdr, _arr_lectures);
                    break;
                case "Battery Test":
                    fill_LV(lvBatteryTest, _hdr, _arr_lectures);
                    break;
                case "Switch":
                    fill_LV(lvSwitch, _hdr, _arr_lectures);
                    break;
                case "Messages":
                    fill_LV(lvMsg , _hdr, _arr_lectures);
                    break;
                case "Time":
                    fill_LV(lvTime , _hdr, _arr_lectures);
                    break;
                case "Temperature Compensation":
                    fill_LV(lvTempC , _hdr, _arr_lectures);
                    break;
                case "Divers":
                    fill_LV(lvDivers , _hdr, _arr_lectures);
                    break;
                default:
                    Current_GRPndx = Current_GRPndx;
                    break;

            }

        }

        private void populate_ArrOLDDD(string _hdr, string[,] _arr_lectures)
        {
            int _Rws = Int32.Parse(arr_Grps[Current_GRPndx, 1]);
            int _Cols = Int32.Parse(arr_Grps[Current_GRPndx, 2]);
            switch (_hdr)
            {
                case "Charger Status":
                    //      if (lvCStatus.Items.Count ==0  ) 
                    //     {
                    //          for (int r=0;r<_Rws ;r++) 
                    //         {
                    //           ListViewItem lv = lvCStatus.Items.Add(_arr_lectures[r,0] );
                    //          for (int c=0;c<_Cols ;c++) lv.SubItems.Add (""); 
                    //         }
                    //     }
                    //       if (lvCStatus.Items.Count > 0) for (int r = 0; r < _Rws; r++) for (int c = 1; c < _Cols; c++) lvCStatus.Items[r].SubItems[c].Text = _arr_lectures[r, c];
                    //       else MessageBox.Show("Error in Charger status Rows=0...."); 
                    fill_LV(lvCStatus, _hdr, _arr_lectures);
                    break;


                case "Output":
                    if (lvOutput.Items.Count == 0)
                    {
                        for (int r = 0; r < _Rws; r++)
                        {
                            ListViewItem lv = lvOutput.Items.Add(_arr_lectures[r, 0]);
                            for (int c = 0; c < _Cols; c++) lv.SubItems.Add("");
                        }
                    }
                    if (lvOutput.Items.Count > 0) for (int r = 0; r < _Rws; r++) for (int c = 1; c < _Cols; c++) lvOutput.Items[r].SubItems[c].Text = _arr_lectures[r, c];
                    else MessageBox.Show("Error in Charger status Rows=0....");
                    break;
                case "Reference":
                    if (lvReference.Items.Count == 0)
                    {
                        for (int r = 0; r < _Rws; r++)
                        {
                            ListViewItem lv = lvReference.Items.Add(_arr_lectures[r, 0]);
                            for (int c = 0; c < _Cols; c++) lv.SubItems.Add("");
                        }
                    }
                    if (lvReference.Items.Count > 0) for (int r = 0; r < _Rws; r++) for (int c = 1; c < _Cols; c++) lvReference.Items[r].SubItems[c].Text = _arr_lectures[r, c];
                    else MessageBox.Show("Error in Charger status Rows=0....");
                    break;
                case "Equalize":
                    if (lvEq.Items.Count == 0)
                    {
                        for (int r = 0; r < _Rws; r++)
                        {
                            ListViewItem lv = lvEq.Items.Add(_arr_lectures[r, 0]);
                            for (int c = 0; c < _Cols; c++) lv.SubItems.Add("");
                        }
                    }
                    if (lvEq.Items.Count > 0) for (int r = 0; r < _Rws; r++) for (int c = 1; c < _Cols; c++) lvEq.Items[r].SubItems[c].Text = _arr_lectures[r, c];
                    else MessageBox.Show("Error in Charger status Rows=0....");
                    break;
                case "Alarms":
                    if (lvAlarms.Items.Count == 0)
                    {
                        for (int r = 0; r < _Rws; r++)
                        {
                            ListViewItem lv = lvAlarms.Items.Add(_arr_lectures[r, 0]);
                            for (int c = 0; c < _Cols; c++) lv.SubItems.Add("");
                        }
                    }
                    if (lvAlarms.Items.Count > 0) for (int r = 0; r < _Rws; r++) for (int c = 1; c < _Cols; c++) lvAlarms.Items[r].SubItems[c].Text = _arr_lectures[r, c];
                    else MessageBox.Show("Error in Charger status Rows=0....");
                    break;
                default:
                    Current_GRPndx = Current_GRPndx;
                    break;

            }

        }



        //send line to appropriate table
        private void fill_GrpParam(string _hdr, string _line)
        {
            MessageBox.Show("Hdr= " + _hdr + "\n\n Line= " + _line);
            switch (_hdr)
            {
                case "Charger Status":
                    init_tablesNM(_hdr);
                    for (int r = 0; r < R_ChargerStatus_Rws; r++)
                    {
                        int iposD = _line.IndexOf(R_ChargerStatus[r, 0]);
                        if (iposD != -1)
                        {
                            iposD += R_ChargerStatus[r, 0].Length + 1;
                            int iposF = _line.IndexOf("||", iposD);
                            string _PLine = _line.Substring(iposD, iposF + 3 - iposD);
                            string[] arr_Val = new string[R_ChargerStatus_Cols - 1];
                            //    arr_Val = Find_Sub_Param (R_ChargerStatus[r, 0], _PLine , R_ChargerStatus_Cols - 1);
                            arr_Val = Find_Sub_Param(_PLine, R_ChargerStatus_Cols - 1);
                            for (int c = 1; c < R_ChargerStatus_Cols; c++)
                                R_ChargerStatus[r, c] = arr_Val[c - 1];
                        }

                    }
                    MessageBox.Show("Charger Status....processed !!! ");
                    break;
                case "Output":
                    MessageBox.Show("Output....");
                    break;
                case "Reference":
                    MessageBox.Show("Reference....");
                    break;
            }
        }

        private string[] Find_Sub_Param(string _stLine, int _Cols)
        {

            string[] res = new string[_Cols];
            int c = 0, debV = 0;

            for (c = 0; c < _Cols; c++) res[c] = " ";

            int iposD = _stLine.IndexOf("~~");
            if (iposD != -1)
            {
                for (c = 0; c < _Cols; c++)
                {
                    debV = iposD + 2;
                    int iposF = _stLine.IndexOf("~~", debV);
                    if (iposF != -1)
                    {
                        // debV = (c == 0) ? iposD + _ParmNm.Length + 3 : iposD + 2;
                        res[c] = _stLine.Substring(debV, iposF - debV);
                        _stLine = _stLine.Substring(iposF, _stLine.Length - iposF);
                        iposD = iposF;
                    }
                    else
                    {
                        iposF = _stLine.IndexOf("||");
                        if (iposF != -1)
                        {
                            res[c] = _stLine.Substring(debV, iposF - debV);
                            // _stLine = _stLine.Substring(iposF, _stLine.Length - iposF);
                            _stLine = "";
                        }
                        else
                        {
                            res[c] = "";
                            c = _Cols;
                        }
                    }
                }

            }

            return res;
        }



        private void disp_arr(string[] arr_st)
        {
            int l = 0;
            string stOut = "";
            while (arr_st[l] != "")
            {
                stOut += "\nl=" + l + "..." + arr_st[l];
                //if ((l % 40) == 0) { MessageBox.Show(stOut); stOut = ""; }
                l++;
            }
            if (l < 40) MessageBox.Show(stOut);
        }




        //read stream, read line, extract line by line and send it fill appropriate table 


        private void fill_ChargerStatus(string [] arr_st)
        {

            

            int l = 0;
            string stOut = "";
            while (arr_st[l] != "")
            {
                stOut += "\nl=" + l + "..." + arr_st[l];
                //if ((l % 40) == 0) { MessageBox.Show(stOut); stOut = ""; }
                l++;
            }
            if (l < 40) MessageBox.Show(stOut);
        }

        private string[] div_Lines(string _st)
        {
            string[] arr_st = new string[500];
            for (int l = 0; l < 500; l++)
                arr_st[l] = "";
            int _idx = 0;
            while (true)
            {
                int ipos = _st.IndexOf("]]]");
                if (ipos == -1)
                {
                    arr_st[_idx] = _st;
                    break;
                }
                else
                {
                    arr_st[_idx] = _st.Substring(0, ipos + 3);
                    _st = _st.Substring(ipos + 3, _st.Length - ipos - 3);

                }
                arr_st[_idx] = arr_st[_idx].Replace("\r", " ").TrimStart();
                if (_st.Length == 0) break;
                _idx++;
            }
            return arr_st;
        }


        private string send_URL(string _Qstr)
        {
            string _excep = "";
            string _page = GetPage(_Qstr, _excep);
            if (_page == null) MessageBox.Show("setting.....Charger not responding......please Check your connection....");

            return _page;

        }





        public static string GetPage(string url, string _Excep)
        {
            _Excep = null;
            WebResponse response = null;
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                response = request.GetResponse();

                stream = response.GetResponseStream();

                if (!response.ContentType.ToLower().StartsWith("text/"))
                    return null;

                string buffer = "", line;

                reader = new StreamReader(stream);

                while ((line = reader.ReadLine()) != null)
                {
                    buffer += line + "\r\n";
                }

                return buffer;
            }
            catch (WebException _ex)
            {
                _Excep = "WEB Excdeption:\n" + _ex;
                //  MessageBox.Show ( + _ex);
                return null;
            }
            catch (IOException _ioex)
            {
                _Excep = "IOException:\n" + _ioex;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (stream != null)
                    stream.Close();

                if (response != null)
                    response.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DispAllTag (thtml.Text  );
        }

        private void txChargerIP_DoubleClick(object sender, EventArgs e)
        {
            txChargerIP.ReadOnly = false;
        }


        private string StripHTML(string source)
        {

            try
            {

                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space

                result = source.Replace("\r", " ");
                result = result.Replace("\0", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating speces becuase browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result, 
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty, 
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything thats enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testng
                //System.Text.RegularExpressions.Regex.Replace(result, 
                //       this.txtRegex.Text,string.Empty, 
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4. 
                // Prepare first to remove any whitespaces inbetween
                // the escaped characters and remove redundant tabs inbetween linebreaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multible tabs followind a linebreak with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for linebreaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // Thats it.
                return result;

            }
            catch
            {
                MessageBox.Show("Error");
                return source;
            }
        }




        private string HAK_htmlParse(string source)
        {

            try
            {

                string result;
                //no <b>
                result = source.Replace("\r", " ");
                result = result.Replace("\0", " ");

                result = result.Replace("\n", " ");
                result = result.Replace("\t", string.Empty);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // No header 
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // NO scripts 
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // No styles 
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //ede adding {
                result = System.Text.RegularExpressions.Regex.Replace(result,
         "<TABLE", " [[[ <",
         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //"</TABLE", " ]]] < ",
                result = System.Text.RegularExpressions.Regex.Replace(result,
"</TABLE", " || ]]] < ",
System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //ede adding }

                // OLD rplc <td> by tabs
                //result = System.Text.RegularExpressions.Regex.Replace(result, @"<( )*td([^>])*>", "\t", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // rplc <td> by "~"
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", " ~~ ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // // rplc <BR> and <LI>  by "\t" 
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Rplc <P>, <DIV> by "\r\r"
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Rplc <TR> by "\r\n||"
                //old ===> result = System.Text.RegularExpressions.Regex.Replace(result,@"<( )*tr([^>])*>", "\r\r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", " || ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // NO <a>, links, images, comments etc and, all inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // No special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Rplc "\r" by "\n"
                result = result.Replace("\n", "\r");

                // NO extra "\r" and "\t":
                // Rplc many "\t" by "\t\t" , many "\r" by "\r\r". 
                // No whitespaces 
                // No escaped char , No redundant "\t" inbetween "\r"
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multible tabs followind a linebreak with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for linebreaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // Thats it.
                return result;

            }
            catch
            {
                MessageBox.Show("Error");
                return source;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void WriteTo_ASCIIFile(string[] arr_st, string FileNm)
        {
            StreamWriter fout;

            // open output file 
            try
            {
                // fout = new FileStream(FileNm, FileMode.Create);
                fout = new StreamWriter(FileNm);
            }
            catch (IOException IOex)
            {
                Console.WriteLine(IOex.Message + "\nError Opening tmp_file");
                return;
            }

            // Write the alphabet to the file. 
            try
            {
                for (int r = 0; r < MAX_arrHtml; r++)
                {
                    if (arr_Html[r].Length > 0) fout.WriteLine(arr_Html[r].Replace("\r", " "));
                    else r = MAX_arrHtml;
                }
            }
            catch (IOException IOex)
            {
                Console.WriteLine(IOex.Message + "\n Error Writing tmp_file");
            }

            fout.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string stOut = "";
            //  IPAddress[] a = Dns.GetHostByName(Dns.GetHostName()).AddressList;


            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            stOut += "hostname= " + ipEntry.HostName.ToString();
            if (ipEntry.Aliases.Length > 0)
            {
                stOut += "\n Aliases: \n";
                foreach (string st in ipEntry.Aliases) stOut += "  als=" + st + "  ";
            }
            stOut += "\n";
            IPAddress[] a = ipEntry.AddressList;

            for (int i = 0; i < a.Length; i++)
                stOut += i + "= " + a[i].ToString();
            MessageBox.Show(stOut);


            IPAddress test3 = IPAddress.Broadcast;
            MessageBox.Show("Broadcast address:" + test3.ToString());



        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //how to use an external dos command and capture its results
            Process proc = new Process();
            proc.StartInfo.FileName = "net.exe";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.Arguments = "view";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();

            StreamReader sr = new StreamReader(proc.StandardOutput.BaseStream);
            string line = "";
            List<string> names = new List<string>();

            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith(@"\\"))
                    names.Add(line.Substring(2).TrimEnd());
            }

            sr.Close();
            proc.WaitForExit();

            foreach (string name in names)
            {
                MessageBox.Show("Nm: " + name);
            }


        }
        

    }
}