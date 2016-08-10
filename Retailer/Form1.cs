using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Retailer
{
    public partial class Form1 : Form
    {
        private bool isAdd;

        public Form1()
        {
            InitializeComponent();
        }

    Database.Retailer r = new Database.Retailer();
    //===================================================
    //                   LOAD  FORM1                    |
    //===================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            enAbleButton();
            disableInput();
            load_Province();
            load_dataGridView_Retailer();
        }
        //===============================================================
        //                    DATAGRIDVIEW                              |
        //===============================================================
        public void load_dataGridView_Retailer()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.Retailer> rec = Database.Retailer.GetData();
                foreach (Database.Retailer data in rec)

                    bindingsource.Add(new Database.Retailer(
                    
                    data.Walletid,
                    data.Date,
                    data.Fname,
                    data.Lname,
                    data.Birthdate,
                    data.Address,
                    data.Province,
                    data.City,
                    data.Balance,
                    data.Frozen,
                    data.Sponsor_id,
                    data.Share,
                    data.Email,
                    data.Password,
                    data.Type
                    ));
                this.dataGridShow.Refresh();
                this.dataGridShow.AutoGenerateColumns = false;
                this.dataGridShow.DataSource = bindingsource;
                this.dataGridShow.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //============================================================
        //              BUTTON CONTROLS                              |
        //============================================================
        private void enAbleButton()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void disAbleButton()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        private void enableInput()
        {
            txtFname.Enabled = true;
            txtLname.Enabled = true;
            txtBirthdate.Enabled = true;
            txtAddress.Enabled = true;
            comboBox_Province.Enabled = true;
            comboBox_City.Enabled = true;
            txtBalance.Enabled = true;
            txtFrozen.Enabled = true;
            txtShare.Enabled = true;
            txtSponsor_id.Enabled = true;
            txtEmail.Enabled = true;
            txtPassword.Enabled = true;
            txtType.Enabled = true;
        }
        private void disableInput()
        {
            txtWalletid.Enabled = false;
            txtFname.Enabled = false;
            txtLname.Enabled = false;
            txtBirthdate.Enabled = false;
            txtAddress.Enabled = false;
            comboBox_Province.Enabled = false;
            comboBox_City.Enabled = false;
            txtBalance.Enabled = false;
            txtFrozen.Enabled = false;
            txtShare.Enabled = false;
            txtSponsor_id.Enabled = false;
            txtEmail.Enabled = false;
            txtPassword.Enabled = false;
            txtType.Enabled = false;
        }


        //=========================================================
        //                 load Province List Method               |
        //==========================================================

        public void load_Province()
        {
            List<Database.DBProvince> obj;

            obj = Database.DBProvince.GetData();
            this.comboBox_Province.Items.Clear();
            foreach (Database.DBProvince rec in obj)
            {
                this.comboBox_Province.Items.Add(rec);
            }

        }
        //====================================================
        //               CANCEL BUTTON FUNCTION              |
        //====================================================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            input_clear();
            enAbleButton();

        }

        //====================================================
        //             ADD BUTTON FUNCTION                   |
        //===================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            input_clear();
            enableInput();
            disAbleButton();
            txtWalletid.Text = " ";
            txtWalletid.Enabled = true;
           
        }
        //==========================================================================
        //                         PROVINCE COMBOBOX                               |
        //==========================================================================
        private void comboBox_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            Database.DBProvince item = (Database.DBProvince)this.comboBox_Province.SelectedItem;
            List<Database.DBCity> obj;

            try
            {
                obj = Database.DBCity.GetDataByProvice(item.Id);
                this.comboBox_City.Items.Clear();
                foreach (Database.DBCity rec in obj)
                {
                    this.comboBox_City.Items.Add(rec);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            r.Province = this.comboBox_Province.SelectedText;
        }

        //============================================================================
        //                          INPUT VALID                                      |  
        //============================================================================

        public bool input_valid()
        {
            if (r.Fname.Equals("") || r.Lname.Equals("") || r.Walletid.Equals("") || r.Address.Equals("") || r.Province.Equals("") || r.City.Equals(""))
            {
                MessageBox.Show("Incomplete Fields");
                return false;
            }
            return true;
        }

        //=============================================================================
        //                                INPUT ENABLES  METHOD                       |
        //=============================================================================
        private void input_enableStatus(bool stat)
        {
            this.txtFname.Enabled =
            this.txtLname.Enabled =
            this.txtWalletid.Enabled =
            this.txtAddress.Enabled =
            this.comboBox_Province.Enabled =
            this.comboBox_City.Enabled =
            this.retailersDate.Enabled =
            this.txtBirthdate.Enabled = stat;
        }


        private void btnClear_Click_1(object sender, EventArgs e)
        {
            input_clear();
        }

        private void dataGridView_Retailer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index > -1)
                {

                    DataGridViewRow selectedRow = dataGridShow.Rows[index];
                    this.retailersDate.Text = selectedRow.Cells[0].Value.ToString();
                    this.txtWalletid.Text = selectedRow.Cells[1].Value.ToString();
                    this.txtFname.Text = selectedRow.Cells[2].Value.ToString();
                    this.txtLname.Text = selectedRow.Cells[3].Value.ToString();
                    this.txtBirthdate.Text = selectedRow.Cells[4].Value.ToString();
                    this.txtAddress.Text = selectedRow.Cells[5].Value.ToString();
                    this.comboBox_Province.Text = selectedRow.Cells[6].ToString();
                    this.comboBox_City.Text = selectedRow.Cells[7].ToString();
                    this.txtBalance.Text = selectedRow.Cells[8].ToString();
                    this.txtFrozen.Text = selectedRow.Cells[9].ToString();
                    this.txtSponsor_id.Text = selectedRow.Cells[10].ToString();
                    this.txtShare.Text = selectedRow.Cells[11].ToString();
                    this.txtEmail.Text = selectedRow.Cells[12].ToString();
                    this.txtPassword.Text = selectedRow.Cells[13].ToString();
                    this.txtType.Text = selectedRow.Cells[14].ToString();
                }

            }
            catch (ArgumentException ex)
            {
                ex.ToString();
            }
           if (dataGridShow.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                dataGridShow.Rows[e.RowIndex].ReadOnly = false;
            }
        }
        //===========================================================
        //                   Button Enable                           |
        //============================================================
        private void buttonEnable(bool stat)
        {
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDelete.Enabled = stat;
        }
        //============================================================================
        //                          CLEAR METHOD                                      |
        //============================================================================
        private void input_clear()
        {

             txtFname.Text = txtLname.Text = txtBirthdate.Text = txtAddress.Text = comboBox_Province.Text = comboBox_City.Text = txtBalance.Text = txtFrozen.Text = txtSponsor_id.Text= txtEmail.Text= txtPassword.Text = txtType.Text=" ";
        }
        //===============================================================================
        //                    DATAGRID   CELL CONTENT CLICK                             |
        //===============================================================================

        private void dataGridShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridShow.Rows[index];
                r.Date = (DateTime)(Convert.ToDateTime(selectedRow.Cells[0].Value.ToString()));
                r.Walletid = selectedRow.Cells[1].Value.ToString();
                r.Fname = selectedRow.Cells[2].Value.ToString();
                r.Lname = selectedRow.Cells[3].Value.ToString();
                r.Birthdate = selectedRow.Cells[4].Value.ToString();
                r.Address = selectedRow.Cells[5].Value.ToString();
                r.Province = selectedRow.Cells[6].Value.ToString();
                r.City = selectedRow.Cells[7].Value.ToString();
                r.Balance = (double)(Convert.ToDouble(selectedRow.Cells[8].Value.ToString()));
                r.Frozen = (double)(Convert.ToDouble(selectedRow.Cells[9].Value.ToString()));
                r.Sponsor_id = selectedRow.Cells[10].Value.ToString();
                r.Share = (decimal)(Convert.ToDouble(selectedRow.Cells[11].Value.ToString()));
                r.Email = selectedRow.Cells[12].Value.ToString();
                r.Password = selectedRow.Cells[13].Value.ToString();
                r.Type = (int)(Convert.ToInt32(selectedRow.Cells[14].Value.ToString()));

                buttonEnable(false);
                disableInput();
                this.btnEdit.Enabled = this.btnCancel.Enabled = this.btnSave.Enabled = this.btnDelete.Enabled = true;
                this.txtWalletid.Enabled = false;
                dataGridShow.Rows[index].Selected = true;
                if (index > -1)
                {
                    this.retailersDate.Text = selectedRow.Cells[0].Value.ToString();
                    this.txtWalletid.Text= selectedRow.Cells[1].Value.ToString();
                    this.txtFname.Text = selectedRow.Cells[2].Value.ToString();
                    this.txtLname.Text = selectedRow.Cells[3].Value.ToString();
                    this.txtBirthdate.Text = selectedRow.Cells[4].Value.ToString();
                    this.txtAddress.Text = selectedRow.Cells[5].Value.ToString();
                    this.comboBox_Province.Text = selectedRow.Cells[6].Value.ToString();
                    this.comboBox_City.Text = selectedRow.Cells[7].Value.ToString();
                    this.txtBalance.Text = selectedRow.Cells[8].Value.ToString();
                    this.txtFrozen.Text = selectedRow.Cells[9].Value.ToString();
                    this.txtSponsor_id.Text = selectedRow.Cells[10].Value.ToString();
                    this.txtShare.Text = selectedRow.Cells[11].Value.ToString();
                    this.txtEmail.Text = selectedRow.Cells[12].Value.ToString();
                    this.txtPassword.Text = selectedRow.Cells[13].Value.ToString();
                    this.txtType.Text = selectedRow.Cells[14].Value.ToString();
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            this.dataGridShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridShow.MultiSelect = false;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdd = false;
            enableInput();
            disAbleButton();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            enAbleButton();
            if (isAdd)
            {

                
                r.Date = Convert.ToDateTime(retailersDate.Text);
                r.Walletid = Regex.Replace(this.txtWalletid.Text, "-", "-");
                r.Fname = Convert.ToString(txtFname.Text);
                r.Lname = Convert.ToString(txtLname.Text);
                r.Birthdate = Convert.ToString(txtBirthdate.Text);
                r.Address = Convert.ToString(txtAddress.Text);
                r.Province = Convert.ToString(comboBox_Province.Text);
                r.City = Convert.ToString(comboBox_City.Text);
                r.Sponsor_id = Convert.ToString(txtSponsor_id.Text);
                r.Email = Convert.ToString(txtEmail.Text);
                r.Password = Convert.ToString(txtPassword.Text);

                r.Balance = Convert.ToDouble(txtBalance.Text);
                r.Frozen = Convert.ToDouble(txtFrozen.Text);

                r.Share = Convert.ToDecimal(txtShare.Text);

                MessageBox.Show(r.Walletid);
                r.Add();
                input_clear();
                disableInput();
                enAbleButton();

                load_dataGridView_Retailer();

            }
            else
            {
               
                    r.Date = Convert.ToDateTime(retailersDate.Value);
                    r.Walletid = Regex.Replace(this.txtWalletid.Text, "-", "-");
                    r.Fname = Convert.ToString(txtFname.Text);
                    r.Lname = Convert.ToString(txtLname.Text);
                    r.Birthdate = Convert.ToString(txtBirthdate.Text);
                    r.Address = Convert.ToString(txtAddress.Text);
                    r.Province = Convert.ToString(comboBox_Province.Text);
                    r.City = Convert.ToString(comboBox_City.Text);
                    r.Balance = Convert.ToDouble(txtBalance.Text);
                    r.Frozen = Convert.ToDouble(txtFrozen.Text);
                    r.Sponsor_id = Convert.ToString(txtSponsor_id.Text);
                    r.Share = Convert.ToDecimal(txtShare.Text);
                    r.Email = Convert.ToString(txtEmail.Text);
                    r.Password = Convert.ToString(txtPassword.Text);
                    r.Type = Convert.ToInt32(txtType.Text);
                    r.Update();

             
                int selectedIndex = this.dataGridShow.CurrentCell.RowIndex;
                this.dataGridShow.Rows[selectedIndex].SetValues(r.Date, r.Walletid, r.Fname, r.Lname, r.Birthdate, r.Address, r.Province, r.City, r.Balance, r.Frozen, r.Sponsor_id, r.Share, r.Email, r.Password, r.Type);


                enableInput();
                disAbleButton();
                this.btnEdit.Enabled = true;



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string idx = dataGridShow.CurrentRow.Cells[1].Value.ToString();
                Database.Retailer cards = Database.Retailer.GetDataID(idx);
                MessageBox.Show(idx + "");

                Debug.WriteLine("DELETE START");
                if (cards == null)
                {

                    DialogResult dialogResult = MessageBox.Show(" Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        r.Walletid = Regex.Replace(this.txtWalletid.Text, "-", "");
                        Debug.WriteLine("DELETE BEGIN");

                        r.Delete(idx);
                        Debug.WriteLine("DELETE END");

                        load_dataGridView_Retailer();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record " + ex.Message);
            }

        }


    }
}
