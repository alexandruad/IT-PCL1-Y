#light

module MiniProjectPhase1
(*Part1*)
//union for the Size
type DrinkSize = | Large | Medium | Small

//union for the type of drink
type TypeOfContainer = | Can | Bottle | Cup

//union for typeOfDrink
type TypeOfDrink = | Cup1 | Cup2 | Cup3  | Bottle1 | Bottle2 | Bottle3 | Can1 | Can2 | Can3

//record for the data drink type
type DrinkRec= { DrinkSizeX : DrinkSize; TypeOfContainerX : TypeOfContainer; TypeOfDrinkX : TypeOfDrink}

//function to calculate the price
let getPrice (drinkRecY:DrinkRec) =
    match drinkRecY.TypeOfContainerX with
     |TypeOfContainer.Bottle ->
            match drinkRecY.TypeOfDrinkX with
             | TypeOfDrink.Bottle1 -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large -> 25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | TypeOfDrink.Bottle2  -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large ->  25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | TypeOfDrink.Bottle3  -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large -> 25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | _ ->  0
     |TypeOfContainer.Can ->
            match drinkRecY.TypeOfDrinkX with
             | TypeOfDrink.Can1 -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large -> 25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | TypeOfDrink.Can2  -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large -> 25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | TypeOfDrink.Can3  -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large ->  25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | _ -> 0
     |TypeOfContainer.Cup ->
            match drinkRecY.TypeOfDrinkX with
             | TypeOfDrink.Cup1 -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large -> 25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | TypeOfDrink.Cup2  -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large -> 25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | TypeOfDrink.Cup3  -> 
                match drinkRecY.DrinkSizeX with
                 |DrinkSize.Large -> 25
                 |DrinkSize.Medium -> 15
                 |DrinkSize.Small -> 10
             | _ ->  0

(*Part1*)

//define union message for - sending to the CanteenAgent
type CanteenMessage =  | OrderDrink of DrinkRec * int// Drink, qty
                       | LeaveAComment of string  // ”Comment-super!”

let printPriceForDrinks (drink:DrinkRec) (i:int) =
    let price:int = (getPrice drink)*i
    match drink.TypeOfContainerX with
    | TypeOfContainer.Cup    -> printf "Please pay DKK %i for your %i cofee drinks. Thanks! " price i
    | TypeOfContainer.Can   -> printf "Please pay DKK %i for your %i can drinks. Thanks! " price i
    | TypeOfContainer.Bottle -> printf "Please pay DKK %i for your %i bottle drinks. Thanks! " price i

//Ordering drinks or leave feedback
let orderDrinksProccess canteenMessage =
    match canteenMessage with
    | OrderDrink (drink, qnty) -> printPriceForDrinks drink qnty
    | LeaveAComment comment -> printfn "%A" comment 

//the agent that handles the ordering/feedback
let canteenDrinkAgent = 
        MailboxProcessor.Start(fun inbox -> 
                //define a function to process messeges placed in the inbox queue
              let rec messageLoop = async {
                  let! msg = inbox.Receive()
                //Print the price or the comment!
                  orderDrinksProccess msg |>ignore
                  System.Threading.Thread.Sleep 1000
                   // loop to top
                  return! messageLoop
               }
              messageLoop)

//Testing

//Creating variables of each rec type bottle,can and cup
let drinkY:DrinkRec = { DrinkSizeX = DrinkSize.Large ; TypeOfContainerX = TypeOfContainer.Bottle; TypeOfDrinkX = TypeOfDrink.Bottle1} 
let qnty:int = 5

let messageDrink:CanteenMessage = OrderDrink (drinkY, qnty)
let messageComment:CanteenMessage = CanteenMessage.LeaveAComment "The drink/s was awesome! Great!!!"

canteenDrinkAgent.Post messageDrink
canteenDrinkAgent.Post messageComment


