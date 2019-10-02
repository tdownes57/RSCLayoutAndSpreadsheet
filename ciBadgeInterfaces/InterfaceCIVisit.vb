''
''Added 10/2/2019 thomas downes  
''
''   The following is for CI Badge Visitor Management, shortenned to "CI Visitor".   
''
''Set ANSI_PADDING On
''GO

''CREATE TABLE [dbo].[tblVisitsCIB](
''	[fstrVisitID] [varchar](30) Not NULL,
''	[fdatSchedArrival] [datetime] NULL,
''	[fdatArrival] [datetime] NULL,
''	[fdatEstDeparture] [datetime] NULL,
''	[fdatDeparture] [datetime] NULL,
''	[fstrID] [varchar](30) NULL,
''	[fstrLastName] [varchar](30) NULL,
''	[fstrFirstName] [varchar](30) NULL,
''	[fstrCompany] [varchar](30) NULL,
''	[fstrPurpose] [varchar](30) NULL,
''	[fstrVisitorType] [varchar](30) NULL,
''	[fstrHost] [varchar](30) NULL,
''	[fstrHostPhone] [varchar](30) NULL,
''	[fstrStationIn] [varchar](30) NULL,
''	[fstrStationOut] [varchar](30) NULL,
'' CONSTRAINT [PK_tblVisitsCIB] PRIMARY KEY CLUSTERED 
''(
''	[fstrVisitID] ASC
'')WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
'') ON [PRIMARY]

Public Interface InterfaceCIVisit
    ''
    ''Added 10/2/2019 thomas downes  
    ''
    ''   The following is for CI Badge Visitor Management, shortenned to "CI Visitor".   
    ''
    Property fstrVisitID As String
    Property fdatSchedArrival As DateTime
    Property fdatArrival As DateTime
    Property fdatEstDeparture As DateTime
    Property fdatDeparture As DateTime
    Property fstrRecipientID As String
    Property fstrLastName As String
    Property fstrFirstName As String
    Property fstrCompany As String
    Property fstrPurpose As String
    Property fstrVisitorType As String
    Property fstrHost As String
    Property fstrHostPhone As String
    Property fstrStationIn As String
    Property fstrStationOut As String

End Interface
