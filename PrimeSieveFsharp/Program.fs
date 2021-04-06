open System

let primeCounts = Map.ofList([ 
    10, 1               // Historical data for validating our results - the number of prim)
    100, 25            // to be found under some limit, such as 168 primes under 10)
    1000, 168
    10000, 1229
    100000, 9592
    1000000, 78498
    10000000, 664579
    100000000, 5761455
]) 

let initPrimeSieve sieveSize = Array.init sieveSize (fun _ -> true)

let filterPrimes bitArray =
    [|3..2..Array.length bitArray|]
    |> Array.filter (fun index -> bitArray.[index])

let countPrimes (primes: int[]) = Array.length primes + 1

let validateResults primeCounts sieveSize primes =
    match Map.tryFind sieveSize primeCounts with
    | Some expected -> expected = countPrimes primes
    | None -> false

let runSieve sieveSize (bitArray: bool[]) =
    let mutable factor = 3
    let mutable num = 0
    let q = Math.Sqrt (float sieveSize) |> int

    while factor < q do
        factor <- seq {factor..2..sieveSize} |> Seq.find (fun i -> bitArray.[i])

        num <- factor * factor
        while num <= sieveSize do
            bitArray.[num] <- false
            num <- num + factor * 2

        factor <- factor + 2
    bitArray

let printResults showResults duration passes sieveSize bitArray =
    let primes = bitArray |> filterPrimes 

    if showResults then 
        printf "2, "
        primes |> Array.iter (fun b -> printf "%i, " b)
        printfn ""

    printfn "Passes: %d, Time: %f, Avg: %f, Limit: %d, Count: %d, Valid: %b"
        passes
        duration
        (duration / (float passes))
        sieveSize
        (countPrimes primes)
        (validateResults primeCounts sieveSize primes)

[<EntryPoint>]
let main argv =
    let mutable passes = 0
    let sieveSize = 1_000_000
    let tStart = DateTime.UtcNow

    while (DateTime.UtcNow - tStart).TotalSeconds < 5. do
        initPrimeSieve sieveSize |> runSieve sieveSize |> ignore
        passes <- passes + 1

    let tD = DateTime.UtcNow - tStart

    initPrimeSieve sieveSize 
    |> runSieve sieveSize
    |> printResults false tD.TotalSeconds passes sieveSize
    0 // return an integer exit code