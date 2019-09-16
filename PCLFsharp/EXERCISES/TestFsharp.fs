#light
module TestFsharp


// 1.1 Given the following value
//
//Declare an F# to deconstruct the sdata that prints only ("ECTS",30)

let sdata = ((1234,"Your name"), 6,("ECTS",30))

let foo dataReceived =
 let (_, _, special) = dataReceived
 printfn "%s %i" <|| special

 (* 2.1
 Declare a function concatStrList strLst that concatenates a list of strings (strList) into a single string using pattern matching.

Example string items in the list: "PCL1Y ", " Spring ", " 2019 :", "your name"  and "your number"

 *)
 let stringList = ["PCL1Y "; " Spring "; " 2019 :"; "Alexandru Adoamnei" ; "253659"]

 let rec concatStrList strings =
        match strings with
        | [] -> ""
        | (hd :: tls) -> hd + concatStrList tls
;;

//3 Get max from a list
let list1 = [9;2;5;23;11;17;6] 

let max2 x y = if x >= y then x else y;;

let rec getMaximum xs =
   match xs with
   // The function aborts with an error message on empty lists
   | [] -> invalidArg "xs" "Empty list"
   // Return immediately on a singleton list
   | [x] -> x
   // xs has at least two elements, call max_list 
   // on the bigger element of the first two ones and the rest of the list
   | x1::x2::xs' -> getMaximum((max2 x1 x2)::xs')

//4 get the first n elements from a list

let rec foo n list = 10


;;