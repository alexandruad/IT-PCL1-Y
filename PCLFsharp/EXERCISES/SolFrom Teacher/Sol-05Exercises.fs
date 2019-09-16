module Sol_05Exercises

// 5.1
let countNumOfVowels (str : string) =
        let charList = List.ofSeq str  
        let accFunc (As, Es, Is, Os, Us) letter =
            (*
            if letter = 'a' then (As + 1, Es, Is, Os, Us)
            elif letter = 'e' then (As, Es + 1, Is, Os, Us)
            elif letter = 'i' then (As, Es, Is + 1, Os, Us)
            elif letter = 'o' then (As, Es, Is, Os + 1, Us)
            elif letter = 'u' then (As, Es, Is, Os, Us + 1)
            else (As, Es, Is, Os, Us)
            *)
            // better with pattern matching
            match letter with
             | 'a' -> (As + 1, Es, Is, Os, Us)
             | 'e' -> (As, Es + 1, Is, Os, Us)
             | 'i' -> (As, Es, Is + 1, Os, Us)
             | 'o' -> (As, Es, Is, Os + 1, Us)
             | 'u' -> (As, Es, Is, Os, Us + 1)
             | _   -> (As, Es, Is, Os, Us)
        List.fold accFunc (0, 0, 0, 0, 0) charList

// 5.2
let primesUpTo n =
        [
            for num in 1 .. n do 
                let factorsOfNum =
                    [
                        for j in 1 .. num do 
                            if num % j = 0 then yield j
                    ]
                if List.length factorsOfNum = 2 then yield num
        ]

// 5.3
let rec pclFib n = 
     if n <= 2 then 1
     else pclFib (n - 1) + pclFib (n - 2)

// 5.4
let doubleNum x = 2 * x
let sqrNum x = x * x

// apply functions twice
let pclQuad x = doubleNum (doubleNum x)
let pclFourth x = sqrNum (sqrNum x)