import React, { useContext } from "react";
import { Context } from "../../Context/Context";

function Card(props) {
    const { dispatch } = useContext(Context);

    return(
        <div className={props.stock > 0 ? "box" : "disabled box"}
            onClick={props.stock > 0 ? () => dispatch({ type: "ADD_TO_BASKET", payload: props.id }) : null}
            key={props.id}>
          <img className="product_img" src={"./images/" + props.id + ".jpg"} alt="product" />
          <div className="content">
            <div className="title">
              <span>{props.name}</span>
            </div>
            <div className="price">
              <span>Price: {props.price}€</span>
            </div>
            <div className="stock">
              <span>Stock: {props.stock}</span>
            </div>
          </div>
      </div>
    )
}

export default Card;