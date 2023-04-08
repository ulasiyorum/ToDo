export async function register() {

    const data = await fetch("https://localhost:7198/api/v1/User/Register", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        }
      });

      return data.json();

}

export async function login(key) {

    const data = await fetch("https://localhost:7198/api/v1/User/Login?key=" + key, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json'
        }
      });

      return data.json();

}