import {getWinners} from './apiRequests.js'
import { hideOption } from "./authorization.js"


let tableWinners = document.getElementById("table");
let user = JSON.parse(localStorage.getItem("user"));


hideOption(user.userType);


async function generateTable()
{
   let data = await getWinners();
   
   
   for (var i = 0; i < data.length; i++)
   {

    var tr = document.createElement("tr");
    tr.innerHTML = `
      <td>${data[i].firstName}</td>
      <td>${data[i].lastName}</td>
      <td>${data[i].lottoNumber}</td>
      <td>${data[i].prize.numberBalls}</td>
      <td>${data[i].prize.name}</td>
      `

    tableWinners.appendChild(tr);
    }
}



generateTable();


