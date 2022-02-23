﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchedIT_Desktop.forms;
using WatchedIT_Desktop.logic.services;

namespace WatchedIT_Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            bool result = UserService.Login(username, password);
            if (result)
            {
                Home home = new Home();
                this.Hide();
                home.ShowDialog();
                this.Show();
            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.ShowDialog();
            this.Show();
        }
    }
}
