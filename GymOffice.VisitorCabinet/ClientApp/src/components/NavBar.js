import Button from "react-bootstrap/Button";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { Link } from "react-router-dom";
import useAuth from "../hooks/useAuth";
import Home from "./Home";
import { useNavigate, Routes, Route } from "react-router-dom";
export default function NavBar() {
  const navigate = useNavigate();
  const { auth, setAuth } = useAuth();
  const logout = () => {
    setAuth({});
    navigate("/");
  };
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
              <Nav.Link as={Link} className="fs-5" to="/Abonnements" href="#">
                Abonnements
              </Nav.Link>
              <Nav.Link as={Link} className="fs-5" to="/Coaches" href="">
                Coaches
              </Nav.Link>
            </Nav>
            {auth != undefined && auth.hasOwnProperty("email") ? (
              <Nav>
                <Nav.Link className="my-auto" href="">
                  <p className="my-auto fs-3 fw-semibold text-dark">
                    {"Hello " + auth.email}
                  </p>
                </Nav.Link>
                <Nav.Link href="">
                  <Button onClick={logout} variant="primary" size="lg">
                    Log Out
                  </Button>
                </Nav.Link>
              </Nav>
            ) : (
              <Nav>
                <Nav.Link as={Link} to="/Login" href="">
                  <Button variant="secondary" size="lg">
                    Login
                  </Button>
                </Nav.Link>
                <Nav.Link as={Link} to="/Register" href="">
                  <Button variant="primary" size="lg">
                    GetStarted
                  </Button>
                </Nav.Link>
              </Nav>
            )}
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </div>
  );
}
