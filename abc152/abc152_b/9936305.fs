// detail: https://atcoder.jp/contests/abc152/submissions/9936305
let ab = stdin.ReadLine().Split() |> Array.map int
let f a b = a |> string |> Array.replicate b |> String.concat ""
[| f ab.[0] ab.[1] ; f ab.[1] ab.[0]|] |> Array.min |> stdout.WriteLine
