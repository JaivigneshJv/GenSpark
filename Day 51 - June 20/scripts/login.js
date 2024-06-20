const users = [
  {username: "user1", password: "pass1"},
  {username: "user2", password: "pass2"},
];

function validateLogin(username, password) {
  return users.some(
    (user) => user.username === username && user.password === password
  );
}

function setupFormListener() {
  document
    .getElementById("loginForm")
    .addEventListener("submit", function (event) {
      event.preventDefault();

      const username = document.getElementById("username").value;
      const password = document.getElementById("password").value;
      const loginMessage = document.getElementById("loginMessage");

      if (validateLogin(username, password)) {
        loginMessage.textContent = "Login successful!";
        loginMessage.classList.remove("text-danger");
        loginMessage.classList.add("text-success");
      } else {
        loginMessage.textContent = "Invalid username or password.";
      }
    });
}

if (typeof document !== "undefined") {
  setupFormListener();
}

module.exports = {validateLogin, setupFormListener};
