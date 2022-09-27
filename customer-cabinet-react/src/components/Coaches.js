import Coach from "./Coach";
import axios from "axios";
import React, { useState, useEffect, useCallback } from "react";
export default function Coaches() {
  const [coaches, setCoaches] = useState([]);
  const url = "http://localhost:5173/api/Coach/GetActiveCoaches";

  React.useEffect(() => {
    axios.get(url).then((response) => {
      const received = response.data;
      setCoaches(received);
    });
  }, []);
  return (
    <div class="row">
      {Array.isArray(coaches) ? (
        coaches.map((coach) => <Coach coach={coach} />)
      ) : (
        <h1></h1>
      )}
    </div>
  );
}
