class Stock { // даётся определение класса
 private:     // элементы (данные и функции) с закрытым доступом
  std::string company; // название компании
  long shares;          // количество акций
  double share_val;    // цена одной акции
  double total_val;    // полная цена пакета акций
  void set_tot() { total_val = shares * share_val; } // метод, расчет цены пакета
 public:  // элементы (данные и функции) с открытым доступом
  void acquire(const std::string & co, long n, double pr); // начальное приобретение
  void buy(long num, double price);  // метод реализует покупку акций
  void sell(long num, double price); // продажа акций 
  void update(double price);         // изменяет цену
  void show() const;                 // выводит информацию на экран
}; 
