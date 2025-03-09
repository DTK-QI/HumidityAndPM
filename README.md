# HumidityAndPM

<div align="center">
  <img src="https://img.shields.io/badge/platform-ASP.NET%20Core%208.0-blue" alt="Platform">
  <img src="https://img.shields.io/badge/language-C%23-brightgreen" alt="Language">
  <img src="https://img.shields.io/badge/database-SQL%20Server-red" alt="Database">
  <img src="https://img.shields.io/badge/license-MIT-green" alt="License">
</div>

<details open>
<summary>English</summary>

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

</details>

<details>
<summary>中文</summary>

## 關於專案

HumidityAndPM是一個網絡應用程式，用於收集、分析和可視化環境數據，特別專注於空氣質量（PM2.5）和濕度測量。該應用程式從台灣環保署的API獲取數據，將其存儲在數據庫中，並通過互動式圖表和表格進行展示。

### 主要功能

- **實時數據收集** - 每小時自動從台灣環保署公共API獲取環境數據
- **數據可視化** - 互動式圖表顯示濕度與PM2.5隨時間的相關性
- **數據管理** - 環境數據點的增刪改查操作
- **定時任務** - 使用Hangfire進行背景作業調度，定期更新數據
- **響應式UI** - 使用Bootstrap的移動端友好界面

## 技術架構

- **後端**
  - ASP.NET Core 8.0
  - Entity Framework Core
  - Hangfire（用於定時任務）
  
- **前端**
  - HTML, CSS, JavaScript
  - Bootstrap用於響應式設計
  - Chart.js用於數據可視化
  
- **資料庫**
  - SQL Server

## 開始使用

### 前置要求

- .NET 8.0 SDK
- SQL Server
- 環保署API金鑰

### 安裝步驟

1. 克隆存儲庫
   ```sh
   git clone https://github.com/yourusername/HumidityAndPM.git
   ```

2. 在`HumidityAndPMDataConnect/Models/WeatherContext.cs`中配置數據庫連接字串

3. 設置API金鑰環境變數
   ```sh
   # Windows
   setx API_moenv your_api_key
   
   # Linux/macOS
   export API_moenv=your_api_key
   ```

4. 執行數據庫遷移
   ```sh
   dotnet ef database update
   ```

5. 運行應用程式
   ```sh
   dotnet run --project HumidityAndPM
   ```

### 數據庫配置

要從現有數據庫重新生成Entity Framework模型：
```sh
dotnet ef dbcontext scaffold "Server=.;Database=Weather;User ID=XX;Password=XXX;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models --force
```

## 專案結構

- **HumidityAndPM**：主要Web應用程式專案
  - `Controllers/`：處理HTTP請求
  - `Function/`：包含數據檢索的業務邏輯
  - `Models/`：應用程式的數據模型
  - `Views/`：數據可視化的UI模板
  
- **HumidityAndPMDataConnect**：數據訪問層專案
  - `Models/`：數據庫訪問的實體模型
  
- **HumidityAndPMTests**：應用程式的單元測試

## API參考

| 端點 | 方法 | 描述 |
| --- | --- | --- |
| `/weather/GetData?label={label}` | GET | 根據標籤獲取天氣數據 |
| `/weather/GetDataValue?id={id}` | GET | 根據ID獲取特定數據值 |
| `/weather/updateValue` | POST | 更新數據值 |
| `/weather/DeleteDataValue?id={id}` | DELETE | 根據ID刪除數據值 |

</details>