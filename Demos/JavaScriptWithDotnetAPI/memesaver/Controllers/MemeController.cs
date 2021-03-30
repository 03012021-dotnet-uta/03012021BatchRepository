using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
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

        // GET api/<MemeController>/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST api/<MemeController>
        [HttpPost]
        // [Route("/postrequest")]
        public Person Post([FromBody] Person obj)
        {
            Console.WriteLine($"YAY! we made it to the C# side with {obj.Fname}, {obj.Lname}. ");
            //call a method in the business logic layer.
            //the business logic layer implements business requirements. Thisi s where the majority of 
            // the data manipulation will be.
            Person obj1 = _business.Login(obj);

            return obj1;
        }

    }
}
