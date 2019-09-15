Option Explicit On ''Added 8/16/2019 td 
Option Strict On ''Added 8/16/2019 td 
''
''Added 7/30/2019 thomas downes
''

Partial Public Class CtlGraphicFldLabel
    ''
    ''Added 8/5/2019 td
    ''   This is to store the initial Width & Height, when resizing.
    ''
    Public FormDesigner As FormDesignProtoTwo ''Added 8/9/2019 td  

    Public TempResizeInfo_W As Integer = 0 ''Intial resizing width.  (Before any adjustment is made.)
    Public TempResizeInfo_H As Integer = 0 ''Intial resizing height.  (Before any adjustment is made.)

    ''Added 8/12/2019 Thomas Downes 
    Public TempResizeInfo_Left As Integer = 0 ''Intial resizing Left.  (Before any adjustment is made.)
    Public TempResizeInfo_Top As Integer = 0 ''Intial resizing Top.  (Before any adjustment is made.)

    Private Shared _item_fieldname As ToolStripMenuItem ''Added 8/16/2019 td

    Private Shared _item_group_alignLeft As ToolStripMenuItem ''Added 8/2/2019 td
    Private Shared _item_group_alignRight As ToolStripMenuItem ''Added 8/2/2019 td
    Private Shared _item_group_alignWidth As ToolStripMenuItem ''Added 8/5/2019 td
    Private Shared _item_group_alignHeight As ToolStripMenuItem ''Added 8/5/2019 td
    Private Shared _item_group_alignTop As ToolStripMenuItem ''Added 8/5/2019 td
    Private Shared _item_group_alignBottom As ToolStripMenuItem ''Added 8/5/2019 td
    Private Shared _item_group_alignParent As ToolStripMenuItem ''Added 8/5/2019 td

    Private Shared _equalizeDistances_Top As ToolStripMenuItem ''Added 8/16/2019 td
    Private Shared _equalizeDistances_Left As ToolStripMenuItem ''Added 8/16/2019 td

    Private Shared _item_group_add As ToolStripMenuItem ''Added to top of of module, 8/12 & 8/2/2019 td
    Private Shared _item_group_omit As ToolStripMenuItem ''Added to top of of module, 8/12 & 8/2/2019 td

    Private Shared _item_group_switch__Up As ToolStripMenuItem ''Move up in a top-down sequence, 8/15/2019 td
    Private Shared _item_group_switchDown As ToolStripMenuItem ''Move down in a top-down sequence, 8/15/2019 td

    Private Const mc_AttachContextMenuToTop As Boolean = False ''8/12/2019 td''True ''Added 8/5/2019 td 

    ''8/14/2019 td''Private Const mc_CreateVisibleButtonForDemo As Boolean = True ''Added 8/13/2019 td 

    Private mod_bBypassCreateButton As Boolean = False ''Added 8/13/2019 td 

    Private mod_fauxMenuEditSingleton As CtlGraphPopMenuEditSingle ''Added 8/14/2019 td
    Private mod_fauxMenuEditGroupedItems As CtlGraphPopMenuEditGroup ''Added 8/14/2019 td
    Private mod_strAlignmentTypeText As String ''Added 8/14/2019 td
    Private mod_fauxMenuAlignment As CtlGraphPopMenuAlign ''Added 8/14/2019 td 

    Private Sub OpenDialog_Field(sender As Object, e As EventArgs)
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
        Me.FormDesigner.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub SwitchCtl__Up(sender As Object, e As EventArgs)
        ''
        ''Added 8/16/2019 thomas downes
        ''
        Me.GroupEdits.SwitchControls___Up(Me)

        ''Added 9/13/2019 td
        Me.FormDesigner.AutoPreview_IfChecked()

    End Sub

    Private Sub SwitchCtl_Down(sender As Object, e As EventArgs)
        ''
        ''Added 8/16/2019 thomas downes
        ''
        Me.GroupEdits.SwitchControls_Down(Me)

        ''Added 9/13/2019 td
        Me.FormDesigner.AutoPreview_IfChecked()

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

            Refresh_Image()
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
        Me.FormDesigner.AutoPreview_IfChecked()

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
        Me.FormDesigner.AutoPreview_IfChecked()

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
        Dim frm_ToShow As New DialogTextOffset

        ''
        ''Added 8/10/2019 thomas downes
        ''
        ''8/16/2019 td''frm_ToShow.LoadFieldAndForm(Me.FieldInfo, Me.FormDesigner, Me)
        ''9/03/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)
        frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Base, Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)

        ''Major call !!
        frm_ToShow.ShowDialog()

        ''Refresh the form. ----8/17/2019 td
        Dim boolUserPressedOK As Boolean
        boolUserPressedOK = (frm_ToShow.DialogResult = DialogResult.OK)

        If (boolUserPressedOK) Then '' ----8/17/2019 td

            Me.ElementInfo_Text.FontOffset_X = frm_ToShow.FontOffset_X
            Me.ElementInfo_Text.FontOffset_Y = frm_ToShow.FontOffset_Y
            Me.ElementInfo_Text.FontSize_Pixels = frm_ToShow.FontSize
            Me.ElementInfo_Text.Font_DrawingClass = frm_ToShow.Font_DrawingClass

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
                        ''.ElementInfo.Alignment = frm_ToShow.Alignment  
                        .ElementInfo_Text.FontOffset_X = frm_ToShow.FontOffset_X
                        .ElementInfo_Text.FontOffset_Y = frm_ToShow.FontOffset_Y
                        .ElementInfo_Text.FontSize_Pixels = frm_ToShow.FontSize

                        ''Added 8/18/2019 thomas d.
                        .ElementInfo_Text.Font_DrawingClass = frm_ToShow.Font_DrawingClass
                        .ElementInfo_Text.TextAlignment = frm_ToShow.TextAlignment
                        .ElementInfo_Text.ExampleValue = frm_ToShow.TextExampleValue.Text

                        .Refresh_Image(True)
                        .Refresh()

                    End With

                Next each_ctl

            End If ''ENdo f "If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then"

        End If ''End of "If (boolUserPressedOK) Then"

        ''Added 9/13/2019 td
        Me.FormDesigner.AutoPreview_IfChecked()

    End Sub ''End of "Private Sub Open_OffsetTextDialog(sender As Object, e As EventArgs)"

    Private Sub BorderDesign(sender As Object, e As EventArgs)
        ''
        ''Added 9/ 2/2019 thomas downes
        ''
        Dim frm_ToShow As New DialogTextBorder

        frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Base, Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)

        ''Major call !!
        frm_ToShow.ShowDialog()

        ''Refresh the form. ----8/17/2019 td
        Dim boolUserPressedOK As Boolean
        boolUserPressedOK = (frm_ToShow.DialogResult = DialogResult.OK)

        If (boolUserPressedOK) Then '' ----8/17/2019 td

            Me.ElementInfo_Base.Border_WidthInPixels = frm_ToShow.Border_SizeInPixels
            Me.ElementInfo_Base.Border_Color = frm_ToShow.Border_Color
            Me.ElementInfo_Base.Border_Displayed = frm_ToShow.Border_Displayed ''Added 9/9/2019 td

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

                        .ElementInfo_Base.Border_WidthInPixels = frm_ToShow.Border_SizeInPixels
                        .ElementInfo_Base.Border_Color = frm_ToShow.Border_Color
                        .ElementInfo_Base.Border_Displayed = frm_ToShow.Border_Displayed ''9/9 td

                        .Refresh_Image(True)
                        .Refresh()

                    End With

                Next each_ctl

            End If ''End of "If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then"

        End If ''End of "If (boolUserPressedOK) Then"

        ''Added 9/13/2019 td
        Me.FormDesigner.AutoPreview_IfChecked()

    End Sub ''End of "Private Sub Open_OffsetTextDialog(sender As Object, e As EventArgs)"

    Private Sub Rotate90Degrees(sender As Object, e As EventArgs)
        ''
        ''Added 8/17/2019 thomas downes
        ''  
        Select Case Me.ElementInfo_Base.OrientationToLayout
            Case "", " ", "P"
                Me.ElementInfo_Base.OrientationToLayout = "L"
            Case "L"
                Me.ElementInfo_Base.OrientationToLayout = "P"
            Case Else
                Me.ElementInfo_Base.OrientationToLayout = "P"
        End Select

        ''Added 8/12/2019 thomas downes 
        ''
        ''   Increment by 90 degrees.  
        ''    This will enable the badge to be printed with the element oriented
        ''   correctly (with one out of four choices of orientation). 
        ''
        Me.ElementInfo_Base.OrientationInDegrees += 90

        '' 9/15 td''Refresh_Image()
        Refresh_Image(True)
        Me.Refresh()

        ''Added 9/13/2019 td
        Me.FormDesigner.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub Rotate90Degrees()"

    Private Sub CreateVisibleButton_Master(par_strText As String, par_handler As EventHandler, ByRef pboolExitEarly As Boolean,
                                           Optional pboolAlignment As Boolean = False)
        ''
        ''Added 8/13/2019 td  
        ''
        If (mod_bBypassCreateButton) Then
            ''Added 8/13/2019 td  
            pboolExitEarly = False  ''Reinitialize. 
            mod_bBypassCreateButton = False ''Reinitialize. 

            ''8/14/2019 td''ElseIf (mc_CreateVisibleButtonForDemo) Then
        ElseIf (Me.FormDesigner.OkayToShowFauxContextMenu()) Then
            ''
            ''Added 8 / 13 / 2019 td 
            ''
            ''8/14/2019 td''CreateVisibleButton(par_strText, par_handler)
            CreateFauxContextMenu(par_strText, par_handler, pboolAlignment)
            mod_bBypassCreateButton = True ''Reinitialize. 
            pboolExitEarly = True

        End If ''End of "If (mod_bBypassCreateButton) Then .... ElseIf (mc_CreateVisibleButtonForDemo) Then ...."

    End Sub ''End of "Private Sub CreateMouseButton_Master(par_strText As String, par_handler As EventHandler)"

    Private Sub CreateFauxContextMenu(par_strText As String, par_handler As EventHandler,
                                           Optional pboolAlignment As Boolean = False)
        ''
        ''Added 8/13/2019 td  
        ''
        ''8/13/2019 td''Dim obj_newButton As New Button
        ''  8/14/2019 td''Dim obj_newMenuSingleton As CtlGraphPopMenuEditSingle
        ''  8/14/2019 td''Dim obj_newMenuGroupedItems As CtlGraphPopMenuEditGroup

        ''Moved to _Master procedure. ---8/14/2019 td''mod_bBypassCreateButton = True ''Avoid infinite loops!!   Added 8/13/2019 

        Select Case True

            Case (pboolAlignment)
                ''
                ''Added 8/14/2019 thomas downes
                ''
                If (mod_fauxMenuAlignment Is Nothing) Then
                    mod_fauxMenuAlignment = New CtlGraphPopMenuAlign
                    Me.FormDesigner.Controls.Add(mod_fauxMenuAlignment)
                    AddHandler mod_fauxMenuAlignment.PictureBox1.Click, AddressOf Alignment_Master
                End If ''End fo "If (mod_fauxMenuAlignment Is Nothing) Then"

                With mod_fauxMenuAlignment
                    .Left = Me.Left
                    .Top = (Me.Top + Me.Height + 10)
                    .Visible = True
                    .BringToFront()
                    Application.DoEvents()
                    .SizeToExpectations()
                    Application.DoEvents()
                End With

            Case Me.GroupEdits.LabelsList_OneOrMoreItems

                ''8/14/2019 td''obj_newMenuSingleton = New CtlGraphPopMenuEditGroup
                If (mod_fauxMenuEditGroupedItems Is Nothing) Then
                    mod_fauxMenuEditGroupedItems = New CtlGraphPopMenuEditGroup
                    ''Me.FormDesigner.Controls.Add(obj_newButton)
                    Me.FormDesigner.Controls.Add(mod_fauxMenuEditGroupedItems)
                End If ''End fo "If (mod_fauxMenuEditGroupedItems Is Nothing) Then"

                With mod_fauxMenuEditGroupedItems

                    ''8/13/2019 td''.Text = par_strText
                    ''#1 8/13/2019 td''.Click += par_address
                    '' #2 8/13/2019 td''AddHandler .Click, AddressOf par_handler
                    ''8/14/2019 td''AddHandler .Click, par_handler
                    RemoveHandler .PictureBox1.Click, AddressOf OpenDialog_Color
                    RemoveHandler .PictureBox1.Click, AddressOf OpenDialog_Font
                    RemoveHandler .PictureBox1.Click, AddressOf OpenDialog_Field
                    RemoveHandler .PictureBox1.Click, AddressOf Alignment_Master

                    AddHandler .PictureBox1.Click, par_handler

                    .Left = Me.Left
                    .Top = (Me.Top + Me.Height + 10)
                    .Visible = True
                    .BringToFront()
                    Application.DoEvents()
                    .SizeToExpectations()
                    Application.DoEvents()
                End With

            Case Else

                ''8/14/2019 td''obj_newMenuSingleton = New CtlGraphPopMenuEditSingle
                If (mod_fauxMenuEditSingleton Is Nothing) Then
                    mod_fauxMenuEditSingleton = New CtlGraphPopMenuEditSingle
                    Me.FormDesigner.Controls.Add(mod_fauxMenuEditSingleton)
                End If ''End of "If (mod_fauxMenuEditSingleton Is Nothing) Then"

                With mod_fauxMenuEditSingleton

                    RemoveHandler .PictureBox1.Click, AddressOf OpenDialog_Color
                    RemoveHandler .PictureBox1.Click, AddressOf OpenDialog_Font
                    RemoveHandler .PictureBox1.Click, AddressOf OpenDialog_Field

                    ''8/14/2019 td''AddHandler .Click, par_handler
                    AddHandler .PictureBox1.Click, par_handler

                    .Visible = True
                    .Left = Me.Left
                    .Top = (Me.Top + Me.Height + 10)
                    .Visible = True
                    .BringToFront()
                    Application.DoEvents()
                    .SizeToExpectations()
                    Application.DoEvents()
                End With

        End Select


    End Sub ''End of "Private Sub CreateMouseButton(par_strText As String, par_handler As EventHandler)"

    Private Sub PictureLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureLabel.MouseClick
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolRightClick As Boolean
        Dim boolHoldingCtrlKey As Boolean ''Added 7/31/2019 thomas downes  

        boolRightClick = (e.Button = MouseButtons.Right)

        ''
        ''Added 8/9/2019 td
        ''
        Me.FormDesigner.ControlBeingModified = Me

        ''
        ''I need to be able to determine if the SHIFT or CTRL keys were pressed when the application is launched
        ''     https://stackoverflow.com/questions/22476342/how-to-determine-if-the-shift-or-ctrl-key-was-pressed-when-launching-the-applica
        ''
        boolHoldingCtrlKey = (My.Computer.Keyboard.CtrlKeyDown) ''Added 7/31/2019 td

        ''Added 7/30/2019 thomas downes
        If (boolRightClick) Then
            ''
            ''Encapsulated 8/16/2019 td 
            ''
            RefreshTheContextMenu(e)

        ElseIf (boolHoldingCtrlKey) Then ''Added 7/31/2019 thomas downes
            ''
            ''Added 7/31/2019 thomas downes  
            ''
            ToggleGroupSelection()

        End If ''End of "If (boolRightClick) Then .... ElseIf (boolHoldingCtrlKey) Then ...."

    End Sub  ''End of Sub RefreshTheContextMenu  


    Private Sub RefreshTheContextMenu(par_mouse_info As MouseEventArgs)
        ''
        ''Encapsulated 8/16/2019 td 
        ''
        Dim local_toolStripItems As ToolStripItemCollection ''Added 8/12/2019 thomas 
        Dim bool_I_am_in_GroupOfItems As Boolean ''Added 8/16/2019 td 
        Dim intGroupCount As Integer ''Added 8/16/2019 thomas d. 

        ''Added 7/30/2019 thomas downes
        ''ContextMenuStrip1.Items.Clear()

        Dim boolCreateNewItems As Boolean ''Added 8/12/2019 thomas downes  

        If (mc_AttachContextMenuToTop) Then ''Added 8/12/2019 thomas downes  
            ''8/12/2019 td''boolCreateNewItems = (0 = Me.FormDesigner.RightClickMenuParent.DropDownItems.Count)
            local_toolStripItems = Me.FormDesigner.RightClickMenuParent.DropDownItems
            boolCreateNewItems = (1 >= local_toolStripItems.Count)
        Else
            boolCreateNewItems = (0 = ContextMenuStrip1.Items.Count)
            local_toolStripItems = ContextMenuStrip1.Items
        End If ''End of "If (mc_AttachContextMenuToTop) Then ..... Else ....."

        If (boolCreateNewItems) Then
            ''
            ''Build the context menu.  
            ''
            LoadTheContextMenu(local_toolStripItems) ''Encapsulated 8/12/2019 thomas downes  

        End If ''End of "If (0 = ContextMenuStrip1.Items.Count) Then"

        ''
        ''Is the current elment part of the Group-Edits Selection?  
        ''
        With Me.GroupEdits

            _item_group_add.Visible = .LabelsList_IsItemUnselected(Me)
            _item_group_omit.Visible = .LabelsList_IsItemIncluded(Me)

            bool_I_am_in_GroupOfItems = .LabelsList_TwoOrMoreItems() _
                                       And .LabelsList_IsItemIncluded(Me)

            ''Add 8/2/2019 thomas d.  
            _item_group_add.Visible = bool_I_am_in_GroupOfItems ''.LabelsList_TwoOrMoreItems() _
            ''    And .LabelsList_IsItemIncluded(Me)

            ''Add 8/2/2019 thomas d.  
            _item_group_alignParent.Visible = bool_I_am_in_GroupOfItems ''.LabelsList_TwoOrMoreItems() _
            ''  And .LabelsList_IsItemIncluded(Me)

            ''Add 8/16/2019 thomas d.  
            _item_group_switchDown.Visible = bool_I_am_in_GroupOfItems ''.LabelsList_TwoOrMoreItems() _
            ''   And .LabelsList_IsItemIncluded(Me)
            _item_group_switch__Up.Visible = bool_I_am_in_GroupOfItems ''.LabelsList_TwoOrMoreItems() _
            ''   And .LabelsList_IsItemIncluded(Me)

            ''Add 8/16/2019 thomas d.  
            _item_group_switch__Up.Enabled = .HasAtLeastOne__Up(Me)
            _item_group_switchDown.Enabled = .HasAtLeastOne_Down(Me)

            If (bool_I_am_in_GroupOfItems) Then
                intGroupCount = .LabelsList_CountItems()
                _item_fieldname.Text = $"Group of {intGroupCount} Items (w/ Field " & Me.FieldInfo.FieldLabelCaption & ")"
            Else
                _item_fieldname.Text = "Field " & Me.FieldInfo.FieldLabelCaption
            End If ''Endof " If (bool_I_am_in_GroupOfItems) Then .... Else ...."

        End With ''End of "With Me.GroupEdits"

        ''8/4/2019 td''ContextMenuStrip1.Show(e.Location.X + Me.ParentForm.Left,
        ''8/4/2019 td''               e.Location.Y + Me.Top + Me.ParentForm.Top)

        If (mc_AttachContextMenuToTop) Then
            ''
            ''This might make it visible to the Game Bar Recorder.
            ''  -----8/10/2019 td 
            ''
            Me.FormDesigner.RightClickMenuParent.Visible = True

            ''8//12/2019 td''Me.FormDesigner.RightClickMenuParent.PerformClick() ''Show/display menu.  ---8//12/2018 td
            Application.DoEvents() ''Added 8/12/2019 td  
            Me.FormDesigner.RightClickMenuParent.ShowDropDown() ''Show/display menu.  ---8//12/2018 td

            ''Reference the items in the main menu.  -----8/10/2019 td 
            ''For Each each_menuitem In ContextMenuStrip1.Items
            ''    Me.FormDesigner.RightClickMenuParent.DropDownItems.Add(each_menuitem)
            ''Next each_menuitem

        Else
            With par_mouse_info
                ContextMenuStrip1.Show(.Location.X + Me.Left + Me.ParentForm.Left,
                                       .Location.Y + Me.Top + Me.ParentForm.Top)
            End With ''ENd of " With par_mouse_info"
        End If ''End of "If (mc_AttachContextMenuToTop) Then ... Else ...."

    End Sub  ''End of Sub RefreshTheContextMenu 


    Private Sub ToggleGroupSelection()
        ''
        ''Encapsulated 8/16/2019 thomas downes  
        ''
        ''pictureLabel.BorderStyle = BorderStyle.FixedSingle
        ''
        ''Place a 6-pixel margin around the control, with a yellow color.
        ''   (This will indicate selection.)   ----7/3/2019
        ''
        Dim boolNotIncludedYet As Boolean = (Not mod_includedInGroupEdit) ''Added 8/1/2019
        Dim boolIncludedAlready As Boolean = (mod_includedInGroupEdit)

        If (boolNotIncludedYet) Then

            GroupEditElement_Add()

            ''mod_includedInGroupEdit = True

            ''Me.GroupEdits.LabelsDesignList_Add(Me) ''Added 8/1/2019 td

            ''''8/2/2019''Me.BackColor = Color.Yellow
            ''''8/2/2019''pictureLabel.Top = 6
            ''''8/2/2019''pictureLabel.Left = 6
            ''''8/2/2019''pictureLabel.Width = Me.Width - 2 * 6
            ''''8/2/2019''pictureLabel.Height = Me.Height - 2 * 6

            ''''Added 8/2/2019 td 
            ''Me.ElementInfo.SelectedHighlighting = True
            ''Me.RefreshImage()

        ElseIf (boolIncludedAlready) Then
            ''
            ''Undo the selection. 
            ''
            GroupEditElement_Omit()

            ''mod_includedInGroupEdit = False
            ''Me.GroupEdits.LabelsDesignList_Remove(Me) ''Added 8/1/2019 td

            ''Me.BackColor = Me.ElementInfo.BackColor
            ''pictureLabel.Top = 0
            ''pictureLabel.Left = 0
            ''pictureLabel.Width = Me.Width ''- 2 * 6
            ''pictureLabel.Height = Me.Height ''- 2 * 6

            ''Me.ElementInfo.SelectedHighlighting = False
            ''Me.RefreshImage()

        End If ''Endo f ""If (boolNotIncludedYet) Then .... ElseIf (boolIncludedAlready) Then....

    End Sub ''End of "Private Sub ToggleGroupSelection()"


    Private Sub LoadTheContextMenu(par_toolStripItems As ToolStripItemCollection)
        ''
        ''Encapsulated 8/12/2019 thomas downes  
        ''
        ''8/16/2019 td''Dim new_item_fieldname As ToolStripMenuItem
        Dim new_item_field As ToolStripMenuItem
        Dim new_item_colors As ToolStripMenuItem
        Dim new_item_font As ToolStripMenuItem
        Dim new_item_refresh As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_sizeInfo As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_editExample As ToolStripMenuItem ''Added 8/110/2019 td
        Dim new_item_offsetTextEtc As ToolStripMenuItem ''Added 8/15/2019 td  
        Dim new_item_rotate90 As ToolStripMenuItem ''Added 8/17/2019 td  
        Dim new_item_border As ToolStripMenuItem ''Added 9/02/2019 td  

        ''8/12/2019 td''Static item_group_add As ToolStripMenuItem ''Added 8/2/2019 td
        ''8/12/2019 td''Static item_group_omit As ToolStripMenuItem ''Added 8/2/2019 td

        _item_fieldname = New ToolStripMenuItem("Field " & Me.FieldInfo.FieldLabelCaption)
        ''8/16/2019 td''new_item_fieldname.Font.Bold = True ''Added 8/16/2019 td  
        ''8/16/2019 td''new_item_fieldname.Font = modFonts.MakeItBold(new_item_fieldname.Font)
        modFonts.MakeItBoldEtc(_item_fieldname.Font)

        new_item_refresh = New ToolStripMenuItem("Refresh Element") ''Added 7/31/2019 td
        new_item_sizeInfo = New ToolStripMenuItem("Size Information") ''Added 7/31/2019 td
        new_item_field = New ToolStripMenuItem("Browse Field")

        _item_group_add = New ToolStripMenuItem("Grouping Elements to Edit")
        _item_group_omit = New ToolStripMenuItem("Remove from Grouped Elements")

        new_item_colors = New ToolStripMenuItem("Set Colors")
        new_item_font = New ToolStripMenuItem("Set Font")

        ''Add 8/2/2019 thomas d.  
        _item_group_alignLeft = New ToolStripMenuItem("Left-Hand Edge")
        _item_group_alignRight = New ToolStripMenuItem("Right-Hand Edge")
        ''Add 8/2/2019 thomas d.  
        _item_group_alignWidth = New ToolStripMenuItem("Width")
        _item_group_alignHeight = New ToolStripMenuItem("Height")

        _item_group_alignTop = New ToolStripMenuItem("Top Edge")
        _item_group_alignBottom = New ToolStripMenuItem("Bottom Edge")
        _item_group_alignParent = New ToolStripMenuItem("Align Grouped Elements")

        _item_group_switchDown = New ToolStripMenuItem("Switch Downward in List")
        _item_group_switch__Up = New ToolStripMenuItem("Switch Upward in List")

        ''Added 8/16/2019 td
        _equalizeDistances_Top = New ToolStripMenuItem("Equalize Distances (between Top Edges)")
        _equalizeDistances_Left = New ToolStripMenuItem("Equalize Distances (between Left Edges)")

        ''
        ''Added 8/10/2019 td
        ''
        new_item_editExample = New ToolStripMenuItem("Edit example value (for Layout Design)")

        ''Added 8/15/2019 td  
        new_item_offsetTextEtc = New ToolStripMenuItem("Position text within the element")

        ''Added 8/17/2019 td  
        new_item_rotate90 = New ToolStripMenuItem("Rotate text 90 degrees")

        ''Added 9/02/2019 td  
        new_item_border = New ToolStripMenuItem("Border Size and Color")

        AddHandler new_item_field.Click, AddressOf OpenDialog_Field
        AddHandler new_item_colors.Click, AddressOf OpenDialog_Color
        AddHandler new_item_font.Click, AddressOf OpenDialog_Font

        AddHandler new_item_refresh.Click, AddressOf RefreshElement_Field ''Added 7/31/2019 thomas d.
        AddHandler new_item_sizeInfo.Click, AddressOf GiveSizeInfo_Field ''Added 7/31/2019 thomas d.

        AddHandler _item_group_add.Click, AddressOf GroupEditElement_Add ''Added 8/01/2019 thomas d.
        AddHandler _item_group_omit.Click, AddressOf GroupEditElement_Omit ''Added 8/01/2019 thomas d.

        AddHandler _item_group_switchDown.Click, AddressOf SwitchCtl_Down ''Added 8/15/2019 thomas d.
        AddHandler _item_group_switch__Up.Click, AddressOf SwitchCtl__Up ''Added 8/15/2019 thomas d.

        ''Added 8/10/2019 thomas d.
        AddHandler new_item_editExample.Click, AddressOf ExampleValue_Edit ''Added 8/10/2019 thomas d.

        ''Added 8/15/2019 thomas d.
        AddHandler new_item_offsetTextEtc.Click, AddressOf Open_OffsetTextDialog ''Added 8/15/2019 thomas d.

        ''Added 8/17/2019 thomas d.
        AddHandler new_item_rotate90.Click, AddressOf Rotate90Degrees ''Added 8/17 /2019 thomas d.

        ''Added 8/17/2019 thomas d.
        AddHandler new_item_border.Click, AddressOf BorderDesign ''Added 9/02 /2019 thomas d.

        par_toolStripItems.Add(_item_fieldname)   ''ContextMenuStrip1.Items.Add(new_item_fieldname)
        par_toolStripItems.Add(new_item_field)   ''ContextMenuStrip1.Items.Add(new_item_field)

        par_toolStripItems.Add(new_item_colors)   ''ContextMenuStrip1.Items.Add(new_item_colors)
        par_toolStripItems.Add(new_item_font)   ''ContextMenuStrip1.Items.Add(new_item_font)

        ''Added 8/17/2019 td
        par_toolStripItems.Add(new_item_offsetTextEtc)
        par_toolStripItems.Add(new_item_rotate90)
        par_toolStripItems.Add(new_item_border) ''Added 9/2/2019 td

        ''Moved from below, 8/14/2019 td 
        par_toolStripItems.Add(_item_group_alignParent)   ''ContextMenuStrip1.Items.Add(item_group_alignParent) ''Added 8/5/2019 thomas d.  

        par_toolStripItems.Add(new_item_refresh)   ''ContextMenuStrip1.Items.Add(new_item_refresh) ''Added 7/31/2019 thomas d.  
        par_toolStripItems.Add(new_item_sizeInfo)   ''ContextMenuStrip1.Items.Add(new_item_sizeInfo) ''Added 7/31/2019 thomas d.

        ''If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then
        par_toolStripItems.Add(_item_group_add)   ''ContextMenuStrip1.Items.Add(new_item_group_add) ''Added 8/01/2019 thomas d.  
        ''End If

        ''If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then
        par_toolStripItems.Add(_item_group_omit)   ''ContextMenuStrip1.Items.Add(new_item_group_omit) ''Added 8/01/2019 thomas d.  
        ''End If

        ''Add 8/16/2019 thomas d.  
        par_toolStripItems.Add(_item_group_switch__Up)
        par_toolStripItems.Add(_item_group_switchDown)

        ''Add 8/2/2019 thomas d.  
        ''8/5/2019 td''ContextMenuStrip1.Items.Add(new_item_group_alignLeft) ''Added 8/01/2019 thomas d.  
        ''8/5/2019 td''ContextMenuStrip1.Items.Add(new_item_group_alignRight) ''Added 8/01/2019 thomas d.  

        ''Add 8/5/2019 thomas d.  
        ''Moved to the top.par_toolStripItems.Add(_item_group_alignParent)   ''ContextMenuStrip1.Items.Add(item_group_alignParent) ''Added 8/5/2019 thomas d.

        Dim toolstripAlignParent As ToolStripMenuItem = CType(_item_group_alignParent, ToolStripMenuItem)

        ''Added 8/10/2019 thomas d.
        par_toolStripItems.Add(new_item_editExample)   ''ContextMenuStrip1.Items.Add(new_item_editExample) ''Added 8/10/2019 thomas d.  

        ''
        ''Add 8/5/2019 thomas d.  
        ''
        With toolstripAlignParent.DropDownItems

            .Add(_item_group_alignLeft)
            .Add(_item_group_alignRight)

            .Add(_item_group_alignTop)
            .Add(_item_group_alignBottom)

            .Add(_item_group_alignWidth)
            .Add(_item_group_alignHeight)

            ''Added 8/16/2019 thoimas downes 
            .Add(_equalizeDistances_Top)
            .Add(_equalizeDistances_Left)

        End With ''End of "With toolstripAlignParent.DropDownItems"

        ''
        ''Add 8/5/2019 thomas d.  
        ''
        AddHandler _item_group_alignLeft.Click, AddressOf Alignment_Master
        AddHandler _item_group_alignRight.Click, AddressOf Alignment_Master

        AddHandler _item_group_alignTop.Click, AddressOf Alignment_Master
        AddHandler _item_group_alignBottom.Click, AddressOf Alignment_Master

        AddHandler _item_group_alignWidth.Click, AddressOf Alignment_Master
        AddHandler _item_group_alignHeight.Click, AddressOf Alignment_Master

        ''Add 8/16/2019 thomas d.  
        AddHandler _equalizeDistances_Left.Click, AddressOf Alignment_Master
        AddHandler _equalizeDistances_Top.Click, AddressOf Alignment_Master

    End Sub ''End of "Private Sub LoadTheContextMenu()" 

End Class
