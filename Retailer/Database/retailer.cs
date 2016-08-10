using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Retailer.Database
{
    class Retailer
    {
        private static string tablename = "retailers";

        private string  walletid, fname, lname, birthdate, address, province, city, sponsor_id, email, password;
        private double balance, frozen;
        private decimal share;
        private int type;
        private DateTime date;



        // --------------Setter/Getter for Date-----------------
        public DateTime Date
        {
            set
            {
                date = value;
            }
            get
            {
                return date;
            }
        }
        //-----------------Setter/Getter for Walletid-------------

        public string Walletid
        {
            set
            {
                walletid = value;
            }
            get
            {
                return walletid;
            }
        }
        //-----------------Setter/Getter for fname-------------
        public string Fname
        {
            set
            {
                fname = value;
            }
            get
            {
                return fname;
            }
        }
        //-----------------Setter/Getter for Lname-------------
        public string Lname
        {
            set
            {
                lname = value;
            }
            get
            {
                return lname;
            }
        }
        //-----------------Setter/Getter for Birthdate-------------
        public string Birthdate
        {
            set
            {
                birthdate = value;
            }
            get
            {
                return birthdate;
            }
        }
        //-----------------Setter/Getter for Address-------------
        public string Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }
        }
        //-----------------Setter/Getter for Province-------------
        public string Province
        {
            set
            {
                province = value;
            }
            get
            {
                return province;
            }
        }
        //-----------------Setter/Getter for City-------------
        public string City
        {
            set
            {
                city = value;
            }
            get
            {
                return city;
            }
        }

        //-----------------Setter/Getter for Balance-------------
        public double Balance
        {
            set
            {
                balance = value;
            }
            get
            {
                return balance;
            }
        }
        //-----------------Setter/Getter for Frozen-------------
        public double Frozen
        {
            set
            {
                frozen = value;
            }
            get
            {
                return frozen;
            }
        }
        //-----------------Setter/Getter for Sponsor_id-------------
        public string Sponsor_id
        {
            set
            {
                sponsor_id = value;
            }
            get
            {
                return sponsor_id;
            }
        }

        //-----------------Setter/Getter for Share-------------
        public decimal Share
        {
            set
            {
                share = value;
            }
            get
            {
                return share;
            }
        }
        //-----------------Setter/Getter for Email-------------
        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }

        //-----------------Setter/Getter for Password-------------
        public string Password
        {
            set
            {
                password = "12345";
            }
            get
            {
                return password;
            }
        }
        //-----------------Setter/Getter for Type-------------
        public int Type
        {
            set
            {
                type = 0;
            }
            get
            {
                return type;
            }
        }

        //----------------------CONSTRUCTORS-----------------------
        public Retailer() { }

        public Retailer(string walletid, DateTime date, string fname, string lname,
            string birthdate, string address, string province, string city, double balance,
            double frozen, string sponsor_id, decimal share, string email, string password, int type)
        {
            this.date = date;
            this.walletid = walletid;
            this.fname = fname;
            this.lname = lname;
            this.birthdate = birthdate;
            this.address = address;
            this.province = province;
            this.city = city;
            this.balance = balance;
            this.frozen = frozen;
            this.sponsor_id = sponsor_id;
            this.share = share;
            this.email = email;
            this.password = password;
            this.type = type;
        }





        //==========================================
        //         ADD METHOD/ INSERT SQL          |
        //==========================================

        public void Add()
        {
            MySqlConnection con = DBConnection.ConnectDatabase();
            string sqlAdd = "INSERT INTO retailers(date, walletid,fname,lname,birthdate, address,province,city,balance,frozen,sponsor_id,share,email,password,type)VALUES('" + date.ToString("u")+"','" + walletid + "','" + fname + "','" + lname + "','" + birthdate + "','" + address + "','" + province + "','" + city + "','" + balance + "','" + frozen + "','" + sponsor_id + "','" + share + "','" + email + "','" + password + "','" + type + "')";
            MySqlCommand cmd = new MySqlCommand(sqlAdd, con);
            MessageBox.Show(walletid);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            MessageBox.Show("Saved Data");

            while (reader.Read())
            {


            }

            con.Close();
        }
        //=============================================================
        //                   EDIT FUNCTION                            |
        //=============================================================
        public void Update()
        {

            string cmdText = "UPDATE " + tablename + " SET  date = @date,fname = @fname,lname =@lname,birthdate = @birthdate,address = @address,province = @province,city = @city,balance = @balance, frozen = @frozen,sponsor_id = @sponsor_id,share = @share,email = @email,password = @password,type = @type WHERE walletid =@walletid";
            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@date", this.date);
                cmd.Parameters.AddWithValue("@walletid", this.Walletid);
                cmd.Parameters.AddWithValue("@fname", this.Fname);
                cmd.Parameters.AddWithValue("@lname", this.Lname);
                cmd.Parameters.AddWithValue("@birthdate", this.Birthdate);
                cmd.Parameters.AddWithValue("@address", this.Address);
                cmd.Parameters.AddWithValue("@province", this.Province);
                cmd.Parameters.AddWithValue("@city", this.City);
                cmd.Parameters.AddWithValue("@balance", this.Balance);
                cmd.Parameters.AddWithValue("@frozen", this.Frozen);
                cmd.Parameters.AddWithValue("@sponsor_id", this.Sponsor_id);
                cmd.Parameters.AddWithValue("@share", this.Share);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@password", this.Password);
                cmd.Parameters.AddWithValue("@type", this.Type);

               

                cmd.ExecuteNonQuery(); //execute the mysql command

                MessageBox.Show("Successfully Updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //============================================================
        //                      GET DATA FOR DATAGRIDVIEW            |
        //===========================================================
        public static List<Retailer> GetData()
        {
            List<Retailer> data = new List<Retailer>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlDataGrid = "SELECT * FROM retailers";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retailer rawData = new Retailer();
                        rawData.Date = reader.GetDateTime(0);
                        rawData.Walletid = reader.GetString(1);
                        rawData.Fname = reader.GetString(2);
                        rawData.Lname = reader.GetString(3);
                        rawData.Birthdate = reader.GetString(4);
                        rawData.Address = reader.GetString(5);
                        rawData.Province = reader.GetString(6);
                        rawData.City = reader.GetString(7);
                        rawData.Balance = reader.GetDouble(8);
                        rawData.Frozen = reader.GetDouble(9);
                        rawData.Sponsor_id = reader.GetString(10);
                        rawData.Share = reader.GetDecimal(11);
                        rawData.Email = reader.GetString(12);
                        rawData.Password = reader.GetString(13);
                        rawData.Type = reader.GetInt32(14);
                        data.Add(rawData);
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return data;
        }

        public static List<Retailer> GetDataWalletid()
        {
            List<Retailer> data = new List<Retailer>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Retailer rawData = new Retailer();
                        rawData.Walletid = reader.GetString(1);

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
            return this.Walletid;
        }
//===========================================================================
//                          DELETE DATA                                     |
//===========================================================================
        public void Delete()
        {
            MySqlConnection con = DBConnection.ConnectDatabase();
            string command = "DELETE FROM " + tablename + " WHERE walletid =@walletid";

            try
            {
                MySqlCommand cmd = new MySqlCommand(command, con);
                cmd.Parameters.AddWithValue("@walletid", this.Walletid);
                Debug.WriteLine("You DELETE---=====================");

                cmd.ExecuteNonQuery(); //execute the mysql command

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(string walletid)
        {
            MySqlConnection con = DBConnection.ConnectDatabase();
            string command = "DELETE FROM " + tablename + " WHERE walletid=@walletid";

            try
            {
                MySqlCommand cmd = new MySqlCommand(command, con);
                cmd.Parameters.AddWithValue("@walletid", walletid);
                Debug.WriteLine("You DELETE---=====================");
                cmd.ExecuteNonQuery(); //execute the mysql command

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

//============================================================================
//                          Get Data ID                                      |
//============================================================================
        public static Retailer GetDataID(string id)
        {
            Retailer data = null;

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename + " WHERE walletid=" + id, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    reader.Read();

                    data = new Retailer();
                    data.Date = reader.GetDateTime(0);
                    data.Walletid = reader.GetString(1);
                    data.Fname = reader.GetString(2);
                    data.Lname = reader.GetString(3);
                    data.Birthdate = reader.GetString(4);
                    data.Address = reader.GetString(5);
                    data.Province = reader.GetString(6);
                    data.City = reader.GetString(7);
                    data.Balance = reader.GetDouble(8);
                    data.Frozen = reader.GetDouble(9);
                    data.Sponsor_id = reader.GetString(10);
                    data.Share = reader.GetDecimal(11);
                    data.Email = reader.GetString(12);
                    data.Password = reader.GetString(13);
                    data.Type = reader.GetInt32(14);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return data;

        }
        //------------------------->SEARCH RETAILER
        public static List<Retailer> GetDataRetailer(string findRetailer)
        {
            List<Retailer> data = new List<Retailer>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            try 
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM "+ tablename + " WHERE walletid LIKE '%" + findRetailer + "%'" + " OR fname LIKE '" + findRetailer + "%'" + "OR lname LIKE '" + findRetailer + "%'", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retailer rawData = new Retailer();
                        rawData.Date = reader.GetDateTime(0);
                        rawData.Walletid = reader.GetString(1);
                        rawData.Fname = reader.GetString(2);
                        rawData.Lname = reader.GetString(3);
                        rawData.Birthdate = reader.GetString(4);
                        rawData.Address = reader.GetString(5);
                        rawData.Province = reader.GetString(6);
                        rawData.City = reader.GetString(7);
                        rawData.Balance = reader.GetDouble(8);
                        rawData.Frozen = reader.GetDouble(9);
                        rawData.Sponsor_id = reader.GetString(10);
                        rawData.Share = reader.GetDecimal(11);
                        rawData.Email = reader.GetString(12);
                        rawData.Password = reader.GetString(13);
                        rawData.Type = reader.GetInt32(14);
                        data.Add(rawData);
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


            return data;
        }

//-------------------------->SEARCH BYDATE
        public static List<Retailer> GetDataByDate(DateTime past, DateTime present)
        {
            List<Retailer> data = new List<Retailer>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename + " WHERE date BETWEEN '" + past.ToString("yyyy-MM-dd") + " 0:0:0" + "' AND '" + present.ToString("yyyy-MM-dd") + " 23:59:59" + "' ORDER BY walletid DESC", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Retailer rawData = new Retailer();
                        rawData.Date = reader.GetDateTime(0);
                        rawData.Walletid = reader.GetString(1);
                        rawData.Fname = reader.GetString(2);
                        rawData.Lname = reader.GetString(3);
                        rawData.Birthdate = reader.GetString(4);
                        rawData.Address = reader.GetString(5);
                        rawData.Province = reader.GetString(6);
                        rawData.City = reader.GetString(7);
                        rawData.Balance = reader.GetDouble(8);
                        rawData.Frozen = reader.GetDouble(9);
                        rawData.Sponsor_id = reader.GetString(10);
                        rawData.Share = reader.GetDecimal(11);
                        rawData.Email = reader.GetString(12);
                        rawData.Password = reader.GetString(13);
                        rawData.Type = reader.GetInt32(14);
                        data.Add(rawData);
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return data;
        }

    }
}
