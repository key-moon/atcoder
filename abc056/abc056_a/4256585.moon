// detail: https://atcoder.jp/contests/abc056/submissions/4256585
rsint = -> [tonumber s for s in string.gmatch io.read!,"%d+"]
i = io.read!
if string.sub(i,1,1) == string.sub(i,3,3)
   print "H"
else
   print "D"
