import React from 'react';
import { CardWrapper,TextWrapper,Heading, DeleteButton, EditButton,CardsButton,Heading3 } from '../AppElements';
import Delete from './Delete';

function BankCard({ data }) {

  const handleDelete = () => {
    Delete(data.cardId)
  };

  return (
    <CardWrapper className='card'>
        <Heading3>{data.cardId}</Heading3>
        <Heading>Card number:{data.cardNumber}</Heading>
        <TextWrapper>Card type:{data.cardTypeName}</TextWrapper>
        <TextWrapper>Currency name: {data.currencyName}</TextWrapper>
        <TextWrapper>Currency ammount: {data.currencyAmmount}</TextWrapper>
        <DeleteButton onClick={handleDelete}>Delete</DeleteButton>
        <EditButton>Edit</EditButton>
        <CardsButton>Cards</CardsButton>
    </CardWrapper>
  );
}

export default BankCard;
