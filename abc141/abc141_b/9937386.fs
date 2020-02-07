// detail: https://atcoder.jp/contests/abc141/submissions/9937386
if
    stdin.ReadLine() |> Seq.indexed
    |> Seq.exists (fun (ind, elem) -> (elem = 'R' && ind % 2 = 1) ||(elem = 'L' && ind % 2 = 0))
then "No" else "Yes"
|> stdout.WriteLine
