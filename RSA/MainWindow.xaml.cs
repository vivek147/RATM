using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace RSA
{

    public partial class MainWindow : Window
    {
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
    
        byte[] plaintext;
        byte[] encryptedtext; 
        string PasswordE;

        string PasswordD;
 
        byte[] compare;

        public MainWindow()
        {
              InitializeComponent();
              EncryptPassword("Vivek");

              compare = ByteConverter.GetBytes(PasswordE);

              DecryptPassword(compare);

     

        }

        public void EncryptPassword(String Password)
        {
            plaintext = ByteConverter.GetBytes(Password);
            encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
            PasswordE = ByteConverter.GetString(encryptedtext);

     
        }
       


        public void DecryptPassword(byte[] EncryptedPassword)
        {
            byte[] decryptedtex = Decryption(EncryptedPassword, RSA.ExportParameters(true), false);
            PasswordD = ByteConverter.GetString(decryptedtex);
           
        }


     
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                } return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }




        //function for Decryption

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

    
    }
}
