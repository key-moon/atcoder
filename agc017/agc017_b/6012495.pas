// detail: https://atcoder.jp/contests/agc017/submissions/6012495
var
	n,a,b,c,d,c1,c1m,c2,c2m,dif:longint;
begin
	Readln(n, a, b, c, d);
	dif := abs(b - a);
	c1 := ((dif + ((n + 1) mod 2) * c) div (c * 2)) * 2 - ((n + 1) mod 2);
	c2 := c1 + 2;
	c1m := ((n - 1) + c1) div 2;
	c2m := (n - 2) - c1m;
	if (((n - 1) * c <= dif) and (dif <= (n - 1) * d)) or 
		((c1 <= (n - 1)) and (dif <= c1 * c + c1m * (d - c))) or
		((c2 <= (n - 1)) and (c2 * c - c2m * (d - c) <= dif)) then
		Writeln('YES')
	else
		Writeln('NO');
end.
