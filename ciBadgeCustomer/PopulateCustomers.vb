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

    Private Sub CheckedChanged(sender As Object, e As EventArgs) Handles checkbox1.CheckedChanged,
             checkbox2.CheckedChanged, checkbox3.CheckedChanged, checkbox3.CheckedChanged,
             checkbox4.CheckedChanged, checkbox5.CheckedChanged, checkbox6.CheckedChanged,
             checkbox7.CheckedChanged, checkbox8.CheckedChanged, checkbox9.CheckedChanged,
             checkbox10.CheckedChanged, checkbox11.CheckedChanged, checkbox12.CheckedChanged
        ''
        ''Added 2/16/2022 thomas downes
        ''
        Dim sender_checkbox As CheckBox
        ''----Dim row_checkboxClass As ciBadgeCustomer.ClassRowCustomer
        Dim row_checkboxClass As ClassRowOfCustomer

        sender_checkbox = CType(sender, Windows.Forms.CheckBox)

        If (sender_checkbox.Tag IsNot Nothing) Then

            row_checkboxClass = CType(sender_checkbox.Tag, ClassRowOfCustomer)



        End If ''End of "If (sender_checkbox.Tag IsNot Nothing) Then"



    End Sub




End Class
