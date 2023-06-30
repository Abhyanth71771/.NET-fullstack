"use strict";
let user1 = {
    name: "hello",
    id: 10,
    count: () => {
        console.log("helloo");
        return 10;
    },
    displayname: (na = 'abhyanth') => {
        console.log(na);
        return "working";
    }
};
user1.displayname("");
