#include <iostream> 
#include "stock.h" 

/*** M����� **************************************************/
void Stock::acquire(const std::string & co, long n, double pr){
  company = co; // ������ ������� ���� ������ �o ���� (private
                // � public) ��������� �������, � �������� 
                // ����������� �����.
                // ����� company - ������� �������, � ��������
                // ����������� ����� acquire()
  if (n < 0){// ������� ��������
    std::cout << "Number of shares cannot be negative; "
	      << company << " shares set to 0.\n";
    shares = 0;
  }
  else
    shares = n;
  
  share_val = pr; 
  set_tot();   // ���� ������ ������ � ����� ������
}
/********************************************************************/
void Stock::buy(long num, double price) { 
  // buy shares and update current price per share
  if (num < 0){ // ��������
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
   * ��������� ���������� � ������ �����. 
   * ����������� �������������� ������ ��� �������� ������. 
   * 
   * const ����� ���������� ������ ��������, ��� ����� �� ��������
   * ��������� �������, � �������� �� �����������
   */

  using std::cout; 
  using std::ios_base; 
  
  // ���������� � ��������� ��������� ������� ������
  ios_base::fmtflags orig = cout.setf(ios_base::fixed, ios_base::floatfield); 
  std::streamsize prec = cout.precision(2); 
  
  cout << "Company: " << company  << ", " << "Shares: " << shares << ", ";
  cout << "Share Price: $" << share_val << ", ";
  cout << "Total Value: $" << total_val << '\n' ; 
  
  // �������������� ��������� ������� 
  cout.setf(orig, ios_base::floatfield); 
  cout.precision(prec); 
} 
