using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

        /// <summary>
        /// Thie method takes a password string and byte[] representing the hashKey(salt)
        /// and returns a byte[] of the hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public byte[] HashThePassword(string password, byte[] key)
        {
            using HMACSHA512 hmac = new HMACSHA512(key: key);// you can assign the key manually instead of using the auto-generated one that comes with the HMAC instance.

            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hashedPassword;
        }

        public async Task<byte[]> ConvertMemeIformfileToByteArrayAsync(IFormFile meme)
        {
            byte[] memeBytes;
            // convert the iformfile to a byte array.
            using (MemoryStream ms = new MemoryStream())
            {
                //this section to for converting to a byte Array
                await meme.CopyToAsync(ms); // copy the contents of the file to the memoryStream obj
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

        public StringPersonDTO ConvertPersonToStringPerson(Person person)
        {
            StringPersonDTO stringPerson = new StringPersonDTO()
            {
                Fname = person.Fname,
                Lname = person.Lname,
                MemberSince = person.MemberSince,
                PasswordHash = Convert.ToBase64String(person.PasswordHash, 0, person.PasswordHash.Length),
                PersonId = person.PersonId.ToString(),
                UserName = person.UserName
            };
            return stringPerson;
        }

        public MemeDTO ConvertMemeToMemeDto(Meme meme)
        {
            MemeDTO memeDto = new MemeDTO()
            {
                MemeId = meme.MemeId,
                MemeString = ConvertByteArrayToImageString(meme.MemeByteArray),
                PersonId = meme.PersonId,
                UploadDate = meme.UploadDate
            };
            return memeDto;
        }

    }// end of class
}// end of namespace