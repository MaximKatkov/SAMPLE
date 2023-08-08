#include <iostream> 
#include "stock.h" 

/*** ������������ � ����������� *************************************/
Stock::Stock(){ // ����������� ��� ���������� 
  company = "no name"; 
  shares = 0; 
  share_val = 0.0; 
  total_val = 0.0; 
  
  // ����� ����� ������������ ����� � ���������� this
  this->total_val = 0.0; // ������������ total_val = 0.0; 

  // ����������� ����� �������, ������� ����������������
  std::cout << "Constructor is applied to object at " << this << std::endl;  
} 

Stock::Stock(const std::string &co, long n, double pr){ 
  //����������� � �����������
  company=co;
  if (n < 0) { 
    std::cout << "Number of shares can't be negative; " 
	      << company << " shares set to 0.\n"; 
    shares = 0; 
  } 
  else 
    shares = n; 
  
  share_val = pr; 
  set_tot() ; 
} 

Stock::~Stock(){ // ����������, ��������� ���������
  std::cout << "Bye, " << company << "!\n";
} 

/*** ������ ������ **************************************************/
void Stock::buy(long num, double price) { 
  // buy shares and update current price per share
  if (num < 0){ 
    std::cout << "Number of shares purchased can't be negative. " 
	      <<"Transaction is aborted.\n"; 
  } else { 
    shares += num; 
    share_val = price; 
    set_tot(); 
  } 
} 
/********************************************************************/
void Stock::sell(long num, double price) {  
  // cell shares and update current price per share
  
  // NOT USED HERE
} 
/********************************************************************/
void Stock::update(double price){ // change the price
  share_val = price; 
  set_tot(); 
} 
/********************************************************************/
void Stock::get_status(std::string &com, int *s, double *sv, 
		       double *tv) const{
  //get information about the stock
 com=company;  *s=shares; *sv=share_val;  *tv=total_val;
}
/********************************************************************/
const Stock & Stock::topval(const Stock & s) const { 
  /*
   * ���������� ���� ������ ����� (������ ������ Stock), � �������� 
   * ����������� ������ �����, � ������ �����, ������� ���������� 
   * � ���������.  ���������� ������ �� ����� ����� � ������� �����.
   */

  if (s.total_val > total_val) 
    return s;      // � ��������� ���� ������, ���������� ������ s
  else 
    return *this;  // this ��������� �� ������, � �������� �����������
                   // �����. ���������� ������ �� ������, �������� * 
  // ����� � ������
  // return (s.total_val > total_val) ? s : *this;
}
/********************************************************************/
void Stock::show() const { 
  /*
   * ��������� ���������� � ������ �����. 
   * ����������� �������������� ������ ��� �������� ������. 
   * 
   * const ����� ���������� ��������, ��� ����� �� ��������
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

/********************************************************************/
void show_all_stocks(const Stock *stocks, int N){ // �� ������� ������
  /*
   * ���������� ���� ��� ������ �� ����� ���������� � ���� ������� 
   * ����� �� �������. ���������� ������������� ��� �������� ������.
   */

  using namespace std;
  cout <<"Stock holdings:\n";  
  string s;
  int shares; 
  double share_val, total_val;

  printf("    %15s %11s %12s %11s\n", "Company", "Shares ", "$/share", "Total $$"); 
  for (int n = 0; n < N; n++){
    stocks[n].get_status(s, &shares, &share_val, &total_val); 
    printf("%3d %15s %10d %13.2f %11.2f\n", n+1, s.c_str(), shares, share_val, total_val); 
  }
}
