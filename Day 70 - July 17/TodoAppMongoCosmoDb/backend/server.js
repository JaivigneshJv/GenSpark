//Best

// const express = require("express");

// const app = express();

// app.get("/", (req, res) => {
//   res.send("hello world");
// });

// // GET method route

// app.get("/", (req, res) => {
//   res.send("GET request to the homepage");
// });

// // POST method route

// app.post("/", (req, res) => {
//   res.send("POST request to the homepage");
// });

const express = require("express");
const mongoose = require("mongoose");
const cors = require("cors");

const routes = require("./routes/ToDoRoute");

require("dotenv").config();

const app = express();
const PORT = process.env.PORT || 8001;

app.use(express.json());
app.use(cors());

mongoose
  .connect(process.env.MONGODB_URL, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  })
  .then(() => console.log("MongoDB connected..."))
  .catch((err) => console.log(err));

app.use(routes);

app.listen(PORT, () => console.log(`Server started on port ${PORT}`));
