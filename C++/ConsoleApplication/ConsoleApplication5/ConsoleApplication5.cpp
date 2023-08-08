#include <iostream>

#include <ctime>
#include <windows.h>
#include <process.h>

using namespace std;

//Колличество подключаемых потоков
const int NumberOfThreads =32
;
//размер матриц
const int n = 1024;
const int m = 1024;
const int k = 1024;

int** matr_1 = new int* [n];//первая множитель-матрица(1)
int** matr_2 = new int* [m];//второй множитель-матрица(2)
int** matr_3 = new int* [n];// матрица ответа(3)

int q = n / NumberOfThreads,
r = n % NumberOfThreads;

int from[NumberOfThreads] = { 0 }, to[NumberOfThreads] = { 0 };

unsigned __stdcall ThreadFunctionMult(void* param)
{
    // функция заполняет матрицу matr_3 переумножая определенные ячейки массивов matr_1,matr_1 и складывая их
    int iNum = *(reinterpret_cast<int*>(param));
    for (int i = from[iNum]; i < to[iNum]; i++)
    {
        for (int j = 0; j < k; j++)
        {
            matr_3[i][j] = 0;
            for (int z = 0; z < m; z++)

                matr_3[i][j] += matr_1[i][z] * matr_1[z][j];
        }
    }
    return 0;
}

int main()
{
 
        setlocale(LC_ALL, "rus");

        cout << "<<< Умножение матриц квадратного типа >>>" << endl << "<<< Количество подключаемых потоков и размер матрицы инициализируются в коде >>>" << endl;

        for (int i = 0; i < n; i++)
            //открываем пространство и выделяем память для ячеек массивов
            matr_1[i] = new int[m];

        for (int i = 0; i < m; i++)
            matr_2[i] = new int[k];

        for (int i = 0; i < n; i++)
            matr_3[i] = new int[k];

        srand(time(0));
        // заполняем массивы matr_1 и matr_2 рандомными значениями
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matr_1[i][j] = rand() % 3;

                // cout << matr_1[i][j] << " ";
            }
            //cout << endl;
        }

        //cout << endl;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                matr_2[i][j] = rand() % 3;
                //cout << matr_2[i][j] << " ";
            }
            // cout << endl;
        }

        //cout << endl;

        clock_t start, end;
        //начало таймера вычесления 
        start = clock();

        HANDLE hThreads[NumberOfThreads];
        unsigned id;
        int noms[NumberOfThreads];
        for (int i = 0; i < NumberOfThreads; i++) {
            to[i] = from[i] + q + (i < r ? 1 : 0);
            noms[i] = i;
            hThreads[i] = (HANDLE)_beginthreadex(NULL, 0, ThreadFunctionMult, (void*)(noms + i), 0, &id);
            if (i < NumberOfThreads - 1)
                from[i + 1] = to[i];
        }
        WaitForMultipleObjects(NumberOfThreads, hThreads, TRUE, INFINITE);
        for (int i = 0; i < NumberOfThreads; i++)
            CloseHandle(hThreads[i]);

        end = clock() - start;
        //конец таймера вычисления

        cout << "Время вычисления программы : " << end / (double)CLOCKS_PER_SEC<<endl;

        for (int i = 0; i < n; i++)
            delete[] matr_1[i];

        for (int i = 0; i < m; i++)
            delete[] matr_2[i];

        for (int i = 0; i < n; i++)
            delete[] matr_3[i];
        delete[] matr_1;
        delete[] matr_2;
        delete[] matr_3;

        return 0;
}
