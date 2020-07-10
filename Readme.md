# RUN
```
dotnet run -p Api
```

# Tests
```
dotnet test Api.IntegrationTests/
```

# RUN in Docker

```
docker build -t aspnetapp .
docker run -d -p 8080:80 --name myapp aspnetapp
```

# RUN in docker compose for integration tests

```
docker-compose down && docker-compose up --build
```

END Points
- http://localhost:8080/weatherForecast
- http://localhost:8080/users
- http://localhost:8080/users/1/repos

