import './App.css';
import Register from './Register';
import Login from './Login';
import {MyProfiles} from './Profile';
import {BrowserRouter, Route, Routes, NavLink} from 'react-router-dom';
import Ping from './BackEndCalls/AuthCalls'

function App() {
  return (
    <BrowserRouter>
    <div className="App container">
     <h3 className="d-flex justify-content-right m-3" > 
       React JS FrontEnd
     </h3>
     <nav className="navbar navbar-expand-sm bg-light navbar-dark"> 
     <ul className="navbar-nav">
     <li className="nav-item-m-1">
       <NavLink className="btn btn-light btn-outline-primary" to="/Register">
         Register
       </NavLink>
     </li>
     <li className="nav-item-m-1">
       <NavLink className="btn btn-light btn-outline-primary" to="/Login">
         Login
       </NavLink>
     </li>
     <li className="nav-item-m-1">
       <NavLink className="btn btn-light btn-outline-primary" to="/Profile">
         Profile Teste
       </NavLink>
     </li>
     </ul>
     </nav>
     <Routes>
       <Route path='/register' element={<Register/>}></Route>
       <Route path='/login' element={<Login/>}></Route>
       <Route path='/profile' element={<MyProfiles/>}></Route>
     </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
