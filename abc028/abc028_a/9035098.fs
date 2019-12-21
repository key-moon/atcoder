// detail: https://atcoder.jp/contests/abc028/submissions/9035098
[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    if n < 60 then "Bad" else if n < 90 then "Good" else if n < 100 then "Great" else "Perfect"
    |> stdout.WriteLine
    0
