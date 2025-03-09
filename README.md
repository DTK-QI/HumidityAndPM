# HumidityAndPM

<div align="center">
  <img src="https://img.shields.io/badge/platform-ASP.NET%20Core%208.0-blue" alt="Platform">
  <img src="https://img.shields.io/badge/language-C%23-brightgreen" alt="Language">
  <img src="https://img.shields.io/badge/database-SQL%20Server-red" alt="Database">
  <img src="https://img.shields.io/badge/license-MIT-green" alt="License">
</div>

[中文文档](README.zh.md)

## About The Project

HumidityAndPM is a web application that collects, analyzes, and visualizes environmental data, specifically focusing on air quality (PM2.5) and humidity measurements. The application retrieves data from Taiwan's Environmental Protection Administration (EPA) API, stores it in a database, and presents it through interactive charts and tables.

### Key Features

- **Real-time Data Collection** - Automatically fetches environmental data from Taiwan EPA's public API every hour
- **Data Visualization** - Interactive charts showing the correlation between humidity and PM2.5 values over time
- **Data Management** - CRUD operations for environmental data points
- **Scheduled Tasks** - Background job scheduling using Hangfire to regularly update data
- **Responsive UI** - Mobile-friendly interface using Bootstrap

## Built With

- **Backend**
  - ASP.NET Core 8.0
  - Entity Framework Core
  - Hangfire (for scheduled tasks)
  
- **Frontend**
  - HTML, CSS, JavaScript
  - Bootstrap for responsive design
  - Chart.js for data visualization
  
- **Database**
  - SQL Server

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server
- EPA API Key

### Installation

1. Clone the repository
   ```sh
   git clone https://github.com/yourusername/HumidityAndPM.git
   ```

2. Configure the database connection string in `HumidityAndPMDataConnect/Models/WeatherContext.cs`

3. Set environment variable for API key
   ```sh
   # Windows
   setx API_moenv your_api_key
   
   # Linux/macOS
   export API_moenv=your_api_key
   ```

4. Run database migrations
   ```sh
   dotnet ef database update
   ```

5. Run the application
   ```sh
   dotnet run --project HumidityAndPM
   ```

### Database Configuration

To regenerate the Entity Framework models from an existing database:
```sh
dotnet ef dbcontext scaffold "Server=.;Database=Weather;User ID=XX;Password=XXX;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models --force
```

## Project Structure

- **HumidityAndPM**: Main web application project
  - `Controllers/`: Handles HTTP requests
  - `Function/`: Contains business logic for data retrieval
  - `Models/`: Data models for the application
  - `Views/`: UI templates for data visualization
  
- **HumidityAndPMDataConnect**: Data access layer project
  - `Models/`: Entity models for database access
  
- **HumidityAndPMTests**: Unit tests for the application

## API Reference

| Endpoint | Method | Description |
| --- | --- | --- |
| `/weather/GetData?label={label}` | GET | Gets weather data by label |
| `/weather/GetDataValue?id={id}` | GET | Gets a specific data value by ID |
| `/weather/updateValue` | POST | Updates a data value |
| `/weather/DeleteDataValue?id={id}` | DELETE | Deletes a data value by ID |