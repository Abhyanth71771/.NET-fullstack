//We cannot create a object of the abstract class directly but it can be ceeate for the child class
//which will inherit the abstract class 
abstract class Person {
    name: string;
    
    constructor(name: string) {
        this.name = name;
    }

    display(): void{
        console.log(this.name);
    }

    abstract find(name:string): Person;
}

class employee1 extends Person{
    
    emopno: number;

    constructor(name:string,empno:number)
    {
            super(name)
            this.emopno=empno
    }
    find(): Person {
        
        return new employee1(this.name,1)
    }

    // display(): void {
    //     console.log("hello from the inherited class")
    // }
    
}
let g1:employee1=new employee1("Abhyanth",45)
g1.display()
console.log(g1.find())
// class employee2 extends Person{
    
//     emopno: number;

//     constructor(name:string,empno:number)
//     {
//             super(name)
//             this.emopno=empno
//     }
//     find(name: string): Person {
        
//         return new employee1(name,1)
//     }

//     // display(): void {
//     //     console.log("hello from the inherited class")
//     // }
    
// }
