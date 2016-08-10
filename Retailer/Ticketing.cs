using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Retailer
{
    public partial class Ticketing : Form
    {
        public Ticketing()
        {
            InitializeComponent();
        }

        public void loadRetailer()
        {
            List<Database.Retailer> obj;

            obj = Database.Retailer.GetDataWalletid();

            comboBoxWalletID.Items.Clear();

            foreach (Database.Retailer rec in obj)
            {
                comboBoxWalletID.Items.Add(rec);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void Ticketing_Load(object sender, EventArgs e)
        {
            loadRetailer();
        }

        private void comboBoxWalletID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Database.DBTicketing t = new Database.DBTicketing();
            t.GetDatabyWalletId(comboBoxWalletID.Text);
            txtUserKey.Text = t.User_key;
            txtWebsite.Text = t.Website;
            txtphilo_id.Text = t.Philo_Id;
            txtUser_Id.Text = t.User_Id;
        }
    }
}
