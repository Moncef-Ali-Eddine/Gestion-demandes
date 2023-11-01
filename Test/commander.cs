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
    public partial class commander : System.Windows.Forms.Form
    {
        public commander()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void liste_commande_Load(object sender, EventArgs e)
        {

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var retour = new Article();
            retour.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var gestion_admin = new Admin_menu();
            gestion_admin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var gestion_admin = new Admin_menu();
            gestion_admin.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var list_demande = new liste_demandes();
            list_demande.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var devis = new devis();
            devis.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
