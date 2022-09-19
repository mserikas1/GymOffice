import PhotoCarousel from "./PhotoCarousel";
import Advantages from "./Advantages";
import AdvantagesTitle from "./AdvantagesTitle";
export default function Home(props) {
  return (
    <div>
      <PhotoCarousel />
      <AdvantagesTitle />
      <Advantages />
    </div>
  );
}
