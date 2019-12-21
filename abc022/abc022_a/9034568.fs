// detail: https://atcoder.jp/contests/abc022/submissions/9034568
[<EntryPoint>]
let main argv =
    let nst = stdin.ReadLine().Split() |> Array.map int

    let isBest w = nst.[1] <= w && w <= nst.[2]

    let mutable weight = stdin.ReadLine() |> int
    let mutable count = if weight |> isBest then 1 else 0
    for _ in [2..nst.[0]] do
        weight <- weight + (stdin.ReadLine() |> int)
        count <- if weight |> isBest then count + 1 else count
    count |> stdout.WriteLine
    0
