// detail: https://atcoder.jp/contests/abc140/submissions/9937464
let n = stdin.ReadLine() |> int
let rsint () = stdin.ReadLine().Split() |> Array.map int
let a = rsint()
let b = rsint()
let c = rsint()
(a |> Array.sumBy (fun x -> b.[x - 1])) + 
(a |> Array.take (n - 1) |> Array.zip (a |> Array.skip 1)
    |> Array.sumBy (fun (x, y) -> if (x - 1) = y then c.[y - 1] else 0))
|> stdout.WriteLine
