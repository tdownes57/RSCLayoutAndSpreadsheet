''----Public Class DialogListBothTypeFields
Option Explicit On
Option Strict On
Option Infer Off ''On ''3/17/2022 td ''Off
'' 
''Added 3/17/20122 thomas downes
''
Imports ciBadgeInterfaces
Imports ciBadgeFields ''Added 9/19/2019 td   

Public Structure StructLoadWhatFields
    ''Added 4/30/2022 thomas
    Dim StandardFields As Boolean
    Dim CustomFields As Boolean
    Dim RelevantFields As Boolean
    Dim NonrelevantFields As Boolean
End Structure

Public Class DialogListBothTypeFields
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

    Private mod_structLoad As StructLoadWhatFields ''Added 4/30/2022 td

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
        Dim struct_Load As New StructLoadWhatFields
        Dim bTargettingSingleField As Boolean

        bTargettingSingleField = (Me.JustOneField_Standard IsNot Nothing) Or
                                 (Me.JustOneField_Custom IsNot Nothing)

        ''----If (Me.JustOneField_Standard IsNot Nothing) Then
        If (bTargettingSingleField) Then
            LinkLabelShowAllFieldsCS.Visible = False
            LinkShowRelevantOnly.Visible = False
            LinkShowOnlyNotRelevant.Visible = False
            LinkShowOnlyStandardFields.Visible = False
            LinkLabelShowAllFieldsRNR.Visible = False
        End If ''en dof ""If (bTargettingSingleField) Then""

        struct_Load.StandardFields = True
        struct_Load.CustomFields = True
        struct_Load.RelevantFields = True
        struct_Load.NonrelevantFields = True

        LoadFields_Master(struct_Load)

        ''added 4/30/2022 
        mod_structLoad = struct_Load

    End Sub


    Private Sub LoadFields_Master(par_structLoad As StructLoadWhatFields)
        '' 7/21 td''ClassCustomField.InitializeHardcodedList_Students()

        ''Dec. 6, 2021 td
        ''---Me.CacheManager.OutputToTextFile_CustomFields(Me.ListOfFields)

        ''Dec. 6 2021''LoadCustomFields_All()
        ''Dec. 13 2021''LoadCustomFields_All(Me.ListOfFields_Custom)
        ''Jan5 2022 td''LoadCustomFields_All(Me.ListOfFields_Custom, Me.JustOneField_Custom)

        ''Added 3/21/2022 Thomas DOWNES 
        FlowLayoutPanel1.Controls.Clear()

        ''
        ''Step 1 of 2. Load Standard Fields.  
        ''
        ''Added 1/5/2022 thomas d.
        ''Added 1/5/2022 thomas d.
        If (Me.ListOfFields_Standard Is Nothing) Then
            If (Me.JustOneField_Standard Is Nothing) Then
                ''
                ''There are not any custom fields to load.  Hence, do nothing.--3/21/2022
                ''
            Else
                ''Added 1/5/2022 thomas d.
                par_structLoad.StandardFields = True ''Added 4/30/2022 
                par_structLoad.RelevantFields = True ''Added 4/30/2022 
                par_structLoad.NonrelevantFields = True ''Added 4/30/2022 
                Dim objListOfJustOneField_Stan As New HashSet(Of ClassFieldStandard)
                objListOfJustOneField_Stan.Add(Me.JustOneField_Standard)
                ''April 30/2022''LoadFields_All_Standard(objListOfJustOneField_Stan, Me.JustOneField_Standard)
                LoadFields_All_Standard(objListOfJustOneField_Stan, par_structLoad, Me.JustOneField_Standard)

            End If ''End of "If (Me.JustOneField_Standard Is Nothing) Then... Else..."

        ElseIf (par_structLoad.StandardFields) Then
            ''April 30, 2022 ''Else
            ''Dec14 2021 td''LoadCustomFields_All()
            ''April 30/2022''LoadFields_All_Standard(Me.ListOfFields_Standard, Me.JustOneField_Standard)
            LoadFields_All_Standard(Me.ListOfFields_Standard, par_structLoad, Me.JustOneField_Standard)

        End If ''End of "If (Me.ListOfFields_Standard Is Nothing) Then ... Else ..."

        ''
        ''Step 2 of 2. Load Custom Fields.  
        ''
        If (Me.ListOfFields_Custom Is Nothing) Then

            Dim objListOfJustOneField As New HashSet(Of ClassFieldCustomized)

            If (Me.JustOneField_Custom Is Nothing) Then
                ''
                ''There are not any custom fields to load.  Hence, do nothing.--3/21/2022
                ''
                ''----Added 3/21/2022 thomas downes
                ''----LoadCustomFields_All(objListOfJustOneField)

            Else

                ''Added 1/5/2022 thomas d.
                par_structLoad.CustomFields = True ''Added 4/30/2022 
                par_structLoad.RelevantFields = True ''Added 4/30/2022 
                par_structLoad.NonrelevantFields = True ''Added 4/30/2022 
                objListOfJustOneField.Add(Me.JustOneField_Custom)
                ''April 2022''LoadFields_All_Custom(objListOfJustOneField, Me.JustOneField_Custom)
                LoadFields_All_Custom(objListOfJustOneField, par_structLoad, Me.JustOneField_Custom)

            End If ''End of "If (Me.JustOneField_Custom Is Nothing) Then ... Else..."

        ElseIf (par_structLoad.CustomFields) Then
            ''April 30, 2022 ''Else
            ''Dec14 2021 td''LoadCustomFields_All()
            ''April 2022''LoadFields_All_Custom(Me.ListOfFields_Custom, Me.JustOneField_Custom)
            LoadFields_All_Custom(Me.ListOfFields_Custom, par_structLoad, Me.JustOneField_Custom)

        End If ''End of "If (Me.ListOfFields_Custom Is Nothing) Then ... Else ..."

    End Sub ''End of Private Sub LoadFields_Master

    Private Sub LoadFields_All_Custom(par_listFields As HashSet(Of ClassFieldCustomized),
                                     par_checkLoad As StructLoadWhatFields,
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

        ''Moved to calling procedure.March 21 2022''FlowLayoutPanel1.Controls.Clear()
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
                LoadCustomField_Each(each_customField, par_checkLoad)
            End If ''End of "If (boolProceed) Then"

        Next each_customField

        ''
        ''Add 7/21/2019
        ''
        FlowLayoutPanel1.Controls.Add(New CtlAddCustomField())

    End Sub ''End of "Private Sub LoadFields_All_Custom()"  

    Private Sub LoadCustomField_Each(par_customfld As ClassFieldCustomized,
                                     par_checkLoad As StructLoadWhatFields)
        ''
        ''Added 7/ 21/2019
        ''
        Dim userControl As CtlConfigFldCustom
        Dim boolIrrelevant As Boolean ''Added 3/21/2022 td

        ''Added 3/21/2022 td
        boolIrrelevant = (Not par_customfld.IsRelevantToPersonality)

        ''7/21/2019 td''FlowLayoutPanel1.Controls.Add(New UserCustomFieldCtl())

        Dim userControl_Irrelevant As CtlConfigFldCustRelevancy ''Added 3/21/2022
        If (boolIrrelevant) Then ''Added 3/21/2022 td
            ''Added 3/21/2022 td
            ''Added 4/30/2022 td
            If (par_checkLoad.NonrelevantFields) Then
                userControl_Irrelevant = New CtlConfigFldCustRelevancy
                userControl_Irrelevant.Load_CustomControl(par_customfld)
                userControl_Irrelevant.Visible = True
                FlowLayoutPanel1.Controls.Add(userControl_Irrelevant)
            End If ''End of ""If (par_checkLoad.NonrelevantFields) Then""

        ElseIf (par_checkLoad.RelevantFields) Then ''Conditioned 4/30/2022
            ''4/30/2022 td
            userControl = New CtlConfigFldCustom
            ''9/17/2019 td''userControl.Load_CustomControl(CType(par_customfld, ICIBFieldStandardOrCustom))
            userControl.Load_CustomControl(par_customfld)
            userControl.Visible = True
            FlowLayoutPanel1.Controls.Add(userControl)

        End If ''Endof "If (boolIrrelevant) Then //// else ///"


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

        ''Added 4/13/2022 td
        If (Me.DialogResult = DialogResult.OK) Then
            ''Don't ask the user, the user has already pressed "OK" or "Yes" or "Cancel".---4/13/2022
        ElseIf (Me.DialogResult = DialogResult.Yes) Then
            ''Don't ask the user, the user has already pressed "OK" or "Yes" or "Cancel".---4/13/2022
        ElseIf (Me.DialogResult = DialogResult.Cancel) Then
            ''Don't ask the user, the user has already pressed "OK" or "Cancel".---4/13/2022

        Else
            ''Added 7/31/2019 td  
            dia_result = MessageBox.Show("Save your work?  (Currently, this does _NOT_ save your work permanently to your PC.) " &
                                     vbCrLf_Deux & "(Allows the window to be re-opened from the parent application, with your work retained.)", "ciLayout",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If (dia_result = DialogResult.Cancel) Then e.Cancel = True

            If (dia_result = DialogResult.Yes) Then
                SaveControls()
                ''Added 12/6/2021 td
                Me.ClosingOK_SoSaveWork = True
                ''Added 03/23/2022 thomas d.  
                Me.DialogResult = DialogResult.OK

            End If ''End of "If (dia_result = DialogResult.Yes) Then"

        End If ''If (Me.DialogResult = DialogResult.OK) Then

    End Sub

    Private Sub SaveControls()
        ''
        ''Added 7/23/2019 td  
        ''
        ''Encapsulated 7/27/2019 td 
        ''
        Dim each_ctl_configure_field_Standard As CtlConfigFldStandard
        Dim each_ctl_configure_field_Custom As CtlConfigFldCustom
        Dim each_ctl_configure_field_StandRelevy As CtlConfigFldStdRelevancy ''Added 3/23/2022 td
        Dim each_ctl_configure_field_CustRelevy As CtlConfigFldCustRelevancy ''Added 3/23/2022 td

        For Each each_control As Control In FlowLayoutPanel1.Controls

            If (TypeOf each_control Is CtlAddCustomField) Then Continue For
            If (TypeOf each_control Is CtlAddStandardField) Then Continue For ''Added 3/23/2022

            ''7/27/2019 td''CType(each_control, CtlConfigFldCustom).Save_CustomControl()

            Dim bControlIsCustom As Boolean = False ''Added 3/23/2022 td
            Dim bControlIsCustom_Relevancy As Boolean = False ''Added 3/23/2022 td
            Dim bControlIsStandard As Boolean = False ''Added 3/23/2022 td
            Dim bControlIsStandard_Relevancy As Boolean = False ''Added 3/23/2022 td

            ''Added 3/23/2022 td
            If (TypeOf each_control Is CtlConfigFldStandard) Then bControlIsStandard = True
            If (TypeOf each_control Is CtlConfigFldStdRelevancy) Then bControlIsStandard_Relevancy = True
            If (TypeOf each_control Is CtlConfigFldCustom) Then bControlIsCustom = True
            If (TypeOf each_control Is CtlConfigFldCustRelevancy) Then bControlIsCustom_Relevancy = True

            Select Case True

                Case bControlIsStandard
                    ''
                    ''Standard-Field Control
                    ''
                    each_ctl_configure_field_Standard = CType(each_control, CtlConfigFldStandard)
                    With each_ctl_configure_field_Standard
                        .Save_StandardControl()
                        If (.NewlyAdded) Then Me.ListOfFields_Standard.Add(.Field_Standard)
                    End With ''End of "With each_ctl_configure_field_Standard"


                Case bControlIsCustom
                    ''
                    ''Custom-Field Control
                    ''
                    each_ctl_configure_field_Custom = CType(each_control, CtlConfigFldCustom)
                    With each_ctl_configure_field_Custom

                        .Save_CustomControl()

                        ''8/29/2019 td''If (.NewlyAdded) Then FormMain.GetCurrentPersonality_Fields_Custom().Add(.Model)
                        If (.NewlyAdded) Then
                            ''9/2/2019 td''FormMain.GetCurrentPersonality_Fields_Custom().Add(.ModelFieldInfo)
                            ''12/5/2021 td''Form__Main_PreDemo.GetCurrentPersonality_Fields_Custom().Add(.Field_Customized)
                            ''01/01/2022 td''Form__Main_Demo.ElementsCache_Edits.ListOfFields_Custom.Add(.Field_Customized)
                            Me.ListOfFields_Custom.Add(.Field_Customized)

                        End If ''End of "If (.NewlyAdded) Then"

                    End With ''End of "With each_ctl_configure_field"


                Case bControlIsStandard_Relevancy
                    ''
                    ''Standard-Field Control (w/ Relevancy Container)
                    ''
                    each_ctl_configure_field_StandRelevy = CType(each_control, CtlConfigFldStdRelevancy)
                    With each_ctl_configure_field_StandRelevy
                        .Save_StandardControl()
                        If (.NewlyAdded) Then Me.ListOfFields_Standard.Add(.Field_Standard)
                    End With ''End of "With each_ctl_configure_field_Standard"

                Case bControlIsCustom_Relevancy
                    ''
                    ''Custom-Field Control (w/ Relevancy Container)
                    ''
                    each_ctl_configure_field_CustRelevy = CType(each_control, CtlConfigFldCustRelevancy)
                    With each_ctl_configure_field_CustRelevy
                        .Save_CustomControl()
                        If (.NewlyAdded) Then Me.ListOfFields_Custom.Add(.Field_Customized)
                    End With ''End of "With each_ctl_configure_field_Standard"

            End Select ''End of ""Select Case True""

        Next each_control

        ''
        ''Exit procedure.....
        ''

    End Sub ''End of "Private Sub SaveControls" 


    Private Sub LoadFields_All_Standard(par_listFields As HashSet(Of ClassFieldStandard),
                                     par_checkLoad As StructLoadWhatFields,
                                     Optional par_JustOneField As ClassFieldStandard = Nothing)
        ''Mar. 17, 2022 td''Private Sub LoadStandardFields_All(par_listFields As HashSet(Of ClassFieldStandard)
        ''Dec. 14, 2021 td''Private Sub LoadStandardFields_All()
        ''
        ''Added 8/19/2019
        ''
        ''10/17 td''Dim list_local As List(Of ClassFieldStandard) = Nothing
        Dim list_local As HashSet(Of ClassFieldStandard) = Nothing
        Dim boolProceed As Boolean ''Added 12/14/2021 td

        If (ListOfFields_Standard IsNot Nothing) Then list_local = ListOfFields_Standard

        If (list_local Is Nothing) Then
            ''5/07/2022 td--ClassFieldStandard.InitializeHardcodedList_Students(True)
            ''5/07/2022 td--list_local = ClassFieldStandard.ListOfFields_Students
            ''5/09/2022 td--ClassFieldStandard.InitializeHardcodedList_Standard(True)
            ''5/09/2022 td--list_local = ClassFieldStandard.ListOfFields_Standard
            list_local = ClassFieldStandard.GetInitializedList_Standard("Students")

        End If ''end of "If (list_local Is Nothing) Then"

        ''Moved to calling procedure.March 21 2022''FlowLayoutPanel1.Controls.Clear()

        For Each each_standardField As ClassFieldStandard In list_local

            ''Add 8/19/2019 td
            ''8/22/2019 td''LoadCustomField_Each(each_standardField)
            ''12/14/2021 td''LoadStandardField_Each(each_standardField)

            ''
            ''Add 7/21/2019
            ''
            boolProceed = (par_JustOneField Is Nothing Or
                (par_JustOneField Is each_standardField))

            If (boolProceed) Then

                ''April 30, 2022 ''LoadStandardField_Each(each_standardField)
                LoadStandardField_Each(each_standardField, par_checkLoad)

            End If ''end of " If (boolProceed) Then"

        Next each_standardField

        ''
        ''Add 7/21/2019
        ''
        ''8/22/2019 td''FlowLayoutPanel1.Controls.Add(New CtlAddCustomField())
        ''---FlowLayoutPanel1.Controls.Add(New CtlAddStandardField())

    End Sub ''End of "Private Sub LoadFields()"  

    Private Sub LoadStandardField_Each(par_standardFld As ClassFieldStandard,
                                       par_checkLoad As StructLoadWhatFields)
        ''
        ''Added 8/19/2019
        ''
        Dim userControl As CtlConfigFldStandard
        Dim boolIrrelevant As Boolean ''Added 3/21/2022 td

        ''Added 3/21/2022 td
        boolIrrelevant = (Not par_standardFld.IsRelevantToPersonality)

        Dim userControl_Irrelevant As CtlConfigFldStdRelevancy ''Added 3/23/2022

        If (boolIrrelevant) Then ''Added 3/23/2022 td
            ''Added 4/30/2022 td
            If (par_checkLoad.NonrelevantFields) Then
                ''Added 3/23/2022 td
                userControl_Irrelevant = New CtlConfigFldStdRelevancy
                ''3/23/2022 td''userControl_Irrelevant.Load_StandardControl(CType(par_standardFld, ICIBFieldStandardOrCustom))
                userControl_Irrelevant.Load_StandardControl(par_standardFld) '', ICIBFieldStandardOrCustom))
                userControl_Irrelevant.Visible = True
                FlowLayoutPanel1.Controls.Add(userControl_Irrelevant)
            End If ''End of ""If (par_checkLoad.NonrelevantFields) Then""

        ElseIf (par_checkLoad.RelevantFields) Then ''Condition added 4/30/2022
            ''April 30, 2022 td'' Else
            userControl = New CtlConfigFldStandard
            userControl.Load_StandardControl(CType(par_standardFld, ICIBFieldStandardOrCustom))
            userControl.Visible = True
            FlowLayoutPanel1.Controls.Add(userControl)

        End If ''End of "If (boolIrrelevant) Then .... ElseIf ...."

    End Sub ''End of "Private Sub LoadStandardField_Each(par_standardFld As ClassStandardField)"


    Public Function ConfirmAutoSave() As Boolean

        ''Added 4/30/2022 thomas downes
        Dim boolConfirmed As Boolean
        boolConfirmed = MessageBoxTD.Show_Confirmed("This will trigger an auto-save " &
                               "of any edits that have been made.",
                               "Hit Cancel if you don't want your edits saved.", True)
        Return boolConfirmed

    End Function ''End of "Public Function ConfirmAutoSave() As Boolean"


    Private Sub LinkLabelRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabelRefresh.LinkClicked

        ''Added 7/27/2019 td
        SaveControls()
        FlowLayoutPanel1.Controls.Clear()

        ''Dec.6, 2021''LoadCustomFields_All(Me.ListOfFields)
        ''April 30, 2022 ''LoadFields_All_Custom(Me.ListOfFields_Custom)
        LoadFields_All_Custom(Me.ListOfFields_Custom, mod_structLoad)
        ''April 30, 2022 ''LoadFields_All_Standard(Me.ListOfFields_Standard)
        LoadFields_All_Standard(Me.ListOfFields_Standard, mod_structLoad)

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
            ''April 30, 2022 ''LoadFields_All_Custom(Me.ListOfFields_Custom)
            LoadFields_All_Custom(Me.ListOfFields_Custom, mod_structLoad)
        End If ''End of "If (dia_result = DialogResult.Yes) Then"

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 4/13/2022 thomas Downes 
        ''
        SaveControls()
        Me.ClosingOK_SoSaveWork = True
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ''
        ''Added 4/13/2022 thomas Downes 
        ''
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub LinkLabelShowAllFieldsCS_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelShowAllFieldsCS.LinkClicked

        ''Added 4/30/2022 td 
        With mod_structLoad
            .StandardFields = True
            .CustomFields = True
        End With

        If (ConfirmAutoSave()) Then ''Added 4/30/2022 td

            SaveControls() ''Added 4/30/2022 td

            LoadFields_Master(mod_structLoad)

        End If ''End of ""If (ConfirmAutoSave()) Then"

    End Sub

    Private Sub LinkShowOnlyStandardFields_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkShowOnlyStandardFields.LinkClicked

        ''Added 4/30/2022 td 
        With mod_structLoad
            .StandardFields = True
            .CustomFields = False
        End With

        If (ConfirmAutoSave()) Then ''Added 4/30/2022 td

            SaveControls() ''Added 4/30/2022 td

            LoadFields_Master(mod_structLoad)

        End If ''End of ""If (ConfirmAutoSave()) Then"

    End Sub

    Private Sub LinkLabelShowAllFieldsRNR_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelShowAllFieldsRNR.LinkClicked

        ''Added 4/30/2022 td 
        With mod_structLoad
            .RelevantFields = True
            .NonrelevantFields = True
        End With

        If (ConfirmAutoSave()) Then ''Added 4/30/2022 td

            SaveControls() ''Added 4/30/2022 td

            LoadFields_Master(mod_structLoad)

        End If ''End of ""If (ConfirmAutoSave()) Then"

    End Sub

    Private Sub LinkShowRelevantOnly_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkShowRelevantOnly.LinkClicked

        ''Added 4/30/2022 td 
        With mod_structLoad
            .RelevantFields = True
            .NonrelevantFields = False
        End With

        If (ConfirmAutoSave()) Then ''Added 4/30/2022 td

            SaveControls() ''Added 4/30/2022 td

            LoadFields_Master(mod_structLoad)

        End If ''End of ""If (ConfirmAutoSave()) Then"

    End Sub

    Private Sub LinkShowOnlyNotRelevant_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkShowOnlyNotRelevant.LinkClicked

        ''Added 4/30/2022 td 
        With mod_structLoad
            .RelevantFields = False
            .NonrelevantFields = True
        End With

        If (ConfirmAutoSave()) Then ''Added 4/30/2022 td

            SaveControls() ''Added 4/30/2022 td

            LoadFields_Master(mod_structLoad)

        End If ''End of ""If (ConfirmAutoSave()) Then"

    End Sub

    Private Sub CheckBoxGotIt_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGotIt.Click ''.CheckedChanged
        ''
        ''Add 4/30/2022 thomas downes
        ''
        Dim strStatment As String
        Dim boolConfirmed As Boolean

        strStatment = "Below, each Field's control panel contains a checkbox " &
        "labelled ""Relevant"".  If you leave the checkbox unchecked, you will not " &
        "see that Field.  Example, the Field will not appear in any drop-down lists."

        boolConfirmed = MessageBoxTD.Show_Confirmed(strStatment, "Understand?", False)

        ''LabelHeaderCaption2.Visible = (Not boolConfirmed)
        If (boolConfirmed) Then
            ''Make the color the same as the form's background color. 
            LabelHeaderCaption2.BackColor = Me.BackColor
            CheckBoxGotIt.BackColor = Me.BackColor
        ElseIf (Not boolConfirmed) Then
            LabelHeaderCaption2.BackColor = Drawing.Color.AliceBlue
            CheckBoxGotIt.BackColor = Drawing.Color.AliceBlue
        End If ''End of ""If (Not boolConfirmed) Then""

        If (boolConfirmed) Then CheckBoxGotIt.Checked = True
        If (Not boolConfirmed) Then CheckBoxGotIt.Checked = False

    End Sub



End Class