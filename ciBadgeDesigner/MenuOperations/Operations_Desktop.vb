Option Explicit On
Option Strict On
Option Infer Off

''
''Added 1/16/2022 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 
Imports ciBadgeCachePersonality ''Added 1/18/2022 td

''
'' Added 1/16/2022 thomas downes
''
Public Class Operations_Desktop
    Inherits Operations__Desktop_Dummy
    ''Jan17 2022 ''Implements ICurrentElement ''Added 12/28/2021 td
    ''
    '' Added 1/16/2022 thomas downes
    ''
    ''Jan17 2022 ''Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement

    Public Sub Create_New_StaticText_Control_GD2001(sender As Object, e As MouseEventArgs)
        ''
        ''Added 1/16/2022 thomas downes  
        ''
        ''Dim oCacheManager As ciBadgeCachePersonality.ClassCacheManagement
        ''Dim oDesignerForm_Desktop As IDesignerForm_Desktop ''Added 1/18/2022
        Dim infoDesignerForm As IDesignerForm ''Added 1/18/2022
        Dim objElementStaticText As ciBadgeElements.ClassElementStaticText
        Dim objElementControl As CtlGraphicStaticText
        Dim intHeightOfRSC As Integer

        ''oCacheManager = Me.ParentDesignerForm.ElementsCache_PathToXML
        infoDesignerForm = Me.ParentDesignerForm

        intHeightOfRSC = infoDesignerForm.HeightAnyRSCMoveableControl()
        If (intHeightOfRSC = 0) Then
            intHeightOfRSC = 24 ''A default height.  I checked  
        End If

        ''objElementStaticText = New ClassElementStaticText("New StaticText...", e.X, e.Y, 25)
        objElementStaticText = New ClassElementStaticText("New StaticText...", e.X, e.Y, intHeightOfRSC)

        objElementControl = CtlGraphicStaticText.GetStaticText(obj_parametersGetElementControl,
                                                               objElementStaticText,
                                                               MyBase.ParentForm,
                                                               "CtlGraphicStaticText",
                                                               MyBase.EventsForMoveability_Group)


    End Sub


    Public Sub Create_New_Graphic_Control_GD2002(sender As Object, e As MouseEventArgs)
        ''
        ''Added 1/16/2022 thomas downes  
        ''

    End Sub


End Class
