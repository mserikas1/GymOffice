import Carousel from "react-bootstrap/Carousel";
import React, { useState, useEffect } from "react";
import axios from "axios";

export default function PhotoCarousel() {
  const [photos, setPhotos] = useState([]);
  const url = "carouselphoto/getcarouselphotos";

  useEffect(() => {
    axios.get(url).then((response) => setPhotos(response.data));
  }, []);

  return (
    <div className="my-5 w-75 mx-auto row">
      {Array.isArray(photos) ? (
        <Carousel>
          {photos.map((url) => (
            <Carousel.Item>
              <img
                style={{ height: "600px" }}
                className="d-block w-100 mx-auto"
                src={url}
                alt="slide"
              />
            </Carousel.Item>
          ))}
        </Carousel>
      ) : (
        <h1></h1>
      )}
    </div>
  );
}
