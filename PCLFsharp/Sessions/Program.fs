
#light
open System

//A nice day

let dayEvent = "Valentine's day!"



(* 

Hello Morten!

*)
let num1 = 10
let num2 = 11
let num3 = num1 + num2
let num4 = num3
//A simple function

let f x = 2 * 3 + 2 - 1 + x
let result1 = f (f (f (f 2)))
let result2 = f (num3 + num3 + num4)

//function with return

let foo x =
      let a = x*x
      let b = x/x
      a/b

let funcResult = foo 10

//rec function

let rec vFactorial x = 
    if x<= 1 then
        1
    else
        x * vFactorial (x - 1);
  

 //tuples type of data declaration

let pointA = (25, 50)
let data3 = (14, "Boss" , 124.55)


let funSwap (a, b) = (b, a)

//Swaping a point
let pointB = funSwap pointA

//Lists


//empty list

let listEmpty = []
let list3 = [1; 2; 3]

//List of odd numbers

let oddNumbers = [1;3;5;7;9]

//list operations concatenate element to list
let newList = listEmpty :: 9


let englishVowels = ['a'; 'e'; 'i'; 'o'; 'u']
let enV = ["A"; "B"]


//List comprehension
//squares of the first 10 integers

let sqrOfOneToTen = [for n in 1..10 -> n*n]




let main argv =
    printfn "Hello World from F#!"
    0 // return 0
