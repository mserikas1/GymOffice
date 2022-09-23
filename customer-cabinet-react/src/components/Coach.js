import "../css/Coach.css";
import { Icon } from "@iconify/react";
export default function Coach(props) {
  return (
    <div className="col">
      <div className="coachCard">
        <div className="front">
          <figure className="snip1218">
            <div className="image">
              <img src={"img/" + props.coach.photoUrl} alt="sample80" />
            </div>
            <figcaption>
              <h3>
                {props.coach.firstName}
                <span> {props.coach.lastName}</span>
              </h3>
            </figcaption>
          </figure>
        </div>
        <div className="back">
          <div className="container">
            <div className="coachInfo">
              <div className="coachInfoItem">
                <Icon icon="mdi:school-outline" /> Degree of{" "}
                {props.coach.education}
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
      </div>
    </div>
  );
}
