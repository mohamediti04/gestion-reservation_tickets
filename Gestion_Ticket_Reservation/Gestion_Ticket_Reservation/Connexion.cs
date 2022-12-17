using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_Ticket_Reservation
{
    class Connexion
    {
       

       public static SqlConnection  Connect()
       {
           SqlConnection con = null;
           try
           {
                con = new SqlConnection();
               con.ConnectionString = "server=DESKTOP-P71D8UA\\SQLEXPRESS;database=db_reservation;integrated security=true";
               con.Open();
              // MessageBox.Show("Connexion Status = "+con.State.ToString());
              
           }
           catch (SqlException e)
           {
               Console.WriteLine(e.ToString());
           }

           return con;

       }
    }

}
