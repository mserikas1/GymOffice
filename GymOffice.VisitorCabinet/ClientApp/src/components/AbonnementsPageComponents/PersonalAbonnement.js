export default function PersonalAbonnement(props) {
  return (
    <div>
      <div class="container-text">My Abonnements</div>
      <div class="row row-cols-1 row-cols-md-3 g-4 mt-3">
        <div class="col">
          <div class="card">
            <div class="card-body">
              <h3 class="card-title">Abonnement 1</h3>
              <h5 className="text-primary" style={{ marginLeft: "25%" }}>
                11:00-17:00
              </h5>
              <p class="card-text">Abonnement 1 descripion</p>
              <h5 className="card-text">
                <span className="text-danger">Expiration date:</span> 10.05
              </h5>
            </div>
          </div>
        </div>
      </div>
      <div class="divider">
        {" "}
        <span></span>
      </div>
    </div>
  );
}
