// detail: https://atcoder.jp/contests/abc146/submissions/8779379
open System


[<EntryPoint>]
let main argv =
    let daylist = [|"SUN"; "MON"; "TUE"; "WED"; "THU"; "FRI"; "SAT"|]
    let day = stdin.ReadLine()

    stdout.WriteLine(7 - Array.findIndex (fun x -> x.Equals(day)) daylist)
    0
