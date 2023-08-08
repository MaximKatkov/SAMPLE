#include <iostream>

int main()
{
	char array[] = { '2','0','1','6' };
	int N = std::size(array);
	std::cout << N << std::endl;

	for (int i = 0, j = N - 1; i < j; i++, j--) {
		char t = array[i];
		array[i] = array[j];
		array[j] = t;
	}
	for (int i = 0; i < N; i++)
		std::cout << array[i]<<" ";
}
