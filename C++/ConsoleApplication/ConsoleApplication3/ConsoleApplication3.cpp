#include <iostream>
#include<fstream>
#include<string>
#include "math.h"
using namespace std;
int main()
{
	ofstream fout;
	double x=0;
	
	fout.open("f1.txt");

	for (int i = 0; i < 300; i++) {

		fout << "-" << 0 << "," << i << " " << "-" << 0 << "," << "0" << i << endl;
		x++;
	}
	
	for (int i = 0; i < 300; i++) {
	    
		fout <<0<< ","<<i <<" " <<0<<"," <<"0" <<i<< endl;
		x++;
	}
}

