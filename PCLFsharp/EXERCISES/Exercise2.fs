#light
module Exercise2

(*Exercise 2.1 –F# files*)

let x = 23
let myName = "Valeny"
let age = 25
let country = "Australia"
let y = 4 + 2
;;


//Stuff to add

let a = 5
let b = let a = 10 in a + 5
let c = a + b
;;
(*Exercise 2.2–Function DeclarationI*)

let addNum1 x = x+1
let addNum10 x = x+10
let addNum20 x = addNum10 x + 10
;;

(*Exercise 2.3–FunctionDeclaration II*)

let max2 x y = 
    if x >= y then
        x
    else
        y
;;
let evenOrOdd x = 
    if x % 2 = 0 then
        printf " even number"
        else
            printf " odd number"
 ;;       
let addXY x y = 
    printf "Number to add : %i + %i " x y
    x + y
;;

(*Exercise 2.4 Optional*)

let rec tenMultipliedBy n = if n <= 1 then addNum10 0 else 10 + tenMultipliedBy (n - 1)
let rec addNum_jk j k = j + tenMultipliedBy k 
;;