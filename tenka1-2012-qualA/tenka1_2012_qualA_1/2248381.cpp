// detail: https://atcoder.jp/contests/tenka1-2012-qualA/submissions/2248381
#include<iostream>
using namespace std;
int a[100]={1,1};
int main() {
    int n;
    cin>>n;
    for(int i=2;i<=n;i++)a[i]=a[i-1]+a[i-2];
    cout<<a[n]<<endl;
    return 0;
}
