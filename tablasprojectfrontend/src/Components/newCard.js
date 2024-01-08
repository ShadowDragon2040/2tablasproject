import React, { useState } from 'react';
import axios from 'axios';
import { TextWrapper, CardWrapper3, CardsButton2, Heading3 } from '../AppElements';

function NewCardForm({ onDataAdded, onUpdate }) {
  const [formData, setFormData] = useState({
    cardNumber: '',
    cardTypeName: '',
    currencyName: '',
    currencyAmmount: '',
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.post('https://localhost:7241/Card', formData)
      .then(response => {
        console.log('New card added:', response.data);
        if (onDataAdded) {
          onDataAdded(response.data);
        }
        setFormData({
          cardNumber: '',
          cardTypeName: '',
          currencyName: '',
          currencyAmmount: '',
        });
      })
      .catch(error => {
        console.error('Error adding new card:', error);
      });
      onUpdate();
  };

  return (
    <CardWrapper3>
      <Heading3 style={{textAlign:"center"}}>Új kártya felvétele:</Heading3>
      <form onSubmit={handleSubmit}>
        <TextWrapper>
          Card number:   
          <input
            type="text"
            name="cardNumber"
            value={formData.cardNumber}
            onChange={handleChange}
            required
          />
        </TextWrapper>
        <TextWrapper>
          Card type name:
          <input
            type="text"
            name="cardTypeName"
            value={formData.cardTypeName}
            onChange={handleChange}
            required
          />
        </TextWrapper>
        <TextWrapper>
          Currency name:
          <input
            type="text"
            name="currencyName"
            value={formData.currencyName}
            onChange={handleChange}
            required
          />
        </TextWrapper>
        <TextWrapper>
          Currency amount:
          <input
            type="text"
            name="currencyAmmount"
            value={formData.currencyAmmount}
            onChange={handleChange}
            required
          />
        </TextWrapper>
        <CardsButton2 type="submit">Add Card</CardsButton2>
      </form>
    </CardWrapper3>
  );
}

export default NewCardForm;
