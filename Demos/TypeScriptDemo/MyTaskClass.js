"use strict";
//Object.defineProperty(exports, "__esModule", { value: true });
var MyTask = /** @class */ (function () {
    function MyTask(name) {
        this.name = name;
    }
    MyTask.prototype.run = function (arg) {
        console.log("running: " + this.name + ", arg: " + arg);
        return ['my', 'string', 'array'];
    };
    return MyTask;
}());
//exports.MyTask = MyTask;
