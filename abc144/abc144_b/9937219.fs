// detail: https://atcoder.jp/contests/abc144/submissions/9937219
if
    [|1..9|] |> Array.collect (fun x -> [|1..9|] |> Array.map (fun y -> x * y))
    |> Array.contains (stdin.ReadLine() |> int)
then "Yes" else "No" 
|> stdout.WriteLine
