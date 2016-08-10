using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Retailer.Database
{
    class DBProvince
    {
        private static string tablename = "provinces";
        private int id;
        private string name;

        public int Id 
        {
            get { return id; }
            set { id = value; }

        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public static List<DBProvince> GetData()
        {
            List<DBProvince> data = new List<DBProvince>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBProvince rawData = new DBProvince();
                        rawData.Id = reader.GetInt32(0);
                        //string sdate = reader.GetString(1).ToString();
                        //DateTime dddate = DateTime.Parse(sdate);
                        // rawData.Date = dddate;
                        rawData.Name = reader.GetString(1);
                        // rawData.Message = reader.GetString(3);
                        //rawData.Sent = reader.GetString(4);

                        data.Add(rawData);
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return data;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return this.Name;
        }


    }
}
