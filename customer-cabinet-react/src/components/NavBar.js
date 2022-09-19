import Button from "react-bootstrap/Button";
import Container from "react-bootstrap/Container";
import Form from "react-bootstrap/Form";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import { Link } from "react-router-dom";
export default function NavBar() {
  return (
    <div>
      <Navbar collapseOnSelect expand="lg" bg="warning" sticky="top">
        <Container fluid>
          <Navbar.Brand as={Link} to="/" className="fs-5">
            Home
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link as={Link} className="fs-5" to="/Abonements" href="#">
                Abonnements
              </Nav.Link>
              <Nav.Link as={Link} className="fs-5" to="/Coaches" href="">
                Coaches
              </Nav.Link>
              <Nav.Link as={Link} className="fs-5" to="/GroupTrainings" href="">
                Group Trainings
              </Nav.Link>
            </Nav>
            <Nav>
              <Nav.Link href="#deets">
                <Button variant="secondary" size="lg">
                  Log In
                </Button>{" "}
              </Nav.Link>
              <Nav.Link href="#memes">
                <Button variant="primary" size="lg">
                  GetStarted
                </Button>{" "}
              </Nav.Link>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </div>
  );
}
