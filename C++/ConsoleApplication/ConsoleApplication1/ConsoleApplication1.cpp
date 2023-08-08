#include <iostream>
using namespace std;



int main()
{
	int array[20];
	int n,s1=1,s2=0;
	cin >> n;
	for (int i = 0; i < n; i++) {
		cin >> array[i];
	}


	for (int i = 0; i < n; i++) {

		if (array[i] <= array[i + 1])
			s1++;
		if (array[i] >= array[i + 1])
			s2++;
	}
	if (s1 == n)
		cout << "Yes";
	else if( s2==n )
		cout << "Yes";
	else
		cout << "No";
	

	
}

	







