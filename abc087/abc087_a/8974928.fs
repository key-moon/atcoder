// detail: https://atcoder.jp/contests/abc087/submissions/8974928
[<EntryPoint>]
let main argv =
    let rint () = stdin.ReadLine() |> int
    (rint () - rint ()) % rint () |> stdout.WriteLine
    0
