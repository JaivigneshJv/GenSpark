def swap_case(word):
    swap_word=""
    for letter in word:
        if letter.islower():
            swap_word+= letter.upper()
        elif letter.isupper():
            swap_word+=letter.lower()
        else:
             swap_word += letter

    return swap_word 

