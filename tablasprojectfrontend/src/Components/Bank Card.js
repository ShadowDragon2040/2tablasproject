import { CardWrapper,TextWrapper,Heading, DeleteButton, EditButton,CardsButton,Heading3 } from '../AppElements';
import Delete from './Delete';
import React, { useState } from 'react';
import axios from 'axios';

function BankCard({ data }) {
  const [isEditing, setIsEditing] = useState(false);
  const [editedData, setEditedData] = useState({ ...data });

  const handleDelete = () => {
    Delete(data.personalId);
  };

  const handleEdit = () => {
    setIsEditing(true);
  };

  const handleSaveChanges = () => {
    axios.put(`https://localhost:7241/Card?id=${data.cardId}`, editedData)
      .then(response => {
        console.log('Data changed:', response.data);
        setIsEditing(false);
      })
      .catch(error => {
        console.error('Error changing data:', error);
      });
  };

  const handleCancel = () => {
    setIsEditing(false);
    setEditedData({ ...data });
  };

  const handleChange = (e) => {
    setEditedData({
      ...editedData,
      [e.target.name]: e.target.value,
    });
  };

  return (
    <CardWrapper>
      <Heading3>Id number: {data.cardId}</Heading3>
      {isEditing ? (
        <>
          <TextWrapper>
          Card Number:
            <input
              type="text"
              name="cardNumber"
              value={editedData.cardNumber}
              onChange={handleChange}
            />
          </TextWrapper>
          <TextWrapper>
          Card Type Name:
            <input
              type="text"
              name="cardTypeName"
              value={editedData.cardTypeName}
              onChange={handleChange}
            />
          </TextWrapper>
          <TextWrapper>
          Currency Name:
            <input
              type="text"
              name="currencyName"
              value={editedData.currencyName}
              onChange={handleChange}
            />
          </TextWrapper>
          <TextWrapper>
          Currency Ammount:
            <input
              type="text"
              name="currencyAmmount"
              value={editedData.currencyAmmount}
              onChange={handleChange}
            />
          </TextWrapper>
        </>
      ) : (
        <>
          <Heading3>Card Number:</Heading3>
          <Heading>{data.cardNumber}</Heading>
          <TextWrapper>Card Type Name: {data.cardTypeName}</TextWrapper>
          <TextWrapper>Currency Name: {data.currencyName}</TextWrapper>
          <TextWrapper>Currency Ammount: {data.currencyAmmount}</TextWrapper>
        </>
      )}
      {isEditing ? (
        <>
          <EditButton onClick={handleSaveChanges}>Save</EditButton>
          <CardsButton onClick={handleCancel}>Cancel</CardsButton>
        </>
      ) : (
        <>
          <DeleteButton onClick={handleDelete}>Delete</DeleteButton>
          <EditButton onClick={handleEdit}>Edit</EditButton>
        </>
      )}
    </CardWrapper>
  );
}

export default BankCard;
