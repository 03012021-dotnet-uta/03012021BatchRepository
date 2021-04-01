using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace memesaver
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemeController : ControllerBase
    {
        private readonly UserMethods _business;
        public MemeController(UserMethods business)
        {
            this._business = business;
        }

        [HttpPost("register")]
        public ActionResult<Person> Register(RawPerson rawperson)
        {
            Person person = new Person();
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                // return StatusCode(409, $"User '{rawPerson.UserName}' already exists.");
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else
            {
                // here you will use the bussiness logic layer instance to pass the data to that layer and eventually save it to the Db.
                //Console.WriteLine($"{rawperson.Fname}, {rawperson.Lname}");
                person = _business.Register(rawperson);
            }

            //check if person is null!!!
            if (person == null)
            {
                return StatusCode(409, "We're sorry, your new user was not successfully saved or a user of that username already exists.");
            }
            return person;
        }

        // THIS IS AN ACTION METHOD
        // GET: api/<MemeController>
        [HttpGet("login/{username}/{password}")]
        public ActionResult<Person> Login(string username, string password)
        {
            // return new string[] { "Mark", "Moore" };
            //here we will do mich the same as in the register.....
            Person person = new Person();
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                // return StatusCode(409, $"User '{rawPerson.UserName}' already exists.");
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else
            {
                // here you will use the bussiness logic layer instance to pass the data to that layer and eventually save it to the Db.
                //Console.WriteLine($"{rawperson.Fname}, {rawperson.Lname}");
                person = _business.Login(username, password);
            }

            //check if person is null!!!
            if (person == null)
            {
                return StatusCode(409, "We're sorry, your username was not found.");
            }
            return person;
        }

        [HttpPost("editprofile")]
        public ActionResult<bool> EditProfile([FromBody] EditPerson editPerson)
        {
            //Console.WriteLine($"\n\nEditPerson is {editPerson.Fname}, {editPerson.Lname}, {editPerson.NewPassword}, {editPerson.NewUsername}, {editPerson.Username}, {editPerson.PasswordHash}\n\n");
            //return new EmptyResult();

            _business.Editperson(editPerson);

            return true;
        }

        [HttpPost("memeupload")]
        public ActionResult<string> Memeupload([FromForm] Guid personId, [FromForm] IFormFile meme)
        {
            // do everything here and return the string for demo purposes
            //is the meme empty?
            if (meme.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //this section to for converting to a byte Array
                    meme.CopyTo(ms); // copy thre contents of the file to the ememoryStream obj
                    byte[] memeBytes = ms.ToArray();// convert the memory dstrezm to a byte array


                    // this section is for convertying from a byte array to a string
                    string memeString = Convert.ToBase64String(memeBytes, 0, memeBytes.Length); //                
                    string imageDataString = string.Format($"data:image/jpg;base64,{memeString}");
                    return imageDataString;
                }
            }
            return StatusCode(401, "That was a failure of image handling");

        }


    }//end of class
}//end of namespace
