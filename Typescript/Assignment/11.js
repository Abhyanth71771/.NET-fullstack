"use strict";
class employee {
    constructor(firstname, lastname, salary) {
        this.empcode = 0;
        this.firstname = '';
        this.lastname = '';
        this.salary = 0;
        this.firstname = firstname;
        this.lastname = lastname;
        this.salary = salary;
    }
    get disp_empcode() {
        return this.empcode;
    }
    set disp_empcode(x) {
        if (x > 1000) {
            console.log("Emp code shoud be below 1000 so please restart");
        }
        else {
            this.empcode = x;
        }
    }
    getsalary() {
        return this.salary;
    }
}
let E1 = new employee("Abhyanth", 'P', 40000);
E1.disp_empcode = 134;
let E2 = new employee("Abhi", 'P', 4000);
E2.disp_empcode = 1344;
console.log(E1.firstname);
console.log(E1.lastname);
console.log(E1.empcode);
console.log("From get methood:" + E1.disp_empcode);
console.log("The salary " + E1.getsalary());
