import { Container } from "react-bootstrap";
import NavBar from "./NavBar";
export default function Layout(props) {
  return (
    <div>
      <NavBar />
      <Container>{props.children}</Container>
    </div>
  );
}
