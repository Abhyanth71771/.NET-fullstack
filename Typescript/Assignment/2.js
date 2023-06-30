"use strict";
class customerOperations {
    set addcust(name) {
        customerOperations.cust.push(name);
    }
    dispcust() {
        console.log(customerOperations.cust);
    }
}
customerOperations.cust = [];
let c1 = new customerOperations;
c1.addcust = "hello";
c1.addcust = "hello";
c1.addcust = "Chirah";
c1.addcust = "Sarthak";
c1.addcust = "Abhyanth";
c1.addcust = "Suhas";
console.log(c1.dispcust);
