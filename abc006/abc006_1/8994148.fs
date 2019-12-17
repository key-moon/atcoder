// detail: https://atcoder.jp/contests/abc006/submissions/8994148
[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    if n % 3 = 0 then "YES" else "NO"
    |> stdout.WriteLine
    0
