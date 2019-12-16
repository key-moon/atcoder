// detail: https://atcoder.jp/contests/abc080/submissions/8975159
[<EntryPoint>]
let main argv =
    let nab = stdin.ReadLine().Split() |> Array.map int
    min (nab.[0] * nab.[1]) nab.[2] |> stdout.WriteLine
    0
