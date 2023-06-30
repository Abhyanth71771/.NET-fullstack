"use strict";
class box {
    constructor(account, id) {
        this.account = account;
        this.id = id;
    }
    static getIFSC() {
        return "HDFCBVC";
    }
}
box.ifsc = "hdfusjc12345";
class boxweight extends box {
    constructor(account, id, weight) {
        super(account, id);
        this.weight = 0;
        this.weight = weight;
    }
    getString() {
        return box.ifsc;
    }
}
let b1 = new boxweight(1, 2, 3);
console.log(b1.getString());
console.log(boxweight.getIFSC());
