import copy
import math
class table:

    def __init__(self, arr, front=-1):
        self.array = copy.copy(arr)
        self.front = front

    def __eq__(self, other):

        for i in range(9):
            if self.array[i] != other.array[i]:
                return False
        return True

    def __str__(self):
        s = ""
        for i in range(3):
            for j in range(3):
                s += str(self.array[i*3+j]) + ' '
            s += '\n'
        return s

    def premove(self, num): # up:3 down:2 left:1 right:0
        AW = [1, 0, 3, 2]
        temp = copy.copy(self.array)
        ind = temp.index(0)
        if (ind % 3 == 0 and num == 1) or (ind % 3 == 2 and num == 0):
            return None

        oind = ind + (-3 if num & 1 else 3) * (num >= 2) + (-1 if num else 1) * (num < 2)
        if 0 > oind or oind > 8:
            return None
        temp[ind], temp[oind] = temp[oind], temp[ind]
        return table(temp, AW[num])

    def do(self, num):
        temp = copy.copy(self.array)
        ind = temp.index(0)
        oind = ind + (-3 if num & 1 else 3) * (num >= 2) + (-1 if num else 1) * (num < 2)
        temp[ind], temp[oind] = temp[oind], temp[ind]
        return table(temp,-2)

    def get_cost(self):

        filter = [
            [0, 1, 3, 4],
            [1, 2, 4, 5],
            [3, 4, 6, 7],
            [4, 5, 7, 8]
        ]
        temp_array = []
        for j in range(4):
            ind = self.array.index(0)
            if (ind % 3 == 0 and j == 1) or(ind % 3 == 2 and j == 0):
            	continue
            oind = ind + (-3 if j & 1 else 3) * (j >= 2) + (-1 if j else 1) * (j < 2)
            sum = 10
            if 0<=oind<9:
                for i in range(4):
                    if (ind in filter[i]) and (self.array[oind] in filter[i]):
                        sum -= 1
                temp_array.append([j, sum])

        temp_array.sort(key=lambda x: x[1])
        return [x[0] for x in temp_array]

# 7, 2, 4, 5, 0, 6, 8, 3, 1
# 1, 8, 2, 4, 0, 5, 3, 6, 7
# 1, 2, 5, 3, 4, 8, 6, 0, 7
# 1, 2, 0, 3, 4, 5, 6, 7, 8
question = [7, 2, 4, 5, 0, 6, 8, 3, 1]
queue = [table(question)]
history = [table(question)]
ans = [0, 1, 2,
       3, 4, 5,
       6, 7, 8]
ans = table(ans)
count = 0
while len(queue):
    var = queue.pop(0)
    count += 1
    if count % 1000 == 0: print(count)

    res = any(ans == queitem for queitem in queue)
    if res:
        while var != ans:
            var = queue.pop(0)
        print("solve")
        print(var)
        temp = var.do(var.front)
        while 1:
            print(temp)
            for item in history:
                if item == temp:
                    if item.front == -1:
                        exit(1)
                    temp = item.do(item.front)
                    break

    else:
        for i in var.get_cost():
            temp = var.premove(i)
            if temp is not None:
                result = any(temp == hisitem for hisitem in history)
                if not(result):
                    #print(temp)
                    queue.append(temp)
                    history.append(temp)
print("無解!")

