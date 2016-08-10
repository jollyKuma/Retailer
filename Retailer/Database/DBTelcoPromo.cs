using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace Retailer.Database
{
    class DBTelcoPromo
    {
        private static string tablename = "telcopromo";

        private int id, baseamount;
        private string telconame, pattern, telcokeyword, gateway, userkeyword;
        private static string ctelconame;
        private float deduction;

//===========================SETTER/GETTER==================================
        public int ID 
        {
            set { id = value; }
            get { return id; }
        }

        public string TelcoName
        {
            set { telconame = value; }
            get { return telconame; }
        }

        public string Pattern
        {
            set { pattern = value; }
            get { return pattern; }
        }

        public int BaseAmount
        {
            set { baseamount = value; }
            get { return baseamount; }
        }

        public string TelcoKeyword
        {
            set { telcokeyword = value; }
            get { return telcokeyword; }
        }

        public string Gateway
        {
            set { gateway = value; }
            get { return gateway; }
        }

        public float Deduction
        {
            set { deduction = value; }
            get { return deduction; }
        }
        public string UserKeyword
        {
            set { userkeyword = value; }
            get { return userkeyword; }
        }

        public string CTelconame 
        {
            set { ctelconame = value; }
            get { return ctelconame; }
        }

//=========================CONSTRUCTORS ===================================
        public DBTelcoPromo() { }

        public DBTelcoPromo(int id, string telconame, string pattern, int baseamount, string telcokeyword, string gateway, float deduction, string userkeyword,string ctelconame)
        {
            this.id           = id;
            this.telconame    = telconame;
            this.pattern      = pattern;
            this.baseamount   = baseamount;
            this.telcokeyword = telcokeyword;
            this.gateway      = gateway;
            this.deduction    = deduction;
            this.userkeyword  = userkeyword;
        }
//=====================GET DATA FOR DATAGRIDVIEW ============================
        public static List<DBTelcoPromo>GetData()
        {
            List<DBTelcoPromo> data = new List<DBTelcoPromo>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            DBTelcoPromo t = new DBTelcoPromo();
            string sqlDataGrid;

            if (t.CTelconame == "ALL" || t.CTelconame == null)
            {
                sqlDataGrid = "SELECT * FROM telcopromo";
            }
            else
            {
                sqlDataGrid = "SELECT * FROM telcopromo WHERE telconame = " + "'" + ctelconame + "'";
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBTelcoPromo rawData = new DBTelcoPromo();
                        rawData.ID        = reader.GetInt32(0);
                        rawData.TelcoName = reader.GetString(1);
                        rawData.Pattern   = reader.GetString(2);
                        rawData.BaseAmount= reader.GetInt32(3);
                        rawData.TelcoKeyword = reader.GetString(4);
                        rawData.Gateway= reader.GetString(5);
                        rawData.Deduction= reader.GetFloat(6);
                        rawData.UserKeyword = reader.GetString(7);
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
//=============================GET DATA ID FOR TELCO PROMO========================
        public static DBTelcoPromo GetDataID(int id)
        {
            DBTelcoPromo data = null;

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename + " WHERE id=" + id, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    reader.Read();

                    data = new DBTelcoPromo();
                    data.ID = reader.GetInt32(0);
                    data.TelcoName = reader.GetString(1);
                    data.Pattern = reader.GetString(2);
                    data.BaseAmount = reader.GetInt32(3);
                    data.TelcoKeyword = reader.GetString(4);
                    data.Gateway = reader.GetString(5);
                    data.Deduction = reader.GetFloat(6);
                    data.UserKeyword = reader.GetString(7);
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
//===================================METHODS======================
        //------------> ADD METHOD
        public void Add() 
        {
            MySqlConnection con = DBConnection.ConnectDatabase();


            string sqlAdd = "INSERT INTO telcopromo(telconame,pattern,baseamount, telcokeyword,gateway,deduction,userkeyword) VALUES('" + telconame + "','" + pattern + "','" + baseamount + "','" + telcokeyword + "','" + gateway + "','" + deduction + "','" + userkeyword + "')";
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
                MessageBox.Show(ex+"");

            }

            con.Close();
        }
        //----------------------->UPDATE METHOD
        public void Update()
        {
            string cmdText = "UPDATE " + tablename + " SET telconame = @telconame, pattern = @pattern,baseamount = @baseamount,telcokeyword = @telcokeyword,gateway = @gateway,deduction = @deduction,userkeyword = @userkeyword WHERE id =@id";
            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@id", this.ID);
                cmd.Parameters.AddWithValue("@telconame", this.TelcoName);
                cmd.Parameters.AddWithValue("@pattern", this.Pattern);
                cmd.Parameters.AddWithValue("@baseamount", this.BaseAmount);
                cmd.Parameters.AddWithValue("@telcokeyword", this.TelcoKeyword);
                cmd.Parameters.AddWithValue("@gateway", this.Gateway);
                cmd.Parameters.AddWithValue("@deduction", this.Deduction);
                cmd.Parameters.AddWithValue("@userkeyword", this.UserKeyword);

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
        //---------------------DELETE METHOD---------------------
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
