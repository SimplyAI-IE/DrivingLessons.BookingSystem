# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# ✅ Expose the correct port for Render (5000)
EXPOSE 5000

# ✅ Run your application
ENTRYPOINT ["dotnet", "DrivingLessons.BookingSystem.API.dll"]
