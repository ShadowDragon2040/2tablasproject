import React, { useState, useEffect } from 'react';
import Card from './Card';
import NewDataForm from './newData';
import NewCardForm from './newCard';

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
  }, [data.count]);

const handleDataAdded = (newData) => {
  setData(prevData => [...prevData, newData]);
  handleCount();
};

const handleCardAdded = (newData) => {
  setData(prevData => [...prevData, newData]);
  handleCount();
};

  return (
    <div>
      <div style={{textAlign: 'center'}}>
        <h1>Adat lista</h1>
      </div>
        <NewDataForm onDataAdded={handleDataAdded} />
        <NewCardForm onCardAdded={handleCardAdded} />
      {data.map(item => (
        <Card setCount={handleCount}  key={item.PersonalId} data={item} onUpdate={handleCount}/>
      ))}
    </div>
  );
}

export default DataList;
