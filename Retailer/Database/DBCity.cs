using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Retailer.Database
{
    class DBCity
    {
        private static string tablename = "cities";
        private int id;
        private string name;
        private int prov_id;

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
        public int ProvId 
        {
            get { return prov_id; }
            set { prov_id = value;}
        }
        public static List<DBCity> GetDataByProvice(int idx)
        {
            List<DBCity> data = new List<DBCity>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename + " WHERE province_id=" + idx, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBCity rawData = new DBCity();
                        rawData.Id = reader.GetInt32(0);
                        rawData.Name = reader.GetString(1);
                        rawData.ProvId = reader.GetInt32(2);
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
