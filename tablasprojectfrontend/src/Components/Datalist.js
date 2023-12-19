import React, { useState, useEffect } from 'react';
import Card from './Card';
import NewDataForm from './newData';
import NewCardForm from './newCard';

function DataList() {
  const [data, setData] = useState([]);
  /*const [cardData, setcardData] = useState([]);*/

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
/*
  useEffect(() => {
    fetch('https://localhost:7241/Card')
      .then(response => response.json())
      .then(data => {
        setcardData(data.result);
      })
      .catch(error => {
        console.error(error);
      });
  }, []);
*/
const handleDataAdded = (newData) => {
  setData(prevData => [...prevData, newData]);
};

const handleCardAdded = (newData) => {
  setData(prevData => [...prevData, newData]);
};

  return (
    <div>
      <div>
        <h1>Adat lista</h1>
      </div>
      <NewDataForm onDataAdded={handleDataAdded} />
      <NewCardForm onCardAdded={handleCardAdded} />
      {data.map(item => (
        <Card setCount={handleCount}  key={item.PersonalId} data={item} /*cardData={cardData}*/ />
      ))}
    </div>
  );
}

export default DataList;
