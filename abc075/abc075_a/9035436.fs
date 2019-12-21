// detail: https://atcoder.jp/contests/abc075/submissions/9035436
[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split()
    |> Array.fold (fun x y -> x ^^^ (int y)) 0
    |> stdout.WriteLine
    0
