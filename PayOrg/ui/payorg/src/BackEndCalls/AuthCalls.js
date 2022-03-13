

export default async function CreateUser(email, password) {
  //eslint-disable-next-line
  console.log(email, password);
  return await fetch("http://localhost:5000/register/Create", {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: `{"Email": "${email}","Senha": "${password}"}`,
  }) .then((response) => response.json())
  .then((responseData) => {
    return responseData;
  }).catch(error => console.warn(error));
}
   
export async function Ping() {
  //eslint-disable-next-line
  let response = await fetch("http://localhost:5000/Ping", {
    method: 'GET',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
  },
  ).then(response => {
    if (response.ok) {
      response.json().then(json => {
        return console.log(json);
      });
    }
  });
  return "";

}
