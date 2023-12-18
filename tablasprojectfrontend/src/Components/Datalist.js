import React, { useState, useEffect } from 'react';
import Card from './Card';

function DataList() {
  const [data, setData] = useState([]);
  /*const [cardData, setcardData] = useState([]);*/

  useEffect(() => {
    fetch('https://localhost:7241/PersonalData')
      .then(response => response.json())
      .then(data => {
        setData(data.result);
      })
      .catch(error => {
        console.error(error);
      });
  }, []);
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
  return (
    <div>
      <div>
        <h1>Adat lista</h1>
      </div>
      {data.map(item => (
        <Card key={item.PersonalId} data={item} /*cardData={cardData}*/ />
      ))}
    </div>
  );
}

export default DataList;
