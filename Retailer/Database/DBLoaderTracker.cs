using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace Retailer.Database
{
    class DBLoaderTracker
    {
        private static string tablename ="loadtracker";

        private int id;
        private string walletid, paidthru, trackingNo, status, comment;
        private double amount;
        private string dateTime;

//===============  Setters/Getters ====================================

        public int Id
        {
            set { id = value;  }
            get { return id;   }
        }

        public string WalletId
        {
            set { walletid = value;  }
            get { return walletid; }
        }
        
        public double Amount
        {
            set { amount = value; }
            get { return amount; }
        }

        public string Paidthru
        {
            set { paidthru = value; }
            get { return paidthru; }
        }

        public string TrackingNo
        {
            set { trackingNo = value; }
            get { return trackingNo; }
        }

        public string Status
        {
            set { status = value; }
            get { return status; }
        }

        public string Comment
        {
            set { comment = value; }
            get { return comment; }
        }

        public string LTDateTime
        {
            set { dateTime = value ; }
            get { return dateTime; }
        }

//==============Constructors ======================

        public DBLoaderTracker() { }

        public DBLoaderTracker(int id, string walletid, double amount, string paidthru, string trackingNo, string status, string comment, string dateTime)
        {
            this.id          = id;
            this.walletid    = walletid;
            this.amount      = amount;
            this.paidthru    = paidthru;
            this.trackingNo  = trackingNo;
            this.status      = status;
            this.comment     = comment;
            this.dateTime    = dateTime;
        }
//========================GET DATA FOR DATAGRIDVIEW===========================
        public static List<DBLoaderTracker> GetData()
        {
            List<DBLoaderTracker> data = new List<DBLoaderTracker>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlDataGrid = "SELECT * FROM loadtracker";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBLoaderTracker rawData = new DBLoaderTracker();
                        rawData.Id= reader.GetInt32(0);
                        rawData.WalletId = reader.GetString(1);
                        rawData.Amount = reader.GetDouble(2);
                        rawData.Paidthru = reader.GetString(3);
                        rawData.TrackingNo = reader.GetString(4);
                        rawData.Status= reader.GetString(5);
                        rawData.Comment = reader.GetString(6);
                        rawData.LTDateTime = reader.GetString(7);
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
        public static List<DBLoaderTracker> GetDataLoadTracker( string findLoadTracker)
        {
            List<DBLoaderTracker> data = new List<DBLoaderTracker>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlDataGrid = "SELECT * FROM " + tablename + " WHERE id LIKE '%" + findLoadTracker + "%'" + "OR walletid LIKE '" + findLoadTracker + "%'" + "OR amount LIKE '" + findLoadTracker + "%'" + "OR paidthru LIKE '" + findLoadTracker + "%'" + "OR trackingNo LIKE '" + findLoadTracker + "%'" + "OR status LIKE '" + findLoadTracker + "%'" + "OR comment LIKE '" + findLoadTracker + "%'" + "OR dateTime LIKE '" + findLoadTracker + "%'";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBLoaderTracker rawData = new DBLoaderTracker();
                        rawData.Id = reader.GetInt32(0);
                        rawData.WalletId = reader.GetString(1);
                        rawData.Amount = reader.GetDouble(2);
                        rawData.Paidthru = reader.GetString(3);
                        rawData.TrackingNo = reader.GetString(4);
                        rawData.Status = reader.GetString(5);
                        rawData.Comment = reader.GetString(6);
                        rawData.LTDateTime = reader.GetString(7);
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
  
//=======================GET DATA ID LOAD TRACKER ======================================
        public static DBLoaderTracker GetDataID(int id)
        {
            DBLoaderTracker data = null;

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename + " WHERE id=" + id, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    reader.Read();

                    data = new DBLoaderTracker();
                    data.Id = reader.GetInt32(0);
                    data.WalletId= reader.GetString(1);
                    data.Amount = reader.GetDouble(2);
                    data.Paidthru = reader.GetString(3);
                    data.trackingNo = reader.GetString(4);
                    data.Status = reader.GetString(5);
                    data.Comment= reader.GetString(6);
                    data.LTDateTime = reader.GetString(7);
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
    



//===================== METHODS ==========================
 
        //-------> ADD METHOD
        public void Add()
        {
            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlAdd = "INSERT INTO loadtracker(walletid,amount,paidthru,trackingNo, status,comment,dateTime) VALUES('" + walletid + "','" + amount + "','" + paidthru + "','" + trackingNo + "','" + status + "','" + comment + "','" + dateTime + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlAdd, con);

                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                MessageBox.Show("Saved Data");

                while (reader.Read())
                {


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(walletid + " Does not exist");

            }

            con.Close();
        }
        //--------------> UPDATE METHOD
        public void Update()
        {

            string cmdText = "UPDATE " + tablename + " SET walletid = @walletid, amount = @amount,paidthru = @paidthru,trackingNo = @trackingNo,status = @status,comment = @comment,dateTime = @dateTime WHERE id =@id";
            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@walletid", this.WalletId);
                cmd.Parameters.AddWithValue("@amount", this.Amount);
                cmd.Parameters.AddWithValue("@paidthru", this.Paidthru);
                cmd.Parameters.AddWithValue("@trackingNo", this.TrackingNo);
                cmd.Parameters.AddWithValue("@status", this.Status);
                cmd.Parameters.AddWithValue("@comment", this.Comment);
                cmd.Parameters.AddWithValue("@dateTime", this.LTDateTime);

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
    //------------------------->DELETE METHOD
        public void Delete()
        {
            MySqlConnection con = DBConnection.ConnectDatabase();
            string command = "DELETE FROM " + tablename + " WHERE id =@id";

            try
            {
                MySqlCommand cmd = new MySqlCommand(command, con);
                cmd.Parameters.AddWithValue("@id", this.Id);
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
        public void Delete(int id)
        {
            MySqlConnection con = DBConnection.ConnectDatabase();
            string command = "DELETE FROM " + tablename + " WHERE id=@id";

            try
            {
                MySqlCommand cmd = new MySqlCommand(command, con);
                cmd.Parameters.AddWithValue("@id", id);
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

    }
}
