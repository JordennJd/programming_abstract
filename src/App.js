import './App.css';
import Button from './Button';
import {Routes,Route,Link,NavLink} from 'react-router-dom'
import Register from './pages/RegisterPage'
import Login from './pages/LoginPage'
import Home from "./pages/HomePage";
import {useEffect, useState} from "react";
import NavigateHeader from "./Components/NavigateHeader";

function App() {
        const [name, setName] = useState('');

        useEffect(() => {
        (
            async () => {
                const response = await fetch('http://localhost:5169/api/Authificate/User', {
                    headers: {'Content-Type': 'application/json'},
                    credentials: 'include',

                });

                const content = await response.json();
                setName(content.name);
            }
        )();
    });
  return (
    <div className="App">

        <NavigateHeader name={name} setName={setName}/>
            
        <Routes>
            <Route path="register" element={<Register/>}></Route>
            <Route path="login" element={<Login setName={setName}/>}></Route>
            <Route path="/" exact element={<Home name={name}/>}></Route>

        </Routes>
        
    </div>
  );
}

export default App;
