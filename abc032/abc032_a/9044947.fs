// detail: https://atcoder.jp/contests/abc032/submissions/9044947
[<EntryPoint>]
let main argv =
    let rint () = stdin.ReadLine() |> int
    let a = rint ()
    let b = rint ()
    let rec solve n = if n % a = 0 && n % b = 0 then n else solve (n + 1)
    rint () |> solve
    |> stdout.WriteLine
    0
