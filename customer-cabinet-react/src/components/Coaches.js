import Coach from "./Coach";
import axios from "axios";
import React, { useState, useEffect, useCallback } from "react";
import { CoachService } from "../services/CoachService";
export default function Coaches() {
  const service = new CoachService();
  const [coaches, setCoaches] = useState([]);
  const url = "http://localhost:5173/api/Coach/GetCoaches";

  React.useEffect(() => {
    axios.get(url).then((response) => {
      const received = response.data;
      setCoaches(received);
    });
  }, []);
  return (
    <div class="row row-cols-1 row-cols-md-3 g-4">
      {Array.isArray(coaches) ? (
        coaches.map((coach) => <Coach coach={coach} />)
      ) : (
        <h1></h1>
      )}
    </div>
  );
}
