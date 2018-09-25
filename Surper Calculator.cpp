#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string>
#include <vector>
#include <math.h>
#include <conio.h>
using namespace std;

typedef long long ll;

int **get_new_array(long long n, long long m) {
	int **temp = new int *[n];
	for (long long i = 0; i<n; i++)
		temp[i] = new int[m];
	return temp;
}

void clean_array(int **arr, long long a, long long b) {
	for (long long i = 0; i<a; i++)
		for (long long j = 0; j<b; j++)
			arr[i][j] = 0;
}

bool negative(vector <int> tmp) {
	for (int i = 0; i<tmp.size(); i++)
		if (tmp[i]<0)return true;
		else if (tmp[i]>0)return false;
		return false;
}

void RA_N(vector <int> *num) {
	int t = 0,tmp;
	for (int i = num->size() - 1; i >= 0; i--) {
		if ((*num)[i] + t >= 10) tmp = (*num)[i],(*num)[i] = ((*num)[i] + t) % 10,t = (tmp + t) / 10;
		else (*num)[i] = ((*num)[i] + t), t = 0;
	}
	if (t) num->insert(num->begin(), t);
}

void remove_zero(vector <int> *num) {
	while (!num->empty())
		if (!(*num)[0]) num->erase(num->begin());
		else break;
}

void fill_zero(string *a, string *b) {
	while (a->size() != b->size())
		if (a->size()>b->size()) *b = "0" + *b;
		else *a = "0" + *a;
}

void fill_zero(vector <int> *a,vector <int> *b) {
	while (a->size() != b->size())
		if (a->size()>b->size()) b->insert(b->begin(),0);
		else a->insert(a->begin(), 0);
}

void minus_to_array(int *flag, string *a, string *b) {
	if ((*a)[0] == '-')flag[0] = 1, a->erase(a->begin());
	if ((*b)[0] == '-')flag[1] = 1, b->erase(b->begin());
}

void NRA(vector <int> *num, vector <int> *N) {
	int t = 0;
	for (int i = N->size() - 1; i >= 0; i--) {
		num->insert(num->begin(), ((*N)[i] * (*N)[N->size() - 1] + t) % 10);
		t = ((*N)[i] * (*N)[N->size() - 1] + t) / 10;
	}
	if (t) num->insert(num->begin(), t);
}

void TRA(vector <int> *num, vector <int> *N,int times) {
	int t = 0;
	for (int i = N->size() - 1; i >= 0; i--) {
		num->insert(num->begin(), ((*N)[i] * times + t) % 10);
		t = ((*N)[i] * times + t) / 10;
	}
	if (t) num->insert(num->begin(), t);
}

void put_vt_into_str(string *str, vector <int> tmp) {
	for (int i = 0; i<tmp.size(); i++)
		str->push_back(tmp[i] + 48);
}

void vt_out(vector <int> num) {
	for (int i = 0; i<num.size(); i++)
		cout << num[i] << " ";
	cout << endl;
}

void RM(int mode, vector <int> *ctemp) {
	int t = 0;
	for (int i = ctemp->size() - 1; i >= 0; i--) {
		if (mode) {
			(*ctemp)[i] += t,t = 0;
			while((*ctemp)[i]>0) (*ctemp)[i] -= 10, t++;
		}
		else{
			(*ctemp)[i] -= t,t = 0;
			while((*ctemp)[i]<0) (*ctemp)[i] += 10, t++;
		}
	}
}

int main() {
	int l;
	while (1) {
		system("color B");
		system("title Surper Calculator");
		cout << "(a). matrix A(T)" << endl;
		cout << "(b). matrix A+B" << endl;
		cout << "(c). matrix A*B" << endl;
		cout << "(d). two fucking long integer plus & minus" << endl;
		cout << "(e). two fucking long integer times" << endl;
		cout << "(f). two fucking long integer divide by (ANS with quotient && remainder)" << endl;
		cout << "(g). two fucking long integer divide by (ANS with point)" << endl;
		cout << "(h). fucking long integer root (ANS with point)" << endl;
		cout << "(q). quit" << endl;
		fflush(stdin);
		l = getche();
		fflush(stdin);
		//system("color 7");
		system("cls");
		//========================================================
		system("color F");
		if (l == 'a') {
			system("title matrix A(T)");
			ll a, b, max;
			int **arr;
			cout << "輸入矩陣大小:\n";
			cin >> a >> b;

			max = a>b ? a : b;
			arr = get_new_array(max, max);

			clean_array(arr, max, max);

			cout << "輸入矩陣:\n";

			ll m = -99999999999;

			for (ll i = 0; i<a; i++)
				for (ll j = 0; j<b; j++) {
					cin >> arr[i][j];
					if (m < arr[i][j]) m = arr[i][j];
				}

			int n = 0;
			while (m != 0) m /= 10, n++;

			system("color E");
			for (ll i = 0; i<a; i++) {
				for (ll j = 0; j<b; j++)
					printf("%*d ", n, arr[j][i]);
				cout << "\n";
			}
			free(arr);
		}
		else if (l == 'b') {
			system("title matrix A+B");
			ll a, b;
			int **arr_A;
			int **arr_B;
			cout << "輸入矩陣大小:\n";
			cin >> a >> b;
			arr_A = get_new_array(a, b);
			arr_B = get_new_array(a, b);

			cout << "輸入矩陣A:\n";
			for (ll i = 0; i<a; i++)
				for (ll j = 0; j<b; j++)
					cin >> arr_A[i][j];

			cout << "輸入矩陣B:\n";
			for (ll i = 0; i<a; i++)
				for (ll j = 0; j<b; j++)
					cin >> arr_B[i][j];

			ll max = -99999999999;

			for (ll i = 0; i<a; i++)
				for (ll j = 0; j<b; j++)
					if (max < arr_A[i][j] + arr_B[i][j])
						max = arr_A[i][j] + arr_B[i][j];

			int n = 0;
			while (max != 0) max /= 10, n++;
			system("color E");
			for (ll i = 0; i<a; i++) {
				for (ll j = 0; j<b; j++)
					printf("%*d ", n, arr_A[i][j] + arr_B[i][j]);
				cout << "\n";
			}
			free(arr_A);
			free(arr_B);
		}
		else if (l == 'c') {
			system("title matrix A*B");
			ll a, b, c;
			int **arr_A;
			int **arr_B;
			int **arr_C;
			cout << "輸入兩個矩陣大小 輸入a,b,c(axb bxc):\n";
			cin >> a >> b >> c;
			arr_A = get_new_array(a, b);
			arr_B = get_new_array(b, c);
			arr_C = get_new_array(a, c);

			cout << "輸入矩陣A:\n";
			for (ll i = 0; i<a; i++)
				for (ll j = 0; j<b; j++)
					cin >> arr_A[i][j];

			cout << "輸入矩陣B:\n";
			for (ll i = 0; i<b; i++)
				for (ll j = 0; j<c; j++)
					cin >> arr_B[i][j];

			clean_array(arr_C, a, c);

			ll max = -99999999999;

			for (ll j = 0; j<a; j++)
				for (ll i = 0; i<c; i++) {
					for (ll k = 0; k<b; k++)
						arr_C[j][i] += arr_A[j][k] * arr_B[k][i];
					if (max < arr_C[j][i]) max = arr_C[j][i];
				}

			int n = 0;
			while (max != 0) max /= 10, n++;
			system("color E");
			for (ll i = 0; i<a; i++) {
				for (ll j = 0; j<c; j++)
					printf("%*d ", n, arr_C[i][j]);
				cout << "\n";
			}
			free(arr_A);
			free(arr_B);
			free(arr_C);
		}
		else if (l == 'd') {
			system("title two fucking long integer plus, minus");
			string str_A, str_B, str_ANS;
			vector <int> temp;
			cout << "輸入兩數字相加或相減:";
			cin >> str_A >> str_B;

			char x;
			cout << "輸入加號或減號:";
			cin >> x;

			if (x == '-')
				if (str_B[0] == '-')
					str_B.erase(str_B.begin());
				else
					str_B = "-" + str_B;

			int fl[2] = { 0 };
			minus_to_array(fl, &str_A, &str_B);

			fill_zero(&str_A, &str_B);

			if (fl[0])str_A = "-" + str_A;
			if (fl[1])str_B = "-" + str_B;

			if (str_A[0] == '-'&&str_B[0] == '-') {

				for (int i = 1; i<str_A.size(); i++)
					temp.push_back((int)(str_A[i] - 48 + str_B[i] - 48));

				RA_N(&temp);

				str_ANS.push_back('-');

				put_vt_into_str(&str_ANS, temp);
			}
			else if (str_A[0] != '-'&&str_B[0] != '-') {

				for (int i = 0; i<str_A.size(); i++)
					temp.push_back((int)(str_A[i] - 48 + str_B[i] - 48));

				RA_N(&temp);

				put_vt_into_str(&str_ANS, temp);
			}
			else {
				bool flag = 1;

				if (str_A[0] == '-')str_A.erase(str_A.begin()), flag = 0;
				else str_B.erase(str_B.begin());

				for (int i = 0; i<str_A.size(); i++)
					temp.push_back((int)(str_A[i] - str_B[i]));

				RM(negative(temp), &temp);

				if (flag&&negative(temp))str_ANS.push_back('-');

				flag = 0;
				for (int i = 0; i<temp.size(); i++) {
					if (temp[i] != 0)flag = 1;
					if (flag)str_ANS.push_back(abs(temp[i]) + 48);
				}

			}
			system("color E");
			cout << str_ANS << endl;
		}
		else if (l == 'e') {
			system("title two fucking long integer times");
			string str_A, str_B, str_ANS;
			vector <int> temp;

			cout << "輸入兩數字相乘:";
			cin >> str_A >> str_B;

			int fl[2] = { 0 };
			minus_to_array(fl, &str_A, &str_B);

			if (fl[0] != fl[1]) str_ANS.push_back('-');

			for (int i = 0; i<str_B.size(); i++)
				for (int j = 0; j<str_A.size(); j++)
					if ((i + j) >= temp.size())
						temp.push_back((str_B[i] - 48)*(str_A[j] - 48));
					else
						temp[i + j] += (str_B[i] - 48)*(str_A[j] - 48);

			RA_N(&temp);

			put_vt_into_str(&str_ANS, temp);
			system("color E");
			cout << str_ANS << endl;
		}
		else if (l == 'f') {
			system("title two fucking long integer divide by (ANS with quotient,remainder)");
			string str_A, str_B;
			vector <int> counter;
			vector <int> temp;
			vector <int> tmp;
			vector <int> B;
			vector <int> A;
			cout << "輸入兩數字相除:";
			cin >> str_A >> str_B;

			int fl[2] = { 0 };
			minus_to_array(fl, &str_A, &str_B);
			fill_zero(&str_A, &str_B);

			for (int i = 0; i < str_B.size(); i++)
				B.push_back(str_B[i] - 48);

			for (int i = 0; i < str_A.size(); i++)
				A.push_back(str_A[i] - 48);

			for (int i = 1000; i > 0; i--) {
				temp.clear();
				tmp.clear();
				TRA(&tmp,&B,i);
				fill_zero(&A,&tmp);

				for (int j = 0; j < A.size(); j++)
					temp.push_back(A[j] - tmp[j]);

				if (!negative(temp)){
					counter.push_back(i);

					A.clear();
					remove_zero(&temp);

					RM(false, &temp);

					for (int j = 0; j < temp.size(); j++)
						A.push_back(temp[j]);

					i = 101;
				}
			}
			tmp.clear();
			tmp.push_back(0);
			for (int k = 0; k < counter.size(); k++) {
				tmp[tmp.size()-1] += counter[k];
				RA_N(&tmp);
			}
			system("color E");
			if (fl[0] != fl[1]) {
				temp.clear();
				fill_zero(&B, &A);
				for (int j = 0; j < B.size(); j++)
					temp.push_back(B[j] - A[j]);
				RM(false, &temp);
				remove_zero(&temp);

				tmp[tmp.size() - 1]++;
				RA_N(&tmp);
				char mn;
				if (fl[0])mn = '-';
				cout << "商:" << mn;
				for (int i = 0; i < tmp.size(); i++)
					cout << tmp[i];
				cout << ",餘數:";
				for (int i = 0; i < temp.size(); i++)
					cout << temp[i];
				cout << endl;
			}
			else {
				remove_zero(&A);
				cout << "商:";
				for (int i = 0; i <tmp.size(); i++)
					cout << tmp[i];
				cout << ",餘數:";
				for (int i = 0; i < A.size(); i++)
					cout << A[i];
				cout << endl;
			}
		}
		else if (l == 'g') {
			system("title two fucking long integer divide by (ANS with point)");
			string str_A, str_B, str_temp;
			vector <string> counter;
			vector <int> temp;

			cout << "輸入兩數字相除:";
			cin >> str_A >> str_B;

			int x;
			cout << "\n取小數點幾位?:";
			cin >> x;
			cout << "\n";

			int fl[2] = { 0 };
			minus_to_array(fl, &str_A, &str_B);

			int point = -1, NB = 0;
			while (1) {

				temp.clear();

				fill_zero(&str_A, &str_B);

				for (int i = 0; i<str_A.size(); i++)
					temp.push_back((int)(str_A[i] - str_B[i]));

				if (negative(temp)) {
					if (point==-1) point = counter.size();
					else {
						string str;
						str.push_back(NB + 48);
						counter.push_back(str);
						NB = 0;
					}
					str_A.push_back('0');
					x--;
					if (x<0) break;
					continue;
				}

				RM(negative(temp), &temp);

				bool flag = 0;
				for (int i = 0; i<temp.size(); i++) {
					if (temp[i] != 0)flag = 1;
					if (flag)str_temp.push_back(abs(temp[i]) + 48);
				}

				if (point == -1) counter.push_back(str_temp);
				else NB++;

				str_A = str_temp;
				str_temp.clear();
			}
			system("color E");
			cout << "商: ";
			if (fl[0] != fl[1] && !fl[1])cout << "-";

			cout << point << ".";
			for (int i = point; i<counter.size(); i++)
				cout << counter[i];
			cout << endl;
		}
		else if (l == 'h') {
			system("title fucking long integer root (ANS with point)");
			string str_A;
			vector <int> temp;

			cout << "輸入數字開二次方根:\n";
			cin >> str_A;

			int x;
			cout << "取小數點幾位?:\n";
			cin >> x;

			vector <int> SK;
			vector <int> CT;//
			vector <int> DT;//
			vector <int> tmp;//

			int point = 0;
			vector <char> counter;

			if (str_A.size() % 2)str_A = "0" + str_A;

			for (int j = 0; j<str_A.size(); j += 2)
				SK.push_back((str_A[j] - 48) * 10 + (str_A[j + 1] - 48));

			point = SK.size();
			x += SK.size();

			while (SK.size() < x)SK.push_back(0);

			bool flag = 0;
			DT.push_back(SK.front() / 10);
			DT.push_back(SK.front() % 10);
			SK.erase(SK.begin());

			for (int m = 0;; m++) {

				if (m == 10) {
					flag = 1;
					m -= 2;
					continue;
				}

				if (counter.size() == x)break;

				temp.clear();
				tmp.clear();

				CT.push_back(m);
				NRA(&tmp, &CT);

				while (DT.size() != tmp.size())
					if (DT.size()>tmp.size()) tmp.insert(tmp.begin(), 0);
					else DT.insert(DT.begin(), 0);

				for (int i = 0; i<DT.size(); i++)
					temp.push_back(DT[i] - tmp[i]);

				if (flag){
					counter.push_back(m + 48);
					SK.push_back(0);
					DT.clear();

					int t = 0;
					for (int i = temp.size() - 1; i >= 0; i--)
						if ((temp[i] - t)<0) DT.insert(DT.begin(), temp[i] - t + 10), t = 1;
						else DT.insert(DT.begin(), temp[i] - t), t = 0;

					while (!DT.empty())
						if (!DT[0]) DT.erase(DT.begin());
						else break;

					DT.push_back(SK.front() / 10);
					DT.push_back(SK.front() % 10);
					SK.erase(SK.begin());

					CT[CT.size() - 1] *= 2;

					m = 0;
					flag = 0;
					continue;
				}

				CT.pop_back();
				if (negative(temp)){
					flag = 1;
					m -= 2;
					continue;
				}
			}
			system("color E");
			for (int i = 0; i<counter.size(); i++) {
				if (i == point) cout << ".";
				cout << counter[i];
			}
			cout << endl;
		}
		else if (l == 'q') {
			return 0;
		}
		system("pause");
		system("cls");
	}
}
