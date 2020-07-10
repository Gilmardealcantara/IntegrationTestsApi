#!/bin/bash

set -e
run_cmd="dotnet run --urls http://*:80 -p ./Api"

echo -e "\n\nInit Migrations!!!\n\n"
rm -rf ./Api/Migrations/
/app/dotnet-ef migrations add Initial -p ./Api

until /app/dotnet-ef database update -v -p ./Api; do
>&2 echo "SQL Server is starting up"
sleep 1
done
>&2 echo "SQL Server is up - executing command"

echo -e "\n\nFinish Migrations and UPDATE!!!\n\n"

exec $run_cmd
