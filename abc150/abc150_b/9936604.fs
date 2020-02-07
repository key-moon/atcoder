// detail: https://atcoder.jp/contests/abc150/submissions/9936604
stdin.ReadLine() |> ignore
let s = stdin.ReadLine()
[|0..(s.Length - 3)|] |> Array.filter (fun ind -> s.[ind..(ind + 2)] = "ABC") |> Array.length
|> stdout.WriteLine
