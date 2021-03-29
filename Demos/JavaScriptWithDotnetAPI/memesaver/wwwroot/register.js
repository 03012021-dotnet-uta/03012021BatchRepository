console.log('register.js works');

const registerForm = document.querySelector('.regform');
const registerResponse = document.querySelector('.registerResponse');

registerForm.addEventListener('submit', (e) => {
  e.preventDefault();//to prevent the form from submitting and resetting

  // grab the data and create an object to send as part of the body of my fetch()
  // console.log(registerForm.fname.value);
  const userData = {
    fname: registerForm.fname.value,
    lname: registerForm.lname.value,
    username: registerForm.username.value,
    password: registerForm.password.value,
  }

  fetch('api/meme/register', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type':'application/json'
    },
    body:JSON.stringify(userData)
    })
    .then(response => {
      if (!response.ok) {
        throw new Error(`Network response was not ok (${response.status})`);
      }
      else       // When the page is loaded convert it to text
        return response.json();
    })
    .then((jsonResponse) => {
      registerResponse.textContent = ` Welcome, ${jsonResponse.fname} ${jsonResponse.lname}`;
      console.log(jsonResponse);
    })
    .catch(function(err) {  
        console.log('Failed to fetch page: ', err);  
    });
});
