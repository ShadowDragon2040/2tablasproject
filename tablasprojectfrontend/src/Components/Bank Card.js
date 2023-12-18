import { CardWrapper2,TextWrapper,Heading, DeleteButton, EditButton,CardsButton,Heading3 } from '../AppElements';
import Delete from './Delete';
import React, { useState } from 'react';
import axios from 'axios';

function BankCard(props) {

  const [isEditing, setIsEditing] = useState(false);
  const [editedData, setEditedData] = useState({ ...props });


  const handleDelete = () => {
    Delete(props.data[0].cardId);
  };

  const handleEdit = () => {
    setIsEditing(true);
  };

  const handleSaveChanges = () => {
    axios.put(`https://localhost:7241/Card?id=${props.data[0].cardId}`, editedData)
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
    setEditedData({ ...props });
  };

  const handleChange = (e) => {
    setEditedData({
      ...editedData,
      [e.target.name]: e.target.value,
    });
  };

  return (
    <CardWrapper2>
      <Heading3>Card id number: {props.data[0].cardId}</Heading3>
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
          Currency Amount:
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
          <Heading>{props.data[0].cardNumber}</Heading>
          <TextWrapper>Card Type Name: {props.data[0].cardTypeName}</TextWrapper>
          <TextWrapper>Currency Name: {props.data[0].currencyName}</TextWrapper>
          <TextWrapper>Currency Ammount: {props.data[0].currencyAmmount}</TextWrapper>
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
    </CardWrapper2>
  );
}

export default BankCard;
