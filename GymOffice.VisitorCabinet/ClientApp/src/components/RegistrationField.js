import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { BsFillXCircleFill, BsCheck2 } from "react-icons/bs";
import {
  faUser,
  faLock,
  faR,
  faEye,
  faInfoCircle,
  faEyeSlash,
} from "@fortawesome/free-solid-svg-icons";
export default function RegistrationField(props) {
  return (
    <div>
      <div className="input-field my-3">
        <FontAwesomeIcon icon={props.icon} className="p-2" />
        <input
          type={props.fieldType}
          autoComplete="off"
          placeholder={props.fieldName}
          required
          aria-invalid={props.validField ? "false" : "true"}
          onChange={(e) => props.setField(e.target.value)}
          onFocus={() => props.setFieldFocus(true)}
          onBlur={() => props.setFieldFocus(false)}
        />
        {props.children}
        {!props.validField ? (
          <BsFillXCircleFill className="fs-5 mx-3" style={{ color: "red" }} />
        ) : (
          <BsCheck2 className="fs-3 mx-2" style={{ color: "green" }} />
        )}
      </div>
      <p
        className={
          props.fieldValue && props.fieldFocus && !props.validField
            ? "instructions"
            : "hide"
        }
      >
        <FontAwesomeIcon className="px-2" icon={faInfoCircle} />
        {props.instruction}
      </p>
    </div>
  );
}
