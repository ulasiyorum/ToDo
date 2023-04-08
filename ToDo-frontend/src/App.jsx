import { useEffect, useState } from 'react'
import { login, register } from '../lib/user';
import ToDoList from '../Components/ToDoList';
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
    <ToDoList user={user}/>
  ) : (<button onClick={registerEvent}>Register</button>)
}

export default App
