﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Admin_menu : Form
    {
        public Admin_menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var admin_log = new Admin_login();
            admin_log.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var liste_demandes = new liste_demandes();
            liste_demandes.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gestion_admin = new gestion_admin();
            gestion_admin.Show();
            this.Hide();
        }
    }
}