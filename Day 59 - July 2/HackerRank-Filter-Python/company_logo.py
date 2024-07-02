#!/bin/python3

import math
import os
import random
import re
import sys
from collections import Counter



if __name__ == '__main__':
    s = sorted(input())
    characters = Counter(s).most_common(3)
    
    for i in characters:
        print(f'{i[0]} {i[1]}')
