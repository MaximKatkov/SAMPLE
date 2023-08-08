#include<iostream> 
#include<string> 
#include<cstdio>

#include"stock.h" 

const int STKS = 4; // количество объектов в массиве

/********************************************************************/
void run_stock(void){ // пример работы с объектами
  
  using namespace std;

  /*** Создание объектa класса  ***/
  Stock s1;         // неявный вызов конструктора без аргументов
  Stock s2=Stock(); //   явный вызов конструктора без аргументов

  // распечатаем адреса объектов s1 и s2
  cout << "Object s1 is at " << &s1 << endl;  
  cout << "Object s2 is at " << &s2 << endl;  

  s1.show();        // вывести значения на экран, используя метод show
  s2.show(); 

  Stock s3("IBM", 4, 160.00);            // конструктор с аргументами
  //Stock s3=Stock("IBM", 4, 160.00);    // так тоже можно
  s3.show();         
  s3.buy(1, 150.0);  // купить акций, применив метод buy   
  s3.show(); 

  Stock s4("Boeing"); // конструктор с аргументами, используются значения по умолчанию
  s4.show(); 

  /*** Создание массива объектов  ***/
  Stock mystocks[STKS]={Stock("Apple",   10, 135.72),
			Stock("Sysco",   10,  52.35), 
			Stock("Intel",  100,  36.48),
			Stock("Alphabet", 5, 846.55)};
  // Можно также
  //stocks[0]=Stock("Apple",   10, 135.72);// 10 shares for 135.72 each
  //stocks[1]=Stock("Sysco",   10,  52.35);  
  //stocks[2]=Stock("Intel",  100,  36.48); 
  //stocks[3]=Stock("Alphabet", 5, 846.55);
 
  /*** Вывести на экран информация о массив объектов ***/
  show_all_stocks(mystocks, STKS); // начальное состояние

  /*** Операции с пакетами акций из массива ***/
  mystocks[0].buy(11, 150.0);// применяем метод buy к 0-му элементу  
  mystocks[2].update(35.45); // применяем метод update кo 2-му элементу  
  show_all_stocks(mystocks, STKS); // новое состояние

  /*
   * Часть кода для нахождения пакета с наибольшей ценой.  
   * Вводим *top, который буден показывать на него, и в цикле 
   * сравниваем цены пакетов попарно.
   */
  const Stock *top = &mystocks[0]; //установка указателя на 0-ой элем.
  for (int st = 1; st < STKS; st++)// сравниваем цены пакетов в цикле
    top = &top->topval(mystocks[st]); 

  // Теперь top указывает на самый ценный пакет акций 
  std::cout << "\nMost valuable holding:\n"; 
  top->show();
}
/********************************************************************/
int main() { 
    run_stock();
    return 0; 
}
