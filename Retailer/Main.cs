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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnRetailers_Click(object sender, EventArgs e)
        {
            Form1 ret = new Form1();
            ret.Show();
        }

        private void btnLoadTracker_Click(object sender, EventArgs e)
        {
            LoadTracker ld = new LoadTracker();
            ld.Show();
        }

        private void btnTelcoPromo_Click(object sender, EventArgs e)
        {
            TelcoPromo tp = new TelcoPromo();
            tp.Show();
        }

        private void btnMLM_Click(object sender, EventArgs e)
        {
            MLM mlm = new MLM();
            mlm.Show();
        }

        private void btnReferalP_Click(object sender, EventArgs e)
        {
            ReferralPolicy rp = new ReferralPolicy();
            rp.Show();
        }

        private void btnTicketing_Click(object sender, EventArgs e)
        {
            Ticketing t = new Ticketing();
            t.Show();
        }


    }
}
