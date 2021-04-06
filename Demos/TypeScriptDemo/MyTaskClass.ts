import { Task } from './TaskInterface';

export class MyTask implements Task {
  name: String;
  constructor(name: String) {
    this.name = name;
  }

  run(arg: string): void {
    console.log(`running: ${this.name}, arg: ${arg}`);
    //return ['my', 'string', 'array'];
  }
}