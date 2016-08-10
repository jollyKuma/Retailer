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
    public partial class MLM : Form
    {
        public MLM()
        {
            InitializeComponent();
            load_dataGridViewRetailer();
            txtWalletid.Enabled = false;
        }
        //---------> DATAGRIDVIEW REATAILER
        public void load_dataGridViewRetailer()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.Retailer> rec = Database.Retailer.GetData();
                foreach (Database.Retailer data in rec)

                bindingsource.Add(data);
                this.dataGridViewRetailer.Refresh();
                this.dataGridViewRetailer.AutoGenerateColumns = false;
                this.dataGridViewRetailer.DataSource = bindingsource;
                this.dataGridViewRetailer.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            this.dataGridViewRetailer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRetailer.MultiSelect = false;
        }
        //--------->DATAGRIDVIEW BONUS
        public void load_dataGridViewBonus()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBReferral_Mlm> rec = Database.DBReferral_Mlm.GetDataMlm(txtWalletid.Text);
                foreach (Database.DBReferral_Mlm data in rec)

                bindingsource.Add(data);
                this.dataGridViewbonus.Refresh();
                this.dataGridViewbonus.AutoGenerateColumns = false;
                this.dataGridViewbonus.DataSource = bindingsource;
                this.dataGridViewbonus.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            this.dataGridViewbonus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewbonus.MultiSelect = false;

        }
        //--------->DATAGRIDVIEW HISTORY
        public void load_dataGridViewHistory()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBReferral_Mlm> rec = Database.DBReferral_Mlm.GetDataHistory(txtWalletid.Text);
                foreach (Database.DBReferral_Mlm data in rec)

                    bindingsource.Add(data);
                this.dataGridViewHistory.Refresh();
                this.dataGridViewHistory.AutoGenerateColumns = false;
                this.dataGridViewHistory.DataSource = bindingsource;
                this.dataGridViewHistory.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            this.dataGridViewHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistory.MultiSelect = false;
        }
        //--------->DATAGRIDVIEW PENDING
        public void load_dataGridViewPending()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBReferral_Mlm> rec = Database.DBReferral_Mlm.GetDataPending(txtWalletid.Text);
                foreach (Database.DBReferral_Mlm data in rec)

                    bindingsource.Add(data);
                this.dataGridViewPending.Refresh();
                this.dataGridViewPending.AutoGenerateColumns = false;
                this.dataGridViewPending.DataSource = bindingsource;
                this.dataGridViewPending.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            this.dataGridViewPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPending.MultiSelect = false;
        }


        private void dataGridViewMLM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWalletid.Enabled = false;
            txtWalletid.Text = dataGridViewRetailer.CurrentRow.Cells[0].Value.ToString();

            load_dataGridViewBonus();
            load_dataGridViewHistory();
            load_dataGridViewPending();

            this.dataGridViewRetailer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRetailer.MultiSelect = false;
        }

        private void MLM_Load(object sender, EventArgs e)
        {

        }

        private void txtFindRetailer_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            BindingSource bindingsource = new BindingSource();

            List<Database.Retailer> rec = Database.Retailer.GetDataRetailer(txtFindRetailer.Text);
             foreach (Database.Retailer data in rec)

                bindingsource.Add(data);

                this.dataGridViewRetailer.Refresh();
                this.dataGridViewRetailer.AutoGenerateColumns = false;
                this.dataGridViewRetailer.DataSource = bindingsource;
                this.dataGridViewRetailer.ClearSelection();

                Cursor.Current = Cursors.Default;

        }

        public void loadGridByDateBonus()
        {


            Cursor.Current = Cursors.WaitCursor;

            BindingSource bindingsource = new BindingSource();

            List<Database.DBReferral_Mlm> rec = Database.DBReferral_Mlm.GetDataByMlmDate(dateTimePickerFrom.Value, dateTimePickerTo.Value);
            foreach (Database.DBReferral_Mlm data in rec)

                bindingsource.Add(data);

            this.dataGridViewbonus.Refresh();
            this.dataGridViewbonus.AutoGenerateColumns = false;
            this.dataGridViewbonus.DataSource = bindingsource;
            this.dataGridViewbonus.ClearSelection();

            Cursor.Current = Cursors.Default; 
        }
        public void loadGridByDateHistory()
        {


            Cursor.Current = Cursors.WaitCursor;

            BindingSource bindingsource = new BindingSource();

            List<Database.DBReferral_Mlm> rec = Database.DBReferral_Mlm.GetDataByHistoryDate(dateTimePickerFrom.Value, dateTimePickerTo.Value);
            foreach (Database.DBReferral_Mlm data in rec)

                bindingsource.Add(data);

            this.dataGridViewbonus.Refresh();
            this.dataGridViewbonus.AutoGenerateColumns = false;
            this.dataGridViewbonus.DataSource = bindingsource;
            this.dataGridViewbonus.ClearSelection();

            Cursor.Current = Cursors.Default;
        }
        public void loadGridByDatePending()
        {


            Cursor.Current = Cursors.WaitCursor;

            BindingSource bindingsource = new BindingSource();

            List<Database.DBReferral_Mlm> rec = Database.DBReferral_Mlm.GetDataByPendingDate(dateTimePickerFrom.Value, dateTimePickerTo.Value);
            foreach (Database.DBReferral_Mlm data in rec)

                bindingsource.Add(data);

            this.dataGridViewbonus.Refresh();
            this.dataGridViewbonus.AutoGenerateColumns = false;
            this.dataGridViewbonus.DataSource = bindingsource;
            this.dataGridViewbonus.ClearSelection();

            Cursor.Current = Cursors.Default;
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            loadGridByDateBonus();
            load_dataGridViewHistory();
            load_dataGridViewPending();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            loadGridByDateBonus();
            load_dataGridViewHistory();
            load_dataGridViewPending();
        }
    }
}
