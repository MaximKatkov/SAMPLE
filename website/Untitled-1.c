#include <stdio.h>
#include <stdlib.h>
#define SIDE_SIZE (1025)

int nod (int a, int b)
{
    if (b == 0)
        return a;
    else
        return nod (b, a % b);
}
 
int main()
{
int n,k,z=0,x,d;
int ** a, **b,**c, i, j;
 
 
if ( ! ( a = malloc(sizeof(int*) * SIDE_SIZE) ) ) {
    perror("malloc");
    exit(1);
}
for ( i = 0; i < SIDE_SIZE; ++i ) {
    if ( ! ( a[i] = malloc(sizeof(int) * SIDE_SIZE) ) ) {
        perror("malloc");
        exit(1);
    }
}
if ( ! ( c = malloc(sizeof(int*) * SIDE_SIZE) ) ) {
    perror("malloc");
    exit(1);
}
for ( i = 0; i < SIDE_SIZE; ++i ) {
    if ( ! ( c[i] = malloc(sizeof(int) * SIDE_SIZE) ) ) {
        perror("malloc");
        exit(1);
    }
}
 
if ( ! ( b = malloc(sizeof(int*) * SIDE_SIZE) ) ) {
    perror("malloc");
    exit(1);
}
for ( i = 0; i < SIDE_SIZE; ++i ) {
    if ( ! ( b[i] = malloc(sizeof(int) * SIDE_SIZE) ) ) {
        perror("malloc");
        exit(1);
    }
}
 
 
scanf("%d %d",&n,&d);
 
for ( i = 1; i <= n; ++i )
 
 {
    for ( j = 1; j <= n; ++j )
    {
       a[i][j]=nod(i+1, j+1);
    b[i][j]=nod(n-i+1, n-j+1);
    }
 
 
}
 
i=1;
while (i<=n)
{  j=1;
while (j<=n)
  {c[i][j]=0;
    k=1;
     while (k<=n)
  {c[i][j]+=a[i][k]*b[j][k]; k++;    }
 
    if (c[i][j]%d==0) z++;
    j++;}
    i++;
}
 
 
printf("%d",z);
for ( i = 0; i <= n; ++i )
 
    free(a[i]);
 
free(a);
for ( i = 0; i <= n; ++i )
    free(b[i]);
 
free(b);
return 0;
 
for ( i = 0; i <= n; ++i )
    free(с[i]);
 
free(с);
return 0;
 
}