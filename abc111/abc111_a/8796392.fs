// detail: https://atcoder.jp/contests/abc111/submissions/8796392
open System


[<EntryPoint>]
let main argv =
    Console.ReadLine().Replace('1', 'l').Replace('9', '1').Replace('l', '9')
    |> Console.WriteLine
    0
