import PhotoCarousel from "./HomePageComponents/PhotoCarousel";
import Advantages from "./HomePageComponents/Advantages";
import AdvantagesTitle from "./HomePageComponents/AdvantagesTitle";
import Intro from "./HomePageComponents/Intro";
export default function Home(props) {
  return (
    <div className="container">
      <Intro />
      <PhotoCarousel />
      <AdvantagesTitle />
      <Advantages />
    </div>
  );
}
