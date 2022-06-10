#include <iostream>
#include <vector>
#include <stdlib.h>
#include <time.h>
#include <cmath>

#include <stdio.h>
#include <termios.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/ioctl.h>

#define hand_card_number 13
using namespace std;
char color[4] = { 'C','D','H','S' }; // 梅花 方塊 愛心 黑桃


int c_getche(void)
{
  struct termios old, _new;
  int ch;

  tcgetattr(0, &old);

  _new = old;
  _new.c_lflag &= ~ICANON;
  //new.c_lflag &= ~ECHO;
  tcsetattr(0, TCSANOW, &_new);

  ch = getchar();

  tcsetattr(0, TCSANOW, &old);
  return ch;
}


struct card { //卡片結構
	int c;
	int num;
};

void get_card(vector <card> &tmp, vector <card> &player) { //從牌庫中抽牌(method:Fisher–Yates shuffle)
	int index = rand() % tmp.size();
	player.push_back(tmp[index]);
	tmp[index] = tmp[tmp.size() - 1];
	tmp.pop_back();
}

void reset(vector <card> &tmp) {  //重設牌庫(因為使用Fisher–Yates shuffle)
	tmp.clear();
	for (int i = 0; i<4; ++i) {
		for (int j = 0; j < 13; ++j) {
			card ctmp;
			ctmp.c = i;
			ctmp.num = j;
			tmp.push_back(ctmp);
		}
	}
}

// 牌型分析系統
//===========================================================

// 6 同花順
int Straight_flush(vector <card> tmp) {
	if (tmp.size() != 5) return false;
	int c = -1, num[13] = { 0 };
	for (int i = 0; i < tmp.size(); i++) {
		if (c == -1) c = tmp[i].c,num[tmp[i].num]=1;
		else {
			if (!tmp[i].c == c) {
				return 0;
			}
			num[tmp[i].num] = 1;
		}
	}
	int counter = 0;
	for (int i = 0; i < 13; i++) {
		if (num[i] == 1) {
			counter++;
		}
		else {
			counter = 0;
		}
		if (counter == 5) break;
	}
	if (counter == 5) return tmp.front().c*100+ tmp.front().num;
	else return 0;
}

// 5 鐵支
int Four_of_a_kind(vector <card> tmp) {
	if (tmp.size() != 5) return 0;
	int num[13] = { 0 };
	for (int i = 0; i < 5; ++i) {
		num[tmp[i].num]++;
	}
	for (int i = 12; i >= 0; --i) {
		if (num[i] == 4) {
			return 3 * 100 + i;
		}
	}
	return false;

}

// 4 葫蘆
int Full_House(vector <card> tmp) {
	if (tmp.size() != 5) return 0;
	int num[13] = { 0 };
	for (int i = 0;i < 5; ++i) {
		num[tmp[i].num]++;
	}
	bool flag[2] = { 0 };
	int RTnum = -1;
	for (int i = 12; i>=0; --i) {
		if (num[i] == 2) flag[0] = 1;
		if (num[i] == 3) {
			RTnum = i;
			flag[1] = 1;
		}
	}
	if (flag[0]&&flag[1]) return  100 + RTnum;
	else return false;
}

// 3 同花
int flush(vector <card> tmp) {
	if (tmp.size() != 5) return false;
	int c[4] = { 0 };
	int num[13] = { 0 };
	for (int i = 0; i < 5; i++) {
		c[tmp[i].c]++;
	}
	for (int i = 0; i < 4; i++) {
		if (c[i] == 5) {
			for (int j = 0; j < 5; j++) {
				num[tmp[j].num]++;
			}
			for (int j = 12; j >= 0; j--) {
				if (num[j]) return  i*100 + j;
			}
		}
	}
	return false;
}

// 2 順子
int straight(vector <card> tmp) {
	if (tmp.size() != 5) return 0;
	int num[13] = {0};
	for (int i = 4; i >= 0; i--) {
		num[tmp[i].num]++;
	}
	int counter = 0;
	int RTc, RTnum;
	for (int i = 12; i >= 0; i++) {
		if (num[i] == 1) counter++;
		else if (num[i] > 1) return false;
		else {
			if (counter >= 1) break;
			counter = 0;
		}

		if (counter == 1) {
			RTnum = i;
		}
		else if (counter == 5) {
			break;
		}
	}
	if (counter == 5) {
		for (int i = 0; i < 5; i++) {
			if(tmp[i].num = RTnum) return tmp[i].c * 100 + tmp[i].num;
		}
	}
	else {
		return false;
	}
}

// 1 三條
int three_of_a_kind(vector <card> tmp) {
	int num[13] = { 0 };
	for (int i = (tmp.size()-1); i >= 0; i--) {
		num[tmp[i].num]++;
	}
	int RTnum=-1;
	for (int i = 12; i >= 0; i--) {
		if (num[i] == 3) {
			RTnum = i;
			break;
		}
	}
	int c[4] = { 0 };
	if (RTnum != -1) {
		for (int i = 0; i < tmp.size(); i++) {
			if (tmp[i].num == RTnum) {
				c[tmp[i].c]++;
			}
		}
		for (int j = 3; j >= 0; j--) {
			if (c[j] == 1) return j * 100 + RTnum;
		}
	}
	else {
		return false;
	}
	
}

// 0 對子
int two_pair(vector <card> tmp) {
	int num[13] = { 0 };
	for (int i = 0; i < tmp.size(); i++) {
		num[tmp[i].num]++;
	}
	int pairs = 0;
	int max_c = -1;
	int max_num = -1;
	for(int i=0;i<13;i++){
		if (num[i] == 2 ) {
			if(max_num < i)max_num = i;
			pairs++;
		}
	}
	if (pairs == 0) {
		return 0;
	}
	else {
		for (int i = 0; i < tmp.size(); i++) {
			if ((tmp[i].num == max_num) && (max_c < tmp[i].c))	max_c = tmp[i].c;
		}
	}
	return pairs*1000+ max_c * 100 + max_num;
}

// -1 單張


// 牌型比較系統(透過細節比較)
int cmp_cards(int *a,int *b,int num) {
	if ((num == 2) && (b[0] == 0)) {
		if((a[num] % 100) == (b[num] % 100)){
			return ((a[num] / 100) > (b[num] / 100));
		}
		return ((a[num] % 100) > (b[num] % 100));
	}
	else{
		if (a[num] == b[num]) {
			return cmp_cards(a, b, num + 1);
		}
		return a[num] > b[num];
	}
}

// 取得牌墩細節(包含牌型 最大花色 最大數字)
int *cards_detail(vector <card> cards) {
	int *detail = new int[3];
	detail[0] = -2;
	int(*cards_classes[7])(vector <card>);
	cards_classes[6] = Straight_flush;
	cards_classes[5] = Four_of_a_kind;
	cards_classes[4] = Full_House;
	cards_classes[3] = flush;
	cards_classes[2] = straight;
	cards_classes[1] = three_of_a_kind;
	cards_classes[0] = two_pair;

	for (int i = 6; i >= 0; i--) {
		int tmp = cards_classes[i](cards);
		if (tmp) {
			if (i != 0) {
				detail[0] = i;
				detail[2] = tmp / 100;
				detail[1] = tmp % 100;
			}
			else {
				detail[0] = i;
				detail[1] = tmp / 1000;
				detail[2] = tmp % 1000;
			}
			break;
		}
	}
	int max_num = -1;
	if (detail[0] == -2) {
		for (int i = 0; i < cards.size(); i++) {
			if (max_num < cards[i].num) {
				max_num = cards[i].num;
				detail[0] = -1;
				detail[2] = cards[i].c;
				detail[1] = cards[i].num;
			}
			
		}
		
	}
	return detail;
}

//===========================================================

// 玩家物件
class PlayerOBJ {
public:
	int sc = (1 << hand_card_number-1); // 選擇換牌時使用
	vector <card> tmp_hand,f_hand,m_hand,b_hand,cg_cards; //手牌區 tmp_hand,牌敦f_hand,m_hand,b_hand,換牌區cg_cards
	vector <vector<card>> comb_stack;// 電腦自主組牌使用(會把可能組成的牌型 塞進stack中)

	PlayerOBJ(vector <card> &tmp){ //建構式  會根據牌庫(tmp)抽出手牌
		tmp_hand.clear();
		for(int i=0;i<hand_card_number;i++) get_card(tmp, tmp_hand); //抽出手牌
	}

	void give_card(vector <card> &tmp) { //把自己要交換的牌傳給別人的手牌  別人的手牌 (tmp)
		for (int i = 0; i < cg_cards.size(); i++) {
			tmp.push_back(cg_cards[i]);
		}
		cg_cards.clear();
	}

	//顯示相關
	//===============================

	void show() { //顯示自己目前有的手牌
		cout << "| ";
		for (vector <card> ::iterator i = tmp_hand.begin(); i != tmp_hand.end(); i++) {
			switch(i->num) { //根據13張規則 A為最大 所以設定A為數字12 其他以此類推
				case 12:
					printf("%c,%2c ", color[i->c], 'A');
					break;
				case 11:
					printf("%c,%2c ", color[i->c], 'K');
					break;
				case 10:
					printf("%c,%2c ", color[i->c], 'Q');
					break;
				case 9:
					printf("%c,%2c ", color[i->c], 'J');
					break;
				default:
					printf("%c,%02d ", color[i->c], (i->num)+2);
					break;
			}
			cout << "| ";
		}
		cout << endl;
	}
	
	void select() { //選項游標顯示
		for (int i = tmp_hand.size()-1;i >= 0;i--) cout << ((sc & (1 << i)) ? "   |" : "    ") << "   ";
		cout << endl;
	}

	void show_give_cards() { //即將給出去的卡片
		for (vector <card> ::iterator i = cg_cards.begin(); i != cg_cards.end(); i++) {
			switch (i->num) {
				case 12:
					printf("%c,%2c\n", color[i->c], 'A');
					break;
				case 11:
					printf("%c,%2c\n", color[i->c], 'K');
					break;
				case 10:
					printf("%c,%2c\n", color[i->c], 'Q');
					break;
				case 9:
					printf("%c,%2c\n", color[i->c], 'J');
					break;
				default:
					printf("%c,%02d\n", color[i->c], (i->num) + 2);
					break;
			}
		}
	}

	void show(int *map) { //根據傳進來的map做手牌輸出
		cout << "| ";
		for (int i = 0; i < tmp_hand.size(); i++) {
			if (map[i] == 0) {
				switch (tmp_hand[i].num) {
				case 12:
					printf("%c,%2c ", color[tmp_hand[i].c], 'A');
					break;
				case 11:
					printf("%c,%2c ", color[tmp_hand[i].c], 'K');
					break;
				case 10:
					printf("%c,%2c ", color[tmp_hand[i].c], 'Q');
					break;
				case 9:
					printf("%c,%2c ", color[tmp_hand[i].c], 'J');
					break;
				default:
					printf("%c,%02d ", color[tmp_hand[i].c], (tmp_hand[i].num) + 2);
					break;
				}
				cout << "| ";
			}
		}
		cout << endl;
	}
	//===============================


	//手牌組合系統(電腦自主組牌使用)
	//============================================

	void combination() {
		update_card_map(); //將手牌(vector容器)轉換二維陣列 方便做演算

		vector <card> temp_cards; //儲存剛抽取的可能組合
		comb_stack.clear();//淨空 以防之前已使用過

		while(1){ //抽取手牌中所有可能的同花順
			temp_cards = Straight_flush();
			if (temp_cards.size() == 5) {
				comb_stack.push_back(temp_cards);
				temp_cards.clear();
			}
			else {
				break;
			}
		}
		while (1) {//抽取手牌中所有可能的鐵支(少一張單張)
			temp_cards = Four_of_a_kind();
			if (temp_cards.size() == 4) {
				comb_stack.push_back(temp_cards);
				temp_cards.clear();
			}
			else {
				break;
			}
		}
		while (1) { //抽取手牌中所有可能的葫蘆
			temp_cards = Full_House();
			if (temp_cards.size() == 5) {
				comb_stack.push_back(temp_cards);
				temp_cards.clear();
			}
			else {
				break;
			}
		}
		while (1) {//抽取手牌中所有可能的同花
			temp_cards = flush();
			if (temp_cards.size() == 5) {
				comb_stack.push_back(temp_cards);
				temp_cards.clear();
			}
			else {
				break;
			}
		}
		while (1) {//抽取手牌中所有可能的順子
			temp_cards = straight();
			if (temp_cards.size() == 5) {
				comb_stack.push_back(temp_cards);
				temp_cards.clear();
			}
			else {
				break;
			}
		}
		while (1) {//抽取手牌中所有可能的三條
			temp_cards = three_of_a_kind();
			if (temp_cards.size() == 3) {
				comb_stack.push_back(temp_cards);
				temp_cards.clear();
			}
			else {
				break;
			}
		}
		while (1) { //抽取手牌中所有可能的對子
			temp_cards = two_pair();
			if (temp_cards.size() == 2) {
				comb_stack.push_back(temp_cards);
				temp_cards.clear();
			}
			else {
				break;
			}
		}
		temp_cards = one_pair();//取出剩下的牌
		if(temp_cards.size()>0) comb_stack.push_back(temp_cards);//剩下的牌塞入comb_stack中
		
		for (vector <vector<card>> ::iterator i = comb_stack.begin(),parent= comb_stack.end(); i !=comb_stack.end(); i++) { //將comb_stack中的對子 試圖兩兩成對組合後塞回comb_stack中
			if (i->size() == 2&& parent== comb_stack.end()) { //找到一個對子
				parent = i;
			}
			else if (i->size() == 2 && parent != comb_stack.end()) { //找到另一個對子
				while (i->size() != 0) { //另一個對子 塞入先前的一個對子中
					parent->push_back(i->back());
					i->pop_back();
				}
				i = comb_stack.erase(i); //清除已淨空的"空vector<card>"  傳回下一格的iterator
				i--;//為了抵銷等等的i++ 才不會漏掉一格
				parent = comb_stack.end();//重置未找到的狀態
			}
		}

		//==================================================================
		if (comb_stack.size() < 3) { //過多的散牌
			vector<card>temp_stack;
			while (comb_stack[1].size() > 5) { //將散牌分出 直到該墩牌數正確
				temp_stack.push_back(comb_stack[1].back());
				comb_stack[1].pop_back();
			}
			comb_stack.push_back(temp_stack);
		}
		else if (comb_stack.size() > 3) { //單獨的對子或三條導致
			while (comb_stack.size()!=3) {//將多餘的牌敦 全部塞入comb_stack[2]中等待下一階段處理
				if (comb_stack.back().size()==0) {
					comb_stack.pop_back();
				}
				else {
					comb_stack[2].push_back(comb_stack.back().back());
					comb_stack.back().pop_back();
				}
				
			}
		}
		//==================================================================

		for (vector <vector<card>> ::iterator i = comb_stack.begin(); i != comb_stack.end(); i++) { //抽取最後牌墩的牌 補齊每個牌墩(鐵支的牌在這時候補齊)
			if (i!= (comb_stack.end()-1)) { //不處理"前墩的牌" 也就是comb_stack的最後一個元素
				while (i->size() !=5) {//如果有牌墩牌不5張 抽牌補齊為止
					i->push_back(comb_stack.back().back());
					comb_stack.back().pop_back();
				}
			}	
		}

		//將處理好的牌存入前中後墩中
		b_hand = comb_stack[0];
		m_hand = comb_stack[1];
		f_hand = comb_stack[2];
	}

private:

	int card_map[4][13] = { 0 }; //將手牌轉換二維陣列用
	
	void update_card_map() { //將手牌轉換二維陣列用
		for (int i = 0; i < 4; i++)
			for (int j = 0; j < 13; j++)
				card_map[i][j] = 0;//初始化

		for (int i = 0; i < tmp_hand.size(); i++)
			card_map[tmp_hand[i].c][tmp_hand[i].num] = 1;//紀錄手牌有的牌
	}
	
	vector <card> Straight_flush() {
		vector <card> temp_cards;
		card temp_card;
		for (int i = 3; i >=0; i--) {
			for (int j = 12; j >=4; j--) {
				if (card_map[i][j] == 1) {
					temp_card.c = i;
					temp_card.num = j;
					temp_cards.push_back(temp_card);
				}
				else {
					temp_cards.clear();
				}
				if (temp_cards.size() == 5) {
					for (int k = 0; k < temp_cards.size(); k++) card_map[temp_cards[k].c][temp_cards[k].num]=2;
					return temp_cards;
				}
			}
			temp_cards.clear();
		}
		return temp_cards;
	}

	vector <card> Four_of_a_kind() { //一張待補
		vector <card> temp_cards;
		card temp_card;
		for (int i =12; i>=0; i--) {
			for (int j = 0; j < 4; j++) {
				if (card_map[j][i] == 1) {
					temp_card.c = j;
					temp_card.num = i;
					temp_cards.push_back(temp_card);
				}
				else {
					break;
				}
				if (temp_cards.size() == 4) {
					for (int k = 0; k < temp_cards.size(); k++) card_map[temp_cards[k].c][temp_cards[k].num] = 2;
					return temp_cards;
				}
			}
			temp_cards.clear();
		}
		return temp_cards;
	}

	vector <card> Full_House() {
		vector <card> rt_cards;
		vector <card> temp_cards;
		card temp_card;
		rt_cards = three_of_a_kind();
		if (rt_cards.size() < 3) {
			rt_cards.clear();
			return rt_cards;
		}
		temp_cards = two_pair();
		if (temp_cards.size() < 2) {
			for (int i = 0; i < rt_cards.size(); i++) {
				card_map[rt_cards[i].c][rt_cards[i].num] = 1;
			}
			temp_cards.clear();
			return temp_cards;
		}
		for (int i = 0; i < temp_cards.size(); i++) {
			rt_cards.push_back(temp_cards[i]);
		}
		return rt_cards;
	}

	vector <card> flush() {
		vector <card> temp_cards;
		card temp_card;
		for (int i = 3; i >= 0;i--) {
			for (int j = 12; j >=5; j--) {
				if (card_map[i][j] == 1) {
					temp_card.c = i;
					temp_card.num = j;
					temp_cards.push_back(temp_card);
				}
				if (temp_cards.size() == 5) {
					for (int k = 0; k < temp_cards.size(); k++) card_map[temp_cards[k].c][temp_cards[k].num] = 2;
					return temp_cards;
				}
			}
			temp_cards.clear();
		}
		return temp_cards;
	}

	vector <card> straight() {
		vector <card> temp_cards;
		card temp_card;
		for (int i = 12; i >= 4; i--) {
			bool flag = false;
			for (int j = 3; j >= 0; j--) {
				if (card_map[j][i] == 1) {
					temp_card.c = j;
					temp_card.num = i;
					temp_cards.push_back(temp_card);
					flag = true;
					break;
				}
			}
			if (temp_cards.size() == 5) {
				for (int k = 0;  k < temp_cards.size(); k++) {
					card_map[temp_cards[k].c][temp_cards[k].num]=2;
				}
				return temp_cards;
			}
			if(!flag)temp_cards.clear();
		}
		return temp_cards;
	}

	vector <card> three_of_a_kind() {
		vector <card> temp_cards;
		card temp_card;
		for (int i = 12; i >= 0; i--) {
			for (int j = 0; j < 4; j++) {
				if (card_map[j][i] == 1) {
					temp_card.c = j;
					temp_card.num = i;
					temp_cards.push_back(temp_card);
				}
				if (temp_cards.size() == 3) {
					for (int k = 0; k < temp_cards.size(); k++) {
						card_map[temp_cards[k].c][temp_cards[k].num] = 2;
					}
					return temp_cards;
				}
			}
			temp_cards.clear();
		}
		return temp_cards;
	}

	vector <card> two_pair() {
		vector <card> temp_cards;
		card temp_card;
		for (int i = 12;i>=0; i--) {
			for (int j = 3; j >=0; j--) {
				if (card_map[j][i] == 1) {
					temp_card.c = j;
					temp_card.num = i;
					temp_cards.push_back(temp_card);
				}
				if (temp_cards.size() == 2) {
					for (int k = 0; k < temp_cards.size(); k++) {
						card_map[temp_cards[k].c][temp_cards[k].num] = 2;
					}
					return temp_cards;
				}
			}
			temp_cards.clear();
		}
		return temp_cards;
	}

	vector <card> one_pair() {
		vector <card> temp_cards;
		card temp_card;
		for (int i = 3; i>=0; i--) {
			for (int j = 12;j>=0; j--) {
				if (card_map[i][j] == 1) {
					temp_card.c = i;
					temp_card.num = j;
					temp_cards.push_back(temp_card);
				}
			}
		}
		return temp_cards;
	}
	//============================================
};

int main() {
	

	vector <card> tmp; //牌堆
	vector <PlayerOBJ> PA; //玩家
	
	//取得遊玩人數
	int player_num = 0;
	cout << "輸入遊玩人數" << endl;
	cin >> player_num;

	int total_score[4] = { 0 };//紀錄win的局數
	
	while (1) {
		srand((unsigned)time(NULL)); // 亂數種子初始化

		reset(tmp); // 重整牌庫

		PA.clear();// 重整儲存玩家物件的容器
		for (int i = 0; i < player_num; i++) { //建立玩家物件
			PlayerOBJ PBT(tmp);
			PA.push_back(PBT);//將玩家物件放入容器方便編寫程式
		}

		for (int i = 0; i < PA.size(); i++) {  //顯示手牌初始狀態
			cout << "手牌: " << i + 1 << endl;
			PA[i].show();
		}
		cout << endl;
		system("read -n 1 -p \"Press any key to continue...\"");
	
		// 選擇牌組
		cout << "選擇牌組 :" << endl;
		int x;
		cin >> x;
		system("clear");
		x--;//玩家輸入的值多一

		//處理玩家選擇的牌 交換至PA[0]物件的手牌	
		vector<card> swap_temp;
		swap_temp = PA[0].tmp_hand;
		PA[0].tmp_hand = PA[x].tmp_hand;
		PA[x].tmp_hand = swap_temp;


		for (int i = 0; i < PA.size(); i++) {  //顯示目前手牌狀態
			cout << "手牌: " << i + 1 << endl;
			PA[i].show();
		}
		cout << endl;
		system("read -n 1 -p \"Press any key to continue...\"");
		system("clear");


		//決定交換牌的對象
		//===================================

		vector <int> CGP; //紀錄交換對象
		if (player_num == 2) { //只有兩個玩家 直接互換
			CGP.push_back(1);
			CGP.push_back(0);
		}
		else {
			int temp[4] = { 0,1,2,3 }; //隨機抽取交換對象(method:Fisher–Yates shuffle)
			for (int i = 0; i < 4; i++) {
				int index = rand() % (4-CGP.size());
				CGP.push_back(temp[index]);
				temp[index] = temp[4 - CGP.size()];
			}
		}
		//===================================

		//玩家選擇交換的牌
		for (int j = 0; j < 3; j++) { 
			char t = '\0'; //初始化選項變數
			while (t != 's') { //如果輸入 's' 視為選定選項
				cout << "玩家手牌第" << j << "次選擇交換的牌:" << endl;
				PA[0].show();			 //顯示手牌
				PA[0].select();			 //顯示選項游標
				PA[0].show_give_cards(); //顯示將要給出的卡片
				fflush(stdin);//清空輸入緩衝區(以防吃到不該吃的)
				t = c_getche();//讀取一個字元
				fflush(stdin);//清空輸入緩衝區(以防吃到不該吃的)
				system("clear");
				switch (t) {
					case 'a'://選項游標往左(如果不是在最左的話)
						if (PA[0].sc < pow(2, hand_card_number - j - 1)) PA[0].sc = PA[0].sc << 1;
						break;
					case 'd'://選項游標往右(如果不是在最右的話)
						if (PA[0].sc  > 1) PA[0].sc = PA[0].sc >> 1;
						break;
					case 's'://選定該選項
						for (int k = 0; k < PA[0].tmp_hand.size(); k++) {//找出玩家選擇選項
							if (PA[0].sc & (1 << k)) {
								PA[0].cg_cards.push_back(PA[0].tmp_hand[PA[0].tmp_hand.size() - k - 1]);
								PA[0].tmp_hand[PA[0].tmp_hand.size() - k - 1] = PA[0].tmp_hand[PA[0].tmp_hand.size() - 1];
								PA[0].tmp_hand.pop_back();
								break;
							}
						}
						PA[0].sc = (1 << (PA[0].tmp_hand.size() - 1));
						break;
				}
			}
		}
		cout << "你要交給對方的牌是:" << endl;
		PA[0].show_give_cards();
		system("read -n 1 -p \"Press any key to continue...\"");
		system("clear");

		//電腦思考交換牌
		for (int i = 1; i < player_num; i++) { 
			PA[i].combination();//先湊牌一次 看看有那些組合
			PA[i].cg_cards = PA[i].f_hand;//把前墩的牌 給別人(通常是雜牌)
			for (int j = 0; j < PA[i].f_hand.size(); j++) {
				for (vector <card>::iterator k = PA[i].tmp_hand.begin(); k != PA[i].tmp_hand.end(); k++) {
					if ((k->c == PA[i].f_hand[j].c )&&(k->num == PA[i].f_hand[j].num)) {
						PA[i].tmp_hand.erase(k);
						break;
					}
				}
			}
		}  

		//執行交換牌
		for (int i = 0; i < player_num; i++) PA[i].give_card(PA[CGP[i]].tmp_hand); 
	
		//電腦手牌分成前中後三墩
		for (int i = 1; i < player_num; i++) PA[i].combination();

		//玩家自選前中後三墩
		
		while(1){
			
			int a[5] = { 0 };
			int card_map[13] = { 0 };
			cout << "選擇你的前墩" << endl;
			PA[0].show(card_map);
			for (int j = 0; j < PA[0].tmp_hand.size(); j++) printf("  %2d   ", j);
			cout << endl;
			for (int j = 0; j < 3; ++j) cin >> a[j];
			for (int j = 0; j < 3; ++j) {
				if (card_map[a[j]] == 1) {
					cout << "請勿輸入已經使用過的牌" << endl;
					system("read -n 1 -p \"Press any key to continue...\"");
					system("clear");
					continue;
				}
				card_map[a[j]] = 1;
			}
			PA[0].f_hand.clear();
			for (int j = 0; j < 3; ++j) PA[0].f_hand.push_back(PA[0].tmp_hand[a[j]]);

			cout << "選擇你的中墩" << endl;
			PA[0].show(card_map);
			for (int j = 0; j < PA[0].tmp_hand.size(); j++)if (card_map[j] == 0) printf("  %2d   ", j);
			cout << endl;
			for (int j = 0; j < 5;++j) cin >> a[j];
			for (int j = 0; j < 5; ++j) {
				if (card_map[a[j]] == 1) {
					cout << "請勿輸入已經使用過的牌" << endl;
					system("read -n 1 -p \"Press any key to continue...\"");
					system("clear");
					continue;
				}
				card_map[a[j]] = 1;
			}
			PA[0].m_hand.clear();
			for (int j = 0; j < 5; ++j)PA[0].m_hand.push_back(PA[0].tmp_hand[a[j]]);

			cout << "選擇你的後墩" << endl;
			PA[0].show(card_map);
			for (int j = 0; j < PA[0].tmp_hand.size(); j++)if (card_map[j] == 0) printf("  %2d   ", j);
			cout << endl;
			for (int j = 0; j < 5; ++j) cin >> a[j];
			for (int j = 0; j < 5; ++j) {
				if (card_map[a[j]] == 1) {
					cout << "請勿輸入已經使用過的牌" << endl;
					system("read -n 1 -p \"Press any key to continue...\"");
					system("clear");
					continue;
				}
				card_map[a[j]] = 1;
			} 
			PA[0].b_hand.clear();
			for (int j = 0; j < 5; ++j) PA[0].b_hand.push_back(PA[0].tmp_hand[a[j]]);
			
			//PA[0].combination();//測試使用
			
			int *bd = cards_detail(PA[0].b_hand);
			int *md = cards_detail(PA[0].m_hand);
			int *fd = cards_detail(PA[0].f_hand);
			if (cmp_cards(md, bd, 0) || cmp_cards(fd, md, 0)) {
				cout << "輸入錯誤: 前不能大於中 中不能大於後" << endl;
				system("read -n 1 -p \"Press any key to continue...\"");
				system("clear");
			}
			else {
				break;
			}
		}
	
		//勝負系統(計算贏幾墩)
		//====================================================
		//舊版
		/*
		vector <vector<card>> comp_cards;
		int score_board[4] = { 0 };

		for (int k = 0; k < 3; k++) {
			comp_cards.clear();
			switch (k) {
				case 0:
					for (int i = 0; i < player_num; i++) comp_cards.push_back(PA[i].f_hand);
					break;
				case 1:
					for (int i = 0; i < player_num; i++) comp_cards.push_back(PA[i].m_hand);
					break;
				case 2:
					for (int i = 0; i < player_num; i++) comp_cards.push_back(PA[i].b_hand);
					break;
			}
			int *max =new int[3];
			max[0] = -9;
			int turn_max_player=-1;
			for (int i = 0; i < comp_cards.size(); i++) {
				int *tmp = cards_detail(comp_cards[i]);
				if (cmp_cards(tmp,max,0,1)) { //========================
					turn_max_player = i;
				}
			}
			score_board[turn_max_player]++;
		}
		*/

		int score_board[4] = { 0 }; //儲存墩數
		for (int i = 0; i < player_num; i++) {     //先選一個玩家
			for (int j = 0; j < player_num; j++) { //與前一個比較的人
				if (i == j) continue;//同一個人不用比較
				int score = 0;//贏幾個牌墩
				for (int k = 0; k < 3; k++) {
					switch (k) {
						case 0:
							if (cmp_cards(cards_detail(PA[i].f_hand), cards_detail(PA[j].f_hand), 0)) score++;
							break;
						case 1:
							if (cmp_cards(cards_detail(PA[i].m_hand), cards_detail(PA[j].m_hand), 0)) score++;
							break;
						case 2:
							if (cmp_cards(cards_detail(PA[i].b_hand), cards_detail(PA[j].b_hand), 0)) score++;
							break;
					}

				}
				switch (score) {
					case 0:
						score_board[j]+=6;
						break;
					case 1:
						score_board[j]++;
						break;
					case 2:
						score_board[i]++;
						break;
					case 3:
						score_board[i] += 6;
						break;
				}
			}
			
		}
		//====================================================

		//顯示贏家
		int MT = -1; //最大墩數
		vector <int> winner;
		for (int i = 0; i < player_num; i++){ //選一個玩家的墩數
			total_score[i]+=score_board[i];
			if (MT < score_board[i]) { //墩數較多刷新最大墩數
				winner.clear();
				MT = score_board[i];
				winner.push_back(i);
			}
			else if (MT == score_board[i]) { //同墩數
				winner.push_back(i);
			}
		}

		cout << "這一輪贏家 ";
		for (int i = 0; i < winner.size(); i++)	cout << winner[0] + 1 << " ";
		cout << " player ,贏了 " << MT << " 墩" << endl;
		system("read -n 1 -p \"Press any key to continue...\"");
		system("clear");

		cout << "總計:" << endl;
		for (int i = 0; i < 4; i++) cout << "玩家 :" << i+1 << " ,贏了 " << total_score[i] << " 墩" << endl;

		char c;
		cout << "(r).重新開始	(n).下一輪	(q).離開" << endl;
		fflush(stdin);
		c = c_getche();
		fflush(stdin);
		system("clear");
		switch (c) {
			case 'r':
				for (int i = 0; i < 4; i++) total_score[i] = 0;
				break;
			case 'n':
				break;
			case 'q':
				return 0;
				break;
		}
	}
}
