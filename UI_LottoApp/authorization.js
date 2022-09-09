let  optionDraw = document.getElementsByTagName("li")[1];
let  optionUsers = document.getElementsByTagName("li")[3];


export function hideOption(role) {
  if (role != "Admin") {
    optionDraw.style.display = "none";
    optionUsers.style.display = "none";
  }
}
