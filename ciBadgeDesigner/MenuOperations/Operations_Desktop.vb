﻿Option Explicit On
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


    Public Sub Context_Menu_GD9121(sender As Object, e As EventArgs)
        ''---Dec15 2021--Public Sub How_Context_Menus_Are_Generated_EE1001
        ''
        ''Added 3/22/2023 thomas downes  
        ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''
        Dim strPathToNotesFolder As String
        Dim strPathToNotesFileTXT As String

        strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
        strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
        System.Diagnostics.Process.Start(strPathToNotesFileTXT)

    End Sub ''end of "Public Sub Context_Menu_GD9121(sender As Object, e As EventArgs)"


    Public Sub Create_New_StaticText_Control_V3_GD2001(sender As Object, e As MouseEventArgs)
        ''
        ''Added 1/16/2022 thomas downes  
        ''
        ''--Dim oCacheManager As ciBadgeCachePersonality.ClassCacheManagement
        ''--Dim oDesignerForm_Desktop As IDesignerForm_Desktop ''Added 1/18/2022

        Dim infoDesignerForm As IDesignerForm ''Added 1/18/2022
        Dim objElementStaticText As ciBadgeElements.ClassElementStaticTextV3
        Dim objElementControl As CtlGraphicStaticTextV3
        Dim intHeightOfRSC As Integer
        Dim objSizeOfRSC As System.Drawing.Size ''Added 1/19/2022
        Dim obj_parametersGetElementControl As ClassGetElementControlParams ''Added 1/18/2022
        Dim badge_layout_dims As BadgeLayoutDimensionsClass ''Added 2/21/2023

        ''oCacheManager = Me.ParentDesignerForm.ElementsCache_PathToXML
        infoDesignerForm = Me.ParentDesignerForm

        ''intHeightOfRSC = infoDesignerForm.HeightAnyRSCMoveableControl()
        ''If (intHeightOfRSC = 0) Then
        ''    intHeightOfRSC = 24 ''A default height.  I checked  
        ''End If ''End of "If (intHeightOfRSC = 0) Then"
        objSizeOfRSC = infoDesignerForm.SizeAnyRSCMoveableControl()
        intHeightOfRSC = objSizeOfRSC.Height
        obj_parametersGetElementControl = DesignerClass.GetParametersToGetElementControl()
        ''Added 2/21/2023
        With obj_parametersGetElementControl.iLayoutFunctions
            ''Added 2/21/2023
            badge_layout_dims = New BadgeLayoutDimensionsClass(.Layout_Width_Pixels,
                                                               .Layout_Height_Pixels)
        End With ''ENd of "With obj_parametersGetElementControl.iLayoutFunctions"

        ''objElementStaticText = New ClassElementStaticText("New StaticText...", e.X, e.Y, 25)
        ''8/17/2022 objElementStaticText = New ClassElementStaticTextV3("New StaticText...", e.X, e.Y, intHeightOfRSC)
        objElementStaticText = New ClassElementStaticTextV3("New StaticText...",
                                                            e.X, e.Y,
                                                            intHeightOfRSC,
                                                            objSizeOfRSC.Width,
                                                            badge_layout_dims)

        ''Moved up. 2/2023''obj_parametersGetElementControl = DesignerClass.GetParametersToGetElementControl()

        ''Added 1/18/2022 thomas downes  
        objElementStaticText.Visible = True
        objElementStaticText.Text_StaticLine =
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
                    .ListOfElementTextsV3_Backside.Add(objElementStaticText)
                End With
            Else
                ''Front of ID Card. 
                With .ElementsCacheManager.CacheForEditing
                    .ListOfElementTextsV3_Front.Add(objElementStaticText)
                End With
            End If ''End of "If (bCardBackside) Then ... Else ... "

            Dim sizeIfNeeded As New Size() ''Added 1/26/2022 td

            ''
            ''Next, create the control which will display the Element-StaticText.   
            ''
            objElementControl = CtlGraphicStaticTextV3.GetStaticText(obj_parametersGetElementControl,
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


    End Sub ''End of "Public Sub Create_New_StaticText_V3_Control_GD2001(sender As Object, e As MouseEventArgs)"


    Public Sub Create_New_StaticText_Control_V4_GD2001(sender As Object, e As MouseEventArgs)
        ''
        ''Added 1/16/2022 thomas downes  
        ''
        ''--Dim oCacheManager As ciBadgeCachePersonality.ClassCacheManagement
        ''--Dim oDesignerForm_Desktop As IDesignerForm_Desktop ''Added 1/18/2022

        Dim infoDesignerForm As IDesignerForm ''Added 1/18/2022
        Dim objElementStaticTextV4 As ciBadgeElements.ClassElementStaticTextV4
        Dim objElementControl As CtlGraphicStaticTextV4
        Dim intHeightOfRSC As Integer
        Dim objSizeOfRSC As System.Drawing.Size ''Added 1/19/2022
        Dim obj_parametersGetElementControl As ClassGetElementControlParams ''Added 1/18/2022

        infoDesignerForm = Me.ParentDesignerForm
        objSizeOfRSC = infoDesignerForm.SizeAnyRSCMoveableControl()
        intHeightOfRSC = objSizeOfRSC.Height

        objElementStaticTextV4 = New ClassElementStaticTextV4() ''"New StaticText...", e.X, e.Y, intHeightOfRSC)

        ''Added 1/31/2022 td
        With objElementStaticTextV4

            .Text_StaticLine = "New static text...."
            .TopEdge_Pixels = e.Y
            .LeftEdge_Pixels = e.X
            .Height_Pixels = intHeightOfRSC

            .FontSize_AutoScaleToElementYesNo = True ''Added 2/2/2022 td
            .FontSize_AutoScaleToElementRatio = 0.8 ''Added 2/2/2022 td
            .FontSize_AutoSizePromptUser = True ''Added 6/02/2022 td

            obj_parametersGetElementControl = DesignerClass.GetParametersToGetElementControl()

            ''Added Feb. 2, 2022 thomas downes
            .BadgeLayout = obj_parametersGetElementControl.DesignerClass.BadgeLayout_Class

        End With

        ''Added 1/18/2022 thomas downes  
        objElementStaticTextV4.Visible = True
        objElementStaticTextV4.Text_StaticLine =
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
                    .ListOfElementTextsV4_Backside.Add(objElementStaticTextV4)
                End With
            Else
                ''Front of ID Card. 
                With .ElementsCacheManager.CacheForEditing
                    .ListOfElementTextsV4_Front.Add(objElementStaticTextV4)
                End With
            End If ''End of "If (bCardBackside) Then ... Else ... "

            Dim sizeIfNeeded As New Size() ''Added 1/26/2022 td

            ''
            ''Next, create the control which will display the Element-StaticText.   
            ''
            objElementControl = CtlGraphicStaticTextV4.GetStaticTextControl(obj_parametersGetElementControl,
                                    objElementStaticTextV4,
                                    MyBase.ParentForm,
                            obj_parametersGetElementControl.DesignerClass,
                                    "CtlGraphicStaticText",
                                    CType(DesignerClass, ILayoutFunctions),
                                    sizeIfNeeded,
                                    obj_parametersGetElementControl.iRecordElemLastTouched,
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

        ''5/14/2022 objElementStaticGraphic = New ClassElementGraphic(objRect,
        ''                                                  Me.DesignerClass.BackgroundBox_Front,
        ''                                                  strPathToGraphicImage)
        objElementStaticGraphic = New ClassElementGraphic(objRect,
                                                          Me.DesignerClass.BadgeLayout_Class,
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
            ''4/2/2023 objElementControl = CtlGraphicStaticGraphic.GetStaticGraphic(obj_parametersGetElementControl,
            ''4/2/2023           objElementStaticGraphic,
            ''                   MyBase.ParentForm,
            ''                        "CtlGraphicStaticGraphic",
            ''                        DesignerClass, sizeGraphic, True,
            ''                        .iControlLastTouched,
            ''                        .oMoveEventsGroupedControls)
            objElementControl = CtlGraphicStaticGraphic.GetStaticGraphic(obj_parametersGetElementControl,
                                    objElementStaticGraphic, .oMoveEventsGroupedControls, sizeGraphic,
                                    True)

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
