export class CoachService {
  url = "http://localhost:5173/api/Coach";
  getCoaches() {
    return fetch(this.url + "/GetCoaches", {
      mode: "no-cors",
      method: "get",
      headers: new Headers({
        "Content-Type": "application/json",
      }),
    });
  }
}
