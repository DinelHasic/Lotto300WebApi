
export async function getUsersCredentials() {
  const data = await fetch(
    `https://localhost:7121/api/User/all/users/credentials`
  );

  const dataJson = await data.json();

  return dataJson;
}

// Getall User
export async function getDataUsers() {
  const data = await fetch(`https://localhost:7121/api/User/all/users`);

  const dataJson = await data.json();

  return dataJson;
}

// Get Users that Won
export async function getWinners() {
  const data = await fetch(`https://localhost:7121/api/Game/winners`);

  const dataJson = await data.json();

  return dataJson;
}

// Adding new User
export async function sendCreatedUserr(text) {
  await fetch(`https://localhost:7121/api/User/create/user`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(text),
  }).then((res) => {
    console.log("Request complete! response:", res);
  });
}

// Adding lotto numbers user selected
export async function sendUserNumbers(user) {
  await fetch(`https://localhost:7121/api/Game/numbers/selected`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(user),
  }).then((res) => {
    console.log("Request complete! response:", res);
  });
}

//Sending drawn numbers
export async function sendDrawnNumbers(number) {
  await fetch(`https://localhost:7121/api/Game/drawn/numbers`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(number),
  }).then((res) => {
    console.log("Request complete! response:", res);
  });
}
