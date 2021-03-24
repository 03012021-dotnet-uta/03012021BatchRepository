const newTodo = document.querySelector('.newTodo');
const todoList = document.querySelector('.todoList');
const searchForm = document.querySelector('.searchForm');



newTodo.addEventListener('submit', (event) => {
  event.preventDefault();
  console.log(newTodo.todo.value.length);
  const userInput = newTodo.todo.value.trim();
  console.log(userInput.length);

  addNewTodo(userInput);// call the function to add the todo to the list

  // newTodo.todo.value = '';// to reset the input field
  newTodo.reset();// to reset the whole form.
});

function addNewTodo(todo) {
  const html = `
  <li>
    <span class="todoItem">${todo}</span>
    <i class="deletebutton">DELETE</i>
  </li>
  `;

  todoList.innerHTML += html;
}

//user bubbleing to our advantage and watch for a 'click' event 
// on the <ul>
todoList.addEventListener('click', (event) => {
  if (event.target.classList.contains('deletebutton')) {
    event.target.parentElement.remove();
}
});

/**this will listen toe h the 'keyup' on the searchForm
 * and give us the surrent search term the user is typing.
 */
searchForm.addEventListener('keyup', () => {
  console.log(searchForm.search.value);
  const val = searchForm.search.value.trim().toLowerCase();
  
  Array.from(todoList.children)
    .filter((todo) => !todo.textContent.toLowerCase().includes(val))
    .forEach((todo) => todo.classList.add('noDisplay'));
  
    Array.from(todoList.children)
    .filter((todo) => todo.textContent.toLowerCase().includes(val))
    .forEach((todo) => todo.classList.remove('noDisplay') );

});
