# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# WORKFIR /app
# EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app/src
EXPOSE 80


# copy csproj/sln files
COPY ["pamela-soulis-project1.WebUI/pamela-soulis-project1.WebUI.csproj", "pamela-soulis-project1.WebUI/"]
COPY ["pamela-soulis-project1.Domain/pamela-soulis-project1.Domain.csproj", "pamela-soulis-project1.Domain/"]
COPY ["pamela-soulis-project1.DataAccess/pamela-soulis-project1.DataAccess.csproj", "pamela-soulis-project1.DataAccess/"]
COPY *.sln ./
RUN dotnet restore "pamela-soulis-project1.WebUI/pamela-soulis-project1.WebUI.csproj"

# copy rest of build context into /app/src
COPY . .

# publish to /app/publish
RUN dotnet publish pamela-soulis-project1.WebUI -o ../publish --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

WORKDIR /app

# copy assemblies from build stage into this stage
COPY --from=build /app/publish ./

CMD dotnet pamela-soulis-project1.WebUI.dll


# WORKDIR "/pamela-soulis-project1.WebUI"
# RUN dotnet build "pamela-soulis-project1.WebUI.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "pamela-soulis-project1.WebUI.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "pamela-soulis-project1.WebUI.dll"]