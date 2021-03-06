
use [Agent_DB]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDataBaseVersion]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDataBaseVersion]
GO

CREATE TABLE [dbo].[tblDataBaseVersion] (
	[Version] [nchar] (50) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
Insert into [dbo].[tblDataBaseVersion] (Version) values ('1.17.02')
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




--Add tblCTAAnsweredCalls
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCTAAnsweredCalls]') and OBJECTPROPERTY(id, N'IsUserTable') = 0)
Begin

CREATE TABLE [dbo].[tblCTAAnsweredCalls] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
End

GO

--Generate SQL View for tblCTAAnsweredCalls
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewCTAAnsweredCallsAll]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].viewCTAAnsweredCallsAll
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewCTAAnsweredCallsAll
AS
SELECT     dbo.tblCTAAnsweredCalls.*
FROM         dbo.tblCTAAnsweredCalls

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

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
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewCTAAnsweredCallsAll] 
					(
					[index], 
					pid, 
					phone,
					portType,
					state )

					values(
					@number ,
					@pid ,
					@phone,
					@portType ,
					@state )


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




--Add tblCTAMissedCalls
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCTAMissedCalls]') and OBJECTPROPERTY(id, N'IsUserTable') = 0)

Begin

CREATE TABLE [dbo].[tblCTAMissedCalls] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
End

GO

--Generate SQL View for tblCTAMissedCalls
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewCTAMissedCallsAll]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].viewCTAMissedCallsAll
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewCTAMissedCallsAll
AS
SELECT     dbo.tblCTAMissedCalls.*
FROM         dbo.tblCTAMissedCalls

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


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
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewCTAMissedCallsAll] 
					(
					[index], 
					pid, 
					phone,
					portType,
					state )

					values(
					@number ,
					@pid ,
					@phone,
					@portType ,
					@state )


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


--tblphonebook
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblPhoneBook]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblPhoneBook]
GO

CREATE TABLE [dbo].[tblPhoneBook] (
	[index] [int] NULL ,
	[Name] [nvarchar] (50) COLLATE Arabic_CI_AS NOT NULL ,
	[Numebr] [nvarchar] (50) COLLATE Arabic_CI_AS NOT NULL 
) ON [PRIMARY]
GO



--viewPhonebook
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewtblPhoneBook]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewtblPhoneBook]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create view viewtblPhoneBook As select * from dbo.tblPhoneBook

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--insertPhonebook
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertPhoneBook]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertPhoneBook]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE procedure pr_insertPhoneBook;1

@index tinyint,
@name  nvarchar(50),
@number nvarchar(50)


as
begin transaction

insert into [dbo].[viewtblPhoneBook] 
					([index],
					[name],
					Numebr)

					values(
					@index ,
					@name,
					@number)


if @@error>0
	return



if @@error>0
	rollback transaction
else
	commit transaction
GO

CREATE procedure pr_insertPhoneBook;2

@index tinyint,
@name  nvarchar(50),
@number nvarchar(50)


as
begin transaction



update  [dbo].[viewtblPhoneBook]  set Numebr= @number where name=@name 
	

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










