// detail: https://atcoder.jp/contests/abc143/submissions/9937294
stdin.ReadLine() |> ignore
let d = stdin.ReadLine().Split() |> Array.map int
((d |> Array.collect (fun x -> d |> Array.map (fun y -> x * y)) |> Array.sum) - (d |> Array.sumBy (fun x -> x * x))) / 2
|> stdout.WriteLine
