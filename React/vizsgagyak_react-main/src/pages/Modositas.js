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