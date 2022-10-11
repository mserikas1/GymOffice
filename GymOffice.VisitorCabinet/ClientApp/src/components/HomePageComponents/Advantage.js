export default function Advantage(props) {
  let imgClass = "img-fluid";
  if (props.index % 2) {
    imgClass += " rounded-bottom";
  } else {
    imgClass += " rounded-top";
  }
  const body = (
    <div className="col-sm-9">
      <div className="card-body">
        <h5 className="card-title fs-1">{props.title}</h5>
        <p className="card-text fs-3">{props.description}</p>
      </div>
    </div>
  );
  const img = (
    <div className={"col-sm-3"}>
      <img src={props.photoUrl} className={imgClass} alt="..." />
    </div>
  );
  return (
    <div className="card mb-3 p-0">
      <div className="row no-gutters">
        {props.index % 2 ? body : img}
        {props.index % 2 ? img : body}
      </div>
    </div>
  );
}
