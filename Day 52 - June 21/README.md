# Student Class - JavaScript OOP Example

This repository contains an example implementation of a `Student` class in JavaScript, demonstrating various Object-Oriented Programming (OOP) concepts such as encapsulation, abstraction, inheritance, and polymorphism.

## Table of Contents

- [Student Class - JavaScript OOP Example](#student-class---javascript-oop-example)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [OOP Concepts](#oop-concepts)
    - [Encapsulation](#encapsulation)
    - [Abstraction](#abstraction)
    - [Inheritance](#inheritance)
    - [Polymorphism](#polymorphism)
  - [Prototype-Based Inheritance Example](#prototype-based-inheritance-example)
  - [Student Class Example](#student-class-example)
  - [Usage](#usage)
  - [Conclusion](#conclusion)

## Introduction

This project demonstrates the application of key OOP principles using JavaScript's prototype-based inheritance. We define a `Person` class and extend it to create a `Student` class. Additionally, we create a `GraduateStudent` class to showcase inheritance and polymorphism.

## OOP Concepts

### Encapsulation

Encapsulation is achieved by creating private properties and methods within a class, allowing controlled access and modification. In our `Student` class, grades are managed privately, with methods to add and calculate grades.

### Abstraction

Abstraction involves hiding complex implementation details and exposing only the necessary parts of an object. The `Student` class abstracts the complexity of grade calculation by providing simple methods to interact with grades.

### Inheritance

Inheritance allows a class to inherit properties and methods from another class. The `Student` class inherits from the `Person` class, and the `GraduateStudent` class further extends the `Student` class, demonstrating multi-level inheritance.

### Polymorphism

Polymorphism enables objects to be treated as instances of their parent class, while still retaining their own specific behaviors. We override the `getDetails` method in both `Student` and `GraduateStudent` classes to demonstrate polymorphism.

## Prototype-Based Inheritance Example

```javascript
// Define a Person constructor
function Person(name, age) {
  this.name = name;
  this.age = age;
}

// Add a method to the Person prototype
Person.prototype.greet = function () {
  console.log("Hello, my name is " + this.name);
};

// Define a Student constructor, inheriting from Person
function Student(name, age, studentId) {
  // Call the Person constructor
  Person.call(this, name, age);
  this.studentId = studentId;
}

// Set up inheritance so that Student inherits from Person
Student.prototype = Object.create(Person.prototype);
Student.prototype.constructor = Student;

// Add a method to the Student prototype
Student.prototype.study = function () {
  console.log(this.name + " is studying.");
};

// Example usage
let student = new Student("Alice", 20, "S12345");
student.greet(); // "Hello, my name is Alice"
student.study(); // "Alice is studying."
```

## Student Class Example

```javascript
// Base class Person
class Person {
  constructor(name, age) {
    this.name = name;
    this.age = age;
  }

  getDetails() {
    return `Name: ${this.name}, Age: ${this.age}`;
  }

  greet() {
    console.log("Hello, my name is " + this.name);
  }
}

// Student class inheriting from Person
class Student extends Person {
  constructor(name, age, studentId, grades = []) {
    super(name, age);
    this.studentId = studentId;
    this._grades = grades; // Encapsulation of grades

    // Private method to calculate average grade
    this._calculateAverage = function () {
      if (this._grades.length === 0) return 0;
      let total = this._grades.reduce((sum, grade) => sum + grade, 0);
      return total / this._grades.length;
    };
  }

  // Public method to add grade
  addGrade(grade) {
    this._grades.push(grade);
  }

  // Public method to get average grade
  getAverageGrade() {
    return this._calculateAverage();
  }

  // Overriding the getDetails method (Polymorphism)
  getDetails() {
    return `${super.getDetails()}, Student ID: ${
      this.studentId
    }, Average Grade: ${this.getAverageGrade().toFixed(2)}`;
  }
}

// Example usage
let student = new Student("Alice", 20, "S12345", [85, 90, 78]);
student.greet(); // "Hello, my name is Alice"
console.log(student.getDetails()); // "Name: Alice, Age: 20, Student ID: S12345, Average Grade: 84.33"

student.addGrade(95);
console.log(student.getAverageGrade()); // 87
console.log(student.getDetails()); // "Name: Alice, Age: 20, Student ID: S12345, Average Grade: 87.00"

// Polymorphism example with another subclass
class GraduateStudent extends Student {
  constructor(name, age, studentId, grades, thesisTitle) {
    super(name, age, studentId, grades);
    this.thesisTitle = thesisTitle;
  }

  // Overriding the getDetails method
  getDetails() {
    return `${super.getDetails()}, Thesis Title: ${this.thesisTitle}`;
  }
}

let gradStudent = new GraduateStudent(
  "Bob",
  25,
  "G54321",
  [90, 92, 88],
  "Quantum Computing"
);
gradStudent.greet(); // "Hello, my name is Bob"
console.log(gradStudent.getDetails()); // "Name: Bob, Age: 25, Student ID: G54321, Average Grade: 90.00, Thesis Title: Quantum Computing"
```

## Usage

To run the examples, simply include the JavaScript code in your project and execute it in a JavaScript runtime environment, such as a web browser or Node.js.

```
npm start
```

## Conclusion

This project showcases how to implement and utilize various OOP principles in JavaScript using prototype-based inheritance. It provides a clear demonstration of encapsulation, abstraction, inheritance, and polymorphism through the `Person`, `Student`, and `GraduateStudent` classes.
