"use strict";
class Employee3 {
    constructor() {
        this.name = "Abhyanth";
        this.empcode = 123;
    }
    display() {
        console.log("Name of the Employee:" + this.name + "\nThe Employee code of " + this.name + " is:" + this.empcode);
    }
}
let c14 = new Employee3;
c14.display();
