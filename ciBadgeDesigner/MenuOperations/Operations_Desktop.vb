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

    Public DesignerClass As ClassDesigner ''Added 1/18/2022 td
    ''Not needed. 1/18/2022 td''Public InfoRefreshPreview As IRefreshPreview ''Added 1/18/2022 td

    Public Sub Create_New_StaticText_Control_GD2001(sender As Object, e As MouseEventArgs)
        ''
        ''Added 1/16/2022 thomas downes  
        ''
        ''--Dim oCacheManager As ciBadgeCachePersonality.ClassCacheManagement
        ''--Dim oDesignerForm_Desktop As IDesignerForm_Desktop ''Added 1/18/2022

        Dim infoDesignerForm As IDesignerForm ''Added 1/18/2022
        Dim objElementStaticText As ciBadgeElements.ClassElementStaticText
        Dim objElementControl As CtlGraphicStaticText
        Dim intHeightOfRSC As Integer
        Dim obj_parametersGetElementControl As ClassGetElementControlParams ''Added 1/18/2022

        ''oCacheManager = Me.ParentDesignerForm.ElementsCache_PathToXML
        infoDesignerForm = Me.ParentDesignerForm

        intHeightOfRSC = infoDesignerForm.HeightAnyRSCMoveableControl()
        If (intHeightOfRSC = 0) Then
            intHeightOfRSC = 24 ''A default height.  I checked  
        End If ''End of "If (intHeightOfRSC = 0) Then"

        ''objElementStaticText = New ClassElementStaticText("New StaticText...", e.X, e.Y, 25)
        objElementStaticText = New ClassElementStaticText("New StaticText...", e.X, e.Y, intHeightOfRSC)
        obj_parametersGetElementControl = DesignerClass.GetParametersToGetElementControl()

        ''Added 1/18/2022 thomas downes  
        objElementStaticText.Visible = True
        objElementStaticText.Text_Static =
            InputBox("Enter the static text you want to appear.  You can revise it later.",
                     "Enter text", "Text for all ID Cards", e.X, e.Y)

        With obj_parametersGetElementControl
            ''
            ''Next, apply the new element to the Backside or the Front, depending. 
            ''
            Dim bCardBackside As Boolean ''Added 1/18/2022 thomas d.
            bCardBackside = (Me.DesignerClass.EnumSideOfCard_Current =
                EnumWhichSideOfCard.EnumBackside)

            If (bCardBackside) Then
                ''Backside of ID Card. 
                With .ElementsCacheManager.CacheForEditing
                    .ListOfElementTexts_Backside.Add(objElementStaticText)
                End With
            Else
                ''Front of ID Card. 
                With .ElementsCacheManager.CacheForEditing
                    .ListOfElementTexts_Front.Add(objElementStaticText)
                End With
            End If ''End of "If (bCardBackside) Then ... Else ... "

            ''
            ''Next, create the control which will display the Element-StaticText.   
            ''
            objElementControl = CtlGraphicStaticText.GetStaticText(obj_parametersGetElementControl,
                                    objElementStaticText,
                                    MyBase.ParentForm,
                                    "CtlGraphicStaticText",
                                    DesignerClass,
                                    .iRefreshPreview,
                                    .iControlLastTouched,
                                    .oMoveEventsGroupedControls)

            ''
            ''Next, refresh/initiate the control (e.g. size & location & image).  
            ''
            ''Not needed, redundant. 1/18/2022 td''objElementControl.Refresh_Image(True)
            objElementControl.Refresh_Master()

            ''
            ''Next, display the control.  ----1/18/2022 td
            ''
            MyBase.ParentForm.Controls.Add(objElementControl)
            objElementControl.Visible = True

        End With ''End of "With obj_parametersGetElementControl"

    End Sub ''End of "Public Sub Create_New_StaticText_Control_GD2001(sender As Object, e As MouseEventArgs)"


    Public Sub Create_New_Graphic_Control_GD2002(sender As Object, e As MouseEventArgs)
        ''
        ''Added 1/16/2022 thomas downes  
        ''

    End Sub


End Class
