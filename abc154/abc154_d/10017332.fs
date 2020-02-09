// detail: https://atcoder.jp/contests/abc154/submissions/10017332
let nk = stdin.ReadLine().Split() |> Array.map int
let (n, k) = (nk.[0], nk.[1])
let p = stdin.ReadLine().Split() |> Array.map int
let accum = p |> Array.fold (fun list elem -> (list |> List.head |> (+) elem)::list) [0] |> List.rev |> Array.ofList
let maxSum = [|k..n|] |> Array.map (fun x -> accum.[x] - accum.[x - k]) |> Array.max
((maxSum + k) |> double) / 2.0 |> stdout.WriteLine
