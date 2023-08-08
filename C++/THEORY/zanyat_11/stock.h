class Stock { // ������ ����������� ������
 private:  // �������� � �������� ��������
  std::string company; // �������� ��������
  long shares;          // ���������� �����
  double share_val;    // ���� ����� �����
  double total_val;    // ��������� ���� �����
  void set_tot() { total_val = shares * share_val; } 
 public:  // �������� � �������� �������� 
  // void acquire(const std::string & co, long  n, double pr);
 
  Stock();  // ����������� ��� ���������� 

  // ����������� � �����������, ���� �������� �� ���������
  Stock(const std::string &co, long n=0, double pr=0.0); 
  
  ~Stock(); // ����������
 
  void buy(long num, double price);  // ����� ��������� ������� �����
  void sell(long num, double price); // ������� ����� 
  void update(double price);         // �������� ����
  void show() const;                 // ������� ���������� �� �����

  void get_status(std::string &s, int *shrs, double *sval, 
		  double *tval) const; // �������� ������� ������

  const Stock &topval(const Stock &s) const; 
  // ���������� ���� ���� ������� ����� 
}; 
void show_all_stocks(const Stock *stocks, int N); // �� ������� ������
