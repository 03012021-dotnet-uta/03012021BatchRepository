const diveditform = document.querySelector('.diveditform');


const user = JSON.parse(localStorage.getItem('person'));
// const person = localStorage.getItem('person');
// console.log(person);
console.log(user);

( () => {
  const editprofileform =
    `
    <form class="editform">
    <div class="formdiv">
      <label for="fname">Enter your First Name:</label>
      <input class="forminput" type="text" id="fname" name="fname" placeholder="${user.fname}" required>
    </div>
    <div class="formdiv">
      <label for="lname">Enter your Last Name:</label>
      <input class="forminput" type="text" id="lname" name="lname" placeholder="${user.lname}" required>
    </div>
    <div class="formdiv">
      <label for="username">Change your Username:</label>
      <input class="forminput" type="text" id="username" name="username" placeholder="${user.userName}" required>
    </div>
    <div class="formdiv">
      <label for="password">Change your Password:</label>
      <!-- add a regex that  verifies the password requirements-->
      <input class="forminput" type="password" id="password" name="password" placeholder="new password" required>
      <div class="textred">**Password must have at least 1 uppercase letter, 1 lowercase letter, and one special
        character** </div>
    </div>
    <input class="formButton" type="submit" value="Submit">
  </form>
  `
  diveditform.innerHTML = editprofileform;

})();

diveditform.addEventListener('submit', (e) => {
  e.preventDefault();

  const editform = diveditform.querySelector('.editform');

  const userData = {
    personId:user.personId,
    fname: editform.fname.value.trim(),
    lname: editform.lname.value.trim(),
    username: user.userName,
    newpassword: editform.password.value.trim(),
    passwordHash: user.passwordHash,
    newUserName: editform.username.value.trim()
  }

  console.log(userData);

  fetch('api/meme/editprofile', {
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
      return jsonResponse;
    })
    .then(res => {
      //save the personId to localStorage
      localStorage.setItem('personId', JSON.stringify(res));// this is available to the whole browser
      //sessionStorage.setItem('personId', res.personId);// this is ony vailable to the certain window tab.
      //switch the screen
      location = 'personmenu.html';// 
    })
    .catch(function(err) {  
        console.log('Failed to fetch page: ', err);  
    });
});