#light

module MiniProjectPhase2

(*

Phase 2:In this second phase of the mini-project, you are required to implement a function to ordera drink
from (or leave a comment to) the canteen in a concurrent way.Hints: The OrderDrinkmessage processing should
use the Pricecalculation function that returns the price for the specified drinkmultiplied by the given quantity:
F# has both shared-memory concurrency and message-passing concurrency. As discussed during the lessons, 
F# has a built-in mailbox processorconcept that is popular in Erlanglanguage.  This  built-in  mailbox  processor  is  defined  in  the 
F#  library  as  a  type  called MailboxProcessorand usually referred to as an Agentor 

Actor.typeCanteenMessage =  
| OrderDrink ofAllDrinks * int// Drink, qty
| LeaveAComment ofstring  // ”Comment-super!”

Implement a canteenagent (call it canteenDrinkAgent) that receives aCanteenMessage declared above and prints
a message with the price of the drink to thesender(for OrderDrink).
Further, a second message LeaveAComment of string (ie. “Comment”) to leave a string comment to the canteen operators. 
Acknowledge the comments with your own ideas.
Example:> 
canteenDrinkAgent.Post (OrderDrink(InCup {Size=Small; Drink=Cappucinno}, 2))
;;
Should give for instance:> Please pay DKK 24.00 for your 2 coffee drinks. Thanks!

*)

//Part1

//Input in F# Interactive to test after full implementation
//calculatePriceAndPrint1 Bottle({TypeOf=Tuborg; DrinkSize= Large});;

//union for the Size
type DrinkSize = | Large | Medium | Small

// union for Bottle, Can and Cup types
type BottleType = | Bottle1 | Bottle2 | Bottle3
type CanType = | Can1 | Can2 | Can3 
type CupType = | Cup1 | Cup2 | Cup3



//Defining the rec types for the Bottle, Can and Cup
type Bottle = {TypeOfBottle: BottleType; BottleSize: DrinkSize}
type Can = {TypeOfCan: CanType; CanSize: DrinkSize}
type Cup = {TypeOfCup: CupType; CupSize: DrinkSize}



//Sub -Calculate and return the price for Bottle
let priceBottle bottle : int =
    match bottle:Bottle with
    | ({TypeOfBottle = Bottle1 ; BottleSize = Small}) ->  15
    | ({TypeOfBottle = Bottle1 ; BottleSize = Medium}) -> 20
    | ({TypeOfBottle = Bottle1 ; BottleSize = Large}) ->  25
    | ({TypeOfBottle = Bottle2 ; BottleSize = Small}) ->  15
    | ({TypeOfBottle = Bottle2 ; BottleSize = Medium}) -> 20
    | ({TypeOfBottle = Bottle2 ; BottleSize = Large}) ->  25
    | ({TypeOfBottle = Bottle3 ; BottleSize = Small}) ->  15
    | ({TypeOfBottle = Bottle3 ; BottleSize = Medium}) -> 20
    | ({TypeOfBottle = Bottle3 ; BottleSize = Large}) ->  25
    | _ ->  -1

//Sub -Calculate and return the price for Can
let priceCan can : int =
    match can:Can with
    | ({TypeOfCan = Can1 ; CanSize = Small}) ->  15
    | ({TypeOfCan = Can1 ; CanSize = Medium}) -> 20
    | ({TypeOfCan = Can1 ; CanSize = Large}) ->  25
    | ({TypeOfCan = Can2 ; CanSize = Small}) ->  15
    | ({TypeOfCan = Can2 ; CanSize = Medium}) -> 20
    | ({TypeOfCan = Can2 ; CanSize = Large}) ->  25
    | ({TypeOfCan = Can3 ; CanSize = Small}) ->  15
    | ({TypeOfCan = Can3 ; CanSize = Medium}) -> 20
    | ({TypeOfCan = Can3 ; CanSize = Large}) ->  25
    | _ -> -1


//Sub -Calculate and return the price for Cup
let priceCup cup =
    match cup:Cup with
    | ({TypeOfCup = Cup1 ; CupSize = Small}) -> 15
    | ({TypeOfCup = Cup1 ; CupSize = Medium}) ->20
    | ({TypeOfCup = Cup1 ; CupSize = Large}) -> 25
    | ({TypeOfCup = Cup2 ; CupSize = Small}) -> 15
    | ({TypeOfCup = Cup2 ; CupSize = Medium}) ->20
    | ({TypeOfCup = Cup2 ; CupSize = Large}) -> 25
    | ({TypeOfCup = Cup3 ; CupSize = Small}) -> 15
    | ({TypeOfCup = Cup3 ; CupSize = Medium}) ->20
    | ({TypeOfCup = Cup3 ; CupSize = Large}) -> 25
    | _ -> -1

//prereq
type AllDrinks = | Bottles of Bottle
                 | Cans of Can
                 | Cups of Cup



//Calculate the price for a drink(Bottle,Can,Cup)
let giveprice drink =
    match drink: AllDrinks with 
    | Bottles b -> priceBottle(b)
    | Cans ca -> priceCan(ca)
    | Cups cu -> priceCup(cu)
    | _ -> -1


//Part2

//define union message for - sending to the CanteenAgent
type CanteenMessage =  | OrderDrink of AllDrinks * int// Drink, qty
                       | LeaveAComment of string  // ”Comment-super!”

//printing function
let printPriceForDrinks (drink:AllDrinks) (i:int) =
    let price:int = (giveprice drink)*i
    match drink:AllDrinks with
    | Cups c    -> printf "Please pay DKK %i for your %i cofee drinks. Thanks! \n" price i
    | Cans ca   -> printf "Please pay DKK %i for your %i can drinks. Thanks! \n" price i
    | Bottles b -> printf "Please pay DKK %i for your %i bottle drinks. Thanks! \n" price i
    | _         -> failwith "We do not serve that.Thanks! \n"

//Ordering drinks or leave feedback
let orderDrinksProccess canteenMessage =
    match canteenMessage with
    | OrderDrink (drink, qnty) -> printPriceForDrinks drink qnty
    | LeaveAComment comment -> printfn "%A" comment 


;;

//the agent that handles the ordering/feedback
let canteenDrinkAgent = 
        MailboxProcessor.Start(fun inbox -> 
                //define a function to process messeges placed in the inbox queue
              let rec messageLoop = async {
                  let! msg = inbox.Receive()
                //Print the price or the comment!
                  orderDrinksProccess msg 

                   // loop to top
                  return! messageLoop
               }
              messageLoop)
;;

//Testing
//Creating variables of each rec type bottle,can and cup


//Creating variables of each rec type bottle,can and cup
let First:Bottle = {TypeOfBottle = Bottle1; BottleSize = Small}
let Second:Can = {TypeOfCan = Can2; CanSize = Medium}
let Third:Cup = {TypeOfCup = Cup3; CupSize = Large}



let drink1:AllDrinks = Bottles(First)
let drink2:AllDrinks = Cans(Second)
let drink3:AllDrinks = Cups(Third)
let qnty:int = 5


let messageDrink1:CanteenMessage = OrderDrink (drink1, qnty)
let messageDrink2:CanteenMessage = OrderDrink (drink2, qnty)
let messageDrink3:CanteenMessage = OrderDrink (drink3, qnty)
let messageComment:CanteenMessage = CanteenMessage.LeaveAComment "The drink/s was awesome! Great!!! \n"


canteenDrinkAgent.Post messageDrink1
canteenDrinkAgent.Post messageDrink2
canteenDrinkAgent.Post messageDrink3
canteenDrinkAgent.Post messageComment

//final

canteenDrinkAgent.Post (OrderDrink (Cups {TypeOfCup = Cup3; CupSize = Large}, 1))





