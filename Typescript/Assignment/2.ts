class customerOperations{
    public static cust:string[]=[];
public set addcust(name:string){
    customerOperations.cust.push(name)
}
public dispcust(){
    console.log(customerOperations.cust)
}
}
let c1:customerOperations=new customerOperations
c1.addcust="hello"
c1.addcust = "hello";
c1.addcust = "Chirah";
c1.addcust = "Sarthak";
c1.addcust = "Abhyanth";
c1.addcust = "Suhas";
console.log(c1.dispcust)
