// detail: https://atcoder.jp/contests/abc092/submissions/8974825
open System

[<EntryPoint>]
let main argv =
    let rint () = stdin.ReadLine() |> int
    (min (rint ()) (rint ())) + (min (rint ()) (rint ()))
    |> stdout.WriteLine
    0
