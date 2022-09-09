import { sendDrawnNumbers } from "./apiRequests.js";
import { hideOption } from "./authorization.js";

let drawNumbers = document.getElementById("drawNumbers");
let generateRandomNumbers = document.getElementById("generateRandomNumbers");
let storingDrawnNumbers = "";

let user = JSON.parse(localStorage.getItem("user"));

hideOption(user.role);

function generateLottoNumbers() {
  sendNumber.disabled = true;

  for (let i = 1; i <= 37; i++) {
    let button = document.createElement("button");

    button.classList.add("dot");
    button.textContent = `${i}`;

    showNumbers.append(button);
  }
}

drawNumbers.addEventListener("click", function (e) {
  generateRandomNumbers.innerHTML = "";
  storingDrawnNumbers = "";
  for (let i = 0; i < 8; i++) {
    let number = Math.floor(Math.random() * 37) + 1;
    generateRandomNumbers.innerHTML += `<span class="drawnNumbers"> ${number} </span>`;
    storingDrawnNumbers += number.toString();

    if(i != 7) storingDrawnNumbers += " ";
  }

  sendDrawnNumbers(storingDrawnNumbers);
});
