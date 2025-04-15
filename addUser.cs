using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PGESCOM.Passwd;

namespace PGESCOM
{
    public partial class addUser : Form
    {
        public bool normalUser;
        public static bool superUser;
        private static string usernameText = "";
        private static string passwordText = "";
        private static string FullName = "";
        private static string mykey = "primax";


        public static object _username { get; private set; }

        public addUser()
        {
            InitializeComponent();
            //initialize normal radio button at true
        }

        //username reference
        private void username_TextChanged(object sender, EventArgs e)
        {
            usernameText = username.Text;
        }

        //super user checked
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }
            //Ensure that the RadioButton.Checked property
            //changed to true.
            if (rb.Checked)
            {

                //Keep track of the selected RadioButton by saving a reference
                //to it.
                superUser = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            passwordText = password.Text;
        }

        private void fullName_TextChanged(object sender, EventArgs e)
        {
            FullName = fullName.Text; 
        }

        //normal user checked
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }
            //Ensure that the RadioButton.Checked property
            //changed to true.
            if (rb.Checked)
            {
                //Keep track of the selected RadioButton by saving a reference
                //to it.
                normalUser = true;
            }
        }

        //return the last user added in the table
        //created this method since the userID doesn't auto increment 
        public static (string, string) getLastUserAdded()
        {
            string userID = "";
            string U_IPport = "";

            string stSql = "SELECT TOP 1 * FROM PSM_users_New ORDER BY userID DESC";

            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    userID = Oreadr["userID"].ToString(); 
                    U_IPport = Oreadr["U_IPport"].ToString();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            return (userID, U_IPport);
        }

        //verify if User already exists in the databse 
        public static bool userExist(string user)
        {
            bool userInDatabase = false;

            string stSql = "SELECT * FROM PSM_USERS_New WHERE [user] = @user";

            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@user", user);
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    Console.WriteLine(Oreadr["userID"].ToString());
                    if (Oreadr["userID"].ToString() != "") userInDatabase = true;
                }
            } 
            catch(Exception error)
            {
                Console.WriteLine(error);
            }
            return userInDatabase;
        }

        //add user in database 
        public static bool addUserInDatabase()
        {
            bool success = false;
            bool userAlreadyExist = userExist(usernameText);
            Console.WriteLine(userAlreadyExist);
            if (userAlreadyExist != true)   
            {
                Console.WriteLine();
                (string, string) userID_AND_UIPport = ("", "");
                userID_AND_UIPport = getLastUserAdded();

                //user id and U_IPport
                int userID = Int32.Parse(userID_AND_UIPport.Item1) + 1;
                int UIPport = Int32.Parse(userID_AND_UIPport.Item2) + 1;

                //password encryption 
                string EncryptedPassword = StringCipher.Encrypt(passwordText, mykey);

                string type = "N";

                if (superUser == true) type = "S";
                //bool userExist = userExist(username.Text);
                string stSql = "SET IDENTITY_INSERT PSM_users_New ON INSERT INTO PSM_users_New (userID, [user], user_pass, type, inuse, FullName, U_IPport, email) VALUES (@userID, @user, @user_pass, @type, @inuse, @FullName, @U_IPport, @email)";

                try
                {
                    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                    OConn.Open();
                    SqlCommand Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSql;
                    Ocmd.Parameters.AddWithValue("@userID", userID);
                    Ocmd.Parameters.AddWithValue("@user", usernameText);
                    Ocmd.Parameters.AddWithValue("@user_pass", EncryptedPassword);
                    Ocmd.Parameters.AddWithValue("@type", type);
                    Ocmd.Parameters.AddWithValue("@inuse", "0");
                    Ocmd.Parameters.AddWithValue("@FullName", FullName);
                    Ocmd.Parameters.AddWithValue("@U_IPport", UIPport);
                    Ocmd.Parameters.AddWithValue("@email", "");

                    SqlDataReader Oreadr = Ocmd.ExecuteReader();
                    success = true;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
            } 
            else MessageBox.Show("This user already exist");
            return success;
        }

        //add user button
        private void addUser_Click(object sender, EventArgs e)
        {
            if (passwordText != "" | FullName != "" | usernameText != "")
            {
                bool addUserConfirm = addUserInDatabase();

                if (addUserConfirm == true)
                {
                    MessageBox.Show("The user was successfully added");
                    this.Close();
                    this.Dispose();
                }
                else MessageBox.Show("Something went wrong, Please contact your admin...");
            } 
            else MessageBox.Show("Veuillez remplir tous les champs...");
        }
    }
}