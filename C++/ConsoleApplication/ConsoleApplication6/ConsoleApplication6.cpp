#include <iostream>
#include <ctime>
#include <windows.h>
#include <process.h>

using namespace std;
int func() {
    cout << "<<Please,enter matrix size>>>" << endl;
    int k;
    cin >> k;
    return k-1;
}


const int n = func();
const int k = n;
const int m = n;

int** matr_1 = new int* [n];
int** matr_2 = new int* [m];
int** matr_3 = new int* [n];



unsigned __stdcall ThreadFunctionMult(void* param)
{
    
    for (int i = 0; i <k; i++)
    {
        for (int j = 0; j < k; j++)
        {
            matr_3[i][j] = 0;
            for (int z = 0; z < n; z++)
                matr_3[i][j] += matr_1[i][z] * matr_2[z][j];
        }
    }
    return 0;
}

int main()
{

    while(true){
       
    cout<< "<<<To exit the console, enter the number of cores equal to zero>>>" << endl;
    cout << "<<<Please, enter the number of connected cores to calculate>>>" << endl;
    int NumberOfThreads;
    cin >> NumberOfThreads;
    
    cout << "<<<Please,wait a few moment>>>" << endl;

     if (NumberOfThreads == 0)
         break;
    
    int q = n / NumberOfThreads, r = n % NumberOfThreads;

    int * from = new int[NumberOfThreads];
    int* to = new int[NumberOfThreads];

     from[NumberOfThreads-1] = { 0 }, to[NumberOfThreads-1] = { 0 };

    for (int i = 0; i < n; i++)
        matr_1[i] = new int[m];

    for (int i = 0; i < m; i++)
        matr_2[i] = new int[k];

    for (int i = 0; i < n; i++)
        matr_3[i] = new int[k];

    srand(time(0));

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            matr_1[i][j] = rand() % 3;
            //cout << matr_1[i][j] << " ";
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
        //cout << endl;
    }

    //cout << endl;
  

    setlocale(LC_ALL, "rus");
    clock_t start, end;
    start = clock();


    HANDLE* hThreads=new HANDLE[NumberOfThreads];
    unsigned id;
    int *noms=new int [NumberOfThreads];
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
    //printf("Program calculation time: % f\n", end / (double)CLOCKS_PER_SEC);
    cout << "Время вычисления программы: " << end / (double)CLOCKS_PER_SEC<<endl;

    for (int i = 0; i < n; i++)
        delete[] matr_1[i];

    for (int i = 0; i < m; i++)
        delete[] matr_2[i];

    for (int i = 0; i < n; i++)
        delete[] matr_3[i];
  
    delete[] hThreads;
    delete[]noms;
    delete[]from;
    delete[]to; 


  }
     system("pause");
}