# ===========================================
# BUILD STAGE
# ===========================================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia projetos com base na estrutura REAL do seu repo
COPY ExpensesControl/*.csproj ExpensesControl/
COPY ExpensesControl.Application/*.csproj ExpensesControl.Application/
COPY ExpensesControl.Domain/*.csproj ExpensesControl.Domain/
COPY ExpensesControl.Infrastructure/*.csproj ExpensesControl.Infrastructure/

COPY ExpensesControl.sln .

RUN dotnet restore

# Copia todo o repositório
COPY . .

# Publica somente o projeto da API (ExpensesControl)
RUN dotnet publish ExpensesControl/ExpensesControl.csproj -c Release -o /out

# ===========================================
# RUNTIME STAGE
# ===========================================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /out .

# Render define a porta automaticamente via variável PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

ENTRYPOINT ["dotnet", "ExpensesControl.dll"]
