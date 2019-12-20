// detail: https://atcoder.jp/contests/abc015/submissions/9029809
[<EntryPoint>]
let main argv =
    [|stdin.ReadLine(); stdin.ReadLine()|] |> Array.maxBy (fun s -> s |> String.length) |> stdout.WriteLine
    0
