// detail: https://atcoder.jp/contests/abc019/submissions/9032766
[<EntryPoint>]
let main argv =
    (stdin.ReadLine().Split() |> Array.map int |> Array.sort).[1] |> stdout.WriteLine
    0
