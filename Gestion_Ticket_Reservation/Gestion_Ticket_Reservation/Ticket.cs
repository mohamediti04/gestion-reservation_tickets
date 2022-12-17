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
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            loadAllTickets();
            loadStationArriveNameList();
            loadStationDepartNameList();
            loadUserAsPassagersNameList();
            if (Login.chauffeur != null)
            {
                connectedUser.Text = Login.chauffeur;
            }
            else
            {
                connectedUser.Text ="1";
            }

        }
        private void loadStationArriveNameList()
        {
            try
            {
                SqlConnection sqlConnection = Connexion.Connect();
                SqlCommand sqlCommande;
                sqlCommande = new SqlCommand();
                sqlCommande.Connection = sqlConnection;

                SqlDataAdapter da = new SqlDataAdapter("SELECT id,nom FROM t_station", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox4.DataSource = dt;
                comboBox4.DisplayMember = "nom";
                comboBox4.ValueMember = "id";




            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }
        }
        private void loadStationDepartNameList()
        {
            try
            {
                SqlConnection sqlConnection = Connexion.Connect();
                SqlCommand sqlCommande;
                sqlCommande = new SqlCommand();
                sqlCommande.Connection = sqlConnection;

                SqlDataAdapter da = new SqlDataAdapter("SELECT id,nom FROM t_station", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
               

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "nom";
                comboBox2.ValueMember = "id";



            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }
        }
        private void loadUserAsPassagersNameList()
        {
            try
            {
                SqlConnection sqlConnection = Connexion.Connect();
                SqlCommand sqlCommande;
                sqlCommande = new SqlCommand();
                sqlCommande.Connection = sqlConnection;

                SqlDataAdapter da = new SqlDataAdapter("SELECT id,nom FROM t_user", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "nom";
                comboBox3.ValueMember = "id";

                



            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }
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
                int passager = Int32.Parse(comboBox3.SelectedValue.ToString());
                int stationDepart = Int32.Parse(comboBox2.SelectedValue.ToString());
                int stationArrive = Int32.Parse(comboBox4.SelectedValue.ToString());
                double prix = Double.Parse(textBox2.Text);
               string dateVoyage = dateTimePicker1.Value.ToString("yyyy-MM-dd");





               MessageBox.Show("Data = passager" + passager + "stationDepart=" + stationDepart + "stationArrive=" + stationArrive + "prix = " + prix + "dateVoyage" + dateVoyage);
               string query = @"insert into t_ticket values(" + int.Parse("1") + "," + passager + ",CAST('" + dateVoyage + "' as date)," + stationDepart + "," + stationArrive + "," + prix + ")";
              
                sqlCommande.CommandText = query;
                sqlCommande.ExecuteNonQuery();

                sqlConnection.Close();
                loadAllTickets();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                // Console.WriteLine(e.ToString());
            }
        }

        private void loadAllTickets()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            SqlConnection sqlConnection = Connexion.Connect();
            string selectquery = "SELECT * FROM t_ticket";
            SqlCommand sqlCommand = new SqlCommand(selectquery, sqlConnection);


            using (SqlDataReader read = sqlCommand.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] { 
            read.GetValue(read.GetOrdinal("id")),  // Or column name like this
            read.GetValue(read.GetOrdinal("chauffeur")),
            read.GetValue(read.GetOrdinal("passager")),
              read.GetValue(read.GetOrdinal("date")),
                read.GetValue(read.GetOrdinal("station_depart")),
                  read.GetValue(read.GetOrdinal("station_arrive")),
                    read.GetValue(read.GetOrdinal("prix"))

            });
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
             

              try
            {
                SqlConnection sqlConnection = Connexion.Connect();
                SqlCommand sqlCommande;
                sqlCommande = new SqlCommand();
                sqlCommande.Connection = sqlConnection;
                string query = @"delete from t_ticket where id=" + Convert.ToInt32(textBoxId.Text); ;
                    sqlCommande.CommandText = query;
                    sqlCommande.ExecuteNonQuery();
                    loadAllTickets();
              



            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }
        }
    }
}
