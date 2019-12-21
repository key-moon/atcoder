// detail: https://atcoder.jp/contests/abc033/submissions/9044910
[<EntryPoint>]
let main argv =
    if (stdin.ReadLine() |> Seq.distinct |> Seq.length) = 1 then "SAME" else "DIFFERENT"
    |> stdout.WriteLine
    0
