// detail: https://atcoder.jp/contests/abc141/submissions/8783986
open System
let curry f a b = f (a, b)

[<EntryPoint>]
let main argv =
    let weathers = [|"Sunny";"Cloudy";"Rainy";"Sunny"|]
    let s = Console.ReadLine()
    weathers.[(weathers |> Array.findIndex (fun x -> x = s)) + 1] |> Console.WriteLine
    0
