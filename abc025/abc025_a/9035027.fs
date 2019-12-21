// detail: https://atcoder.jp/contests/abc025/submissions/9035027
[<EntryPoint>]
let main argv =
    let s = stdin.ReadLine()
    s
    |> Seq.map (fun c1 -> s |> Seq.map (fun c2 -> (string c1) + (string c2)))
    |> Seq.concat
    |> Seq.sort
    |> Seq.item (stdin.ReadLine() |> int |> (+) -1)
    |> stdout.WriteLine
    0
