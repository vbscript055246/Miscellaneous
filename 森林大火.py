import copy

class point:

    def __init__(self, X=0, Y=0):
        self.x = X
        self.y = Y

    def __add__(self, other):
        x = self.x + other.x
        y = self.y + other.y
        return point(x, y)


class F:

    def __init__(self, n):
        self.queue = list()
        self.num = n

    def update_map(self):
        global way, map, obj_fire
        poi_num = len(self.queue)
        flag = 0
        for i in range(poi_num):
            temp = self.queue[0]
            self.queue.remove(self.queue[0])
            for w in way:
                tmp = temp + w
                if 0 <= tmp.x < len(map[0]) and 0 <= tmp.y < len(map) and map[tmp.y][tmp.x] == 0:
                    self.queue.append(tmp)
                    map[tmp.y][tmp.x] = self.num
                    flag = 1
                elif 0 <= tmp.x < len(map[0]) and 0 <= tmp.y < len(map) and map[tmp.y][tmp.x] and map[tmp.y][tmp.x] != self.num:
                    self.queue += obj_fire[map[tmp.y][tmp.x]-1].queue
                    obj_fire[map[tmp.y][tmp.x] - 1].queue = list()
                    flag = 1
        return flag


def get_F(temp, num):
    global way, map
    output = [temp]
    queue = [temp]
    map[temp.y][temp.x] = num
    while len(queue):
        temp = queue[0]
        queue.remove(queue[0])
        for i in range(4):
            tmp = temp + way[i]
            if 0 <= tmp.x < len(map[0]) and 0 <= tmp.y < len(map) and map[tmp.y][tmp.x] == -1:
                queue.append(tmp)
                output.append(tmp)
                map[tmp.y][tmp.x] = num

    return output


def dfs(stack, obj_fire):

    global map, max, best_stack

    if len(stack):
        flag = 0
        for item in obj_fire:
            flag = flag or item.update_map()
        '''
        for item in map:
            print(item)
        print()
        '''
        if not flag:
            score = 0
            for i in range(len(map)):
                for j in range(len(map[0])):
                    if map[i][j] == 0:
                        score += 1
            if score > max:
                max = score
                best_stack = copy.deepcopy(stack)
            return

    for item in obj_fire:
        if len(item.queue):
            queue_backup = copy.deepcopy(item.queue)
            item.queue = list()
            backup_map = copy.deepcopy(map)
            stack.append(item.num)
            dfs(stack, obj_fire)
            stack.pop()
            map = backup_map
            item.queue = queue_backup


way = [point(0, -1), point(1, 0), point(0, 1), point(-1, 0),
       point(1, -1), point(1, 1), point(-1, 1), point(-1, -1)]

fire = []
map = []
obj_fire = []
best_stack = []
max = 0

mn = [int(e) for e in input().split()]
k = int(input())

for i in range(k):
    temp = [int(e) for e in input().split()]
    fire.append(temp)

for i in range(mn[0]): map.append([0] * mn[1])

for item in fire: map[item[0]][item[1]] = -1


for i in range(len(map)):
    for j in range(len(map[0])):
        if map[i][j] == -1:
            obj_fire.append(F(len(obj_fire)+1))
            obj_fire[-1].queue = get_F(point(i, j), len(obj_fire))


dfs([], obj_fire)
print(max)
print(best_stack)



