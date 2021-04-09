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
        public async Task<ActionResult<Person>> RegisterAsync(RawPerson rawperson)
        {
            Person person = new Person();
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                // return StatusCode(409, $"User '{rawPerson.UserName}' already exists.");
                return StatusCode(400, "That was a failure of modelbinding");
            }
            else
            {
                // here you will use the bussiness logic layer instance to pass the data to that layer and eventually save it to the Db.
                //Console.WriteLine($"{rawperson.Fname}, {rawperson.Lname}");
                person = await _business.RegisterAsync(rawperson);
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
        public async Task<ActionResult<StringPersonDTO>> LoginAsync(string username, string password)
        {
            // return new string[] { "Mark", "Moore" };
            //here we will do mich the same as in the register.....
            StringPersonDTO person = new StringPersonDTO();
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                // return StatusCode(409, $"User '{rawPerson.UserName}' already exists.");
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else
            {
                // here you will use the bussiness logic layer instance to pass the data to that layer and eventually save it to the Db.
                //Console.WriteLine($"{rawperson.Fname}, {rawperson.Lname}");
                person = await _business.LoginAsync(username, password);
            }

            //check if person is null!!!
            if (person == null)
            {
                return StatusCode(409, "We're sorry, your username was not found.");
            }

            // convert the person to a StringPerson


            return person;
        }

        [HttpPost("editprofile")]
        public async Task<ActionResult<bool>> EditProfileAsync([FromBody] EditPerson editPerson)
        {
            //Console.WriteLine($"\n\nEditPerson is {editPerson.Fname}, {editPerson.Lname}, {editPerson.NewPassword}, {editPerson.NewUsername}, {editPerson.Username}, {editPerson.PasswordHash}\n\n");
            //return new EmptyResult();
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                // return StatusCode(409, $"User '{rawPerson.UserName}' already exists.");
                return StatusCode(400, "That was a failue of modelbinding");
            }

            bool changed = await _business.EditpersonAsync(editPerson);
            if (changed)
            {
                return true;
            }

            return false;
        }

        [HttpPost("memeupload")]
        public async Task<ActionResult<bool>> MemeuploadAsync([FromForm] Guid personId, [FromForm] IFormFile meme)
        {
            bool success = await _business.AddMemeAsync(personId, meme);
            if (!success)
            {
                return BadRequest();
            }
            return success;
        }

        [HttpGet("memes")]
        public async Task<ActionResult<ICollection<MemeDTO>>> MemesAsync()
        {
            ICollection<MemeDTO> memes = await _business.MemesAsync();
            return Ok(memes);
        }

        [HttpGet("allpersons")]
        public async Task<ActionResult<StringPersonDTO>> GetAllPeopleAsync()
        {
            //best practice is to check the value at each step to make sure you have a value and that it is in range.
            List<StringPersonDTO> people = await _business.GetAllPeopleAsync();
            return Ok(people);
        }

        [HttpGet("getpersonbyid/{personId}")]
        public async Task<ActionResult<StringPersonDTO>> GetPersonByIdAsync(string personId)
        {
            StringPersonDTO stringPerson = await _business.GetPersonByIdAsync(personId);
            return Ok(stringPerson);
        }

        [HttpGet("allmemes")]
        public async Task<ActionResult<StringPersonDTO>> GetAllMemesAsync()
        {
            //best practice is to check the value at each step to make sure you have a value and that it is in range.
            List<MemeDTO> memes = await _business.GetAllMemesAsync();
            return Ok(memes);
        }

        [HttpGet("getmemebyid/{memeId}")]
        public async Task<ActionResult<StringPersonDTO>> GetMemeByIdAsync(string memeId)
        {
            MemeDTO memeDTO = await _business.GetMemeByIdAsync(memeId);
            return Ok(memeDTO); 
        }

    }//end of class
}//end of namespace
