open System

type Quaternion(w: float, x: float, y: float, z: float) =
    
    member this.W = w
    member this.X = x
    member this.Y = y
    member this.Z = z

    override this.ToString() =
        sprintf "[%g, %gi, %gj, %gk]" w x y z


    member this.Conjugate() =
        Quaternion(w, -x, -y, -z)

    member this.NormSquared() =
        w * w + x * x + y * y + z * z

    member this.Norm() =
        sqrt (this.NormSquared())

    member this.Inverse() =
        let n2 = this.NormSquared()
        if n2 = 0.0 then raise (DivideByZeroException("Nie można odwrócić kwaterionu o normie zerowej."))
        let conj = this.Conjugate()
        Quaternion(conj.W / n2, conj.X / n2, conj.Y / n2, conj.Z / n2)


    static member (+) (q1: Quaternion, q2: Quaternion) =
        Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z)

    static member (-) (q1: Quaternion, q2: Quaternion) =
        Quaternion(q1.W - q2.W, q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z)

    static member (*) (q1: Quaternion, q2: Quaternion) =
        let nw = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z
        let nx = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y
        let ny = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X
        let nz = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W
        Quaternion(nw, nx, ny, nz)

    static member (*) (q: Quaternion, scalar: float) =
        Quaternion(q.W * scalar, q.X * scalar, q.Y * scalar, q.Z * scalar)

    static member (*) (scalar: float, q: Quaternion) =
        q * scalar

    static member (/) (q1: Quaternion, q2: Quaternion) =
        q1 * q2.Inverse()

    static member (/) (q: Quaternion, scalar: float) =
        if scalar = 0.0 then raise (DivideByZeroException("Nie można dzielić przez zero."))
        Quaternion(q.W / scalar, q.X / scalar, q.Y / scalar, q.Z / scalar)

    static member (~-) (q: Quaternion) =
        Quaternion(-q.W, -q.X, -q.Y, -q.Z)

let testQuaternions () =
    let q1 = Quaternion(1.0, 2.0, 3.0, 4.0)
    let q2 = Quaternion(0.5, -1.0, 2.0, -0.5)

    printfn "q1 = %O" q1
    printfn "q2 = %O" q2
    printfn "-------------------------------------------------"
    printfn "q1 + q2 = %O" (q1 + q2)
    printfn "q1 - q2 = %O" (q1 - q2)
    
    printfn "q1 * q2 = %O" (q1 * q2)
    printfn "q2 * q1 = %O" (q2 * q1) 
    
    printfn "q1 * 2.0 = %O" (q1 * 2.0)
    
    printfn "Sprzężenie q1: %O" (q1.Conjugate())
    printfn "Odwrotność q2: %O" (q2.Inverse())
    
    printfn "q1 / q2 = %O" (q1 / q2)

testQuaternions ()