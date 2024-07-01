class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def display(self):
        print(f"Name: {self.name}, Age: {self.age}")

class Employee(Person):
    def __init__(self, name, age, employee_id):
        super().__init__(name, age)
        self.employee_id = employee_id

    def display(self):
        super().display()
        print(f"Employee ID: {self.employee_id}")

# Creating an object of the Employee class
employee1 = Employee("Bob", 35, "E123")
employee1.display()
