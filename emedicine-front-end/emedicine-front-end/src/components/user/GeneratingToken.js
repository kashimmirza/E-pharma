/** @format */

import React, { useState } from "react";
import axios from "axios";

const GenerateToken = () => {
 const [phoneNumber, setPhoneNumber] = useState("");
 const [email, setEmail] = useState("");
 const [message, setMessage] = useState("");

 const handleGenerateToken = async () => {
  try {
   const response = await axios.post("/api/token/generate", {
    phoneNumber,
    email,
   });
   setMessage(`Token sent to your ${phoneNumber ? "phone" : "email"}.`);
  } catch (error) {
   setMessage("An error occurred.");
  }
 };

 return (
  <div>
   <input
    type="text"
    value={phoneNumber}
    onChange={(e) => setPhoneNumber(e.target.value)}
    placeholder="Phone number"
   />
   <input
    type="email"
    value={email}
    onChange={(e) => setEmail(e.target.value)}
    placeholder="Email"
   />
   <button onClick={handleGenerateToken}>Send Token</button>
   <p>{message}</p>
  </div>
 );
};

export default GenerateToken;
