def mutate_string(string, position, character):
    l = list(string)
    l[position] = character
    string = ''.join(l)
    return string
    #OR
    n = len(string)
    listq = list(string)
    for i in range(n):
        if i == position:
            listq[i] = character
            return ''.join(listq)

