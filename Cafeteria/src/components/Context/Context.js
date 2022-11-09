import React, { createContext, useReducer } from "react";
import allProducts from "../../hooks/Data";

//const { data, isLoading, error } = useGetProducts();

const intialState = {
    allProducts,
    basket: [],
    totalPrices: 0
};

const sumPrice = (items) => {
    const totalPrice = items.reduce((totalPrice, product) => {
      return totalPrice + product.price * product.count;
    }, 0);

    return { totalPrice };
  };


const reduce = (state, action) => {
    switch (action.type) {
        case "ADD_TO_BASKET": {
            const hasProduct = state.basket.some(
              (product) => product.id === action.payload
            );
            if (!hasProduct) {
              const mainItem = state.allProducts.find(
                (product) => product.id === action.payload
              );
              state.basket.push(mainItem);
            } else {
                console.log("wut");
                const indexPlus = state.basket.findIndex(
                    (product) => product.id === action.payload
                  );
                state.basket[indexPlus].count++;
            }
      
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
    const [state, dispatch] = useReducer(reduce, intialState);

    return (
        <Context.Provider value={{ state, dispatch }}>
            {children}
        </Context.Provider>
    );
}