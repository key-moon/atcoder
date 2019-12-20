// detail: https://atcoder.jp/contests/abc014/submissions/9029780
[<EntryPoint>]
let main argv =
    let rint () = stdin.ReadLine() |> int
    let a = rint()
    let b = rint()
    (b * 100 - a) % b |> stdout.WriteLine
    0
