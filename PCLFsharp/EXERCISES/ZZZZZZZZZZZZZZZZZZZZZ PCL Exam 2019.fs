module PCL_Exam_2019

//Q1

let studydata = ((123456, "Alexandru Adoamnei"), "Specialization", ("6 Semester", 30))
//Q1a

let deconstructStudyData studydata =
    match studydata with 
       | (_,_,(x,y)) -> printfn "%s %i" x y
(*
Testing
> deconstructStudyData studydata;;
6 Semester 30
val it : unit = ()
*)


//Q1b

let deconstructStudyData2 studydata =
    match studydata with 
       | (_,_,(x,_)) -> printfn "%s" x
(*
Testing
> deconstructStudyData2 studydata;;
6 Semester
val it : unit = ()
*)

//Q1c

let rec countPositiveN lst = 
  match lst with
  | [] -> 0
  | hd::tl when hd<=0 -> 0 + countPositiveN tl
  | hd::tl when hd>0 -> 1 + countPositiveN tl
;;
(*
Testing
> countPositiveN [1;2;-3;4;5];;
val it : int = 4
*)

//Q2
List.exists (fun x-> x=1) [1;2;3];;

//Q2a
let myExists p l=
    let rec myExistsRec l =
        match l with
        | [] -> false
        | hd::tl when p hd -> true
        | _::tl -> myExistsRec tl
    myExistsRec l
;;
(*
Testing
> myExists (fun c -> c="PME1") ["ALI";"PME1";"NSQ1"];;
val it : bool = true
> myExists (fun c -> c="PME2") ["ALI";"PME1";"NSQ1"];;
val it : bool = false
*)
//Q2b
let myExistsHof p l =
    List.exists p l

(*
Testing
> myExistsHof (fun c -> c="PME1") ["ALI";"PME1";"NSQ1"];;
val it : bool = true
> myExistsHof (fun c -> c="PME2") ["ALI";"PME1";"NSQ1"];;
val it : bool = false
*)

//Q2c
let list1 = [9;2;5;23;11;17;6] 
let max2 x y = if x >= y then x else y;;

let getMaxNum xs =
 let rec getMaximum xs =
   match xs with
   // The function aborts with an error message on empty lists
   | [] -> printfn "System.Exception: Error - Empty list."
   // Return immediately on a singleton list
   | [x] -> x
   // xs has at least two elements, call max_list 
   // on the bigger element of the first two ones and the rest of the list
   | x1::x2::xs' -> getMaximum((max2 x1 x2)::xs')
 getMaximum xs
;;
(*
Testing
> getMaxNum list1;;
val it : int = 23

> getMaxNum [];;
System.Exception: Error - Empty list.
*)


//Q3

//Q3a
let getElements n ls =
 if List.length ls < n then printfn "System.Exception: You are taking too many elements" 
 let rec getElementsRec n ls =
    match ls with
    | [] -> []
    | ls when (List.length ls) < n -> [] 
    | hd::ts -> hd :: getElementsRec n ts
 getElementsRec n ls
;;
(*
> getElements 3 [1;2;3;4;5];;
val it : int list = [1; 2; 3]

> getElements 6 [1;2;3;4;5];;
System.Exception: You are taking too many elements
*)

//Q3b

let rec getElementAt ls n =
  match ls,n with
  | [],_ -> failwith "Empty list or wrong position"
  | h::_,1 -> h
  | _::ls,n -> getElementAt ls (n-1)
;;
(*
Testing
> getElementAt [1;2;3;4;5] 1;;
val it : int = 1

> getElementAt [1;2;3;4;5] 4;;
val it : int = 4

> getElementAt [1;2;3;4;5] 9;;
System.Exception: Empty list
*)

//Q3c
let lastElement ls =
 let rec lastElementTR acc ls =
    match ls with 
    | []     -> failwith "List is empty"
    | [h]    -> h
    | h::tl  -> lastElementTR acc tl
 lastElementTR 0 ls
;;

let rec lastElement1 = function
    | hd :: [] -> hd
    | hd :: tl -> lastElement1 tl
    | _ -> failwith "Empty list."
;;
(*
Testing
> lastElement [1;2;3;4;5];;
val it : int = 5

*)



//Q4

//Q4a

type BinaryTree =
 | Node of int * BinaryTree * BinaryTree // key, left-child, right-child
 | Empty // Leaf
let rtNodeValue tree =
    match tree with
    | Node (data, _, _)
        -> data
    | Empty -> failwith "Tree is empty"
 // example tree
let binTree =
 Node(2,
    Node(4, Empty, Empty),
        Node(7,
            Node(10, Empty, Empty),
                Node(12, Empty, Empty)
        )
   )
(*
Testing
> rtNodeValue binTree;;
val it : int = 2

> 
val binTree : BinaryTree =
  Node
    (2,Node (7,Empty,Empty),
     Node (4,Node (10,Empty,Empty),Node (12,Empty,Empty)))

*)

//Q4b

let leftSubTree tree =
    match tree with
    | Node (data, right, left)
        -> left
    | Empty -> failwith "Tree is empty"
;;
(*
Testing
> leftSubTree binTree;;
val it : BinaryTree = Node (4,Empty,Empty)

> 
val leftSubTree : tree:BinaryTree -> BinaryTree
>
> leftSubTree binTree;;
val it : BinaryTree = Node (7,Node (10,Empty,Empty),Node (12,Empty,Empty))

> leftSubTree Empty;;
System.Exception: Tree is empty
*)


//Q4c

let rec appears searchKey tree = function
 | Leaf -> false // Not found
 | Node (data, right, left) -> 
   if data=searchKey then true // Found
   elif right=Empty then appears searchKey left
   else appears searchKey right
;;

(*
> appears 2 binTree;;
val it : bool = true

> appears 12 binTree;;
val it : bool = true

> appears 99 binTree;;
val it : bool = false

*)


//Q5
type size = Small | Medium | Large
type drink = Cola | Sprite | Squash
type Can = {Size: size; Drink: drink}

//Q5a

let priceCan can : int =
    match can:Can with
    | ({Drink = Cola ; Size = Small}) ->  15
    | ({Drink = Cola ; Size = Medium}) -> 20
    | ({Drink = Cola ; Size = Large}) ->  25
    | ({Drink = Sprite ; Size = Small}) ->  15
    | ({Drink = Sprite ; Size = Medium}) -> 20
    | ({Drink = Sprite ; Size = Large}) ->  25
    | ({Drink = Squash ; Size = Small}) ->  15
    | ({Drink = Squash ; Size = Medium}) -> 20
    | ({Drink = Squash ; Size = Large}) ->  25
    | _ -> -1
 ;;
 let canCola:Can = {Drink = Cola; Size = Medium}
 priceCan canCola;;
(*
Testing
type size =
  | Small
  | Medium
  | Large
type drink =
  | Cola
  | Sprite
  | Squash
type Can =
  {Size: size;
   Drink: drink;}

val priceCan : can:Can -> int
*)


//Q5b


//the agent that handles the ordering/feedback
let viacanteenAgent = 
        MailboxProcessor.Start(fun inbox -> 
                //define a function to process messeges placed in the inbox queue
              let rec messageLoop = async {
                  let! msg = inbox.Receive()
                //Print the price or the comment!
                  findPrice msg 

                   // loop to top
                  return! messageLoop
               }
              messageLoop)
;;

let food1:Food = Food(Food)
let qnty:int = 5


let messageDrink1:CanteenMessage = OrderDrink (drink1, qnty)
let messageDrink2:CanteenMessage = OrderDrink (drink2, qnty)
let messageDrink3:CanteenMessage = OrderDrink (drink3, qnty)
let messageComment:CanteenMessage = CanteenMessage.LeaveAComment "The drink/s was awesome! Great!!! \n"


canteenDrinkAgent.Post messageDrink1
canteenDrinkAgent.Post messageDrink2
