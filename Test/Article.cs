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
    public partial class Article : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True");
        public Article()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var gestion_admin = new Admin_menu();
            gestion_admin.Show();
            this.Hide();
        }
        private void loadCombo()
        {

            string req = "SELECT DISTINCT nom_fournisseur FROM fourniseur";
            con.Open();
            using (SqlCommand command = new SqlCommand(req, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["nom_fournisseur"].ToString());
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
                    string req = "select * from article";
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
        private void Article_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            loadCombo();
            loadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO article VALUES (@article,@prix,@id_four)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@article", txt_name.Text);
                command.Parameters.AddWithValue("@prix", txt_pass.Text);
                command.Parameters.AddWithValue("@id_four", comboBox1.SelectedItem.ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vraiment Modifier?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string req = ("update article set prix=@p1,id_four=@p2 where article=@id");
                using (SqlCommand cmd = new SqlCommand(req, con))
                {



                    cmd.Parameters.AddWithValue("@id", txt_name.Text.ToString());
                    cmd.Parameters.AddWithValue("@p1", txt_pass.Text.ToString());
                    cmd.Parameters.AddWithValue("@p2", comboBox1.SelectedItem.ToString());
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("modifier avec success.");

                    }
                    else
                    {
                        MessageBox.Show("echec lors de la modif");
                    }
                    loadData();
                   
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vraiment supprimer?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string req = "delete from article where article=@id";
                using (SqlCommand cmd = new SqlCommand(req, con))
                {
                    cmd.Parameters.AddWithValue("@id", txt_name.Text.ToString());
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
    }
}
