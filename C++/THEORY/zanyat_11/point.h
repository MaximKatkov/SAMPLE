class Point{ 
 private:
  std::string label; // имя (метка) точки 
  double x;          // координата        
  double y;          // координата
 public: 
  Point (std::string s, double a = 0, double b = 0) ; 
  // создает объект с меткой s и значениями координат a, b 
  
  void showpoint() const; 
  // отображает метку и текущие значения координат
 
  void movepoint(double x1, double y1); 
  // добавляет к координатам вызывающего объекта величины х1, у1 
  
  double dist(const Point & p1) const;
  // Возвращает расстояние от вызывающего объекта до p1

  Point add(std::string s, const Point & p1) const; 
  // Складывает х из p1 и х вызывающего объекта,
  // складывает y из p1 и y вызывающего объекта,
  // создает новый объект класса Point с полученными
  // значениями x, y и меткой s и возвращает его

  void reset (double a = 0, double b = 0) ; 
  // устанавливает х, у равными a, b 

  Point middle(std::string s, const Point & p1) const; 
  // Возвращает новую точку с именем s и координатами
  // посередине между вызываемой точкой и p1.
}; 
