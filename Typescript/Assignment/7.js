"use strict";
function disk(price, dis = 5) {
    let newprice = price - ((dis * price) / 100);
    return newprice;
}
console.log(disk(760));
