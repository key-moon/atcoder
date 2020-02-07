// detail: https://atcoder.jp/contests/abc153/submissions/9935634
let ha = stdin.ReadLine().Split() |> Array.map int
let (h, a) = (ha.[0], ha.[1])
(h + a - 1) / a |> stdout.WriteLine
