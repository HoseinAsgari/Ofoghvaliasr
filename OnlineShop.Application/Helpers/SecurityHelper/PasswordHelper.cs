using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Helpers.SecurityHelper
{
    public class PasswordHelper
    {
        public static Task<string> EncodePasswordMd5(string pass) //Encrypt using MD5   
        {
            return Task.Run(() =>
            {
                byte[] originalBytes;
                byte[] encodedBytes;
                MD5 md5;
                //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
                md5 = new MD5CryptoServiceProvider();
                originalBytes = Encoding.Default.GetBytes(pass);
                encodedBytes = md5.ComputeHash(originalBytes);
                //Convert encoded bytes back to a 'readable' string   
                return BitConverter.ToString(encodedBytes);
            });
        }

        public static Task<string> EncodePasswordSha256(string pass) //Encrypt using Sha256   
        {
            return Task.Run(() =>
            {
                return BitConverter.ToString(SHA256.HashData(Encoding.UTF8.GetBytes(pass)));
            });
        }
    }
}
