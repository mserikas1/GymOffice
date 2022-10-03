import "../css/Login.css";
import { useRef, useState, useEffect } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import { Link } from "react-router-dom";
import { faEnvelope } from "@fortawesome/free-regular-svg-icons";
import RegistrationField from "./RegistrationField";
import {
  faUser,
  faLock,
  faR,
  faEye,
  faInfoCircle,
  faEyeSlash,
} from "@fortawesome/free-solid-svg-icons";
const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;
const pwdRegex =
  /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!"#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).{8,24}$/;
export default function Login() {
  library.add(faUser, faLock, faEyeSlash, faR);
  const emailRef = useRef();
  const errRef = useRef();

  const [email, setEmail] = useState("");
  const [validEmail, setValidEmail] = useState(false);
  const [emailFocus, setEmailFocus] = useState(false);

  const [pwd, setPwd] = useState("");
  const [pwdType, setPwdType] = useState("password");
  const [validPwd, setValidPwd] = useState(false);
  const [pwdFocus, setPwdFocus] = useState(false);

  const [errMsg, setErrMsg] = useState("");
  const [success, setSuccess] = useState(false);

  useEffect(() => {
    emailRef.current.focus();
  }, []);

  useEffect(() => {
    const result = emailRegex.test(email);
    console.log(result);
    console.log(email);
    setValidEmail(result);
  }, [email]);

  useEffect(() => {
    const result = pwdRegex.test(pwd);
    console.log(result);
    setValidPwd(result);
  }, [pwd]);

  useEffect(() => {
    setErrMsg("");
  }, [email]);
  const showPassword = (e) => {
    e.preventDefault();
    if (pwdType === "password") {
      setPwdType("text");
    } else {
      setPwdType("password");
    }
  };
  const handleSubmit = () => console.log("submit");
  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-sm-6">
          <div className="panel border bg-white">
            <p
              ref={errRef}
              className={errMsg ? "errmsg" : "offscreen"}
              aria-live="assertive"
            >
              {errMsg}
            </p>
            <div className="panel-heading">
              <h3 className="pt-3 font-weight-bold">Login</h3>
            </div>
            <div className="panel-body p-3">
              <form onSubmit={handleSubmit}>
                <div className="form-group py-2">
                  <div className="input-field">
                    <FontAwesomeIcon className="p-2" icon={faEnvelope} />
                    <input
                      type="text"
                      autoComplete="off"
                      ref={emailRef}
                      placeholder="Enter your Email"
                      required
                      aria-invalid={validEmail ? "false" : "true"}
                      onChange={(e) => setEmail(e.target.value)}
                      onFocus={() => setEmailFocus(true)}
                      onBlur={() => setEmailFocus(false)}
                    />
                  </div>
                </div>
                <p
                  className={
                    emailFocus && email && !validEmail ? "instructions" : "hide"
                  }
                >
                  <FontAwesomeIcon className="px-2" icon={faInfoCircle} />
                  Invalid format for email
                </p>
                <div className="form-group py-1 pb-2">
                  <div className="input-field">
                    <FontAwesomeIcon icon="lock" className="p-2" />
                    <input
                      type={pwdType}
                      autoComplete="off"
                      value={pwd}
                      placeholder="Enter your Password"
                      onChange={(e) => setPwd(e.target.value)}
                      onFocus={() => setPwdFocus(true)}
                      onBlur={() => setPwdFocus(false)}
                      required
                    />
                    <span className="pe-2" onClick={(e) => showPassword(e)}>
                      {pwdType === "password" ? (
                        <FontAwesomeIcon icon="eye-slash" />
                      ) : (
                        <FontAwesomeIcon icon={faEye} />
                      )}
                    </span>
                  </div>
                </div>
                <p
                  className={
                    pwdFocus && pwd && !validPwd ? "instructions" : "hide"
                  }
                >
                  <FontAwesomeIcon className="px-2" icon={faInfoCircle} />
                  {
                    "Password has to have at least one capital letter, small letter, number and special character.\nThe length from 8 to 24 characters."
                  }
                </p>
                <div
                  className={
                    validPwd && validEmail
                      ? "d-block btn btn-primary btn-block mt-3"
                      : "d-block btn btn-primary btn-block mt-3 disabled"
                  }
                >
                  Login
                </div>
                <div className="text-center pt-4 text-muted">
                  Don't have an account?
                  <Link to="/Register" href="#">
                    Sign up
                  </Link>
                </div>
              </form>
            </div>
            <div className="mx-3 my-2 py-2 bordert">
              <div className="text-center py-3">
                <a
                  href="https://wwww.facebook.com"
                  target="_blank"
                  className="px-2"
                >
                  <img
                    className="logo"
                    src="https://img.icons8.com/fluency/144/000000/facebook-new.png"
                  />
                </a>
                <a
                  href="https://www.google.com"
                  target="_blank"
                  className="px-2"
                >
                  <img
                    className="logo"
                    src="https://img.icons8.com/color/144/1A1A1A/google-logo.png"
                  />
                </a>
                <a
                  href="https://twitter.com/home"
                  target="_blank"
                  className="px-2"
                >
                  <img
                    className="logo"
                    src="https://img.icons8.com/color/144/000000/twitter-circled--v4.png"
                  />
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
