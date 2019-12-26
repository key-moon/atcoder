// detail: https://atcoder.jp/contests/abc069/submissions/9139714
[<EntryPoint>]
let main argv =
    let nm = stdin.ReadLine().Split() |> Array.map int |> Array.map ((+) -1)
    nm.[0] * nm.[1]
    |> stdout.WriteLine
    0
