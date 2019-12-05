// detail: https://atcoder.jp/contests/abc112/submissions/8796346
open System

[<EntryPoint>]
let main argv =
    if Console.ReadLine () = "1" then 
        "Hello World" 
    else 
        let rint () = Console.ReadLine () |> int
        rint () + rint ()
        |> Convert.ToString
    |> Console.WriteLine
    0
