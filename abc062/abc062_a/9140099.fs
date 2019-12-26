// detail: https://atcoder.jp/contests/abc062/submissions/9140099
[<EntryPoint>]
let main argv =
    let groups = [|[|1;3;5;7;8;10;12|];[|4;6;9;11|];[|2|]|]
    let getGroup n = groups |> Array.findIndex (Array.contains n)
    if (stdin.ReadLine().Split() 
    |> Array.map int 
    |> Array.map getGroup 
    |> Array.distinct 
    |> Array.length
    |> (=) 1) then "Yes" else "No"
    |> stdout.WriteLine
    0
