console.log('upload.js works');

const formuploadmeme = document.querySelector('.formuploadmeme');// class of the form itself
const memeimage = document.querySelector('.memeimage');// class of the div where I hope to print the image
const fileField = document.querySelector('input[type="file"]');// this gets the specific input field of the file

formuploadmeme.addEventListener('submit', (e) => {
  e.preventDefault();

  //create a FormData object and append the 2 values we need to send.
  const memeupload = new FormData();// an object to hold the form fields and their data
  const person = JSON.parse(localStorage.getItem('person'));
  console.log(person.personId);
  memeupload.append('personId', person.personId);
  memeupload.append('meme', fileField.files[0]);// get the first (only) file

  fetch('api/meme/memeupload', {
    method: 'POST',
    body: memeupload // you don't have to stringify it.
  })
    .then(res => {
      return res.text();// extact the response body as text
    })
    .then(text => {
      // insert the image tag to the image div.
      // const html = `<img src="${text}" alt="No Image Found" style="height:150px" />`;
      // memeimage.innerHTML = html;
      memeimage.innerHTML = `Was your upload successful? -- ${text}`;
      location = 'personmenu.html';// 
    })
    .catch(err => console.error(err));
});