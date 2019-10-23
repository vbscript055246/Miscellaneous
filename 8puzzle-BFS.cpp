#include <iostream>
#include <vector>
#include <thread>
using namespace std;

class table{
public:
    friend ostream& operator<<(ostream& os, const table& obj);

    int front;
    int Hindex;

    table(int *newTable, int ft = -1, int hi = -1):front(ft), Hindex(hi){
        for(int i=0;i<9;i++) array[i] = newTable[i];
    }

    bool operator==(table &other){
        for(int i=0;i<9;i++)
            if(array[i] != other.array[i]) return false;
        return true;
    }

    int index(int n){
        for(int i=0;i<9;i++) if (array[i] == n) return i;
    }

    table *nextmove(int num){   // up:3 down:2 left:1 right:0
        //int anti_way[] = {1, 0, 3, 2};

        table *next = new table(array);
        int ind = index(0);

        if((ind % 3 == 0 && num == 1) || (ind % 3 == 2 && num == 0))
            return NULL;
        int oind = ind + (num & 1? -3:3) * (num >= 2) + (num?-1:1) * (num < 2);
        if (oind > 8 || oind < 0)
            return NULL;
        swap(next->array[ind], next->array[oind]);
        return next;
    }

private:
    int array[9];

};

ostream& operator<<(ostream& os, const table& obj)
{
    for (int i=0;i<3;i++){
        for(int j=0;j<3;j++){
            os << obj.array[i*3+j] << " ";
        }
        os << endl;
    }
    os << endl;
    return os;
}

int main() {
    vector <table> que;
    vector <table> history;
    int count = 0;
    int question[] = { 7, 2, 4, 5, 0, 6, 8, 3, 1};
    //7, 2, 4, 5, 0, 6, 8, 3, 1

    int ans_arr[] = {
            0, 1, 2,
            3, 4, 5,
            6, 7, 8
    };
    table start = table(question, -1, 0);
    que.push_back(start);
    history.push_back(start);
    table ans(ans_arr);

    while(que.size()){
		count++;
        if(count%1000 == 0) cout << count <<endl;
        table var = que.front();
        que.erase(que.begin());
        if (var == ans){
            cout << "solve" << endl;
            //print
            cout << var;
            while(var.front != -1){
                var = history[var.front];
                //print
                cout << var;
            }
            exit(6);
        }
        else{
            for(int i=0;i<4;i++){
                table *temp = var.nextmove(i);
                if (temp != NULL){
                    bool flag = 0;
                    for(int j =0;j<history.size();j++){
                        if (history[j] == *temp){
                            flag = 1;
                            break;
                        }
                    }
                    if (flag) continue;

                    temp->front = var.Hindex;
                    temp->Hindex = history.size();
                    que.push_back(*temp);
                    history.push_back(*temp);
                }
            }
        }
    }
    cout << "GG" << endl;
}
