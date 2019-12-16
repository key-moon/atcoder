// detail: https://atcoder.jp/contests/abc078/submissions/8975215
[<EntryPoint>]
let main argv =
    let s = stdin.ReadLine()
    let x = s.[0]
    let y = s.[2]
    if x < y then "<" else if x > y then ">" else "=" 
    |> stdout.WriteLine
    0
