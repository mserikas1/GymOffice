import Layout from "./components/Layout";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Abonnements from "./components/AbonnementsPageComponents/Abonnements";
import Coaches from "./components/CoachesPageComponents/Coaches";
import Rules from "./components/RulesPageComponents/Rules";
import Home from "./components/Home";
import GroupTrainings from "./components/GroupTrainings";
import Login from "./components/Login";
import Register from "./components/Register";

function App() {
    return (
        <Router>
            <Layout>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/Abonnements" element={<Abonnements />} />
                    <Route path="/Coaches" element={<Coaches />} />
                    <Route path="/Rules" element={<Rules />} />
                    <Route path="/GroupTrainings" element={<GroupTrainings />} />
                    <Route path="/Register" element={<Register />} />
                    <Route path="/Login" element={<Login />} />
                </Routes>
            </Layout>
        </Router>
    );
}

export default App;

