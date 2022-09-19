import "../css/Advantages.css";
export default function Advantages() {
  return (
    <div className="container">
      <div className="card-group vgr-cards">
        <div className="card">
          <div className="card-img-body">
            <img
              className="card-img"
              src="https://picsum.photos/500/230"
              alt="Card image cap"
            />
          </div>
          <div className="card-body">
            <h3 className="card-title">Advantage 1</h3>
            <p className="card-text">Descripion to advantage 1</p>
          </div>
        </div>
        <div className="card">
          <div className="card-img-body">
            <img
              className="card-img"
              src="https://picsum.photos/400/200"
              alt="Card image cap"
            />
          </div>
          <div className="card-body">
            <h3 className="card-title">Advantage 2</h3>
            <p className="card-text">Descripion to advantage 2</p>
          </div>
        </div>
        <div className="card">
          <div className="card-img-body">
            <img
              className="card-img"
              src="https://picsum.photos/450/250"
              alt="Card image cap"
            />
          </div>
          <div className="card-body">
            <h3 className="card-title">Advantage 3</h3>
            <p className="card-text">Descripion to advantage 3</p>
          </div>
        </div>
      </div>
    </div>
  );
}
