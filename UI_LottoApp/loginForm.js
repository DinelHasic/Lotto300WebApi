import { loginUserToken } from "./apiRequests.js";
import { parseJWT } from "./decode.js";

let password = document.getElementById("password");
let username = document.getElementById("userName");
let loginButton = document.getElementById("logIn");
let usernameError = document.getElementById("username_invalid");
let passwordError = document.getElementById("password_invalid");

loginButton.addEventListener("click", async function () {
  let user = { userName: `${username.value}`, password: `${password.value}` };

  let token = await loginUserToken(user);

  let decodeToken = parseJWT(token.data.data);

  localStorage.setItem("user", JSON.stringify(decodeToken));
  localStorage.setItem("token", JSON.stringify(token.data.data));

  location.replace("/Pages/Home.html");
});

password.addEventListener("input", function () {
  const passwordValidation = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{7,32}$/;

  let checkPassword = passwordValidation.test(password.value);

  if (checkPassword == false) {
    passwordError.style.display = "block";
  } else {
    passwordError.style.display = "none";
  }
});

username.addEventListener("input", function () {
  const userNameValidation = /^[A-z][A-z0-9-_]{5,12}$/;
  let checkUsername = userNameValidation.test(username.value);

  if (checkUsername === false) {
    usernameError.style.display = "block";
  } else {
    usernameError.style.display = "none";
  }
});
