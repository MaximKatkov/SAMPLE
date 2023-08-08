#include <iostream> 
#include "stock.h" 

/*** Mетоды **************************************************/
void Stock::acquire(const std::string & co, long n, double pr){
  company = co; // внутри методов есть доступ кo всем (private
                // и public) элементам объекта, к которому 
                // применяется метод.
                // Здесь company - элемент объекта, к которому
                // применяется метод acquire()
  if (n < 0){// простая проверка
    std::cout << "Number of shares cannot be negative; "
	      << company << " shares set to 0.\n";
    shares = 0;
  }
  else
    shares = n;
  
  share_val = pr; 
  set_tot();   // есть прямой доступ к этому методу
}
/********************************************************************/
void Stock::buy(long num, double price) { 
  // buy shares and update current price per share
  if (num < 0){ // проверка
    std::cout << "Number of shares purchased cannot be negative. " 
	      << "Transaction is aborted.\n"; 
  } else { 
    shares += num; 
    share_val = price; 
    set_tot(); 
  } 
} 
/********************************************************************/
void Stock::sell (long num, double price) {  
  // sell shares and update current price per share

  // NEEDS TO BE WRITTEN

} 
/********************************************************************/
void Stock::update(double price){ // change the price
  share_val = price; 
  set_tot(); 
} 

/********************************************************************/
void Stock::show() const { 
  /*
   * Выводится информация о пакете акций. 
   * Применяется форматирование вывода для удобства чтения. 
   * 
   * const после аргументов метода означает, что метод не изменяет
   * состояние объекта, к которому он применяется
   */

  using std::cout; 
  using std::ios_base; 
  
  // Сохранение и изменение исходного формата вывода
  ios_base::fmtflags orig = cout.setf(ios_base::fixed, ios_base::floatfield); 
  std::streamsize prec = cout.precision(2); 
  
  cout << "Company: " << company  << ", " << "Shares: " << shares << ", ";
  cout << "Share Price: $" << share_val << ", ";
  cout << "Total Value: $" << total_val << '\n' ; 
  
  // Восстановление исходного формата 
  cout.setf(orig, ios_base::floatfield); 
  cout.precision(prec); 
} 
