class customer1 {
    constructor(public firstname:string,public lastname:string,public contactno:number){

    }
    public disp=()=>{
        console.log(this.firstname)
        console.log(this.lastname)
        console.log(this.contactno)
    }
}
let c12:customer1=new customer1("hola","xeedd",123)
c12.disp()
    