import React, {useEffect, useState} from 'react';
import {Link, NavLink} from "react-router-dom";
import Register from '/Users/danilalatyrev/Desktop/ForProjects/reactLearn/reactlearn/src/pages/RegisterPage.jsx'
import Login from '/Users/danilalatyrev/Desktop/ForProjects/reactLearn/reactlearn/src/pages/LoginPage.jsx'
import Home from "/Users/danilalatyrev/Desktop/ForProjects/reactLearn/reactlearn/src/pages/HomePage.jsx";

const NavigateHeader = (props) => {
    const logout = async () => {
        await fetch('http://localhost:5169/api/Authificate/logout', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include',
        });

        props.setName('');
    }
    
    
    let menu;

    if (props.name == undefined) {
        menu = (
            <header>
                    <NavLink to="/login">Login</NavLink>
                    <NavLink to="/register">register</NavLink>
                <NavLink to="/">home</NavLink>
            </header>
        );
    } else {
        menu = (
            <header>
                    <NavLink to="/">home</NavLink>
                    <Link to="/login" className="nav-link" onClick={logout}>Logout</Link>
            </header>
        )
    }

    return (
        <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
            <div className="container-fluid">
                <div>
                    {menu}
                </div>
            </div>
        </nav>
    );
};

export default NavigateHeader;
