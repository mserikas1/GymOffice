import { useState, useRef, useEffect } from "react";
import "../css/Login.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import { BsFillXCircleFill, BsCheck2 } from "react-icons/bs";
import { Link } from "react-router-dom";
import RegistrationField from "./RegistrationField";
import { faEnvelope } from "@fortawesome/free-regular-svg-icons";
import {
  faUser,
  faLock,
  faR,
  faEye,
  faPhone,
  faInfoCircle,
  faEyeSlash,
} from "@fortawesome/free-solid-svg-icons";
const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;
const phoneNumberRegex = /^\+380[0-9]{9}$/;
const firstNameRegex = /^[A-z][A-z]{1,23}$/;
const lastNameRegex = /^[A-z][A-z]{1,23}$/;
const pwdRegex =
  /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!"#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).{8,24}$/;
export default function Register() {
  library.add(faUser, faLock, faEyeSlash, faR);
  const errRef = useRef();

  const [email, setEmail] = useState("");
  const [validEmail, setValidEmail] = useState(false);
  const [emailFocus, setEmailFocus] = useState(false);

  const [firstName, setFirstName] = useState("");
  const [validFirstName, setValidFirstName] = useState(false);
  const [firstNameFocus, setFirstNameFocus] = useState(false);

  const [lastName, setLastName] = useState("");
  const [validLastName, setValidLastName] = useState(false);
  const [lastNameFocus, setLastNameFocus] = useState(false);

  const [phoneNumber, setPhoneNumber] = useState("");
  const [validPhoneNumber, setValidPhoneNumber] = useState(false);
  const [phoneNumberFocus, setPhoneNumberFocus] = useState(false);

  const [pwd, setPwd] = useState("");
  const [validPwd, setValidPwd] = useState(false);
  const [pwdFocus, setPwdFocus] = useState(false);

  const [matchPwd, setMatchPwd] = useState("");
  const [validMatch, setValidMatch] = useState(false);
  const [matchFocus, setMatchFocus] = useState(false);

  const [pwdType, setPwdType] = useState("password");

  const [errMsg, setErrMsg] = useState("");
  const [success, setSuccess] = useState(false);

  const fieldValues = [email, firstName, lastName, phoneNumber];
  const fieldIcons = [faEnvelope, faUser, faUser, faPhone];
  const fieldNames = ["Email", "First name", "Last name", "Phone number"];
  const validsField = [
    validEmail,
    validFirstName,
    validLastName,
    validPhoneNumber,
  ];
  const setsField = [setEmail, setFirstName, setLastName, setPhoneNumber];
  const setsFieldFocus = [
    setEmailFocus,
    setFirstNameFocus,
    setLastNameFocus,
    setPhoneNumberFocus,
  ];
  const fieldFocuses = [
    emailFocus,
    firstNameFocus,
    lastNameFocus,
    phoneNumberFocus,
  ];
  const fieldInstructions = [
    "Invalid format for email",
    "First name has to start from capital or small letter",
    "Last name has to start from capital or small letter",
    "Phone number has to have format +380XXXXXXXXX",
  ];

  useEffect(() => {
    setValidEmail(emailRegex.test(email));
    setValidFirstName(firstNameRegex.test(firstName));
    setValidLastName(lastNameRegex.test(lastName));
    setValidPhoneNumber(phoneNumberRegex.test(phoneNumber));
  }, [email, firstName, lastName, phoneNumber]);

  useEffect(() => {
    const result = pwdRegex.test(pwd);
    console.log(result);
    setValidPwd(result);
    const match = pwd === matchPwd && matchPwd.length > 0;
    console.log(match);
    setValidMatch(match);
  }, [pwd, matchPwd]);

  useEffect(() => {
    setErrMsg("");
  }, [email, pwd, matchPwd]);
  const showPassword = () => {
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
              <h3 className="pt-3 font-weight-bold">Register</h3>
            </div>
            <div className="panel-body p-3">
              <form onSubmit={handleSubmit}>
                {fieldValues.map((fieldValue, index) => (
                  <RegistrationField
                    fieldType="text"
                    icon={fieldIcons[index]}
                    fieldValue={fieldValue}
                    fieldName={fieldNames[index]}
                    validField={validsField[index]}
                    setField={setsField[index]}
                    setFieldFocus={setsFieldFocus[index]}
                    fieldFocus={fieldFocuses[index]}
                    instruction={fieldInstructions[index]}
                  />
                ))}
                <RegistrationField
                  fieldType={pwdType}
                  icon={faLock}
                  fieldValue={pwd}
                  fieldName={"Password"}
                  validField={validPwd}
                  setField={setPwd}
                  setFieldFocus={setPwdFocus}
                  fieldFocus={setPwdFocus}
                  instruction={
                    "Password has to have at least one capital letter, small letter, number and special character.\nThe length from 8 to 24 characters. "
                  }
                >
                  <span onClick={showPassword}>
                    {pwdType === "password" ? (
                      <FontAwesomeIcon className="fs-6" icon="eye-slash" />
                    ) : (
                      <FontAwesomeIcon className="fs-6" icon={faEye} />
                    )}
                  </span>
                </RegistrationField>
                <RegistrationField
                  fieldType={pwdType}
                  icon={faLock}
                  fieldValue={matchPwd}
                  fieldName={"Confirm password"}
                  validField={validMatch}
                  setField={setMatchPwd}
                  setFieldFocus={setMatchFocus}
                  fieldFocus={matchFocus}
                  instruction={"Passwords are different"}
                />
                <div className="d-block btn btn-primary btn-block mt-3">
                  Register
                </div>
                <div className="text-center pt-4 text-muted">
                  Already registered?
                  <Link to="/Login" href="#">
                    Log in
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
