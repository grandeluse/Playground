This project is used with learning purpose

- Here some useful commands

su sudo docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -d --name SQL_Server_Docker -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=DB_Password' -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest