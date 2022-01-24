''Jan23 2022 td''Module ModuleStructs
''
''End Module

Public Enum EnumOmitReasons
    ''
    ''Added 1/23/2022 td 
    ''
    _Undetermined
    IrrelevantField ''The field is not flagged as Relevant by the PersonalityConfiguration.
    InvisibleElement ''Visible = False 
    NullImage ''Image is Null and/or not supplied. 
    OutlyingCoordinateX ''The X-value (for the TopLeft corner; i.e. property Left) is outside the bounds of the badge. 
    OutlyingCoordinateY ''The Y-value (for the TopLeft corner; i.e. property Top) is outside the bounds of the badge. 
    OutlyingEdgeBottom ''The Bottom Edge is outside the bounds of the badge. 
    OutlyingEdgeRight ''The Right Edge is outside the bounds of the badge. 
    UnbadgedField ''The field has not been designated as "Displayed on Badge" by the Personality Configuration
    ZeroWidth  ''This is self-explanatory. The Width property is zero.
    ZeroHeight  ''This is self-explanatory. The Height property is zero.

End Enum


Public Structure WhyOmitted_StructV2 ''Added 11/10/2021 thomas downes
    ''Jan23 2022 thomas d''Public Structure WhyOmitted
    ''
    ''Moved from library/namespace CIBadgeElements on 1/23/2022.
    ''
    '' 1/23/2022 Dim NotRelevantField As Boolean ''Added 11/24/2021
    '' 1/23/2022 Dim OmitElement As Boolean
    '' 1/23/2022 Dim ElementVisibleIsFalse As Boolean ''Added 12/6/2021 
    '' 1/23/2022 Dim OmitField As Boolean
    '' 1/23/2022 Dim OmitCoordinateX As Boolean
    '' 1/23/2022 Dim OmitCoordinateY As Boolean
    '' 1/23/2022 Dim OmitWidth As Boolean
    '' 1/23/2022 Dim OmitHeight As Boolean

    Dim __Omitted As Boolean ''Added 1/23/2022 td

    Dim OmitIrrelevantField As Boolean ''Dim NotRelevantField  ''Renamed 1/23/2022  ''Added 11/24/2021
    '' 1/23/2022 Dim OmitElement As Boolean
    Dim OmitInvisibleElement As Boolean ''Dim ElementVisibleIsFalse  ''Renamed 1/23/2022  ''Added 12/6/2021 
    Dim OmitNullImage As Boolean ''Added 1/23/2022 td

    Dim OmitOutlyingCoordinateX As Boolean ''Dim OmitCoordinateX  ''Renamed 1/23/2022
    Dim OmitOutlyingCoordinateY As Boolean ''Dim OmitCoordinateY  ''Renamed 1/23/2022
    Dim OmitOutlyingEdgeBottom As Boolean ''Added 1/24/2022 td
    Dim OmitOutlyingEdgeRight As Boolean ''Added 1/24/2022 td

    Dim OmitUnbadgedField As Boolean ''Dim OmitField As Boolean ''Renamed 1/23/2022
    ''Not needed??''Dim OmitElement As Boolean ''Renamed 1/23/2022
    Dim OmitZeroWidth As Boolean ''Dim OmitWidth as Boolean ''Prefixed w/ "Zero" 1/23/2022
    Dim OmitZeroHeight As Boolean ''Dim OmitHeight as Boolean ''Prefixed w/ "Zero" 1/23/2022

    Dim EnumOmitReason As EnumOmitReasons ''Added 1/23/2022

    Dim DateOmittedCreated As Date ''Added 1/23/2022 td
    Dim DateOmittedUpdated As Date ''Added 1/23/2022 td

    ''Dim increment1 = Function(x As Integer) x + 1
    ''==Const OmitElement_Msg As String = " (Element Property not flagged as True)"
    ''==Const OmitField_Msg As String = " (Field Property not flagged as True)"
    Public Function NotRelevantMsg() As String
        ''Added 11/24/2021 
        ''Jan23 2022 td''If (NotRelevantField) Then Return " (Field not relevant to Personality)"
        If (OmitIrrelevantField) Then Return " (Field not relevant to Personality)"
        Return ""
    End Function
    Public Function OmitElementMsg() As String
        ''Jan23 2022 td''If (OmitElement) Then Return " (Element Property not flagged as True)"
        If (OmitInvisibleElement) Then Return " (Element is Invisible and/or Removed)"
        Return ""
    End Function
    Public Function OmitFieldMsg() As String
        If (OmitIrrelevantField) Then Return " (Field is Irrelevant or Unbadged)"
        Return ""
    End Function

    Public Sub SetDateTime(Optional par_datetime As Date = #1/1/2001#)
        ''Added 1/23/2022 td
        If (par_datetime = #1/1/2001#) Then par_datetime = DateTime.Now

        If (DateOmittedCreated.Year > 2020) Then
            DateOmittedUpdated = par_datetime
        Else
            DateOmittedCreated = par_datetime
            DateOmittedUpdated = par_datetime
        End If
    End Sub ''End of "Public Sub SetDateTime()"

End Structure ''End of "Public Structure WhyOmitted_StructV2"


''Dim OmitIrrelevantField As Boolean ''Dim NotRelevantField  ''Renamed 1/23/2022  ''Added 11/24/2021
''Dim OmitInvisibleElement As Boolean ''Dim ElementVisibleIsFalse  ''Renamed 1/23/2022  ''Added 12/6/2021 
''Dim OmitNullImage As Boolean ''Added 1/23/2022 td
''Dim OmitOutlyingCoordinateX As Boolean ''Dim OmitCoordinateX  ''Renamed 1/23/2022
''Dim OmitOutlyingCoordinateY As Boolean ''Dim OmitCoordinateY  ''Renamed 1/23/2022
''Dim OmitUnbadgedField As Boolean ''Dim OmitField As Boolean ''Renamed 1/23/2022
''''Not needed??''Dim OmitUnbadgedElement As Boolean ''Renamed 1/23/2022
''Dim OmitZeroWidth As Boolean ''Dim OmitWidth as Boolean ''Prefixed w/ "Zero" 1/23/2022
''Dim OmitZeroHeight As Boolean ''Dim OmitHeight as Boolean ''Prefixed w/ "Zero" 1/23/2022



