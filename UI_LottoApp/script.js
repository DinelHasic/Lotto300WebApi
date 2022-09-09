import { sendUserNumbers } from "./apiRequests.js";
import { hideOption } from "./authorization.js";

let sendNumber = document.getElementById("sendNumbers");
let showNumbers = document.getElementById("lottoNumbers");
let username = document.getElementById("username");
let numbersSelected = document.getElementById("numbersSelected");
let storingLottoNumbers;
let numberCount;

let user = JSON.parse(localStorage.getItem("user"));

username.value = `${user.name}`;

hideOption(user.role);

console.log(username.value);

function generateLottoNumbers() {
  numberCount = 0;
  storingLottoNumbers = [];
  showNumbers.innerHTML = "";

  sendNumber.disabled = true;

  for (let i = 1; i <= 37; i++) {
    let button = document.createElement("button");

    button.classList.add("dot");
    button.textContent = `${i}`;

    showNumbers.append(button);
  }

  console.log(localStorage.getItem("user"));
}

// ------Sending Lotto Numbers--------
sendNumber.addEventListener("click", function () {
  let user = {
    username: username.value,
    lottoNumbers: numbersSelected.value,
  };
  sendUserNumbers(user);

  numbersSelected.value = "";

  generateLottoNumbers();
});

// -------Selecting Numbers----------
document.addEventListener("click", function (e) {
  if (e.target.classList == "dot") {
    if (numberCount < 7) {
      let number = e.target.innerText;

      storingLottoNumbers.push(number);
      numbersSelected.value += number;
      numbersSelected.value += " ";
      e.target.disabled = "true";

      numberCount++;
    }
    if (numberCount == 7) {
      sendNumber.disabled = false;
    }
  }
});

generateLottoNumbers();
