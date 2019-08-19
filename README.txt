
# ContactManagement
http://localhost/ContactManagement.API/api/contact/GetAllContacts

## Pre-requisites
--> .Net core 2.2 need to be install.

SQL DB Connection:
"ContactManagement.DefaultConnection": "server=.\\SQLEXPRESS;database=ContactManagementDB;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=true"

--> Database name- ContactManagementDB
--> Table - Contact
--> DB script is attached.

## Build

Build all the projects and run ContactManagement.MvcClient.
To run client- ContactManagement.API should be running. Host it in IIS or run it using IISExpress.

## Implementation
--> Implemented Repository Pattern.
--> Dependency injection
--> Implemented Logger- using Serilog in
			1. ContactManagement.API
			2. ContactManagement.MvcClient
--> Try to implement micro-service architecture
--> Make used of 
			-ExceptionFilterAttribute - API - to catch all unhandle exception
			-ExceptionFilterAttribute - Client - to catch all unhandle exception
			-ActionFilterAttribute - Client - to validate model
			-Customized default error page-display if mode is not Development- UseExceptionHandler("/Contact/Error")
			-Mvc DataAnnotations
--> Used EntityFrameworkCore- DbContext
--> API testing - Swagger is configured
--> Unit test cases