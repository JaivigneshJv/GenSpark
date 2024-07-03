def count_substring(string, sub_string):
    a=len(string)
    b=len(sub_string)
    pp=0
    for i in range(a):
        if string[i] == sub_string[0]:
            k=i
            for j in range(b):
                try:
                    if sub_string[j] == string[k]:
                        c=1
                    else:
                        c=0
                        break
                    k=k+1
                except IndexError:
                    c=0
                    break
            if c==1:
                pp=pp+1
    return pp


