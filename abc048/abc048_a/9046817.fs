// detail: https://atcoder.jp/contests/abc048/submissions/9046817
[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split()
    |> Array.map (fun x -> x.[0..0])
    |> String.concat ""
    |> stdout.WriteLine
    0
