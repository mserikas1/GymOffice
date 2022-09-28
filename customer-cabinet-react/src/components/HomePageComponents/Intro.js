import "../../css/Intro.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { useState } from "react";
import { Link } from "react-router-dom";
import Abonnements from "../AbonnementsPageComponents/Abonnements";
export default function Intro(params) {
  const [btnClass, setBtnClass] = useState("btn btn-danger btn-lg");
  const checkPhoneSize = () =>
    window.innerHeight <= 500
      ? setBtnClass("btn btn-danger")
      : setBtnClass("btn btn-danger btn-lg");
  window.addEventListener("resize", checkPhoneSize);
  return (
    <div className="intro row justify-content-evenly align-items-center">
      <div className="introText col-5 text-white text-center">
        <p className="title">Come Improve With Us</p>
        <p>
          We have programs for all levels of ability, and coaches and mentors in
          place to help you
        </p>
        <Link to="/Abonnements" className={btnClass}>
          View abonnements
        </Link>
      </div>
      <div className="introImage col-5 h-75 text-center">
        <img src="img/JohnCenaRunning.png" />
      </div>
      <Routes>
        <Route path="/Abonnements" element={<Abonnements />} />
      </Routes>
    </div>
  );
}
