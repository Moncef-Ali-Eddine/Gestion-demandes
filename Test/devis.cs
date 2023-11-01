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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Test
{
    public partial class devis : System.Windows.Forms.Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True");
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
        private void loadCombo()
        {

            string req = "select reference from demande";
            con.Open();
            using (SqlCommand command = new SqlCommand(req, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["reference"].ToString());

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
        private void devis_Load(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
            textBox1.Enabled = false;
            loadData();
            loadCombo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();

            string req = " select article from demande where reference ='" + comboBox1.SelectedItem.ToString() + "'";

            using (SqlCommand command = new SqlCommand(req, con))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            comboBox3.Items.Clear();
                            comboBox3.Items.Add(reader["article"].ToString());

                        }
                    }
                }
            }
            string req2 = "SELECT prix * quantity AS devisOrig " +
                "FROM article a " +
                "JOIN demande d ON a.article = d.article " +
                "WHERE reference = @selectedItem";

            using (SqlCommand command = new SqlCommand(req2, con))
            {
                
                command.Parameters.AddWithValue("@selectedItem", comboBox1.SelectedItem.ToString());

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        label3.Text = reader["devisOrig"].ToString();
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string req2 = "SELECT prix as price " +
                "FROM article a " +
                "JOIN demande d ON a.article = d.article " +
                "WHERE reference = @selectedItem";
            using (SqlCommand command = new SqlCommand(req2, con))
            {
                // Assuming comboBox1.SelectedItem.ToString() contains the reference value
                command.Parameters.AddWithValue("@selectedItem", comboBox1.SelectedItem.ToString());



                // Assuming you want to execute a query and get a result back
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming label3 is a label where you want to display the result
                        int prix = int.Parse(reader["price"].ToString());
                        int quantity = int.Parse(textBox1.Text);
                        int deviOri = int.Parse(label3.Text);
                        int result = deviOri - (prix * quantity);
                        label9.Text = result.ToString();
                        int deviNv = int.Parse(label9.Text);
                        int finalresult = deviOri - deviNv;
                        label6.Text = finalresult.ToString();
                    }
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list_demande = new liste_demandes();
            list_demande.Show();
            this.Hide();
        }
    }
}
