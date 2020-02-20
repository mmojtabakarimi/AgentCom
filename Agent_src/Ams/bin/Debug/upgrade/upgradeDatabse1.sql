
use [Agent_DB]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDataBaseVersion]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDataBaseVersion]
GO

CREATE TABLE [dbo].[tblDataBaseVersion] (
	[Version] [nchar] (50) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
Insert into [dbo].[tblDataBaseVersion] (Version) values ('1.19.01')
GO

--Generate SQL View for tblDatabsaeversion
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewDataBaseVersion]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewDataBaseVersion]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewDataBaseVersion
AS
SELECT     dbo.tblDataBaseVersion.*
FROM         dbo.tblDataBaseVersion

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--Add tblUsers  94-07-12
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblUsers]
GO

CREATE TABLE [dbo].[tblUsers] (
	[ID] [int] NOT NULL ,
	[UserName] [nchar] (15) COLLATE Arabic_CI_AS NOT NULL ,
	[Password] [nchar] (15) COLLATE Arabic_CI_AS NULL ,
	[AccessLevel] [tinyint] NOT NULL 
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblUsers] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblUsers] PRIMARY KEY  CLUSTERED 
	(
		[UserName]
	)  ON [PRIMARY] 
GO
Insert into [dbo].[tblUsers] (ID,USERNAME,PassWORD,ACCESSLEVEL) values ('0','Admin','Admin',0)
GO
Insert into [dbo].[tblUsers] (ID,USERNAME,PassWORD,ACCESSLEVEL) values ('0','1','1',1)
GO
Insert into [dbo].[tblUsers] (ID,USERNAME,PassWORD,ACCESSLEVEL) values ('0','op','op',1)
GO
--Add tblUsers View
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewUsers]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewUsers]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewUsers
AS
SELECT     dbo.tblUsers.*
FROM         dbo.tblUsers

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--Add Stored procedure for tbluser ***** pr_deleteUser
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_deleteUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_deleteUser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



--1
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCTAAnsweredCalls]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCTAAnsweredCalls]
GO

CREATE TABLE [dbo].[tblCTAAnsweredCalls] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[date] [nchar] (10) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
GO

--1-2
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewCTAAnsweredCallsAll]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewCTAAnsweredCallsAll]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW viewCTAAnsweredCallsAll AS
SELECT *
FROM tblCTAAnsweredCalls


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--1-3
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_InsertCTAAnsweredCallList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_InsertCTAAnsweredCallList]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



--Add insertCTAAnsweredCalls
CREATE procedure pr_InsertCTAAnsweredCallList;1

@number  tinyint,
@pid nchar(10),
@phone nchar(10),
@portType nchar(10),
@state  nchar(10),
@ddate  nchar(10)

as
begin transaction

insert into [dbo].[viewCTAAnsweredCallsAll] 
					(
					[index], 
					pid, 
					phone,
					portType,
					state,[date] )

					values(
					@number ,
					@pid ,
					@phone,
					@portType ,
					@state,@ddate )


if @@error>0
	return



if @@error>0
	rollback transaction
else
	commit transaction
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--2
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCTAMissedCalls]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCTAMissedCalls]
GO

CREATE TABLE [dbo].[tblCTAMissedCalls] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[date] [nchar] (10) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
GO



--2-1
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewCTAMissedCallsAll]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewCTAMissedCallsAll]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW viewCTAMissedCallsAll AS
SELECT *
FROM tblCTAMissedCalls


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--2-2
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_InsertCTAMissedCallList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_InsertCTAMissedCallList]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



--Add InsertCTAMissed
CREATE procedure pr_InsertCTAMissedCallList;1

@number  tinyint,
@pid nchar(10),
@phone nchar(10),
@portType nchar(10),
@state  nchar(10),
@ddate nchar(10)

as
begin transaction

insert into [dbo].[viewCTAMissedCallsAll] 
					(
					[index], 
					pid, 
					phone,
					portType,
					state ,[date])

					values(
					@number ,
					@pid ,
					@phone,
					@portType ,
					@state,@ddate )


if @@error>0
	return



if @@error>0
	rollback transaction
else
	commit transaction
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO













print 'SUCCESSFULL'










