import "../../css/Abonnement.css";
import React, { useState, useEffect, useCallback } from "react";
import axios from "axios";
import useAuth from "../../hooks/useAuth";
import Abonnement from "./Abonnement";
import { useNavigate } from "react-router-dom";
export default function Abonnements() {
  const navigate = useNavigate();
  const { auth } = useAuth();
  const [abonnements, setAbonnements] = useState([]);
  const url = "abonnementtype/getactiveabonnementtypes";
  const request = async () => {
    try {
      const response = await axios.get(url, {
        headers: {
          Authorization: `Bearer ${auth.accessToken}`,
        },
      });
      setAbonnements(response.data);
    } catch (error) {
      if (error.response?.status === 401) {
        navigate("/Login");
      }
    }
  };
  React.useEffect(() => {
    request();
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
