Option Explicit On
Option Strict On
''
''Added 2/16/2022 td
''
Imports System.Windows.Forms ''Added 2/16/2022 td
Imports ciBadgeCustomer ''Added 2/16/2022 tdy 
''Imports ciBadgeCachePersonality ''Added 2/20/2022 td

Public Class PopulateCustomers
    ''
    ''Added 2/16/2022 td
    ''
    Private mod_widthsSplitContainers As SplitContainerWidths ''Added 2/202/2022 td

    Public Property UserControlWidths As SplitContainerWidths
        ''Added 2/20/2022 td  
        Get
            Return mod_widthsSplitContainers
        End Get
        Set(value As SplitContainerWidths)
            mod_widthsSplitContainers = value
        End Set
    End Property


    Public Sub Load_SplitterWidths(par_widths As SplitContainerWidths)
        ''
        ''Added 2/20/2022 td
        ''
        Dim bNonZero1 As Boolean
        Dim bNonZero2 As Boolean

        mod_widthsSplitContainers = par_widths

        SplitContainer0.Anchor = AnchorStyles.None
        SplitContainer1.Anchor = AnchorStyles.None
        SplitContainer2.Anchor = AnchorStyles.None
        SplitContainer3.Anchor = AnchorStyles.None

        ''Check for non-zero values.
        bNonZero1 = (0 < par_widths.SplitContainer0_Width)
        bNonZero2 = (0 < par_widths.SplitContainer0_SplitterDistance)

        If bNonZero1 Then
            SplitContainer0.Width = par_widths.SplitContainer0_Width
            Application.DoEvents()
            SplitContainer1.Width = par_widths.SplitContainer1_Width
            Application.DoEvents()
            SplitContainer2.Width = par_widths.SplitContainer2_Width
            Application.DoEvents()
            SplitContainer3.Width = par_widths.SplitContainer3_Width
            Application.DoEvents()
        End If ''End of "If bNonZero1 Then"

        If bNonZero1 Then
            SplitContainer0.SplitterDistance = par_widths.SplitContainer0_SplitterDistance
            Application.DoEvents()
            SplitContainer1.SplitterDistance = par_widths.SplitContainer1_SplitterDistance
            Application.DoEvents()
            SplitContainer2.SplitterDistance = par_widths.SplitContainer2_SplitterDistance
            Application.DoEvents()

            ''Added 2/20/2022 thomas downes 
            If (SplitContainer3.Left < 0) Then ''E.g. is -152 on 2/20/2022 
                SplitContainer3.Left = 0 ''Needed, for some reason. The value of -152 is too negative!!
            End If ''End of "If (SplitContainer3.Left < 0) Then"

            Application.DoEvents()
            SplitContainer3.SplitterDistance = par_widths.SplitContainer3_SplitterDistance
            Application.DoEvents()
        End If ''End of "If bNonZero2 Then"

ExitHandler:
        Dim anchor_LeftTopRight As AnchorStyles
        Application.DoEvents()
        anchor_LeftTopRight = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SplitContainer0.Anchor = anchor_LeftTopRight
        SplitContainer1.Anchor = anchor_LeftTopRight
        SplitContainer2.Anchor = anchor_LeftTopRight
        SplitContainer3.Anchor = anchor_LeftTopRight

    End Sub ''End of "Public Sub Load_SplitterWidths"


    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked

    End Sub

    Private Sub PanelCustomerCode_Paint(sender As Object, e As Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles checkbox1.CheckedChanged, checkbox2.CheckedChanged, checkbox3.CheckedChanged,
      checkbox4.CheckedChanged, checkbox5.CheckedChanged, checkbox6.CheckedChanged,
      checkbox7.CheckedChanged, checkbox8.CheckedChanged, checkbox9.CheckedChanged,
        checkbox10.CheckedChanged, checkbox11.CheckedChanged, checkbox12.CheckedChanged
        ''
        ''Added 2/16/2022 thomas downes
        ''
        Dim sender_checkbox As CheckBox
        ''----Dim row_checkboxClass As ciBadgeCustomer.ClassRowCustomer
        Dim row_checkboxClass As ClassRowOfControlsPerCustomer
        Dim intIndex As Integer

        sender_checkbox = CType(sender, Windows.Forms.CheckBox)

        If (sender_checkbox Is checkbox1) Then intIndex = 1
        If (sender_checkbox Is checkbox2) Then intIndex = 2
        If (sender_checkbox Is checkbox3) Then intIndex = 3
        If (sender_checkbox Is checkbox4) Then intIndex = 4
        If (sender_checkbox Is checkbox5) Then intIndex = 5
        If (sender_checkbox Is checkbox6) Then intIndex = 6
        If (sender_checkbox Is checkbox7) Then intIndex = 7
        If (sender_checkbox Is checkbox8) Then intIndex = 8
        If (sender_checkbox Is checkbox9) Then intIndex = 9
        If (sender_checkbox Is checkbox10) Then intIndex = 10
        If (sender_checkbox Is checkbox11) Then intIndex = 11
        If (sender_checkbox Is checkbox12) Then intIndex = 12

        If (intIndex = 0) Then Throw New Exception("Checkbox is not recognized.")

        If (sender_checkbox.Tag IsNot Nothing) Then

            row_checkboxClass = CType(sender_checkbox.Tag, ClassRowOfControlsPerCustomer)
            ActivateRow_PrepareForDataEntry(row_checkboxClass)

        Else

            ''MessageBoxTD.Show_Statement("Sorry, unable to activate this Customer row.")
            sender_checkbox.Tag = New ClassRowOfControlsPerCustomer(Me, intIndex, True)
            row_checkboxClass = CType(sender_checkbox.Tag, ClassRowOfControlsPerCustomer)
            ActivateRow_PrepareForDataEntry(row_checkboxClass)

        End If ''End of "If (sender_checkbox.Tag IsNot Nothing) Then... Else ..."

    End Sub


    Private Sub ActivateRow_PrepareForDataEntry(par_controlsetClass As ClassRowOfControlsPerCustomer)
        ''
        ''Added 2/17/2022 thomas downes
        ''
        With par_controlsetClass

            If (.TextboxCode.Text = "Example") Then .TextboxCode.Text = ""
            If (.TextboxNameFull.Text = "Example") Then .TextboxNameFull.Text = ""
            If (.TextboxNameShort.Text = "Example") Then .TextboxNameShort.Text = ""
            If (.TextboxNotes.Text = "Example") Then .TextboxNotes.Text = ""

            .TextboxCode.ForeColor = System.Drawing.Color.Black
            .TextboxNameFull.ForeColor = System.Drawing.Color.Black
            .TextboxNotes.ForeColor = System.Drawing.Color.Black
            ''Added 2/17/2022 td
            .TextboxNameShort.ForeColor = System.Drawing.Color.Black

            .TextboxCode.BackColor = System.Drawing.Color.White
            .TextboxNameFull.BackColor = System.Drawing.Color.White
            .TextboxNotes.BackColor = System.Drawing.Color.White
            ''Added 2/17/2022 td
            .TextboxNameShort.BackColor = System.Drawing.Color.White

            ''Added 2/17/2022 td
            .TextboxCode.Refresh()
            .TextboxNameFull.Refresh()
            .TextboxNameShort.Refresh()
            .TextboxNotes.Refresh()

        End With ''End of "With par_controlsetClass"



    End Sub  ''End of "Private Sub ActivateRow_PrepareForDataEntry"


    Public Function Save_GetCustomerList() As HashSet(Of ClassCustomer)
        ''
        ''Added 2/17/2022 t.h.o.m.a.s d.o.w.n.e.s.
        ''
        Dim each_checkbox As CheckBox
        Dim each_customer As ClassCustomer
        Dim each_row_controlsetClass As ClassRowOfControlsPerCustomer
        Dim each_bCustomerIsNull As Boolean ''Added 2/17/2022 t/h/o/m/a/s/ /d/o/w/n/e/s/ 
        Dim each_bCustomerInactive As Boolean ''Added 2/17/2022 t/h/o/m/a/s/ /d/o/w/n/e/s/ 
        Dim output_hashset As New HashSet(Of ClassCustomer)
        Dim bMustCreateCustomer As Boolean ''Added 2/17/2022 td

        ''each_checkbox = CType(sender, Windows.Forms.CheckBox)

        Dim arrayCheckboxes As CheckBox()

        arrayCheckboxes = New CheckBox() {checkbox1, checkbox2, checkbox3,
                 checkbox4, checkbox5, checkbox6,
                 checkbox7, checkbox8, checkbox9,
                 checkbox10, checkbox11, checkbox12}

        For Each each_checkbox In arrayCheckboxes

            ''Reinitialize. 
            each_customer = Nothing
            each_row_controlsetClass = Nothing

            If (each_checkbox.Tag IsNot Nothing) Then

                each_row_controlsetClass = CType(each_checkbox.Tag, ClassRowOfControlsPerCustomer)

                ''Check consistency 
                With each_row_controlsetClass
                    each_bCustomerIsNull = (.Customer Is Nothing) ''Feb17 2022 = .CustomerIsNull
                    each_bCustomerInactive = (Not .CheckboxActive.Checked)
                    each_customer = .Customer

                    ''Added 2/17/2022  
                    bMustCreateCustomer = (each_bCustomerIsNull And (Not each_bCustomerInactive))

                    If (bMustCreateCustomer) Then
                        .Customer = New ClassCustomer()
                        each_bCustomerIsNull = (.Customer Is Nothing) ''Feb17 2022 = .CustomerIsNull
                        each_customer = .Customer

                    ElseIf (each_bCustomerIsNull) Then
                        ''Added 2/17/2022 thomas d. 
                        If (False) Then Throw New Exception("Why is this code executing? Might cause null reference.")

                    End If ''End of "If (bMustCreateCustomer) Then .... ElseIf (...) Then"

                End With ''End of "With each_row_controlsetClass"

                If (each_bCustomerInactive And (Not each_bCustomerIsNull)) Then
                    ''
                    ''Don't save the inactive record.  Just turn on the
                    ''  "Deactivated" flag.  
                    ''
                    each_customer.Deactivated = (Not each_row_controlsetClass.CheckboxActive.Checked) ''True

                Else

                    With each_customer

                        If (each_customer Is Nothing) Then Throw New Exception("Why is customer Null?")

                        .AlphanumericCode = each_row_controlsetClass.TextboxCode.Text
                        .Description = each_row_controlsetClass.TextboxNotes.Text
                        .NameFull = each_row_controlsetClass.TextboxNameFull.Text
                        .NameShort = each_row_controlsetClass.TextboxNameShort.Text
                        ''Needed??? ----2/17/2022
                        .Deactivated = (Not each_row_controlsetClass.CheckboxActive.Checked)

                    End With ''End of "With each_customer"

                End If ''End of ""If (each_row_controlsetClass.CustomerIsNull) Then .... Else ...."

            End If ''End of "If (sender_checkbox.Tag IsNot Nothing) Then... Else ..."

            ''
            ''Added 2/18/2022 td 
            ''
            Dim bDoneGuid As Boolean ''Added 2/18/2022 td

            ''
            ''Collect the customer objects. 
            ''
            If (each_customer IsNot Nothing) Then

                ''bDoneGuid = String.IsNullOrEmpty(each_customer.CustomerGUID.ToString()) = False _
                ''        AndAlso (each_customer.CustomerGUID.ToString().StartsWith("00000000") = False)
                bDoneGuid = modUtilities.GuidIsFine(each_customer.CustomerGUID)

                If (Not bDoneGuid) Then
                    Do
                        ''Feb18 2022 td''each_customer.CustomerGUID = New System.Guid()
                        each_customer.CustomerGUID = System.Guid.NewGuid()
                        each_customer.CustomerGUID6char = each_customer.CustomerGUID.ToString().Substring(0, 6)
                        bDoneGuid = modUtilities.GuidIsFine(each_customer.CustomerGUID)

                    Loop Until bDoneGuid
                End If ''End of "If (Not bDoneGuid) Then"

            End If ''end of "If (each_customer IsNot Nothing) Then"

            ''
            ''Place the customer record onto the output parameter!!  
            ''
            If (each_customer IsNot Nothing) Then
                output_hashset.Add(each_customer)
            End If ''end of "If (each_customer IsNot Nothing) Then"

        Next each_checkbox

        ''
        ''Added 2/20/2022
        ''
        If (mod_widthsSplitContainers Is Nothing) Then
            mod_widthsSplitContainers = New SplitContainerWidths()
        End If ''End of "If (mod_widthsSplitContainers Is Nothing) Then"

        With mod_widthsSplitContainers

            .UserControlWidth = Me.Width ''Added 2/20/2022 td 

            .SplitContainer0_Width = SplitContainer0.Width
            .SplitContainer1_Width = SplitContainer1.Width
            .SplitContainer2_Width = SplitContainer2.Width
            .SplitContainer3_Width = SplitContainer3.Width

            .SplitContainer0_SplitterDistance = SplitContainer0.SplitterDistance
            .SplitContainer1_SplitterDistance = SplitContainer1.SplitterDistance
            .SplitContainer2_SplitterDistance = SplitContainer2.SplitterDistance
            .SplitContainer3_SplitterDistance = SplitContainer3.SplitterDistance

        End With ''End of "With mod_widthsSplitContainers"

        ''
        ''Output. 
        ''
        Return output_hashset

    End Function ''End of "Public Function Save_GetCustomerList()"

    Public Sub CheckRightMargin()
        ''
        ''Added 2/19/2022
        ''
        SplitContainer0.Left = 0
        If SplitContainer0.Width <= Me.Width Then SplitContainer0.Width = Me.Width - 10
        SplitContainer1.Left = 0
        If SplitContainer1.Width <= SplitContainer0.Width Then SplitContainer1.Width = SplitContainer0.Width - 10
        SplitContainer2.Left = 0
        If SplitContainer2.Width <= SplitContainer1.Width Then SplitContainer2.Width = SplitContainer1.Width - 10
        SplitContainer3.Left = 0
        If SplitContainer3.Width <= SplitContainer2.Width Then SplitContainer3.Width = SplitContainer2.Width - 10

        ''
        ''Check the Splitter Distance  
        ''
        If SplitContainer3.SplitterDistance > (0.8 * SplitContainer3.Width) Then SplitContainer3.SplitterDistance = CInt(0.8 * SplitContainer3.Width)

        ''If SplitContainer2.SplitterDistance > (0.8 * SplitContainer2.Width) Then SplitContainer2.SplitterDistance = CInt(0.8 * SplitContainer2.Width)

        Me.Refresh()

    End Sub ''end of "Public Sub CheckRightMargin()"



    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub textboxName1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub checkbox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox1.CheckedChanged

    End Sub

    Private Sub SplitContainer0_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer0.Panel1.Paint

    End Sub

    Private Sub textboxNameShort1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabelCheckRightMargin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCheckRightMargin.LinkClicked
        ''
        ''Added 2/19/2022 t;h;o;m;a;s; ;d;o;w;n;e;s;
        ''
        CheckRightMargin()

    End Sub

    Private Sub LinkLabelCheckMargin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCheckMargin3.LinkClicked
        ''
        '' Added 2/19/2022 thomas downes
        ''
        MessageBoxTD.Show_Statement("Splitter3 distance: " &
                   SplitContainer3.SplitterDistance.ToString)
        MessageBoxTD.Show_Statement("SplitterContainer3 width: " &
                   SplitContainer3.Width.ToString)
        MessageBoxTD.Show_Statement("Splitter3 distance: " &
                   SplitContainer3.SplitterDistance.ToString & vbCrLf & vbCrLf &
                   ("SplitterContainer3 width: " &
                   SplitContainer3.Width.ToString))

        ''Added 2/19/2022td
        MessageBoxTD.Show_Statement("Is Container3's Panel2 collapsed? " &
             SplitContainer3.Panel2Collapsed.ToString())

        ''Added 2/19/2022 td
        ''NumericUpDown3a.ToolTip.Text = "SC #3's Splitter distance"
        NumericUpDown3a.Maximum = SplitContainer3.SplitterDistance + 10
        NumericUpDown3a.Value = SplitContainer3.SplitterDistance
        NumericUpDown3a.Enabled = True

        ''NumericUpDown3b.ToolTip.Text = "SC #3's Width "
        NumericUpDown3b.Maximum = SplitContainer3.Width + 10
        NumericUpDown3b.Value = SplitContainer3.Width
        NumericUpDown3b.Enabled = True

    End Sub

    Private Sub LinkLabelCheckMargin2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCheckMargin2.LinkClicked
        ''
        '' Added 2/19/2022 thomas downes
        ''
        MessageBoxTD.Show_Statement("Splitter2 distance: " &
                   SplitContainer2.SplitterDistance.ToString)
        MessageBoxTD.Show_Statement("SplitterContainer2 width: " &
                   SplitContainer2.Width.ToString)
        MessageBoxTD.Show_Statement("Splitter2 distance: " &
                   SplitContainer2.SplitterDistance.ToString & vbCrLf & vbCrLf &
                   ("SplitterContainer2 width: " &
                   SplitContainer2.Width.ToString))

        ''Added 2/19/2022td
        MessageBoxTD.Show_Statement("Is Container2's Panel2 collapsed? " &
             SplitContainer2.Panel2Collapsed.ToString())

        Dim bWiderThanSC1sPanel2 As Boolean

        bWiderThanSC1sPanel2 = (SplitContainer2.Width >
                              SplitContainer1.Panel2.Width)

        If (True Or bWiderThanSC1sPanel2) Then
            ''Added 2/19/2022 td
            MessageBoxTD.Show_Statement("Is Container2 wider than Container1's Panel2 ? " &
                                        bWiderThanSC1sPanel2.ToString &
                                                    vbCrLf & vbCrLf &
                                                 "Container2's width: " &
                                       SplitContainer2.Width.ToString & vbCrLf & vbCrLf &
                                       ("SplitterContainer1.Panel2's width: " &
                                       (SplitContainer1.Panel2.Width).ToString))

        End If ''End of "If (bWiderThanSC1sPanel2) Then"

        ''Added 2/19/2022 thomas downes
        If (bWiderThanSC1sPanel2) Then
            MessageBoxTD.Show_Statement("Corrective actions....")
            SplitContainer2.Left = 0
            Dim save_styles As AnchorStyles = SplitContainer2.Anchor
            SplitContainer2.Anchor = AnchorStyles.None
            SplitContainer2.Width = CInt(0.93 * SplitContainer1.Panel2.Width)
            SplitContainer1.Refresh()
            SplitContainer2.Anchor = save_styles

        End If ''eNDOF "If (bWiderThanSC1sPanel2) Then"

        ''Added 2/19/2022 td
        ''NumericUpDown3a.ToolTip.Text = "SC #3's Splitter distance"
        NumericUpDown2a.Maximum = SplitContainer2.SplitterDistance + 10
        NumericUpDown2a.Value = SplitContainer2.SplitterDistance
        NumericUpDown2a.Enabled = True

        ''NumericUpDown3b.ToolTip.Text = "SC #3's Width "
        NumericUpDown2b.Maximum = SplitContainer2.Width + 10
        NumericUpDown2b.Value = SplitContainer2.Width
        NumericUpDown2b.Enabled = True

    End Sub

    Private Sub LinkLabelCheckMargin1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCheckMargin1.LinkClicked
        ''
        ''Added 2/19/2022 thomdown
        ''



    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3a.ValueChanged
        ''
        ''Added 2/19/2022
        ''
        SplitContainer3.SplitterDistance = CInt(CType(sender, NumericUpDown).Value)

    End Sub

    Private Sub NumericUpDown3b_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3b.ValueChanged
        ''
        ''Added 2/19/2022
        ''
        Dim save_styles As AnchorStyles = SplitContainer3.Anchor
        SplitContainer3.Anchor = AnchorStyles.None
        Dim intSaveWidth As Integer
        Dim intSaveSplitterDistance As Integer
        intSaveWidth = SplitContainer3.Width
        intSaveSplitterDistance = SplitContainer3.SplitterDistance
        SplitContainer3.Width = CInt(CType(sender, NumericUpDown).Value)
        Application.DoEvents()
        SplitContainer3.Anchor = save_styles
        Application.DoEvents()
        If (intSaveWidth > SplitContainer3.Width) Then

            Dim intCorrection As Integer
            intCorrection = (intSaveWidth - SplitContainer3.Width)
            ''Restore the original splitter Distance.
            SplitContainer3.SplitterDistance = intSaveSplitterDistance
            Application.DoEvents()

        End If

    End Sub

    Private Sub NumericUpDown2a_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2a.ValueChanged
        ''
        ''Added 2/19/2022
        ''
        SplitContainer2.SplitterDistance = CInt(CType(sender, NumericUpDown).Value)

    End Sub

    Private Sub NumericUpDown2b_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2b.ValueChanged
        ''
        ''Added 2/19/2022
        ''
        Dim save_styles As AnchorStyles = SplitContainer2.Anchor
        SplitContainer2.Anchor = AnchorStyles.None
        Dim intSaveWidth As Integer
        Dim intSaveSplitterDistance As Integer
        intSaveWidth = SplitContainer2.Width
        intSaveSplitterDistance = SplitContainer2.SplitterDistance
        SplitContainer2.Width = CInt(CType(sender, NumericUpDown).Value)
        Application.DoEvents()
        SplitContainer2.Anchor = save_styles
        Application.DoEvents()
        If (intSaveWidth > SplitContainer2.Width) Then

            Dim intCorrection As Integer
            intCorrection = (intSaveWidth - SplitContainer2.Width)
            ''Restore the original splitter Distance.
            SplitContainer2.SplitterDistance = intSaveSplitterDistance
            Application.DoEvents()

        End If

    End Sub
End Class
