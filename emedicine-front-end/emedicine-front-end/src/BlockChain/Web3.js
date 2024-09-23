/** @format */

import React, { useState } from "react";
import Web3 from "web3";

const web3 = new Web3(Web3.givenProvider);
const contractABI = []; // Replace with your contract ABI
const contractAddress = "your_contract_address";

const contract = new web3.eth.Contract(contractABI, contractAddress);

const BlockchainTransaction = () => {
 const [transactionHash, setTransactionHash] = useState("");
 const [status, setStatus] = useState("");

 const recordTransaction = async () => {
  try {
   const accounts = await web3.eth.getAccounts();
   await contract.methods
    .recordTransaction(transactionHash)
    .send({ from: accounts[0] });
   setStatus("Transaction recorded successfully.");
  } catch (error) {
   setStatus("Error recording transaction.");
  }
 };

 const fetchTransaction = async () => {
  try {
   const result = await contract.methods.getTransaction(transactionHash).call();
   setStatus(`Transaction recorded by ${result[0]} at ${result[1]}`);
  } catch (error) {
   setStatus("Error fetching transaction.");
  }
 };

 return (
  <div>
   <input
    type="text"
    value={transactionHash}
    onChange={(e) => setTransactionHash(e.target.value)}
    placeholder="Transaction Hash"
   />
   <button onClick={recordTransaction}>Record Transaction</button>
   <button onClick={fetchTransaction}>Fetch Transaction</button>
   <p>{status}</p>
  </div>
 );
};

export default BlockchainTransaction;
