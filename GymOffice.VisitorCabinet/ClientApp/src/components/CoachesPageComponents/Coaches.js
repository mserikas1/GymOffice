import Coach from "./Coach";
import axios from "axios";
import React, { useState, useEffect, useCallback } from "react";
export default function Coaches() {
  const [coaches, setCoaches] = useState([]);
  const url = 'coach/getactivecoaches';

  React.useEffect(() => {
    axios.get(url).then((response) => {
      const received = response.data;
      setCoaches(received);
    });
  }, []);
  return (
    <div className="row justify-content-between g-5 mb-3">
      {Array.isArray(coaches) ? (
        coaches.map((coach) => <Coach coach={coach} />)
      ) : (
        <h1></h1>
      )}
    </div>
  );
}
