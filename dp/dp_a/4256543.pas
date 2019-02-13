// detail: https://atcoder.jp/contests/dp/submissions/4256543
var
	llc,lltc,lc,ltc,tc,c,n,i:longint;
			
begin
	readln(n);
	read(llc);
	read(lc);
    lltc := 0;
	ltc := abs(llc - lc);
	for i := 3 to n do
	begin
		read(c);
        tc := lltc + abs(c - llc);
		if ltc + abs(c - lc) < tc then
        	tc := ltc + abs(c - lc);
		lltc := ltc;
		llc := lc;
		ltc := tc;
		lc := c;
	end;
	writeln(ltc);
end.
