#light
module Exercise3

open Exercise2

(*Exercise 3.1 –Pattern matching and recursion*)

//a
let vowelToUpper c =
        match c with
        | 'a' -> "A"
        | 'e' -> "E"
        | 'i' -> "I"
        | 'o' -> "O"
        | 'u' -> "U"
        | _ -> string c

//b
let resultString = "aaa"
let explode (s:string) =[for c in s -> c]
let y = resultString + vowelToUpper 'c'
let rec vowelToUpperFromString s = 
    match s with
     | [] -> ""
     | (hd :: ts) -> vowelToUpper hd + vowelToUpperFromString ts
;;

let containerFunc s =
    let s1 = Seq.toList s
    vowelToUpperFromString s1
;;

(*Exercise 3.2–Some List functions*)
//a.length of a list

let list =  [2; 3; 5; 8]

let rec pmLength ls =
    match ls with
    | [] -> 0
    | (hd :: ts) -> 1 + pmLength ts
;;

//b.Define a function pclSumlsthat sums all the numbers in a list.

let rec pclSum ls =
    match ls with
    | [] -> 0
    | hd::ts -> hd + pclSum ts
;;

(*Exercise 3.3–Lists*)
(* 
Define a function, takeSome n lsthat returns list of first nelements from the list ls. 
Define the function using pattern matching:Example takeSome 2 ['a';'b'; 'c'; 'd']should return['a'; 'b'].
*)

//last x elements
let rec takeSome1 n ls =
  if List.length ls <= n then ls
  else takeSome1 n ls.Tail
  ;;

 //first n elements
let rec takeSome2 n ls =
    match ls with
    | [] -> []
    | ls when (List.length ls)-1 <= n -> []
    | hd::ts -> hd :: takeSome2 n ts
;;

let rec takeSome n ls =
    match n,ls with
    | _, [] -> []
    | 0, _ -> []
    | _, hd::ts -> hd :: takeSome (n-1) ts
;;





//experimenting with stuff
let dvowels1= ['a'; 'e'; 'i'; 'o'; 'u'; 'æ'; 'ø'; 'å']
let vowelToUpper1 characters =
 [
     for c in characters do
        match c with
        | 'a' -> yield "A"
        | 'e' -> yield "E"
        | 'i' -> yield "I"
        | 'o' -> yield "O"
        | 'u' -> yield "U"
        | _ -> yield string c
 ]

 (*
    let rec foo n s =
        match s with
        | "" -> n
        | _ -> n + foo vowelToUpper n s
    foo "" s
*)
