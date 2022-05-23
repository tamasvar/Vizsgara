import React from 'react'

function Delete_tab({onClose, termek}) {

    function submit(e){
        e.preventDefault();
        fetch('https://localhost:5001/Termek?id=' + termek.id,
        { 
            method: "DELETE"
        })
		.then(() =>{
			alert('Deleted!');
            window.location.reload();
		})
    }

  return (
    <form onSubmit={submit}>Are you sure you want to delete the item with the id <b>{termek == null ? "" : termek.id}</b>?<br/>
        <button type='submit' className="btn btn-primary">Yes</button>
        <button className="btn btn-danger" onClick={onClose}>Cancel</button>
    </form>
  )
}

export default Delete_tab