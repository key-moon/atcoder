// detail: https://atcoder.jp/contests/abc132/submissions/8784696
open System

[<EntryPoint>]
let main argv =
    let s = Console.ReadLine().ToCharArray()
    (if s 
        |> Array.groupBy (fun x -> x) 
        |> Array.forall (fun (key, elems) -> elems |> Array.length = 2) then 
        "Yes" 
    else 
        "No") |> Console.WriteLine
    0
