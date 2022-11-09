import React, { useContext } from 'react';
import "./Basket.css";
import { Context } from "../Context/Context";
import BasketItem from './BasketItem';
import { Link } from "react-router-dom";
import { HiArrowLeft } from "react-icons/hi";

function Basket() {
    const { state, dispatch } = useContext(Context);

    return (
        <>
            <div className="favorite_container_linkBar">
                <div className="favorite_linkBar">                
                <Link className="favorite_backLink" to={"/"}>
                    <HiArrowLeft />
                    <span>Back</span>
                </Link>
                </div>
            </div>
            <div className="basket_container">
              <div className="basket_itemBox">
                {state.basket.map((product) => (
                  <BasketItem key={product.id} {...product} />
                ))}
              </div>
              <div className="basket_priceBox">
                <div className="basket_price">
                  <span>Total Price: </span>
                  <span>{state.totalPrice}€</span>
                </div>                
                <button className="basket_button_buy">Buy</button>
                <button
                  onClick={() => dispatch({ type: "EMPTY_BASKET" })}
                  className="basket_button_remove">

                  Delete {state.basket.length} item(s)  
                </button>
              </div>
            </div>
        </>
      );
}

export default Basket;