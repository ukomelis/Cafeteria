import React, { useContext } from "react";
import { Context } from "../../Context/Context";

function Card(props) {
    const { dispatch } = useContext(Context);

    return(
        <div onClick={() => dispatch({ type: "ADD_TO_BASKET", payload: props.id })}
            key={props.id} className="box">
          <img className="product_img" src={"./images/" + props.id + ".jpg"} alt="product" />
          <div className="content">
            <div className="title">
              <span>{props.title}</span>
            </div>
            <div className="price">
              <span>{props.price}€</span>
            </div>
            <div className="stock">
              <span>Stock: {props.stock}</span>
            </div>
          </div>
      </div>
    )
}

export default Card;