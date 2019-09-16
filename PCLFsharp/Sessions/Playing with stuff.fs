#light
module Playing_with_stuff

let square x = x*x
let sumSqr(x,y) = square x + square y
let sumSqr2 x y = square x + square y


let sumUsingForLoop = 
    let mutable sum = 0
    for i in 1..10 do
        sum <- sum + i*i
    sum
;;
 let rec sumRec n = if n <= 0 then 0 else n + sumRec (n - 1)
 let n = 10
 let answer = sumRec 10
 ;;


let function1() =
  for i in 1 .. 10 do
    printf "%d " i
  printfn ""
function1()
;;

let squaresOfOneToTen= [for x in 1..10 -> x*x]

//string

let x = "ab" + "c"

let y = x + "CCC"

//session 3
let squareAnonim = fun x -> x * x

let classS19 = "IT-PCL1-S19"
let length = classS19.Length
let index = classS19.[7]

//Tuples
// Construction
let stud1 = (232401, "Bobby Funny")
// Triple tuple
let stud2 = (232402, "Bobby Funny", "Cross Media")
// Deconstruction –using fst, sndor pattern
let studNum= fst(232401, "Bobby Funny")
let studName= snd(232401, "Bobby Funny")
let (x, y) = stud1

//LIST
let x1 = [1 .. 10]
let x2 = [1..3..12]
let tens = [0 .. 10 .. 50]
tens.Item(3)
tens.Length

////TAIL recursive and not

//not tail recursive
let rec foo n =
    match n with
    | 0 -> 0
    | _ -> 2 + foo (n-1)

//tail recursive
let bar1 n =
 let rec bar acc n =
    match n with
    | 0 -> acc
    | _ -> bar (acc+2) (n-1)
 bar 0 n
//Fibbonaci

//Non-tail recursive version

let rec fibNon = function
    | n when n < 2 -> 1
    | n -> fibNon(n-1) + fibNon(n-2);;
//Tail recursive version

let fib n =
    let rec tfib n1 n2 = function
    | 0 -> n1
    | n -> tfib n2 (n2 + n1) (n - 1)
    tfib 0 1 n;;  