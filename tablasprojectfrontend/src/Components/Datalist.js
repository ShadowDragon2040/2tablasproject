import React, { useState, useEffect } from 'react';
import Card from './Card';
import NewDataForm from './newData';
import NewCardForm from './newCard';
import { Heading } from '../AppElements';

function DataList() {
  const [data, setData] = useState([]);
  const [count,setCount] = useState(0);
  
  const handleCount = () => {
    setCount(count+1);
  }

  useEffect(() => {
    fetch('https://localhost:7241/PersonalData')
      .then(response => response.json())
      .then(data => {
        setData(data.result);
      })
      .catch(error => {
        console.error(error);
      });
  }, [count]);

const handleDataAdded = (newData) => {
  setData(prevData => [...prevData, newData]);
  handleCount();
};

const handleCardAdded = (newData) => {
  setData(prevData => [...prevData, newData]);
  handleCount();
};

  return (
    <div style={{padding: '100px'}}>
      <div style={{textAlign: 'center'}}>
        <Heading>Adat lista</Heading>
      </div>
        <NewDataForm onUpdate={handleCount} onDataAdded={handleDataAdded} />
        <NewCardForm onUpdate={handleCount} onCardAdded={handleCardAdded} />
      {data.map(item => (
        <Card  key={item.PersonalId} data={item} onUpdate={handleCount}/>
      ))}
    </div>
  );
}

export default DataList;
