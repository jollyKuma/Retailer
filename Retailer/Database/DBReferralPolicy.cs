using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace Retailer.Database
{
    class DBReferralPolicy
    {
        private static string tablename = "referral_policy";
        private int id, level;
        private double amount;
        private string details;
//===================SETTER/GETTER=====================
        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public double Amount
        {
            set { amount  = value; }
            get { return amount; }
        }

        public int Level
        {
            set { level = value; }
            get { return level; }
        }
        public string Details
        {
            set { details = value; }
            get { return details; }
        }
//===================CONSTRUCTOR==============
        public DBReferralPolicy() { }

        public DBReferralPolicy(int id, double amount, int level, string details)
        {
            this.id = id;
            this.amount = amount;
            this.level = level;
            this.details = details;
        }
//==================GETDATA METHOD FOR DATAGRIDVIEW=====================
        public static List<DBReferralPolicy> GetData()
        { 
            List<DBReferralPolicy> data = new List<DBReferralPolicy>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            DBReferralPolicy rp = new DBReferralPolicy();

            string sqlDataGrid = "SELECT * FROM referral_policy";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBReferralPolicy rawData = new DBReferralPolicy();

                        rawData.ID = reader.GetInt32(0);
                        rawData.Amount = reader.GetDouble(1);
                        rawData.Level = reader.GetInt32(2);
                        rawData.Details = reader.GetString(3);

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
//=======================GET DATA ID ============================
        public static DBReferralPolicy GetDataId(int id)
        {
            DBReferralPolicy data = null;

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename + " WHERE id=" + id, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    reader.Read();

                    data = new DBReferralPolicy();
                    data.id = reader.GetInt32(0);
                    data.Amount = reader.GetDouble(1);
                    data.Level = reader.GetInt32(2);
                    data.Details = reader.GetString(3);
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
//==================================METHODS=============================
        //-------------> ADD METHOD
        public void Add()
        {
            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlAdd = "INSERT INTO referral_policy(amount,level,details)VALUES('"+amount+"','"+level+"','"+details+"')";
             MySqlCommand cmd = new MySqlCommand(sqlAdd, con);
            try
            {
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                MessageBox.Show("Saved Data");

                while (reader.Read())
                {


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex+"");

            }

            con.Close();

        }
        //------------------------>UPDATE METHOD
        public void Update()
        {

            string sqlUpdate = "UPDATE " + tablename + " SET amount = @amount, level= @level, details = @details WHERE id =@id";
            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.Parameters.AddWithValue("@amount",this.Amount);
                cmd.Parameters.AddWithValue("@level", this.Level);
                cmd.Parameters.AddWithValue("@details", this.Details);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Updated");
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
        //=======================DELETE METHOD===================
        public void Delete()
        {
            MySqlConnection con = DBConnection.ConnectDatabase();
            string command = "DELETE FROM " + tablename + " WHERE id =@id";

            try
            {
                MySqlCommand cmd = new MySqlCommand(command, con);
                cmd.Parameters.AddWithValue("@id", this.ID);
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
