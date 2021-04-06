import { MyTask } from './MyTaskClass';

let myTask: MyTask = new MyTask('someTask');
const stringArr = myTask.run("test");
console.log(stringArr);