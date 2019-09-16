module Solution_03Exercises

// 3.1
let vowelToUpper c =
    match c with
    | 'a' -> 'A'
    | 'e' -> 'E'
    | 'i' -> 'I'
    | 'o' -> 'O'
    | 'u' -> 'U'
    |  c  -> c

let rec upperVowelStr str =
    match str with
    | "" -> ""
    | str -> (vowelToUpper (str.[0])).ToString() + 
                upperVowelStr(str.[1 .. String.length str-1])

let withMap = String.map vowelToUpper

// 3.2
let rec pclLength l = match l with
                         | [] -> 0
                         | (l::ls) -> 1 + pclLength ls

let rec pclSum l = match l with
                         | [] -> 0
                         | (l::ls) -> l + pclSum ls

// 3.3
let rec takeSome n xs =
    match (n,xs) with
         | (0,_) -> []
         | (_,[]) -> failwith "You are taking too many elements"
         | (_,x::xs) -> x :: takeSome (n-1) xs

