interface IPerson{
    name:string
    display():void
}

interface IEmployee{
    empcode:number
}

class Employee3 implements IPerson,IEmployee{

    name: string="Abhyanth"
    empcode:number=123
    display():void {
        console.log("Name of the Employee:"+this.name+"\nThe Employee code of "+this.name+" is:"+this.empcode);
      }
}

let c14:Employee3=new Employee3
c14.display()