import { BsCartPlus, BsInfoLg } from "react-icons/bs";
import Option from "./Option";
export default function Abonnement(props) {
  let keys = [];
  if (props.hasOwnProperty("pricesPerDurs")) {
    keys = Object.keys(props.pricesPerDurs);
  }

  return (
    <div className="col-xl-5 position-relative">
      <div className="card abonnementCard">
        <img
          src="img/backGym2.jpg"
          className="card-img position-absolute overflow-hidden opacity-50"
        />
        <div className="inside">
          <div className="icon fs-3" style={{ top: "3px", right: "13px" }}>
            <BsInfoLg />
          </div>
          <div className="contents d-flex flex-column justify-content-around">
            {keys.map((key) => (
              <Option duration={key} price={props.pricesPerDurs[key]} />
            ))}
          </div>
        </div>
        <div className="card-body position-relative card-img-overlay d-flex flex-column justify-content-between">
          <div className="">
            <h1 className="text-center card-title">{props.name}</h1>
            <h4 className="text-primary text-center">
              {props.startVisitTime + "-" + props.endVisitTime}
            </h4>
            <div className="pt-2 ps-5 fs-3 fw-semibold ">starts from</div>
            <div className="fw-bold text-success">
              <h1 className="price text-center">{props.minPrice + "$"}</h1>
            </div>
          </div>
          <div className="description card-text fs-3 fw-semibold">
            <p>{props.description}</p>
          </div>
          <div className="button d-grid">
            <a className="btn fs-4 btn-outline-danger btn-block">
              <BsCartPlus /> Buy
            </a>
          </div>
        </div>
      </div>
    </div>
  );
}
