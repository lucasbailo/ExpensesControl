# ============================
# 1) Build stage
# ============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia as partes da solução
COPY ../ExpensesControl.Application/*.csproj ./ExpensesControl.Application/
COPY ../ExpensesControl.Domain/*.csproj ./ExpensesControl.Domain/
COPY ../ExpensesControl.Infrastructure/*.csproj ./ExpensesControl.Infrastructure/
COPY ./*.csproj ./ExpensesControl/

# Restaura dependências
RUN dotnet restore ExpensesControl.csproj

# Copia tudo e compila
COPY . .
RUN dotnet publish ExpensesControl.csproj -c Release -o /app/publish

# ============================
# 2) Runtime stage
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

# Render automaticamente define a porta através da variável PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

EXPOSE 8080

ENTRYPOINT ["dotnet", "ExpensesControl.dll"]
