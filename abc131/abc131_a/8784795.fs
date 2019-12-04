// detail: https://atcoder.jp/contests/abc131/submissions/8784795
open System

[<EntryPoint>]
let main argv =
    let s = Console.ReadLine().ToCharArray()
    (if Array.exists2 (fun a b -> a = b) (s |> Array.take 3) (s |> Array.skip 1) then "Bad" else "Good")
    |> Console.WriteLine
    0
