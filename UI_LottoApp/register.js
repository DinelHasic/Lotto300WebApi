
import { sendCreatedUserr} from './apiRequests.js'


let name = document.getElementById("name");
let surname = document.getElementById("surname");
let userName = document.getElementById("userName");
let password = document.getElementById("password");
let button = document.getElementsByTagName("button")[1];


// -------Creating new User-----------
button.addEventListener("click", function (e) {
  e.preventDefault();

  let data = {
    firstName: name.value,
    lastName: surname.value,
    userName: userName.value,
    password: password.value,
  };

  sendCreatedUserr(data);
});