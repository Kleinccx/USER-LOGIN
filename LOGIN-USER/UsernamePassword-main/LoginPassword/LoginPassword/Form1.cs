using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {


            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\LOGIN-PASSWORD-USING-MENU-STRIP-main\\UsernamePassword-main\\LoginPassword\\LoginPassword\\Password.mdb";
          
            string username = Usertxt.Text;
            string password = Passwordtxt.Text;

            bool loginSuccessful = false;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand("SELECT * FROM [thePassword]", connection);

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string storedUsername = reader.GetString(0);
                    string storedPassword = reader.GetString(1);

                    if (username == storedUsername && password == storedPassword)
                    {
                        loginSuccessful = true;
                        break;
                    }
                }
            }
            // Display a message box indicating whether the login was successful
            if (loginSuccessful)
            {
                MessageBox.Show("Login successful.");
                this.Hide();
                Menuform frm = new Menuform();
                frm.ShowDialog();
               
                
                
            }
            else
            {
                MessageBox.Show("Invalid username or password.");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            user.ShowDialog();
        }
    }
}

