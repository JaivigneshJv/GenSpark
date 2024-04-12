# GenSpark Day 1 - Apr 09

## Overview

This repository is for understanding Git, and working on some logic problems.

## Tasks

1. Create a new repository and try conflicting and resolve it.
2. Work on some logic problems:
- [Two Sum](https://leetcode.com/problems/two-sum/description/)

```
class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        prevMap = {}  
        for i, n in enumerate(nums):
            diff = target - n
            if diff in prevMap:
                return [prevMap[diff], i]
            prevMap[n] = i
```


- [Palindrome Number](https://leetcode.com/problems/palindrome-number/description/)
```
class Solution:
    def isPalindrome(self, x: int) -> bool:
        if x < 0 or (x and x % 10 == 0):
            return False
        y = 0
        while y < x:
            y = y * 10 + x % 10
            x //= 10
        return x in (y, y // 10)
```

## Repository

The repository for this project can be found [here](https://github.com/gayat19/FSD09Apr2024).

## Additional Resources

- [Repo - Collaboration](https://github.com/srikanth-karthi/first-presidio)

