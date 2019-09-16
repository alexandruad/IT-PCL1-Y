module Solution_02Exercises

//Exercise 2.2
let addNum1 x = x + 1
let addNum10 x = x + 10
let addNum20 x = addNum10(addNum10(x))

// Exercise 2.3
let max2 x y = if x < y then y else x
let evenOrOdd x = 
   if x % 2 = 0 then
      printfn "even"
   else
      printfn "odd"

let addXY x y = 
      printfn "x=%i y=%i" x y
      x + y

// Exercise 2.4
let addMany10 n = 
    let rec recur acc n =
        if n <= 0 then
            addNum10 0
        else
            acc + (recur (addNum10 0) (n-1))
    recur 0 n

let addNum_jk j k = j + addMany10 k 
// Test run
(*
val addNum10 : x:int -> int
val addMany10 : n:int -> int
val addNum_jk : j:int -> k:int -> int
> addNum_jk 3 5;;
val it : int = 53
*)