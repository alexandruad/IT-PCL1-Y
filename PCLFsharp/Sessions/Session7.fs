
#light
module Session7

//tail recursive

//accumulator

let sumListTR ls =
    let rec sumListHelper(ls, total) =
        match ls with
        | [] -> total
        | hd::tl->
            let ntotal= hd + total
            sumListHelper(tl, ntotal) 
    sumListHelper(ls, 0)

sumListTR [1..10];;

//Continuations

let rec printListRevTR list cont =
    match list with
    // For an emptylist, executethe continuation
    | [] -> cont()
    // For otherlists, addprintingthe current
    // node as part of the continuation.
    | hd::tl ->
        printListRevTR tl (fun () -> printf"%d " hd 
                                     count() )

printListRevTRlist (fun() -> printfn"Done!")
;;

//Sequences
let seQNumbers = seq { 1 .. 5 }
seQNumbers |> Seq.iter (printf"%d ")

//Maps

let someHollyDay2019 =
    [
    ("MaundyThrusday1"),("April 17");
    ("MaundyThrusday2"),("April 18");
    ("MaundyThrusday3"),("April 19")
    ]
    |> Map.ofList

someHollyDay2019.["MaundyThrusday1"];;