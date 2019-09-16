#light
module Exercise4

open Exercise2

//Exercise 4.1 –List functions

//a.Define the function  pclFold.Use pattern matching.
let rec pclFold foo acc ls =
    match ls with
    | [] -> acc
    | h::ts -> pclFold foo (foo acc h) ts
;;
//b.Define a function pclSumWithFold that changes the pclSum

let pclSumWithFold ls =
    pclFold (+) 0 ls
;;

//Exercise 4.2–List function

// a.Define the function  pclFoldBack.
let rec pclFoldBack foo ls acc =
    match ls with
    | [] -> acc
    | x::xs -> foo x (pclFoldBack foo xs acc)
;;

//b.Define a function pclSumWithFoldBack that changes the pclSum

let pclSumWithFoldBack ls =
    pclFoldBack (+) ls 0
;;

//c.Compare

//Exercise 4.3 –List function

let rec pclIncList ls =
    match ls with
    | [] -> []
    | x::xs -> (x+1) :: pclIncList xs
;;


//Exercise 4.4–List function

//a.Define a function, pclMap that applies an arbitrary function f to the elements in a list

let rec pclMap f ls =
    match ls with
    | [] -> []
    | x::xs -> f x :: pclMap f xs
;;

//b.Define a function pclIncListWithMap that changes the pclIncList you defined previously in 4.3 to use pclMap   defined above

let pclIncListWithMap ls =
    pclMap (fun x -> x+1) ls
;;



//Exercise 4.5 –List function

//a.Define a function, pclFilter that removes all elements from a list that do not satisfy a given predicate. 

let rec pclFilter f ls =
    match ls with
    | [] -> []
    | x::xs ->
        if f x then x :: pclFilter f xs
        else pclFilter f xs
;;

//b.Define a function pclEven that returns true for even numbers.

let pclEven x = x%2=0;;

//c.Test the functions:
let result = pclFilter pclEven [0; 1; 2; 3; 4; 5;6;7;8;9];;

//For example, pclFilter pclEven [0; 1; 2; 3; 4; 5;6;7;8;9]
//should return [0; 2; 4;6;8]





