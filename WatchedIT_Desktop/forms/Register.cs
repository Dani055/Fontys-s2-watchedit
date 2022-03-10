using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchedIT_Desktop.logic;
using WatchedIT_Desktop.logic.services;

namespace WatchedIT_Desktop.forms
{
    public partial class Register : Form
    {
        bool closedByButton = false;
        public Register()
        {
            InitializeComponent();

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.closedByButton = true;
            this.Dispose();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closedByButton)
            {
                this.Dispose();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPass.Text;
            string firstname = tbFirstname.Text;
            string lastname = tbLastname.Text;
            string email = tbEmail.Text;
            string imageurl = tbImageurl.Text;

            try
            {
                bool result = UserService.Register(username, password, firstname, lastname, email, imageurl);
                if (result)
                {
                    Utils.ShowInfo("User registered successfully!");
                    this.closedByButton = true;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex.Message);
            }

        }
    }
}
