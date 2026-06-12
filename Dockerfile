#Use the official .NET SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#Set the working directory in the container
WORKDIR /app
#Copy the project file and restore dependencies
COPY ProyectoGenericoNet.Api/*.csproj ./ProyectoGenericoNet.Api/
RUN dotnet restore ProyectoGenericoNet.Api/ProyectoGenericoNet.Api.csproj
#Copy the rest of the application code
COPY . ./
#Publish the application
RUN dotnet publish ProyectoGenericoNet.Api/ProyectoGenericoNet.Api.csproj -c Release -o out
#Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
#Expose the port the application will run on
EXPOSE 8080
#Set the entry point for the application
ENTRYPOINT ["dotnet", "ProyectoGenericoNet.Api.dll"]
