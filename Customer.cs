using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerWindows
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            if (!String.IsNullOrEmpty(nameTextBox.Text))
            {
                string commandString = @"INSERT INTO Customer(Customer_Name, Customer_address) Values ('" + nameTextBox.Text + "', +'" +addressTextBox.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("add");

                }
                else
                {
                    MessageBox.Show("Not Add");
                }

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Please Enter Name and Address");
                return;
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            string commandString = @"SELECT * FROM Customer";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                showDataGridView.DataSource = null;
                MessageBox.Show("Data not Found!");
            }



            sqlConnection.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            if (!String.IsNullOrEmpty(idTextBox.Text))
            {
                string commandString = @"DELETE FROM Customer WHERE ID =" + idTextBox.Text + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Delete");
                }
                else
                {
                    MessageBox.Show("Not Delete");
                }

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Please Enter Id");
                return;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            if (!String.IsNullOrEmpty(idTextBox.Text))
            {
                string commandString = @"UPDATE Customer SET Customer_Name = '"+nameTextBox.Text+"' ,Customer_address = '"+addressTextBox.Text+"' WHERE ID = "+idTextBox.Text+"";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Update");
                }
                else
                {
                    MessageBox.Show("Not Update");
                }

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Inter  ID");
                return;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=CustomerInfo; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            if (!String.IsNullOrEmpty(addressTextBox.Text))
            {
                string commandString = @"SELECT Customer_Name, Customer_address FROM Customer WHERE Customer_address ='"+addressTextBox.Text+"'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    showDataGridView.DataSource = null;
                    MessageBox.Show("Data not Found!");
                }

                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Inter Address");
                return;
            }
        }
    }
}
