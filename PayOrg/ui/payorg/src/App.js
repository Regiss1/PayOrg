import logo from './logo.svg';
import './App.css';
import {Register} from './Register';
import {BrowserRouter, Route, Routes, NavLink} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="App container">
     <h3 className="d-flex justify-content-right m-3">
       React JS FrontEnd
     </h3>
     <nav className="navbar navbar-expand-sm bg-light navbar-dark"> 
     <ul className="navbar-nav">
     <li className="nav-item-m-1">
       <NavLink className="btn btn-light btn-outline-primary" to="/Register">
         Register
       </NavLink>
     </li>
     </ul>
     </nav>
     <Routes>
       <Route path='/register' element={<Register/>}></Route>
     </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;
