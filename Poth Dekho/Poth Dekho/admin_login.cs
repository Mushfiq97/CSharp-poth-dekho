using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Poth_Dekho
{
    public partial class admin_login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbrrs"].ConnectionString;

        Thread th;

        public admin_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from AdminReg where username = @user and password = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ResetControl();
                    this.Close();
                    th = new Thread(openadmindashboard);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                {
                    MessageBox.Show("Username or Password is Invalid", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ResetControl();
                }

                con.Close();

            }
            else
            {
                MessageBox.Show("Fill the textFiled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
            private void openadmindashboard()
            {
                Application.Run(new admin_dashboard());

            }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home f = new home();
            f.Show();
        }
    }
}
