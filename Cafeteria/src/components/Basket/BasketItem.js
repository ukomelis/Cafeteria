import React from "react";

export default function BasketItem(props) {
  return (
    <div className="basket_item">
        <div className="basket_img">
          <img src={"./images/" + props.id + ".jpg"} alt="basket_item" />
        </div>
        <div className="basket_content">
          <span className="basket_title">{props.name}</span>
          <span className="basket_count">Count: {props.count}</span>
          <span>{(props.price * props.count)}€</span>
        </div>
    </div>
  );
}