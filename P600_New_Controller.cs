using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PGESCOM
{
    internal class P600_New_Controller
    {
        //verify if a letter or any other character than a number was inserted in a textbox which is supposed to receive a number
        //P600_New P600View = new P600_New();

        public void InputVerification(System.Windows.Forms.TextBox input)
        {
            if (input.Text.Length == 1)
            {
                if (input.Text == ".")
                {
                    MessageBox.Show("Please insert a number first");
                    input.Text = input.Text.Remove(input.Text.Length - 1);
                }
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(input.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter a number.");
                input.Text = input.Text.Remove(input.Text.Length - 1);
            }
        }


        //verify if input phase is either 1 or 3 
        public bool inputPhaseVerification(System.Windows.Forms.TextBox input)
        {
            bool verif = false;
            if (input.Text !=  "")
            {
                if (input.Text == "1" || input.Text == "3")
                {
                    verif = true;
                }
                else
                {
                    MessageBox.Show("the phase can only be 1 or 3");
                    input.Text = input.Text.Remove(input.Text.Length - 1);
                }
            }


            return verif;
        }

        public void ModuleInputCalcul(TextBox input_PH1, CheckBox NP_Yes, TextBox input_module, TextBox input_Vac)
        {
            //=IF(AND(input_Phase=3,Neutral_Present=Yes),B21/SQRT(3),B21)
            if (input_PH1.Text != "" && input_Vac.Text != "" && NP_Yes.Checked)
            {
                if (input_PH1.Text == "3" && NP_Yes.Checked)
                {
                    input_module.Text = Math.Round(Double.Parse(input_Vac.Text) / Math.Sqrt(3), 2).ToString();
                } else
                {
                    input_module.Text = input_Vac.Text;
                }
            }
        }

        public void GenerateP600Model(TextBox input_PH1, ComboBox input_Vdc, Label P600_model) //TextBox Idc_charger
        {
            if (input_PH1.Text != "" && input_Vdc.Text != "")
            {
                P600_model.Text = $"P600-{input_PH1.Text}-{input_Vdc.Text}";
            } else
            {
                P600_model.Text = "";
            }

        }

        //charger rating ( P600 sizing 2022 excel file reference ) 
        public void IBatteryCalculs(TextBox T_Battery, TextBox I_battery, TextBox Ah_Battery, TextBox kA_battery, TextBox F_battery)
        {
            try
            {
                //T_battery : temps de recharge 
                if (!string.IsNullOrWhiteSpace(T_Battery.Text) &&
                    !string.IsNullOrWhiteSpace(Ah_Battery.Text) &&
                    !string.IsNullOrWhiteSpace(kA_battery.Text) &&
                    !string.IsNullOrWhiteSpace(F_battery.Text)
                    )
                {

                    double ah = Double.Parse(Ah_Battery.Text);
                    double f_bat = Double.Parse(F_battery.Text);
                    double t_bat = Double.Parse(T_Battery.Text);
                    double ka = Double.Parse(kA_battery.Text);

                    //ensure that t_bat can't be equal to zero ( Division by Zero) 
                    if (t_bat == 0)
                    {
                        MessageBox.Show("Le temps de recharge de la batterie ne peut pas être zéro");
                    }

                    double result = (ah * f_bat / t_bat) + ka;

                    I_battery.Text = Math.Round(result, 2).ToString();
                }
                else
                {
                    I_battery.Clear();
                }

            } catch ( Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        //verify if all input have a value before validating 
        public bool validateInput(String T_Battery, String AH_Battery, String KA_Battery, String input_PH1)
        {
            // Check if any input is null or empty
            if (string.IsNullOrWhiteSpace(T_Battery) ||
                string.IsNullOrWhiteSpace(AH_Battery) ||
                string.IsNullOrWhiteSpace(KA_Battery) ||
                string.IsNullOrWhiteSpace(input_PH1)
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PowerOutCalculs(string VdcMax, string Idc, TextBox PowerOutput)
            {
                try
                {
                    if (!string.IsNullOrEmpty(VdcMax) && !string.IsNullOrEmpty(Idc))
                    {
                        double VdcMaxDouble = double.Parse(VdcMax);
                        double IdcDouble = double.Parse(Idc);
                        double result = VdcMaxDouble * IdcDouble;
                        PowerOutput.Text = result.ToString();
                    }
                } catch(Exception ex )
                {
                    Console.WriteLine(ex.Message);
                }
            }

        public void InputCurrentCalculs(TextBox InputCurrent, Dictionary<string, object> parameters)
        {
            try
            {
                // Safely extract parameters
                double vdcMin = Convert.ToDouble(parameters["vdcMin"]);
                double txfEfficiency = Convert.ToDouble(parameters["txfefficiency"]);
                double modEfficiency = Convert.ToDouble(parameters["modEfficiency"]);
                double powerOutput = Convert.ToDouble(parameters["powerOutput"]);
                double phase = Convert.ToDouble(parameters["phase"]);
                double transformerInstalled = Convert.ToDouble(parameters["transformerInstalled"]); // values 0 or 1 

                double result = 0.0;

                if (transformerInstalled == 1)
                {
                    result = powerOutput/vdcMin/Math.Sqrt(phase)/modEfficiency/txfEfficiency;
                } else
                {
                    result = powerOutput / vdcMin / Math.Sqrt(phase) / modEfficiency;
                }
                InputCurrent.Text = Math.Round(result,2).ToString();
            } 
            catch (KeyNotFoundException e)
            {
                Console.WriteLine($"Missing parameter: {e.Message}");
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine($"Invalid parameter type: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
