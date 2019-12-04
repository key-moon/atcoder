// detail: https://atcoder.jp/contests/abc139/submissions/8784377
open System

[<EntryPoint>]
let main argv =
    let readchararr () = Console.ReadLine().ToCharArray()
    let s,t = readchararr(), readchararr()
    s |> (t |> Array.fold2 (fun state a b -> if a = b then state + 1 else state) 0)
    |> Console.WriteLine
    0
