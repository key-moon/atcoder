// detail: https://atcoder.jp/contests/abc058/submissions/9051990
[<EntryPoint>]
let main argv =
    let abc = stdin.ReadLine().Split() |> Array.map int
    if abc.[1] - abc.[0] = abc.[2] - abc.[1] then "YES" else "NO"
    |> stdout.WriteLine
    0
