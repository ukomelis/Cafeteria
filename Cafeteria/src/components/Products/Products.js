import React, { useContext } from "react";
import "./Products.css";
import { Context } from "../Context/Context";
import Card from "./Card/Card";

function Products() {
    const { state } = useContext(Context);
    const productsList = state.allProducts;

    return (
        <div className="product_container">
            {productsList.length > 0 ? (
            productsList.map((product) => <Card key={product.id} {...product} />)
            ) : (
            <div className="not_products">
                <span className="products_empty_title">No products</span>
            </div>
            )}
        </div>
    )
}

export default Products;