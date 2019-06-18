import random
import math
from scipy.stats import chi2
from scipy import stats
import numpy as np


def getChiSquareValue():
    chiSquare = 0
    for index in range(100):
        chiSquare += (array[index] - Ex[index]) ** 2 / Ex[index]
    return chiSquare


def getRand():
    for i in range(times):
        array[random.randint(1, 100) - 1] += 1

def getRandNormal(R):
    global array, prob
    x = np.arange(-R, R)
    xU, xL = x + 0.5, x - 0.5
    prob = stats.norm.cdf(xU, scale=sigma) - stats.norm.cdf(xL, scale=sigma)
    prob = prob / prob.sum()
    tmp = np.random.choice(x, size=times, p=prob)
    for i in range(times):
        array[tmp[i]+50] += 1

df = 99
times = 10**5
sigma = 10**1

array = [0 for x in range(100)]
getRandNormal(50)
Ex = [prob*np.array(times)]


if len(array) and len(Ex):
    f_obs = np.append(np.array(array), np.array(Ex)).reshape(2, 100)
    print(stats.chi2_contingency(f_obs, df)[0:3])

