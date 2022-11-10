import React, { createContext, useReducer } from "react";
import useGetProducts from "../../hooks/useGetProducts";

const sumPrice = (items) => {
    const totalPrice = items.reduce((totalPrice, product) => {
      return totalPrice + product.price * product.count;
    }, 0);

    return { totalPrice };
};

const intialState = {
    allProducts: [],
    basket: [],
    totalPrice: 0
};

const reduce = (state, action) => {
    switch (action.type) {
        case "ADD_TO_BASKET": {
            const allProductsIndex = state.allProducts.findIndex(
                (product) => product.id === action.payload
            );
            if(!state.allProducts[allProductsIndex].stock > 0) return;

            const hasProduct = state.basket.some(
              (product) => product.id === action.payload
            );
            if (!hasProduct) {
              const mainItem = state.allProducts.find(
                (product) => product.id === action.payload
              );
              mainItem.count = 1;

              state.basket.push(mainItem);
            } else {
                const productIndex = state.basket.findIndex(
                    (product) => product.id === action.payload
                  );
                state.basket[productIndex].count++;
            }
            
            state.allProducts[allProductsIndex].stock--;
      
            return {
              ...state,
              ...sumPrice(state.basket)
            };
          }
          case "EMPTY_BASKET": {
            state.basket = state.basket.forEach((product) => (product.count = 1));
            state.basket = [];

            return {
              ...state,
              ...sumPrice(state.basket)
            };
          }
        default:
            return state;
    }
}

export const Context = createContext();

export default function ContextProvider({ children }) {

    const { data } = useGetProducts();
    intialState.allProducts = data;

    const [state, dispatch] = useReducer(reduce, intialState);
    return (
        <Context.Provider value={{ state, dispatch }}>
            {children}
        </Context.Provider>
    );
}