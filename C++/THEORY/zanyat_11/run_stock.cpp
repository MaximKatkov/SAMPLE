#include<iostream> 
#include<string> 
#include<cstdio>

#include"stock.h" 

const int STKS = 4; // ���������� �������� � �������

/********************************************************************/
void run_stock(void){ // ������ ������ � ���������
  
  using namespace std;

  /*** �������� ������a ������  ***/
  Stock s1;         // ������� ����� ������������ ��� ����������
  Stock s2=Stock(); //   ����� ����� ������������ ��� ����������

  // ����������� ������ �������� s1 � s2
  cout << "Object s1 is at " << &s1 << endl;  
  cout << "Object s2 is at " << &s2 << endl;  

  s1.show();        // ������� �������� �� �����, ��������� ����� show
  s2.show(); 

  Stock s3("IBM", 4, 160.00);            // ����������� � �����������
  //Stock s3=Stock("IBM", 4, 160.00);    // ��� ���� �����
  s3.show();         
  s3.buy(1, 150.0);  // ������ �����, �������� ����� buy   
  s3.show(); 

  Stock s4("Boeing"); // ����������� � �����������, ������������ �������� �� ���������
  s4.show(); 

  /*** �������� ������� ��������  ***/
  Stock mystocks[STKS]={Stock("Apple",   10, 135.72),
			Stock("Sysco",   10,  52.35), 
			Stock("Intel",  100,  36.48),
			Stock("Alphabet", 5, 846.55)};
  // ����� �����
  //stocks[0]=Stock("Apple",   10, 135.72);// 10 shares for 135.72 each
  //stocks[1]=Stock("Sysco",   10,  52.35);  
  //stocks[2]=Stock("Intel",  100,  36.48); 
  //stocks[3]=Stock("Alphabet", 5, 846.55);
 
  /*** ������� �� ����� ���������� � ������ �������� ***/
  show_all_stocks(mystocks, STKS); // ��������� ���������

  /*** �������� � �������� ����� �� ������� ***/
  mystocks[0].buy(11, 150.0);// ��������� ����� buy � 0-�� ��������  
  mystocks[2].update(35.45); // ��������� ����� update �o 2-�� ��������  
  show_all_stocks(mystocks, STKS); // ����� ���������

  /*
   * ����� ���� ��� ���������� ������ � ���������� �����.  
   * ������ *top, ������� ����� ���������� �� ����, � � ����� 
   * ���������� ���� ������� �������.
   */
  const Stock *top = &mystocks[0]; //��������� ��������� �� 0-�� ����.
  for (int st = 1; st < STKS; st++)// ���������� ���� ������� � �����
    top = &top->topval(mystocks[st]); 

  // ������ top ��������� �� ����� ������ ����� ����� 
  std::cout << "\nMost valuable holding:\n"; 
  top->show();
}
/********************************************************************/
int main() { 
    run_stock();
    return 0; 
}
