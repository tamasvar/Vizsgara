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