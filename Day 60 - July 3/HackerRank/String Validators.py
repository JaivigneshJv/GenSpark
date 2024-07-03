if __name__ == '__main__':
    s = input()
    a = True
    b = True
    c = True
    d = True
    e = True
    
    for i in range (len(s)):
        if (s[i].isalnum()):
            a = True
            break
        else:
            a = False
            
    for i in range (len(s)):
        if (s[i].isalpha()):
            b = True
            break
        else:
            b = False
    
    for i in range (len(s)):
        if (s[i].isdigit()):
            c = True
            break
        else:
            c = False 
    
    for i in range (len(s)):
        if (s[i].islower()):
            d = True
            break
        else:
            d = False 
    
    for i in range (len(s)):
        if (s[i].isupper()):
            e = True
            break
        else:
            e = False 

    print(a)
    print(b)
    print(c)
    print(d)
    print(e)
