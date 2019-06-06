using EFGHermes.Calculator.Client.CalculatorServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFGHermes.Calculator.Client
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public Calculator(string username, string password) : this()
        {
            this.Username = username;
            this.Password = password;
        }

        private void BtnNum1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "1";
        }

        private void TxtDisplay_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtDisplay.Text, "^\\d*(\\.\\d+)?[\\+\\-\\*\\/]\\d*(\\.\\d+)?$"))
            {
                var expression = txtDisplay.Text.Split(new char[] { '+', '*', '/', '-' });
                double x = double.Parse(expression[0]);
                double y = double.Parse(expression[1]);
                double result;
                using (CalculatorServiceClient client = new CalculatorServiceClient("Username"))
                {
                    client.ClientCredentials.UserName.UserName = Username;
                    client.ClientCredentials.UserName.Password = Password;
                    try
                    {
                        if (txtDisplay.Text.Contains('+'))
                        {
                            result = client.Sum(x, y);
                        }
                        else if (txtDisplay.Text.Contains('-'))
                        {
                            result = client.Subtract(x, y);
                        }
                        else if (txtDisplay.Text.Contains('*'))
                        {
                            result = client.Multiply(x, y);
                        }
                        else
                        {
                            result = client.Divide(x, y);
                        }
                        txtDisplay.Text = result.ToString();
                    }
                    catch (Exception)
                    {
                        txtDisplay.Text = "Unauthorized operation";
                    }
                }
            }
            else
            {
                txtDisplay.Text = "Invalid expression";
            }
        }

        private void BtnNum2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "2";
        }

        private void BtnNum3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "3";
        }

        private void BtnNum4_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "4";
        }

        private void BtnNum5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "5";
        }

        private void BtnNum6_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "6";
        }

        private void BtnNum7_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "7";
        }

        private void BtnNum8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "8";
        }

        private void BtnNum9_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "9";
        }

        private void BtnNum0_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "0";
        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "+";
        }

        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "-";
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "*";
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "/";
        }
    }
}
