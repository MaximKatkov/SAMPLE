class Point{ 
 private:
  std::string label; // ��� (�����) ����� 
  double x;          // ����������        
  double y;          // ����������
 public: 
  Point (std::string s, double a = 0, double b = 0) ; 
  // ������� ������ � ������ s � ���������� ��������� a, b 
  
  void showpoint() const; 
  // ���������� ����� � ������� �������� ���������
 
  void movepoint(double x1, double y1); 
  // ��������� � ����������� ����������� ������� �������� �1, �1 
  
  double dist(const Point & p1) const;
  // ���������� ���������� �� ����������� ������� �� p1

  Point add(std::string s, const Point & p1) const; 
  // ���������� � �� p1 � � ����������� �������,
  // ���������� y �� p1 � y ����������� �������,
  // ������� ����� ������ ������ Point � �����������
  // ���������� x, y � ������ s � ���������� ���

  void reset (double a = 0, double b = 0) ; 
  // ������������� �, � ������� a, b 

  Point middle(std::string s, const Point & p1) const; 
  // ���������� ����� ����� � ������ s � ������������
  // ���������� ����� ���������� ������ � p1.
}; 
