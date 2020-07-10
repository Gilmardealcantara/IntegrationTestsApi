FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

# Copy csproj and restore as distinct layers
# COPY *.csproj ./
COPY . ./
RUN [ -f /app/dotnet-ef ] || dotnet tool install dotnet-ef --tool-path /app/
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
RUN ["dotnet", "test"]

EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
# ENTRYPOINT ["dotnet", "run", "--urls", "http://*:80"]

# Copy everything else and build
# COPY . ./
# RUN dotnet publish -c Release -o out

# Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build-env /app/out .
# EXPOSE 80/tcp
# ENTRYPOINT ["dotnet", "Api.dll"]
