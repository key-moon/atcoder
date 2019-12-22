// detail: https://atcoder.jp/contests/abc042/submissions/9046932
[<EntryPoint>]
let main argv =
    if 
        stdin.ReadLine().Split() 
        |> Array.sort 
        |> String.concat "" = "557"
    then 
        "YES"
    else
        "NO"
    |> stdout.WriteLine
    0
