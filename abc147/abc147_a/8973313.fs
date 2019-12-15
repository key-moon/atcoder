// detail: https://atcoder.jp/contests/abc147/submissions/8973313
[<EntryPoint>]
let main argv =
    if (stdin.ReadLine().Split() |> Array.sumBy int) <= 21 then "win" else "bust"
    |> stdout.WriteLine
    0
