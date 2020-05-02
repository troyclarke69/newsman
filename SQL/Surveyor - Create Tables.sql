USE [NewsMan]
GO
DROP TABLE IF EXISTS [dbo].[Question];
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[QGroup] [int] NOT NULL,				-- Used to group specific questions in view
	[Order] [int] NOT NULL,
	[QuestionText] [varchar](500) NOT NULL,
	[AnswerGroupId] [int] NULL
) ON [PRIMARY]
GO
DROP TABLE IF EXISTS [dbo].[SurveyQuestion];
CREATE TABLE [dbo].[SurveyQuestion](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[SurveyMasterId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL
) ON [PRIMARY]
GO
DROP TABLE IF EXISTS [dbo].[Session];
CREATE TABLE [dbo].[Session](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DateEntered] [datetime] NOT NULL,				
	[Origin] [varchar](50) NULL,
	[SurveyMasterId] [int] NOT NULL,
) ON [PRIMARY]
GO
DROP TABLE IF EXISTS [dbo].[SurveyMaster];
CREATE TABLE [dbo].[SurveyMaster](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Purpose] [varchar](500) NULL,
	[DateOpen] [datetime] NOT NULL,				
	[DateClose] [datetime] NULL,
	[Active] [int] NULL
) ON [PRIMARY]
GO
DROP TABLE IF EXISTS [dbo].[Result];
CREATE TABLE [dbo].[Result](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[SessionId] [int] NOT NULL,
	[SurveyId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,				
	[AnswerOptionId] [int] NOT NULL,	
) ON [PRIMARY]
GO
DROP TABLE IF EXISTS [dbo].[AnswerGroup];
CREATE TABLE [dbo].[AnswerGroup](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]
GO
DROP TABLE IF EXISTS [dbo].[AnswerOption];
CREATE TABLE [dbo].[AnswerOption](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[AnswerVal] [int] NOT NULL,				
	[AnswerText] [varchar](500) NOT NULL,
	[AnswerGroupId] [int] NULL
) ON [PRIMARY]
GO





