import Coach from "../CoachesPageComponents/Coach";
import axios from "axios";
import React, { useState, useEffect, useCallback } from "react";

function Coaches() {
    const [coaches, setCoaches] = useState([]);
    const url = "coach/getactivecoaches";

    useEffect(() => {
        axios.get(url).then((response) => {
            const received = response.data;
            setCoaches(received);
        });
    }, []);
    return (
        <div className="row  mb-3">
            {Array.isArray(coaches) ? (
                coaches.map((coach) => <Coach coach={coach} />)
            ) : (
                <h1></h1>
            )}
        </div>
    );
}

export default Coaches;