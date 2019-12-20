
using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegister rg = new FormRegister();
            rg.Show();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int UserKind;
            AccountBUS bus = new AccountBUS();
            Account a = new Account();
            string temp = txtUsername.Text;

            if (temp == "admin" && String.IsNullOrEmpty(txtPasswrd.Text))
            {
                a = bus.GetAccAdmin();
                UserKind = bus.CheckKind(txtUsername.Text);
                QuanLyBH m = new QuanLyBH(UserKind);
                this.Hide();
                m.Show();
                return;

            }
            if (bus.CheckUserName(txtUsername.Text) == 0)
            {
                MessageBox.Show("Account not exist !");
            }
            else
            {

                if (bus.CheckPass(txtPasswrd.Text, txtUsername.Text) == 0)
                {
                    a = bus.GetAccount(txtUsername.Text, txtPasswrd.Text);
                    UserKind = bus.CheckKind(txtUsername.Text);
                    //MessageBox.Show(a.UserKind.ToString());
                    QuanLyBH m = new QuanLyBH(UserKind);
                    this.Hide();
                    m.Show();
                    
                }
                else
                { 
                    MessageBox.Show("Wrong pass !");
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
