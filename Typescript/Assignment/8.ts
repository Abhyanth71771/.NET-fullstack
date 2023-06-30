function multiply(...mul:number[]){
    let x=mul.length
    let answer:number=1
    for(let i:number=0;i<x;i++){
         answer=answer*mul[i]
    }
    return answer
}
let _arr8=[1,2,3,4,5,6,7,8]
console.log(multiply(..._arr8))