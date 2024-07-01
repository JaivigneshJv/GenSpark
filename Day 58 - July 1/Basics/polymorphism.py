class Animal:
    def make_sound(self):
        pass

class Dog(Animal):
    def make_sound(self):
        return "Woof!"

class Cat(Animal):
    def make_sound(self):
        return "Meow!"

def print_animal_sound(animal):
    print(animal.make_sound())

dog = Dog()
cat = Cat()

print_animal_sound(dog)
print_animal_sound(cat)
