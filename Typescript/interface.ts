interface user{

    name:string,

    id:number,

    count():number,

    displayname(nam:string):string    

}

 let user1:user= {

    name:"hello",

    id:10,

    count:() => {console.log("helloo")

                return 10},

    displayname:(na :string='abhyanth')=>{console.log(na)

                return"working"}

 }

 user1.displayname("")