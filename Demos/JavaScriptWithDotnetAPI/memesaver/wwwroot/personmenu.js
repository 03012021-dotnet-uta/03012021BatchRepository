// console.log('personmenu.js works')
const viewmemes = document.querySelector('#viewmemes');
const editprofile = document.querySelector('#editprofile');
const uploadmeme = document.querySelector('#uploadmeme');

// const personId = localStorage.getItem('person');
// console.log(`this is the new person id => ${personId}`);

//create an IIFE that will retrieve the Person from localStrorage and populate the page.
const user = JSON.parse(localStorage.getItem('person'));
// const person = localStorage.getItem('person');
// console.log(person);
console.log(user);


editprofile.addEventListener('click', () => {
  console.log('editprofile eventlistener works')

});

viewmemes.addEventListener('click', () => {
  console.log('viewmemes eventlistener works')

});

uploadmeme.addEventListener('click', () => {
  console.log('uploadmeme eventlistener works')

});