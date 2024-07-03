if __name__ == '__main__':
    students = []
    scores = []
    for _ in range(int(input())):
        name = input()
        score = float(input())
        students.append((name, score))
        scores.append(score)
    second_lowest_score = min(a for a in scores if a > min(scores))
    students.sort(key=lambda k: k[0])    
    for st in students:
        if st[1] == second_lowest_score:
            print(st[0])