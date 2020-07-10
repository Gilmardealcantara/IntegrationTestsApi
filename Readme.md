docker build -t aspnetapp .
docker run -d -p 8080:80 --name myapp aspnetapp

docker-compose down && docker-compose up --build
http://localhost:8080/WeatherForecast
http://localhost:8080/Users

TODO:
Implements integration tests

EndPoinst

