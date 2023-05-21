using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginPassword
{
    public partial class Userform : Form
    {
        public Userform()
        {
            InitializeComponent();
            loadDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadDataGrid()
        {

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\LOGIN-PASSWORD-USING-MENU-STRIP-main\\UsernamePassword-main\\LoginPassword\\LoginPassword\\Password.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            connection.Open();
            string run = "SELECT * FROM thePassword";
            OleDbCommand com = new OleDbCommand(run, connection);
            OleDbDataAdapter adap = new OleDbDataAdapter(com);
            DataTable table = new DataTable();
            adap.Fill(table);
            DisplayData.DataSource = table;

            DisplayData.Columns["Username"].HeaderText = "Username";
            DisplayData.Columns["Username"].DataPropertyName = "Username";
            DisplayData.Columns["Password"].HeaderText = "Password";
            DisplayData.Columns["Password"].DataPropertyName = "Password";

            connection.Close();

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            AddUser frm5 = new AddUser();
            frm5.ShowDialog();


        }


        private void ViewData()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\LOGIN-PASSWORD-USING-MENU-STRIP-main\\UsernamePassword-main\\LoginPassword\\LoginPassword\\Password.mdb";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM thePassword";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DisplayData.DataSource = dataTable;
            }
        }
        private void DeleteRow()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\LOGIN-PASSWORD-USING-MENU-STRIP-main\\UsernamePassword-main\\LoginPassword\\LoginPassword\\Password.mdb";
            if (DisplayData.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DisplayData.SelectedRows[0];
                int id = (int)selectedRow.Cells["ID"].Value;

           
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();
                string commandText = "DELETE FROM thePassword WHERE ID=@ID";
                MessageBox.Show("Deleted Successfully!");
                OleDbCommand command = new OleDbCommand(commandText, connection);
                command.Parameters.AddWithValue("@ID", id);
              
                command.ExecuteNonQuery();
                connection.Close();

                DisplayData.Rows.Remove(selectedRow);
            }
        }

            private void Viewbtn_Click(object sender, EventArgs e)
        {
            ViewData();

        }

        private void Delbtn_Click(object sender, EventArgs e)
        {
            DeleteRow();

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
        }
    
    
