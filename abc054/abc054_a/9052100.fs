// detail: https://atcoder.jp/contests/abc054/submissions/9052100
[<EntryPoint>]
let main argv =
    let s = stdin.ReadLine().Split() |> Array.map (fun x -> (x |> int |> (+) 11) % 13)
    if s.[0] > s.[1] then "Alice" else if s.[0] < s.[1] then "Bob" else "Draw"
    |> stdout.WriteLine
    0
