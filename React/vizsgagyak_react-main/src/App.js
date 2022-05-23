import './App.css';
import { BrowserRouter, Link, Routes, Route } from 'react-router-dom';
import Kategoriak from './pages/Kategoriak';
import UjKategoria from './pages/UjKategoria';
import Nev from './pages/Nev';
import Modositas from './pages/Modositas';
import "bootstrap/dist/css/bootstrap.css";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <nav className='navbar navbar-expand-sm navbar-light' style={{ backgroundColor: "darkseagreen" }}>
          <div className='collapse navbar-collapse'>
            <ul className='navbar-nav'>
              <li className='nav-item'>
                <Link to="/" style={{textDecoration: "none"}}>
                  <span className='nav-link' style={{fontWeight:"bold"}} >Kategória</span>
                </Link>
              </li>
              <li className='nav-item'>
                <Link to="/uj-kategoria" style={{textDecoration: "none"}}>
                  <span className='nav-link' style={{fontWeight:"bold"}} >Új kategória</span>
                </Link>
              </li>
              <li className='nav-item'>
                <Link to="/nev" style={{textDecoration: "none"}}>
                  <span className='nav-link' style={{fontWeight:"bold"}} >Horváth Leticia</span>
                </Link>
              </li>
            </ul>
          </div>
        </nav>
        <Routes>
          <Route path="/" element={<Kategoriak />} />
          <Route path="/uj-kategoria" element={<UjKategoria />} />
          <Route path="/nev" element={<Nev />} />
          <Route path="/kategoria-modositas/:id" element={<Modositas />} />
        </Routes> 
      </BrowserRouter>
    </div>
  );
}

export default App;
