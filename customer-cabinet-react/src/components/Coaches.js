import CoachesList from "./CoachesList";
export default function Coaches() {
  const coaches = [
    {
      firstName: "Vova",
      education: "Kpi",
    },
    {
      firstName: "Oleg",
      education: "Kpi",
    },
    {
      firstName: "Bohdan",
      education: "Kpi",
    },
  ];
  return <CoachesList coaches={coaches} />;
}
