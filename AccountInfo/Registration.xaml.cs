﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
 
namespace AccountInfo
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            this.Title = "Let's Register for Credentials Management System";
        }

        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
           Login login = new Login();
           //Registration res = new Registration();
           
           Close();
           login.Show();
            
        }

 
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
 
        public void Reset()
        {
            textBoxEmail.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
 
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "Confirm password must be same as password.";
                    passwordBoxConfirm.Focus();
                }

                else
                {
                    errormessage.Text = "";
                   
               
                    byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
                    string encryptedPassword = Convert.ToBase64String(b);   

                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(CS);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Registration (Email,Password) values('" + email + "','" + encryptedPassword + "' )", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    errormessage.Text = "You have Registered successfully.";
                    Reset();
                }
            }
        }

        private void textBoxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            string email = textBoxEmail.Text;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Registration where Email='" + email + "' ", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                string username = dataSet.Tables[0].Rows[0]["Email"].ToString();
                errormessage.Text = "email already exists.";
            }
        }

       
    
    }
}
    