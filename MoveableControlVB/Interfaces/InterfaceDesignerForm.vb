''
''Added 1/15/2022 td
''
Imports ciBadgeDesigner
Imports ciBadgeInterfaces
Imports ciBadgeCachePersonality ''Added 1/15/2022 td

Public Interface IDesignerForm
    ''
    ''Added 1/15/2022 td
    ''
    Property MyText As String
    Property MyPictureBackgroundFront As PictureBox ''Added 1/15/2022 td 
    Property BadgeLayout As BadgeLayoutClass

    Property ElementsCache_ManageBoth As ClassCacheManagement ''Added 1/07/2022
    Property ElementsCache_Edits As ClassElementsCache_Deprecated ''Added 1/07/2022 td 
    Property PersonalityCache_Recipients As ClassCachePersonality
    Property NewFileXML As Boolean ''Added 1/7/2022 
    Property LetsRefresh_CloseForm As Boolean
    Property ElementsCache_PathToXML As String

    Sub ShowForm()
    Sub ShowForm_AsDialog()

    Sub RefreshElementsCache_Saved(par_cache As ClassElementsCache_Deprecated)
    Sub RefreshPreview()



End Interface
