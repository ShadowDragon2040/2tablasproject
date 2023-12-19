import React, { useState } from 'react';
import axios from 'axios';
import { TextWrapper,CardWrapper, CardsButton } from '../AppElements';

function NewDataForm({ onDataAdded }) {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    gender: '',
    language: '',
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    axios.post('https://localhost:7241/PersonalData', formData)
      .then(response => {
        console.log('New data added:', response.data);
        onDataAdded(response.data);
        setFormData({
          firstName: '',
          lastName: '',
          gender: '',
          language: '',
        });
      })
      .catch(error => {
        console.error('Error adding new data:', error);
      });
  };

  return (
    <CardWrapper>
        <TextWrapper>Új személy felvétele:</TextWrapper>
        <form onSubmit={handleSubmit}>
        <TextWrapper>
            First Name:
            <input
            type="text"
            name="firstName"
            value={formData.firstName}
            onChange={handleChange}
            required
            />
        </TextWrapper>
        <TextWrapper>
            Last Name:
            <input
            type="text"
            name="lastName"
            value={formData.lastName}
            onChange={handleChange}
            required
            />
        </TextWrapper>
        <TextWrapper>
            Gender:
            <input
            type="text"
            name="gender"
            value={formData.gender}
            onChange={handleChange}
            required
            />
        </TextWrapper>
        <TextWrapper>
            Language:
            <input
            type="text"
            name="language"
            value={formData.language}
            onChange={handleChange}
            required
            />
        </TextWrapper>
        <TextWrapper>
            Card index id:
            <input
            type="text"
            name="cardIndexId"
            value={formData.cardIndexId}
            onChange={handleChange}
            required
            />
        </TextWrapper>
        <CardsButton type="submit">Add Data</CardsButton>
        </form>
    </CardWrapper>
  );
}

export default NewDataForm;
