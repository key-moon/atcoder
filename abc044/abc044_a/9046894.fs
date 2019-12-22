// detail: https://atcoder.jp/contests/abc044/submissions/9046894
[<EntryPoint>]
let main argv =
    let rint () = stdin.ReadLine() |> int
    let n = rint ()
    let k = rint ()
    let a = rint ()
    let b = rint ()
    n * a - (a - b) * (max (n - k) 0)
    |> stdout.WriteLine
    0
