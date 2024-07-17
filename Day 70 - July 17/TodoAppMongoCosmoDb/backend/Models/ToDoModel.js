// // const express = require("express");

// // const app = express();

// // app.get("/", (req, res) => {
// //   res.send("hello world");
// // });

// // // GET method route

// // app.get("/", (req, res) => {
// //   res.send("GET request to the homepage");
// // });

// // // POST method route

// // app.post("/", (req, res) => {
// //   res.send("POST request to the homepage");
// // });

// const mongoose = require("mongoose");

// // Define a Mongoose schema for the "Task" document
// const taskSchema = new mongoose.Schema({
//   name: {
//     type: String,
//     required: true,
//   },
//   description: String,
//   isCompleted: {
//     type: Boolean,
//     default: false,
//   },
//   dueDate: Date,
// });

// // Create a Mongoose model based on the schema
// const Task = mongoose.model("Task", taskSchema);

// module.exports = Task;

const mongoose = require("mongoose");

const todoSchema = new mongoose.Schema({
  text: {
    type: String,
    required: true,
  },
});

module.exports = mongoose.model("ToDo", todoSchema);