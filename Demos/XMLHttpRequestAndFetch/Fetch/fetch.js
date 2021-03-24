console.log('fetch JS works');

console.log(1);
console.log(2);

fetch('http://api.icndb.com/jokes/random', /**this arg would be the headers */)
  .then(response => response.json())
  .then(response => {
    console.log(`the ID of the joke is ${response.value.id}.`);
    return response;
  })
  .then(res => {
    console.log(res.value.joke);
    return res;
  })
  .then(res1 => {
    const body = document.getElementsByTagName('body');
    let html =
      `
        <div>
        <h4 style="color:blue;text-align:center">${res1.value.joke}</h4>
        </div>
      `;
    body[0].innerHTML += html;
  })
  .catch(err => console.log(`request was rejected with ${err}`));

console.log(3);
setTimeout(() => {
  console.log(`The setTimeout has returned.`)
  
}, 370);
console.log(4);
