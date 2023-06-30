class employee{
     empcode:number=0
     firstname:string=''
     lastname:string=''
     salary:number=0
     constructor(firstname:string,lastname:string,salary:number){
        this.firstname=firstname
        this.lastname=lastname
        this.salary=salary
     }
     public get disp_empcode(){
        return this.empcode

     }
     public set disp_empcode(x:number){
        if(x>1000){
            console.log("Emp code shoud be below 1000 so please restart")
        }
        else{
         this.empcode=x
        }

     }
     public getsalary(){
      return this.salary
     }

}

let E1:employee=new employee("Abhyanth",'P',40000)
E1.disp_empcode=134
let E2:employee=new employee("Abhi",'P',4000)
E2.disp_empcode=1344
console.log(E1.firstname)
console.log(E1.lastname)
console.log(E1.empcode)
console.log("From get methood:"+E1.disp_empcode)
console.log("The salary "+E1.getsalary()) 