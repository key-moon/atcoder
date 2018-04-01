// detail: https://atcoder.jp/contests/abc086/submissions/2293024
open System
open System.Text;
open System.Linq
open System.Collections.Generic

[<EntryPoint>]
let main _ = 
    let ab = Console.ReadLine().Split() |> Array.map int
    Console.WriteLine(if (ab.[0] * ab.[1]) % 2 = 0 then  "Even" else "Odd")
    0
