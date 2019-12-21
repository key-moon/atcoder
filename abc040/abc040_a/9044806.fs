// detail: https://atcoder.jp/contests/abc040/submissions/9044806
[<EntryPoint>]
let main argv =
    let nx = stdin.ReadLine().Split() |> Array.map int
    let n = nx.[0]
    let x = nx.[1]
    min (n - x) (x - 1)
    |> stdout.WriteLine
    0
