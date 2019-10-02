Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/1/2019 td
''

Imports ciBadgeInterfaces
Imports ciBadgeDesigner
Imports ciBadgeElements

Public Class Methods_EditElement
    ''
    ''Added 10/1/2019 td
    ''
    Public Property CurrentElementCtl As CtlGraphicFldLabel
    Public Property Designer As ciBadgeDesigner.ClassDesigner

    Private Sub Open_Field_Of_Element(sender As Object, e As EventArgs)
        ''Private Sub OpenDialog_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ''7/30/2019 td''ColorDialog1.ShowDialog()
        Dim form_ToShow As New ListCustomFieldsFlow

        Dim boolExitEarly As Boolean ''Added 8/13/2019 td
        CreateVisibleButton_Master("Choose a background color", AddressOf OpenDialog_Color, boolExitEarly)
        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        ''Can (should) we just show a single field? ''form_ToShow.JustOneField = Me.FieldInfo
        form_ToShow.JustOneField_Index = Me.FieldInfo.FieldIndex

        form_ToShow.Show()

    End Sub ''eNd of "Private Sub opendialog_Field()"

    Private Sub OpenDialog_Color(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolExitEarly As Boolean ''Added 8/13/2019 td
        CreateVisibleButton_Master("Choose a background color", AddressOf OpenDialog_Color, boolExitEarly)
        Application.DoEvents()
        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        ColorDialog1.ShowDialog()

        If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then

            ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
            ''8/29/2019 td''Me.ElementInfo.BackColor = ColorDialog1.Color
            Me.ElementInfo_Base.Back_Color = ColorDialog1.Color

            ''Me.ElementInfo.Width_Pixels = Me.Width
            ''Me.ElementInfo.Height_Pixels = Me.Height

            Application.DoEvents()
            Application.DoEvents()

            ''9/15/2019 td ''Refresh_Image()
            Refresh_Image(True)
            Me.Refresh()

        ElseIf (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then

            ''Added 8/3/2019 td 
            Dim objElements As List(Of CtlGraphicFldLabel)

            ''8/4//2019 td'objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems
            objElements = Me.GroupEdits.LabelsDesignList_AllItems

            ''If (objElements.Count = 0) Then
            ''   objElements.Add(Me)
            '' End If

            For Each each_ctl As CtlGraphicFldLabel In objElements
                ''
                ''Added 8/3/2019 td  
                ''
                With each_ctl

                    ''8/29/2019 td''.ElementInfoBase.BackColor = ColorDialog1.Color
                    .ElementInfo_Base.Back_Color = ColorDialog1.Color
                    ''.ElementInfo.Width_Pixels = Me.Width
                    ''.ElementInfo.Height_Pixels = Me.Height

                    .Refresh_Image(True)
                    .Refresh()

                End With

            Next each_ctl

        End If ''End of "If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then ... ElseIf (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then"

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub SwitchCtl__Up(sender As Object, e As EventArgs)
        ''
        ''Added 8/16/2019 thomas downes
        ''
        Me.GroupEdits.SwitchControls___Up(Me)

        ''Added 9/13/2019 td
        ''9/19/2019 td'' Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub

    Private Sub SwitchCtl_Down(sender As Object, e As EventArgs)
        ''
        ''Added 8/16/2019 thomas downes
        ''
        Me.GroupEdits.SwitchControls_Down(Me)

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub

    Private Sub OpenDialog_Font(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolExitEarly As Boolean ''Added 8/13/2019 td

        CreateVisibleButton_Master("Choose a text font", AddressOf OpenDialog_Font, boolExitEarly)
        Application.DoEvents()

        ''Added 8/17/2019 td
        If (mod_fauxMenuEditSingleton Is Nothing) Then mod_fauxMenuEditSingleton = New CtlGraphPopMenuEditSingle

        mod_fauxMenuEditSingleton.SizeToExpectations()

        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        FontDialog1.Font = Me.ElementInfo_Text.Font_DrawingClass ''Added 7/31/2019 td  
        FontDialog1.ShowDialog()

        ''Me.ElementInfo.Font_DrawingClass = FontDialog1.Font
        ''Application.DoEvents()
        ''Application.DoEvents()
        ''RefreshImage()
        ''Me.Refresh()

        If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then

            Me.ElementInfo_Text.Font_DrawingClass = FontDialog1.Font
            Me.ElementInfo_Text.FontSize_Pixels = FontDialog1.Font.Size  ''Added 8/17/2019 td
            Application.DoEvents()
            Application.DoEvents()

            ''9/15/2019 td''Refresh_Image()
            Refresh_Image(False)
            Me.Refresh()

        ElseIf (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then

            ''Added 8/3/2019 td 
            Dim objElements As List(Of CtlGraphicFldLabel)
            objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems

            For Each each_ctl As CtlGraphicFldLabel In objElements
                ''
                ''Added 8/3/2019 td  
                ''
                With each_ctl

                    .ElementInfo_Text.Font_DrawingClass = FontDialog1.Font
                    Application.DoEvents()
                    Application.DoEvents()
                    .Refresh_Image(True)
                    .Refresh()

                End With

            Next each_ctl

        End If ''End of "If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then... Else ..."

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub opendialog_Font()"

    Private Sub GroupEditElement_Add(sender As Object, e As EventArgs)
        ''
        ''Added 8/2/2019 td  
        ''
        Static s_boolRunOnceMsg As Boolean ''Added 8/2/2019 td 
        If (Not s_boolRunOnceMsg) Then
            ''Added 8/2/2019 td  
            s_boolRunOnceMsg = True ''Added 8/3/2019 td  
            MessageBox.Show("You can press the CTRL key while you click the element, to select (or de-select)", "Use CTRL key",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If ''ENd of "If (Not s_boolRunOnceMsg) Then"

        GroupEditElement_Add()

    End Sub ''End of "Private Sub GroupEditElement_Add(sender As Object, e As EventArgs)"

    Private Sub GroupEditElement_Add()
        ''
        ''Added 8/2/2019 td  
        ''
        mod_includedInGroupEdit = True

        Me.GroupEdits.LabelsDesignList_Add(Me) ''Added 8/1/2019 td

        ''8/2/2019''Me.BackColor = Color.Yellow
        ''8/2/2019''pictureLabel.Top = 6
        ''8/2/2019''pictureLabel.Left = 6
        ''8/2/2019''pictureLabel.Width = Me.Width - 2 * 6
        ''8/2/2019''pictureLabel.Height = Me.Height - 2 * 6

        ''Added 8/2/2019 td 
        Me.ElementInfo_Base.SelectedHighlighting = True
        Me.Refresh_Image(True)

    End Sub ''End of "Private Sub GroupEditElement_Add()"

    Private Sub GroupEditElement_Omit(sender As Object, e As EventArgs)
        ''
        ''Added 8/2/2019 td  
        ''
        GroupEditElement_Omit()

    End Sub ''End of "Private Sub GroupEditElement_Omit(sender As Object, e As EventArgs)"

    Private Sub GroupEditElement_Omit()
        ''
        ''Added 8/2/2019 td  
        ''
        ''Undo the selection. 
        ''
        mod_includedInGroupEdit = False

        Me.GroupEdits.LabelsDesignList_Remove(Me) ''Added 8/1/2019 td

        ''Me.BackColor = Me.ElementInfo.BackColor
        ''pictureLabel.Top = 0
        ''pictureLabel.Left = 0
        ''pictureLabel.Width = Me.Width ''- 2 * 6
        ''pictureLabel.Height = Me.Height ''- 2 * 6

        Me.SelectedHighlighting = False ''Added 8/3/2019 td  
        Me.ElementInfo_Base.SelectedHighlighting = False
        Me.Refresh_Image(True)

    End Sub ''End of "Private Sub GroupEditElement_Omit( )"

    Private Sub Alignment_Master(sender As Object, e As EventArgs)
        ''
        ''Added 8/5/2019 thomas downes
        ''
        Dim objElements As List(Of CtlGraphicFldLabel)
        Dim sender_toolItem As ToolStripItem
        Dim strAlignmentTypeText As String ''Added 8/14/2019 thomas 
        Dim boolExitEarly As Boolean ''Added 8/13/2019 td
        Dim diag_answer As DialogResult ''Added 8/16/2019 thomas d. 

        ''Added 8/16/2019 td  
        Dim intAverage_Top As Int32 = 0
        Dim intAverage_Left As Int32 = 0
        Dim intAverage_Width As Int32 = 0
        Dim intAverage_Height As Int32 = 0

        If (Not modFonts.AskedAlignmentQuestion) Then
            ''Added 8/16/2019 td  
            diag_answer = MessageBox.Show("When aligning elements, how do you want to determine the alignment line? " & vbCrLf_Deux &
                                          "Yes = Line elements up with the element which was mouse-clicked. " & vbCrLf &
                                          "No = Line elements up using an average-line which includes all selected items." & vbCrLf_Deux &
                                          "(This is a one-time message.  It won't be asked again during this session.)",
                                           "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            ''Added 8/16/2019 td  
            modFonts.UseAverageLineForAlignment = (diag_answer = DialogResult.No)
            If (diag_answer = DialogResult.Cancel) Then Exit Sub
            modFonts.AskedAlignmentQuestion = True ''Ask only once.  
        End If ''End of "If (Not modFonts.AskedAlignmentQuestion) Then"

        CreateVisibleButton_Master("Choose a background color", AddressOf Alignment_Master, boolExitEarly, True)
        ''Moved below.''If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        If (TypeOf sender Is ToolStripMenuItem) Then
            sender_toolItem = CType(sender, ToolStripMenuItem)
            ''Added 8/14/2019 thomas 
            strAlignmentTypeText = sender_toolItem.Text
            mod_strAlignmentTypeText = sender_toolItem.Text ''Added 8/14 td
        Else
            ''Exit Sub
            strAlignmentTypeText = mod_strAlignmentTypeText
        End If ''End of "If (TypeOf sender Is ToolStripMenuItem) Then ..... Else ..."

        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        objElements = Me.GroupEdits.LabelsDesignList_AllItems

        ''
        ''Added 8/16/2019 td  
        ''
        If (modFonts.UseAverageLineForAlignment) Then

            Dim intSumAll_Top As Int64 = 0
            Dim intSumAll_Left As Int64 = 0
            Dim intSumAll_Width As Int64 = 0
            Dim intSumAll_Height As Int64 = 0
            Dim intCountElements As Int64 = 0

            ''Added 8/16/2019 td  
            For Each each_ctl As CtlGraphicFldLabel In objElements
                ''Added 8/16/2019 td  
                intSumAll_Left += each_ctl.Left
                intSumAll_Top += each_ctl.Top
                intSumAll_Width += each_ctl.Width
                intSumAll_Height += each_ctl.Height
                intCountElements += 1
            Next each_ctl

            ''Added 8/16/2019 td  
            intAverage_Top = CType(intSumAll_Top / intCountElements, Int32)
            intAverage_Left = CType(intSumAll_Left / intCountElements, Int32)
            intAverage_Width = CType(intSumAll_Width / intCountElements, Int32)
            intAverage_Height = CType(intSumAll_Height / intCountElements, Int32)

        End If ''End of "If (modFonts.UseAverageLineForAlignment) Then"

        For Each each_ctl As CtlGraphicFldLabel In objElements
            ''
            ''Added 8/5/2019 td  
            ''
            Dim boolAverage As Boolean ''Added 8/16 td  
            boolAverage = modFonts.UseAverageLineForAlignment

            With each_ctl

                Select Case strAlignmentTypeText ''8/14/2019 td''(sender_toolItem.Text)

                    Case (_item_group_alignTop.Text)

                        ''Top 
                        each_ctl.Top = CInt(IIf(boolAverage, intAverage_Top, Me.Top)) ''8/16 Me.Top
                        ''8/29/2019 td''each_ctl.ElementInfo_Text.TopEdge_Pixels = each_ctl.Top ''8/16 Me.Top
                        each_ctl.ElementInfo_Base.TopEdge_Pixels = each_ctl.Top ''8/16 Me.Top

                    Case (_item_group_alignLeft.Text)

                        ''Left
                        each_ctl.Left = CInt(IIf(boolAverage, intAverage_Left, Me.Left)) ''8/16 Me.Left
                        each_ctl.ElementInfo_Base.LeftEdge_Pixels = each_ctl.Left ''Me.Left

                    Case (_item_group_alignWidth.Text)

                        ''Width
                        each_ctl.Width = CInt(IIf(boolAverage, intAverage_Width, Me.Width)) ''8/16 Me.Width
                        each_ctl.ElementInfo_Base.Width_Pixels = each_ctl.Width ''Me.Width

                    Case (_item_group_alignHeight.Text)

                        ''Height  
                        each_ctl.Height = CInt(IIf(boolAverage, intAverage_Height, Me.Height)) ''8/16 Me.Height
                        each_ctl.ElementInfo_Base.Height_Pixels = each_ctl.Height ''Me.Height

                End Select ''End of "Select Case strAlignmentTypeText"

                ''Select Case True
                ''    Case (sender_toolItem Is item_group_alignTop) : each_ctl.Top = Me.Top
                ''    Case (sender_toolItem Is item_group_alignLeft) : each_ctl.Left = Me.Left
                ''    Case (sender_toolItem Is item_group_alignWidth)
                ''        each_ctl.Width = Me.Width
                ''        each_ctl.ElementInfo.Width_Pixels = Me.Width
                ''    Case (sender_toolItem Is item_group_alignHeight)
                ''        each_ctl.Height = Me.Height
                ''        each_ctl.ElementInfo.Height_Pixels = Me.Height
                ''End Select

            End With ''End of "With each_ctl"

        Next each_ctl

        ''Added 9/13/2019 td
        ''Denigrated. 9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub Alignment_Master()"

    Private Sub ExampleValue_Edit(sender As Object, e As EventArgs)
        ''
        ''Added 8/10/2019 thomas downes
        ''
        With textTypeExample
            .Visible = True
            .Text = Me.ElementInfo_Text.Text ''Added 8/16/2019 td
            .SelectAll() ''Added 8/16/2019 td

            ''Added 9/10/2019 td 
            ''  Put the focus on the textbox. 
            .Select() ''Added 9/10/2019 td 

        End With ''End of "With textTypeExample"

    End Sub ''End of "Private Sub ExampleValue_Edit"  

    Private Sub Open_OffsetTextDialog(sender As Object, e As EventArgs)
        ''
        ''Added 8/10/2019 thomas downes
        ''
        ''9/18/2019 td''Dim frm_ToShow As New DialogTextOffset
        Dim frm_ToShow As New DialogTextOffset(Me.ElementClass_Obj, Me.ElementClass_Obj.Copy(), Me)

        ''
        ''Added 8/10/2019 thomas downes
        ''
        ''8/16/2019 td''frm_ToShow.LoadFieldAndForm(Me.FieldInfo, Me.FormDesigner, Me)
        ''9/03/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)
        ''9/18/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Base, Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)
        ''9/19/2019 td''frm_ToShow.LoadFieldAndForm(Me.FormDesigner, Me)
        frm_ToShow.LoadFieldAndForm(Me.LayoutFunctions, Me)

        ''Major call !!
        frm_ToShow.ShowDialog()

        ''Refresh the form. ----8/17/2019 td
        Dim boolUserPressedOK As Boolean
        boolUserPressedOK = (frm_ToShow.DialogResult = DialogResult.OK)

        If (boolUserPressedOK) Then '' ----8/17/2019 td

            ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontOffset_X = frm_ToShow.FontOffset_X
            ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontOffset_Y = frm_ToShow.FontOffset_Y
            ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontSize_Pixels = frm_ToShow.FontSize
            ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.Font_DrawingClass = frm_ToShow.Font_DrawingClass

            If (frm_ToShow.UserConfirmed) Then

                frm_ToShow.UpdateInfo_ViaInterfaces(Me.ElementInfo_Base, Me.ElementInfo_Text)
                Me.Refresh_Image(True)

            End If ''End of "If (frm_ToShow.UserConfirmed) Then"

            ''
            ''
            ''Group Editimg
            ''
            ''
            ''Added 8/18/2019 td 
            If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then

                ''Added 8/18/2019 td 
                Dim objElements As List(Of CtlGraphicFldLabel)
                objElements = Me.GroupEdits.LabelsDesignList_AllItems

                For Each each_ctl As CtlGraphicFldLabel In objElements
                    ''
                    ''Added 8/3/2019 td  
                    ''
                    With each_ctl
                        ''.ElementInfo.Alignment = frm_ToShow.Alignment  
                        ''9/18/2019 td''.ElementInfo_Text.FontOffset_X = frm_ToShow.FontOffset_X
                        ''9/18/2019 td''.ElementInfo_Text.FontOffset_Y = frm_ToShow.FontOffset_Y
                        ''9/18/2019 td''.ElementInfo_Text.FontSize_Pixels = frm_ToShow.FontSize

                        ''Added 8/18/2019 thomas d.
                        ''9/18/2019 td''.ElementInfo_Text.Font_DrawingClass = frm_ToShow.Font_DrawingClass
                        ''9/18/2019 td''.ElementInfo_Text.TextAlignment = frm_ToShow.TextAlignment
                        ''9/18/2019 td''.ElementInfo_Text.ExampleValue = frm_ToShow.TextExampleValue.Text

                        frm_ToShow.UpdateInfo_ViaInterfaces(.ElementInfo_Base, .ElementInfo_Text)

                        .Refresh_Image(True)
                        .Refresh()

                    End With ''End of " With each_ctl"

                Next each_ctl

            End If ''ENdo f "If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then"

        End If ''End of "If (boolUserPressedOK) Then"

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''End of "Private Sub Open_OffsetTextDialog(sender As Object, e As EventArgs)"

    Private Sub BorderDesign(sender As Object, e As EventArgs)
        ''
        ''Added 9/ 2/2019 thomas downes
        ''
        ''9/18/2019 td''Dim frm_ToShow As New DialogTextBorder
        ''9/18/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Base, Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)

        Dim frm_ToShow As New DialogTextBorder(Me.ElementClass_Obj, Me.ElementClass_Obj.Copy())
        ''Denigrated. 9/19 td''frm_ToShow.LoadFieldAndForm(Me.FormDesigner, Me)
        frm_ToShow.LoadFieldAndForm(Me.LayoutFunctions, Me)

        ''Major call !!
        frm_ToShow.ShowDialog()

        ''Refresh the form. ----8/17/2019 td
        Dim boolUserPressedOK As Boolean
        boolUserPressedOK = (frm_ToShow.DialogResult = DialogResult.OK)

        If (boolUserPressedOK) Then '' ----8/17/2019 td

            ''9/18/2019 td''Me.ElementInfo_Base.Border_WidthInPixels = frm_ToShow.Border_SizeInPixels
            ''9/18/2019 td''Me.ElementInfo_Base.Border_Color = frm_ToShow.Border_Color
            ''9/18/2019 td''Me.ElementInfo_Base.Border_Displayed = frm_ToShow.Border_Displayed ''Added 9/9/2019 td

            ''Added 9/18/2019 td
            frm_ToShow.UpdateInfo_ViaInterface(Me.ElementInfo_Base)

            Me.Refresh_Image(True)

            ''
            ''
            ''Group Editimg
            ''
            ''
            ''Added 8/18/2019 td 
            If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then

                ''Added 8/18/2019 td 
                Dim objElements As List(Of CtlGraphicFldLabel)
                objElements = Me.GroupEdits.LabelsDesignList_AllItems

                For Each each_ctl As CtlGraphicFldLabel In objElements
                    ''
                    ''Added 8/3/2019 td  
                    ''
                    With each_ctl

                        ''9/18/2019 td''.ElementInfo_Base.Border_WidthInPixels = frm_ToShow.Border_SizeInPixels
                        ''9/18/2019 td''.ElementInfo_Base.Border_Color = frm_ToShow.Border_Color
                        ''9/18/2019 td''.ElementInfo_Base.Border_Displayed = frm_ToShow.Border_Displayed ''9/9 td

                        ''Added 9/18/2019 td 
                        frm_ToShow.UpdateInfo_ViaInterface(.ElementInfo_Base)

                        .Refresh_Image(True)
                        .Refresh()

                    End With

                Next each_ctl

            End If ''End of "If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then"

        End If ''End of "If (boolUserPressedOK) Then"

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''End of "Private Sub Open_OffsetTextDialog(sender As Object, e As EventArgs)"

    Private Sub Rotate90Degrees(sender As Object, e As EventArgs)
        ''
        ''Added 8/17/2019 thomas downes
        ''  
        With Me.ElementInfo_Base

            Select Case .OrientationToLayout
                Case "", " ", "P"
                    .OrientationToLayout = "L"
                Case "L"
                    .OrientationToLayout = "P"
                Case Else
                    .OrientationToLayout = "P"
            End Select

            ''Added 8/12/2019 thomas downes 
            ''
            ''   Increment by 90 degrees.  
            ''    This will enable the badge to be printed with the element oriented
            ''   correctly (with one out of four choices of orientation). 
            ''
            .OrientationInDegrees += 90

            ''Added 9/23/2019 td
            If (360 <= .OrientationInDegrees) Then
                ''Remove 360 degrees (the full circle) from the 
                ''    property value.   We don't want to have to 
                ''    do modulo arithmetic (divide by 360 & get 
                ''    the remainder).  ---9/23/2019 td 
                ''     
                .OrientationInDegrees = (.OrientationInDegrees - 360)
            End If ''End of "If (360 <= .OrientationInDegrees) Then"

        End With ''End of "With Me.ElementInfo_Base"

        '' 9/15 td''Refresh_Image()
        '' 9/23 td''Refresh_Image(True)
        '' 9/23 td''Me.Refresh()
        Me.Refresh_Master()

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub Rotate90Degrees()"






End Class
