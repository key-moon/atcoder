// detail: https://atcoder.jp/contests/abc037/submissions/9044840
[<EntryPoint>]
let main argv =
    let abc = stdin.ReadLine().Split() |> Array.map int
    abc.[2] / (abc |> Array.take 2 |> Array.min)
    |> stdout.WriteLine
    0
