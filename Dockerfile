# ===========================================
# BUILD STAGE
# ===========================================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os projetos individualmente
COPY ExpensesControl.API/*.csproj ExpensesControl.API/
COPY ExpensesControl.Domain/*.csproj ExpensesControl.Domain/
COPY ExpensesControl.Application/*.csproj ExpensesControl.Application/
COPY ExpensesControl.Infrastructure/*.csproj ExpensesControl.Infrastructure/

COPY ExpensesControl.sln ./

RUN dotnet restore

# Copia tudo
COPY . .

RUN dotnet publish ExpensesControl.API/ExpensesControl.API.csproj -c Release -o /out

# ===========================================
# RUNTIME STAGE
# ===========================================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /out .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "ExpensesControl.API.dll"]
