import Carousel from "react-bootstrap/Carousel";

function UncontrolledExample() {
  return (
    <div className="my-5 w-50 mx-auto">
      <Carousel>
        <Carousel.Item>
          <img
            className="d-block w-100 mx-auto"
            src="https://vezha.ua/wp-content/uploads/2020/02/forest.jpg"
            alt="First slide"
          />
        </Carousel.Item>
        <Carousel.Item>
          <img
            className="d-block w-100 mx-auto"
            src="https://vezha.ua/wp-content/uploads/2020/02/forest.jpg"
            alt="Second slide"
          />
        </Carousel.Item>
        <Carousel.Item>
          <img
            className="d-block w-100 mx-auto"
            src="https://vezha.ua/wp-content/uploads/2020/02/forest.jpg"
            alt="Third slide"
          />
        </Carousel.Item>
      </Carousel>
    </div>
  );
}

export default UncontrolledExample;
