# AzureSqlDemo
Demo which connects client app to web apis to perform crud operations using Azure.

## What you need?
1. Azure Web service
2. Azure sql
3. Visual studio

### Azure sql
Microsoft Azure SQL Database is a managed cloud database provided as part of Microsoft Azure. Below are the steps to create Azure SQl database
1. Create Azure sql in Azure portal which will create a sql server and sql database for you. You can create more number of sql datbases once you create sql server
2. Make a note of Connection string in the sql server page which is required to connect to database from web api.
Note: For detailed steps you can refer microsoft documents.

### Azure Web service
Azure App Service is an HTTP-based service for hosting web applications, REST APIs, and mobile back ends. Below are the steps to create Azure App service
1. Create Azure App service using Azure Web App.
2. After creating Azure App service, you have an option configuration in the page where you can add connection string which is obtained from azure sql page.
3. Note: For detailed steps you can refer microsoft documents.

### Backend Code (AzureSqlXamarinAppDemoBackened)
Backend code is a .net core web api procject and needs to be hosted on Azure cloud using Azure Web App (App service). Steps are as below
1. Add the connection string obtained from azure sql page which is required for connecting to database from web api.
2. You can test if the Api are working fine from Postman, swagger or any other tool
Note: Create the tables in the database as per Model (Account)

### Front end client app (AzureSqlXamarinDbDemo)
Client app is developed in xamarin forms as a mobile app. You can connect and use the web api using any front end that you require. You can deploy the app in your android mobile and perform the crud operations.
<p align="left">
  <img src="/screenshots/clientimg1.jpeg" height="550">
  <img src="/screenshots/clientimg2.jpeg" height="550">
  <img src="/screenshots/clientimg3.jpeg" height="550">
</p>

#### Note: You can click on edit button to update the record, delete button to delete the record and shopping cart button at right bottom corner to add the records.
