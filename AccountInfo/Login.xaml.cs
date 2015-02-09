using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Security.Cryptography;


namespace AccountInfo
{

    public partial class Login : Window
    {
        public Login()
        {   
            InitializeComponent();
        }
        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

 
        private void button1_Click(object sender, RoutedEventArgs e)
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
                   string password = passwordBox1.Password;
                   byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
                   string decryptedPassword = Convert.ToBase64String(b);   
  
                //string encryptedPassword = .HashPasswordForStoringInConfigFile(passwordBox1.Text, "SHA1");

                                           
                string email = textBoxEmail.Text;
                
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Registration where Email='" + email + "'  and password='" + decryptedPassword + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    MainWindow welcome = new MainWindow();
                    string username = dataSet.Tables[0].Rows[0]["Email"].ToString() ;
                    
                    welcome.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "Sorry! Please enter existing emailid/password.";
                }
                con.Close();
            }
        }
 
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            Registration registration = new Registration();
         
            registration.Show();
            Close();
            
        }
 
    }
}