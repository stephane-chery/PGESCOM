using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class P600_New : Form
    {
        P600_New_SQLController P600SQLController = new P600_New_SQLController();
        P600_New_Controller P600Controller = new P600_New_Controller();
        P850UI_UPS_INV_New_SQL_Controller P850SQLController = new P850UI_UPS_INV_New_SQL_Controller(); //some functions are the same 
        private string errorMessage = "Une erreur est survenue! Si cela persite, veuillez communiquer à un technicien.";
        Dictionary<string, object> inputCurrentparameters = new Dictionary<string, object>();

        public P600_New()
        {
            InitializeComponent();
            loadDataAsync();

            //fill default input
            input_PH1.Text = "3";

            frequency.SelectedIndex = 1;
            ambiant_temp.Text = "50";
            //VdcComboBox.SelectedIndex = 4;
            Fcb1.Text = "1.35";
            Fcb2.Text = "1.2";
            Fcb3.Text = "1.25";
            F_Battery.Text = "1.2";
            loadInputCurrentParams();


            //maximization of the form
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        public void loadInputCurrentParams ()
        {
            try
            {
                // Clear the dictionary in case it already contains values
                inputCurrentparameters.Clear();

                int transformerInstalled = 0; //default value; 

                if (transformer_yes.Checked )
                {
                    transformerInstalled = 1;
                } else
                {
                    transformerInstalled = 0;
                }

                // Add new values
                inputCurrentparameters["vdcMin"] = Vdc_min.Text;
                inputCurrentparameters["txfefficiency"] = txf_efficiency.Text;
                inputCurrentparameters["modEfficiency"] = mod_efficiency.Text;
                inputCurrentparameters["powerOutput"] = Power_output.Text;
                inputCurrentparameters["phase"] = input_PH1.Text;
                inputCurrentparameters["transformerInstalled"] = transformerInstalled;

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async void loadDataAsync()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                //await P850SQLController.getVacValues(VacComboBox, input_PH1.Text); //default phase to 3
                await P600SQLController.getVacValues(VacComboBox, input_PH1.Text);
                await P600SQLController.getVdcValues(VdcComboBox);
            } catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                MessageBox.Show(errorMessage);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MainMDI.Confirm("Are you sure you want to cancel ? All unsaved progress will be lost."))
            {
                this.Dispose();
            }
        }

        //P600 charger Validation
        private void btn_validate_Click(object sender, EventArgs e)
        {
            //implement stored procedure to make the insert faster
            if (P600Controller.validateInput(T_Battery.Text, Ah_Battery.Text, kA_battery.Text, input_PH1.Text))
            {
                string validationId = Guid.NewGuid().ToString();
                string InputDetails = $"{input_Vac.Text}Vac - {input_PH1.Text}P - {mi_test.Text}A";
                string P600Model = $"{P600_model.Text}"; //Modular Industrial Battery Charger

                P600SQLController.insertIntoP600ValidationQuery(validationId, "Modular Industrial Battery Charger : ", P600Model, "", "", "", "", "");
                P600SQLController.insertIntoP600ValidationQuery(validationId, "Input : ", InputDetails, "1", "1.50", "100", "100", "");

                P850SQLController.fill_listview("1.50", listViewP600, validationId);
            } else
            {
                MessageBox.Show("Please fill in all fields.");
            }

        }

        private void save_input_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save input");
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Save soumission");
        }

        private void VacComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            input_Vac.Text = VacComboBox.Text;
            Vcb1.Text = VacComboBox.Text;
        }

        private async void input_PH1_TextChanged(object sender, EventArgs e)
        {
            P600Controller.InputVerification(input_PH1);

            if (P600Controller.inputPhaseVerification(input_PH1))
            {
                await P600SQLController.getVacValues(VacComboBox, input_PH1.Text);
                PHcb1.Text = input_PH1.Text;
                P600Controller.ModuleInputCalcul(input_PH1, NP_Yes, module_input, input_Vac);
                P600Controller.GenerateP600Model(input_PH1, VdcComboBox, P600_model);
            }
        }

        private async void reset_button_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is System.Windows.Forms.TextBox)
                        (control as System.Windows.Forms.TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);

            //reinitialize
            await P600SQLController.getVacValues(VacComboBox, "3");
        }

        private void NP_No_CheckedChanged(object sender, EventArgs e)
        {
            if (NP_No.Checked)
            {
                NP_Yes.Checked = false;
                module_input.Text = "";
                neutral_present.Text = "0";
            } else
            { 
                NP_Yes.Checked = true;
            }
        }

        private void NP_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (NP_Yes.Checked)
            {
                NP_No.Checked = false;
                P600Controller.ModuleInputCalcul(input_PH1, NP_Yes, module_input, input_Vac);
                neutral_present.Text = "1";
            }
            else
            {
                NP_No.Checked = true;
            }
        }

        private void VdcComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            P600SQLController.getVdcMaxAndVdcMin(VdcComboBox, Vdc_max, Vdc_min, cellNumber);
            P600Controller.GenerateP600Model(input_PH1, VdcComboBox, P600_model);

            //Vcb2 = Vdc_charger 
            Vcb2.Text = VdcComboBox.Text;
            Vcb3.Text = VdcComboBox.Text;
        }

        private void input_Vac_TextChanged(object sender, EventArgs e)
        {
            P600Controller.ModuleInputCalcul(input_PH1, NP_Yes, module_input, input_Vac);
        }

        private void T_Battery_TextChanged(object sender, EventArgs e)
        {
            P600Controller.InputVerification(T_Battery);
            P600Controller.IBatteryCalculs(T_Battery, I_battery, Ah_Battery, kA_battery,F_Battery);
        }

        private void Ah_Battery_TextChanged(object sender, EventArgs e)
        {
            P600Controller.InputVerification(Ah_Battery);
            P600Controller.IBatteryCalculs(T_Battery, I_battery, Ah_Battery, kA_battery, F_Battery);

        }

        private void kA_battery_TextChanged(object sender, EventArgs e)
        {
            P600Controller.InputVerification(kA_battery);
            P600Controller.IBatteryCalculs(T_Battery, I_battery, Ah_Battery, kA_battery, F_Battery);
        }

        private void F_Battery_TextChanged(object sender, EventArgs e)
        {
            P600Controller.InputVerification(F_Battery);
            P600Controller.IBatteryCalculs(T_Battery, I_battery, Ah_Battery, kA_battery, F_Battery);

        }

        private async void I_battery_TextChanged(object sender, EventArgs e)
        {
            await P600SQLController.IcbLookupP600(Double.Parse(I_battery.Text), "1", Idc_charger);
        }

        private void Idc_charger_TextChanged(object sender, EventArgs e)
        {
            P600Controller.PowerOutCalculs(Vdc_max.Text, Idc_charger.Text, Power_output);
            Icb3.Text = Idc_charger.Text;
        }

        private void Vdc_max_TextChanged(object sender, EventArgs e)
        {
            P600Controller.PowerOutCalculs(Vdc_max.Text, Idc_charger.Text, Power_output);
        }

        private void txf_efficiency_TextChanged(object sender, EventArgs e)
        {
            loadInputCurrentParams();
            P600Controller.InputCurrentCalculs(input_current, inputCurrentparameters);
        }

        private void mod_efficiency_TextChanged(object sender, EventArgs e)
        {
            loadInputCurrentParams();
            P600Controller.InputCurrentCalculs(input_current, inputCurrentparameters);
        }

        private void Power_output_TextChanged(object sender, EventArgs e)
        {
            loadInputCurrentParams();
            P600Controller.InputCurrentCalculs(input_current, inputCurrentparameters);
        }

        private void input_current_TextChanged(object sender, EventArgs e)
        {
            Icb1.Text = Math.Round(Double.Parse(input_current.Text)*1.1, 0).ToString();
        }

        private void transformer_yes_CheckedChanged(object sender, EventArgs e)
        {
            loadInputCurrentParams();
            P600Controller.InputCurrentCalculs(input_current, inputCurrentparameters);
        }

    }
}
