module From_book

 // Sequence of words (Arrays are compatible with sequences)
let words = "The quick brown fox jumped over the lazy dog".Split( [| ' ' |]);;
//val words : string [] = [|"The"; "quick"; "brown"; "fox"; "jumped"; "over"; "the"; "lazy"; "dog"|]

 // Map strings to string, length tuples
words |> Seq.map (fun word -> word, word.Length);;
//val it : seq<string * int> =
//seq [("The", 3); ("quick", 5); ("brown", 5); ("fox", 3); ...]



Seq.fold (+) 0 <| seq { 1 .. 100 };;