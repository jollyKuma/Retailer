using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Retailer.Database
{
    class DBReferral_Mlm
    {
        private static string tblReferralBonus   = "referral_mlm_bonus";
        private static string tblReferralHistory = "referral_mlm_bonus_history";
        private static string tblReferralPending = "referral_mlm_bonus_pending";
    
        private int id, payout_id, bonus_status, level, req_id;
        private string  parent_id, child_id;
        private double amount;
        private DateTime date_notified;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public DateTime Date_Notified
        {
            set { date_notified = value; }
            get { return date_notified; }
        }

        public string Parent_id
        {
            set { parent_id = value; }
            get { return parent_id; }
        }

        public string Child_id
        {
            set { child_id = value; }
            get { return child_id; }
        }

        public double Amount
        {
            set { amount = value; }
            get { return amount; }
        }

        public int Payout_id
        {
            set { payout_id = value; }
            get { return payout_id; }
        }

        public int Bonus_status
        {
            set { bonus_status = value; }
            get { return bonus_status; }
        }

        public int Level
        {
            set { level = value; }
            get { return level; }
        }

        public int Req_id
        {
            set { req_id = value; }
            get { return req_id; }

        }

        public DBReferral_Mlm() { }

        public DBReferral_Mlm(int id, DateTime date_notified, string parent_id, string child_id, double amount, int payout_id, int bonus_status, int level, int req_id) 
        {
            this.id = id;
            this.date_notified = date_notified;
            this.parent_id = parent_id;
            this.child_id = child_id;
            this.amount = amount;
            this.payout_id = payout_id;
            this.bonus_status = bonus_status;
            this.level = level;
            this.req_id = req_id;
        }
        //-------------------------> GET DATA IN MLM <-----------------------
        public static List<DBReferral_Mlm> GetDataMlm(string walletid) 
        {
            List<DBReferral_Mlm> data = new List<DBReferral_Mlm>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            DBReferral_Mlm dm = new DBReferral_Mlm();
            string sqlDataGrid = "SELECT * FROM "+ tblReferralBonus +" WHERE parent_id LIKE '%" + walletid + "%'";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBReferral_Mlm rawData = new DBReferral_Mlm();
                        rawData.Id = reader.GetInt32(0);
                        rawData.Date_Notified = reader.GetDateTime(1);
                        rawData.Parent_id = reader.GetString(2);
                        rawData.Child_id = reader.GetString(3);
                        rawData.Amount = reader.GetDouble(4);
                        rawData.Payout_id = reader.GetInt32(5);
                        rawData.Bonus_status = reader.GetInt32(6);
                        rawData.Level = reader.GetInt32(7);

                        data.Add(rawData);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
            finally
            {
                con.Close();
            }
            return data;
        }

        //------------------------> GET DATA IN HISTORY <---------------------
        public static List<DBReferral_Mlm> GetDataHistory(string walletid)
        {

            List<DBReferral_Mlm> data = new List<DBReferral_Mlm>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            DBReferral_Mlm dm = new DBReferral_Mlm();

            string sqlDataGrid = "SELECT * FROM " + tblReferralHistory + " WHERE parent_id LIKE '%" + walletid + "%'";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBReferral_Mlm rawData = new DBReferral_Mlm();
                        rawData.Id = reader.GetInt32(0);
                        rawData.Date_Notified = reader.GetDateTime(1);
                        rawData.Parent_id = reader.GetString(2);
                        rawData.Child_id = reader.GetString(3);
                        rawData.Amount = reader.GetDouble(4);
                        rawData.Payout_id = reader.GetInt32(5);
                        rawData.Bonus_status = reader.GetInt32(6);
                        rawData.Level = reader.GetInt32(7);
                        rawData.Req_id = reader.GetInt32(8);
                        data.Add(rawData);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
            finally
            {
                con.Close();
            }
            return data;
        
        }
        //---------------------------------> GET DATA IN PENDING <----------------------
        public static List<DBReferral_Mlm> GetDataPending(string walletid)
        {
            List<DBReferral_Mlm> data = new List<DBReferral_Mlm>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            DBReferral_Mlm dp = new DBReferral_Mlm();

            string sqlDataGrid = "SELECT * FROM " + tblReferralPending + " WHERE parent_id LIKE '%" + walletid + "%'";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBReferral_Mlm rawData = new DBReferral_Mlm();
                        rawData.Id = reader.GetInt32(0);
                        rawData.Date_Notified = reader.GetDateTime(1);
                        rawData.Parent_id = reader.GetString(2);
                        rawData.Child_id = reader.GetString(3);
                        rawData.Amount = reader.GetDouble(4);
                        rawData.Payout_id = reader.GetInt32(5);
                        rawData.Bonus_status = reader.GetInt32(6);
                        rawData.Level = reader.GetInt32(7);

                        data.Add(rawData);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
            finally
            {
                con.Close();
            }
            return data;
        }
        //------------------------------GET DATA IN MLM BY DATE <------------------------


        public static List<DBReferral_Mlm> GetDataByMlmDate(DateTime past, DateTime present)
        {

            List<DBReferral_Mlm> data = new List<DBReferral_Mlm>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tblReferralBonus + " WHERE date_notified BETWEEN '" + past.ToString("yyyy-MM-dd") + " 0:0:0" + "' AND '" + present.ToString("yyyy-MM-dd") + " 23:59:59" + "' ORDER BY id DESC", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBReferral_Mlm rawData = new DBReferral_Mlm();
                        rawData.Id = reader.GetInt32(0);
                        rawData.Date_Notified = reader.GetDateTime(1);
                        rawData.Parent_id = reader.GetString(2);
                        rawData.Child_id = reader.GetString(3);
                        rawData.Amount = reader.GetDouble(4);
                        rawData.Payout_id = reader.GetInt32(5);
                        rawData.Bonus_status= reader.GetInt32(6);
                        rawData.Level = reader.GetInt32(7);
                   
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
        //------------------------------GET DATA IN HISTORY BY DATE <------------------------


        public static List<DBReferral_Mlm> GetDataByHistoryDate(DateTime past, DateTime present)
        {

            List<DBReferral_Mlm> data = new List<DBReferral_Mlm>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tblReferralHistory + " WHERE date_notified BETWEEN '" + past.ToString("yyyy-MM-dd") + " 0:0:0" + "' AND '" + present.ToString("yyyy-MM-dd") + " 23:59:59" + "' ORDER BY id DESC", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBReferral_Mlm rawData = new DBReferral_Mlm();
                        rawData.Id = reader.GetInt32(0);
                        rawData.Date_Notified = reader.GetDateTime(1);
                        rawData.Parent_id = reader.GetString(2);
                        rawData.Child_id = reader.GetString(3);
                        rawData.Amount = reader.GetDouble(4);
                        rawData.Payout_id = reader.GetInt32(5);
                        rawData.Bonus_status = reader.GetInt32(6);
                        rawData.Level = reader.GetInt32(7);
                        rawData.Req_id = reader.GetInt32(8);

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
        //------------------------------GET DATA IN Pending BY DATE <------------------------


        public static List<DBReferral_Mlm> GetDataByPendingDate(DateTime past, DateTime present)
        {

            List<DBReferral_Mlm> data = new List<DBReferral_Mlm>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tblReferralPending + " WHERE date_notified BETWEEN '" + past.ToString("yyyy-MM-dd") + " 0:0:0" + "' AND '" + present.ToString("yyyy-MM-dd") + " 23:59:59" + "' ORDER BY id DESC", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBReferral_Mlm rawData = new DBReferral_Mlm();
                        rawData.Id = reader.GetInt32(0);
                        rawData.Date_Notified = reader.GetDateTime(1);
                        rawData.Parent_id = reader.GetString(2);
                        rawData.Child_id = reader.GetString(3);
                        rawData.Amount = reader.GetDouble(4);
                        rawData.Payout_id = reader.GetInt32(5);
                        rawData.Bonus_status = reader.GetInt32(6);
                        rawData.Level = reader.GetInt32(7);

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
