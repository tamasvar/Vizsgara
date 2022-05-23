import React from 'react'

function Update_tab({onClose, termek}) {

    function submit(e){
        e.preventDefault();
        fetch('https://localhost:5001/Termek',
        { 
            method: "PUT",
            headers:{'Content-Type': 'application/json'},
            body: JSON.stringify({
                id: termek.id,
                nev: e.target.elements.nev.value,
                leiras: e.target.elements.leiras.value,
                ar: e.target.elements.ar.value,
                kep: e.target.elements.kep.value
            })
        })
		.then(() =>{
			alert('Updated!');
            window.location.reload();
		})
    }

  return (
    <form onSubmit={submit}>
		<div className='form-group'>
			<label htmlFor='nev'>Név:</label>
			<input type="text" className="form-control" name="nev" defaultValue={termek == null ? "" : termek.nev}/>
		</div>
		<div className='form-group'>
			<label htmlFor='ar'>Ár:</label>
			<input type="number" className="form-control" name="ar" defaultValue={termek == null ? "" : termek.ar}/>
		</div>
		<div className='form-group'>
			<label htmlFor='kep'>Kép:</label>
			<input type="text" className="form-control" name="kep" defaultValue={termek == null ? "" : termek.kep}/>
		</div>
		<div className='form-group'>
			<label htmlFor='leiras'>Leírás:</label>
			<input type="text" className="form-control" name="leiras" defaultValue={termek == null ? "" : termek.leiras}/>
		</div>
		<button type="submit" className="btn btn-primary">Submit</button>
        <button className="btn btn-danger" onClick={onClose}>Cancel</button>
	</form>
  )
}

export default Update_tab