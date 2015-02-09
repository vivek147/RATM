using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountInfo
{
   public class RSAEncryption
   {
        
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;
        string PasswordED;

        public void EncryptPassword(String Password)
        {
            plaintext = ByteConverter.GetBytes(Password);
            encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
            Password = ByteConverter.GetString(encryptedtext);
          
        }

        public void DecryptPassword(String EncryptedPassword)
        {
            byte[] EncryptedPass  = ByteConverter.GetBytes(EncryptedPassword);
            byte[] decryptedtex = Decryption(EncryptedPass, RSA.ExportParameters(true), false);
            PasswordED = ByteConverter.GetString(decryptedtex);

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
