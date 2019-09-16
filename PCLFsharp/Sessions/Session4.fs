#light
module SessionY4

open Exercise2

//RECAP

//Tuples 2,3 length

let threeTplEg = ("Valentine", 6, 50.025)
let (_, special, _) = threeTplEg

let twoTpl = ("WEDN", 14.7)
let first = fst twoTpl
let second = snd twoTpl

//Lists are imutable
let listCons = 1 :: (2 :: (3 :: []))

let headFList = List.head listCons
let tailFList = List.tail listCons

(*
1::2::3::[] -> [1;2;3]
h->1
tail -> [2;3]

tail recursion
match list with
 | []         -> list goala fa ceva
 | hd :: tail -> are ceva inauntru
 *)


////////////////
///LIST cOMPREHENSION


(*

*)

let rec tsum lst =
    match lst with
    | [] -> 0
    | (hd::tls) -> hd + tsum tls



//LIST CMprehension generators yield

let numbersNear x =
    [
        yield x - 1
        yield x
        yield x + 1
    ]

let y =
    [
    let negate y = -y
    for i in 1..10 do
            if i % 2 = 0 then
                    yield negate i
                else
                    yield i
    ];;

let multipleOf x = [for i in 1..10 -> x*i];;


//LIST IV
let multipliesOf x = [for i in 1 .. 10 do yield x * i]

let multipliesOf x = [for i in 1 .. 10 -> x * i]

//simplified list comprehension
let multipliesOf2 x = [for i  in 1..10 -> x * i ]
/////////////////////////////////////////////////////////
let pclSqrs n =[for i in 1 .. n -> (i, i * i)]

let pclSqrsAdd n = [for (i, psq) in pclSqrs n -> 1 + psq]

////////////
let x5 =
 [
 for a in 1..5 do
  match a with
        | 3 -> yield! ["P"; "C"; "L"]
        | _ -> yield string a
 ]


 //yield vs yield!
let listWithYield = [ for i in 0 .. 10 .. 20 do yield [ i.. 1 .. i+9 ]];; // list with 3 sub lists
let listWithYieldBand = [ for i in 0 .. 10 .. 20 do yield! [ i.. 1 .. i+9 ]];; //one list

