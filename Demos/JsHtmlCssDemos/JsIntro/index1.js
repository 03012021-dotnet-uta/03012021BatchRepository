const newTodo = document.querySelector('.newTodo');
const todoList = document.querySelector('.todoList');



newTodo.addEventListener('submit', (event) => {
  event.preventDefault();
  console.log(newTodo.todo.value);
  
  addNewTodo(newTodo.todo.value);



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