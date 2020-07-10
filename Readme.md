docker build -t aspnetapp .
docker run -d -p 8080:80 --name myapp aspnetapp

docker-compose down && docker-compose up --build

TODO:
Implements integration tests