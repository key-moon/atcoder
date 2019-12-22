// detail: https://atcoder.jp/contests/abc049/submissions/9046794
[<EntryPoint>]
let main argv =
    match stdin.ReadLine() with
        | "a" | "i" | "u" | "e" | "o" -> "vowel"
        | _ -> "consonant"
    |> stdout.WriteLine
    0
