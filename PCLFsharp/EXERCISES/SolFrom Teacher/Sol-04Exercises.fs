module Sol_04Exercises

// 4.1
let rec pclFold f init l = 
        match l with
        | []    -> init
        | x::xs -> pclFold f (f init x) xs

let pclSumWithFold l = pclFold (+) 0 l

// 4.2
let rec pclFoldBack f l init = 
        match l with 
        | []    -> init
        | x::xs -> f x (pclFoldBack f xs init)

let pclSumWithFoldback l = pclFoldBack (+) l 0

// 4.3
let rec pclInclist l =
        match l with
        | []    -> []
        | x::xs -> x + 1 :: pclInclist xs

// 4.4
let rec pclMap f = function 
        | [] -> []
        | x::xs -> f x :: pclMap f xs

let pclIncListWithMap l =
        let inc n = n + 1 in pclMap inc l

// 4.5
let rec pclFilter p l = 
        match l with 
        | []    -> []
        | x::xs -> if p x then x :: pclFilter p xs
                   else pclFilter p xs

let pclEven n = 
    if n % 2 = 0 then true
    else false
let evenNums lst = pclFilter pclEven lst