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
            myConnectionString = "server=127.0.0.1;Port=3306;uid=root;pwd='';database=openemr";
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

        public Person getPerson(string ID)
        {
            Person p = new Person();
            MySql.Data.MySqlClient.MySqlDataReader mySQLReader = null;

            String sqlString = "SELECT lname, fname, DOB, sex from openemr.patient_data WHERE pubpid ="+ID;
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);

            mySQLReader = cmd.ExecuteReader();
            if (mySQLReader.Read())
            {
                p.ID = ID;
                p.FirstName = mySQLReader.GetString(0);
                p.LastName = mySQLReader.GetString(1);
                p.StartDate = mySQLReader.GetDateTime(2);

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