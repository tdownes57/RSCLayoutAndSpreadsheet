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
Imports System.Drawing ''Added 1/26/2022 td

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

    Public Property Element_Type As Enum_ElementType = Enum_ElementType.__Desktop ''Added 1/21/2022 td 

    Private mod_dialogFile As New System.Windows.Forms.OpenFileDialog ''Added 1/19/2022 td

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
        Dim objSizeOfRSC As System.Drawing.Size ''Added 1/19/2022
        Dim obj_parametersGetElementControl As ClassGetElementControlParams ''Added 1/18/2022

        ''oCacheManager = Me.ParentDesignerForm.ElementsCache_PathToXML
        infoDesignerForm = Me.ParentDesignerForm

        ''intHeightOfRSC = infoDesignerForm.HeightAnyRSCMoveableControl()
        ''If (intHeightOfRSC = 0) Then
        ''    intHeightOfRSC = 24 ''A default height.  I checked  
        ''End If ''End of "If (intHeightOfRSC = 0) Then"
        objSizeOfRSC = infoDesignerForm.SizeAnyRSCMoveableControl()
        intHeightOfRSC = objSizeOfRSC.Height

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

            Dim sizeIfNeeded As New Size() ''Added 1/26/2022 td

            ''
            ''Next, create the control which will display the Element-StaticText.   
            ''
            objElementControl = CtlGraphicStaticText.GetStaticText(obj_parametersGetElementControl,
                                    objElementStaticText,
                                    MyBase.ParentForm,
                                    "CtlGraphicStaticText",
                                    CType(DesignerClass, ILayoutFunctions),
                                    sizeIfNeeded,
                                    .iRefreshPreview,
                                    .iControlLastTouched,
                                    .oMoveEventsGroupedControls)

        End With ''End of "With obj_parametersGetElementControl"

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
        objElementControl.BringToFront() ''Added 1/26/2022 td
        MyBase.ParentForm.Refresh() ''Added 1/26/2022 td

    End Sub ''End of "Public Sub Create_New_StaticText_Control_GD2001(sender As Object, e As MouseEventArgs)"


    Public Sub Create_New_Graphic_Control_GD2002(sender As Object, e As MouseEventArgs)
        ''
        ''Added 1/19/2022 thomas downes  
        ''
        Dim infoDesignerForm As IDesignerForm
        Dim objElementStaticGraphic As ciBadgeElements.ClassElementGraphic
        Dim objElementControl As CtlGraphicStaticGraphic
        ''Jan19 2022''Dim intHeightOfRSC As Integer
        ''Jan19 2022''Dim intWidthOfRSC As Integer
        Dim obj_parametersGetElementControl As ClassGetElementControlParams
        Dim objSize As System.Drawing.Size
        Dim objRect As System.Drawing.Rectangle
        ''Added 1/21/2022 thomas downes
        Dim objForm_Show As New FormPickGraphic
        Dim strPathToGraphicImage As String ''Added 1/22/2022 td
        Dim diag_result As DialogResult ''Added 1/22/2022 td
        Dim singleRatioWH As Single ''Added 1/22/2022 td

        Dim intImageWidth_Original As Integer ''Added 1/22/2022 td
        Dim intImageHeight_Original As Integer ''Added 1/22/2022 td
        Dim intImageWidth_Reduced As Integer ''Added 1/22/2022 td
        Dim intImageHeight_Reduced As Integer ''Added 1/22/2022 td

        Dim sizeGraphic As Size ''Added 1/26/2022 thomas downes

        ''Important function call.  Show the user the existing graphics files. 
        diag_result = objForm_Show.ShowDialog()
        strPathToGraphicImage = objForm_Show.PathToImageFileLocation

        If (diag_result = DialogResult.Cancel) Then
            ''Added 1/22/2022
            MessageBoxTD.Show_Statement("The user has cancelled, or hasn't selected a file.")
            Return
        ElseIf ("" = strPathToGraphicImage) Then
            ''Added 1/22/2022
            MessageBoxTD.Show_Statement("The user hasn't selected a file.")
            Return
        End If ''End of "If (diag_result = DialogResult.Cancel) Then ... ElseIf ..."

        strPathToGraphicImage = objForm_Show.PathToImageFileLocation
        singleRatioWH = objForm_Show.RatioWH
        intImageWidth_Original = objForm_Show.ImageWidth ''_Original
        intImageHeight_Original = objForm_Show.ImageHeight ''_Original

        infoDesignerForm = Me.ParentDesignerForm
        ''Jan19 2022''intHeightOfRSC = infoDesignerForm.HeightAnyRSCMoveableControl()
        ''Jan19 2022''intWidthOfRSC = infoDesignerForm.WidthAnyRSCMoveableControl()
        objSize = infoDesignerForm.SizeAnyRSCMoveableControl()

        ''Jan19 2022''If (intHeightOfRSC = 0) Then
        ''Jan19 2022''   intHeightOfRSC = 24 ''A default height.  I checked  
        ''Jan19 2022''End If ''End of "If (intHeightOfRSC = 0) Then"

        ''Jan19 2022''If (intWidthOfRSC = 0) Then
        ''Jan19 2022''   intWidthOfRSC = 24 ''A default height.  I checked  
        ''Jan19 2022''End If ''End of "If (intWidthOfRSC = 0) Then"

        Dim iMaxDimensionLengthRSC As Integer ''Added 1/22/2022 td
        iMaxDimensionLengthRSC = CInt(IIf(objSize.Height > objSize.Width, objSize.Height, objSize.Width))

        If (intImageHeight_Original > intImageWidth_Original) Then

            intImageHeight_Reduced = iMaxDimensionLengthRSC
            intImageWidth_Reduced = CInt(intImageHeight_Reduced * singleRatioWH)
        Else
            intImageWidth_Reduced = iMaxDimensionLengthRSC
            intImageHeight_Reduced = CInt(intImageWidth_Reduced / singleRatioWH)

        End If ''End of "If (intImageHeight_Original > intImageWidth_Original) Then ... Else ..."

        ''Jan19 2022''objRect = New System.Drawing.Rectangle(e.X, e.Y, intWidthOfRSC, intHeightOfRSC)
        objRect = New System.Drawing.Rectangle(e.X, e.Y,
                                               intImageWidth_Reduced,
                                               intImageHeight_Reduced)

        objElementStaticGraphic = New ClassElementGraphic(objRect,
                                                          Me.DesignerClass.BackgroundBox_Front,
                                                          strPathToGraphicImage)

        obj_parametersGetElementControl = DesignerClass.GetParametersToGetElementControl()

        objElementStaticGraphic.Visible = True

        With obj_parametersGetElementControl
            ''
            ''Next, apply the new element to the Backside or the Front, depending. 
            ''
            Dim bCardBackside As Boolean ''Added 1/18/2022 thomas d.
            bCardBackside = (Me.DesignerClass.EnumSideOfCard_Current =
                EnumWhichSideOfCard.EnumBackside)

            If (bCardBackside) Then
                ''Backside of ID Card. 
                objElementStaticGraphic.WhichSideOfCard = EnumWhichSideOfCard.EnumBackside
                With .ElementsCacheManager.CacheForEditing
                    .ListOfElementGraphics_Backside.Add(objElementStaticGraphic)
                End With
            Else
                ''Front of ID Card. 
                objElementStaticGraphic.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                With .ElementsCacheManager.CacheForEditing
                    .ListOfElementGraphics_Front.Add(objElementStaticGraphic)
                End With
            End If ''End of "If (bCardBackside) Then ... Else ... "

            ''
            ''Next, create the control which will display the Element-StaticText.   
            ''
            objElementControl = CtlGraphicStaticGraphic.GetStaticGraphic(obj_parametersGetElementControl,
                                    objElementStaticGraphic,
                                    MyBase.ParentForm,
                                    "CtlGraphicStaticGraphic",
                                    DesignerClass, sizeGraphic, True,
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

            ''Added 1/22/2022 thomas 
            ''  Let's make sure that the new element-control is not lurking behind the Background Boxes.
            With Me.DesignerClass
                If (bCardBackside) Then
                    .BackgroundBox_Backside.SendToBack()
                    .BackgroundBox_Front.SendToBack()
                    .BackgroundBox_JustAButton.SendToBack()
                Else
                    .BackgroundBox_Front.SendToBack()
                    .BackgroundBox_Backside.SendToBack()
                    .BackgroundBox_JustAButton.SendToBack()
                End If
            End With

        End With ''End of "With obj_parametersGetElementControl"

        ''
        ''Next, refresh/initiate the control (e.g. size & location & image).  
        ''
        ''Not needed, redundant. 1/18/2022 td''objElementControl.Refresh_Image(True)
        objElementControl.Refresh_Master()

        ''Added 1/26/2022 Thomas DOWNES 
        objElementControl.Visible = True
        objElementControl.BringToFront() ''Added 1/26/2022 td
        MyBase.ParentForm.Refresh() ''Added 1/26/2022 td

    End Sub ''End of "Public Sub Create_New_StaticText_Control_GD2001(sender As Object, e As MouseEventArgs)"


End Class
