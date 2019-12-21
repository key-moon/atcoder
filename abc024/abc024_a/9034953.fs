// detail: https://atcoder.jp/contests/abc024/submissions/9034953
[<EntryPoint>]
let main argv =
    let abck = stdin.ReadLine().Split() |> Array.map int
    let st = stdin.ReadLine().Split() |> Array.map int
    let discount = if (st |> Array.sum) < abck.[3] then 0 else abck.[2]
    abck
    |> Array.take 2
    |> Array.map2 (fun x y -> x * (y - discount)) st
    |> Array.sum
    |> stdout.WriteLine
    0
