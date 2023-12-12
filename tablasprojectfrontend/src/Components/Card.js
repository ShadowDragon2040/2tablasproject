import React, { useState } from 'react';
import axios from 'axios';
import {
  CardWrapper,
  TextWrapper,
  Heading,
  DeleteButton,
  EditButton,
  CardsButton,
  Heading3
} from '../AppElements';
import Delete from './Delete';
import BankCard from './Bank Card';

function Card({ data }) {
  const [isEditing, setIsEditing] = useState(false);
  const [editedData, setEditedData] = useState({ ...data });
  const [showBankCard, setShowBankCard] = useState(false);
  const [bankCardData, setBankCardData] = useState(null);

  const handleDelete = () => {
    Delete(data.personalId);
  };

  const handleEdit = () => {
    setIsEditing(true);
  };

  const handleSaveChanges = () => {
    axios.put(`https://localhost:7241/PersonalData?id=${data.personalId}`, editedData)
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

  const handleCards = () => {
    setShowBankCard(!showBankCard);

    if (!showBankCard) {
      axios.get(`https://localhost:7241/PersonalData/BankCards/${data.cardIndexId}`)
        .then(response => {
          console.log('Card Data:', response.data);
          setBankCardData(response.data);
        })
        .catch(error => {
          console.error('Error getting card data:', error);
        });
    }
  };

  const handleChange = (e) => {
    setEditedData({
      ...editedData,
      [e.target.name]: e.target.value,
    });
  };

  return (
    <CardWrapper>
      <Heading3>Id number: {data.personalId}</Heading3>
      {isEditing ? (
        <>
          <TextWrapper>
            First Name:
            <input
              type="text"
              name="firstName"
              value={editedData.firstName}
              onChange={handleChange}
            />
          </TextWrapper>
          <TextWrapper>
            Last Name:
            <input
              type="text"
              name="lastName"
              value={editedData.lastName}
              onChange={handleChange}
            />
          </TextWrapper>
          <TextWrapper>
            Gender:
            <input
              type="text"
              name="gender"
              value={editedData.gender}
              onChange={handleChange}
            />
          </TextWrapper>
          <TextWrapper>
            Language:
            <input
              type="text"
              name="language"
              value={editedData.language}
              onChange={handleChange}
            />
          </TextWrapper>
        </>
      ) : (
        <>
          <Heading3>Card Holder Name:</Heading3>
          <Heading>{data.firstName} {data.lastName}</Heading>
          <TextWrapper>Gender: {data.gender}</TextWrapper>
          <TextWrapper>Language: {data.language}</TextWrapper>
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
          <CardsButton onClick={handleCards}>Cards</CardsButton>
        </>
      )}
      {showBankCard && bankCardData && <BankCard data={bankCardData} />}
    </CardWrapper>
  );
}

export default Card;
