Option Explicit On
Option Infer Off
Option Strict On

''
''Added 7/18/2019 Thomas DOWNES
''
Imports ControlManager
Imports MoveAndResizeControls_Monem
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d.  
Imports ciLayoutPrintLib ''Added 8/28/2019 thomas d. 

Public Class FormDesignProtoTwo
    Implements ISelectingElements
    ''
    ''Added 7/18/2019 Thomas DOWNES
    ''
    ''#1 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls_NA As New MoveAndResizeControls_Monem.ControlMove_RaiseEvents ''Added 8/3/2019 td  
    '' #2 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls As New MoveAndResizeControls_Monem.ControlMove_GroupMove ''Added 8/3/2019 td  
    Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove

    Private Const mc_boolAllowGroupMovements As Boolean = True ''False ''True ''False ''Added 8/3/2019 td  

    ''Added 8/18/2019 td
    Private mod_imageLady As Image ''8/18/2019 td'' = CtlGraphicPortrait_Lady.picturePortrait.Image

    ''Private mod_generator As LayoutElementGenerator

    ''Private mod_Pic As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Logo As IElement ''Added 7/18/2019 thomas downes 

    ''Private mod_NameFull As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_RecipientID As IElement ''Added 7/18/2019 thomas downes 

    ''Private mod_Text1 As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Text2 As IElement
    ''Private mod_Text3 As IElement
    ''Private mod_Text4 As IElement
    ''Private mod_Text5 As IElement
    ''Private mod_Text6 As IElement
    ''Private mod_Text7 As IElement
    ''Private mod_Text8 As IElement

    ''Private mod_Date1 As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Date2 As IElement
    ''Private mod_Date3 As IElement

    Private vbCrLf_Deux As String = (vbCrLf & vbCrLf) ''Added 7/31/2019 td 

    Public Function LayoutWidth() As Integer
        ''
        ''Added 9/3/2019 thomas downes
        ''
        Return pictureBack.Width

    End Function ''End of "Public Function LayoutWidth() As Integer"

    Public Function OkayToShowFauxContextMenu() As Boolean
        ''
        ''Added 8/14/2019 td 
        ''
        ''OkayToShowFauxContextMenu()
        Return DemoModeActiveToolStripMenuItem.Checked

    End Function ''End of "Public Function OkayToShowFauxContextMenu() As Boolean"

    Private Sub FormDesignProtoTwo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        LoadElementGenerator()

        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel1)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel2)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel3)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel4)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel5)

        ''7/31/2019 td''Me.Controls.Remove(pictureboxPic) ''Added 7/31/2019 thomas d. 
        mod_imageLady = CtlGraphicPortrait_Lady.picturePortrait.Image

        Me.Controls.Remove(CtlGraphicPortrait_Lady) ''Added 7/31/2019 thomas d. 

        ''Encapsulated 7/31/2019 td
        Load_Form()

        ''Added 8/11/2019 thomas d.
        ''
        graphicAdjuster.SendToBack()
        picturePreview.SendToBack()
        pictureBack.SendToBack()

        ResizeLayoutBackgroundImage_ToFitPictureBox() ''Added 8/25/2019 td
        RefreshPreview() ''Added 8/24/2019 td

    End Sub ''End of "Private Sub FormDesignProtoTwo_Load"

    Private Sub ResizeLayoutBackgroundImage_ToFitPictureBox()
        ''
        ''Added 8/25/2019 td 
        ''
        Dim obj_image As Image ''Added 8/24 td
        ''Dim obj_image_clone As Image ''Added 8/24 td
        Dim obj_image_clone_resized As Image ''Added 8/24/2019 td

        ''Added 8/24/2019 td
        obj_image = pictureBack.Image

        ''obj_image_clone = CType(obj_image.Clone(), Image)

        ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)

        ''8/25/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image,
        ''                       pictureBack.Height)

        ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToWidth(obj_image,
        ''8/26/2019 td''       pictureBack.Width)

        obj_image_clone_resized = LayoutPrint.ResizeBackground_ToFitBox(obj_image, pictureBack, True)

        pictureBack.Image = obj_image_clone_resized

    End Sub ''End of Sub ResizeLayoutBackgroundImage()

    Private Sub Load_Form()
        ''
        ''Encapsulated 7/31/2019 td
        ''
        ''7/31/2019 td''LoadElements()
        ''8/28/2019 td''LoadElements_Fields()
        Const c_boolLoadingForm As Boolean = True ''Added 8/28/2019 thomas downes  

        ''9/3/2019 td''LoadElements_Fields(c_boolLoadingForm)
        LoadElements_Fields_Master(c_boolLoadingForm)

        ''Added 7/31/2019 td  
        LoadElements_Picture()

        MakeElementsMoveable()

        ''Added 7/28/2019 td
        ''    Make sure that the Badge Background is in the background. 
        ''
        pictureBack.SendToBack()
        graphicAdjuster.SendToBack() ''Added 8/12/2019 td
        picturePreview.SendToBack() ''Added 8/12/2019 td

    End Sub ''ENd of "Private Sub Load_Form()"

    Private Sub MakeElementsMoveable()
        ''
        ''Added 7/19/2019 thomas downes  
        ''
        ''8/4/2019 td''Dim boolAllowGroupMovements As Boolean = False ''True ''False ''Added 8/3/2019 td  
        ''
        ''Portrait
        ''
        If (mc_boolAllowGroupMovements) Then

            ControlMove_GroupMove.Init(CtlGraphicPortrait_Lady.Picture_Box,
                      CtlGraphicPortrait_Lady, 10, True, mod_groupedMove) ''Added 8/3/2019 thomas downes
        Else
            ControlMoverOrResizer_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
                  CtlGraphicPortrait_Lady, 10, True) ''Added 7/31/2019 thomas downes

        End If ''End of " If (mc_boolAllowGroupMovements) Then .... Else ...."

        ''
        ''Fields
        ''
        Dim each_graphicLabel As CtlGraphicFldLabel ''Added 7/19/2019 thomas downes  

        For Each each_control As Control In Me.Controls ''Added 7/19/2019 thomas downes  

            If (TypeOf each_control Is CtlGraphicFldLabel) Then

                each_graphicLabel = CType(each_control, CtlGraphicFldLabel)

                ''7/31/2019 td''ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
                ''                each_control, 10) ''Added 7/28/2019 thomas downes

                Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td 

                If (mc_boolAllowGroupMovements) Then
                    ControlMove_GroupMove.Init(each_graphicLabel.Picture_Box,
                          each_control, 10, c_bRepaintAfterResize, mod_groupedMove) ''Added 8/3/2019 td 
                Else
                    ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
                          each_control, 10, c_bRepaintAfterResize) ''Added 7/28/2019 thomas downes
                End If ''End of "If (boolAllowGroupMovements) Then ...... Else ..."

            End If ''End of "If (TypeOf each_control Is GraphicFieldLabel) Then"

        Next each_control

    End Sub ''End of "Private Sub MakeElementsMoveable()"

    Private Sub LoadElements_Picture()
        ''
        ''Added 7/31/2019 thomas downes 
        ''
        ''7/31 td''Dim new_picControl As CtlGraphicPortrait ''Added 7/31/2019 td  

        ''Added 8/22/2019 THOMAS D.
        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        If (ClassElementPic.ElementPicture Is Nothing) Then

            ClassElementPic.ElementPicture = New ClassElementPic

            With ClassElementPic.ElementPicture

                .Width = CtlGraphicPortrait_Lady.Width
                .Height = CtlGraphicPortrait_Lady.Height

                .TopEdge = CtlGraphicPortrait_Lady.Top
                .LeftEdge = CtlGraphicPortrait_Lady.Left

                ''Added 8/12/2019 td
                Dim bSwitchWidthHeight As Boolean ''Added 8/12/2019 td
                bSwitchWidthHeight = ("L" = ClassElementPic.ElementPicture.OrientationToLayout)

                ''Added 8/12/2019 td
                ''Switch width & height.  
                If (bSwitchWidthHeight) Then
                    ''Switch width & height.  
                    .Width = CtlGraphicPortrait_Lady.Height
                    .Height = CtlGraphicPortrait_Lady.Width
                End If ''End of "If (bSwitchWidthHeight) Then"

            End With ''End of "With field_standard.ElementInfo"

        End If ''End of "If (ClassElementPic.ElementPicture Is Nothing) Then"

        ''#1 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture)
        '' #2 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
        ''      CType(ClassElementPic.ElementPicture, IElementPic))
        '' #2 7/31/2019 td''Me.Controls.Add(new_picControl)

        ''
        ''DIFFICULT & CONFUSING.....  Let's regenerate the control referenced above.  
        ''
        CtlGraphicPortrait_Lady = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
                                                 CType(ClassElementPic.ElementPicture, IElementPic), Me)

        Me.Controls.Add(CtlGraphicPortrait_Lady)

        With CtlGraphicPortrait_Lady

            .Top = ClassElementPic.ElementPicture.TopEdge
            .Left = ClassElementPic.ElementPicture.LeftEdge
            .Width = ClassElementPic.ElementPicture.Width
            .Height = ClassElementPic.ElementPicture.Height

            ''Added 8/18/2019 td
            .picturePortrait.Image = mod_imageLady

        End With ''End of "With CtlGraphicPortrait1"

    End Sub ''End of " Private Sub LoadElements_Picture()"

    Private Sub LoadElements_Fields_Master(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
        ''
        ''Added 9/03/2019 thomas downes 
        ''
        Const c_boolUseConsolidatedList As Boolean = True ''False ''True

        If (c_boolUseConsolidatedList) Then

            ''9/4/2019 td''LoadElements_Fields_OneList(par_boolLoadingForm, par_bUnloading)
            LoadElements_Fields_OneList(par_boolLoadingForm, par_bUnloading, Me.LayoutWidth())

        Else

            LoadElements_Fields_TwoLists(par_boolLoadingForm, par_bUnloading)

        End If ''End of "If (c_boolUseConsolidatedList) Then ..... Else ...."

    End Sub ''ENd of "Private Sub LoadElements_Fields_Master()"

    Private Sub LoadElements_Fields_OneList(par_boolLoadingForm As Boolean,
                                            Optional par_bUnloading As Boolean = False,
                                            Optional par_widthOfLayout As Integer = 0)
        ''
        ''Added 9/03/2019 thomas downes 
        ''
        Dim intCountControlsAdded As Integer ''Added 9/03/2019 td 
        Dim intTopEdge As Integer ''Added 7/28/2019 td
        Dim intLeftEdge As Integer ''Added 9/03/2019 td
        Dim boolIncludeOnBadge As Boolean ''Added 9/03/2019 td

        For Each each_field As ICIBFieldStandardOrCustom In ClassFields.ListAllFields()

            Dim label_control As CtlGraphicFldLabel

            ''Added 9/3/2019 thomas d. 
            boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)
            If (Not boolIncludeOnBadge) Then Continue For

            ''
            ''Has the user moved the field into place (and pressed the Save & Refresh link)??
            ''
            If (each_field.ElementInfo_Base Is Nothing) Then

                Dim new_element_text As New ClassElementText

                each_field.ElementInfo_Base = new_element_text
                each_field.ElementInfo_Text = new_element_text

                ''#1 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
                '' #2 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, new_element_text, Me)
                label_control = New CtlGraphicFldLabel(each_field, Me, new_element_text)

                ''If (par_boolLoadingForm) Then
                ''    Me.Controls.Add(label_control)
                ''ElseIf (par_bUnloading) Then
                ''    ''9/3/2019 td''Me.Controls.Remove(label_control)
                ''    Throw New NotImplementedException
                ''End If

                ''9/4/2019 td''label_control.Width = CInt(pictureBack.Width / 3)
                label_control.Width = CInt(par_widthOfLayout / 3)

                With each_field.ElementInfo_Base

                    .Width_Pixels = label_control.Width
                    .Height_Pixels = label_control.Height

                    intTopEdge = (30 + (30 * intCountControlsAdded))
                    intLeftEdge = intTopEdge ''Left = Top !! By setting Left = Top, we will create 
                    ''   a nice diagonally-cascading effect. ---9/3/2019 td

                    .TopEdge_Pixels = intTopEdge
                    .LeftEdge_Pixels = intLeftEdge

                    ''Added 9/4/2019 td
                    .LayoutWidth_Pixels = par_widthOfLayout

                End With ''End of "With field_standard.ElementInfo"

            Else

                label_control = New CtlGraphicFldLabel(each_field, Me)

                ''If (par_boolLoadingForm) Then
                ''    Me.Controls.Add(label_control)
                ''ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
                ''    ''Added 8/28/2019 thomas downes 
                ''    ''9/3/2019 td''Me.Controls.Remove(label_control)
                ''    Throw New NotImplementedException
                ''End If ''End of "If (par_boolLoadingForm) Then .... ElseIf ....."

                ''Moved far below. ''new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

            End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

            ''Added 9/3/2019 thomas downes
            ''   Start from the Layout Background's TopLeft corner. 
            ''
            label_control.Top = pictureBack.Top
            label_control.Left = pictureBack.Left

            ''Added 9/3/2019 thomas downes
            ''   Move into position from the Layout Background's TopLeft corner. 
            ''
            label_control.Top += each_field.ElementInfo_Base.TopEdge_Pixels
            label_control.Left += each_field.ElementInfo_Base.LeftEdge_Pixels

            label_control.Width = each_field.ElementInfo_Base.Width_Pixels
            label_control.Height = each_field.ElementInfo_Base.Height_Pixels

            label_control.Visible = each_field.IsDisplayedOnBadge ''BL = Badge Layout

            intCountControlsAdded += 1

            label_control.Name = "FieldControl" & CStr(intCountControlsAdded)
            label_control.BorderStyle = BorderStyle.FixedSingle

            boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)

            If (boolIncludeOnBadge) Then

                Me.Controls.Add(label_control)
                label_control.Visible = True
                label_control.RefreshImage()
                label_control.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

            ElseIf (par_bUnloading) Then
                ''9/3/2019 td''Me.Controls.Remove(label_control)
                Throw New NotImplementedException

            End If ''End of "If (boolInludeOnBadge) Then .... ElseIf (....) ...."

        Next each_field

        ''
        ''Added 8/27/2019 thomas downes
        ''
        Me.Refresh() ''Added 8/28/2019 td   

        MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of ''Private Sub LoadElements_Fields_OneList()''

    Private Sub LoadElements_Fields_TwoLists(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        ''mod_Pic = New ClassElementPic(pictureboxPic)

        ''mod_RecipientID = mod_generator.GetRecipientID(GraphicFieldLabel1) ''New ClassElementText
        ''mod_NameFull = mod_generator.GetFullName(GraphicFieldLabel2) ''New ClassElementText

        ''mod_Text1 = mod_generator.GetTextField1(gr) ''New ClassElementText
        ''mod_Text2 = mod_generator.GetTextField2(PictureBox13) ''New ClassElementText
        ''mod_Text3 = mod_generator.GetTextField3(PictureBox14)

        ''mod_Date1 = mod_generator.GetDateField1(PictureBox15) ''New ClassElementText
        ''mod_Date2 = mod_generator.GetDateField2(PictureBox16) ''New ClassElementText

        Dim intNumControlsAlready_std As Integer ''Added 7/26/2019 td 
        Dim intNumControlsAlready_cust As Integer ''Added 7/26/2019 td 
        ''7/31 td''Dim intTopEdge_cust As Integer ''Added 7/28/2019 td
        Dim intTopEdge_std As Integer ''Added 7/28/2019 td

        Dim intCountControlsAdded As Integer ''Added 8/27/2019 td 
        Dim boolIncludeOnBadge As Boolean ''Added 9/03/2019 td

        ''
        ''Standard Fields 
        ''
        ClassFieldStandard.InitializeHardcodedList_Students(True)

        For Each each_field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

            Dim new_label_control_std As CtlGraphicFldLabel

            ''Added 9/3/2019 thomas d. 
            boolIncludeOnBadge = (par_boolLoadingForm And each_field_standard.IsDisplayedOnBadge)
            If (Not boolIncludeOnBadge) Then Continue For

            ''Added 7/29
            If (each_field_standard.ElementInfo Is Nothing) Then

                each_field_standard.ElementInfo = New ClassElementText()

                ''8/9/2019 td''new_label_control_std = New CtlGraphicFldLabel(field_standard)
                new_label_control_std = New CtlGraphicFldLabel(each_field_standard, Me)

                ''8/28/2019 td''Me.Controls.Add(new_label_control_std)
                If (par_boolLoadingForm) Then
                    Me.Controls.Add(new_label_control_std)
                ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
                    ''Added 8/28/2019 thomas downes 
                    Me.Controls.Remove(new_label_control_std)
                End If

                intCountControlsAdded += 1 ''Added 8/27/2019 td

                ''Moved far below. ''new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

                new_label_control_std.Width = CInt(pictureBack.Width / 3)

                With each_field_standard.ElementInfo

                    .Width_Pixels = new_label_control_std.Width
                    .Height_Pixels = new_label_control_std.Height

                    intTopEdge_std = (30 + 30 * intNumControlsAlready_std)
                    .TopEdge_Pixels = intTopEdge_std
                    .LeftEdge_Pixels = intTopEdge_std ''((10 + intNumControlsAlready_std * .Width_Pixels) + 10)

                End With ''End of "With field_standard.ElementInfo"

            Else

                ''Added 8/9/2019 td''new_label_control_std = New CtlGraphicFldLabel(field_standard)
                new_label_control_std = New CtlGraphicFldLabel(each_field_standard, Me)

                ''8/28/2019 td''Me.Controls.Add(new_label_control_std)
                intCountControlsAdded += 1 ''Added 8/27/2019 td

                If (par_boolLoadingForm) Then
                    Me.Controls.Add(new_label_control_std)
                ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
                    ''Added 8/28/2019 thomas downes 
                    Me.Controls.Remove(new_label_control_std)
                End If ''End of "If (par_boolLoadingForm) Then ... ElseIf ...."

                ''Moved far below. ''new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

            End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

            ''Added 9/3/2019 thomas downes
            ''   Start from the Layout Background's TopLeft corner. 
            ''
            With new_label_control_std

                ''Start from the Layout Background's TopLeft corner. ---9/3/2019 td
                .Top = pictureBack.Top
                .Left = pictureBack.Left

                .Top += each_field_standard.ElementInfo.TopEdge_Pixels
                .Left += each_field_standard.ElementInfo.LeftEdge_Pixels
                .Width = each_field_standard.ElementInfo.Width_Pixels
                .Height = each_field_standard.ElementInfo.Height_Pixels

            End With ''End of "With new_label_control_std"

            ''intTopEdge_std = (30 + 30 * intNumControlsAlready_std)

            ''Moved up.''Me.Controls.Add(new_label_control_std)

            ''Inappropriate. 7/29 td''new_label_control_std.Left = ((10 + intNumControlsAlready_std * new_label_control_std.Width) + 10)
            ''Inappropriate. 7/29 td''''new_label_control_std.Top = 10
            ''Inappropriate. 7/29 td''new_label_control_std.Top = intTopEdge_std

            new_label_control_std.Visible = True
            intNumControlsAlready_std += 1

            new_label_control_std.Name = "StandardCtl" & CStr(intNumControlsAlready_std)
            new_label_control_std.BorderStyle = BorderStyle.FixedSingle

            ''
            ''Added 7/28/2019 thomas d.
            ''
            new_label_control_std.RefreshImage()

            ''Added 7/28/2019 thomas d.
            new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

        Next each_field_standard

        ''
        ''Custom Fields 
        ''
        Dim intTopEdge_cust As Integer ''Added 7/28/2019 td
        ClassFieldCustomized.InitializeHardcodedList_Students(True)

        For Each each_field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

            ''Added 7/29
            ''If (field_custom.ElementInfo Is Nothing) Then field_custom.ElementInfo = New ClassElementText()

            ''Dim new_label_control_cust As New GraphicFieldLabel(field_custom)

            ''intTopEdge_cust = (30 + 30 * intNumControlsAlready_cust)

            ''Me.Controls.Add(new_label_control_cust)
            ''new_label_control_cust.Left = ((intNumControlsAlready_cust * new_label_control_cust.Width) + 10)
            ''''7/28 td''new_label_control_cust.Top = (120 + new_label_control_cust.Height)
            ''new_label_control_cust.Top = intTopEdge_cust
            ''new_label_control_cust.Visible = True

            ''7/28/2019 td''ControlMoverOrResizer_TD.Init(new_label_control_cust, 20) ''Added 7/28/2019 thomas downes

            Dim new_label_control_cust As CtlGraphicFldLabel

            ''Added 9/3/2019 thomas d. 
            boolIncludeOnBadge = (par_boolLoadingForm And each_field_custom.IsDisplayedOnBadge)
            If (Not boolIncludeOnBadge) Then Continue For

            ''Added 7/29
            If (each_field_custom.ElementInfo Is Nothing) Then

                each_field_custom.ElementInfo = New ClassElementText()

                ''8/9/2019 td''new_label_control_cust = New CtlGraphicFldLabel(field_custom)
                new_label_control_cust = New CtlGraphicFldLabel(each_field_custom, Me)

                ''8/28/2019 td''Me.Controls.Add(new_label_control_cust)
                intCountControlsAdded += 1 ''Added 8/27/2019 td

                If (par_boolLoadingForm) Then
                    Me.Controls.Add(new_label_control_cust)
                ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
                    ''Added 8/28/2019 thomas downes 
                    Me.Controls.Remove(new_label_control_cust)
                End If

                new_label_control_cust.Width = CInt(pictureBack.Width / 3)

                With each_field_custom.ElementInfo

                    .Width_Pixels = new_label_control_cust.Width
                    .Height_Pixels = new_label_control_cust.Height

                    intTopEdge_cust = (30 + 30 * intNumControlsAlready_cust)
                    .TopEdge_Pixels = intTopEdge_cust
                    .LeftEdge_Pixels = intTopEdge_cust '' ((10 + intNumControlsAlready_cust * .Width_Pixels) + 10)

                End With ''End of "With each_field_custom.ElementInfo"

            Else

                ''8/9/2019 td''new_label_control_cust = New CtlGraphicFldLabel(field_custom)
                new_label_control_cust = New CtlGraphicFldLabel(each_field_custom, Me)

                ''8/28/2019 td''Me.Controls.Add(new_label_control_cust)
                intCountControlsAdded += 1 ''Added 8/27/2019 td

                If (par_boolLoadingForm) Then
                    Me.Controls.Add(new_label_control_cust)
                ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
                    ''Added 8/28/2019 thomas downes 
                    Me.Controls.Remove(new_label_control_cust)
                End If

            End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

            new_label_control_cust.Top = each_field_custom.ElementInfo.TopEdge_Pixels
            new_label_control_cust.Left = each_field_custom.ElementInfo.LeftEdge_Pixels
            new_label_control_cust.Width = each_field_custom.ElementInfo.Width_Pixels
            new_label_control_cust.Height = each_field_custom.ElementInfo.Height_Pixels

            ''intTopEdge_std = (30 + 30 * intNumControlsAlready_std)

            ''Moved up.''Me.Controls.Add(new_label_control_cust)

            ''Inappropriate. 7/29 td''new_label_control_std.Left = ((10 + intNumControlsAlready_std * new_label_control_std.Width) + 10)
            ''Inappropriate. 7/29 td''''new_label_control_std.Top = 10
            ''Inappropriate. 7/29 td''new_label_control_std.Top = intTopEdge_std

            intNumControlsAlready_cust += 1
            new_label_control_cust.Name = "CustCtl" & CStr(intNumControlsAlready_cust)
            new_label_control_cust.BorderStyle = BorderStyle.FixedSingle

            ''
            ''Added 7/28/2019 thomas d.
            ''
            new_label_control_cust.RefreshImage()

            ''Added 7/28/2019 thomas d.
            new_label_control_cust.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

        Next each_field_custom

        ''
        ''Added 8/27/2019 thomas downes
        ''
        Me.Refresh() ''Added 8/28/2019 td   
        MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of ''Private Sub LoadElements_Fields_TwoLists()''

    Private Sub SaveLayout()
        ''
        ''Added 7/29/2019 td
        ''
        Dim each_graphicalLabel As CtlGraphicFldLabel
        Dim each_portraitLabel As CtlGraphicPortrait ''Added 7/31/2019 td

        For Each each_control As Control In Me.Controls

            If (TypeOf each_control Is CtlGraphicFldLabel) Then

                each_graphicalLabel = CType(each_control, CtlGraphicFldLabel)

                each_graphicalLabel.SaveToModel()

            ElseIf (TypeOf each_control Is CtlGraphicPortrait) Then
                ''
                ''Added 7/31/2019 thomas downes  
                ''
                each_portraitLabel = CType(each_control, CtlGraphicPortrait)
                each_portraitLabel.SaveToModel()

            End If ''end of "If (TypeOf each_control Is GraphicFieldLabel) Then .... ElseIf ..."

        Next each_control

    End Sub ''End of "PRivate Sub SaveLayout()"  

    Private Sub RefreshPreview()
        ''
        ''Added 8/24/2019 td
        ''
        ''8/24 td''Dim objPrintLib As New ciLayoutPrintLib.CILayoutBadge
        Dim objPrintLib As New ciLayoutPrintLib.LayoutPrint_Redux
        Dim listOfElementText_Stdrd As List(Of IElementWithText)
        Dim listOfElementText_Custom As List(Of IElementWithText)
        Dim listOfTextImages As New List(Of Image) ''Added 8/26/2019 thomas downes 

        ''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

        ''objPrintLib.LoadImageWithFieldValues(picturePreview.Image,
        ''      ClassFieldStandard.ListOfFields_Students,
        ''      ClassFieldCustomized.ListOfFields_Students)

        ''9/4/2019 td''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd()
        ''9/4/2019 td''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom()

        listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd(Me.LayoutWidth())
        listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom(Me.LayoutWidth())

        ''8/24 td''picturePreview.SizeMode = PictureBoxSizeMode.Zoom
        ''8/24 td''picturePreview.Image = pictureBack.Image
        ''8/24 td''picturePreview.Image = CType(pictureBack.Image.Clone(), Image)

        Dim obj_image As Image ''Added 8/24 td
        Dim obj_image_clone As Image ''Added 8/24 td
        Dim obj_image_clone_resized As Image ''Added 8/24/2019 td

        ''Added 8/24/2019 td
        obj_image = pictureBack.Image
        obj_image_clone = CType(obj_image.Clone(), Image)

        ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)

        ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image_clone, True,
        ''8/26/2019 td''      picturePreview.Height)

        ''Added 8/26/2019 thomas downes
        obj_image_clone_resized =
            LayoutPrint.ResizeBackground_ToFitBox(obj_image, picturePreview, True)

        objPrintLib.LoadImageWithFieldValues(obj_image_clone_resized,
                                             listOfElementText_Stdrd,
                                             listOfElementText_Custom,
                                             listOfTextImages)

        ''Added 8/26/2019 thomas downes  
        Dim frm_ToShow1 As New FormDisplayImageList1(listOfTextImages)
        frm_ToShow1.Show()

        ''Added 8/27/2019 thomas downes  
        Dim frm_ToShow2 As New FormDisplayImageList2(ClassFieldStandard.ListOfFields_Students,
                                                      ClassFieldCustomized.ListOfFields_Students)
        frm_ToShow2.Show()

        ''8/26 td''picturePreview.Image = obj_image_clone_resized
        picturePreview.Image = obj_image_clone_resized
        picturePreview.Refresh()

    End Sub ''end of "Private Sub RefreshPreview()"

    Private Sub LoadElementGenerator()
        ''
        ''Added 7/18/2019 
        ''
        ''mod_generator = New LayoutElementGenerator



    End Sub

    ''Private Sub PictureboxPic_Click(sender As Object, e As EventArgs)
    ''End Sub

    ''Private Sub PictureBox10_Click(sender As Object, e As EventArgs)
    ''End Sub

    ''Private Sub GraphicFieldLabel1_Load(sender As Object, e As EventArgs) Handles GraphicFieldLabel1.Load
    ''End Sub

    ''Private Sub GraphicFieldLabel4_Load(sender As Object, e As EventArgs) Handles GraphicFieldLabel4.Load
    ''End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        ''
        ''Added 7/29/2019 td  
        ''
        SaveLayout()

    End Sub

    Private Sub FormDesignProtoTwo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim dia_result As DialogResult
        Dim closing_reason As CloseReason

        closing_reason = e.CloseReason

        ''Added 7/31/2019 td  
        dia_result = MessageBox.Show("Save your work?  (Currently, this does _NOT_ save your work permanently to your PC.) " &
                                     vbCrLf_Deux & "(Allows the window to be re-opened from the parent application, with your work retained.)", "ciLayout",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (dia_result = DialogResult.Cancel) Then e.Cancel = True
        If (dia_result = DialogResult.Yes) Then SaveLayout()

    End Sub

    Private Sub LinkSaveAndRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSaveAndRefresh.LinkClicked
        ''
        ''Added 7/31/2019 td
        ''
        ''
        ''Step 1 of 4.   Save the user's work. 
        ''
        SaveLayout()

        ''
        ''Step 2 of 4.  Decide the next step. 
        ''
        Const c_boolStartNewWindow As Boolean = True ''Added 9/3/2019 thomas d. 
        If (c_boolStartNewWindow) Then ''Added 9/3/2019 thomas d. 
            Dim frm_ToShow As New FormDesignProtoTwo()
            frm_ToShow.Show()
            Me.Close()
            Exit Sub
        End If ''End of "If (c_boolStartNewWindow) Then"

        ''
        ''Step 3 of 4.   Remove the existing controls. 
        ''
        ''Added 7/31/2019 td
        For Each each_control As Control In Me.Controls
            If (TypeOf each_control Is CtlGraphicFldLabel) Then Me.Controls.Remove(each_control)
            If (TypeOf each_control Is CtlGraphicPortrait) Then Me.Controls.Remove(each_control)

            Select Case True
                Case (TypeOf each_control Is CtlGraphicFldLabel)
                    each_control.Visible = False
                    Me.Controls.Remove(each_control)
                Case (TypeOf each_control Is CtlGraphicPortrait)
                    each_control.Visible = False
                    Me.Controls.Remove(each_control)
            End Select

        Next each_control

        ''
        ''Step 4 of 5.   Regenerate the form. 
        ''
        Me.Refresh()
        Application.DoEvents()

        ''
        ''Step 5 of 5.   Reload the fields onto the form. 
        ''
        ''9/3/2019 td''Load_Form()
        LoadElements_Fields_Master(False, False)

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub PictureAdjuster_MouseClick(sender As Object, e As MouseEventArgs) Handles graphicAdjuster.MouseClick
        ''
        ''Added 8/9/2019 thomas downes
        ''
        Dim intX As Integer
        Dim intY As Integer
        Dim objControlToModify As CtlGraphicFldLabel
        Dim intGroupedControlsCount As Integer
        Dim boolGroupedCtls As Boolean

        intX = e.X
        intY = e.Y

        intGroupedControlsCount = mod_selectedCtls.Count
        boolGroupedCtls = (0 < intGroupedControlsCount)

        objControlToModify = mod_FieldControlLastTouched

        Select Case True

            Case ((0 < intX And intX < 45) And (0 < intY And intY < 45))

                objControlToModify.ElementInfo_Text.TextAlignment = HorizontalAlignment.Left

            Case ((45 < intX And intX < 90) And (45 < intY And intY < 90))

                objControlToModify.ElementInfo_Text.TextAlignment = HorizontalAlignment.Center

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.TextAlignment = HorizontalAlignment.Right

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                ''objControlToModify.ElementInfo.Fo  ntSize += 1

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                ''objControlToModify.ElementInfo.FontSize -= 1

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                ''objControlToModify.ElementInfo.FontSize -= 1

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

            Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

                objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

        End Select ''En do f"Select Case True"

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles picturePreview.Click

    End Sub

    Private Sub DemoModeActiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DemoModeActiveToolStripMenuItem.Click

        ''Added 8/14/2019 td 
        DemoModeActiveToolStripMenuItem.Checked = (Not DemoModeActiveToolStripMenuItem.Checked)

    End Sub

    Private Sub UserControlsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()

        ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        frm_ToShow.ListOfFields = FormMain.GetCurrentPersonality_Fields_Custom()
        frm_ToShow.Show()

    End Sub

    Private Sub CustomFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomFieldsToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()

        ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        frm_ToShow.ListOfFields = FormMain.GetCurrentPersonality_Fields_Custom()
        frm_ToShow.Show()

    End Sub

    Private Sub StandardFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandardFieldsToolStripMenuItem.Click
        ''
        ''Added 8/19/2019 thomas downes
        '' 
        Dim frm_ToShow As New ListStandardFields()
        frm_ToShow.ListOfFields = FormMain.GetCurrentPersonality_Fields_Standard()
        frm_ToShow.Show()

    End Sub

    Private Sub LinkRefreshPreview_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRefreshPreview.LinkClicked
        ''
        ''Added 8/24/2019 thomas downes
        ''
        RefreshPreview()

        ''''8/24 td''Dim objPrintLib As New ciLayoutPrintLib.CILayoutBadge
        ''Dim objPrintLib As New ciLayoutPrintLib.LayoutPrint_Redux
        ''Dim listOfElementText_Stdrd As List(Of IElementWithText)
        ''Dim listOfElementText_Custom As List(Of IElementWithText)

        ''''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

        ''''objPrintLib.LoadImageWithFieldValues(picturePreview.Image,
        ''''      ClassFieldStandard.ListOfFields_Students,
        ''''      ClassFieldCustomized.ListOfFields_Students)

        ''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd()
        ''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom()

        ''picturePreview.SizeMode = PictureBoxSizeMode.Zoom
        ''picturePreview.Image = pictureBack.Image

        ''objPrintLib.LoadImageWithFieldValues(picturePreview.Image,
        ''                                     listOfElementText_Stdrd,
        ''                                     listOfElementText_Custom)

    End Sub

    Private Sub PictureBack_Click(sender As Object, e As EventArgs) Handles pictureBack.Click

    End Sub

    Private Sub LinkLabelSave1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabelSave1.LinkClicked,
            LinkLabelSave2.LinkClicked
        ''
        ''Added 9/3/2019 thomas downes
        ''
        ''Step 1 of 3.   Save the user's work. 
        ''
        SaveLayout()

    End Sub

    Private Sub LinkRemoveElements_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRemoveElements.LinkClicked
        ''
        ''Added 9/3/2019 thomas downes
        ''
        Dim each_controlField As CtlGraphicFldLabel
        Dim list_controlFields As New List(Of CtlGraphicFldLabel)

        Me.mod_ControlLastTouched = Nothing

        Me.mod_FieldControlLastTouched = Nothing

        Me.mod_selectedCtls.Clear()

        ''
        ''Part 1 of 2.  Create a list of the controls you want to detach from the form. 
        ''
        For Each each_control As Control In Me.Controls

            If (TypeOf each_control Is CtlGraphicFldLabel) Then

                each_controlField = CType(each_control, CtlGraphicFldLabel)
                each_controlField.FormDesigner = Nothing
                each_controlField.Parent = Nothing
                each_controlField.FieldInfo = Nothing
                each_controlField.ElementInfo_Base = Nothing
                each_controlField.ElementInfo_Text = Nothing

                ''Add it to the list.   (Important!) 
                list_controlFields.Add(each_controlField)

            End If ''End of "If (TypeOf each_control Is CtlGraphicFldLabel) Then"

        Next each_control

        ''
        ''Part 2 of 2.  Detach each listed control from the form. 
        ''
        For Each each_controlField In list_controlFields

            Me.Controls.Remove(each_controlField)

        Next each_controlField

    End Sub
End Class