// detail: https://atcoder.jp/contests/abc045/submissions/9046855
[<EntryPoint>]
let main argv =
    let rint () = stdin.ReadLine() |> int
    (rint() + rint()) * rint() / 2
    |> stdout.WriteLine
    0
