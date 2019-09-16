module Session6

open Session1


//  Pipelining |> <| 
//  Function composition >> <<


//Handin 1 mini project about the below
//DU, Records -> DSL



//START

let addTwoP p1 p2 =
    p1 + p2
;;

let addTwoPc p1 =
    let subadd p2 = p1 + p2
    subadd
;;

//
let isEven x = ( x%2=0)
let ls1 = List.filter isEven [0;1;2;3;4] 
let ls2 = List.map isEven [0;1;2;3;4] 

//class ex

let square x = x*x
let toStr (x : int) = x.ToString()
let strLen (x:string) = x.Length
let lenOfSquare = 
    square 
    >> toStr 
    >> strLen


    //class ex Records

type PersonRec = 
    {
     First : string;
     Last : string;
     Age: int;
     }
let bob = 
    {
        First = "Bob";
        Last = "Builder";
        Age = 22
    }

printfn "%s is %d years old" bob.First bob.Age ;;