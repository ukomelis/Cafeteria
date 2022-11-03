function Card(props) {
	return (
		<div className="card">
			<img src={props.image} alt={props.name} />
			<div className="card-body">
				<h3>{props.name}</h3>
				<p>In stock: {props.quantity}</p>
				<p className="price">{props.price}€</p>
			</div>
		</div>
	);
}

export default Card;