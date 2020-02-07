// detail: https://atcoder.jp/contests/abc145/submissions/9937155
let n = stdin.ReadLine() |> int
let s = stdin.ReadLine()
if 
    s.Length % 2 = 0 && 
    (s |> Seq.take(n / 2)) |> Seq.forall2 (fun a b -> a = b) (s |> Seq.skip(n / 2)) 
then "Yes" else "No"
|> stdout.WriteLine
