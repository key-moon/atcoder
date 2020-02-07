// detail: https://atcoder.jp/contests/abc147/submissions/9937024
let s = stdin.ReadLine()
s |> Seq.rev |> Seq.zip s |> Seq.take ((s.Length + 1) / 2) 
|> Seq.sumBy (fun (a, b) -> if a = b then 0 else 1)
|> stdout.WriteLine
