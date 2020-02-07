// detail: https://atcoder.jp/contests/abc150/submissions/9935548
[<EntryPoint>]
let main argv =
    let kx = stdin.ReadLine().Split() |> Array.map int
    if kx.[0] * 500 >= kx.[1] then "Yes" else "No" 
    |> stdout.WriteLine
    0
