using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Receptionist : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True");
        public Receptionist()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var gestion_admin = new User_Login();
            gestion_admin.Show();
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
        private void Receptionist_Load(object sender, EventArgs e)
        {
            
            checkBox1.Checked = false;
            textBox1.Enabled = false;
            loadData();
            loadCombo();
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
           
            string req = " select article from demande where reference ='"+comboBox1.SelectedItem.ToString()+"'";
           
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
                // Assuming comboBox1.SelectedItem.ToString() contains the reference value
                command.Parameters.AddWithValue("@selectedItem", comboBox1.SelectedItem.ToString());

                

                // Assuming you want to execute a query and get a result back
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Assuming label3 is a label where you want to display the result
                        label3.Text = reader["devisOrig"].ToString();
                    }
                }
               
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                if (checkBox2.Checked)
                {
                    string req = ("update demande set etat='commande recu' where reference ='" + comboBox1.SelectedItem.ToString() + "'");
                    using (SqlCommand cmd = new SqlCommand(req, con))
                    {

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }
    }
}
