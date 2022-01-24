Option Explicit On
Option Strict On
Option Infer Off
''
''Added 7/21/2019 thomas downes
''
Imports ciBadgeInterfaces
Imports ciBadgeFields ''Added 9/19/2019 td   

Public Class DialogListCustomFields
    Implements InterfaceShowListFields ''Added 12/6/2021 td 

    ''12/5/2021 td''Public Property ListOfFields As List(Of ClassFieldCustomized) ''Added 7/23/2019 thomas downes 
    Public Property ListOfFields_Custom As HashSet(Of ClassFieldCustomized) Implements InterfaceShowListFields.ListOfFields_Custom ''Added 7/23/2019 thomas downes 

    Public Property ListOfFields_Standard As HashSet(Of ClassFieldStandard) Implements InterfaceShowListFields.ListOfFields_Standard ''Not in use.  Added 12/6/2021 thomas downes 

    Public Property JustOneField_Index As Integer Implements InterfaceShowListFields.JustOneField_Index ''Added 7/30/2019 thomas d. 
    Public Property JustOneField_Any As ClassFieldAny Implements InterfaceShowListFields.JustOneField_Any ''Added 12/13/2021 thomas d. 
    Public Property JustOneField_Custom As ClassFieldCustomized Implements InterfaceShowListFields.JustOneField_Custom ''Added 12/13/2021 thomas d. 
    Public Property JustOneField_Standard As ClassFieldStandard Implements InterfaceShowListFields.JustOneField_Standard ''Added 12/13/2021 thomas d. 

    Public Property CacheManager As ciBadgeCachePersonality.ClassCacheManagement Implements InterfaceShowListFields.CacheManager ''Added 12/??/2021 td

    Public Property PersonalityConfig As ClassPersonalityConfig ''Added 12/13/2021 thomas downes

    Public Property ClosingOK_SoSaveWork As Boolean Implements InterfaceShowListFields.ClosingOK_SoSaveWork ''Added 12/6/2021 thomas downes

    Public Overloads Function ShowDialog() As DialogResult Implements InterfaceShowListFields.ShowDialog
        ''
        ''Added 12/6/2021 td
        ''
        Return CType(Me, Form).ShowDialog()
    End Function


    Public Overloads Sub Show() Implements InterfaceShowListFields.Show
        ''
        ''Added 12/14/2021 td
        ''
        CType(Me, Form).Show()

    End Sub ''End of "Public Overloads Sub Show()"


    Private Const vbCrLf_Deux As String = (vbCrLf & vbCrLf)

    Public Sub AdjustHeightOfWindow()
        ''Added 7/23/2019 thomas downes
        Static s_bEveryOtherCall As Boolean

        If (s_bEveryOtherCall) Then Me.Height -= CInt(UserAddFieldControl1.Height / 2)
        If (Not s_bEveryOtherCall) Then Me.Height += CInt(UserAddFieldControl1.Height / 2)

        s_bEveryOtherCall = Not s_bEveryOtherCall

    End Sub ''End of "Public Sub AdjustHeightOfWindow()"

    Private Sub FormCustomFieldsFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/21/2019 thomas downes
        ''
        '' 7/21 td''ClassCustomField.InitializeHardcodedList_Students()

        ''Dec. 6, 2021 td
        ''---Me.CacheManager.OutputToTextFile_CustomFields(Me.ListOfFields)

        ''Dec. 6 2021''LoadCustomFields_All()
        ''Dec. 13 2021''LoadCustomFields_All(Me.ListOfFields_Custom)
        ''Jan5 2022 td''LoadCustomFields_All(Me.ListOfFields_Custom, Me.JustOneField_Custom)

        ''Added 1/5/2022 thomas d.
        If (Me.ListOfFields_Custom Is Nothing) Then
            If (Me.JustOneField_Custom Is Nothing) Then

                ''Added 1/5/2022 thomas d.
                Dim objListOfJustOneField As New HashSet(Of ClassFieldCustomized)
                objListOfJustOneField.Add(Me.JustOneField_Custom)
                LoadCustomFields_All(objListOfJustOneField, Me.JustOneField_Custom)

            End If ''End of "If (Me.JustOneField_Custom Is Nothing) Then"

        Else
            ''Dec14 2021 td''LoadCustomFields_All()
            LoadCustomFields_All(Me.ListOfFields_Custom, Me.JustOneField_Custom)

        End If ''End of "If (Me.ListOfFields_Custom Is Nothing) Then ... Else ..."


    End Sub

    Private Sub LoadCustomFields_All(par_listFields As HashSet(Of ClassFieldCustomized),
                                     Optional par_JustOneField As ClassFieldCustomized = Nothing)
        ''---Dec13 2021---Private Sub LoadCustomFields_All(par_listFields As HashSet(Of ClassFieldCustomized))
        ''
        ''Added 7.21.2019
        ''
        ''#1 12/6/2021 td''Dim list_local As List(Of ClassFieldCustomized) = Nothing
        ''#2 12/6/2021 td''Dim list_local As HashSet(Of ClassFieldCustomized) = Nothing
        ''#2 12/6/2021 td''If (ListOfFields IsNot Nothing) Then list_local = ListOfFields

        ''Dec.5 2021''If (list_local Is Nothing) Then
        ''Dec.5 2021''    ClassFieldCustomized.InitializeHardcodedList_Students(True)
        ''Dec.5 2021''    list_local = ClassFieldCustomized.ListOfFields_Students
        ''Dec.5 2021''End If ''end of "If (list_local Is Nothing) Then"

        FlowLayoutPanel1.Controls.Clear()
        Dim boolProceed As Boolean ''Added 12/13/2021 td 

        For Each each_customField As ClassFieldCustomized In par_listFields ''ClassCustomField.ListOfFields_Students
            ''
            ''Add 7/21/2019
            ''
            boolProceed = (par_JustOneField Is Nothing Or
                (par_JustOneField Is each_customField))

            If (boolProceed) Then
                ''
                ''Major call!!
                ''
                LoadCustomField_Each(each_customField)
            End If ''End of "If (boolProceed) Then"

        Next each_customField

        ''
        ''Add 7/21/2019
        ''
        FlowLayoutPanel1.Controls.Add(New CtlAddCustomField())

    End Sub ''End of "Private Sub LoadFields()"  

    Private Sub LoadCustomField_Each(par_customfld As ClassFieldCustomized)
        ''
        ''Added 7/ 21/2019
        ''
        Dim userControl As New CtlConfigFldCustom

        ''7/21/2019 td''FlowLayoutPanel1.Controls.Add(New UserCustomFieldCtl())

        ''9/17/2019 td''userControl.Load_CustomControl(CType(par_customfld, ICIBFieldStandardOrCustom))
        userControl.Load_CustomControl(par_customfld)
        userControl.Visible = True

        FlowLayoutPanel1.Controls.Add(userControl)

    End Sub ''End of "Private Sub LoadCustomField_Each(par_customfld As ClassCustomField)"

    Private Sub FormCustomFieldsFlow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ''
        ''Added 7/23/2019 td  
        ''Encapsulated 7/27/2019 td 
        ''
        ''8/4/2019 td''SaveControls()

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

        If (dia_result = DialogResult.Yes) Then
            SaveControls()
            ''Added 12/6/2021 td
            Me.ClosingOK_SoSaveWork = True
        End If ''End of "If (dia_result = DialogResult.Yes) Then"

    End Sub

    Private Sub SaveControls()
        ''
        ''Added 7/23/2019 td  
        ''
        ''Encapsulated 7/27/2019 td 
        ''
        Dim each_ctl_configure_field As CtlConfigFldCustom

        For Each each_control As Control In FlowLayoutPanel1.Controls

            If (TypeOf each_control Is CtlAddCustomField) Then Continue For

            ''7/27/2019 td''CType(each_control, CtlConfigFldCustom).Save_CustomControl()

            each_ctl_configure_field = CType(each_control, CtlConfigFldCustom)

            With each_ctl_configure_field

                .Save_CustomControl()

                ''8/29/2019 td''If (.NewlyAdded) Then FormMain.GetCurrentPersonality_Fields_Custom().Add(.Model)
                If (.NewlyAdded) Then
                    ''9/2/2019 td''FormMain.GetCurrentPersonality_Fields_Custom().Add(.ModelFieldInfo)
                    ''12/5/2021 td''Form__Main_PreDemo.GetCurrentPersonality_Fields_Custom().Add(.Field_Customized)
                    ''01/01/2022 td''Form__Main_Demo.ElementsCache_Edits.ListOfFields_Custom.Add(.Field_Customized)
                    Me.ListOfFields_Custom.Add(.Field_Customized)

                End If ''End of "If (.NewlyAdded) Then"

            End With ''End of "With each_ctl_configure_field"

        Next each_control

        ''
        ''Exit procedure.....
        ''

    End Sub ''End of "Private Sub SaveControls" 

    Private Sub LinkLabelRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabelRefresh.LinkClicked

        ''Added 7/27/2019 td
        SaveControls()
        FlowLayoutPanel1.Controls.Clear()

        ''Dec.6, 2021''LoadCustomFields_All(Me.ListOfFields)
        LoadCustomFields_All(Me.ListOfFields_Custom)

    End Sub

    Private Sub LinkLabelSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelSave.LinkClicked

        ''Added 7/30/2019 td
        SaveControls()

        ''Added 12/6/2021 td
        Me.ClosingOK_SoSaveWork = True

        MessageBox.Show("Saved.", "ciLayoutDesign", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub LinkLabelCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCancel.LinkClicked
        ''
        ''Added 8/4/2019 thomas downes
        ''
        Dim dia_result As DialogResult

        ''Added 8/4/2019 td  
        dia_result = MessageBox.Show("Cancel your work? ", "ciLayout",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If (dia_result = DialogResult.Yes) Then ''LoadCustomFields_All()
            FlowLayoutPanel1.Controls.Clear()
            ''Major call!!
            LoadCustomFields_All(Me.ListOfFields_Custom)
        End If ''End of "If (dia_result = DialogResult.Yes) Then"

    End Sub
End Class