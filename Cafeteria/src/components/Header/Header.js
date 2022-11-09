import React, { useContext } from 'react';
import "./Header.css";
import { Link } from "react-router-dom";
import { AiOutlineShopping } from "react-icons/ai";
import { Context } from "../Context/Context";

function Header() {
    const { state } = useContext(Context);

    return(
        <header className='header'>
            <nav className='nav'>
                <Link to={'/'} className='logo'></Link>
            </nav>
            <div className='icon_Sopping_box'>
                <Link to={"/basket"} className="shoppe_icon_box">
                    <AiOutlineShopping className="shop_icon" />
                    {state.basket.length > 0 && (
                    <span className="badge_shope">{state.basket.length}</span>
                    )}
                </Link>
            </div>
        </header>
    )
}

export default Header;