import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:5001/activities').then((resp) => {
      setActivities(resp.data);
      console.log(resp);
    });
  }, []);

  return (
    <div>
      <Header as="h2" icon="users" content="Reactivities"></Header>
      <List>
        {activities.map((activity: any) => (
          <List.Item key={activity.id}>{activity.title}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
