﻿''
''Added 8/19/2019 td  
''
Imports ciBadgeFields ''Added 9/19/2019 td  

Public Class CtlAddStandardField

    Private mod_MyParentContainer As FlowLayoutPanel

    Private Sub ButtonAddField_Click(sender As Object, e As EventArgs) Handles buttonAddField.Click

        If (mod_MyParentContainer Is Nothing) Then
            ''Jan1 2022 td''mod_MyParentContainer = Me.Parent
            mod_MyParentContainer = CType(Me.Parent, FlowLayoutPanel)
        End If ''End of "If (mod_MyParentContainer Is Nothing) Then"

        Me.Parent.Controls.Remove(Me)

        Dim newfieldControl As New CtlConfigFldStandard
        mod_MyParentContainer.Controls.Add(newfieldControl)
        mod_MyParentContainer.Controls.Add(Me)

        Dim new_field As New ClassFieldStandard

        newfieldControl.NewlyAdded = True ''Added 7/27/2019 td 
        newfieldControl.Load_StandardControl(new_field)

        CType(Me.ParentForm, DialogListStandardFields).AdjustHeightOfWindow()

        mod_MyParentContainer.ScrollControlIntoView(Me)

    End Sub

End Class
