import logo from "./logo.svg";
import "./App.css";
import Layout from "./components/Layout";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Abonements from "./components/Abonements";
import Coaches from "./components/Coaches";
import Home from "./components/Home";
import GroupTrainings from "./components/GroupTrainings";
function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/Abonements" element={<Abonements />} />
          <Route path="/Coaches" element={<Coaches />} />
          <Route path="/GroupTrainings" element={<GroupTrainings />} />
        </Routes>
      </Layout>
    </Router>
  );
}

export default App;
