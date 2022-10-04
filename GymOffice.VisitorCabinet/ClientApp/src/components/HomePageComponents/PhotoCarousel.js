import Carousel from "react-bootstrap/Carousel";
export default function PhotoCarousel() {
  const numbers = [1, 2, 3, 4, 5];
  return (
    <div className="my-5 w-75 mx-auto row">
      <Carousel>
        {numbers.map((number) => (
          <Carousel.Item>
            <img
              className="d-block w-100 mx-auto"
              src={"img/gym" + number + ".jpg"}
              alt="slide"
            />
          </Carousel.Item>
        ))}
      </Carousel>
    </div>
  );
}
