using EFGHermes.Calculator.Client.CalculatorServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFGHermes.Calculator.Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            CalculatorServiceClient client = new CalculatorServiceClient("Username");
            try
            {
                client.ClientCredentials.UserName.UserName = txtUsername.Text;
                client.ClientCredentials.UserName.Password = txtPassword.Text;
                client.Open();
                client.Login();
                Form form = new Calculator(txtUsername.Text, txtPassword.Text);
                this.Hide();
                form.Show();
                client.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.InnerException.Message);
                client.Abort();
            }
        }
    }
}

