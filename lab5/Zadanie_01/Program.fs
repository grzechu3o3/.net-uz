// Prosta rekurencja - silnia
let rec factorial n =
    match n with
    | 0 | 1 -> 1
    | n   -> n * factorial (n - 1)

printfn "Silnia: %d" (factorial 6)

// Ciag fibonacciego
let rec fib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | n -> fib (n - 1) + fib (n - 2)

printfn "Fibonacci: %d" (fib 10)

// suma elementow listy
let rec sumList lst =
    match lst with
    | []          -> 0
    | head :: tail -> head + sumList tail
    
printfn "Suma elementów listy: %d" (sumList [1; 2; 3; 4; 5])

// implementacja List.map
let rec myMap f lst =
    match lst with
    | []          -> []
    | head :: tail -> f head :: myMap f tail

let mapa = myMap (fun x -> x * 2) [1; 2; 3]
let mapa2 = myMap string [10; 20; 30]

// Używamy %A do wypisywania całych list
printfn "Mapa (x * 2): %A" mapa
printfn "Mapa2 (jako tekst): %A" mapa2

// implementacja List.filter
let rec myFilter pred lst =
    match lst with
    | []          -> []
    | head :: tail when pred head -> head :: myFilter pred tail
    | _ :: tail                    -> myFilter pred tail

// Liczby parzyste
let parzyste = myFilter (fun x -> x % 2 = 0) [1;2;3;4;5;6]
printfn "Liczby parzyste z listy: %A" parzyste

// Odwrocenie listy
let rec reverseNaive lst =
    match lst with
    | []          -> []
    | head :: tail -> reverseNaive tail @ [head]

let odwrocona = reverseNaive [1; 2; 3; 4; 5]
printfn "Odwrócona lista: %A" odwrocona