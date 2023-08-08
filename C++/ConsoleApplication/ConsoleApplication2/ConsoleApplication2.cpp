#include <iostream>
#include <fstream>

using namespace std;

int main()
{
	ofstream fout;
	fout.open("2.dat");

	int N = 1000;
	double L = 1, m = 0.2, t, v0 = 100, ax, x = 0,y=0, dt, tmax = 500, angle = 45,g=9.8;
	dt = tmax / N;
	for (int i = 0; i < N; i++) {

		t = i * dt;
		fout << x << " " << y << endl;
		x = v0 * cos(angle) * dt;
		y = v0 * sin(angle) * dt - (g * dt * dt) / 2;

	}

}

