// detail: https://atcoder.jp/contests/fuka5/submissions/4256320
program aaa;
var
	n,k,i,ans:longint;
	a:array[1..1000]of longint;

	procedure qsort(l,r:longint);
  var i,j,k,t:longint;
  begin
    i:=l; j:=r; k:=a[(i+j)shr 1];
    repeat
      while a[i]<k do inc(i);
      while a[j]>k do dec(j);
      if i<=j then
              begin
                t:=a[i]; a[i]:=a[j]; a[j]:=t;
                inc(i); dec(j);
              end;
    until i>j;
    if i<r then qsort(i,r);
    if j>l then qsort(l,j);
  end;
begin
	Readln(n,k);
	for i:=1 to n do
		read(a[i]);
	While n<>0 Do
	begin
		qsort(1,n);
		ans:=0;
		for i:=1 to k do
		begin
			ans:=ans+a[i];
		end;
        Writeln(ans);
        Readln(n,k);
        for i:=1 to n do
        	read(a[i]);
	end;
end.         
