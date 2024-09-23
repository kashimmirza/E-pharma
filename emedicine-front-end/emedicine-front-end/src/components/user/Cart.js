/** @format */

// src/components/Cart.js
import React, { useState, useEffect } from "react";
import axios from "axios";
import "../styles/Cart.css"; // Importing the CSS file
import emptycart from "../../assets/images.jpeg";

const Cart = ({ handleProceedToCheckout }) => {
 const [cartDetails, setCartDetails] = useState({
  totalProducts: 0,
  totalPrice: 0,
 });

 useEffect(() => {
  fetchCartDetails();
 }, []);

 const fetchCartDetails = async () => {
  try {
   const userId = 1; // Change this to dynamically retrieve user ID as needed
   const response = await axios.get(`/api/medicine/getCartDetails/${userId}`);
   setCartDetails(response.data);
  } catch (error) {
   console.error("Error fetching cart details:", error);
  }
 };

 return (
  <div className="drawer-content-wrapper">
   <div className="drawer-content">
    <div className="flex flex-col justify-between w-full h-full">
     {/* Cart Header */}
     <div className="relative flex items-center justify-between w-full border-b ltr:pl-5 rtl:pr-5 md:ltr:pl-7 md:rtl:pr-7 border-border-base">
      <h3 className="text-brand-dark font-semibold text-xl">
       Medicine Cart
       <button className="lazy-felix-download-btn" data-name="Cart">
        <svg
         xmlns="http://www.w3.org/2000/svg"
         className="lazyfelix-icon"
         width="27"
         height="25"
         viewBox="0 0 27 25"
         fill="none"
        >
         {/* Cart icon SVG paths */}
         <path
          d="M13.4518 13.0377C11.4186 12.7365 6.4864 16.878 5.39453 21.7726V22.0362C5.48795 24.1899 7.75902 24.9194 10.9292 24.0316C13.0111 23.1639 14.1728 23.1375 16.125 24.0316C17.9698 25.1612 20.41 23.7051 20.643 22.0362C20.3191 18.4517 16.3154 13.1956 13.4518 13.0377Z"
          fill="#7A7A7A"
          fill-opacity="0.7"
         ></path>
         <ellipse
          cx="4.85476"
          cy="11.946"
          rx="2.97265"
          ry="4.24369"
          transform="rotate(-21.5283 4.85476 11.946)"
          fill="#7A7A7A"
          fill-opacity="0.7"
         ></ellipse>
         <ellipse
          cx="22.0599"
          cy="13.5489"
          rx="2.97265"
          ry="4.24369"
          transform="rotate(22.9527 22.0599 13.5489)"
          fill="#7A7A7A"
          fill-opacity="0.7"
         ></ellipse>
         <ellipse
          cx="10.1354"
          cy="5.66514"
          rx="2.92739"
          ry="4.7215"
          transform="rotate(-9.76985 10.1354 5.66514)"
          fill="#7A7A7A"
          fill-opacity="0.7"
         ></ellipse>
         <ellipse
          cx="17.552"
          cy="5.95842"
          rx="2.92739"
          ry="4.7215"
          transform="rotate(14.6303 17.552 5.95842)"
          fill="#7A7A7A"
          fill-opacity="0.7"
         ></ellipse>
        </svg>
       </button>
      </h3>
      <div className="flex items-center">
       <button className="close-button" aria-label="close">
        <svg
         stroke="currentColor"
         fill="currentColor"
         strokeWidth="0"
         viewBox="0 0 512 512"
         height="1em"
         width="1em"
         xmlns="http://www.w3.org/2000/svg"
        >
         <path d="m289.94 256 95-95A24 24 0 0 0 351 127l-95 95-95-95a24 24 0 0 0-34 34l95 95-95 95a24 24 0 1 0 34 34l95-95 95 95a24 24 0 0 0 34-34z"></path>
        </svg>
       </button>
      </div>
     </div>

     {/* Cart Body */}
     {cartDetails.totalProducts === 0 ? (
      <div className="cart-empty-content px-5 md:px-7 pt-8 pb-5 flex justify-center flex-col items-center">
       <div className="flex mx-auto w-[220px] md:w-auto">
        <img src={emptycart} alt="Empty Cart" className="empty-cart-image" />
       </div>
      </div>
     ) : (
      <div className="cart-content px-5 md:px-7 pt-8 pb-5">
       <p>Total Products: {cartDetails.totalProducts}</p>
       <p>Total Price: ${cartDetails.totalPrice}</p>
       <button onClick={handleProceedToCheckout} className="checkout-button">
        Proceed to Checkout
       </button>
      </div>
     )}

     {/* Footer */}
     <div className="back-to-main px-5 pt-5 pb-5 md:px-7 md:pt-6 md:pb-6">
      <button className="btn-main-page">Back to main page</button>
     </div>
    </div>
   </div>
  </div>
 );
};

export default Cart;
