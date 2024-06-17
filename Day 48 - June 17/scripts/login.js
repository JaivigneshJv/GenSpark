// Check if the user is already logged in
window.onload = async function () {
  try {
    const response = await axios.get(`${config.API_URL}/User/profile`, {
      withCredentials: true,
    });
    if (response.status === 200) {
      if (response.data.role === "Admin") {
        // Redirect to the admin dashboard if the user is an admin
        window.location.href = "../admin/home.html";
      } else {
        window.location.href = "../pages/home.html";
      }
      // Redirect to the home page if logged in
    } else {
      return;
    }
  } catch (error) {}
};
// Login button event listener
document
  .getElementById("login-btn")
  .addEventListener("click", async function (event) {
    event.preventDefault();

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    if (username === "" || password === "") {
      // Display error message if fields are empty
      document.getElementById("error-msg").innerText =
        "Please fill in all fields";
      return;
    }

    try {
      const response = await axios.post(
        `${config.API_URL}/Auth/login`,
        {
          username: username,
          password: password,
        },
        {
          withCredentials: true,
        }
      );

      if (response.status === 200) {
        // Display success message and redirect to home page
        document.getElementById("error-msg").innerText =
          "login successful, redirecting...";
        setTimeout(() => {
          if (response.data.role === "Admin") {
            // Redirect to the admin dashboard if the user is an admin
            window.location.href = "../admin/home.html";
          } else {
            window.location.href = "../pages/home.html";
          }
        }, 5000);
      } else {
        // Display error message if login fails
        document.getElementById("error-msg").innerText = response.data.message;
        console.error(response.data.message);
      }
    } catch (error) {
      // Display error message for invalid credentials
      document.getElementById("error-msg").innerText = "Invalid Credentials";
    }
  });
