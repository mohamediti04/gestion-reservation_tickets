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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = Connexion.Connect();
                SqlCommand sqlCommande;
                sqlCommande = new SqlCommand();
                sqlCommande.Connection = sqlConnection;

                //int id = Int32.Parse(textBox1.Text);
                string nom = textBox2.Text;
                string login = textBox3.Text;
                string password = textBox4.Text;
                
                int profile = Int32.Parse(comboBox1.SelectedValue.ToString());

               // MessageBox.Show("Data = nom" + nom + "login=" + login + "password=" + password + "Profile = " + profile);
                string query = @"insert into t_user values('"+nom+"','"+login+"','"+password+"',"+profile+")";
                            sqlCommande.CommandText = query;
                            sqlCommande.ExecuteNonQuery();
 
                            sqlConnection.Close();
            }catch(Exception ex){
                    MessageBox.Show(ex.ToString());
                   // Console.WriteLine(e.ToString());
            }

        }
        private void loadProfileNameList()
        {
            try
            {
                SqlConnection sqlConnection = Connexion.Connect();
                SqlCommand sqlCommande;
                sqlCommande = new SqlCommand();
                sqlCommande.Connection = sqlConnection;

                SqlDataAdapter da = new SqlDataAdapter("SELECT id,type FROM t_profile", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "type";
                comboBox1.ValueMember = "id";
               
            }catch(Exception exp){
                MessageBox.Show(exp.ToString());

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadProfileNameList();
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
