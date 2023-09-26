using System;
using System.Collections;
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
    public partial class Fournisseur : System.Windows.Forms.Form
    {
        public Fournisseur()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True");

        private void button5_Click(object sender, EventArgs e)
        {
            var gestion_admin = new Admin_menu();
            gestion_admin.Show();
            this.Hide();
        }
        private void loadCombo()
        {

            string req = "select categorie from fourniseur";
            con.Open();
            using (SqlCommand command = new SqlCommand(req, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            comboBox1.Items.Add(reader["categorie"].ToString());
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
                    string req = "select * from fourniseur";
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
        private void Fournisseur_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            loadData();
            loadCombo();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string query = "INSERT INTO fourniseur VALUES (@nom_four,@categorie)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@nom_four", txt_name.Text);
                command.Parameters.AddWithValue("@categorie", comboBox1.SelectedItem);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("voulez vous vraiment Modifier?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string req = ("update fourniseur set categorie=@p1 where nom_fournisseur=@id");
                using (SqlCommand cmd = new SqlCommand(req, con))
                {



                    cmd.Parameters.AddWithValue("@id", txt_name.Text.ToString());
                    cmd.Parameters.AddWithValue("@p1", comboBox1.SelectedItem.ToString());
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
                string req = "delete from fourniseur where nom_fournisseur=@id";
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
