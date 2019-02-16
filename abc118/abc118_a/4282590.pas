// detail: https://atcoder.jp/contests/abc118/submissions/4282590
var
	n,k:longint;
begin
	Readln(n,k);
	if (k mod n) = 0 then
		Writeln(n+k)
	else
		Writeln(k-n);
end.         
