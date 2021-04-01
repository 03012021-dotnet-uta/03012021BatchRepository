using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using models;

namespace BusinessLogic
{
    public class Mapper
    {
        /// <summary>
        /// this override method takes a user inputted password and returns a unique hash for it
        /// /// </summary>
        /// <returns></returns>
        public Person GetANewPersonWithHashedPassword(string passwordString)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                Person user = new Person()
                {
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordString)),//this returns a byte[] representing the password
                    PasswordSalt = hmac.Key     // this assigns the randomly generated Key (comes with the HMAC instance) to the salt variable of the user instance,
                };
                return user;
            }
        }

        public byte[] HashTheUsername(string password, byte[] key)
        {
            using HMACSHA512 hmac = new HMACSHA512(key: key);// you can assign the key manually instead of using the auto-generated one that comes with the HMAC instance.

            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hashedPassword;
        }

        public byte[] ConvertMemeIformfileToByteArray(IFormFile meme)
        {
            byte[] memeBytes;
            // convert the iformfile to a byte array.
            using (MemoryStream ms = new MemoryStream())
            {
                //this section to for converting to a byte Array
                meme.CopyTo(ms); // copy the contents of the file to the memoryStream obj
                memeBytes = ms.ToArray();// convert the memory stream to a byte array
            }
            return memeBytes;
        }

        public string ConvertByteArrayToImageString(byte[] byteArray)
        {
            string memeString = Convert.ToBase64String(byteArray, 0, byteArray.Length); //                
            string imageDataString = string.Format($"data:image/jpg;base64,{memeString}");
            return imageDataString;
        }



    }// end of class
}// end of namespace