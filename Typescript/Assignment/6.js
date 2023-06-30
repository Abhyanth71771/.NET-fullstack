"use strict";
class customer1 {
    constructor(firstname, lastname, contactno) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.contactno = contactno;
        this.disp = () => {
            console.log(this.firstname);
            console.log(this.lastname);
            console.log(this.contactno);
        };
    }
}
let c12 = new customer1("hola", "xeedd", 123);
c12.disp();
