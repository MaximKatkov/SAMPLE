class Stock { // дается определение класса
 private:  // элементы с закрытым доступом
  std::string company; // название компании
  long shares;          // количество акций
  double share_val;    // цена одной акции
  double total_val;    // стоимость всех акций
  void set_tot() { total_val = shares * share_val; } 
 public:  // элементы с открытым доступом 
  // void acquire(const std::string & co, long  n, double pr);
 
  Stock();  // конструктор без аргументов 

  // конструктор с аргументами, есть значения по умолчанию
  Stock(const std::string &co, long n=0, double pr=0.0); 
  
  ~Stock(); // деструктор
 
  void buy(long num, double price);  // метод реализует покупку акций
  void sell(long num, double price); // продажа акций 
  void update(double price);         // изменяет цену
  void show() const;                 // выводит информацию на экран

  void get_status(std::string &s, int *shrs, double *sval, 
		  double *tval) const; // получает скрытые данные

  const Stock &topval(const Stock &s) const; 
  // сравнивает цену двух пакетов акций 
}; 
void show_all_stocks(const Stock *stocks, int N); // не элемент класса
