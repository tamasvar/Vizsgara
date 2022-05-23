import { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import Update_tab from './update'
import Delete_tab from './delete'
import Add_tab from './add'

function App() {
	const [termekek, setTermekek] = useState([]);

    const [deletedisplay, setDeleteDisplay] = useState(false);
    const [adddisplay, setAddDisplay] = useState(false);
    const [updatedisplay, setUpdateDisplay] = useState(false);
	const [termek, setTermek] = useState();

	useEffect(() =>{
		fetch('https://localhost:5001/Termekek')
		.then((res) => res.json())
		.then((json) =>{
			setTermekek(json);
			console.log(json);
		})
	}, [])

	function ImageCheck(image){
		try{
			var http = new XMLHttpRequest();
			http.open('HEAD', 'https://localhost:5001/images/' + image, false);
			http.send();
			
			if(http.status === 200){
				return true;
			}
		}
		catch{ }
		return false;
	}
	
	function Update(e){
		setAddDisplay(false);
		setDeleteDisplay(false);

		console.log(e.target.attributes[0].value)
        var termek = termekek.find((ter) => ter.id === parseInt(e.target.attributes[0].value));
        if(termek != null){
            setTermek(termek);
            setUpdateDisplay(true);
        }
    }

    function Delete(e){
		setAddDisplay(false);
		setUpdateDisplay(false);

        var termek = termekek.find((ter) => ter.id === parseInt(e.target.attributes[0].value));
        if(termek != null){
            setTermek(termek);
            setDeleteDisplay(true);
        }
    }

	return (
		<div className="App">
			<ul className="nav">
				<li className="nav-item">
		  			Termékek
				</li>
				<li className="nav-item" onClick={() => {setDeleteDisplay(false); setUpdateDisplay(false); setAddDisplay(true);}}>
		  			Új Termék
				</li>
				<li className="nav-item">
		  			Kirsch Ádám Péter
				</li>
	  		</ul>
			<table className="table table-striped">
				<thead>
					<tr>
						<th scope="col">#</th>
						<th scope="col">Név</th>
						<th scope="col">Ár</th>
						<th scope="col">Kép</th>
						<th scope="col">Leírás</th>
					</tr>
				</thead>
				<tbody>
					{termekek.map((termek) => (
						<tr key={termek.id}>
							<th scope="row">{termek.id}</th>
							<td>{termek.nev}</td>
							<td>{termek.ar}</td>
							<td><img src={ImageCheck(termek.kep) ? 'https://localhost:5001/images/' + termek.kep : 'https://via.placeholder.com/100x100/FFFFFF'} alt={termek.kep} /></td>
							<td>{termek.leiras}</td>
							<td><button onClick={Update} termekid={termek.id}>M.</button></td>
							<td><button onClick={Delete} termekid={termek.id}>T.</button></td>
						</tr>
					))}
				</tbody>
			</table>
		    <div className={adddisplay ? "" : "invisible"}><Add_tab onClose={() => {setAddDisplay(false)}}/></div>
		    <div className={updatedisplay ? "" : "invisible"}><Update_tab termek={termek} onClose={() => {setUpdateDisplay(false)}}/></div>
		    <div className={deletedisplay ? "" : "invisible"}><Delete_tab termek={termek} onClose={() => {setDeleteDisplay(false)}}/></div>
		</div>
	);
}

export default App;
