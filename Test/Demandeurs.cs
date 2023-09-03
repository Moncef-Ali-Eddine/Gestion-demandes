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
    public partial class Demandeurs : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db;Integrated Security=True");
        public Demandeurs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var main_form = new User_Login();
            main_form.Show();
            this.Hide();
        }

        private void Demandeurs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           String demandes = txt_demandes.Text;
            try { 
            String req = "insert into demandeur values('"+txt_demandes.Text+"')";
            SqlCommand cmd=new SqlCommand(req,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Demande envoyer avec succes");
            }
            catch { MessageBox.Show("Erreur","Error", MessageBoxButtons.OKCancel,MessageBoxIcon.Error); }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_demandes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
