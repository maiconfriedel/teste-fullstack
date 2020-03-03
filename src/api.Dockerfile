FROM mcr.microsoft.com/dotnet/core/sdk:3.1

COPY . .

RUN ["dotnet", "restore"]

ENTRYPOINT ["dotnet", "run", "--project", "./TesteFullStackGrupoKyly.Api/TesteFullStackGrupoKyly.Api.csproj", "--urls", "https://0.0.0.0:5001"]