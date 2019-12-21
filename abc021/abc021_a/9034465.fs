// detail: https://atcoder.jp/contests/abc021/submissions/9034465
[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine()
    n |> stdout.WriteLine
    Array.create (n |> int) "1"
    |> String.concat "
"
    |> stdout.WriteLine
    0
