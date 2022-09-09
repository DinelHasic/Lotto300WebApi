import { getDataUsers } from "./apiRequests.js";
import { hideOption } from "./authorization.js";

let tableUsers = document.getElementById("table");

let usersData = await getDataUsers();

let user = JSON.parse(localStorage.getItem("user"));

hideOption(user.role);

async function generateTable() {
  for (var i = 0; i < usersData.length; i++) {
    var tr = document.createElement("tr");
    tr.innerHTML = `
      <td>${usersData[i].id}</td>
      <td>${usersData[i].firstName}</td>
      <td>${usersData[i].lastName}</td>
      <td>${usersData[i].userName}</td>
      `;
    tableUsers.appendChild(tr);
  }
}

generateTable();
