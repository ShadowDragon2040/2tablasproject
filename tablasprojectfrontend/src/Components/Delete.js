import axios from 'axios';

function Delete(id) {
  axios.delete(`https://localhost:7241/PersonalData?id=${id}`)
    .then(response => {
      console.log('Data deleted:', response.data);
    })
    .catch(error => {
      console.error('Error deleting data:', error);
    });
    id.setCount();
}

export default Delete;