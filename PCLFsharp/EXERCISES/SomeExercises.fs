#light

module SomeExercises

let tupleMe = (1, "FirstName LastName")


let deTupleMe (x, y) =
        printfn "number is : %i" x
        printfn "name is %s" y


let productNM n m =
    printfn "%d multiplied by %d" n m
    n * m


let rec lastElement ls =
    match ls with 
    | []     -> failwith "List must not be empty"
    | [h]    -> h
    | h::tl  -> lastElement tl


let rec lastElement2 = function
    | hd :: [] -> hd
    | hd :: tl -> lastElement2 tl
    | _ -> failwith "Empty list."


let rec myStrLength1 str =
        match str with
        | "" -> 0
        | str -> 1 + myStrLength1 str.[1..]


let myStrLength2 (str: string) = str.Length


let pclReverse xs = 
    let rec rev acc = function
        | [] -> acc
        | x::xs -> rev (x::acc) xs
    rev [] xs


let isPalindrome xs = xs = pclReverse xs


let lastElement3 ls =
    match (pclReverse ls) with
    | [] -> 0
    | hd::tl -> hd


let toUpper (x:string) = x.ToUpper()
let fstTupleToUpper tupleList = tupleList |> List.map (fst >> toUpper)



// Session 15 functions
 // Question 02.1: charToUpperString - Paste function here
 let charToUpper x =
 match x with
 | 'a' -> 'A'
 | 'b' -> 'B'
 | 'c' -> 'C'
 | c -> c
 let rec charToUpperString s =
 match s with
 | "" -> ""
 | s -> (charToUpper (s.[0])).ToString() + charToUpperString(s.[1 ..
String.length s - 1])
 //Question 02.2: pclTake - Paste function here
 let rec pclTake2 n ls =
 match (n, ls) with
 | (0, _) -> []
 | (_, []) -> failwith "you are taking too many elements"
 | (_, h::ls) -> h :: pclTake2 (n-1) ls
 //Question 02.3: pclElementAt - Paste function here
 let rec pclElementAtSol ls n =
 match ls,n with
 | [],_ -> failwith "Empty list"
 | h::_,1 -> h
 | _::ls,n -> pclElementAtSol ls (n-1)
 //Question 02.4: pclReverse, isPalindrome - Paste solution here
 let pclReverse xs =
 let rec rev acc = function
 | [] -> acc
 | x::xs -> rev (x::acc) xs
 rev [] xs
 let isPalindrome xs = xs = pclReverse xs
 //Question 02.5: pclZipper - Paste function here
 let rec pclZipperSol l1 l2 =
 match (l1,l2) with
 | (x::xs, y::ys) -> (x,y) :: pclZipperSol xs ys
 | ([], []) -> []
 | _ -> failwith "The lists have different length"
module Session1617 =
 // helper functions for the stringToWords implementation
 let rec pclTakeSol n ls =
 match (n, ls) with
 | (0, _) -> []
 | (_, []) -> failwith "you are taking too many elements"
 | (_, h::ls) -> h :: pclTakeSol (n-1) ls
 let rec throwAway n ls =
 if n < 0 then
 failwith "Error - Don't allow nehgative args"
 else
 match (n, ls) with
 | (0, _) -> ls
 | (_,h::tl) -> throwAway (n - 1) tl
 | (n, []) -> failwith "List is too short ..."
 // lookup whitespace character
 let rec lookupWS ls =
 match ls with
 | [] -> 0
 | h::tl -> if h = ' ' || h = '\n' || h = '\t'
 then 0 else 1 + lookupWS tl
 let rec lookupNWS ls =
 match ls with
 | [] -> 0
 | h::tl -> if h <> ' ' && h <> '\n' && h <> '\t'
 then 0 else 1 + lookupNWS tl
 let whiteSpaceChar c =
 match c with
 | ' ' -> true
 | '\n' -> true
 | '\t' -> true
 | _ -> false

 let nonWSC c = not (whiteSpaceChar c)

 let rec lookup p ls =
 match ls with
 | [] -> 0
 | h::tl -> if p h then 0 else 1 + lookup p tl

 let lookupWS2 s = lookup whiteSpaceChar s
 let lookupNWS2 s = lookup nonWSC s

 // convert string to words
 let rec convertStringToWords2 s =
 match s with
 | [] -> []
 | _ -> scanWord ( throwAway (lookupNWS2 s) s)
 and scanWord s =
 match s with
 | [] -> []
 | _ -> let n = (lookupWS2 s)
 in pclTakeSol n s :: convertStringToWords2 (throwAway n s)



module Session1819 =
 // Binary tree using discriminated unions
 type BinaryTree =
 | Node of int * BinaryTree * BinaryTree // key, left-child, right-child
 | Empty // Leaf
 let rec printInOrder tree =
    match tree with
    | Node (data, left, right)
        -> printInOrder left
           printfn "Node %d" data
           printInOrder right
    | Empty -> ()
 // example tree
 let binTree =
 Node(2,
    Node(1, Empty, Empty),
        Node(4,
            Node(3, Empty, Empty),
                Node(5, Empty, Empty)
        )
   )

 type tree = Leaf | Node of tree * int * tree
 // To use these as binary search trees for storing sets of integers:
 let rec insert newKey = function
 | Leaf -> Node (Leaf, newKey, Leaf) // Create a new Node
 | Node (left, nodeKey, right) ->
 if newKey < nodeKey
then Node (insert newKey left, nodeKey, right)
else Node (left, nodeKey, insert newKey right)


 let rec isElementOf searchKey = function
 | Leaf -> false // Not found
 | Node (left, nodeKey, right) ->
 if nodeKey=searchKey then true // Found
 elif nodeKey<searchKey then isElementOf searchKey left
 else isElementOf searchKey right

 let rec printInOrder2 tree =
 match tree with
 | Node (left, data, right) ->
 printInOrder2 left
printfn "Node %d" data
 printInOrder2 right
 | Leaf -> ()
 let binTree2 =
 Node(Node(Leaf, 1, Leaf), 2,
 Node(
 Node(Leaf, 3, Leaf),
4,
Node(Leaf, 5, Leaf)
 )
 )
type Suit = | Heart | Diamond | Spade | Club
type PlayingCard =
 | Ace of Suit
 | King of Suit
 | Queen of Suit
 | Jack of Suit
 | ValueCard of int * Suit
let deckOfCards =
 [
 for suit in [ Spade; Club; Heart; Diamond ] do
 yield Ace(suit)
yield King(suit)
yield Queen(suit)
yield Jack(suit)
for value in 2 .. 10 do
 yield ValueCard(value, suit)
 ]
// In the poker game of Texas hold 'em, a starting hand consists of two hole cards,
 // Describe a pair of cards in a game of poker
 let describeHoleCards cards =
 match cards with
 | []
 | [_]
 -> failwith "Too few cards."
 | cards when List.length cards > 2 -> failwith "Too many cards."
 | [ Ace(_); Ace(_) ] -> "Pocket Rockets"
 | [ King(_); King(_) ] -> "Cowboys"

 | [ ValueCard(2, _); ValueCard(2, _)] -> "Ducks"
 | [ Queen(_); Queen(_) ]
 | [ Jack(_); Jack(_) ]
 -> "Pair of face cards"

 | [ ValueCard(x, _); ValueCard(y, _) ] when x = y -> "A Pair"
 | [ first; second ] -> sprintf "Two cards: %A and %A" first second
// Recursive discriminated unions
 type Employee = Manager of string * Employee list | Worker of string
 let rec printOrganization worker =
 match worker with
 | Worker(name) -> printfn "Employee %s" name

 // Manager with a worker list with one element
 | Manager(managerName, [ Worker(employeeName) ] )
 -> printfn "Manager %s with Worker %s" managerName employeeName
 // Manager with a worker list of two elements
 | Manager(managerName, [ Worker(employee1); Worker(employee2) ] )
 -> printfn "Manager %s with two workers %s and %s"
 managerName employee1 employee2
 // Manager with a list of workers
 | Manager(managerName, workers)
 -> printfn "Manager %s with workers..." managerName
 workers |> List.iter printOrganization
 // printOrganization : worker:Employee -> unit
 let coy = Manager("Stanny", [ Worker("Dam"); Worker("Steffy") ] )




 ;;

 Question 02.1: charToUpperString - Paste function here	

let rec charToUpperString s = 
     match s with
          | "" -> ""
          | s -> (s.[0]).ToString() + "#\n" + charToUpperString(s.[1 .. String.length s - 1]);;

let rec ctoupstr s = 
     match s with
          | "" -> ""
          | s -> (ctoup (s.[0])).ToString() + ctoupstr(s.[1 .. String.length s - 1]);;


Question 02.2: pclTake - Paste function here
let rec pclTake2 n ls = 
   match (n, ls) with
        | (0, _) -> []
        | (_, []) -> failwith "you are taking too many elements"
        | (_, h::ls) -> h :: pclTake2 (n-1) ls


Question 02.3: pclElementAt - Paste function here
let rec pclElementAtSol ls n = 
    match ls,n with
         | [],_    -> failwith "Empty list"
         | h::_,1  -> h
         | _::ls,n -> pclElementAtSol ls (n-1)  


Question 02.4: pclReverse, isPalindrome - Paste solution here
let pclReverse xs = 
    let rec rev acc = function
        | [] -> acc
        | x::xs -> rev (x::acc) xs
    rev [] xs

let isPalindrome xs = xs = pclReverse xs


Question 02.5: pclZipper - Paste function here
let rec pclZipperSol l1 l2 =
    match (l1,l2) with
         | (x::xs, y::ys) -> (x,y) :: pclZipperSol xs ys
         | ([], [])       -> []
         | _              -> failwith "The lists have different length"

;;

// Weighted mean
 // summing the weights
 let rec pclSumWs ws =
 match ws with
 | [] -> 0.0
 | (h::tl) -> h + pclSumWs tl
 let rec pclPairXsWs xwLists =
 match xwLists with
 | ([],[]) -> []
 | ([], h::tl) -> failwith "The two lists must be of the same length"
 | (h::tl, []) -> failwith "The two lists must be of the same length"
 | (x::xs, w::ws) -> (x,w) :: (pclPairXsWs (xs,ws))
 let pclWtdMean weights dataset =
 let belowDen = pclSumWs weights
 let wdPairs = pclPairXsWs (weights, dataset)
 (pclSumWs (List.map (fun (x, w) -> x * w) wdPairs))/belowDen
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
 // c. evalExpression
 let rec evalExpression(expr) =
 match expr with
 | Integer(n) -> n
 | Variable s -> getVariableValue(s)
 | Add(expr1, expr2) ->
 let (lexpr, rexpr) = (evalExpression(expr1), evalExpression(expr2))
 in lexpr + rexpr
 // | _ -> failwith "Others ignored"
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
(* more examples, solutions *)
// Tail Recursion, Recursive Data Types
 module Session20 =
 let add x y = x + y
 // Creating a list of 100,000 integers
 let createImmutableList() =
 let rec createList i max =
 if i = max then []
 else i :: createList (i + 1) max
 createList 0 100000
// Example with stack overflow
 let rec sumList lst =
 match lst with
 | [] -> 0
 | hd::tl -> hd + sumList(tl)
 let list1 = [1 .. 100000]
 let list2 = [1 .. 1000000]
 // sumList list2;;
 // Process is terminated due to StackOverflowException.
 // Session termination detected. Press Enter to restart.

 // Recursive function for factorial
 let rec factorial x =
 if x <= 1
 then 1 // Base case
 else x * factorial (x - 1)
 // Sum a list using tail recursion
 let sumListTR lst =
 let rec sumListHelper(lst, total) =
 match lst with
 | [] -> total
 | hd::tl ->
 let ntotal = hd + total
 sumListHelper(tl, ntotal)
 sumListHelper(lst, 0)
// Recursive Data types
 // Sequences
 let seqOfNumbers = seq { 1 .. 5 }
 seqOfNumbers |> Seq.iter (printfn "%d")

 let seqList = seq { for a in 1 .. 10 do yield (a, a*a) }
 //seq<int* int> = seq[(1, 1); (2, 4); (3, 9); (4, 16); ...]
 // Sequence of all positive integers 
 let allPositiveIntsSeq =
 seq { for i in 1 .. System.Int32.MaxValue do yield i }
 // allPositiveIntsSeq ==> seq<int> = seq [1; 2; 3; 4; ...]
 // List of all positive integers - ERROR: Can't fit in memory!
 let allPositiveIntsList = [ for i in 1 .. System.Int32.MaxValue -> i ]
 // System.OutOfMemoryException: Exception of type 'System.OutOfMemoryException' was
thrown.
 // Stopped due to error




 ;;

 [2..10]
|> List.map (fun i ->
        match i with 
        | 2 | 3 | 5 | 7 -> sprintf "%i is prime" i
        | _ -> sprintf "%i is not prime" i
        )
;;

let y = 
    match (2,0) with 
    // OR -- same as multiple cases on one line
    | (2,x) | (3,x) | (4,x) -> printfn "x=%A" x 
    // AND -- must match both patterns at once
    // Note only a single "&" is used
    | (2,x) & (_,1) -> printfn "x=%A" x 
    | (_,_) -> failwith "Is out of range"

;;


let elementsAreEqual aTuple = 
    match aTuple with 
    | (x,y) -> 
        if (x=y) then printfn "both parts are the same" 
        else printfn "both parts are different" 

 ;;
 // loop through a list and print the values
let rec loopAndPrint aList = 
    match aList with 
    // empty list means we're done.
    | [] -> 
        printfn "empty" 

    // binding to head::tail. 
    | x::xs -> 
        printfn "element=%A," x
        // do all over again with the 
        // rest of the list
        loopAndPrint xs 

//test
loopAndPrint [1..5]

// ------------------------
// loop through a list and sum the values
 let rec loopAndSum aList sumSoFar = 
    match aList with 
    // empty list means we're done.
    | [] -> 
        sumSoFar  

    // binding to head::tail. 
    | x::xs -> 
        let newSumSoFar = sumSoFar + x
        // do all over again with the 
        // rest of the list and the new sum
        loopAndSum xs newSumSoFar 

//test
loopAndSum [1..5] 0

;;
// -----------------------
// Tuple pattern matching
let aTuple = (1,2)
match aTuple with 
| (1,_) -> printfn "first part is 1"
| (_,2) -> printfn "second part is 2"


// -----------------------
// Record pattern matching
type Person = {First:string; Last:string}
let person = {First="john"; Last="doe"}
match person with 
| {First="john"}  -> printfn "Matched John" 
| _  -> printfn "Not John" 

// -----------------------
// Union pattern matching
type IntOrBool= I of int | B of bool
let intOrBool = I 42
match intOrBool with 
| I i  -> printfn "Int=%i" i
| B b  -> printfn "Bool=%b" b

;;

let matchOnTwoParameters x y = 
    match (x,y) with 
    | (1,y) -> 
        printfn "x=1 and y=%A" y
    | (x,1) -> 
        printfn "x=%A and y=1" x
    | (_,_) ->
        printfn "LAST"

 ;;

let matchOnTwoTuples x y = 
    match (x,y) with 
    | (1,_),(1,_) -> "both start with 1"
    | (_,2),(_,2) -> "both end with 2"
    | _ -> "something else"

// test
matchOnTwoTuples (1,3) (1,2)
matchOnTwoTuples (3,2) (1,2)


;;
// --------------------------------
// comparing values in a when clause
let makeOrdered aTuple = 
    match aTuple with 
    // swap if x is bigger than y
    | (x,y) when x > y -> (y,x)
        
    // otherwise leave alone
    | _ -> aTuple

//test  
makeOrdered (1,2)        
makeOrdered (2,1)

// --------------------------------
// testing properties in a when clause  
let isAM aDate = 
    match aDate:System.DateTime with 
    | x when x.Hour <= 12-> 
        printfn "AM"
        
    // otherwise leave alone
    | _ -> 
        printfn "PM"

//test
isAM System.DateTime.Now

// --------------------------------
// pattern matching using regular expressions
open System.Text.RegularExpressions

let classifyString aString = 
    match aString with 
    | x when Regex.Match(x,@".+@.+").Success-> 
        printfn "%s is an email" aString
        
    // otherwise leave alone
    | _ -> 
        printfn "%s is something else" aString


//test
classifyString "alice@example.com"
classifyString "google.com"

// --------------------------------
// pattern matching using arbitrary conditionals
let fizzBuzz x = 
    match x with 
    | i when i % 15 = 0 -> 
        printfn "fizzbuzz" 
    | i when i % 3 = 0 -> 
        printfn "fizz" 
    | i when i % 5 = 0 -> 
        printfn "buzz" 
    | i  -> 
        printfn "%i" i

//test
[1..30] |> List.iter fizzBuzz


;;


// using match..with
let f aValue = 
    match aValue with 
    | x -> 
        match x with 
        | _ -> "something" 

// using function keyword
let f = 
    function 
    | x -> 
        function 
        | _ -> "something" 
//or lambdas passed to a higher order function:

// using match..with
[2..10] |> List.map (fun i ->
        match i with 
        | 2 | 3 | 5 | 7 -> sprintf "%i is prime" i
        | _ -> sprintf "%i is not prime" i
        )

// using function keyword
[2..10] |> List.map (function 
        | 2 | 3 | 5 | 7 -> sprintf "prime"
        | _ -> sprintf "not prime"
        )


;;

//non-tail recursive

let rec build_word chars = 
  match chars with
  | [] -> None
  | [c] -> Some char.to_string c
  | hd :: tl -> build_word tl
;;
//tail recursive

let rec build_word ?(acc = '') chars =
  match chars with
  | [] -> None
  | [c] -> Some c
  | hd::tl -> build_word acc:(acc ^ hd) tl
;;

Non-tail recursive version

let rec fib = function
    | n when n < 2 -> 1
    | n -> fib(n-1) + fib(n-2);;
Tail recursive version

let fib n =
    let rec tfib n1 n2 = function
    | 0 -> n1
    | n -> tfib n2 (n2 + n1) (n - 1)
    tfib 0 1 n;; 


;;

let rec foo n =
    match n with
    | 0 -> 0
    | _ -> 2 + foo (n-1)

let rec bar acc n =
    match n with
    | 0 -> acc
    | _ -> bar (acc+2) (n-1)


;;
