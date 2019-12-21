// detail: https://atcoder.jp/contests/abc027/submissions/9035070
[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split()
    |> Array.fold (fun x y -> x ^^^ (int y)) 0
    |> stdout.WriteLine
    0
