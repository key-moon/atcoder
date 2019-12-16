// detail: https://atcoder.jp/contests/abc088/submissions/8974917
[<EntryPoint>]
let main argv =
    let rint () = stdin.ReadLine() |> int
    if rint () % 500 <= rint () then "Yes" else "No"
    |> stdout.WriteLine
    0
