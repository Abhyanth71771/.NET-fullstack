"use strict";
class car {
    constructor() {
        this.name = 'boom boom';
    }
    // constructor(name:string){
    //     this.name=name
    // }
    run(speed = 0) {
        console.log("The name of the car is" + this.name + "The speed of the car is" + speed);
    }
}
class benz extends car {
    run(speed = 150) {
        console.log("The name of the car is" + this.name + "The speed of the car is" + speed);
    }
}
class bmw extends car {
    run(speed = 100) {
        console.log("The name of the car is" + this.name + "The speed of the car is" + speed);
    }
}
let bmw1 = new bmw;
bmw1.run();
let benz1 = new benz;
benz1.run();
