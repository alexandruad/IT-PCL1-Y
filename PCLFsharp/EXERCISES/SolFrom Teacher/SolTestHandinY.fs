module SolTestHandinY

// 1.
let sdata = ((1234, "Your Name"), 6, ("ECTS", 30))
let (_, _, ects) = sdata
// val sdata : (int * string) * int * (string * int) =
//  ((1234, "Sefie Sevia"), 6, ("ECTS", 30))
// val ects : string * int = ("ECTS", 30)

//2.
let rec concatStrList strLst =
    match strLst with
    | [] -> ""
    | hd::tl -> hd + concatStrList tl
//val concatStrList : strLst:string list -> string
// > concatStrList ["PCL1Y "; " Spring "; " 2019 :"; "Jonh Deo"; "1234"];;
// val it : string = "PCL1Y  Spring  2019 :Jonh Deo1234"

//3.
let getMaximum lst =
    let rec helper(lst,m) =
        match lst with
        | [] -> m
        | (x::xs) -> if (m < x) 
                     then helper(xs,x) 
                     else helper(xs,m)
    match lst with
    | [] -> failwith "Error -- empty list"
    | (x::xs) -> helper(xs,x)
// val getMaximum : lst:'a list -> 'a when 'a : comparison
// > getMaximum [9;2;5;23;11;17;6];;
// val it : int = 23

//4.
let rec getSomeItems n ls = 
   match (n, ls) with
        | (0, _) -> []
        | (_, []) -> failwith "you are taking too many elements"
        | (_, h::ls) -> h :: getSomeItems (n-1) ls
// val getSomeItems : n:int -> ls:'a list -> 'a list
// > getSomeItems 3 ["Fruits"; "Vegetables"; "Fish"; "Meat"; "Wine"; "Beer"];;
// val it : string list = ["Fruits"; "Vegetables"; "Fish"]

