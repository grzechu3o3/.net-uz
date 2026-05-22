module ComplexNumbers

type Complex(re: float, im: float) =

    member _.Re = re
    member _.Im = im

    member _.Modulus = sqrt (re * re + im * im)

    member _.Argument = atan2 im re

    member _.Conjugate = Complex(re, -im)

    static member (+) (a: Complex, b: Complex) =
        Complex(a.Re + b.Re, a.Im + b.Im)

    static member (-) (a: Complex, b: Complex) =
        Complex(a.Re - b.Re, a.Im - b.Im)

    static member (*) (a: Complex, b: Complex) =
        Complex(a.Re * b.Re - a.Im * b.Im,
                a.Re * b.Im + a.Im * b.Re)

    static member (/) (a: Complex, b: Complex) =
        let denom = b.Re * b.Re + b.Im * b.Im
        if denom = 0.0 then failwith "Dzielenie przez zero"
        Complex((a.Re * b.Re + a.Im * b.Im) / denom,
                (a.Im * b.Re - a.Re * b.Im) / denom)

    static member (~-) (a: Complex) =
        Complex(-a.Re, -a.Im)

    static member (*) (a: Complex, s: float) =
        Complex(a.Re * s, a.Im * s)

    static member (*) (s: float, a: Complex) =
        Complex(a.Re * s, a.Im * s)

    static member (/) (a: Complex, s: float) =
        if s = 0.0 then failwith "Dzielenie przez zero"
        Complex(a.Re / s, a.Im / s)

    static member (=~) (a: Complex, b: Complex) =
        let eps = 1e-10
        abs (a.Re - b.Re) < eps && abs (a.Im - b.Im) < eps

    override _.Equals(obj) =
        match obj with
        | :? Complex as b -> re = b.Re && im = b.Im
        | _ -> false

    override _.GetHashCode() = hash (re, im)

    static member FromReal(r: float) = Complex(r, 0.0)
    static member FromImaginary(i: float) = Complex(0.0, i)

    override _.ToString() =
        match re, im with
        | r, 0.0 -> sprintf "%g" r
        | 0.0, i -> sprintf "%gi" i
        | r, i when i < 0.0 -> sprintf "%g - %gi" r (abs i)
        | r, i -> sprintf "%g + %gi" r i


module Complex =

    let zero = Complex(0.0, 0.0)
    let one  = Complex(1.0, 0.0)
    let i    = Complex(0.0, 1.0)

    let ofReal r    = Complex(r, 0.0)
    let ofImag im   = Complex(0.0, im)
    let create r im = Complex(r, im)

    // e^(iθ) = cos θ + i·sin θ  (wzór Eulera)
    let fromPolar modulus angle =
        Complex(modulus * cos angle, modulus * sin angle)

    let abs  (z: Complex) = z.Modulus
    let conj (z: Complex) = z.Conjugate
    let arg  (z: Complex) = z.Argument

    let sqrt (z: Complex) =
        let r   = z.Modulus
        let sgn = if z.Im < 0.0 then -1.0 else 1.0
        Complex(System.Math.Sqrt((r + z.Re) / 2.0),
                sgn * System.Math.Sqrt((r - z.Re) / 2.0))

    let rec pow (z: Complex) (n: int) =
        if   n = 0 then one
        elif n < 0 then one / pow z (-n)
        elif n % 2 = 0 then
            let half = pow z (n / 2)
            half * half
        else z * pow z (n - 1)

    let exp (z: Complex) =
        let e = System.Math.Exp(z.Re)
        Complex(e * cos z.Im, e * sin z.Im)

    let log (z: Complex) =
        Complex(System.Math.Log(z.Modulus), z.Argument)

[<EntryPoint>]
let main _ =
    let a = Complex(3.0,  4.0)   //  3 + 4i
    let b = Complex(1.0, -2.0)   //  1 - 2i

    printfn "=== Liczby zespolone ==="
    printfn "a = %O" a
    printfn "b = %O" b
    printfn ""
    printfn "a + b  = %O" (a + b)
    printfn "a - b  = %O" (a - b)
    printfn "a * b  = %O" (a * b)
    printfn "a / b  = %O" (a / b)
    printfn "-a     = %O" (-a)
    printfn ""
    printfn "|a|    = %.4f" (Complex.abs a)
    printfn "arg(a) = %.4f rad" (Complex.arg a)
    printfn "a*     = %O"   (Complex.conj a)
    printfn "√a     = %O"   (Complex.sqrt a)
    printfn "a³     = %O"   (Complex.pow a 3)
    printfn ""
    printfn "Euler: e^(iπ) = %O  (≈ -1)" (Complex.exp (Complex(0.0, System.Math.PI)))
    printfn ""
    printfn "Skalowanie: 2.5 * a = %O" (2.5 * a)
    printfn "a =~ a         : %b" (a =~ a)
    printfn "a =~ b         : %b" (a =~ b)
    0