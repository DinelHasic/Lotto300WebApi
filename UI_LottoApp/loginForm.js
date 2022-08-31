import { getUsersCredentials } from "./apiRequests.js";

let password = document.getElementById("password");
let username = document.getElementById("userName");
let loginButton = document.getElementById("logIn");

let users = await getUsersCredentials();

console.log(users);

loginButton.addEventListener("click", function () {
  for (let user of users) {
    if (user.userName == username.value && user.password == password.value) {
      localStorage.setItem("user", JSON.stringify(user));
      location.replace("/Pages/Home.html");
    }
  }
});
