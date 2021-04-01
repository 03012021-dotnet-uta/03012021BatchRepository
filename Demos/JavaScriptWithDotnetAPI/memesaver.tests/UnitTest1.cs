using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using models;
using Repository;
using Xunit;

namespace memesaver.tests
{
    public class UnitTest1
    {

        DbContextOptions<memeSaverContext> testOptions = new DbContextOptionsBuilder<memeSaverContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;


        [Fact]
        public void ContextRegisterAddsANewUserToTheDb()
        {
            // ARRANGE - create the data to insert into the Db
            //create the new Person seed
            Person testPerson = new Person()
            {
                Fname = "Mark",
                Lname = "Moore",
                UserName = "user1",
            };
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                testPerson.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("testPassword"));//this returns a byte[] representing the password
                testPerson.PasswordSalt = hmac.Key;     // this assigns the randomly generated Key (comes with the HMAC instance) to the salt variable of the user instance,
            }
            Person resultPerson1 = new Person();//to store the return from memeSaverRepo.Register()
            Person resultPerson2 = new Person();//to store the return from memeSaverRepo.Register()

            using (var context1 = new memeSaverContext(testOptions))
            {
                context1.Database.EnsureDeleted();//do this ONCE at hte beginning of each test
                context1.Database.EnsureCreated();// this creates the new-for-this-test database

                //create the MemeSaverRepo instance
                MemeSaverRepo msr = new MemeSaverRepo(context1);
                resultPerson1 = msr.Register(testPerson);
                context1.SaveChanges();
            }

            // ACT - call the method that inserts into the Db
            using (var context2 = new memeSaverContext(testOptions))
            {
                context2.Database.EnsureCreated();
                resultPerson2 = context2.Persons.Where(x => x.PasswordHash == testPerson.PasswordHash).FirstOrDefault();
            }

            // ASSERT - verify the the data state is as expected
            Assert.Equal(resultPerson1.Fname, resultPerson2.Fname);
        }



        [Fact]
        public void LoginReturnsTheConcatNames()
        {
            // // Arrange
            // var repoClass = new MemeSaverRepo();//create a repo class.
            // var businessClass = new UserMethods(repoClass);// this class uses the repos class methods so it needs tso be created with the repo class injected.

            // Person p = new Person()
            // {
            // 	Fname = "Mark",
            // 	Lname = "Moore"
            // };

            // // Act
            // //Person actual = businessClass.Login(p);
            // Person actual = businessClass.Login(p);

            // // Assert - you can assert as many times as you want but it only counts as one test.
            // Assert.Equal("MarkMooreJerry", actual.Fname);
            // Assert.Equal("MooreMarkMooreWalker", actual.Lname);
        }
    }
}
