// detail: https://atcoder.jp/contests/abc060/submissions/9051894
[<EntryPoint>]
let main argv =
    let s = stdin.ReadLine().Split()
    let isValid a b = (Seq.last a) = (Seq.head b)
    if isValid s.[0] s.[1] && isValid s.[1] s.[2] then "YES" else "NO"
    |> stdout.WriteLine
    0
