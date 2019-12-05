// detail: https://atcoder.jp/contests/abc102/submissions/8798474
open System


[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> int
    if n % 2 = 0 then n else 2 * n 
    |> Console.WriteLine
    0
