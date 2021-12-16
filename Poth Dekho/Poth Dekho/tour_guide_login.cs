using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace Poth_Dekho
{
    public partial class tour_guide_login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbrtrs"].ConnectionString;

        Thread th;
        public tour_guide_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from TourGuideReg where UserName = @user and Password = @pass";
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
                    th = new Thread(opentourguidedashboard);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                }
                else
                {
                    MessageBox.Show("Username or Password is Invalid", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Fill the textFiled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void opentourguidedashboard()
        {
            Application.Run(new tourguide_dashboard());

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opentourguidereg);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void opentourguidereg(object obj)
        {
            Application.Run(new tourguide_reg());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            home f = new home();
            f.Show();
        }
    }
}
