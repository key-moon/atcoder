// detail: https://atcoder.jp/contests/donuts-live2014/submissions/9263321
program aaa;
var
	n,s,e,i,res:longint;
begin
	Readln(n);
    if n mod 2 = 1 then
        Writeln('error')
    else
    begin
        res := 0;
        for i:=1 to n do
        begin
            read(s);
            read(e);
            res := res + (e - s);
        end;
        Writeln(res)
    end;
end.         
