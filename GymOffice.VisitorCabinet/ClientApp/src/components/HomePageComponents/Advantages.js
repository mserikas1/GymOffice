import Advantage from "./Advantage";
import axios from "axios";
import React, { useState, useEffect } from "react";
export default function Advantages() {
  const [advantages, setAdvantages] = useState([]);
  const url = "advantage/getadvantages";

  React.useEffect(() => {
    axios.get(url).then((response) => {
      const received = response.data;
      setAdvantages(received);
    });
  }, []);
  return (
    <div className="row">
      {advantages.map((advantage, index) => (
        <Advantage
          title={advantage.title}
          description={advantage.description}
          photoUrl={advantage.photoUrl}
          index={index}
        />
      ))}
    </div>
  );
}
