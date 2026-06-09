open System


type Token =
    | Number of float
    | Plus
    | Minus
    | Multiply
    | Divide
    | LParen
    | RParen
    | EOF

type Expr =
    | Value of float
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr
    | Neg of Expr

let tokenize (input: string) : Token list =
    let rec loop i acc =
        if i >= input.Length then 
            List.rev (EOF :: acc)
        else
            let c = input.[i]
            if Char.IsWhiteSpace(c) then 
                loop (i + 1) acc
            elif c = '+' then loop (i + 1) (Plus :: acc)
            elif c = '-' then loop (i + 1) (Minus :: acc)
            elif c = '*' then loop (i + 1) (Multiply :: acc)
            elif c = '/' then loop (i + 1) (Divide :: acc)
            elif c = '(' then loop (i + 1) (LParen :: acc)
            elif c = ')' then loop (i + 1) (RParen :: acc)
            elif Char.IsDigit(c) || c = '.' then
                let rec readNum j =
                    if j < input.Length && (Char.IsDigit(input.[j]) || input.[j] = '.') then readNum (j + 1)
                    else j
                let next_i = readNum i
                let numStr = input.Substring(i, next_i - i)
                let num = float (numStr.Replace(',', '.'))
                loop next_i (Number num :: acc)
            else 
                failwithf "Błąd leksykalny: Nieznany znak '%c' na pozycji %d" c i
    
    loop 0 []

let parse (tokens: Token list) : Expr =
    
    let rec parseExpression toks =
        let expr, rest = parseTerm toks
        parseExprTail expr rest

    and parseExprTail leftExpr toks =
        match toks with
        | Plus :: rest ->
            let rightExpr, rest2 = parseTerm rest
            parseExprTail (Add(leftExpr, rightExpr)) rest2
        | Minus :: rest ->
            let rightExpr, rest2 = parseTerm rest
            parseExprTail (Sub(leftExpr, rightExpr)) rest2
        | _ -> leftExpr, toks

    and parseTerm toks =
        let fact, rest = parseFactor toks
        parseTermTail fact rest

    and parseTermTail leftFact toks =
        match toks with
        | Multiply :: rest ->
            let rightFact, rest2 = parseFactor rest
            parseTermTail (Mul(leftFact, rightFact)) rest2
        | Divide :: rest ->
            let rightFact, rest2 = parseFactor rest
            parseTermTail (Div(leftFact, rightFact)) rest2
        | _ -> leftFact, toks

    and parseFactor toks =
        match toks with
        | Number n :: rest -> 
            Value n, rest
        | Minus :: rest -> 
            let expr, rest2 = parseFactor rest
            Neg(expr), rest2
        | LParen :: rest ->
            let expr, rest2 = parseExpression rest
            match rest2 with
            | RParen :: rest3 -> expr, rest3
            | _ -> failwith "Błąd składniowy: Brakujący nawias zamykający ')'."
        | EOF :: _ -> failwith "Błąd składniowy: Nieoczekiwany koniec wyrażenia."
        | token :: _ -> failwithf "Błąd składniowy: Nieoczekiwany token %A" token
        | [] -> failwith "Błąd składniowy: Brak tokenów."

    let ast, remainingTokens = parseExpression tokens
    
    match remainingTokens with
    | [EOF] -> ast
    | token :: _ -> failwithf "Błąd składniowy: Nadmiarowe tokeny na końcu wyrażenia: %A" token
    | [] -> ast

let rec evaluate (ast: Expr) : float =
    match ast with
    | Value n -> n
    | Add (left, right) -> evaluate left + evaluate right
    | Sub (left, right) -> evaluate left - evaluate right
    | Mul (left, right) -> evaluate left * evaluate right
    | Div (left, right) -> 
        let r = evaluate right
        if r = 0.0 then raise (DivideByZeroException("Dzielenie przez zero!"))
        evaluate left / r
    | Neg expr -> -(evaluate expr)

let calculate (expression: string) =
    printfn "\nOryginalne wyrażenie: %s" expression
    try
        let tokens = tokenize expression
        printfn "Tokeny: %A" tokens
        
        let ast = parse tokens
        printfn "Drzewo AST: %A" ast
        
        let result = evaluate ast
        printfn "Wynik: %g" result
    with
        | ex -> printfn "BŁĄD: %s" ex.Message

calculate "2 + 2 * 2"               // Kolejność działań
calculate "(2 + 2) * 2"             // Nawiasy
calculate "-5.5 + 10 / 2"           // Liczby zmiennoprzecinkowe i minus unarny
calculate "3 * (4 + 5 * (2 - 1))"   // Zagnieżdżone nawiasy