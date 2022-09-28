import "../../css/Abonnement.css";
import React, { useState, useEffect, useCallback } from "react";
import axios from "axios";
import Abonnement from "./Abonnement";
export default function Abonnements() {
  const [abonnements, setAbonnements] = useState([]);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const url =
    "http://localhost:5173/api/AbonnementType/GetActiveAbonnementTypes";

  React.useEffect(() => {
    axios.get(url).then((response) => {
      const received = response.data;
      setAbonnements(received);
    });
  }, []);
  return (
    <div className="container">
      <div className="row row-cols-1 row-cols-md-3 g-4 mt-4">
        {abonnements.map((abonnement) => (
          <Abonnement
            name={abonnement.name}
            description={abonnement.description}
            startVisitTime={abonnement.startVisitTime}
            endVisitTime={abonnement.endVisitTime}
            minPrice={abonnement.minPrice}
          />
        ))}
      </div>
    </div>
  );
}
