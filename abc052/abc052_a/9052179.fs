// detail: https://atcoder.jp/contests/abc052/submissions/9052179
[<EntryPoint>]
let main argv =
    let abcd = stdin.ReadLine().Split() |> Array.map int
    max (abcd.[0] * abcd.[1]) (abcd.[2] * abcd.[3])
    |> stdout.WriteLine
    0
