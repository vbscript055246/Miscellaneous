#include <iostream>
#include <map>
#include <string>
#include <stdlib.h>
using namespace std;

map <string, int> ans;

void R(string &str, map <string, int>& f_map) {
	string buf;
	map <string, int> tmp_ans;
	for (int i = 0; i<str.size(); i++) {
		if ('a' <= str[i] && str[i] <= 'z') {
			buf.push_back(str[i]);
		}
		else if ('A' <= str[i] && str[i] <= 'Z') {
			if (!buf.empty()) {
				f_map[buf] += 1;
				buf.clear();
			}
			buf.push_back(str[i]);
		}
		else if ('2' <= str[i] && str[i] <= '9') {
			if (!buf.empty()) {
				f_map[buf] += (int)(str[i] - 48);
				buf.clear();
			}
			else {
				cout << "unreadable" << endl;
				exit(999);
			}
		}
		else {
			int pair = 1;
			if (!buf.empty()) {
				f_map[buf] += 1;
				buf.clear();
			}
			i++;
			while (pair != 0) {
				if (str[i] == '(') pair++;
				else if (str[i] == ')') pair--;
				buf.push_back(str[i]);
				i++;
			}
			buf.erase(buf.size()-1,1);
			R(buf, tmp_ans);
			buf.clear();
			if ('2' <= str[i] && str[i] <= '9') {
				for (map <string, int>::iterator j = tmp_ans.begin(); j != tmp_ans.end(); j++){
					(*j).second = (int)(str[i] - 48)*(*j).second;
				}
			}
			for (map <string, int>::iterator j = tmp_ans.begin(); j != tmp_ans.end(); j++) {
				f_map[(*j).first] += (*j).second;
			}
			tmp_ans.clear();
		}
	}
	if (!buf.empty()){
		f_map[buf] += 1;
	}

}
int main() {
	string str;
	cin >> str;
	R(str, ans);

	for (map <string, int>::iterator i = ans.begin(); i != ans.end(); i++) {
		cout << (*i).first << " : " << (*i).second << endl;
	}
	system("pause");
}
