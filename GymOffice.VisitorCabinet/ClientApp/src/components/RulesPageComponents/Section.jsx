import React, { useState, useEffect } from "react";
import axios from "axios";

function Section(props) {
    const [rules, setRules] = useState([]);
    const url = "rules/rulesbysection/" + props.section.id

    useEffect(() => {
        axios.get(url).then((response) => {
            const received = response.data;
            setRules(received);
        });
    }, []);

    return (
        <ul>
            {Array.isArray(rules) ?
                (rules.map((rule) => <li>{rule.description}</li>)) :
                (<h3>no rules</h3>)
            }
        </ul>
    )
}

export default Section;