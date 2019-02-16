// detail: https://atcoder.jp/contests/abc118/submissions/4282283
var
	n,m,i,j,p,q,res:longint;
	a:array[1..30]of longint;
begin
	Readln(n,m);
	res := 0;
	for i:=1 to n do
	begin
		Read(p);
		for j:=1 to p do
		begin
			Read(q);
			a[q] := a[q] + 1;
		end;
	end;
	for i:=1 to m do
		if a[i] = n then
			res := res + 1;
	Writeln(res);
end.         
