using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Retailer.Database
{
    class DBTicketing
    {
        public static string tablename = "tblticketing";

        private int id;
        string user_key, website, philo_id, user_id, password;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string User_key
        {
            set { user_key = value; }
            get { return user_key; }
        }

        public string Website
        {
            set { website = value; }
            get { return website; }
        }

        public string Philo_Id
        {
            set { philo_id = value; }
            get { return philo_id; }
        }

        public string User_Id
        {
            set { user_id = value; }
            get { return user_id; }
        }

        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public DBTicketing() { }

        public DBTicketing(int id, string user_key, string website, string philo_id, string user_id, string password)
        {
            this.Id = id;
            this.User_key = user_key;
            this.Website = website;
            this.Philo_Id = philo_id;
            this.User_Id = user_id;
            this.Password = password;
        }

        public void GetDatabyWalletId(string walletid)
        { 
        MySqlConnection con = DBConnection.ConnectDatabase();
           try{
               string sql = "SELECT * FROM " + tablename + " WHERE user_key LIKE '%" + walletid + "%'";
 MySqlCommand cmd = new MySqlCommand(sql,con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Id = reader.GetInt32(0);
                        User_key = reader.GetString(1);
                        Website = reader.GetString(2);
                        Philo_Id = reader.GetString(3);
                        User_Id = reader.GetString(4);
                        Password = reader.GetString(5);
                        Debug.WriteLine(Id +"tHIS IS THE ID"); 
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
        }

        
    }
}
