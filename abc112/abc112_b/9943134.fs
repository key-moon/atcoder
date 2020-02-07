// detail: https://atcoder.jp/contests/abc112/submissions/9943134
let nt = stdin.ReadLine().Split() |> Array.map int
let (n, T) = (nt.[0], nt.[1])
let cands =
    [|1..n|] |> Array.map (
        fun _ -> 
            let ct = stdin.ReadLine().Split() |> Array.map int
            let (c, t) = (ct.[0], ct.[1])
            (c, t)
    )
    |> Array.filter (fun (_, t) -> t <= T)


if cands.Length = 0 then "TLE" else cands |> Array.minBy fst |> fst |> string
|> stdout.WriteLine
