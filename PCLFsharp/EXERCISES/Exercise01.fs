#light
module Exercise

open System.Collections

let sqrOfOneToTen = [for n in 1..10 -> n*n]
3 :: sqrOfOneToTen

//Exercise 1–Getting Started 

3 :: [4; 5; 2; 7] (*COMPUTES*)

List.length [4; 5; 2; 7] (*COMPUTES*)


[4; 5; 2; 7] :: 3
(*
[4; 5; 2; 7] :: 3;;
The evaluation of the last expression generated an error.
Why? 
*)

//Because you cannot append, only prepend. You will have to add the tail as it is empty all the time.

//What can you do to make it work (that is, to insert the element3at the end of the list[4; 5; 2; 7])?
[4; 5; 2; 7] :: [3 :: []]