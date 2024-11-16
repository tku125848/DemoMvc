### Nuget 匯入 Dapper, Microsoft.Data.SqlClient , Newtonsoft.Json
### 建立 Connections 目錄
### 新增 Interface Connection
### 建立 Interface IDapperConnection.cs
### 建立 class MyDbConnection.cs 繼承 IDapperConnection 且 Implement Methods
### 開啟 User Secrets 設定 ConnectionString , 以 MyDb 作為 Key 為例
    1. Rider -> Tools -> User Secrets -> Add ConnectionString
    2.Visual Studio -> Manage User Secrets -> Add ConnectionString
### 在 Program.cs 中注入 MyDbConnection，注入 MemoryCache
### 註解 <Nullable>enable</Nullable>
### 新增 MyModel.cs 且定義屬性與 GetOne 與 GetList 方法
### 新增 MyModel.cs  GetOneFromMS 與 GetListFromMS 方法
### 新增 IndexVm.cs 且定義 myModels 與 myModel 屬性
### 在 HomeController.cs 在 Index 方法加入 InedexVm 且 加入 View Model
### 在 Index.cshtml 使用 @Model