// detail: https://atcoder.jp/contests/abc077/submissions/9035463
[<EntryPoint>]
let main argv =
    if stdin.ReadLine() = (stdin.ReadLine() |> Seq.rev |> Seq.map string |> String.concat "") then "YES" else "NO"
    |> stdout.WriteLine
    0
