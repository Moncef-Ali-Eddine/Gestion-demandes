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
    public partial class gestion_user : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db;Integrated Security=True");
        public gestion_user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string req = "insert into admin_log values('" + txt_name.Text + "','" + txt_pass.Text + "')";
                SqlCommand cmd = new SqlCommand(req, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ajout avec succes");
            }
            catch
            {
                MessageBox.Show("erreur l'ajout à echoué");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vraiment supprimer?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string req = "delete from admin_log where nom_utilisateur=" + txt_name.Text;
                    SqlCommand cmd = new SqlCommand(req, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("suppression avec succes");
                }
                catch
                {
                    MessageBox.Show("erreur la ssuppression à echoué");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vraiment Modifier?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    //boutton modifier

                    string req = ("update admin_log set password=@p1 where nom_utilisateur=@id");
                    SqlCommand cmd = new SqlCommand(req, con);
                    // les demandes sont toujours avant le con.open
                    cmd.Parameters.AddWithValue("@p1", txt_pass.Text.ToString());
                    cmd.Parameters.AddWithValue("@id", txt_name.Text.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Mise a jour avec succes");
                }
                catch
                {
                    MessageBox.Show("Erreur", "Erreur");


                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
