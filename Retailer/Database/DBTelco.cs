using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Retailer.Database
{
    class DBTelco
    {
        private static string tablename = "telco";
        private string dbtelconame;

        public string DBtelconame
        {
            set { dbtelconame = value; }
            get { return dbtelconame; }
        }
        public static List<DBTelco> GetData()
        {
            List<DBTelco> data = new List<DBTelco>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBTelco rawData = new DBTelco();
                        rawData.DBtelconame = reader.GetString(0);

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
            return this.DBtelconame;
        }

    }
}
