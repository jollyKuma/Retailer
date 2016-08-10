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
    public partial class TelcoPromo : Form
    {
        Database.DBTelcoPromo tp = new Database.DBTelcoPromo();
        private bool isAdd;
        public int addValue;
        public string errMsg;


        public TelcoPromo()
        {
            InitializeComponent();
            disableInput();
            comboBoxTelcoName.Items.Add("ALL");
            load_dataGridView_TelcoPromo();
        }
        private void txtbaseamount_TextChanged(object sender, EventArgs e)
        {
            txtbaseamount.Enabled = true;
            int baseamount;
            double percent;
            double result;
            double dedResult;

            if (txtbaseamount.Text != null)
            {
                txtbaseamount.TextChanged -= txtbaseamount_TextChanged;  // dettach the event handler
                //addValue = Convert.ToInt32();
                baseamount =  tp.BaseAmount;

                if (int.TryParse(txtbaseamount.Text, out baseamount))
                {
                    percent = 0.02;
                    result = baseamount * percent;
                    dedResult = baseamount - result;

                    txtdeduction.Text = dedResult.ToString();
                    
                }
                txtbaseamount.TextChanged += txtbaseamount_TextChanged;
            }

        }
//===============================================================
//                    DATAGRIDVIEW                              |
//===============================================================
        public void load_dataGridView_TelcoPromo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBTelcoPromo> rec = Database.DBTelcoPromo.GetData();

                foreach (Database.DBTelcoPromo data in rec)

                    bindingsource.Add(data);
                this.dataGridTelcoPromo.Refresh();
                this.dataGridTelcoPromo.AutoGenerateColumns = false;
                this.dataGridTelcoPromo.DataSource = bindingsource;
                this.dataGridTelcoPromo.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void input_clear()
        {
            comboBtelconame.Text = txtpattern.Text = txtbaseamount.Text = txttelcokeyword.Text = txtgateway.Text = txtdeduction.Text = txtuserkeyword.Text = " ";
        }
        public void enableInput()
        {
            comboBtelconame.Enabled = txtpattern.Enabled = txtbaseamount.Enabled = txttelcokeyword.Enabled = txtgateway.Enabled = txtdeduction.Enabled = txtuserkeyword.Enabled = true;
        }
        public void disableInput()
        {
            comboBtelconame.Enabled = txtpattern.Enabled = txtbaseamount.Enabled = txttelcokeyword.Enabled = txtgateway.Enabled = txtdeduction.Enabled = txtuserkeyword.Enabled = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
             enableButton();

             if (isAdd)
             {
                 
                 try
                 {
                     tp.TelcoName = Convert.ToString(comboBtelconame.Text);
                     tp.Pattern = Convert.ToString(txtpattern.Text);
                     tp.BaseAmount = Convert.ToInt32(txtbaseamount.Text);
                     tp.TelcoKeyword = Convert.ToString(txttelcokeyword.Text);
                     tp.Gateway = Convert.ToString(txtgateway.Text);
                     tp.Deduction = float.Parse(txtdeduction.Text);
                     tp.UserKeyword = Convert.ToString(txtuserkeyword.Text);

                     if (isValidated() == true)
                     {
                         tp.Add();
                         input_clear();
                         disableButton();
                     }
                     else
                     {

                         MessageBox.Show(errMsg);
                         disableButton();
                     }
                     
                
                    
                 }
                 catch(Exception ex)
                 {
                     MessageBox.Show("Invalid Input");
                     disableButton();
                 }
                 load_dataGridView_TelcoPromo();
             }
             else
             {
                 try
                 {

                     tp.TelcoName = Convert.ToString(comboBtelconame.Text);
                     tp.Pattern = Convert.ToString(txtpattern.Text);
                     //tp.BaseAmount = Convert.ToInt32(txtbaseamount.Text);
                     tp.TelcoKeyword = Convert.ToString(txttelcokeyword.Text);
                     tp.Gateway = Convert.ToString(txtgateway.Text);
                     tp.Deduction = float.Parse(txtdeduction.Text);
                     tp.UserKeyword = Convert.ToString(txtuserkeyword.Text);

                     tp.Update();


                     int selectedIndex = this.dataGridTelcoPromo.CurrentCell.RowIndex;
                     this.dataGridTelcoPromo.Rows[selectedIndex].SetValues(tp.ID, tp.TelcoName, tp.Pattern, tp.BaseAmount, tp.TelcoKeyword, tp.Gateway, tp.Deduction, tp.UserKeyword);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Invalid Input");
                     disableButton();
                 }

                 enableInput();
                 disableButton();
                 this.btnEdit.Enabled = true;
             }
        }

        private void dataGridLoadTracker_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridTelcoPromo.Rows[index];
                tp.ID = (Int32)(Convert.ToInt32(selectedRow.Cells[0].Value.ToString()));
                tp.TelcoName= selectedRow.Cells[1].Value.ToString();
                tp.Pattern = selectedRow.Cells[2].Value.ToString();
                tp.BaseAmount = (Int32)(Convert.ToInt32(selectedRow.Cells[3].Value.ToString()));
                tp.TelcoKeyword = selectedRow.Cells[4].Value.ToString();
                tp.Gateway = selectedRow.Cells[5].Value.ToString();
                tp.Deduction =(float)(float.Parse(selectedRow.Cells[6].Value.ToString()));
                tp.UserKeyword = selectedRow.Cells[7].Value.ToString();

                enableButton();
                disableInput();
                this.btnEdit.Enabled = this.btnCancel.Enabled = this.btnSave.Enabled = this.btnDelete.Enabled = true;
                this.txtWalletid.Enabled = false;
                dataGridTelcoPromo.Rows[index].Selected = true;
                if (index > -1)
                {
                    this.comboBtelconame.Text = selectedRow.Cells[1].Value.ToString();
                    this.txtpattern.Text = selectedRow.Cells[2].Value.ToString();
                    this.txtbaseamount.Text = selectedRow.Cells[3].Value.ToString();
                    this.txttelcokeyword.Text = selectedRow.Cells[4].Value.ToString();
                    this.txtgateway.Text = selectedRow.Cells[5].Value.ToString();
                    this.txtdeduction.Text = selectedRow.Cells[6].Value.ToString();
                    this.txtuserkeyword.Text = selectedRow.Cells[7].Value.ToString();

                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            this.dataGridTelcoPromo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTelcoPromo.MultiSelect = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = Convert.ToInt32(dataGridTelcoPromo.CurrentRow.Cells[0].Value.ToString());
                Database.DBTelcoPromo cards = Database.DBTelcoPromo.GetDataID(idx);

                if (cards != null)
                {

                    DialogResult dialogResult = MessageBox.Show(" Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        tp.Delete(idx);
                        load_dataGridView_TelcoPromo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record " + ex.Message);
            }

        }

        private void comboBoxTelcoName_SelectedIndexChanged(object sender, EventArgs e)

        {

            tp.CTelconame = comboBoxTelcoName.Text;
            load_dataGridView_TelcoPromo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            enableButton();
            enableInput();
            input_clear();
        }
        public void loadTelcoName()
        {
            List<Database.DBTelco> obj;

            obj = Database.DBTelco.GetData();

            comboBtelconame.Items.Clear();

            foreach (Database.DBTelco rec in obj)
            {
                comboBtelconame.Items.Add(rec);
                comboBoxTelcoName.Items.Add(rec);
            }
        }

        private void TelcoPromo_Load(object sender, EventArgs e)
        {
            loadTelcoName();
        }
//===================INPUT VALIDATION======================
        public bool isValidated()
        {
            bool isValid = true;
          
                if (comboBtelconame.SelectedIndex == -1)
                {
                    errMsg = "Please select a Telco Name";
                    comboBtelconame.Focus();
                    isValid = false;
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtpattern.Text))
                {
                    errMsg = "Please input a Pattern";
                    txtpattern.Focus();
                    isValid = false;
                    return false;

                }
                if (string.IsNullOrWhiteSpace(txtbaseamount.Text))
                {
                    errMsg = "Please input a Baseamount";
                    txtbaseamount.Focus();
                    isValid = false;
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txttelcokeyword.Text))
                {
                    errMsg = "Please input a Telco Keyword";
                    txttelcokeyword.Focus();
                    isValid = false;
                    return false;

                }
                if (string.IsNullOrWhiteSpace(txtgateway.Text))
                {
                    errMsg = "Please input a Gateway";
                    txtgateway.Focus();
                    isValid = false;
                    return false;

                }
                if (string.IsNullOrWhiteSpace(txtdeduction.Text))
                {
                    errMsg = "Please input a Deduction";
                    txtdeduction.Focus();
                    isValid = false;
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtuserkeyword.Text))
                {
                    errMsg = "Please input a User Keyword";
                    txtuserkeyword.Focus();
                    isValid = false;
                    return false;

                }
                else
                { 
                    isValid = true;
                    return true;
                }
            

        
        }

        private void comboBtelconame_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
