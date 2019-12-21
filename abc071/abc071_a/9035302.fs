// detail: https://atcoder.jp/contests/abc071/submissions/9035302
[<EntryPoint>]
let main argv =
    let xab = stdin.ReadLine().Split() |> Array.map int
    let x = xab.[0]
    let a = xab.[1]
    let b = xab.[2]
    if abs(x - a) < abs(x - b) then "A" else "B"
    |> stdout.WriteLine
    0
