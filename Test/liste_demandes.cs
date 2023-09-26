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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test
{
    public partial class liste_demandes : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True");
        public liste_demandes()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True"))
            {
                try
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    string req = "select * from demande";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(req, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable t = new DataTable();
                    t.Load(dr);
                    dataGridView.DataSource = t;
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }

        }
        private void liste_demandes_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string req = "update demande set etat='confirmer' where reference=@id";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (SqlCommand cmd = new SqlCommand(req, con))
            {
                cmd.Parameters.AddWithValue("@id", textBox1.Text.ToString());

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("demande confirmée.");
                }
                else
                {
                    MessageBox.Show("échec lors de la modification");
                }
            }

            con.Close();

            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var admin_menu = new Admin_menu();
            admin_menu.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var gestion_admin = new Admin_menu();
            gestion_admin.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vraiment supprimer?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string req = "delete from demande where reference=@id";

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand(req, con))
                {
                    cmd.Parameters.AddWithValue("@id", textBox1.Text.ToString());
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("supprimer avec succès.");
                    }
                    else
                    {
                        MessageBox.Show("échec lors de la suppression");
                    }
                }
                con.Close();

                loadData();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
