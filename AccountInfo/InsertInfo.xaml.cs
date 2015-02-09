using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccountInfo
{
  
    public partial class InsertInfo : Window
    {
        public InsertInfo()
        {
            InitializeComponent();
            this.Title = "Insert New Card Details";

        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            BankNamebox.DisplayMemberPath = "Text";
            BankNamebox.SelectedValuePath = "Value";

            List<ComboboxItem> list = new List<ComboboxItem>();

            ComboboxItem item = new ComboboxItem();
            item.Text = "ICICI";
            item.Value = "1";
            list.Add(item);

            item = new ComboboxItem();
            item.Text = "SBI";
            item.Value = "2";
            list.Add(item);

            item = new ComboboxItem();
            item.Text = "AXIS";
            item.Value = "3";
            list.Add(item);

            item = new ComboboxItem();
            item.Text = "HDFC";
            item.Value = "4";
            list.Add(item);

            BankNamebox.ItemsSource = list;
        }
        private void ComboBox_Loaded1(object sender, RoutedEventArgs e)
        {
            CardTypebox.DisplayMemberPath = "Text";
            CardTypebox.SelectedValuePath = "Value";

            List<ComboboxItem> list = new List<ComboboxItem>();

            ComboboxItem item = new ComboboxItem();
            item.Text = "CREDIT";
            item.Value = "1";
            list.Add(item);

            item = new ComboboxItem();
            item.Text = "DEBIT";
            item.Value = "2";
            list.Add(item);
           
            CardTypebox.ItemsSource = list;
        }

        public void InsertDetails()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
              con.Open();
              SqlCommand cmd =
              new SqlCommand("Insert into Bank_Detail (Card_Id,Card_Type,Cvv,UserName,Months,Years,BankName_ID) values(" + Cardnumberbox.Text + ",'" + CardTypebox.Text + "'," + Cvvbox.Text + ",'" + CardNamebox.Text + "'," + Monthbox.Text + "," + yearbox.Text + "," + BankNamebox.SelectedValue.ToString() + ")");
              cmd.Connection = con;
              cmd.ExecuteNonQuery();
            }
        }

        private void AddDetailButton2_Click(object sender, RoutedEventArgs e)
        {
            if (CardNamebox.Text.Length == 0)
            {
                errormessage.Text = "Please enter your name ";
                CardNamebox.Focus();
            }

            else
            {
                  Regex nonNumericRegex = new Regex(@"\D");
                  string CardName = CardNamebox.Text;
                  if (Cardnumberbox.Text.Length != 16)
                  {
                      errormessage.Text = "Please Enter 16 digit card number";
                    
  
                  }
                  
                  else if(nonNumericRegex.IsMatch(Cardnumberbox.Text))
                  {
                      errormessage.Text = "Card Number Must be Numeric";
                  }
                  else 
                  {
                      string CardNumber = Cardnumberbox.Text;
                      if ((Monthbox.Text.Length != 2) || (yearbox.Text.Length != 4))
                      {
                          errormessage.Text = "Please enter a valid Expiry Date";
                      }
                      else if (nonNumericRegex.IsMatch(Monthbox.Text) || nonNumericRegex.IsMatch(yearbox.Text))
                      {
                          errormessage.Text = "Expiry Date requires MM/YYYY format";
                      }
                      else 
                      {
                        string Mbox = Monthbox.Text;
                        string Ybox = yearbox.Text;
                          if (CardTypebox.SelectedIndex < 0)
                          {
                              errormessage.Text = "Please Select Card Type";
                          }
                          else 
                          {
                              if (Cvvbox.Text.Length != 3)
                              { errormessage.Text = "Please Enter 3 digit Cvv Number"; }
                              else if (nonNumericRegex.IsMatch(Cvvbox.Text))
                              {
                                  errormessage.Text = "CVV Number Must be Numeric";
                              }
                              else
                              {
                                  string Cvv = Cvvbox.Text;
                                  StackEnableTouser.IsEnabled = IsEnabled.Equals(false);
                                  InsertDetails();
                                  Reset();
                                  errormessage.Text = "Details Added Successfully";
                              }
                          }
                      }
                  }

                 
            }
        
            
        
          
       
        }

        private void BankNamebox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(BankNamebox.SelectedIndex >= 0)
            {
                StackEnableTouser.IsEnabled = IsEnabled;
                    
            }
         }

        public void Reset()
        {
            BankNamebox.Text = "";
            CardNamebox.Text = "";
            Cardnumberbox.Text = "";
            CardTypebox.Text = "";
            Cvvbox.Text = "";
            Monthbox.Text = "";
            yearbox.Text = "";
        }
    }
}