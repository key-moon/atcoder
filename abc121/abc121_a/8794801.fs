// detail: https://atcoder.jp/contests/abc121/submissions/8794801
open System

[<EntryPoint>]
let main argv =
    let rsint () = Console.ReadLine().Split() |> Array.map int
    Array.map2 (fun x y -> x - y) (rsint()) (rsint()) 
    |> Array.fold (fun x y -> x * y) 1
    |> Console.WriteLine
    0
