﻿CREATE SCHEMA DatabaseTest

CREATE TABLE engineering
(
	[Id] BIGINT IDENTITY (1, 1) NOT NULL, 
    [Name] VARCHAR(255) NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
)