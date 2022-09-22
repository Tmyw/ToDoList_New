FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDoList_New/ToDoList_New.csproj", "ToDoList_New/"]
RUN dotnet restore "ToDoList_New/ToDoList_New.csproj"
COPY . .
WORKDIR "/src/ToDoList_New"
RUN dotnet build "ToDoList_New.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoList_New.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoList_New.dll"]
