const loginForm = document.getElementById('loginform');
const responseDiv = document.getElementsByClassName('responseFromLogin');


loginForm.addEventListener('submit', (event) => {
  event.preventDefault();
  /**create a string[] to send to the API in the body */
  const loginData = {
    Fname: loginForm.fname.value.trim(),
    Lname: loginForm.lname.value.trim()
  }
  // console.log(loginForm.fname.value.trim());
  // console.log(loginForm.lname.value.trim());
  // console.log('plain text');
  //debugger

  fetch('api/meme', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type':'application/json'
    },
    body:JSON.stringify(loginData)
    })
    .then(response => {
      if (!response.ok) {
        throw new Error(`Network response was not ok (${response.status})`);
      }
      else       // When the page is loaded convert it to text
        return response.json();
    })
    .then((jsonResponse) => {
      responseDiv[0].textContent = jsonResponse.fname + ' ' + jsonResponse.lname;
      console.log(jsonResponse);
    }
    )
    .catch(function(err) {  
        console.log('Failed to fetch page: ', err);  
    });
});

