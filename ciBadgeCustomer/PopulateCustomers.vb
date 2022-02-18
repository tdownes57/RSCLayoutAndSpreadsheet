Option Explicit On
Option Strict On
''
''Added 2/16/2022 td
''
Imports System.Windows.Forms ''Added 2/16/2022 td
Imports ciBadgeCustomer ''Added 2/16/2022 td

Public Class PopulateCustomers
    ''
    ''Added 2/16/2022 td
    ''
    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked

    End Sub

    Private Sub PanelCustomerCode_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles PanelCustomerCode.Paint

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
            If (.TextboxNotes.Text = "Example") Then .TextboxNotes.Text = ""

            .TextboxCode.ForeColor = System.Drawing.Color.Black
            .TextboxNameFull.ForeColor = System.Drawing.Color.Black
            .TextboxNotes.ForeColor = System.Drawing.Color.Black

            .TextboxCode.BackColor = System.Drawing.Color.White
            .TextboxNameFull.BackColor = System.Drawing.Color.White
            .TextboxNotes.BackColor = System.Drawing.Color.White

        End With

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
                    each_bCustomerInactive = (.CheckboxActive.Checked)
                    each_customer = .Customer

                    ''Added 2/17/2022  
                    bMustCreateCustomer = (each_bCustomerIsNull And (Not each_bCustomerInactive))
                    If (bMustCreateCustomer) Then
                        .Customer = New ClassCustomer()
                        each_bCustomerIsNull = (.Customer Is Nothing) ''Feb17 2022 = .CustomerIsNull
                        each_customer = .Customer
                    End If ''End of "If (bMustCreateCustomer) Then"

                End With ''End of "With each_row_controlsetClass"

                If (each_bCustomerInactive And (Not each_bCustomerIsNull)) Then
                    ''
                    ''Don't save the inactive record.  Just turn on the
                    ''  "Deactivated" flag.  
                    ''
                    each_customer.Deactivated = (Not each_row_controlsetClass.CheckboxActive.Checked) ''True

                Else

                    With each_customer

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
            ''Collect the customer objects. 
            ''
            If (each_customer IsNot Nothing) Then
                output_hashset.Add(each_customer)
            End If ''end of "If (each_customer IsNot Nothing) Then"

        Next each_checkbox

        ''
        ''Output. 
        ''
        Return output_hashset

    End Function ''End of "Public Function Save_GetCustomerList()"

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub textboxName1_TextChanged(sender As Object, e As EventArgs) Handles textboxNameFull1.TextChanged

    End Sub

    Private Sub checkbox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkbox1.CheckedChanged

    End Sub
End Class
