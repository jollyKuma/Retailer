using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Retailer
{
    public partial class ReferralPolicy : Form
    {
        Database.DBReferralPolicy rp = new Database.DBReferralPolicy();
        private bool isAdd;
        public string errMsg;

        public ReferralPolicy()
        {
            
            InitializeComponent();
            load_dataGridViewReferralPolicy();
        }

        public void input_clear()
        {
            txtAmount.Text = txtDetails.Text = txtLevel.Text = "";
        }

        public void enableInput()
        {
            txtAmount.Enabled = txtLevel.Enabled = txtDetails.Enabled = true;
        }

        public void disableInput()
        {
            txtAmount.Enabled = txtLevel.Enabled = txtDetails.Enabled = false;
        }

        public void enableButton()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        public void disableButton()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

        }
        public bool isValidated()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                errMsg = "Please input Amount";
                txtAmount.Focus();
                isValid = false;
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLevel.Text))
            {
                errMsg = "Please input  Level";
                txtLevel.Focus();
                isValid = false;
                return false;

            }
            if (string.IsNullOrWhiteSpace(txtDetails.Text))
            {
                errMsg = "Please input Details";
                txtDetails.Focus();
                isValid = false;
                return false;
            }
            else
            {
                isValid = true;
                return true;
            }
            
        }
        public void load_dataGridViewReferralPolicy()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBReferralPolicy> rec = Database.DBReferralPolicy.GetData();
                foreach (Database.DBReferralPolicy data in rec)

                    bindingsource.Add(data);
                this.dataGridViewReferralPolicy.Refresh();
                this.dataGridViewReferralPolicy.AutoGenerateColumns = false;
                this.dataGridViewReferralPolicy.DataSource = bindingsource;
                this.dataGridViewReferralPolicy.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        private void dataGridViewReferralPolicy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int index = e.RowIndex;
                
                DataGridViewRow selectedRow = dataGridViewReferralPolicy.Rows[index];
                rp.ID = (Int32)(Convert.ToInt32(selectedRow.Cells[0].Value.ToString()));
                rp.Amount = (double)(Convert.ToDouble(selectedRow.Cells[1].Value.ToString()));
                rp.Level = (Int32)(Convert.ToInt32(selectedRow.Cells[2].Value.ToString()));
                rp.Details = selectedRow.Cells[3].Value.ToString();

                enableButton();
                disableInput();
                this.btnEdit.Enabled = this.btnCancel.Enabled = this.btnSave.Enabled = this.btnDelete.Enabled = true;
                dataGridViewReferralPolicy.Rows[index].Selected = true;
                if (index > -1)
                {
                    this.txtAmount.Text = selectedRow.Cells[1].Value.ToString();
                    this.txtLevel.Text = selectedRow.Cells[2].Value.ToString();
                    this.txtDetails.Text = selectedRow.Cells[3].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            this.dataGridViewReferralPolicy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReferralPolicy.MultiSelect = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            input_clear();
            enableInput();
            disableButton();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            enableInput();
            disableButton();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                int idx = Convert.ToInt32(dataGridViewReferralPolicy.CurrentRow.Cells[0].Value.ToString());
                Database.DBReferralPolicy cards = Database.DBReferralPolicy.GetDataId(idx);

                if (cards != null)
                {

                    DialogResult dialogResult = MessageBox.Show(" Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {

                        rp.Delete(idx);
                        load_dataGridViewReferralPolicy();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record " + ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            enableButton();
            if (isAdd)
            {
                try
                {
                    rp.Amount = Convert.ToDouble(txtAmount.Text);
                    rp.Level = Convert.ToInt32(txtLevel.Text);
                    rp.Details = Convert.ToString(txtDetails.Text);

                    if (isValidated() == true)
                    {
                        rp.Add();
                        input_clear();
                        disableInput();
                        enableButton();
                    }
                    else
                    {
                        MessageBox.Show(errMsg);
                        disableButton();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Input ");
                    disableButton();
                }

                load_dataGridViewReferralPolicy();
            }
            else
            {

                rp.Amount = Convert.ToDouble(txtAmount.Text);
                rp.Level = Convert.ToInt32(txtLevel.Text);
                rp.Details = Convert.ToString(txtDetails.Text);

                rp.Update();



                int selectedIndex = this.dataGridViewReferralPolicy.CurrentCell.RowIndex;
                this.dataGridViewReferralPolicy.Rows[selectedIndex].SetValues(rp.ID, rp.Amount, rp.Level, rp.Details);

                input_clear();
                enableInput();
                enableButton();
                this.btnEdit.Enabled = true;



            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            input_clear();
            enableButton();
        }

        private void ReferralPolicy_Load(object sender, EventArgs e)
        {
            disableInput();
        }



    }
}
