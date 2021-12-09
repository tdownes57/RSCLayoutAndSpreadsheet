''
''Added 10/2/2019 thomas downes
''

Module modFactoryControls

    Public Enum EnumControlsMode

        Undetermined

        BadgeCard_Layout
        BadgeCard_Preview

        DataEntry_Support
        DataEntry_Design

    End Enum

    ''
    ''Added 12/8/2021 Thomas 
    ''
    Public Enum EnumWhichSideOfCard
        Undetermined
        EnumFrontside
        EnumBackside

    End Enum

    ''Public Function GetFieldControl_Generic(par_enum As EnumControlsMode) As ICtlElementFieldCtl


    ''Select Case par_enum

    ''    Case EnumControlsMode.BadgeCard_Layout

    ''              Return New CtLGraphicFieldCtl 


    ''  End Select  

    ''End Function




End Module
