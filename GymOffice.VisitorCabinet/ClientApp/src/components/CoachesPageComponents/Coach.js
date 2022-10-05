import "../../css/Coach.css";
import { Icon } from "@iconify/react";
export default function Coach(props) {
  return (
    <div className="col-xl-5">
      <div className="coachCard" style={{ height: "450px" }}>
        <div className="front card h-100">
          <img
            className="card-image-top"
            src={props.coach.photoUrl}
            alt=""
            style={{ height: "85%" }}
          />
          <div className="card-body">
            <h3 className="card-title text-uppercase ps-3 align-middle">
              {props.coach.firstName}
              <span className="fw-bold"> {props.coach.lastName}</span>
            </h3>
          </div>
        </div>
        <div className="back coachInfo h-100">
          <div className="coachInfoItem">
            <Icon icon="mdi:school-outline" /> Degree of {props.coach.education}
          </div>
          <div className="coachInfoItem">
            <Icon icon="fluent:ribbon-star-24-regular" /> Work experience: 5
            years
          </div>
          <div className="coachInfoItem">
            <Icon icon="fluent:person-note-24-regular" />{" "}
            {props.coach.description}
          </div>
        </div>
      </div>
    </div>
  );
}
