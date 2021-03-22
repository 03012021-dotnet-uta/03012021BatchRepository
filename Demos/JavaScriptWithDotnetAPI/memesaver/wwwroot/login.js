const loginForm = document.getElementById('loginform');
const responseDiv = document.getElementsByClassName('responseFromLogin');


loginForm.addEventListener('submit', (event) => {

  event.preventDefault();

  /**create a string[] to send to the API in the body */
  const stringObj = {
    fname: loginForm.fName.value,
    lname: loginForm.lName.value
  }

  //use Fetch() call the method of the controller that will return the string....
  fetch('/postrequest', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(stringObj)
  })
    .then(response => {
      if (!response.ok) {
        throw new Error(`Network response was not ok (${response.status})`);
      }
      else       // When the page is loaded convert it to text
        return response.json();
    })
    .then((jsonResponse) => {
        // Initialize the DOM parser
        //var parser = new DOMParser();

        // Parse the text
        //var doc = parser.parseFromString(html, "text/html");

        // You can now even select part of that html as you would in the regular DOM 
        // Example:
        // var docArticle = doc.querySelector('article').innerHTML;
        responseDiv[0].textContent = jsonResponse;
        // console.log(doc);
    })
    .catch(function(err) {  
        console.log('Failed to fetch page: ', err);  
    });
      // console.log('response.json');
      // return response.json();
      // location = 'upload.html';// do this to change the browser page to a different .html

      // print the return to the screen
      // responseDiv[0].innerHTML = response.text();
    });

