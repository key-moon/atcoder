// detail: https://atcoder.jp/contests/abc142/submissions/9937325
let k = stdin.ReadLine().Split() |> Array.last |> int
stdin.ReadLine().Split() |> Array.map int |> Array.filter (fun x -> k <= x) |> Array.length
|> stdout.WriteLine
