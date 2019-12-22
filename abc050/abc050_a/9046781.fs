// detail: https://atcoder.jp/contests/abc050/submissions/9046781
[<EntryPoint>]
let main argv =
    let ab = stdin.ReadLine().Split()
    let a = int ab.[0]
    let b = int ab.[2]
    let func = match ab.[1] with
        | "+" -> (+)
        | "-" -> (-)
    func a b |> stdout.WriteLine
    0
