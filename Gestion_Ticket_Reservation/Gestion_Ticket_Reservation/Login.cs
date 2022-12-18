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

namespace Gestion_Ticket_Reservation
{
   
    public partial class Login : Form
    {
        public static String chauffeur = null;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = Connexion.Connect();
               
                string login = textBox3.Text;
                string password = textBox4.Text;



                string selectquery = "SELECT * FROM t_user where login = '" + login + "' and password='" + password + "' and profile=1";
                SqlCommand sqlCommand = new SqlCommand(selectquery, sqlConnection);
                SqlDataReader reader1;
                reader1 = sqlCommand.ExecuteReader();
                if (reader1.Read())
                {

                    /*string loginUser = reader1.GetValue(2).ToString();
                    string passwordUser = reader1.GetValue(3).ToString();
                    int profileUser = Convert.ToInt32(reader1.GetValue(4).ToString());
                    MessageBox.Show("Login = " + loginUser + ",Password =" + passwordUser + ",Profile = " + profileUser);*/
                    chauffeur = login;
                    MessageBox.Show("chauffeur : " + chauffeur);
                    new Ticket().Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("You should have an account");
                    new Form1().Show();
                    this.Hide();
                }
                sqlConnection.Close();
               

            }
            catch (SqlException expSql)
            {
                MessageBox.Show(expSql.ToString());
                Console.WriteLine(expSql.ToString());

            }catch(Exception exp){
                 MessageBox.Show(exp.ToString());
            }

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

      
    }
}
