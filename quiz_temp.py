import os


relate = {'狗': '雞', '雞': '米', '米': None}
bad_event = {'狗': "無情的做成虛擬雞", '雞': "殘酷的煮成花生米", '米': None}
A_side = ['狗', '雞', '米']
B_side = []
boat_side = True

while len(B_side) != 3:

    if boat_side:

        for item in B_side:
            if relate[item] in B_side:
                print("{}把{}{}吃了~QAQ".format(item, relate[item], bad_event[item]))
                exit(0)

        print("船現在在A岸:")
        for i in range(1, len(A_side)+1):
            print("{}. {}".format(i, A_side[i-1]))

        num = int(input("請問誰要上船呢? 輸入0直接到另一岸\n"))
        if len(A_side) < num or num < 0:
            continue
        elif num == 0:
            boat_side = not boat_side
            continue

        B_side.append(A_side[num-1])
        del A_side[num-1]

    else:

        for item in A_side:
            if relate[item] in A_side:
                print("{}把{}{}吃了~QAQ".format(item, relate[item], bad_event[item]))
                exit(0)

        print("船現在在B岸:")
        for i in range(1, len(B_side)+1):
            print("{}. {}".format(i, B_side[i-1]))

        num = int(input("請問誰要上船呢? 輸入0直接到另一岸\n"))
        if len(B_side) < num or num < 0:
            continue
        elif num == 0:
            boat_side = not boat_side
            continue
        A_side.append(B_side[num - 1])
        del B_side[num - 1]

    boat_side = not boat_side
    os.system('clear')

print("破關囉~!!!")

