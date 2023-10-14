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
    public partial class devis : System.Windows.Forms.Form
    {
        public devis()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            var commander = new commander();
            commander.Show();
            this.Hide();
        }
    }
}
