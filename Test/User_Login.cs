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
    public partial class User_Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2G3VOJ3;Initial Catalog=db_Medexp;Integrated Security=True");
        public User_Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void Admin_login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password;

            username = txt_username.Text;
            password= txt_password.Text;
            
            try
            {
                String req = "select * from users where user_login='" + txt_username.Text + "' and password='" + txt_password.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(req, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    String role = reader["user_role"].ToString();

                    if (role == "admin")
                    {
                        var admin_menu = new Admin_menu();
                        admin_menu.Show();
                        this.Hide();
                    }
                    else if (role == "demandeur")
                    {
                        var demandeur = new Demandeurs();
                        demandeur.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Le nom d'utilisateur ou le mot de passe sont incorrectes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
