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
