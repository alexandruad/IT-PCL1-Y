#light
module Exercise5

open System.Linq

//Higher-order functions, partial function application, closuresExercise 

//5.1Write an F# function countNumOfVowelsto count the number of vowels in a given string. 
//The type is:countNumOfVowels : string -> int * int * int * int *int. 
//Consider using List.fold.
//Test with: countNumOfVowels "Higher-order functions can take and return functions of any order"


let rec countNumOfVowels (str:string) =
    let charList = List.ofSeq str

    let accFunc (As, Es, Is, Os, Us) letter =
        match letter with
        |'a' -> (As+1, Es, Is, Os, Us)
        |'e' -> (As, Es+1, Is, Os, Us)
        |'i' -> (As, Es, Is+1, Os, Us)
        |'o' -> (As, Es, Is, Os+1, Us)
        |'u' -> (As, Es, Is, Os, Us+1)
        | _ -> (As, Es, Is, Os, Us)
    List.fold accFunc (0, 0, 0, 0, 0) charList
;;


//5.2 Define a function primesUpTo n to create a list of prime numbers up to a given number. 
//For instance: primesUpTo 10 results in [2; 3; 5; 7] 

let primesUpTo max =
    [
    for n in 1..max do 
        let factorsOfN = 
            [
             for i in 1..n do 
                if n % i = 0 then
                    yield i
            ]
        if List.length factorsOfN = 2 then
            yield n
    ]
;;


//5.3 Consider the sequence of Fibonacci numbers defined as follows:
//By the definition, Fibonacci numbers have the following sequence, where each number is the sum of the previous two:0, 1, 1, 2, 3, 5, 8, 13, 21, ...
//Define an F# function pclFib n that, when given a number, returns the nth Fibonacci number.

let rec fib n =
    match n with
    | 0 -> 0
    | 1 | 2 -> 1
    | _ -> fib(n-2) + fib (n-1)
;;

let pclFib n = fib (n-1);;


//5.4
//a.Define twoF# functions doubleNum x that multiplies x by 2 and sqrNum x that multiplies x by itself.

let doubleNum x = x*2
let sqrNum x = x*x;;


//b.Define another F# function  pclQuad x that applies the doubleNum function defined above twice. 

let pclQuad x = 
    doubleNum (doubleNum x)
;;

//c.Define another F# function  pclFourth x that applies the sqrNumf unction defined (in a.) above twice. 

let pclFourth x = 
    sqrNum (sqrNum x)
;;
let pclFourthV1 x = 
    sqrNum x |> sqrNum |> doubleNum
;;