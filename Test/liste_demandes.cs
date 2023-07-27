using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class liste_demandes : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db;Integrated Security=True");
        public liste_demandes()
        {
            InitializeComponent();
        }

        private void liste_demandes_Load(object sender, EventArgs e)
        {
            string req = "select * from demandeur";
            con.Open();
            SqlCommand cmd = new SqlCommand(req, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(dr);
            dataGridView.DataSource = t;
            dr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var admin_log = new Admin_login();
            admin_log.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var admin_menu = new Admin_menu();
            admin_menu.Show();
            this.Hide();
        }
    }
}
