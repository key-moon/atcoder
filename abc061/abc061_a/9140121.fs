// detail: https://atcoder.jp/contests/abc061/submissions/9140121
[<EntryPoint>]
let main argv =
    let abc = stdin.ReadLine().Split() |> Array.map int 
    let a = abc.[0]
    let b = abc.[1]
    let c = abc.[2]
    if a <= c && c <= b then "Yes" else "No"
    |> stdout.WriteLine
    0
