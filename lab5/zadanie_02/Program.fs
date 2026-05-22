open System

let rec gcd a b =
    if b = 0 then abs a else gcd b (a % b)

type Fraction(numerator: int, denominator: int) =
    do if denominator = 0 then raise (DivideByZeroException("Mianownik nie może być zerem."))

    let divisor = gcd numerator denominator
    let sign = if denominator < 0 then -1 else 1
    
    let num = sign * (numerator / divisor)
    let den = sign * (denominator / divisor)

    member this.Numerator = num
    member this.Denominator = den

    override this.ToString() = 
        if den = 1 then sprintf "%d" num
        else sprintf "%d/%d" num den


    static member (+) (f1: Fraction, f2: Fraction) =
        let newNum = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator
        let newDen = f1.Denominator * f2.Denominator
        Fraction(newNum, newDen)

    static member (-) (f1: Fraction, f2: Fraction) =
        let newNum = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator
        let newDen = f1.Denominator * f2.Denominator
        Fraction(newNum, newDen)

    static member (*) (f1: Fraction, f2: Fraction) =
        let newNum = f1.Numerator * f2.Numerator
        let newDen = f1.Denominator * f2.Denominator
        Fraction(newNum, newDen)

    static member (/) (f1: Fraction, f2: Fraction) =
        if f2.Numerator = 0 then raise (DivideByZeroException("Nie można dzielić przez ułamek o wartości zero."))
        let newNum = f1.Numerator * f2.Denominator
        let newDen = f1.Denominator * f2.Numerator
        Fraction(newNum, newDen)

    static member (~-) (f: Fraction) =
        Fraction(-f.Numerator, f.Denominator)

let testFractions () =
    let u1 = Fraction(1, 2)
    let u2 = Fraction(3, 4)
    let u3 = Fraction(2, -8)

    printfn "u1 = %O" u1
    printfn "u2 = %O" u2
    printfn "u3 = %O (skrócone z 2/-8)" u3
    printfn "----------------"
    printfn "u1 + u2 = %O" (u1 + u2)
    printfn "u1 - u2 = %O" (u1 - u2)
    printfn "u1 * u2 = %O" (u1 * u2)
    printfn "u1 / u2 = %O" (u1 / u2)
    printfn "-u1     = %O" (-u1)

testFractions ()