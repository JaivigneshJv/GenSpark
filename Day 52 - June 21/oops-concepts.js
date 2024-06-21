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
