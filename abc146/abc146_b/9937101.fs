// detail: https://atcoder.jp/contests/abc146/submissions/9937101
let n = stdin.ReadLine() |> int
let s = stdin.ReadLine()
s |> String.collect (fun x -> ((int x) + n - 65) % 26 + 65 |> char |> string) 
|> stdout.WriteLine
