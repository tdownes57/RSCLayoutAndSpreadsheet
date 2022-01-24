Option Strict On
Option Explicit On
''
''Added 12/6/2021 thomas downes
''
Imports ciBadgeCachePersonality ''Added 12/6/2021 td 

Module modAllowFieldEdits

    ''Added 12/6/2021 thomas downes
    Public Enum EnumStandardCustom
        Undefined
        Standard
        Custom
    End Enum

    Public Sub ShowFieldsToEdit_Standard(par_ElementsCache_Manage As ClassCacheManagement,
                                        par_ElementsCache_Edits As ClassElementsCache_Deprecated,
                                        par_boolDebugMode As Boolean)
        ''
        ''Encapsulated 12/6/2021 thomas downes
        ''
        ShowFieldsToEdit_Either(par_ElementsCache_Manage,
                                par_ElementsCache_Edits,
                                par_boolDebugMode,
                                EnumStandardCustom.Standard)

    End Sub

    Public Sub ShowFieldsToEdit_Custom(par_ElementsCache_Manage As ClassCacheManagement,
                                        par_ElementsCache_Edits As ClassElementsCache_Deprecated,
                                        par_boolDebugMode As Boolean)
        ''
        ''Encapsulated 12/6/2021 thomas downes
        ''
        ShowFieldsToEdit_Either(par_ElementsCache_Manage,
                                par_ElementsCache_Edits,
                                par_boolDebugMode,
                                EnumStandardCustom.Custom)

    End Sub

    Private Sub ShowFieldsToEdit_Either(par_ElementsCache_Manage As ClassCacheManagement,
                                        par_ElementsCache_Edits As ClassElementsCache_Deprecated,
                                        par_boolDebugMode As Boolean,
                                        par_enumType As EnumStandardCustom)
        ''
        ''Encapsulated 12/6/2021 thomas downes
        ''
        Const c_boolCreateTextFile As Boolean = False ''Dec.6 2021'' True
        Dim boolOkayToSave As Boolean ''Added 12/6/2021 
        Dim boolStandard As Boolean = (par_enumType = EnumStandardCustom.Standard)
        Dim bool__Custom As Boolean = (par_enumType = EnumStandardCustom.Custom)

        For intReview As Integer = 1 To 2

            ''--Dim frm_ToShow_AllCustomFields As New ListCustomFieldsFlow()
            Dim frm_ToShowFields As InterfaceShowListFields ''ListCustomFieldsFlow()

            If (boolStandard) Then frm_ToShowFields = New DialogListStandardFields
            If (bool__Custom) Then frm_ToShowFields = New ListCustomFieldsFlow

            ''Dim each_field As ciBadgeFields.ClassFieldCustomized
            ''Dim each_element As ciBadgeElements.ClassElementField
            Dim strListOfBadgeFields As String = ""
            ''Dim why_omit As New WhyOmitted
            ''Dim boolDiffer As Boolean ''Added 12/4/2021 td  

            ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
            ''12/4/2021 td''frm_ToShow.ListOfFields = Form__Main_PreDemo.GetCurrentPersonality_Fields_Custom()

            ''frm_ToShow.ListOfFields.Clear()
            ''Dec.5 2021''frm_ToShow.ListOfFields = New List(Of ClassFieldCustomized)

            ''Dec.5 2021''For Each each_field In par_ElementsCache_Edits.ListOfFields_Custom()
            ''Dec.5 2021''    ''Allow the field to be displayed & edited.
            ''Dec.5 2021''    frm_ToShow.ListOfFields.Add(each_field)
            ''Dec.5 2021''Next each_field

            ''12/6/2021 td''frm_ToShow.ListOfFields = par_ElementsCache_Edits.ListOfFields_Custom
            frm_ToShowFields.CacheManager = par_ElementsCache_Manage ''Added 12/6/2021 td 

            ''1/24/2022 td''frm_ToShowFields.ListOfFields_Standard = par_ElementsCache_Manage.CacheForEditing.ListOfFields_Standard
            ''1/24/2022 td''frm_ToShowFields.ListOfFields_Custom = par_ElementsCache_Manage.CacheForEditing.ListOfFields_Custom

            ''Modified 1/24/2022 td
            frm_ToShowFields.ListOfFields_Standard = par_ElementsCache_Edits.ListOfFields_Standard
            frm_ToShowFields.ListOfFields_Custom = par_ElementsCache_Edits.ListOfFields_Custom

            ''Added 1/24/2022 td
            Dim boolCachesMatch As Boolean ''Added 1/24/2022 td
            boolCachesMatch = (par_ElementsCache_Edits Is par_ElementsCache_Manage.CacheForEditing)
            If (Not boolCachesMatch) Then
                System.Diagnostics.Debugger.Break()
            End If ''End of "If (Not boolCachesMatch) Then"

            ''Dec. 6, 2021 td
            If (c_boolCreateTextFile) Then
                ''Display the field properties, in particular the Boolean values. 
                par_ElementsCache_Manage.OutputToTextFile_CustomFields(par_ElementsCache_Edits.ListOfFields_Custom,
                        "Before Dialog, ElementsCache_Edits")
            End If ''End of "If (c_boolCreateTextFile) Then"

            ''
            ''
            ''Show the user & allow edits!!
            ''
            ''
            frm_ToShowFields.ShowDialog()

            ''Dec. 6, 2021 td
            If (c_boolCreateTextFile) Then
                ''Dec. 6, 2021 td
                par_ElementsCache_Manage.OutputToTextFile_CustomFields(par_ElementsCache_Edits.ListOfFields_Custom,
                                                                      "After Dialog, ElementsCache_Edits")
            End If ''ENdo f "If (c_boolCreateTextFile) Then"

            ''Dec. 6, 2021 td
            boolOkayToSave = frm_ToShowFields.ClosingOK_SoSaveWork
            If (boolOkayToSave) Then

                ''Dec14 2021''par_ElementsCache_Manage.Save()
                Const c_SaveToFile As Boolean = True
                par_ElementsCache_Manage.Save(c_SaveToFile)

            End If ''End of "If (boolOkayToSave) Then"

            ''
            ''
            ''Double-check what has been saved. ----12/4/2021 td
            ''
            ''
            ''par_ElementsCache_ManageBoth.CheckEditedFieldsHaveElementsIfNeeded(pstrErrorMessage)
            Dim strErrorMessage As String = ""
            Dim strListOfCustomFields As String = ""

            If (par_boolDebugMode) Then
                par_ElementsCache_Manage.CheckEditedFieldsHaveElementsIfNeeded_Custom(strListOfCustomFields, strErrorMessage)
                If (False) Then DisplayStringDataInNotepad(strListOfBadgeFields)
            End If ''End of "If (par_boolDebugMode) Then"

            ''Added 12/5/2021 thomas downes
            If (strErrorMessage <> "") Then MessageBox.Show(strErrorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ''Added 12/5/2021 thomas downes
            If (Not par_boolDebugMode) Then Exit For

            If (boolOkayToSave) Then
                ''Allow user to review the saved settings (all over again!). 
                Dim dresult As DialogResult
                dresult = MessageBox.Show("Want to check/confirm your work was saved?", "Check/Confirm?",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (dresult = DialogResult.OK) Then dresult = DialogResult.Yes
                If (dresult <> DialogResult.Yes) Then Exit For
            Else
                ''No need to loop again if the user cancelled out of the dialog box. 
                Exit For
            End If ''end of "If (boolOkayToSave) Then .... Else ...."

        Next intReview

        ''RefreshTheSetOfDisplayedElements()
        ''PictureBox1.SendToBack()

        ''Me.mod_designer.UnloadDesigner()
        ''Me.mod_designer = Nothing

        ''SaveLayout()

        ''>>>>>>>>>>>>>>>>> ExitHandler....
        ''
        ''Major call!! 
        ''
        ''RefreshTheSetOfDisplayedElements()
        ''PictureBox1.SendToBack()

    End Sub ''End of "Private Sub ShowFieldsToEdit_Custom" 


    Public Sub DisplayStringDataInNotepad(par_stringData As String)
        ''
        ''Copied from Form__Main_Demo.vb on 12/5/2021 td   
        ''Added 11/28/2021 thomas downes  
        ''
        Dim strRandomFolder As String
        Dim strRandomFilePath As String
        Dim strRandomTitle As String

        strRandomFolder = DiskFolders.PathToFolder_Preview()
        strRandomTitle = String.Format("Elements {0:HHmmss}.txt", DateTime.Now)
        strRandomFilePath = System.IO.Path.Combine(strRandomFolder, strRandomTitle)
        System.IO.File.WriteAllText(strRandomFilePath, par_stringData)
        System.Diagnostics.Process.Start(strRandomFilePath)

    End Sub ''ENd of "Public Shared Sub DisplayStringDataInNotepad()"


    Private Sub ShowFieldsToEdit_Custom_Deprecated()
        ''
        ''Rendered obselete 12/6/2021 thomas downes
        ''
        ''Const c_boolCreateTextFile As Boolean = False ''Dec.6 2021'' True
        ''Dim boolOkayToSave As Boolean ''Added 12/6/2021 

        ''For intReview As Integer = 1 To 2

        ''    Dim frm_ToShow_AllCustomFields As New ListCustomFieldsFlow()

        ''    ''Dim each_field As ciBadgeFields.ClassFieldCustomized
        ''    ''Dim each_element As ciBadgeElements.ClassElementField
        ''    Dim strListOfBadgeFields As String = ""
        ''    ''Dim why_omit As New WhyOmitted
        ''    ''Dim boolDiffer As Boolean ''Added 12/4/2021 td  

        ''    ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        ''    ''12/4/2021 td''frm_ToShow.ListOfFields = Form__Main_PreDemo.GetCurrentPersonality_Fields_Custom()

        ''    ''frm_ToShow.ListOfFields.Clear()
        ''    ''Dec.5 2021''frm_ToShow.ListOfFields = New List(Of ClassFieldCustomized)

        ''    ''Dec.5 2021''For Each each_field In Me.ElementsCache_Edits.ListOfFields_Custom()
        ''    ''Dec.5 2021''    ''Allow the field to be displayed & edited.
        ''    ''Dec.5 2021''    frm_ToShow.ListOfFields.Add(each_field)
        ''    ''Dec.5 2021''Next each_field

        ''    ''12/6/2021 td''frm_ToShow.ListOfFields = Me.ElementsCache_Edits.ListOfFields_Custom
        ''    frm_ToShow_AllCustomFields.CacheManager = Me.ElementsCache_ManageBoth ''Added 12/6/2021 td 
        ''    frm_ToShow_AllCustomFields.ListOfFields_Custom = Me.ElementsCache_ManageBoth.CacheForEditing.ListOfFields_Custom

        ''    ''Dec. 6, 2021 td
        ''    If (c_boolCreateTextFile) Then
        ''        ''Display the field properties, in particular the Boolean values. 
        ''        Me.ElementsCache_ManageBoth.OutputToTextFile_CustomFields(Me.ElementsCache_Edits.ListOfFields_Custom,
        ''                "Before Dialog, ElementsCache_Edits")
        ''    End If ''End of "If (c_boolCreateTextFile) Then"

        ''    ''
        ''    ''
        ''    ''Show the user & allow edits!!
        ''    ''
        ''    ''
        ''    frm_ToShow_AllCustomFields.ShowDialog()

        ''    ''Dec. 6, 2021 td
        ''    If (c_boolCreateTextFile) Then
        ''        ''Dec. 6, 2021 td
        ''        Me.ElementsCache_ManageBoth.OutputToTextFile_CustomFields(Me.ElementsCache_Edits.ListOfFields_Custom,
        ''                                                              "After Dialog, ElementsCache_Edits")
        ''    End If ''ENdo f "If (c_boolCreateTextFile) Then"

        ''    ''Dec. 6, 2021 td
        ''    boolOkayToSave = frm_ToShow_AllCustomFields.ClosingOK_SoSaveWork
        ''    If (boolOkayToSave) Then

        ''        Me.ElementsCache_ManageBoth.Save()

        ''    End If ''End of "If (boolOkayToSave) Then"

        ''    ''
        ''    ''
        ''    ''Double-check what has been saved. ----12/4/2021 td
        ''    ''
        ''    ''
        ''    ''Me.ElementsCache_ManageBoth.CheckEditedFieldsHaveElementsIfNeeded(pstrErrorMessage)
        ''    Dim strErrorMessage As String = ""
        ''    Dim strListOfCustomFields As String = ""
        ''    Me.ElementsCache_ManageBoth.CheckEditedFieldsHaveElementsIfNeeded_Custom(strListOfCustomFields, strErrorMessage)
        ''    If (False) Then DisplayStringDataInNotepad(strListOfBadgeFields)

        ''    ''Added 12/5/2021 thomas downes
        ''    If (strErrorMessage <> "") Then MessageBox.Show(strErrorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ''    ''Added 12/5/2021 thomas downes
        ''    If (Not mod_boolDebugMode) Then Exit For

        ''    If (boolOkayToSave) Then
        ''        ''Allow user to review the saved settings (all over again!). 
        ''        Dim dresult As DialogResult
        ''        dresult = MessageBox.Show("Want to check/confirm your work was saved?", "Check/Confirm?",
        ''                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        ''        If (dresult = DialogResult.OK) Then dresult = DialogResult.Yes
        ''        If (dresult <> DialogResult.Yes) Then Exit For
        ''    Else
        ''        ''No need to loop again if the user cancelled out of the dialog box. 
        ''        Exit For
        ''    End If ''end of "If (boolOkayToSave) Then .... Else ...."

        ''Next intReview

        ''''RefreshTheSetOfDisplayedElements()
        ''''PictureBox1.SendToBack()

        ''''Me.mod_designer.UnloadDesigner()
        ''''Me.mod_designer = Nothing

        ''''SaveLayout()

        ''''>>>>>>>>>>>>>>>>> ExitHandler....
        ''''
        ''''Major call!! 
        ''''
        ''RefreshTheSetOfDisplayedElements()
        ''PictureBox1.SendToBack()

    End Sub ''End of "Private Sub ShowFieldsToEdit_Custom_Deprecated" 


End Module
