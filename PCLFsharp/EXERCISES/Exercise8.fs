#light

module Exercise8

(*
Exercise 8.1-Pattern matching, discriminated union
Declare a type IntegerTree representing a tree of integers and define a recursive function sumIntegerTree
that sums all the values in the tree.
*)

type IntegerTree =
    | Node of int * IntegerTree * IntegerTree
    | Empty
;;

let binTree = Node(2,Node(1, Empty, Empty),
                   Node(4,Node(3, Empty, Empty),Node(5, Empty, Empty))    )
;;
//define sumIntegerTree recursive function

let rec sumIntegerTree tree =
    match tree with
    | Node (x, innerTree1, innerTree2) ->  x + sumIntegerTree innerTree1 + sumIntegerTree innerTree2
    | _ -> 0
;;

//08 Multi paradigm programming

let mutable x = 5
let mutable f = fun x -> x + 1


//Array
let x = [|0|]
let y = x
x.[0] <- 3