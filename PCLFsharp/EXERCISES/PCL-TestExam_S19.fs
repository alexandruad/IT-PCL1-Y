#light

module PCL_TestExam_S19

//Q1


//Q1a
let sqrOnlyFirst ls =
  match ls with 
    | hd :: _ -> hd * hd
    | [] -> 0
;;
(*
    It will match with the first number in the array and return 5
    It will try to match but since the list is empty it will throw an error.
    To fix it we need to match another case for an empty list e.g. :
    let sqrOnlyFirst ls =
    match ls with 
    | hd :: _ -> hd * hd
    | [] -> 0

*)
#Q1b

let stringToList s = [for c in s -> c]

open Exercise2
open PCL_TestExam_S19
open PCL_TestExam_S19
open System
open Microsoft.FSharp.Core

;;
(* From the teacher
 let stringToList s =
 let n = String.length s in
 let rec stl i =
 if i = n then []
 else s.[i] :: stl (i+1)
 in stl 0
*)

//Q2

type Vector = | V2 of float * float
              | V3 of float * float * float
              | V4 of float * float * float * float
              | V5 of float * float * float * float * float

let vector2:Vector = Vector.V2(1.0,2.0)
;;
let vecLen vec =
 match vec with
 | V2 (x,y) -> sqrt (x**x + y**y)
 | V3 (x,y,z) -> sqrt (x**x + y**y + z**z)
 | V4 (x,y,z,u) -> sqrt (x**x + y**y + z**z + u**u)
 | V5 (x,y,z,u,v) -> sqrt (x**x + y**y + z**z + u**u + v**v)
 ;;

 let vecAdd v1 v2 =
  match (v1,v2) with
  | (V2 (x1,y1),V2 (x2,y2)) -> V2 (x1+x2,y1+y2)
  | (V3 (x1,y1,z1),V3 (x2,y2,z2)) -> V3 (x1+x2,y1+y2,z1+z2)
  | (V4 (x1,y1,z1,u1),V4 (x2,y2,z2,u2)) -> V4 (x1+x2,y1+y2,z1+z2,u1+u2)
  | (V5 (x1,y1,z1,u1,v1),V5 (x2,y2,z2,u2,v2)) -> V5 (x1+x2,y1+y2,z1+z2,u1+u2,v1+v2)
  | _ -> failwith "Error: Trying to add vectors of different dimension"
;;


//Q3 rerun: string -> int -> string
//recursive

let rerun s n =
 let rec rerunRec s n =
    match n with
        | i when i<0 -> "No negative values!"
        | 0 -> ""
        | 1 -> s
        | _ -> s + rerunRec s (n-1)
 rerunRec s n
 ;;
 
let rerunT s n =
  let rec rerunTailRec acc s n =
    match n with
        | i when i<0 -> "No negative values!"
        | 0 -> acc
        | _ -> rerunTailRec (acc+s) s (n-1)
  rerunTailRec "" s n



//Q4
let f1 i j k =
    seq {
        for x in [0 .. i] do
            for y in [0 .. j] do
                if x+y < k then yield (x,y)
    }
let f2 f p sq =
    seq {
        for x in sq do
            if p x then yield f x
    }

let f2Lib f p sq =
    sq |> Seq.filter p |> Seq.map f

let f3 g sq =
    seq {
        for s in sq do
            yield! g s
    }



//Q5
type expr = | Const of int
            | BinOpr of expr * string * expr
;;
let expr1 = BinOpr (Const (1), "*", Const(1))
let expr2 = BinOpr (Const (1), "+",BinOpr (Const (2),"*", Const (3)))
let expr3 = BinOpr (Const (1), "+", Const(9))
;;
let toString e =
  let rec pclToString (e:expr) : string =
    match e with 
        | Const c -> c.ToString()
        | BinOpr (ex1, s, ex2) -> "(" + pclToString ex1 + s + pclToString ex2 + ")"
  (pclToString e)
;;
//let rec printInOrder e =
//    match e with
//    | BinOpr (e1, s, e2)
//        -> printInOrder e1
//           printf "%s" s
//           printInOrder e2
//    | Const c -> printf "%d" c
//;;

//function to extract the set of operators
let extractOperators e =
  let rec pclOperators (e:expr) =
    match e with 
        | Const c -> ""
        | BinOpr (ex1, s, ex2) -> pclOperators ex1 + s + pclOperators ex2
  (pclOperators e)
;;
//Q6


//Question 6a
let data = [1;2;3;4;5]
let list = List.map(fun i -> i + 10) data
//val list : int list = [11; 12; 13; 14; 15]

//Question 6b
let naturalNumbers = [0;1;2;3;4;5;6;7;8;9]
let printEvenNumbers = List.filter(fun i -> i%2=0) naturalNumbers
//val printEvenNumbers : int list = [0; 2; 4; 6; 8]


