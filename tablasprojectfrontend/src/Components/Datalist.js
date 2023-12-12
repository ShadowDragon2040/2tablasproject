import React, { useState, useEffect } from 'react';
import Card from './Card';

function DataList() {
  const [data, setData] = useState([]);

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

  return (
    <div>
      {data.map(item => (
        <Card key={item.PersonalId} data={item} />
      ))}
    </div>
  );
}

export default DataList;
