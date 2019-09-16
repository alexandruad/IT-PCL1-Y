#light

module Function_signatures

(*
https://fsharpforfunandprofit.com/posts/function-signatures/

val testA = int -> int
val testB = int -> int -> int
val testC = int -> (int -> int)      
val testD = (int -> int) -> int
val testE = int -> int -> int -> int
val testF = (int -> int) -> (int -> int)
val testG = int -> (int -> int) -> int
val testH = (int -> int -> int) -> int
*)

let funcA a = a+1
let funcB a b = a+b

let funcC a = (*) a
let funcD a = (a 1)
let funcE a b c = a+b+c
let funcF a = (*) (a 1)
let funcG a b = ( b(a+1) ) + 1
let funcH a = (a 1 1) + 1

let testD f = f 1 |> (+) 1
let testF f = f 1 |> (+) 
let testG x f = x + 1 |> f |> (+) 1
let testH f = f 1 2 |> (+) 1


