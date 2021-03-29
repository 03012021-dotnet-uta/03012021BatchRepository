using System;
using BusinessLogic;
using models;
using Repository;
using Xunit;

namespace memesaver.tests
{
    public class UnitTest1
    {
        [Fact]
        public void QuadrupleTheIntReturnsQuadrupleTheInt()
        {
            // // arrange
            // var businessClass = new UserMethods();
            // int x = 4;

            // // act
            // int result = businessClass.QuadrupleTheInt(x);

            // // assert
            // Assert.Equal(4 * 4, result);
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
