// detail: https://atcoder.jp/contests/abc018/submissions/9032425
[<EntryPoint>]
let main argv =
    let input = [|1..3|] |> Array.map (fun _ -> stdin.ReadLine() |> int)
    let sorted = input |> Array.sortDescending
    input
    |> Array.map (fun x -> sorted |> Array.findIndex (fun y -> y = x) |> (+) 1 |> string)
    |> String.concat "
"
    |> stdout.WriteLine
    0
