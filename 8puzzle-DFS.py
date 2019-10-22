import copy

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
        if ind % 3 == 0 and num == 1:
            return None
        if ind % 3 == 2 and num == 0:
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


# 7, 2, 4, 5, 0, 6, 8, 3, 1
# 1, 8, 2, 4, 0, 5, 3, 6, 7
# 1, 2, 5, 3, 4, 8, 6, 0, 7
question = [ 
    1, 2, 5,
    3, 0, 8,
    6, 4, 7
]
ans = [0, 1, 2, 3, 4, 5, 6, 7, 8]
ans = table(ans)
history = []
stack = []
count = 0
def DFS(var):
    global stack, history, count
    count+=1
    if count % 1000 == 0:
        print(count)
    if var == ans:
        for ct, item in enumerate(stack):
            print(ct)
            print(item)
        print(ans)
        exit(1)
    else:
        for i in range(4):
            temp = var.premove(i)
            if temp is not None:
                r1 = any(temp == sitem for sitem in stack)
                r2 = any(temp == hisitem for hisitem in history)
                if not(r1 or r2):
                    stack.append(temp)
                    history.append(temp)
                    DFS(temp)
                    stack.pop()

# stack.append()
DFS(table(question))
print("GG!")
