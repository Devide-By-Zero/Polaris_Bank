﻿using System;
using System.Windows.Forms;

namespace BankSYS
{
    public partial class FrmStartScreen : Form
    {
        public FrmStartScreen()
        {
            InitializeComponent();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            else
            {
                Application.Exit();
            }
        }

        private void lnkRegesterCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegesterLoginData Reg = new FrmRegesterLoginData();
            Reg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid = true;
            Customer.PPSNo = null;
            Customer.CustomerId = txtCustomerid.Text;
            Customer.PAC = txtPUC.Text;
            Validation v = new Validation();
            errorProvider.Clear();

            if (Customer.CustomerId.Length != 8 || !v.IsNumeric(Customer.CustomerId))
            {
                valid = false;
                errorProvider.SetError(txtCustomerid, "Please enter a valid customerID");
            }
            if (Customer.PAC.Length != 5 || !v.IsNumeric(Customer.PAC))
            {
                valid = false;
                errorProvider.SetError(txtPUC, "Please enter a valid PAC");
            }
            if(valid)
            { 
                try
                {
                    if (CustomerSQL.Login(Customer.CustomerId, Customer.PAC))
                    {
                        FrmDisplayAccounts Acc = new FrmDisplayAccounts();
                        Acc.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Login failed: Please try again");
                    }
                }
                catch
                {
                    MessageBox.Show("Error 005: Could not connect to database. Please contact an administratior");
                }
            }
        }

        private void FrmStartScreen_Load(object sender, EventArgs e)
        {
            txtCustomerid.Focus();
        }
    }
}
