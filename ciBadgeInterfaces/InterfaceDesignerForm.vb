''
''Added 1/15/2022 td
''
''Imports ciBadgeDesigner
''Imports ciBadgeInterfaces
''Imports ciBadgeCachePersonality ''Added 1/15/2022 td
Imports System.Windows.Forms ''Added 1/15/2022 td

Public Interface IDesignerForm_Desktop ''Suffixed with _Desktop on about 1/15/2022 td
    ''
    ''Added 1/15/2022 td
    ''
    Property MyText As String
    Property MyPictureBackgroundFront As PictureBox ''Added 1/15/2022 td 
    Property BadgeLayout As BadgeLayoutDimensionsClass

    Property NewFileXML As Boolean ''Added 1/7/2022 
    Property LetsRefresh_CloseForm As Boolean
    Property ElementsCache_PathToXML As String

    Function HeightAnyRSCMoveableControl() As Integer ''Added 1/18/2022 thomas d

    Sub ShowForm()
    Sub ShowForm_AsDialog()

    Sub RefreshPreview()

    ''Property ElementsCache_ManageBoth As ClassCacheManagement ''Added 1/07/2022
    ''Property ElementsCache_Edits As ClassElementsCache_Deprecated ''Added 1/07/2022 td 
    ''Property PersonalityCache_Recipients As ClassCachePersonality
    ''Sub RefreshElementsCache_Saved(par_cache As ClassElementsCache_Deprecated)


End Interface
