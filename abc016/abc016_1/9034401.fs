// detail: https://atcoder.jp/contests/abc016/submissions/9034401
[<EntryPoint>]
let main argv =
    let md = stdin.ReadLine().Split() |> Array.map int
    if md.[0] % md.[1] = 0 then "YES" else "NO"
    |> stdout.WriteLine
    0
