import Coach from "./Coach";
import "../css/Coach.css";
export default function CoachesList(props) {
  return (
    <div class="row row-cols-1 row-cols-md-3 g-4">
      {props.coaches.map((coach) => (
        <Coach coach={coach} />
      ))}
    </div>
  );
}
