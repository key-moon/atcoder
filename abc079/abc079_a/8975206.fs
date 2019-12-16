// detail: https://atcoder.jp/contests/abc079/submissions/8975206
[<EntryPoint>]
let main argv =
    let s = stdin.ReadLine()
    let isGoodString s = s |> Seq.distinct |> Seq.length = 1
    if isGoodString s.[0..2] || isGoodString s.[1..3] then "Yes" else "No" 
    |> stdout.WriteLine
    0
