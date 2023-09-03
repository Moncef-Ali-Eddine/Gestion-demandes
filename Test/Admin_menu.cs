using System;
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
    public partial class Admin_menu : System.Windows.Forms.Form
    {
        public Admin_menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var admin_log = new User_Login();
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
            var gestion_admin = new gestion_user();
            gestion_admin.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var gestion_admin = new Article();
            gestion_admin.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var gestion_admin = new Fournisseur();
            gestion_admin.Show();
            this.Hide();
        }
    }
}
