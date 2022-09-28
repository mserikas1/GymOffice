import { BsCartPlus } from "react-icons/bs";
export default function Abonnement(props) {
  return (
    <div className="col">
      <div className="card">
        <div className="card-body">
          <h1 className="text-center card-title">{props.name}</h1>
          <h4 className="text-primary text-center">
            {props.startVisitTime + "-" + props.endVisitTime}
          </h4>
          <div className="pt-2 ps-5">from</div>
          <div className="fw-bold text-success">
            <h1 className="price text-center">{props.minPrice + "$"}</h1>
          </div>
          <p className="card-text fs-3">{props.description}</p>
          <div className="d-grid">
            <a className="btn fs-4 btn-outline-danger btn-block">
              <BsCartPlus /> Buy
            </a>
          </div>
          <div className="text-center"></div>
        </div>
      </div>
    </div>
  );
}
