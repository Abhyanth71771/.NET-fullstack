class box{

    public static ifsc:string="hdfusjc12345"

    public static getIFSC():string

    {

        return "HDFCBVC"

    }

    constructor(

        public account:number,

        public id:number,

       )

        {

    }

   

}



class boxweight extends box{

        weight:number=0

        constructor(account:number,id:number,weight:number){

        super(account,id)

        this.weight=weight

    }

    public  getString ():string{

        return box.ifsc

    }

}

let b1:boxweight=new boxweight(1,2,3)



console.log(b1.getString())






console.log(boxweight.getIFSC())