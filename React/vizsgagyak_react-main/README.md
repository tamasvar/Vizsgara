-------App.js--------

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
---------Kategoriak.js------------------

import React from 'react' 
import { useEffect, useState } from 'react' 
import { NavLink } from 'react-router-dom';

function Kategoriak() { const [kategoriak, setKategoria] = useState([]);
useEffect(() => {
    fetch("https://localhost:7082/api/kategoriak")
        .then((res) => res.json())
        .then((kategoriak) => setKategoria(kategoriak))
        .catch(console.log)

}, [])
function Refresh(){
    fetch("https://localhost:7082/api/kategoriak").then((res) => res.json()).then((Kategoriak) => setKategoria(Kategoriak))
}
function Torles(id){
    fetch("https://localhost:7082/api/kategoriak/" + id, {
                        method: "DELETE",
                        headers: {
                            'Accept': 'application/json, text/plain',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            id: id,
                        }),
                    })
                        .then(() => {
                            Refresh();
                        })
};
return (
    <div className='justify-content-center'>
        <br></br>
        <h5>Kategóriáink</h5>
        <div className='row justify-content-center'>
            {kategoriak.map((egyKat) => (
                <div className='card col-sm-3 d-inline-block m-4 p-2' style={{ background: "#eef0f6" }}>
                    <h6 className='text-muted'>{egyKat.megnevezes}</h6>
                    <h6 className='text-dark'>{egyKat.leiras}</h6>
                    {console.log(egyKat)}
                    <div className='card-body'>
                        <img className='img-fluid'
                            style={{ maxHeight: 200 }}
                            src={egyKat.kepek ? "./images/" + egyKat.kepek : "https://via.placeholder.com/400x800"} alt='Kategória képe' />
                    </div>
                    <div>
                        <NavLink key={egyKat.id} to={"/kategoria-modositas/"+egyKat.id}>
                            <button className='btn btn-outline-dark m-2'>Módosítás</button>
                        </NavLink>
                        <button onClick={() => {Torles(val.id);}}>Törlés</button>
                    </div>
                </div>
            ))}
        </div>
    </div>
)
}export default Kategoriak
-----Modositas.js-------

import { React, useEffect } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

export default function Modositas(props) {
    const {id} = useParams();
    const navigate = useNavigate();
    useEffect(() => {
        (async () => {
            try {
                const res = await fetch(`https://localhost:7082/api/kategoriak/${id}`);
                const kategoria = await res.json();
                document.getElementsByName("name")[0].value = kategoria.megnevezes;
                document.getElementById("description").value = kategoria.leiras;
                document.getElementsByName("image")[0].value = kategoria.kepek;
            }
            catch (err) {
                console.log(err);
            }
        })();
    }, [id]);
    return (
        <div className='p-5 content bg-whitesmoke text-center'>
            <h5 className='m-2'>Kategória módosítása</h5>
            <form
                onSubmit={(e) => {
                    e.persist();
                    e.preventDefault();
                
                  fetch("https://localhost:7082/api/kategoriak/" + id, {
                    method: "PUT",
                    headers: {
                        'Accept': 'application/json, text/plain',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        id:id,
                        megnevezes: e.target.elements.name.value,
                        leiras: e.target.elements.description.value,
                        kepek: e.target.elements.image.value,
                    }),
                })
                    .then(() => {
                        navigate("/");
                    })
                    .catch(console.log);
            }}>
            <div className='form-group row pb-3 justify-content-center'>
                <div className='col-sm-4'>
                    <input type="text" name='name' placeholder="Termék neve" className='form-control w-100' />
                </div>
            </div>
            <div className='form-group row pb-3 justify-content-center'>
                <div className='col-sm-4'>
                    <textarea id="description" type="text" name='description' placeholder="Leírás" className='form-control' />
                </div>
            </div>
            <div className='form-group row pb-3 justify-content-center'>
                <div className='col-sm-4'>
                    <input type="text" name='image' placeholder="Kép útvonal" className='form-control' />
                </div>
            </div>
            <br></br>
            <button type="submit" className='btn btn-outline-dark'>
                Módosítás
            </button>
        </form>
    </div>
);
}
----------UjKategoria.js-----------

 import React from 'react' 
import { useNavigate } from 'react-router-dom';               

function UjKategoria() { 
const navigate = useNavigate(); 
return ( 
<div className='p-5 content bg-whitesmoke text-center'>
<h5 className='m-5'>Új kategória hozzáadása</h5>
<form 
  onSubmit={(e) => { 
                    e.persist(); 
                    e.preventDefault();

fetch("https://localhost:7082/api/ujkategoriak", {
                    method: "POST",
                    headers: {
                        'Accept': 'application/json, text/plain',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        id: 0,
                        megnevezes: e.target.elements.name.value,
                        leiras: e.target.elements.description.value,
                        kepek: e.target.elements.image.value,
                    }),
                })
                    .then(() => {
                        navigate("/");
                    })
                    .catch(console.log);
            }}>
            <div className='form-group row pb-3 justify-content-center'>
                <div className='col-sm-4'>
                    <input type="text" name='name' placeholder="Termék neve" className='form-control w-100' />
                </div>
            </div>
            <div className='form-group row pb-3 justify-content-center'>
                <div className='col-sm-4'>
                    <input type="text" name='description' placeholder="Leírás" className='form-control' />
                </div>
            </div>
            <div className='form-group row pb-3 justify-content-center'>
                <div className='col-sm-4'>
                    <input type="text" name='image' placeholder="Kép útvonal" className='form-control' />
                </div>
            </div>
            <br></br>
            <button type="submit" className='btn btn-outline-dark'>
                Hozzáadás
            </button>
        </form>
    </div>
)
}
export default UjKategoria
--------nev.js----------

import React from 'react'

function Nev() {return (<div>Nev</div>)}

export default Nev
--------App.css----------

.App {text-align: center;}

.App-logo {height: 40vmin;pointer-events: none;}

@media (prefers-reduced-motion: no-preference) {.App-logo {animation: App-logo-spin infinite 20s linear;}}

.App-header {background-color: #282c34;min-height: 100vh;display: flex;flex-direction: column;align-items: center;justify-content: center;font-size: calc(10px + 2vmin);color: white;}

.App-link {color: #61dafb;}

@keyframes App-logo-spin {from {transform: rotate(0deg);}to {transform: rotate(360deg);}}
