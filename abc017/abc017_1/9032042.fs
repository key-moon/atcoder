// detail: https://atcoder.jp/contests/abc017/submissions/9032042
[<EntryPoint>]
let main argv =
    [|1..3|] |> Array.map (fun _ -> 
        let a = stdin.ReadLine().Split() |> Array.map int
        a.[0] * a.[1] / 10
    ) |> Array.sum
    |> stdout.WriteLine
    0
