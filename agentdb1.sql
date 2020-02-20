if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_DeleteSpeeDial]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_DeleteSpeeDial]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_InsertCTAAnsweredCallList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_InsertCTAAnsweredCallList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_InsertCTAMissedCallList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_InsertCTAMissedCallList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_MissedCallList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_MissedCallList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_deleteExtensionAcdQeue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_deleteExtensionAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_deleteExtensionHold]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_deleteExtensionHold]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_deletePhoneBook]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_deletePhoneBook]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_deleteTrunkAcdQeue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_deleteTrunkAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_deleteTrunkHold]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_deleteTrunkHold]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertAgent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertAgent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertAnaloTrunk]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertAnaloTrunk]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertAnsweredCallList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertAnsweredCallList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertExtensionAcdQeue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertExtensionAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertExtensionHold]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertExtensionHold]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertPhoneBook]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertPhoneBook]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertTrunkAcdQeue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertTrunkAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_insertTrunkHold]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_insertTrunkHold]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_updateAnalogExtensionDigit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_updateAnalogExtensionDigit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_updateAnalogExtensionState]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_updateAnalogExtensionState]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_updateAnalogExtensiontime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_updateAnalogExtensiontime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_updateAnalogTrunkState]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_updateAnalogTrunkState]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_updateAnalogTrunkbParty]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_updateAnalogTrunkbParty]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_updateSpeeDial]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_updateSpeeDial]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[pr_updateTrunkAcdQeue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[pr_updateTrunkAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewAgent]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewAgent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewAnalogTrunk]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewAnalogTrunk]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewAnsweredCalls]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewAnsweredCalls]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewCTAAnsweredCallsAll]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewCTAAnsweredCallsAll]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewCTAMissedCallsAll]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewCTAMissedCallsAll]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewDataBaseVersion]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewDataBaseVersion]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewExtensionAcdQeue]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewExtensionAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewExtensionHold]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewExtensionHold]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewMissedCalls]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewMissedCalls]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewUsers]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewUsers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewtblExtensionPeriority]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewtblExtensionPeriority]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewtblLineData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewtblLineData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewtblNumbering]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewtblNumbering]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewtblSpeedDial]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewtblSpeedDial]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewTrunkAcdQeue]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewTrunkAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewTrunkHold]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewTrunkHold]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[viewtblPhoneBook]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[viewtblPhoneBook]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAgent]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAgent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAnalogTrunk]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAnalogTrunk]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAnsweredCalls]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAnsweredCalls]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCTAAnsweredCalls]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCTAAnsweredCalls]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCTAMissedCalls]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCTAMissedCalls]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDataBaseVersion]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDataBaseVersion]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblExtensionAcdQeue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblExtensionAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblExtensionHold]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblExtensionHold]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblExtensionPeriority]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblExtensionPeriority]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblLineData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblLineData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMissedCalls]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMissedCalls]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblNumbering]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblNumbering]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblPhoneBook]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblPhoneBook]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblSpeedDial]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblSpeedDial]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblTrunkAcdQeue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblTrunkAcdQeue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblTrunkHold]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblTrunkHold]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUsers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblUsers]
GO

CREATE TABLE [dbo].[tblAgent] (
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[date] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[time] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[State] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAnalogTrunk] (
	[Phone] [nchar] (10) COLLATE Arabic_CI_AS NOT NULL ,
	[Port] [nchar] (10) COLLATE Arabic_CI_AS NOT NULL ,
	[State] [nchar] (10) COLLATE Arabic_CI_AS NULL ,
	[OtheParty] [nchar] (20) COLLATE Arabic_CI_AS NULL ,
	[PortType] [nchar] (10) COLLATE Arabic_CI_AS NULL ,
	[InOut] [nchar] (10) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblAnsweredCalls] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
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

CREATE TABLE [dbo].[tblCTAMissedCalls] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[date] [nchar] (10) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblDataBaseVersion] (
	[Version] [nchar] (50) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblExtensionAcdQeue] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblExtensionHold] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblExtensionPeriority] (
	[index] [int] NULL ,
	[port] [nchar] (10) COLLATE Arabic_CI_AS NULL ,
	[phone] [nchar] (10) COLLATE Arabic_CI_AS NOT NULL ,
	[periority] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblLineData] (
	[RackNumber] [tinyint] NOT NULL ,
	[ShelfNumber] [tinyint] NOT NULL ,
	[SlotNumber] [tinyint] NOT NULL ,
	[PortNumber] [tinyint] NOT NULL ,
	[PreDigit] [nchar] (10) COLLATE SQL_Latin1_General_CP437_CI_AS NOT NULL ,
	[PostDigit] [nchar] (10) COLLATE SQL_Latin1_General_CP437_CI_AS NOT NULL ,
	[HuntGroup] [tinyint] NOT NULL ,
	[PickupGroup] [tinyint] NOT NULL ,
	[TollRestrictionGroup] [tinyint] NOT NULL ,
	[ClassOfService] [smallint] NOT NULL ,
	[DTMF] [bit] NOT NULL ,
	[CallerID] [bit] NOT NULL ,
	[CoinBox] [bit] NOT NULL ,
	[DenidRing] [bit] NOT NULL ,
	[DenidCalling] [bit] NOT NULL ,
	[WarmLine] [bit] NOT NULL ,
	[HotLine] [bit] NOT NULL ,
	[GainIn] [tinyint] NOT NULL ,
	[GainOut] [tinyint] NOT NULL ,
	[BadPayer] [tinyint] NOT NULL ,
	[Bparty] [nchar] (30) COLLATE SQL_Latin1_General_CP437_CI_AS NULL ,
	[Power] [tinyint] NOT NULL ,
	[Test] [tinyint] NOT NULL ,
	[LineState] [tinyint] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblMissedCalls] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblNumbering] (
	[NumberingType] [tinyint] NOT NULL ,
	[NumberOfPreDigit] [tinyint] NOT NULL ,
	[PreDigit] [nchar] (10) COLLATE SQL_Latin1_General_CP437_CI_AS NOT NULL ,
	[NewPreDigit] [nchar] (10) COLLATE SQL_Latin1_General_CP437_CI_AS NULL ,
	[NumberOfPostDigit] [tinyint] NULL ,
	[PostDigitMin] [nchar] (10) COLLATE SQL_Latin1_General_CP437_CI_AS NULL ,
	[PostDigitMax] [nchar] (10) COLLATE SQL_Latin1_General_CP437_CI_AS NULL ,
	[PostDigitLengthMin] [tinyint] NULL ,
	[PostDigitLengthMax] [tinyint] NULL ,
	[ZoneNumber] [tinyint] NOT NULL ,
	[TargetOffice] [tinyint] NULL ,
	[RouteNumber] [tinyint] NULL ,
	[ChargeingType] [tinyint] NOT NULL ,
	[GenerateDetailRecord] [tinyint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblPhoneBook] (
	[id] [bigint] IDENTITY (1, 1) NOT NULL ,
	[index] [int] NULL ,
	[Name] [nvarchar] (50) COLLATE Arabic_CI_AS NOT NULL ,
	[Numebr] [nvarchar] (50) COLLATE Arabic_CI_AS NOT NULL ,
	[job] [nvarchar] (20) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblSpeedDial] (
	[SpeedIndex] [nchar] (10) COLLATE Arabic_CI_AS NOT NULL ,
	[Phone] [nchar] (20) COLLATE Arabic_CI_AS NOT NULL ,
	[name] [nchar] (30) COLLATE Arabic_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblTrunkAcdQeue] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblTrunkHold] (
	[index] [int] NULL ,
	[pid] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[phone] [nchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[portType] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblUsers] (
	[ID] [int] NOT NULL ,
	[UserName] [nchar] (15) COLLATE Arabic_CI_AS NOT NULL ,
	[Password] [nchar] (15) COLLATE Arabic_CI_AS NULL ,
	[AccessLevel] [tinyint] NOT NULL 
) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewTrunkAcdQeue
AS
SELECT     dbo.tblTrunkAcdQeue.*
FROM         dbo.tblTrunkAcdQeue

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewTrunkHold
AS
SELECT     dbo.tblTrunkHold.*
FROM         dbo.tblTrunkHold

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewtblPhoneBook
AS
SELECT     dbo.tblPhoneBook.*
FROM         dbo.tblPhoneBook

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewAgent
AS
SELECT     dbo.tblAgent.*
FROM         dbo.tblAgent

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewAnalogTrunk
AS
SELECT     dbo.tblAnalogTrunk.*
FROM         dbo.tblAnalogTrunk

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewAnsweredCalls
AS
SELECT     dbo.tblAnsweredCalls.*
FROM         dbo.tblAnsweredCalls


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewExtensionAcdQeue
AS
SELECT     dbo.tblExtensionAcdQeue.*
FROM         dbo.tblExtensionAcdQeue

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewlExtensionHold
AS
SELECT     dbo.tblExtensionHold.*
FROM         dbo.tblExtensionHold

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewMissedCalls
AS
SELECT     dbo.tblMissedCalls.*
FROM         dbo.tblMissedCalls

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewtblExtensionPeriority
AS
SELECT     dbo.tblExtensionPeriority.*
FROM         dbo.tblExtensionPeriority

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW viewtblLineData AS
SELECT *
FROM tblLineData

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW viewtblNumbering AS
SELECT *
FROM tblNumbering


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.viewtblSpeedDial
AS
SELECT     dbo.tblSpeedDial.*
FROM         dbo.tblSpeedDial

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE procedure pr_DeleteSpeeDial;1


@speedindex nchar(10),
@phone nchar(20)

as
begin transaction
delete from  [dbo].[viewtblSpeedDial]  where  speedindex = @speedIndex


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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE procedure pr_MissedCallList;1

@number  tinyint,
@pid nchar(10),
@phone nchar(10),
@portType nchar(10),
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewMissedCalls] 
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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE procedure pr_deleteExtensionAcdQeue;1





@pid nchar(10),
@phone nchar(10)



as
begin transaction

delete from [dbo].[viewExtensionAcdQeue] 
				where
				(pid=@pid ) and
				(phone = @phone)







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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE procedure pr_deleteExtensionHold;1





@pid nchar(10),
@phone nchar(10)



as
begin transaction

delete from [dbo].[viewExtensionHold] 
				where
				(pid=@pid ) and
				(phone = @phone)







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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





CREATE procedure pr_deletePhoneBook;1



@name nvarchar(50),
@number nvarchar(50)




as
begin transaction
print @name
print @number

delete from [dbo].[viewtblPhonebook] 
				where
				([name]=@name ) and
				(numebr= @number)







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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE procedure pr_deleteTrunkAcdQeue;1





@pid nchar(10),
@phone nchar(20)



as
begin transaction

delete from [dbo].[viewTrunkAcdQeue] 
				where
				(pid=@pid )







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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO





CREATE procedure pr_deleteTrunkHold;1





@pid nchar(10),
@phone nchar(20)



as
begin transaction

delete from [dbo].[viewTrunkHold] 
				where
				(pid=@pid )
				







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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE procedure pr_insertAgent;1

@phone nchar(10),
@date nchar(10),
@time nchar(10),
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewAgent] 
					(phone,
					[date],[time],
					state )

					values(
					@phone ,
					@date ,
					@time,
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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE procedure pr_insertAnaloTrunk;1

@phone nchar(10),
@Port nchar(10),
@State  nchar(10),
@OtheParty  nchar(20)

as
begin transaction

insert into [dbo].[viewAnalogTrunk] 
					(phone,
					[Port],
					State,OtheParty )

					values(
					@phone ,
					@Port ,
					@State	,@OtheParty )


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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_insertAnsweredCallList;1

@number  tinyint,
@pid nchar(10),
@phone nchar(10),
@portType nchar(10),
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewAnsweredCalls] 
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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_insertExtensionAcdQeue;1

@number  tinyint,
@pid nchar(10),
@phone nchar(10),
@portType nchar(10),
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewExtensionAcdQeue] 
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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_insertExtensionHold;1

@number  tinyint,
@pid nchar(10),
@phone nchar(10),
@portType nchar(10),
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewExtensionHold] 
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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE procedure pr_insertPhoneBook;1

@index tinyint,
@name  nvarchar(50),
@number nvarchar(50),
@job nvarchar(20)



as
begin transaction

insert into [dbo].[viewtblPhoneBook] 
					([index],
					[name],
					Numebr,job)

					values(
					@index ,
					@name,
					@number,@job)


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
@number nvarchar(50),
@job nvarchar(50)


as
begin transaction



update  [dbo].[viewtblPhoneBook]  set Numebr= @number , name=@name ,job=@job where id=@index 
	

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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_insertTrunkAcdQeue;1

@number  tinyint,
@pid nchar(10),
@phone nchar(20),
@portType nchar(10),
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewTrunkAcdQeue] 
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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_insertTrunkHold;1

@number  tinyint,
@pid nchar(10),
@phone nchar(10),
@portType nchar(10),
@state  nchar(10)

as
begin transaction

insert into [dbo].[viewTrunkHold] 
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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE procedure pr_updateAnalogExtensionDigit;1

@rack  nchar(10),
@shelf  nchar(10),
@slot nchar(10),
@port nchar(10),
@digit  nchar(10)

as
begin transaction

declare @bbb nvarchar(30)

select @bbb= bparty  from   [dbo].[viewtbllineData] where(rackNumber=@rack and shelfNumber=@shelf and SlotNumber = @slot and PortNumber = @port )



UPDATE 
    [dbo].[viewtbllineData] 
SET 
    bparty =(rtrim(ltrim(@bbb))+@digit) where (rackNumber=@rack and shelfNumber=@shelf and SlotNumber = @slot and PortNumber = @port )




if @@error>0
	return



if @@error>0
	rollback transaction
else
	commit transaction
GO

CREATE procedure pr_updateAnalogExtensionDigit;2

@rack  nchar(10),
@shelf  nchar(10),
@slot nchar(10),
@port nchar(10),
@digit  nchar(10)

as
begin transaction

declare @bbb nvarchar(30)

select @bbb= bparty  from   [dbo].[viewtbllineData] where(rackNumber=@rack and shelfNumber=@shelf and SlotNumber = @slot and PortNumber = @port )



UPDATE 
    [dbo].[viewtbllineData] 
SET 
    bparty ='  '  where (rackNumber=@rack and shelfNumber=@shelf and SlotNumber = @slot and PortNumber = @port )




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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_updateAnalogExtensionState;1

@rack  nchar(10),
@shelf  nchar(10),
@slot nchar(10),
@port nchar(10),
@State  nchar(10)

as
begin transaction
update [dbo].[viewtbllineData] set
				LineState=@State
			
				where
				(rackNumber=@rack and shelfNumber=@shelf and SlotNumber = @slot and PortNumber = @port )

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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE procedure pr_updateAnalogExtensiontime;1

@rack  nchar(10),
@shelf  nchar(10),
@slot nchar(10),
@port nchar(10),
@State  nchar(10)

as
begin transaction
update [dbo].[viewtbllineData] set
				bparty=@State
			
				where
				(rackNumber=@rack and shelfNumber=@shelf and SlotNumber = @slot and PortNumber = @port )

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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_updateAnalogTrunkState;1

@port  nchar(10),
@phone nchar(10),

@State  nchar(10)

as
begin transaction
update [dbo].[viewAnalogTrunk] set
				State=@State
			
				where
				(port=@port)

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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_updateAnalogTrunkbParty;1

@port  nchar(10),
@phone nchar(10),

@bPArty  nchar(20)

as
begin transaction
update [dbo].[viewAnalogTrunk] set
				OtheParty=@bParty
			
				where
				(port=@port)

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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_updateSpeeDial;1 


@speedindex nchar(10),
@phone nchar(20),
@name1 nchar(50)

as
begin transaction

declare @clist int
set @clist = 0

set @clist = (select  Count(*) from  [dbo].[viewtblSpeedDial]    where  speedindex =@speedindex)
print @clist 
if @clist = 0 
	begin
	
	
	insert into  [dbo].[viewtblSpeedDial] (
	
					SpeedIndex ,phone,[name])
				
				values(@speedIndex,
					@phone,@name1)
	end
else
	begin
	update  [dbo].[viewtblSpeedDial] 
						set   phone=@phone 	where (speedindex=@speedindex)
	
	end
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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE procedure pr_updateTrunkAcdQeue;1

@number  tinyint,
@pid nchar(10),
@phone nchar(20),
@portType nchar(10),
@state  nchar(10)

as
begin transaction
update [dbo].[viewTrunkAcdQeue] set
				phone=@phone
			
				where
				(pid=@pid)

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

