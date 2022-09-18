import Button from "react-bootstrap/Button";
import Container from "react-bootstrap/Container";
import Form from "react-bootstrap/Form";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";

function NavBarExample() {
  return (
    <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark" sticky="top">
      <Container>
        <Navbar.Brand href="#home">React-Bootstrap</Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link className="fs-5" href="#features">
              Abonnements
            </Nav.Link>
            <Nav.Link className="fs-5" href="#pricing">
              Coaches
            </Nav.Link>
            <Nav.Link className="fs-5" href="#pricing">
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
  );
}

export default NavBarExample;
