using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Utilities.AuthorizeHelpers
{
    public class HashingHelper
    {
        public static string CreatePasswordHash(string password)
        {
            using MD5 md5 = MD5.Create();

            byte[] input = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(input);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            };
            return sb.ToString();
        }
        public static bool VerifyPasswordHash(string loginPassword, string existingPassword)
        {
            for (int i = 0; i < existingPassword.Length; i++)
            {
                if (loginPassword[i] != existingPassword[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static string CreateRefrehToken(string userName)
        {
            var random = new Random();
            using MD5 md5 = MD5.Create();

            StringBuilder randomString = new StringBuilder();

            for (int i = 0; i < random.Next(10, 20); i++)
            {
                randomString.Append(userName[random.Next(userName.Length)]);
            }

            byte[] input = Encoding.ASCII.GetBytes(randomString.ToString());
            byte[] hash = md5.ComputeHash(input);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            };
            return sb.ToString();
        }
    }
}
