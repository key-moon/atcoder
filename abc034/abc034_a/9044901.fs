// detail: https://atcoder.jp/contests/abc034/submissions/9044901
[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split() |> Array.map double
    if ab.[0] < ab.[1] then "Better" else "Worse"
    |> stdout.WriteLine
    0
