import Advantage from "./Advantage";
export default function Advantages() {
  const advantages = [
    {
      name: "Advantage1",
      description: "Description to advantage 1",
      nameOfSign: "coachThumbUp.jpg",
    },
    {
      name: "Advantage2",
      description: "Description to advantage 2",
      nameOfSign: "increase.jpg",
    },
    {
      name: "Advantage3",
      description: "Description to advantage 3",
      nameOfSign: "phoneAtGym.jpg",
    },
  ];
  return (
    <div className="row">
      {advantages.map((advantage, index) => (
        <Advantage
          name={advantage.name}
          description={advantage.description}
          nameOfSign={advantage.nameOfSign}
          index={index}
        />
      ))}
    </div>
  );
}
