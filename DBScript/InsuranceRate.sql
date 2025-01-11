﻿CREATE TABLE [dbo].[InsuranceRate] (
BusinessYear	NVARCHAR (MAX) NULL,
StateCode	NVARCHAR (MAX) NULL,
IssuerId	NVARCHAR (MAX) NULL,
SourceName	NVARCHAR (MAX) NULL,
VersionNum	NVARCHAR (MAX) NULL,
ImportDate	NVARCHAR (MAX) NULL,
IssuerId2	NVARCHAR (MAX) NULL,
FederalTIN	NVARCHAR (MAX) NULL,
RateEffectiveDate	NVARCHAR (MAX) NULL,
RateExpirationDate	NVARCHAR (MAX) NULL,
PlanId	NVARCHAR (MAX) NULL,
RatingAreaId	NVARCHAR (MAX) NULL,
Tobacco	NVARCHAR (MAX) NULL,
Age	NVARCHAR (MAX) NULL,
IndividualRate	NVARCHAR (MAX) NULL,
IndividualTobaccoRate	NVARCHAR (MAX) NULL,
Couple	NVARCHAR (MAX) NULL,
PrimarySubscriberAndOneDependent	NVARCHAR (MAX) NULL,
PrimarySubscriberAndTwoDependents	NVARCHAR (MAX) NULL,
PrimarySubscriberAndThreeOrMoreDependents	NVARCHAR (MAX) NULL,
CoupleAndOneDependent	NVARCHAR (MAX) NULL,
CoupleAndTwoDependents	NVARCHAR (MAX) NULL,
CoupleAndThreeOrMoreDependents	NVARCHAR (MAX) NULL,
RowNumber	NVARCHAR (MAX) NULL,
[CreatedDate] datetime default CURRENT_TIMESTAMP,
Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
)