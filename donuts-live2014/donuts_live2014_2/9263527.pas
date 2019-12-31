// detail: https://atcoder.jp/contests/donuts-live2014/submissions/9263527
program aaa;
var
	n,i,a,dig,res: Int64;
begin
	Readln(n);
    for i := n div 10 * 10 + 1 to n do
        if i mod 7 = 0 then
            res := res + 1;
    
    n := n div 10;
    a := 1;
    while n <> 0 do
    begin
        dig := n mod 10;
        res := res + dig * a;
        a := a * 7;
        n := n div 10
    end;
    Writeln(res);
end.
