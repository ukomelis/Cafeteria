import React from 'react';
import Card from '../Card/Card';
import styled from "styled-components";

function ProductsContainer(props) {

    const CardContainer = styled.div`
        display: flex;
        flex-wrap: wrap;
        align-items: center;
        justify-content: center;        
    `;

    const Separator = styled.span`
        margin-left: 10px;
        margin-right: 10px;
    `;

    if(props.isLoading) { return <div> Loading ... </div> };
    return (
        <div className="products">
            <h1>Products</h1>
            <CardContainer>
                {props.products.map((product) => (
                <>
                <Separator />
                    <Card
                        key={product.id}
                        id={product.id}
                        name={product.name}
                        stock={product.stock}
                        price={product.price}
                    />
                </>
                ))}                
            </CardContainer>
        </div>
    );
}

export default ProductsContainer;