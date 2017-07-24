using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleRESTServer.Models;
using MySql.Data;


namespace SimpleRESTServer
{
    public class PersonPersistance
    {

        private MySql.Data.MySqlClient.MySqlConnection conn;

        public PersonPersistance()
        {

            string myConnectionString;
            myConnectionString = "server=127.0.0.1:3306;database=openemr";
            try
            {

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();



            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {


            }
        }

        public Person getPerson(long ID)
        {
            Person p = new Person();
            MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

            String sqlString = "SELECT pubpid AS pid, lname, fname, DOB from openemr.patient_data";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySQLReader = cmd.ExecuteReader();
            if (mySQLReader.Read())
            {
                p.ID = mySQLReader.GetInt32(0);
                p.FirstName = mySQLReader.GetString(1);
                p.LastName = mySQLReader.GetString(2);
                p.StartDate = mySQLReader.GetDateTime(3);

                return p;
                


            }
            else
            {
                return null;
            }






        }

        public long savePerson(PersonPersistance pers)
        {

            String sqlString = "";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;


        }


    }

}