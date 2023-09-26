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
    public partial class gestion_user : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True");
        public gestion_user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            try
            {
                string req = "insert into users values('" + txt_name.Text + "','" + txt_pass.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
                SqlCommand cmd = new SqlCommand(req, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ajout avec succes");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vraiment supprimer?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string req = "delete from users where user_login='" + txt_name.Text+"'";
                    SqlCommand cmd = new SqlCommand(req, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("suppression avec succes");
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("voulez vous vraiment Modifier?", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {

                    string req = ("update users set password=@p1,user_role=@p2 where user_login=@id");
                    SqlCommand cmd = new SqlCommand(req, con);
                    cmd.Parameters.AddWithValue("@p1", txt_pass.Text.ToString());
                    cmd.Parameters.AddWithValue("@id", txt_name.Text.ToString());
                    cmd.Parameters.AddWithValue("@p2", comboBox1.SelectedItem.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Mise a jour a etait effectuer avec succès");
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
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
            var gestion_admin = new Admin_menu();
            gestion_admin.Show();
            this.Hide();
        }
        private void loadData()
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string req = "select * from users";
            con.Open();
            SqlCommand cmd = new SqlCommand(req, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(dr);
            dataGridView.DataSource = t;
            dr.Close();
            con.Close();
        }
        private void gestion_user_Load(object sender, EventArgs e)
        {
            loadData();


        }
    }
}
