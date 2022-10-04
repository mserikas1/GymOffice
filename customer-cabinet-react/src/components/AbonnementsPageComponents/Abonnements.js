import "../../css/Abonnement.css";
import React, { useState, useEffect, useCallback } from "react";
import axios from "axios";
import useAuth from "../../hooks/useAuth";
import Abonnement from "./Abonnement";
export default function Abonnements() {
  const { auth } = useAuth();
  const [abonnements, setAbonnements] = useState([]);
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const url =
    "http://localhost:5173/api/AbonnementType/GetActiveAbonnementTypes";

  React.useEffect(() => {
    axios
      .get(url, {
        headers: {
          authorization: `${auth.accessToken}`,
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        const received = response.data;
        setAbonnements(received);
      });
  }, []);
  return (
    <div className="container">
      <div className="row justify-content-between g-5 mb-3">
        {abonnements.map((abonnement) => (
          <Abonnement
            name={abonnement.name}
            description={abonnement.description}
            startVisitTime={abonnement.startVisitTime}
            endVisitTime={abonnement.endVisitTime}
            minPrice={Math.min(...Object.values(abonnement.pricesPerDurs))}
            pricesPerDurs={abonnement.pricesPerDurs}
          />
        ))}
      </div>
    </div>
  );
}
