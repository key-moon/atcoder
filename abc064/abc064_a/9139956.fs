// detail: https://atcoder.jp/contests/abc064/submissions/9139956
[<EntryPoint>]
let main argv =
    let num = (stdin.ReadLine().Split() |> String.concat "" |> int)
    if num % 4 = 0 then "YES" else "NO"
    |> stdout.WriteLine
    0
