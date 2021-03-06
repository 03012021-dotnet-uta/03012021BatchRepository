// console.log("Mark said, \"Hello, JavaScript\".")

/***Mark
 * Said 
 * this
 * is
 * a 
 * block
 *  comment
 */

"use strict";
/**use strict eliminatres some silent errors so that you correct things before deployment
 * Fix some mistakes that allows optimizations
 * Prohibits some syntax that is as of right now not official BUT may become so later on.
 * Eliminates Hoisting? NOOOO. It modifies Hoisting.
 */
var varNum = 1;
console.log(varNum);

const constNum = 2;
// varNum = 6;// you cannot change a const variable
// console.log(varNum);

let letNum = 3;
letNum = 'Marks string';// you can change a let variable to a different type.
console.log(letNum);
console.log(letNum.toUpperCase()); //call a METHOD on the string data type


//this is a function declaration
function marksFunction() {
  console.log('This is as parameterless function');
}

marksFunction();//yo call the funciton by it's name with the () behind it.

function marks2ndFunction(string) {
  console.log(string.toUpperCase());// use the toUpperCase() method on the string data type
}
marks2ndFunction('this is a upper case string');

/**Function Expressions 
 * this is a function used as an expression  (like 5+3)
 * and assigned to a variable 
 * that then is invoked as the function
*/
let myFunction = function (num) {
  // return num ** 2;
  return Math.pow(num,3);
}

let myCubed = myFunction(10);// invoke the function using ()
console.log(myCubed);
console.log(myFunction(Math.floor(10.346792757287)));//you can invoke the function inside asnother function

/**lambda syntax AKA arrow functions */
let myFunction2 = (arg1, arg2) => {
  arg1 += arg2; //equivalent to 'arg1 = arg1 + arg2' 
  let newNum = Math.pow(arg1,2);
  return newNum;
}

/**as simple as it gets arrow function */
let myfunc = () => 'This is as simple as it gets.';

/**this is equivalent to the above. */
let myfunc2 = function () {
  return 'This is as simple as it gets.';
}

let result1 = myFunction2(1, 2);
console.log(result1);// print the return of myFunction2();
console.log(myfunc2());// invoke myfunc2.

/**Callback functions basics 
 * takes a callback function and an array
 * then it will cycle through the array,
 * passing the values through the callback function
 * and copy the return of the callback funcition
 * to another new array.
 * return the new array
*/
function arrayCopy(callbackFunc, array) {
  let newArr = [];
  for (let i = 0; i < array.length;i++){
    let newValue = callbackFunc(array[i]);//send the value into the callback function
    newValue++;
    newArr[i] = newValue;// assign the return of the callback function to the new array
  }
  return newArr;
}

//this function will be sent as an agr to arrayCopy
function myCallbackFunction(myint = 0, myString = 'nothing sent') {
  console.log(myString);
  return ++myint;
}

//this is the array
let array = [1, 2, 3, 4, 5];
let newArr = arrayCopy(myCallbackFunction, array);//invoke the function
console.log(newArr);

//example of creating the callback function while invoking arrayCopy()
let newArr1 = arrayCopy(
  (myInt, myString = 'myString') => {
  console.log(myString);
    return ++myInt;
}, array);
console.log(newArr1);

//forEach() loop example
array.forEach((value, index) => {
  console.log(`The value is ${value}`);
  console.log(`The index is ${index}`);

});

//create a function to sent to array.forEach();
function forEachCallback(value, index) {
    console.log(`The value is ${value}`);
    console.log(`The index is ${index}`);
}

array.forEach(forEachCallback);// invoke the forEach method.

/**Pass by value is when the value of hte variable is copied into the 
 * function and the function cannot change the otiginal variable value
 */
function passByValue(myInt) {
  return --myInt + ' this is one fewer than you sent';
}

let myInt0 = 1;
let myInt1 = passByValue(myInt0);
console.log(myInt0);
console.log(myInt1);

/**objects are passed by reference 
 * this means that the variable does NOT hold hte value....
 * the variable holds a reference to the memory location
 * on the heap where the value is contained.
*/
let myObject = {
  id: 1,
  name: 'Mark',
  city: 'Monterrey',
  //this is a method of myObject (not a function)
  details : function () {
    return `${this.name} is from ${this.city}`;
  }
}

//in C# syntax
// Person me = new Person(){
//   id: 1,
//   name: 'Mark',
//   city: 'Monterrey'
// }

function referenceObject(myObject1) {
  myObject1.id = 2;
  myObject1.name = 'Arely'
  return myObject1;
}

let myNewObj = referenceObject(myObject);
console.log(myObject);
console.log(myNewObj);

//call the method inside the object
console.log(myObject.details());
myObject.name = 'Noureldin';// change the values and call it again.
console.log(myObject.details());
// let myInt = 4;
function shadowFunc() {
  let myFuncExp = function() {
    // console.log(myInt);
    let myInt = 5;
    console.log(myInt);
  };
  myFuncExp();
}

shadowFunc();


/** IIFE (Immediately Invoked Function Expression) */
(() => {
  let myInt = 5;
  console.log(myInt);
})();

/** Truthy and Falsy */
console.log(1 == 1);  //true
console.log(1 == '1');//truthy
console.log(5 === '5');  //falsy
let a = {};
let b = a;
let c = {};
console.log(a == b);  //true
console.log(a !== b); //false
console.log(a === b); //true
console.log(a == c);  //falsy

console.log(String(53));
let x;
console.log(Number(x));
console.log(Number(false));
console.log(Number(true));
console.log(Number(''));
console.log(Number('13'));
console.log(Number('thirteen'));
console.log(Boolean('thirteen'));
if ('thirteen'){
  console.log('a string evaluates to true')
}

console.log(Math.sqrt(100));
console.log(Math.max(100, 5432, 51, 2132));
console.log(Math.cbrt(100));
console.log(Math.PI);

//a Map is a key:value pair..like a Dictionary in C#
// the keys must be unique
let myMap = new Map();
myMap.set('Mark', 41);
myMap.set('chicken', 'cluck');
myMap.set('Hope', 14);
myMap.set('Mark', 10);

// alert(myMap.get('Mark'));
myMap.forEach((value, key) => {
  console.log(`The key is ${key} and the value is ${value}`)
})

let myObjStringified = JSON.stringify(myObject);
console.log(myObjStringified.toUpperCase());
console.log(myObjStringified);
console.log(typeof myObjStringified);
let myObjParsed = JSON.parse(myObjStringified);
console.log(myObjParsed);

function names(fName, lName, choice = true) {
  function fullName() {
    return `The full name is ${fName} ${lName}`;
  }

  function fullNameReverse() {
    return `The full name reversed is ${lName} ${fName}`;
  }

  if (choice) { console.log(fullName()); }
  else { console.log(fullNameReverse()); }
}

names('Mark','Moore',false);
// fullName();// you cannot call this function becaues it's out of scope.

/**Lexical Environment example
 * THe function returned from counter() 
 * still has access to the number variable inside 
 * counter().
 * This means that the return of conter() IS the function
 * and can be invoked also to get the current 
 * value of the variable from inside counter()
 */
function counter() {
  let counterNum = 0;

  return function () {
    return ++counterNum;
  }
}

let counterReturned = counter();
console.log(counterReturned());
console.log(counterReturned());
console.log(counterReturned());
console.log(counterReturned());

/**another example */
function makeAdder(x=4) {
  return function (y) {
    return x + y;
  }
}

let add5 = makeAdder();
let resultAdd6 = add5(6);
console.log(resultAdd6);

let user = {
  name: 'Mark',
  location: "myRoom",
  stats: {
    height: 185,
    weight: 85
  }
};

console.log(user.name);
console.log(user.stats.height);

user.favColor = 'blue';
console.log(user.favColor);
console.log(user);
let exists = user.shoeSize in user;
console.log(exists);
if (exists) {
  console.log(`YES shoeSize in the object`)
}
else {
  console.log(`NO, shoesize does not exist in the object`)
}

for (let key in user){
  console.log(key, ' space ' + user[key]);
}

function people(name) {
  this.name = name;
  this.city;
}

let mark = new people('Mark-sa-lot');
console.log(mark.name);
mark.city = 'Monterrey';
console.log(mark.city);

let maya = new people('yaya');
console.log(maya.name);
maya.city = 'Crowley';
console.log(maya.city);


/**below is classes with inheritance. 
 * Make sure to call the super() class in the 
 * constructor before setting local class properties.
 */
class Shape{
  constructor(description){
    this.description = description;
  }
};

class Rectangle /*extends Shape*/ {
  constructor(height,desc, width) {
    // super(desc);
    this.height = height;
    this.width = width;
  }

  getArea() {
    if (this.height < 0) {
      return 'The height is negative';
    }
    else return this.calcArea();
  }

  calcArea() {
    return this.height * this.width;
  }
}

/**you can use the setPrototypeOf() to manually set a super class.
This means you will need to also manually add the 
properties of that derived class */
let rect1 = Object.setPrototypeOf(Rectangle, Shape);
let rect = new Rectangle(-1, 8);
rect1.description = 'This rectangle inherits from Shape.';
rect1.height = 1;
rect1.width = 2;
rect1.calcArea =   function() {
  return this.height * this.width;
};
rect1.getArea =   function() {
  if (this.height < 0) {
    return 'The height is negative';
  }
  else return this.calcArea();
};
console.log(rect1.height, rect1.width, Rectangle.name, rect1.calcArea(), rect1.getArea(), rect1.description);

let myString = 'This is a string';
let sliced = myString.slice(5, 11);
console.log(sliced);
console.log(myString);
let first = myString.split(' ', 1);
let second = myString.split(' ', 3);
console.log(first);
console.log(second);



