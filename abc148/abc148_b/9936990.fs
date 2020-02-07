// detail: https://atcoder.jp/contests/abc148/submissions/9936990
let n = stdin.ReadLine() |> int
let st = stdin.ReadLine().Split()
Seq.zip st.[0] st.[1] |> Seq.map (fun (a, b) -> (string a) + (string b)) |> String.concat "" |> stdout.WriteLine
