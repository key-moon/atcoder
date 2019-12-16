// detail: https://atcoder.jp/contests/abc090/submissions/8974894
[<EntryPoint>]
let main argv =
    [|0..2|] |> Array.map (fun x -> stdin.ReadLine().[x..x]) |> String.concat "" |> stdout.WriteLine
    0
