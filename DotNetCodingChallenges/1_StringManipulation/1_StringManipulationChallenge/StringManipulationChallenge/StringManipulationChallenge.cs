using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInputString; //this will hold your users message
            int numberLessThanStringLength; // this will hold the number from steps 6 and 7
            int elementNum;         //this will hold the element number within the messsage that your user indicates
            char char1;             //this will hold the char value that your user wants to search for in the message.
            string fName;           //this will hold the users first name
            string lName;           //this will hold the users last name
            string userFullName;    //this will hold the users full name;


            Console.WriteLine("Please enter your message and press enter");
            userInputString = Console.ReadLine();//***We are not worrying about validation right now.***


            Console.WriteLine("Please enter a number LESS THAN the length of your string and press enter");
            elementNum = int.Parse(Console.ReadLine());//***We are not worrying about validation right now.***


            //now call each method.
            string s1 = StringToUpper(userInputString);
            System.Console.WriteLine($"Your message in upper case is '{s1}'");


            string s2 = StringToLower(userInputString);
            System.Console.WriteLine($"Your message in lower case is '{s2}'");


            string s3 = StringTrim(userInputString);
            System.Console.WriteLine($"Your message trimmed of beginning and ending whitespace is '{s3}'");


            string s4 = StringSubstring(userInputString, elementNum);
            System.Console.WriteLine($"The substring of your message starting with the {elementNum} element is '{s4}'");


            Console.WriteLine($"For which character should I search in your original message, '{userInputString}'?");
            char1 = Console.ReadLine()[0];
            int charElement = SearchChar(userInputString, char1);
            Console.WriteLine($"Index of {char1} is {charElement}");


            Console.WriteLine("Please enter your first name.");
            fName = Console.ReadLine();
            Console.WriteLine("Please enter your last name.");
            lName = Console.ReadLine();
            userFullName = ConcatNames(fName, lName);
            Console.WriteLine($"Your first and Last names together are '{userFullName}'");


        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all upper case, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringToUpper(string x)
        {
            string y = x.ToUpper();
            Console.WriteLine($"From the StringToUpper method '{y}'");
            return y;
        }

        // This method has one string parameter. 
        // It will:
        // 1) change the string to all lower case, 
        // 2) print the result to the console and 
        // 3) return the new string.        
        public static string StringToLower(string x)
        {
            string y = x.ToLower();
            Console.WriteLine($"From the StringToLower method '{y}'");
            return y;
        }

        // This method has one string parameter. 
        // It will:
        // 1) trim the whitespace from before and after the string, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringTrim(string x)
        {
            string y = x.Trim();
            Console.WriteLine($"From the StringTrim method '{y}'");
            return y;
        }

        // This method has two parameters, one string and one integer. 
        // It will:
        // 1) get the substring based on the integer received, 
        // 2) print the result to the console and 
        // 3) return the new string.
        public static string StringSubstring(string x, int elementNum)
        {
            string y = x.Substring(elementNum);
            Console.WriteLine($"From the StringSubstring method '{y}'");
            return y;
        }

        // This method has two parameters, one string and one char.
        // It will:
        // 1) search the string parameter for the char parameter
        // 2) return the index of the char.
        public static int SearchChar(string userInputString, char x)
        {
            int searchInput = userInputString.IndexOf(x);
            Console.WriteLine($"From the SearchChar method '{searchInput}'");
            return searchInput;
        }

        // This method has two string parameters.
        // It will:
        // 1) concatenate the two strings with a space between them.
        // 2) return the new string.
        public static string ConcatNames(string fName, string lName)
        {
            string userFullName = string.Concat(fName, " ", lName);//you can enter more than just 2 strings to concatenate.
            Console.WriteLine($"From the ConcatNames method '{userFullName}'");
            return userFullName;
        }



    }//end of program
}
