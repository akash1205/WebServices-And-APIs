using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mail;

namespace PolicceREST.Models
{
    public class PersonPersistence
    {

        MySqlConnection con;
        public PersonPersistence()
        {
            
            string myConnectionString;
            myConnectionString = "server=br-cdbr-azure-south-b.cloudapp.net;user id=baf8ce7e917901;database=restwebservice;password=83efb267";
            try {
            con = new MySqlConnection(myConnectionString);
            con.Open();
            }
            catch(MySqlException ex)
            {

            }
        }

        public Person getPerson(long id)
        {
            Person p = new Person();
            MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM PERSON WHERE ID = "+id.ToString();
            MySqlCommand cmd = new MySqlCommand(sqlString, con);
            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                p.ID = mySqlReader.GetInt64(0);
                p.FirstName = mySqlReader.GetString(1);
                p.LastName = mySqlReader.GetString(2);
                p.CriminalRecords = mySqlReader.GetInt32(3);
                p.DrivingTickets = mySqlReader.GetInt32(4);
                return p;
                con.Close();
            }
            con.Close();
            return null;
        }

       
    }
}