import { BsArrowRight } from "react-icons/bs";
import { faArrowRight } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
export default function Option(props) {
  const duration = props.duration;
  return (
    <div className="d-flex text-center fs-3 flex-row justify-content-around">
      <div className="text-black" style={{ width: "45%" }}>
        {duration == 1 ? `${duration} month` : `${duration} months`}
      </div>
      <div style={{ width: "25%" }}>
        <FontAwesomeIcon icon={faArrowRight} />
      </div>
      <div className="text-success fw-bold" style={{ width: "30%" }}>
        {props.price}$
      </div>
    </div>
  );
}
