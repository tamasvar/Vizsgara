import React from 'react'
import { useEffect, useState } from 'react'
import { NavLink } from 'react-router-dom';

function Kategoriak() {
    const [kategoriak, setKategoria] = useState([]);

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
}

export default Kategoriak