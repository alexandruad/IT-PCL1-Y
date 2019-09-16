#light

module Exercise6

open System


//Exercise 6.1–Data type declaration
//a.Define the data type declaration (PclShape) for Rectangle and RightTriangle

type PclShape = 
    | RightTriangle of width:float*length:float*hypotenuse:float
    | Rectangle of width:float*length:float
;;

//b.Create some values to represent both shapes
let triangle:PclShape = RightTriangle(3.0,4.0,5.0)
let rectangle:PclShape = Rectangle(4.0,3.0)
;;

//c.Define a function pclArea : PclShape -> float that calculates the area of a shape.
let pclArea (shape:PclShape) : float = 
    match shape with
    | RightTriangle(a,b,_) -> a*b/2.0
    | Rectangle(a,b) -> a*b
;;


//d.Define a function pclPerimeter to calculate the perimeter of a rectangle.
let pclPerimeter (shape:PclShape) : float = 
    match shape with
    | RightTriangle(a,b,c) -> a+b+c
    | Rectangle(a,b) -> (a+b)*2.0
;;

//e.Redefine the PclShape to use records instead of tuples (PclShapeR).
type PclShapeR = 
    {
     A : float;
     B : float;
     C : float
    }
;;

let triangleR:PclShapeR = {A = 3.0; B = 4.0; C = 5.0}
    ;;
let rectangleR:PclShapeR = {A = 3.0; B = 4.0; C = 0.0}
    ;;

let pclAreaR (shape:PclShapeR) : float = 
    match shape.C with
    | 0.0 -> shape.A*shape.B //rectangle
    | _ -> shape.A*shape.B/2.0 //triangle
;;

//Exercise 6.2-Higher-order functions

//Define a function pclCollectlsthat collects consecutive duplicates of list elements(ls)into sublists.
//Example:pclCollect ['p'; 'p'; 's'; 'c'; 'a'; 'l';'a';'p';'c';'l';'y']
//returns  [['p'; 'p']; ['s']; ['c']; ['a']; ['l']; ['a']; ['p']; ['c']; ['l']; ['y']]



let pclCollect ls =
    let rec aux current acc = function
        | [] -> [] // original list empty
        | [x] -> (x :: current) :: acc
        | a::(b :: _ as tail) -> 
            if a=b then aux (a::current) acc tail
            else aux [] ((a::current) :: acc) tail in
    List.rev (aux [] [] ls)
;;













////////////////////////////////////////////////////////////////////

let pack list =
    let rec aux current acc = function
      | [] -> []    (* Can only be reached if original list is empty *)
      | [x] -> (x :: current) :: acc
      | a :: (b :: _ as t) ->
         if a = b then aux (a :: current) acc t
         else aux [] ((a :: current) :: acc) t  in
    List.rev (aux [] [] list)
;;

let rec pclFilter f ls =
    match ls with
    | [] -> []
    | x::xs ->
        if f x then x :: pclFilter f xs
        else pclFilter f xs
;;


let list1 = [ 1; 2; 3; 4; 5; 2; 2; 2]
let list2 = List.ofSeq (set list1)