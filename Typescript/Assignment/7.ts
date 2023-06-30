function disk(price:number,dis:number=5):number{
    let newprice=price-((dis*price)/100)
    return newprice
}
console.log(disk(760))