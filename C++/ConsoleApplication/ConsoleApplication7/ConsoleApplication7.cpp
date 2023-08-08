#include <iostream>
#include <cstring>
#include <math.h>
#include <time.h>
#include <fstream>
#include <omp.h>
using namespace std;

class CMatrix //класс множетва строк в виде вектора(т.е массив бесконечной длинны, так как если память закичивается мы перевыдеяем память)
{
private:
	double** arr;
	int N;//размер матрицы
public:
	CMatrix(int N)  //конструктор если есть парметр размера матрицы
	{
		this->N = N;
		arr = new double* [N];
		for (int i = 0; i < N; ++i)
			arr[i] = new double[N];

		for (int i = 0; i < N; ++i)
			for (int j = 0; j < N; ++j)
				arr[i][j] = 0;
	}
	CMatrix() { SetZero(); }//конструктор по умолчанию
	~CMatrix() { Clean(); }    //деструктор
	void SetZero() { arr = nullptr;  N = 0; }  //зануление класса
	void Clean() { for (int i = 0; i < N; i++) delete[] arr[i]; delete[] arr; SetZero(); }  //чистка памяти
	void CopyOnly(CMatrix& other); //функция копирования
	void random_filling();//рандомное заполение файла
	CMatrix(CMatrix& other) { CopyOnly(other); }  //опрератор копирования  
	CMatrix& operator=(CMatrix& b) { if (this != &b) { Clean(); CopyOnly(b); } return *this; }  //оператор присваивания
	void multiplication(CMatrix& a, CMatrix& b);//простое умножение матриц
	void MultiplyWithOMP(CMatrix& a, CMatrix& b, int threadsNum);// умножение матриц с помощью OMP
	friend ostream& operator<<(ostream& cout, const CMatrix& other); //опрератор вывода
};
void CMatrix::CopyOnly(CMatrix& other)//функция копирования
{
	N = other.N;
	arr = new double* [N];
	for (int i = 0; i < N; ++i)
		arr[i] = new double[N];

	for (int i = 0; i < N; ++i)
		for (int j = 0; j < N; ++j)
			arr[i][j] = other.arr[i][j];
}
void CMatrix::random_filling()
{
	double  min = -100.01, max = 100.01; int precision = 4;
	double value;
	for (int i = 0; i < N; ++i)
		for (int j = 0; j < N; ++j)
		{
			value = rand() % (int)pow(10, precision);
			value = min + (value / pow(10, precision)) * (max - min);// получить вещественное число
			arr[i][j] = value;
		}

}
void CMatrix::multiplication(CMatrix& a, CMatrix& b)
{
	int i, j, k;
	for (i = 0; i < N; ++i)
	{
		for (j = 0; j < N; ++j)
		{
			for (k = 0; k < N; ++k)
				arr[i][j] += a.arr[i][k] * b.arr[k][j];
		}
	}
}

void CMatrix::MultiplyWithOMP(CMatrix& a, CMatrix& b, int threadsNum)
{
	//Устанавливаем число потоков
	omp_set_num_threads(threadsNum);
	int i, j, k;
#pragma omp parallel for shared(a.arr, b.arr, arr) private(i, j, k)
	for (i = 0; i < N; i++)
	{
		for (j = 0; j < N; j++)
		{
			for (k = 0; k < N; k++)
			{
				arr[i][j] += (a.arr[i][k] * b.arr[k][j]);
			}
		}
	}
}
ostream& operator<<(ostream& cout, const CMatrix& other)
{
	for (int i = 0; i < other.N; ++i)
	{
		for (int j = 0; j < other.N; ++j)
			cout << other.arr[i][j] << " ";
		cout << "\n";
	}

	return cout;
}
int main(void)
{
	while (true) {
		setlocale(LC_ALL, "rus");
		int N;
		int flow;
		cout << "Введите размер квадратной матрицы (для завершения вычислений введите размер равный нулю) : ";
		cin >> N;
		if (N == 0)
			break;
		cout << "Введите колличество подключаемых потоков : ";
		cin >> flow;
		CMatrix A(N), B(N), R(N), R1(N);
		A.random_filling();
		B.random_filling();
		//	cout << A << endl;
		//	cout << B << endl;
		clock_t start = clock();
		R.multiplication(A, B);
		clock_t konec = clock();
		//cout << R << endl;
		double seconds = (double)(konec - start) / CLOCKS_PER_SEC;
		cout << "Время вычесления простого умножения матриц : " << seconds << " секунды\n";
		clock_t start1 = clock();
		R1.MultiplyWithOMP(A, B, flow);
		clock_t konec1 = clock();
		//cout << R1 << endl;
		seconds = (double)(konec1 - start1) / CLOCKS_PER_SEC;
		cout << "Время вычисления умножения матриц с помощью OMP: " << seconds << " секунды\n";
		
		
	}
}