using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test
{
    public partial class Demandeurs : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True");
        public Demandeurs()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var gestion_admin = new User_Login();
            gestion_admin.Show();
            this.Hide();
        }
        private void loadCombo()
        {

            string req = "select article from article";
            con.Open();
            using (SqlCommand command = new SqlCommand(req, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            comboBox3.Items.Add(reader["article"].ToString());
                        }
                    }
                }
            }


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
        private void Demandeurs_Load(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = 0;
            loadCombo();
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string req = ("update demande set etat='encours de confirmation' where reference=@id");
            using (SqlCommand cmd = new SqlCommand(req, con))
            {


                cmd.Parameters.AddWithValue("@id", textBox2.Text.ToString());

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("demande envoyer pour la confirmation.");

                }
                else
                {
                    MessageBox.Show("echec lors de la modif");
                }
                loadData();

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_demandes_TextChanged(object sender, EventArgs e)
        {

        }
        public int num;
        private void button10_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO demande (reference,article,quantity) VALUES (@ref,@article,@quantity)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@article", comboBox3.SelectedItem.ToString());
                command.Parameters.AddWithValue("@quantity", textBox1.Text);
                command.Parameters.AddWithValue("@ref", textBox2.Text);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("ajout avec success.");

                }
                else
                {
                    MessageBox.Show("echec lors de l'ajout");
                }
                loadData();

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vraiment supprimer?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string req = "delete from demande where reference=@id";
                using (SqlCommand cmd = new SqlCommand(req, con))
                {
                    cmd.Parameters.AddWithValue("@id", textBox2.Text.ToString());
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("supprimer avec success.");

                    }
                    else
                    {
                        MessageBox.Show("echec lors de la suppression");
                    }
                    loadData();

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    
}
