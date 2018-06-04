// detail: https://atcoder.jp/contests/abc086/submissions/2616375
Module Module1
  Sub Main()
    Dim a As Integer() = ReadInts()
    If (a(0) * a(1)) Mod 2 = 0 Then
            Console.WriteLine("Even")
        Else
            Console.WriteLine("Odd")
    End If
  End Sub
  Function ReadInts()As Integer()
    Dim a As String() = Console.ReadLine().Split()
    Dim res(a.Length) As Integer
    For index As Integer = 0 To a.Length - 1
      res(index) = CInt(a(index))
    Next
    Return res
  End Function
End Module
