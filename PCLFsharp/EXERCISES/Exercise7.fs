#light

module Exercise7

(*
Exercise 7.01
Redefine the  pclArea function (defined in Exercise 6.1) to use the new data type(PclShapeR). 
Call the new function pclAreaR.
*)

type PclShapeR = 
    {
     A : float;
     B : float;
     C : float
    }
;;

let triangleR:PclShapeR = {A = 3.0; B = 4.0; C = 5.0}
let rectangleR:PclShapeR = {A = 3.0; B = 4.0; C = 0.0}


let pclAreaR (shape:PclShapeR) : float = 
    match shape.C with
    | 0.0 -> shape.A*shape.B //rectangle
    | _ -> shape.A*shape.B/2.0 //triangle
;;