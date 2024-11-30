FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 443
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CourseWork.Api/CourseWork.Api.csproj", "CourseWork.Api/"]
COPY ["CourseWork.Domain/CourseWork.Domain.csproj", "CourseWork.Domain/"]
COPY ["CourseWork.Application/CourseWork.Application.csproj", "CourseWork.Application/"]
COPY ["CourseWork.Persistence/CourseWork.Persistence.csproj", "CourseWork.Persistence/"]
RUN dotnet restore "CourseWork.Api/CourseWork.Api.csproj"
COPY . .
WORKDIR "/src/CourseWork.Api"
RUN dotnet build "CourseWork.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CourseWork.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseWork.Api.dll"]
