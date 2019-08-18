
# ContactManagement
http://localhost/ContactManagement.API/api/contact/GetAllContacts

## Pre-requisites
--> .Net core 2.2 need to be install.

SQL DB Connection:
"ContactManagement.DefaultConnection": "server=.\\SQLEXPRESS;database=ContactManagementDB;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;Trusted_Connection=true"

--> Database name- ContactManagementDB
--> Table - Contact
--> Script--

			USE [ContactManagementDB]
			GO

			/****** Object:  Table [dbo].[Contact]    Script Date: 18-08-2019 16:22:41 ******/
			SET ANSI_NULLS ON
			GO

			SET QUOTED_IDENTIFIER ON
			GO

			CREATE TABLE [dbo].[Contact](
				[ID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
				[FirstName] [varchar](50) NOT NULL,
				[LastName] [varchar](50) NOT NULL,
				[Email] [varchar](100) NOT NULL,
				[PhoneNumber] [varchar](50) NOT NULL,
				[City] [varchar](100) NOT NULL,
				[IsActive] [bit] NULL,
			 CONSTRAINT [PK_ContactId] PRIMARY KEY CLUSTERED 
			(
				[ID] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY]
			GO

			ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_IsActive]  DEFAULT ((0)) FOR [IsActive]
			GO


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
--> Make used of ExceptionFilterAttribute and ActionFilterAttribute
--> Used EntityFrameworkCore- DbContext
--> API testing - Swagger is configured