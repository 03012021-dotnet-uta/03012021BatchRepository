using System;
using Xunit;
using System.Collections.Generic;
namespace _3_DataTypeAndVariablesChallenge.Tests
{
    public class ProgramTest
    {
        static byte myByte = 255;
        static sbyte mySbyte = -128;
        static int myInt = 2147483647;
        static uint myUint = 4294967295;
        static short myShort = -32768;
        static ushort myUShort = 65535;
        static float myFloat = -31.1289f;
        static double myDouble = -12.1231250;
        static char myCharacter = 'A';
        static bool myBool = true;
        static string myText = "I control text";
        static string numString = "15";
        static decimal myDecimal = 3.001002003m;
        static long myLong = 9223372036854775807;
        static ulong myUlong = 18446744073709551615;

        public static IEnumerable<object[]> _numbers => new List<object[]>{
            new object[] {myByte, "Data type => byte"},
            new object[] {mySbyte,"Data type => sbyte"},
            new object[] {myInt,"Data type => int"},
            new object[] {myUint,"Data type => uint"},
            new object[] {myShort,"Data type => short"},
            new object[] {myUShort,"Data type => ushort"},
            new object[] {myFloat,"Data type => float"},
            new object[] {myDouble,"Data type => double"},
            new object[] {myCharacter,"Data type => char"},
            new object[] {numString,"Data type => string"},
            new object[] {myDecimal,"Data type => decimal"},
            new object[] {myLong,"Data type => long"},
            new object[] {myUlong,"Data type => ulong"}
        };

        [Theory]
        [MemberData(nameof(_numbers))] // this will give each element of the IEnumberable and run the test for each element in the IEnumberable
        public void PrintValuesShouldReturnType(object o, string s)
        {
            //Arrange
            // This is done above by creating the IEnumerable and feeding it's elements to the Method 

            //Act
            string result = Program.PrintValues(o);

            //Assert
            Assert.Equal<string>(s, result);
        }

        [Theory]
        [InlineData("5")]
        [InlineData("why")]
        public void StringToIntreturnsIntOrNull(string s)
        {
            // Arrange
            // this is done with InlineData()

            // Act
            int? result = Program.StringToInt(s);

            // Assert
            if (s == "5")
            {
                Assert.Equal(5, result);
            }
            else if (s == "why")
            {
                Assert.Equal(null, result);
            }
        }
    }
}
