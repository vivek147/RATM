using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace AccountInfo
{

    public partial class MainWindow : Window
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public long? Old_ID;
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Check Your Card Details";
        }
       
       
       private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            bind();
        }
      
        public void bind()
       {
           errormessage.Text = "";
           string q = "select Id,BankName from Bank_Name";
           string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
           SqlDataAdapter da = new SqlDataAdapter(q,CS);
           DataSet ds = new DataSet();
           da.Fill(ds,"Bank_Name");
           Cmb1.ItemsSource = ds.Tables[0].DefaultView;
           Cmb1.DisplayMemberPath = ds.Tables[0].Columns["BankName"].ToString();
           Cmb1.SelectedValuePath = ds.Tables[0].Columns["Id"].ToString(); 
       }
      
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
            stack2.Visibility = Visibility.Collapsed;
             List<string> list = new List<string>();
             list.Add("CREDIT");
             list.Add("DEBIT");
           
           
            if (Cmb1.SelectedIndex >= 0)
             {
                Cmb2.Visibility = Visibility.Visible;
                Cmb2.ItemsSource = list; 
             }
            if (Cmb2.SelectedIndex >= 0)
            {
                string str = this.Cmb2.Items[this.Cmb2.SelectedIndex].ToString();
                string id = Cmb1.SelectedValue.ToString();

                LoadGrid(id, str);
                stack2.Visibility = Visibility.Visible;
            }
            
        }

        private void Cmb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
            string str = this.Cmb2.Items[this.Cmb2.SelectedIndex].ToString();
            string id = Cmb1.SelectedValue.ToString();
                  
            LoadGrid(id,str);
            stack2.Visibility = Visibility.Visible;
              
        }

        private void LoadGrid(string str1, string p)
        {
            errormessage.Text = "";
            ArrayList lidb = new ArrayList();

            using (SqlConnection con = new SqlConnection(CS))
            {
             SqlCommand cmd =
             new SqlCommand("select Card_Type,Card_Id,Cvv,UserName,Months,Years from Bank_Detail where BankName_ID = @str and Card_Type = @p", con);
             cmd.Parameters.AddWithValue("@str",str1);
             cmd.Parameters.AddWithValue("@p", p);
             con.Open();
             SqlDataReader rdr = cmd.ExecuteReader();
              
                while (rdr.Read())
                {
                   MyBankDetails mDetail = new MyBankDetails(); 
                   mDetail.CARD_TYPE = (string)rdr[0];
                   mDetail.CARD_NUMBER   = (long)rdr[1];
                   mDetail.CVV_NUMBER = (long)rdr[2];
                   mDetail.CARDNAME = (string)rdr[3];
                   mDetail.EXPIRYM = (int)rdr[4];
                   mDetail.EXPIRYY = (int)rdr[5];
                   lidb.Add(mDetail);
                }
            }
           
            
            Grid1.ItemsSource = lidb;
        }

    
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            InsertInfo Info = new InsertInfo();
            Info.Show();
        }
    
        // To delete the data
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MyBankDetails customerRow = Grid1.SelectedItem as MyBankDetails;


            if (customerRow == null)
            {
              errormessage.Text ="Please Select item to delete" ;
            }
            else
            {
                errormessage.Text = "";
            long ID = customerRow.CARD_NUMBER;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd =
                new SqlCommand("delete from Bank_Detail where Card_Id = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                int val = cmd.ExecuteNonQuery();
                errormessage.Text = "item Deleted successfully";
                string str = this.Cmb2.Items[this.Cmb2.SelectedIndex].ToString();
                string id = Cmb1.SelectedValue.ToString();

                LoadGrid(id, str);

                errormessage.Text = "Item Deleted";
            }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            MyBankDetails customerRow = Grid1.SelectedItem as MyBankDetails;

            if (customerRow == null)
            {
                errormessage.Text = "Please Select item to be Updated";
            }
            else
            {
                errormessage.Text = "";
                long New_ID = customerRow.CARD_NUMBER;
                long Cvv = customerRow.CVV_NUMBER;
                string Name = customerRow.CARDNAME;
                int ExM = customerRow.EXPIRYM;
                int ExY = customerRow.EXPIRYY;
                using (SqlConnection con = new SqlConnection(CS))
                {


                    SqlCommand cmd =
                    new SqlCommand("update Bank_Detail Set Cvv=@Cvv , Card_Id =@New_ID ,UserName=@Name,Months=@ExM,Years=@ExY where Card_Id = @Old_ID", con);
                    cmd.Parameters.AddWithValue("@Old_ID", Old_ID);
                    cmd.Parameters.AddWithValue("@New_ID", New_ID);
                    cmd.Parameters.AddWithValue("@Cvv", Cvv);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@ExM", ExM);
                    cmd.Parameters.AddWithValue("@ExY", ExY);
                    con.Open();
                    int val = cmd.ExecuteNonQuery();
                    errormessage.Text = "item Updated successfully";

                    string str = this.Cmb2.Items[this.Cmb2.SelectedIndex].ToString();
                    string id = Cmb1.SelectedValue.ToString();

                    LoadGrid(id, str);

                }
            }
         
        }

        private void SeIndexChanged(object sender, SelectionChangedEventArgs e)
        {
           
            MyBankDetails customerRow = Grid1.SelectedItem as MyBankDetails;
         
            if(customerRow != null)
             { 
             Old_ID = customerRow.CARD_NUMBER;
             }
           
        }

        
    }
}
