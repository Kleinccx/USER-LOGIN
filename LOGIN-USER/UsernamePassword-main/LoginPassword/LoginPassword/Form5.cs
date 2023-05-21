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

namespace LoginPassword
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\LOGIN-PASSWORD-USING-MENU-STRIP-main\\UsernamePassword-main\\LoginPassword\\LoginPassword\\Password.mdb";
            OleDbConnection connection = new OleDbConnection(con);

            string Username = User.Text;
            string Password = Pass.Text;

            string insert = "INSERT INTO thePassword (username, [password]) VALUES (?, ?)";
            OleDbCommand command = new OleDbCommand(insert, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            User.Clear();
            Pass.Clear();
            MessageBox.Show("Added successfully!");
            this.Hide();
        }

        private void User_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
