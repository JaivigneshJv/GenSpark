const fs = require("fs");
const path = require("path");
const {JSDOM} = require("jsdom");
const {validateLogin, setupFormListener} = require("../scripts/login");

describe("Login Page", () => {
  let dom;
  let document;

  beforeEach(() => {
    const html = fs.readFileSync(
      path.resolve(__dirname, "../src/index.html"),
      "utf8"
    );
    dom = new JSDOM(html, {runScripts: "dangerously"});
    document = dom.window.document;
    global.document = document;
    setupFormListener();
  });

  afterEach(() => {
    dom.window.close();
  });

  test("validateLogin function works correctly", () => {
    expect(validateLogin("user1", "pass1")).toBe(true);
    expect(validateLogin("user2", "pass2")).toBe(true);
    expect(validateLogin("user1", "wrongpass")).toBe(false);
    expect(validateLogin("invaliduser", "pass1")).toBe(false);
    expect(validateLogin("invaliduser", "wrongpass")).toBe(false);
  });

  test("successful login displays success message", () => {
    document.getElementById("username").value = "user1";
    document.getElementById("password").value = "pass1";

    const form = document.getElementById("loginForm");
    const event = new dom.window.Event("submit");
    form.dispatchEvent(event);

    const loginMessage = document.getElementById("loginMessage");
    expect(loginMessage.textContent).toBe("Login successful!");
    expect(loginMessage.classList.contains("text-success")).toBe(true);
    expect(loginMessage.classList.contains("text-danger")).toBe(false);
  });

  test("failed login displays error message", () => {
    document.getElementById("username").value = "user1";
    document.getElementById("password").value = "wrongpass";

    const form = document.getElementById("loginForm");
    const event = new dom.window.Event("submit");
    form.dispatchEvent(event);

    const loginMessage = document.getElementById("loginMessage");
    expect(loginMessage.textContent).toBe("Invalid username or password.");
    expect(loginMessage.classList.contains("text-danger")).toBe(true);
    expect(loginMessage.classList.contains("text-success")).toBe(false);
  });
});
