const loginForm = document.getElementById('loginform');
const responseDiv = document.querySelector('.responseFromLogin');


loginForm.addEventListener('submit', (event) => {
  event.preventDefault();
 
  const Username = loginForm.username.value.trim();
  const Password = loginForm.password.value.trim();

  //debugger

  // a fetch request is, by default, a GET request and doesn't need a body. 
  fetch(`api/meme/login/${Username}/${Password}`)
    .then(response => {
      if (!response.ok) {
        throw new Error(`Network response was not ok (${response.status})`);
      }
      else       // When the page is loaded convert it to text
        return response.json();
    })
    .then((jsonResponse) => {
      responseDiv.textContent = `Welcome, ${jsonResponse.fname} ${jsonResponse.lname}. It's good to see you.`;
      console.log(jsonResponse);
      return jsonResponse;
    })
    .then(res => {
      //save the Person to localStorage
      localStorage.setItem('person', JSON.stringify(res));
      //sessionStorage.setItem('personId', res.personId);
      //switch the screen
      location = 'personmenu.html';
    })
    .catch(function(err) {  
        console.log('Failed to fetch page: ', err);  
    });
});

