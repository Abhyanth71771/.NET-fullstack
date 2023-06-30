class car{
    name:string='boom boom'
    // constructor(name:string){
    //     this.name=name
    // }
 public run(speed:number=0){
        console.log("The name of the car is"+this.name+"The speed of the car is"+speed)
 }   
}

class benz extends car{
    public run(speed: number=150): void {
        console.log("The name of the car is"+this.name+"The speed of the car is"+speed)
    }
}

class bmw extends car{
    public run(speed: number=100): void {
        console.log("The name of the car is"+this.name+"The speed of the car is"+speed)
    }
}

let bmw1:bmw=new bmw
bmw1.run()
let benz1=new benz
benz1.run()