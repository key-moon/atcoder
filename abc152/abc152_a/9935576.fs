// detail: https://atcoder.jp/contests/abc152/submissions/9935576
[<EntryPoint>]
let main argv =
    if stdin.ReadLine().Split() |> Array.map int |> Array.reduce (-) = 0 then "Yes" else "No"
    |> stdout.WriteLine
    0
