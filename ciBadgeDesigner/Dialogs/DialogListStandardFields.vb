Option Explicit On ''Added 8/29/2019 td
Option Strict On ''Added 8/29/2019 td
''
''Added 8/19/2019 thomas downes
''
Imports ciBadgeInterfaces
Imports ciBadgeFields ''Added 9/19/2019 td 

Public Class DialogListStandardFields
    Implements InterfaceShowListFields ''Added 12/6/2021 td 

    ''10/17 Public Property ListOfFields As List(Of ClassFieldStandard) ''Added 8/19/2019 thomas downes 
    ''12/6/2021''Public Property ListOfFields As HashSet(Of ClassFieldStandard) ''Added 8/19/2019 thomas downes 

    Public Property ListOfFields_Custom As HashSet(Of ClassFieldCustomized) Implements InterfaceShowListFields.ListOfFields_Custom ''Added 7/23/2019 thomas downes 

    Public Property ListOfFields_Standard As HashSet(Of ClassFieldStandard) Implements InterfaceShowListFields.ListOfFields_Standard ''Not in use.  Added 12/6/2021 thomas downes 

    Public Property CacheManager As ciBadgeCachePersonality.ClassCacheManagement Implements InterfaceShowListFields.CacheManager
    Public Property JustOneField_Index As Integer Implements InterfaceShowListFields.JustOneField_Index ''Added 7/30/2019 thomas d. 

    ''Dec. 13 2021''Public Property JustOneField_Object As ClassFieldAny Implements InterfaceShowListFields.JustOneField_Object ''Added 12/13/2021 thomas d. 
    Public Property JustOneField_Any As ClassFieldAny Implements InterfaceShowListFields.JustOneField_Any ''Added 12/13/2021 thomas d. 
    Public Property JustOneField_Custom As ClassFieldCustomized Implements InterfaceShowListFields.JustOneField_Custom ''Added 12/13/2021 thomas d. 
    Public Property JustOneField_Standard As ClassFieldStandard Implements InterfaceShowListFields.JustOneField_Standard ''Added 12/13/2021 thomas d. 

    Public Property ClosingOK_SoSaveWork As Boolean Implements InterfaceShowListFields.ClosingOK_SoSaveWork ''Added 12/6/2021 thomas downes

    ''Jan2 2022 td''Private mod_listFields As List(Of ClassFieldStandard) ''Added 1/2/2022 td

    ''Public Sub New(par_listFields As List(Of ClassFieldStandard))
    ''    ''
    ''    ''Added 1/2/2022 thomas downes
    ''    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()

    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''Jan2 2022 td''mod_listFields = par_listFields

    ''End Sub


    Public Overloads Function ShowDialog() As DialogResult Implements InterfaceShowListFields.ShowDialog
        ''
        ''Added 12/6/2021 td
        ''
        Return CType(Me, Form).ShowDialog()

    End Function ''End of "Public Overloads Function ShowDialog()"


    Public Overloads Sub Show() Implements InterfaceShowListFields.Show
        ''
        ''Added 12/14/2021 td
        ''
        CType(Me, Form).Show()

    End Sub ''End of "Public Overloads Sub Show()"


    Private Const vbCrLf_Deux As String = (vbCrLf & vbCrLf)

    Public Sub AdjustHeightOfWindow()

        ''Added 8/19/2019 thomas downes
        Static s_bEveryOtherCall As Boolean

        If (s_bEveryOtherCall) Then Me.Height -= CInt(CtlAddStandardField1.Height / 2)
        If (Not s_bEveryOtherCall) Then Me.Height += CInt(CtlAddStandardField1.Height / 2)

        s_bEveryOtherCall = Not s_bEveryOtherCall

    End Sub ''End of "Public Sub AdjustHeightOfWindow()"

    Private Sub FormCustomFieldsFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 8/19/2019 thomas downes
        ''
        '' 7/21 td''ClassCustomField.InitializeHardcodedList_Students()

        ''Dec14 2021 td''LoadStandardFields_All()
        ''Jan5 2022 td''LoadStandardFields_All(Me.ListOfFields_Standard, Me.JustOneField_Standard)

        ''Added 1/5/2022 thomas d.
        If (Me.ListOfFields_Standard Is Nothing) Then
            If (Me.JustOneField_Standard Is Nothing) Then

                ''Added 1/5/2022 thomas d.
                Dim objListOfJustOneField = New HashSet(Of ClassFieldStandard)
                objListOfJustOneField.Add(Me.JustOneField_Standard)
                LoadStandardFields_All(objListOfJustOneField, Me.JustOneField_Standard)

            End If ''End of "If (Me.JustOneField_Standard Is Nothing) Then"

        Else
            ''Dec14 2021 td''LoadStandardFields_All()
            LoadStandardFields_All(Me.ListOfFields_Standard, Me.JustOneField_Standard)

        End If ''End of "If (Me.ListOfFields_Standard Is Nothing) Then ... Else ..."


    End Sub ''End of Private Sub Form_Load  

    Private Sub LoadStandardFields_All(par_listFields As HashSet(Of ClassFieldStandard),
                                     Optional par_JustOneField As ClassFieldStandard = Nothing)
        ''Dec. 14, 2021 td''Private Sub LoadStandardFields_All()
        ''
        ''Added 8/19/2019
        ''
        ''10/17 td''Dim list_local As List(Of ClassFieldStandard) = Nothing
        Dim list_local As HashSet(Of ClassFieldStandard) = Nothing
        Dim boolProceed As Boolean ''Added 12/14/2021 td

        If (ListOfFields_Standard IsNot Nothing) Then list_local = ListOfFields_Standard

        If (list_local Is Nothing) Then
            ClassFieldStandard.InitializeHardcodedList_Students(True)
            list_local = ClassFieldStandard.ListOfFields_Students
        End If ''end of "If (list_local Is Nothing) Then"

        FlowLayoutPanel1.Controls.Clear()

        For Each each_standardField In list_local

            ''Add 8/19/2019 td
            ''8/22/2019 td''LoadCustomField_Each(each_standardField)
            ''12/14/2021 td''LoadStandardField_Each(each_standardField)

            ''
            ''Add 7/21/2019
            ''
            boolProceed = (par_JustOneField Is Nothing Or
                (par_JustOneField Is each_standardField))

            If (boolProceed) Then

                LoadStandardField_Each(each_standardField)

            End If ''end of " If (boolProceed) Then"

        Next each_standardField

        ''
        ''Add 7/21/2019
        ''
        ''8/22/2019 td''FlowLayoutPanel1.Controls.Add(New CtlAddCustomField())
        FlowLayoutPanel1.Controls.Add(New CtlAddStandardField())

    End Sub ''End of "Private Sub LoadFields()"  

    Private Sub LoadStandardField_Each(par_standardFld As ClassFieldStandard)
        ''
        ''Added 8/19/2019
        ''
        Dim userControl As New CtlConfigFldStandard

        userControl.Load_StandardControl(CType(par_standardFld, ICIBFieldStandardOrCustom))
        userControl.Visible = True

        FlowLayoutPanel1.Controls.Add(userControl)

    End Sub ''End of "Private Sub LoadStandardField_Each(par_standardFld As ClassStandardField)"

    Private Sub FormCustomFieldsFlow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ''
        ''Added 8/19/2019 td  
        ''
        Dim dia_result As DialogResult
        Dim closing_reason As CloseReason

        closing_reason = e.CloseReason

        ''Added 8/19/2019 td  
        dia_result = MessageBox.Show("Save your work?  (Currently, this does _NOT_ save your work permanently to your PC.) " &
                                     vbCrLf_Deux & "(Allows the window to be re-opened from the parent application, with your work retained.)", "ciLayout",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (dia_result = DialogResult.Cancel) Then e.Cancel = True
        If (dia_result = DialogResult.Yes) Then SaveControls()

    End Sub

    Private Sub SaveControls()
        ''
        ''Added 8/19/2019 td  
        ''
        Dim each_ctl_configure_field As CtlConfigFldStandard

        For Each each_control As Control In FlowLayoutPanel1.Controls

            If (TypeOf each_control Is CtlAddCustomField) Then Continue For
            If (TypeOf each_control Is CtlAddStandardField) Then Continue For

            each_ctl_configure_field = CType(each_control, CtlConfigFldStandard)

            With each_ctl_configure_field

                ''8/22/2019 TD''.Save_CustomControl()
                .Save_StandardControl()

                ''8/22/2019 td''If (.NewlyAdded) Then FormMain.GetCurrentPersonality_Fields_Custom().Add(.Model)
                If (.NewlyAdded) Then

                    ''#1 1/2/2022 td''Form__Main_PreDemo.GetCurrentPersonality_Fields_Standard().Add(.Field_Standard)
                    ''#2 1/2/2022 td''mod_ListOfFields.Add(.Field_Standard)
                    Me.ListOfFields_Standard.Add(.Field_Standard)

                End If ''End of "If (.NewlyAdded) Then"

            End With ''End of "With each_ctl_configure_field"

        Next each_control

    End Sub

    Private Sub LinkLabelRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabelRefresh.LinkClicked

        ''Added 7/27/2019 td
        SaveControls()
        FlowLayoutPanel1.Controls.Clear()

        ''8/22/2019 td''LoadCustomFields_All()
        ''#1 Dec14 2021''LoadStandardFields_All()
        ''#2 Dec14 2021''LoadStandardFields_All(Me.ListOfFields_Standard)
        LoadStandardFields_All(Me.ListOfFields_Standard, Me.JustOneField_Standard)

    End Sub

    Private Sub LinkLabelSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelSave.LinkClicked

        ''Added 7/30/2019 td
        SaveControls()

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
            ''8/22/2019 td''LoadCustomFields_All()
            ''Dec14 2021''LoadStandardFields_All()
            LoadStandardFields_All(Me.ListOfFields_Standard, Me.JustOneField_Standard)
        End If ''End of "If (dia_result = DialogResult.Yes) Then"

    End Sub
End Class


