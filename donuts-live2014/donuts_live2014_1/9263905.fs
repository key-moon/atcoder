// detail: https://atcoder.jp/contests/donuts-live2014/submissions/9263905
[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    if n % 2 = 1 then 
        "error" 
    else
        (stdin.ReadLine().Split()
        |> Array.map int 
        |> Array.chunkBySize 2 
        |> Array.fold (fun x y -> x + y.[1] - y.[0]) 0).ToString()
    |> stdout.WriteLine
    0
