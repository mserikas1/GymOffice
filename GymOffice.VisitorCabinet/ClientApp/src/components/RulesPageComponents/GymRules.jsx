import React, { useState, useEffect } from "react";
import Section from "./Section";
import axios from "axios";
import styles from './GymRules.module.css';

function GymRules() {
    const [sections, setSections] = useState([]);
    const url = "rules/sections";

    useEffect(() => {
        axios.get(url).then((response) => {
            const received = response.data;
            setSections(received);
        });
    }, []);

    return (
        <div className={styles.rules}>
            <h1 className={styles.header}>Gym Rules</h1>
            <ol>
                {Array.isArray(sections) ?
                    (sections.map((section) =>
                        <div className="m-5">
                            <li><h5>{section.name}</h5></li>
                            <Section section={section} />
                        </div>)
                    ) : (<h3>no rules</h3>)
                }
            </ol>
        </div >
    )
}

export default GymRules;