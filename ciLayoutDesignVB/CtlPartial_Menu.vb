
''
''
''

Partial Public Class CtlGraphicFldLabel


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

        ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
        Me.ElementInfo.BackColor = ColorDialog1.Color
        Me.ElementInfo.Back_Color = ColorDialog1.Color

        ''Me.ElementInfo.Width_Pixels = Me.Width
        ''Me.ElementInfo.Height_Pixels = Me.Height

        Application.DoEvents()
        Application.DoEvents()

        RefreshImage()
        Me.Refresh()

        ''Added 8/3/2019 td 
        Dim objElements As List(Of CtlGraphicFldLabel)
        objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems
        If (objElements.Count = 0) Then
            objElements.Add(Me)
        End If

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

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub OpenDialog_Font(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        FontDialog1.Font = Me.ElementInfo.Font_AllInfo ''Added 7/31/2019 td  

        FontDialog1.ShowDialog()

        Me.ElementInfo.Font_AllInfo = FontDialog1.Font

        Application.DoEvents()
        Application.DoEvents()

        RefreshImage()
        Me.Refresh()

        ''Added 8/3/2019 td 
        Dim objElements As List(Of CtlGraphicFldLabel)
        objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems
        If (objElements.Count = 0) Then
            objElements.Add(Me)
        End If ''End of " If (objElements.Count = 0) Then"

        For Each each_ctl As CtlGraphicFldLabel In objElements
            ''
            ''Added 8/3/2019 td  
            ''
            With each_ctl

                .ElementInfo.Font_AllInfo = FontDialog1.Font
                .RefreshImage()
                .Refresh()

            End With

        Next each_ctl

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

        Static new_item_group_add As ToolStripMenuItem ''Added 8/2/2019 td
        Static new_item_group_omit As ToolStripMenuItem ''Added 8/2/2019 td

        Static new_item_group_alignLeft As ToolStripMenuItem ''Added 8/2/2019 td
        Static new_item_group_alignRight As ToolStripMenuItem ''Added 8/2/2019 td

        boolRightClick = (e.Button = MouseButtons.Right)

        ''I need to be able to determine if the SHIFT or CTRL keys were pressed when the application is launched
        ''     https://stackoverflow.com/questions/22476342/how-to-determine-if-the-shift-or-ctrl-key-was-pressed-when-launching-the-applica
        ''
        boolHoldingCtrlKey = (My.Computer.Keyboard.CtrlKeyDown) ''Added 7/31/2019 td

        ''Added 7/30/2019 thomas downes
        If (boolRightClick) Then

            ''Added 7/30/2019 thomas downes
            ''ContextMenuStrip1.Items.Clear()

            If (0 = ContextMenuStrip1.Items.Count) Then

                new_item_fieldname = New ToolStripMenuItem("Field " & Me.FieldInfo.FieldLabelCaption)
                new_item_refresh = New ToolStripMenuItem("Refresh Element") ''Added 7/31/2019 td
                new_item_sizeInfo = New ToolStripMenuItem("Size Information") ''Added 7/31/2019 td
                new_item_field = New ToolStripMenuItem("Browse Field")
                new_item_group_add = New ToolStripMenuItem("Grouping Elements to Edit")
                new_item_group_omit = New ToolStripMenuItem("Remove from Grouped Elements")

                new_item_colors = New ToolStripMenuItem("Set Colors")
                new_item_font = New ToolStripMenuItem("Set Font")

                ''Add 8/2/2019 thomas d.  
                new_item_group_alignLeft = New ToolStripMenuItem("Align Grouped Elements (Right-Hand Edge)")
                new_item_group_alignRight = New ToolStripMenuItem("Align Grouped Elements (Left-Hand Edge)")

                AddHandler new_item_field.Click, AddressOf OpenDialog_Field
                AddHandler new_item_colors.Click, AddressOf OpenDialog_Color
                AddHandler new_item_font.Click, AddressOf OpenDialog_Font

                AddHandler new_item_refresh.Click, AddressOf RefreshElement_Field ''Added 7/31/2019 thomas d.
                AddHandler new_item_sizeInfo.Click, AddressOf GiveSizeInfo_Field ''Added 7/31/2019 thomas d.

                AddHandler new_item_group_add.Click, AddressOf GroupEditElement_Add ''Added 8/01/2019 thomas d.
                AddHandler new_item_group_add.Click, AddressOf GroupEditElement_Omit ''Added 8/01/2019 thomas d.

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
                ContextMenuStrip1.Items.Add(new_item_group_alignLeft) ''Added 8/01/2019 thomas d.  
                ContextMenuStrip1.Items.Add(new_item_group_alignRight) ''Added 8/01/2019 thomas d.  

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

            End With ''End of "With Me.GroupEdits"

            ContextMenuStrip1.Show(e.Location.X + Me.ParentForm.Left,
                                   e.Location.Y + Me.Top + Me.ParentForm.Top)


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
