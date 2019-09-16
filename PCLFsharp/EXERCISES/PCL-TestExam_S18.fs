module PCL_TestExam_S18

let f x y = x + y
let g (x, y) = x + y
;;
 (*
 They have different types, and thus take different arguments.
 f is in curried form and has type int -> int -> int: it takes an int,
 and returns a function that takes another int which in turn returns an int.
 g, on the other hand,
 has type int * int -> int and takes a tuple of two ints as arguments.
 *)
 let stringToList s =
  let n = String.length s in
  let rec stl i =
   if i = n then []
   else s.[i] :: stl (i+1)
  in stl 0
 (*
 stringToList "Good luck!" ==> char list = ['G'; 'o'; 'o'; 'd'; ' '; 'l'; 'u'; 'c';
'k'; '!']
 *)
 type Vector =
  | V2 of float * float
  | V3 of float * float * float
  | V4 of float * float * float * float
  | V5 of float * float * float * float * float
 let vecLen vec =
  match vec with
  | V2 (x,y) -> sqrt (x**x + y**y)
  | V3 (x,y,z) -> sqrt (x**x + y**y + z**z)
  | V4 (x,y,z,u) -> sqrt (x**x + y**y + z**z + u**u)
  | V5 (x,y,z,u,v) -> sqrt (x**x + y**y + z**z + u**u + v**v)
 let vecAdd v1 v2 =
  match (v1,v2) with
   | (V2 (x1,y1),V2 (x2,y2)) -> V2 (x1+x2,y1+y2)
   | (V3 (x1,y1,z1),V3 (x2,y2,z2)) -> V3 (x1+x2,y1+y2,z1+z2)
   | (V4 (x1,y1,z1,u1),V4 (x2,y2,z2,u2)) -> V4 (x1+x2,y1+y2,z1+z2,u1+u2)
   | (V5 (x1,y1,z1,u1,v1),V5 (x2,y2,z2,u2,v2)) -> V5 (x1+x2,y1+y2,z1+z2,u1+u2,v1+v2)
   | _ -> failwith "Error: Trying to add vectors of different dimension"
;;
// Weighted mean
 // summing the weights
 let rec pclSumWs ws =
  match ws with
    | [] -> 0.0
    | (h::tl) -> h + pclSumWs tl
 ;; 
 let rec pclPairXsWs xwLists =
  match xwLists with
    | ([],[]) -> []
    | ([], h::tl) -> failwith "The two lists must be of the same length"
    | (h::tl, []) -> failwith "The two lists must be of the same length"
    | (x::xs, w::ws) -> (x,w) :: (pclPairXsWs (xs,ws))
;;
 
 let pclWtdMean weights dataset =
  let belowDen = pclSumWs weights
  let wdPairs = pclPairXsWs (weights, dataset)
  (pclSumWs (List.map (fun (x, w) -> x * w) wdPairs))/belowDen
;;
 // pclWtdMean [0.5; 1.0; 2.5; 1.5] [5.0; 10.5; 11.5; 3.5];;

// Expression and evaluation of expressions
    // A simple solution could use getVariableValue to return an integer
 type Expression =
  | Integer of int
  | Variable of string
  | Add of Expression * Expression
 // | LessThan of Expression * Expression


 // a. e1 = n + 1
let e1 = Add(Variable "n1", Integer 1)


//b. getVaraibleValue
let getVariableValue (s:string) =
    if s = "n1" then 4
    else failwith "variable not in the environment"
;;

// c. evalExpression
let rec evalExpression(expr) =
 match expr with
  | Integer(n) -> n
  | Variable s -> getVariableValue(s)
  | Add(expr1, expr2) ->
    let (lexpr, rexpr) = (evalExpression(expr1), evalExpression(expr2))
    in lexpr + rexpr
// | _ -> failwith "Others ignored"
;;


 // A more general solution could declare a type for EnvironmentBindings
 // and then look up values of variables from the bindings.
 type EnvironmentBindings = (string * int) list

 let rec getVariableValue2(variable:string, env: EnvironmentBindings) =
    match env with
        | [] -> None
        | (var, value)::rest ->
            if (variable = var) then Some value
            elif (var < variable) then getVariableValue2(variable, rest)
            else None
;;
 // Expressions can now be evaluated using the environment bindings
 // which can return some value.
 let rec evalExpression2(expr: Expression, env: EnvironmentBindings) =
    match expr with
        | Integer(n) -> Some n
        | Variable s -> getVariableValue2(s, env)
        | Add(expr1, expr2) ->
            let ad1 = evalExpression2(expr1, env)
            printfn " ad1 is %A" ad1
            let ad2 = evalExpression2(expr2, env)
            match ad1 with
                | None -> None
                | Some w ->
                match ad2 with
                    | None -> None
                    | Some v -> Some (v + w)
;;
