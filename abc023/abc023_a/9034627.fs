// detail: https://atcoder.jp/contests/abc023/submissions/9034627
[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> Seq.sumBy (fun x -> (int x) - 48) |> stdout.WriteLine
    0
