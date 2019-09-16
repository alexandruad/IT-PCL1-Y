module Session1

//tuple construction

let student1 = (123, "Hey1")
let student2 = (456, "Hey2")

//Deconstruct with pattern First and Second parameter from tuple
let aNumber = fst student1
let aName = snd student1

//3 paramTuple get specific params

let student3 = (12345  , "Name", "Data")
let (_, _, special) = student3


//Vectors addition
let vectorAddInt(x1, y1) (x2, y2) = (x1 + x2, y1 + y2)

let vectorAddFloat(x1, y1) (x2, y2) = (x1 + x2, y1 + y2) : float * float

//TODO substraction and length
let vectorSub (x1, y1) (x2, y2) = (x1 - x2, y1 - y2) : float * float

let vectorLen(x : float, y : float) = sqrt x*x + y*y



//List
let x = [1..10]
let tens = [0 .. 10 .. 50]
