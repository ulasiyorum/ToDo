import { useEffect, useState } from 'react'
import { login, register } from '../lib/user';
function App() {

  const [user,setUser] = useState(null);

  useEffect(() => {
    loginEvent();
  },[]);

  const registerEvent = async () => {
    const data = await register();
    localStorage.setItem("key",data.data.loginKey);

    setUser(data.data);
  }

  const loginEvent = async () => {
    const key = localStorage.getItem("key");
    if(!key)
      return;

    const data = await login(key);

    setUser(data.data);
  }


  return user ? (
    <div>Hello {user.name}</div>
  ) : (<button onClick={registerEvent}>Register</button>)
}

export default App
