Challenge 1 – String and its methods

Now you know the use of various string functions. 
Let’s create a small Console application to practice using the 
string manipulation methods that are included with .NET while getting input from the user
and calling methods.
Feel free to play with different inputs and experiment with the methods. 
You can call the methods in whatever order you want, just make sure the body of the method 
returns the expected result or the test cases will not pass.

TIP: You can ctrl-click any .NET method name to go to the .NET definition of the method within .NET.

Steps:
1. Although there are various string and integer variables declared for you, you will need to declare a few more.
2. Get a string from the user. We are not worried about input validation right now
    so if your user inputs unexpected values, your program will give unexpected results.
3. Print to the console “Please enter your message and press enter”.
4. The user will enter their message.
5. Assign the users entered string to the string variable 'userInputString'.
6. Print to the console "Please enter a number LESS THAN the length of your string and press enter".
7. Assign that entered string to the int variable 'numberLessThanStringLength'. 
    Because Console.ReadLine() returns a string, you will need to parse this string to an int using 'int.parse();' 
    Do this by nesting the Console.ReadLine() inside 'int.Parse()'
    Take the time to read about int.Parse() (and all the methods used here) and how it works by ctrl-click'ing the method name.
8. Call each of the provided methods with the correct arguments, according to the instruction in the XML comments above the 
    method and replace the method body of each with the correct C# syntax to fulfill the requirements of the method. 
    You may need to get some input from the user for the method.
9. Print what is returned from each method to the console. 
    DO NOT print to the console from within the method! This is bad practice and make your code untestable.

