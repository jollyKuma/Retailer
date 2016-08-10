using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Retailer
{
    public partial class LoadTracker : Form
    {

        Database.DBLoaderTracker lt = new Database.DBLoaderTracker();
        private bool isAdd; 

        public LoadTracker()
        {
            InitializeComponent();
            disableInput();
            comboStatus.Items.Add("Paid");
            comboStatus.Items.Add("Claimed");
            comboStatus.Items.Add("Pending");
            load_dataGridView_LoadTracker();

        }
        //===============================================================
        //                    DATAGRIDVIEW                              |
        //===============================================================
        public void load_dataGridView_LoadTracker()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBLoaderTracker> rec = Database.DBLoaderTracker.GetData();
                foreach (Database.DBLoaderTracker data in rec)

                    bindingsource.Add(data);
               /* foreach (Database.DBLoaderTracker data in rec)

                    bindingsource.Add(new Database.DBLoaderTracker(
                    data.Id,
                    data.WalletId,
                    data.Amount,
                    data.Paidthru,
                    data.TrackingNo,
                    data.Status,
                    data.Comment,
                    data.LTDateTime
                    ));*/
                
         
                this.dataGridLoadTracker.Refresh();
                this.dataGridLoadTracker.AutoGenerateColumns = false;
                this.dataGridLoadTracker.DataSource = bindingsource;
                this.dataGridLoadTracker.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        public void input_clear()
        {
            txtwallet.Text = txtAmount.Text = txtPaidThru.Text = txtTrackingNo.Text = comboStatus.Text = txtComment.Text = " ";
        }
        public void enableInput() 
        {
           txtwallet.Enabled = txtAmount.Enabled = txtPaidThru.Enabled = txtTrackingNo.Enabled = comboStatus.Enabled = txtComment.Enabled = true;
        }
        public void disableInput()
        {
            txtwallet.Enabled = txtAmount.Enabled = txtPaidThru.Enabled = txtTrackingNo.Enabled = comboStatus.Enabled = txtComment.Enabled = false;
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
//--------------ADD------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            input_clear();
            enableInput();
            disableButton();
            txtWalletid.Text = " ";
            txtWalletid.Enabled = true; 

        }
//-------------------SAVE-----------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            enableButton();
            if (isAdd)
            {

                lt.WalletId = Regex.Replace(this.txtwallet.Text, "-", "-");
                lt.Amount = Convert.ToDouble(txtAmount.Text);
                lt.Paidthru = Convert.ToString(txtPaidThru.Text);
                lt.TrackingNo = Convert.ToString(txtTrackingNo.Text);
                lt.Status = Convert.ToString(comboStatus.Text);
                lt.Comment = Convert.ToString(txtComment.Text);
                lt.LTDateTime =this.dateTimeLT.Value.ToString();

                lt.Add();
                input_clear();
                disableInput();
                enableButton();
            load_dataGridView_LoadTracker();
            }
            else
            {
                
                lt.WalletId = Regex.Replace(this.txtwallet.Text, "-", "-");
                lt.Amount = Convert.ToDouble(txtAmount.Text);
                lt.Paidthru = Convert.ToString(txtPaidThru.Text);
                lt.TrackingNo = Convert.ToString(txtTrackingNo.Text);
                lt.Status = Convert.ToString(comboStatus.Text);
                lt.Comment = Convert.ToString(txtComment.Text);
                lt.LTDateTime = this.dateTimeLT.Value.ToString();

                lt.Update();
                input_clear();
                disableInput();
                disableButton();

                int selectedIndex = this.dataGridLoadTracker.CurrentCell.RowIndex;
                this.dataGridLoadTracker.Rows[selectedIndex].SetValues(lt.Id,lt.WalletId,lt.Amount,lt.Paidthru,lt.TrackingNo,lt.Status,lt.Comment,lt.LTDateTime);





            }
        }

 //----------------------CELL CLICK-----------------

        private void dataGridLoadTracker_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridLoadTracker.Rows[index];
                lt.Id = (Int32)(Convert.ToInt32(selectedRow.Cells[0].Value.ToString()));
                lt.WalletId = selectedRow.Cells[1].Value.ToString();
                lt.Amount = (double)(Convert.ToDouble(selectedRow.Cells[2].Value.ToString()));
                lt.Paidthru = selectedRow.Cells[3].Value.ToString();
                lt.TrackingNo = selectedRow.Cells[4].Value.ToString();
                lt.Status= selectedRow.Cells[5].Value.ToString();
                lt.Comment = selectedRow.Cells[6].Value.ToString();
                lt.LTDateTime= selectedRow.Cells[7].Value.ToString();

                enableButton();
                disableInput();
                this.btnEdit.Enabled = this.btnCancel.Enabled = this.btnSave.Enabled = this.btnDelete.Enabled = true;
                this.txtWalletid.Enabled = false;
                dataGridLoadTracker.Rows[index].Selected = true;
                if (index > -1)
                {
                    this.txtwallet.Text = selectedRow.Cells[1].Value.ToString();
                    this.txtAmount.Text = selectedRow.Cells[2].Value.ToString();
                    this.txtPaidThru.Text = selectedRow.Cells[3].Value.ToString();
                    this.txtTrackingNo.Text = selectedRow.Cells[4].Value.ToString();
                    this.comboStatus.Text = selectedRow.Cells[5].Value.ToString();
                    this.txtComment.Text = selectedRow.Cells[6].Value.ToString();
                    this.dateTimeLT.Text = selectedRow.Cells[7].Value.ToString();
                    
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            this.dataGridLoadTracker.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLoadTracker.MultiSelect = false;

        }
//------------------------EDIT-------------------------------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            enableInput();
            disableButton();
        }
//-----------------------DELETE-------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
             try
            {
                int idx = Convert.ToInt32(dataGridLoadTracker.CurrentRow.Cells[0].Value.ToString());
                Database.DBLoaderTracker cards = Database.DBLoaderTracker.GetDataID(idx);

                if (cards != null)
                {

                    DialogResult dialogResult = MessageBox.Show(" Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        lt.WalletId = Regex.Replace(this.txtWalletid.Text, "-", "");

                        lt.Delete(idx);  
                        load_dataGridView_LoadTracker();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record " + ex.Message);
            }

         }
//-----------------------------SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;

            dataGridLoadTracker.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridLoadTracker.Rows)
                {
                    if (row.Cells[5].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            BindingSource bindingsource = new BindingSource();

            List<Database.DBLoaderTracker> rec = Database.DBLoaderTracker.GetDataLoadTracker(txtSearch.Text);
             foreach (Database.DBLoaderTracker data in rec)

                bindingsource.Add(data);

                this.dataGridLoadTracker.Refresh();
                this.dataGridLoadTracker.AutoGenerateColumns = false;
                this.dataGridLoadTracker.DataSource = bindingsource;
                this.dataGridLoadTracker.ClearSelection();

                Cursor.Current = Cursors.Default;

        }   
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            enableButton();
            enableInput();
        }

        


    }
}
