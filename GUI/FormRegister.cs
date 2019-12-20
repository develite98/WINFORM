using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using DTO;
using BUS;

namespace GUI
{
    public partial class FormRegister : Form
    {

        public FormRegister()
        {
            InitializeComponent();
        }

        

        
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text == string.Empty)
                errorUsername.SetError(txtUsername, "Username is empty");
            else if (txtUsername.Text.Any(char.IsUpper) || txtUsername.Text.Any(char.IsWhiteSpace))
                errorUsername.SetError(txtUsername, "Have upper character or white space in username!");
            else
                errorUsername.Clear();
        }


        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == string.Empty)
                errorPassword.SetError(txtPassword, "Password is empty");
            else if (txtPassword.Text.Any(char.IsUpper) || txtPassword.Text.Any(char.IsWhiteSpace) || txtPassword.Text.Length<=3)
                errorPassword.SetError(txtPassword, "Have upper character or white space or do not touch required lenght!");
            else
                errorPassword.Clear();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == string.Empty)
                errorName.SetError(txtName, "Name is empty");
            else if (txtName.Text.Substring(0, 1).Any(char.IsLower))
                errorName.SetError(txtName, "Name must start with upper charater!");
            else
                errorName.Clear();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (txtEmail.Text == string.Empty)
                errorEmail.SetError(txtEmail, "Email is empty");
            else if (Regex.IsMatch(txtEmail.Text, pattern))
                errorEmail.Clear();
            else
                errorEmail.SetError(txtEmail, "Email not correct !");
        }

        private void txtDbo_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");
            bool iValid = regex.IsMatch(txtDbo.Text.Trim());
            DateTime dt;
            iValid = DateTime.TryParseExact(txtDbo.Text, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            if (!iValid)
            {
                errorDBO.SetError(txtDbo, "Datetime not correct !");
            }
            if (iValid)
                errorDBO.Clear();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            AccountBUS bus = new AccountBUS();
            var obj = new Account
            {
                UserName = txtUsername.Text,
                Password=txtPassword.Text,
                Name=txtName.Text,
                Email=txtEmail.Text,
                DOB=DateTime.ParseExact(txtDbo.Text,"dd/MM/yyyy",CultureInfo.CurrentUICulture.DateTimeFormat)
            };
            if (bus.ThemAccount(obj))
            {
                MessageBox.Show("Create Successfully");
            }
            else
            {
                MessageBox.Show("Create User Faild");
            }
            this.Close();
        }

    }
}
