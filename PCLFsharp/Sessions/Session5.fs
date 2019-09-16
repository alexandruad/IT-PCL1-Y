#light
module Session5

let rec map f = function
 | [] -> []
 | hd :: tl -> f hd :: map f tl
;;

//map Example

let result = List.map List.rev [[1;2;3];[4;5;6]] ;;
//val it : int list list = [[3; 2; 1]; [6; 5; 4]]
let inclList ls = let inc n = n + 1 in map inc ls

//Currying
let result1 = List.map ((+) "SEngr ") ["Nicolina"; "Edgaras"; "Mogens"];;