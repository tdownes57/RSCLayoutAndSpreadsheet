Option Explicit On ''Added 9/6/2022 td
Option Strict On ''Added 9/6/2022 td
''
''Added 9/6/2022 td
''
''9/2/2022 Public Module StructureWhyOmitted
''
''Added 9/6/2022 td
''
#Disable Warning CA1707 ''Warning is "Remove underscores."
#Disable Warning CA1051 ''Warning is "Do not declare public instance variables."

Public Structure WhyOmitted_StructV1 ''Added 11/10/2021 thomas downes
        ''----Public Structure WhyOmitted ''Added 11/10/2021 thomas d.
        ''
        ''As of 1/23/2022, this Public Structure is defined in library CIBadgeElements. 
        ''
        ''See library CIBadgeInterfaces for Public Structure WhyOmitted_StructV2.  ----1/23/2022 TD
        ''
        Public NotRelevantField As Boolean ''Added 11/24/2021
        Public OmitElement As Boolean
        Public ElementVisibleIsFalse As Boolean ''Added 12/6/2021 
        Public OmitField As Boolean
        Public OmitCoordinateX As Boolean
        Public OmitCoordinateY As Boolean
        Public OmitWidth As Boolean
        Public OmitHeight As Boolean

        ''Dim increment1 = Function(x As Integer) x + 1
        ''==Const OmitElement_Msg As String = " (Element Property not flagged as True)"
        ''==Const OmitField_Msg As String = " (Field Property not flagged as True)"
        Public Function NotRelevantMsg() As String
            ''Added 11/24/2021 
            ''Jan23 2022 td''If (NotRelevantField) Then Return " (Field not relevant to Personality)"
            If (OmitField) Then Return " (Field not relevant to Personality)"
            Return ""
        End Function
        Public Function OmitElementMsg() As String
            ''Jan23 2022 td''If (OmitElement) Then Return " (Element Property not flagged as True)"
            If (OmitElement) Then Return " (Element Property not flagged as True)"
            Return ""
        End Function
        Public Function OmitFieldMsg() As String
            If (OmitField) Then Return " (Field Property not flagged as True)"
            Return ""
        End Function

    ''
    ''For this commented procedure (Public Sub SetDateTime), please see library CIBadgeInterfaces,
    ''    Public Structure WhyOmitted_StructV2.----1/23/2022 td
    ''
    ''1/23/2022 TD''Public Sub SetDateTime(par_datetime As Date)
    ''    ''Added 1/23/2022 td
    ''    If (DateOmittedCreated.Year > 2020) Then
    ''        DateOmittedUpdated = par_datetime
    ''    Else
    ''        DateOmittedCreated = par_datetime
    ''        DateOmittedUpdated = par_datetime
    ''    End If
    ''End Sub ''End of "Public Sub SetDateTime()"

    ''Added 3/18/2023  
    Public Overrides Function Equals(obj As Object) As Boolean
        ''Added 3/18/2023  
        Return False ''MyBase.Equals(obj)
    End Function



End Structure ''End of "Public Structure WhyOmitted_StructV1"



''9/2/2022 End Module
