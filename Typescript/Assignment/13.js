"use strict";
//We cannot create a object of the abstract class directly but it can be ceeate for the child class
//which will inherit the abstract class 
class Person {
    constructor(name) {
        this.name = name;
    }
    display() {
        console.log(this.name);
    }
}
class employee1 extends Person {
    constructor(name, empno) {
        super(name);
        this.emopno = empno;
    }
    find() {
        return new employee1(this.name, 1);
    }
}
let g1 = new employee1("Abhyanth", 45);
g1.display();
console.log(g1.find());
// class employee2 extends Person{
//     emopno: number;
//     constructor(name:string,empno:number)
//     {
//             super(name)
//             this.emopno=empno
//     }
//     find(name: string): Person {
//         return new employee1(name,1)
//     }
//     // display(): void {
//     //     console.log("hello from the inherited class")
//     // }
// }
