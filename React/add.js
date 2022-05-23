import React from 'react'

function Add_tab({onClose}) {

    function submit(e){
        e.preventDefault();
        fetch('https://localhost:5001/Termek',
        { 
            method: "POST",
            headers:{'Content-Type': 'application/json'},
            body: JSON.stringify({
                id: 0,
                nev: e.target.elements.nev.value,
                leiras: e.target.elements.leiras.value,
                ar: e.target.elements.ar.value,
                kep: e.target.elements.kep.value
            })
        })
		.then(() =>{
			alert('Added!');
            window.location.reload();
		})
    }

  return (
    <form onSubmit={submit}>
		<div className='form-group'>
			<label htmlFor='nev'>Név:</label>
			<input type="text" className="form-control" name="nev"/>
		</div>
		<div className='form-group'>
			<label htmlFor='ar'>Ár:</label>
			<input type="number" className="form-control" name="ar"/>
		</div>
		<div className='form-group'>
			<label htmlFor='kep'>Kép:</label>
			<input type="text" className="form-control" name="kep"/>
		</div>
		<div className='form-group'>
			<label htmlFor='leiras'>Leírás:</label>
			<input type="text" className="form-control" name="leiras"/>
		</div>
		<button type="submit" className="btn btn-primary">Submit</button>
        <button className="btn btn-danger" onClick={onClose}>Cancel</button>
    </form>
  )
}

export default Add_tab