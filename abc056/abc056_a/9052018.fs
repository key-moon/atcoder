// detail: https://atcoder.jp/contests/abc056/submissions/9052018
[<EntryPoint>]
let main argv =
    if stdin.ReadLine().Split() |> Array.distinct |> Array.length |> (=) 1 then "H" else "D"
    |> stdout.WriteLine
    0
