
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

    Private item_group_alignLeft As ToolStripMenuItem ''Added 8/2/2019 td
    Private item_group_alignRight As ToolStripMenuItem ''Added 8/2/2019 td
    Private item_group_alignWidth As ToolStripMenuItem ''Added 8/5/2019 td
    Private item_group_alignHeight As ToolStripMenuItem ''Added 8/5/2019 td
    Private item_group_alignTop As ToolStripMenuItem ''Added 8/5/2019 td
    Private item_group_alignBottom As ToolStripMenuItem ''Added 8/5/2019 td
    Private item_group_alignParent As ToolStripMenuItem ''Added 8/5/2019 td

    Private Const mc_AttachContextMenuToTop As Boolean = True ''Added 8/5/2019 td 

    Private Sub OpenDialog_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ''7/30/2019 td''ColorDialog1.ShowDialog()
        Dim form_ToShow As New FormCustomFieldsFlow

        ''Can (should) we just show a single field? ''form_ToShow.JustOneField = Me.FieldInfo
        form_ToShow.JustOneField_Index = Me.FieldInfo.FieldIndex

        form_ToShow.Show()

    End Sub ''eNd of "Private Sub opendialog_Field()"

    Private Sub OpenDialog_Color(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ColorDialog1.ShowDialog()

        If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then

            ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
            Me.ElementInfo.BackColor = ColorDialog1.Color
            Me.ElementInfo.Back_Color = ColorDialog1.Color

            ''Me.ElementInfo.Width_Pixels = Me.Width
            ''Me.ElementInfo.Height_Pixels = Me.Height

            Application.DoEvents()
            Application.DoEvents()

            RefreshImage()
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

                    .ElementInfo.BackColor = ColorDialog1.Color
                    .ElementInfo.Back_Color = ColorDialog1.Color
                    ''.ElementInfo.Width_Pixels = Me.Width
                    ''.ElementInfo.Height_Pixels = Me.Height

                    .RefreshImage()
                    .Refresh()

                End With

            Next each_ctl

        End If

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub OpenDialog_Font(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        FontDialog1.Font = Me.ElementInfo.Font_AllInfo ''Added 7/31/2019 td  
        FontDialog1.ShowDialog()

        ''Me.ElementInfo.Font_AllInfo = FontDialog1.Font
        ''Application.DoEvents()
        ''Application.DoEvents()
        ''RefreshImage()
        ''Me.Refresh()

        If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then

            Me.ElementInfo.Font_AllInfo = FontDialog1.Font
            Application.DoEvents()
            Application.DoEvents()

            RefreshImage()
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

                    .ElementInfo.Font_AllInfo = FontDialog1.Font
                    Application.DoEvents()
                    Application.DoEvents()
                    .RefreshImage()
                    .Refresh()

                End With

            Next each_ctl

        End If ''End of "If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then... Else ..."

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
        Me.ElementInfo.SelectedHighlighting = True
        Me.RefreshImage()

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
        Me.ElementInfo.SelectedHighlighting = False
        Me.RefreshImage()

    End Sub ''End of "Private Sub GroupEditElement_Omit( )"

    Private Sub Alignment_Master(sender As Object, e As EventArgs)
        ''
        ''Added 8/5/2019 thomas downes
        ''
        Dim objElements As List(Of CtlGraphicFldLabel)
        Dim sender_toolItem As ToolStripItem

        If (Not TypeOf sender Is ToolStripMenuItem) Then Exit Sub
        sender_toolItem = CType(sender, ToolStripMenuItem)

        objElements = Me.GroupEdits.LabelsDesignList_AllItems

        For Each each_ctl As CtlGraphicFldLabel In objElements
            ''
            ''Added 8/5/2019 td  
            ''
            With each_ctl

                Select Case (sender_toolItem.Text)
                    Case (item_group_alignTop.Text) : each_ctl.Top = Me.Top

                    Case (item_group_alignLeft.Text) : each_ctl.Left = Me.Left

                    Case (item_group_alignWidth.Text)

                        each_ctl.Width = Me.Width
                        each_ctl.ElementInfo.Width_Pixels = Me.Width

                    Case (item_group_alignHeight.Text)

                        each_ctl.Height = Me.Height
                        each_ctl.ElementInfo.Height_Pixels = Me.Height

                End Select

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

            End With

        Next each_ctl

    End Sub ''eNd of "Private Sub Alignment_Master()"

    Private Sub ExampleValue_Edit()
        ''
        ''Added 8/10/2019 thomas downes
        ''
        textTypeExample.Visible = True

    End Sub ''End of "Private Sub ExampleValue_Edit"  

    Private Sub PictureLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureLabel.MouseClick
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolRightClick As Boolean
        Dim boolHoldingCtrlKey As Boolean ''Added 7/31/2019 thomas downes  

        Dim new_item_fieldname As ToolStripMenuItem
        Dim new_item_field As ToolStripMenuItem
        Dim new_item_colors As ToolStripMenuItem
        Dim new_item_font As ToolStripMenuItem
        Dim new_item_refresh As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_sizeInfo As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_editExample As ToolStripMenuItem ''Added 8/110/2019 td

        Static new_item_group_add As ToolStripMenuItem ''Added 8/2/2019 td
        Static new_item_group_omit As ToolStripMenuItem ''Added 8/2/2019 td

        boolRightClick = (e.Button = MouseButtons.Right)

        ''
        ''Added 8/9/2019 td
        ''
        Me.FormDesigner.ControlBeingModified = Me

        ''I need to be able to determine if the SHIFT or CTRL keys were pressed when the application is launched
        ''     https://stackoverflow.com/questions/22476342/how-to-determine-if-the-shift-or-ctrl-key-was-pressed-when-launching-the-applica
        ''
        boolHoldingCtrlKey = (My.Computer.Keyboard.CtrlKeyDown) ''Added 7/31/2019 td

        ''Added 7/30/2019 thomas downes
        If (boolRightClick) Then

            ''Added 7/30/2019 thomas downes
            ''ContextMenuStrip1.Items.Clear()

            Dim boolCreateNewItems As Boolean
            If (mc_AttachContextMenuToTop) Then
                boolCreateNewItems = (0 = Me.FormDesigner.RightClickMenuParent.DropDownItems.Count)
            Else
                boolCreateNewItems = (0 = ContextMenuStrip1.Items.Count)
            End If

            If (boolCreateNewItems) Then

                new_item_fieldname = New ToolStripMenuItem("Field " & Me.FieldInfo.FieldLabelCaption)
                new_item_refresh = New ToolStripMenuItem("Refresh Element") ''Added 7/31/2019 td
                new_item_sizeInfo = New ToolStripMenuItem("Size Information") ''Added 7/31/2019 td
                new_item_field = New ToolStripMenuItem("Browse Field")
                new_item_group_add = New ToolStripMenuItem("Grouping Elements to Edit")
                new_item_group_omit = New ToolStripMenuItem("Remove from Grouped Elements")

                new_item_colors = New ToolStripMenuItem("Set Colors")
                new_item_font = New ToolStripMenuItem("Set Font")

                ''Add 8/2/2019 thomas d.  
                item_group_alignLeft = New ToolStripMenuItem("Left-Hand Edge")
                item_group_alignRight = New ToolStripMenuItem("Right-Hand Edge")
                ''Add 8/2/2019 thomas d.  
                item_group_alignWidth = New ToolStripMenuItem("Width")
                item_group_alignHeight = New ToolStripMenuItem("Height")

                item_group_alignTop = New ToolStripMenuItem("Top Edge")
                item_group_alignBottom = New ToolStripMenuItem("Bottom Edge")
                item_group_alignParent = New ToolStripMenuItem("Align Grouped Elements")

                ''Added 8/10/2019 td
                ''
                new_item_editExample = New ToolStripMenuItem("Edit example value (for Layout Design)")

                AddHandler new_item_field.Click, AddressOf OpenDialog_Field
                AddHandler new_item_colors.Click, AddressOf OpenDialog_Color
                AddHandler new_item_font.Click, AddressOf OpenDialog_Font

                AddHandler new_item_refresh.Click, AddressOf RefreshElement_Field ''Added 7/31/2019 thomas d.
                AddHandler new_item_sizeInfo.Click, AddressOf GiveSizeInfo_Field ''Added 7/31/2019 thomas d.

                AddHandler new_item_group_add.Click, AddressOf GroupEditElement_Add ''Added 8/01/2019 thomas d.
                AddHandler new_item_group_add.Click, AddressOf GroupEditElement_Omit ''Added 8/01/2019 thomas d.

                ''Added 8/10/2019 thomas d.
                AddHandler new_item_editExample.Click, AddressOf ExampleValue_Edit ''Added 8/10/2019 thomas d.

                ContextMenuStrip1.Items.Add(new_item_fieldname)
                ContextMenuStrip1.Items.Add(new_item_field)

                ContextMenuStrip1.Items.Add(new_item_colors)
                ContextMenuStrip1.Items.Add(new_item_font)

                ContextMenuStrip1.Items.Add(new_item_refresh) ''Added 7/31/2019 thomas d.  
                ContextMenuStrip1.Items.Add(new_item_sizeInfo) ''Added 7/31/2019 thomas d.

                ''If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then
                ContextMenuStrip1.Items.Add(new_item_group_add) ''Added 8/01/2019 thomas d.  
                ''End If

                ''If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then
                ContextMenuStrip1.Items.Add(new_item_group_omit) ''Added 8/01/2019 thomas d.  
                ''End If

                ''Add 8/2/2019 thomas d.  
                ''8/5/2019 td''ContextMenuStrip1.Items.Add(new_item_group_alignLeft) ''Added 8/01/2019 thomas d.  
                ''8/5/2019 td''ContextMenuStrip1.Items.Add(new_item_group_alignRight) ''Added 8/01/2019 thomas d.  

                ''Add 8/5/2019 thomas d.  
                ContextMenuStrip1.Items.Add(item_group_alignParent) ''Added 8/5/2019 thomas d.  
                Dim toolstripAlign As ToolStripMenuItem = CType(item_group_alignParent, ToolStripMenuItem)

                ''Added 8/10/2019 thomas d.
                ContextMenuStrip1.Items.Add(new_item_editExample) ''Added 8/10/2019 thomas d.  

                ''
                ''Add 8/5/2019 thomas d.  
                ''
                toolstripAlign.DropDownItems.Add(item_group_alignLeft)
                toolstripAlign.DropDownItems.Add(item_group_alignRight)

                toolstripAlign.DropDownItems.Add(item_group_alignTop)
                toolstripAlign.DropDownItems.Add(item_group_alignBottom)

                toolstripAlign.DropDownItems.Add(item_group_alignWidth)
                toolstripAlign.DropDownItems.Add(item_group_alignHeight)

                ''
                ''Add 8/5/2019 thomas d.  
                ''
                AddHandler item_group_alignLeft.Click, AddressOf Alignment_Master
                AddHandler item_group_alignRight.Click, AddressOf Alignment_Master

                AddHandler item_group_alignTop.Click, AddressOf Alignment_Master
                AddHandler item_group_alignBottom.Click, AddressOf Alignment_Master

                AddHandler item_group_alignWidth.Click, AddressOf Alignment_Master
                AddHandler item_group_alignHeight.Click, AddressOf Alignment_Master

            End If ''End of "If (0 = ContextMenuStrip1.Items.Count) Then"

            ''
            ''Is the current elment part of the Group-Edits Selection?  
            ''
            With Me.GroupEdits

                new_item_group_add.Visible = .LabelsList_IsItemUnselected(Me)
                new_item_group_omit.Visible = .LabelsList_IsItemIncluded(Me)

                ''Add 8/2/2019 thomas d.  
                new_item_group_add.Visible = .LabelsList_TwoOrMoreItems() _
                                             And .LabelsList_IsItemIncluded(Me)

                ''Add 8/2/2019 thomas d.  
                item_group_alignParent.Visible = .LabelsList_TwoOrMoreItems() _
                                             And .LabelsList_IsItemIncluded(Me)

            End With ''End of "With Me.GroupEdits"

            ''8/4/2019 td''ContextMenuStrip1.Show(e.Location.X + Me.ParentForm.Left,
            ''8/4/2019 td''               e.Location.Y + Me.Top + Me.ParentForm.Top)

            If (mc_AttachContextMenuToTop) Then
                ''
                ''This might make it visible to the Game Bar Recorder.
                ''  -----8/10/2019 td 
                ''
                Me.FormDesigner.RightClickMenuParent.Visible = True

                ''Reference the items in the main menu.  -----8/10/2019 td 
                ''For Each each_menuitem In ContextMenuStrip1.Items
                ''    Me.FormDesigner.RightClickMenuParent.DropDownItems.Add(each_menuitem)
                ''Next each_menuitem

            Else
                ContextMenuStrip1.Show(e.Location.X + Me.Left + Me.ParentForm.Left,
                                       e.Location.Y + Me.Top + Me.ParentForm.Top)
            End If ''End of "If (mc_AttachContextMenuToTop) Then ... Else ...."

        ElseIf (boolHoldingCtrlKey) Then ''Added 7/31/2019 thomas downes
            ''
            ''Added 7/31/2019 thomas downes  
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

            End If ''Endo f ""If (....) Then .... ElseIf (....) Then....

        End If ''End of "If (boolRightClick) Then .... Else ...."

    End Sub

End Class
