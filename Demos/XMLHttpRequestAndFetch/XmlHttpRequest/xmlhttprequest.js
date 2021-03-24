console.log('xmlhttprequest JS works');

let printToConsole = function () {
  if (request.readyState === 4) {
    console.log(`readystate ${request.readyState} reached`);

    /**print the response body to the console */
    console.log(request.responseText);

    console.log(JSON.parse(request.responseText));
    const responseText = JSON.parse(request.responseText);
    const body = document.getElementsByTagName('body');
    let html =
      `
        <div>
        <h4 style="color:blue;text-align:center">${responseText.value.joke}</h4>
        </div>
      `;
    body[0].innerHTML += html;
  }
  else {
    console.log(`ALT - Readystate ${request.readyState} reached.`);
  }
}


/**create the request object */
let request = new XMLHttpRequest();

/** assign what to do when the readystate changes. */
request.onreadystatechange = printToConsole;

/**configure the request with the website */
request.open('GET', 'http://api.icndb.com/jokes/random', true);

/**send the request */
request.send();