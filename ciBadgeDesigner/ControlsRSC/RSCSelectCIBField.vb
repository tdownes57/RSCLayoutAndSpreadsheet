Option Explicit On '' Added 2/16/2022 thomas downes 
Option Strict On '' Added 2/16/2022 thomas downes 
''
'' Added 2/16/2022 thomas downes 
''
Imports ciBadgeFields
Imports ciBadgeInterfaces
Imports ciBadgeCachePersonality ''Added 3/13/2022 td

Public Class RSCSelectCIBField
    ''
    '' Added 2/16/2022 thomas downes 
    ''
    Public ElementsCache_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 3/10/2022 td
    Public ParentSpreadsheet As RSCFieldSpreadsheet ''Added 4/11/2022 thomas 
    Public InfoMouseEvents As RSCInterfaceMouseEvents ''Added 4/1/2022 td
    Public Event RSCMouseUp(sender As Object, e As MouseEventArgs) ''Added 4/1/2022 td
    Public Event RSCFieldChanged(newCIBField As EnumCIBFields) ''Added 4/1/2022 td

    Private mod_fields As List(Of ciBadgeFields.ClassFieldAny)
    Private mod_bLoading As Boolean = False ''Added 4/1/2022 td


    Public WriteOnly Property Loading() As Boolean
        Set(value As Boolean)
            ''Added 4/1/2022 td
            mod_bLoading = value
        End Set
    End Property


    Public Property SelectedValue() As EnumCIBFields
        ''
        ''Added 3/15/2022 thomas downes 
        ''
        Get
            ''Added 3/15/2022 thomas downes 0
            ''----#1 3/18/2022  Return CType(Me.comboBoxRelevantFields.SelectedItem, EnumCIBFields)
            ''----#1 3/18/2022  Return CType(Me.comboBoxRelevantFields.SelectedValue, EnumCIBFields)
            Dim outputEnum As ciBadgeInterfaces.EnumCIBFields ''Added 3/18/2022 thomas downes
            outputEnum = CType(Me.comboBoxRelevantFields.SelectedValue, EnumCIBFields)
            Return outputEnum

        End Get
        Set(value As EnumCIBFields)
            ''Added 3/15/2022 thomas downes 
            ''----3/18/2022  Me.comboBoxRelevantFields.SelectedItem = value
            Me.comboBoxRelevantFields.SelectedValue = value
        End Set
    End Property


    Public Function HasField_Selected() As Boolean
        '
        'Added 5/25/2022
        '
        ''Return (CInt(SelectedValue) > 0)
        Dim outputEnum As ciBadgeInterfaces.EnumCIBFields ''Added 3/18/2022 thomas downes
        outputEnum = CType(Me.comboBoxRelevantFields.SelectedValue, EnumCIBFields)
        Return (CInt(outputEnum) > 0) AndAlso (outputEnum <> EnumCIBFields.Undetermined)

    End Function ''End of ""Public Function HasField_Selected() As Boolean""


    Public Function GetFieldEnumSelected() As EnumCIBFields

        ''Added 5/4/2022 td
        Return Me.SelectedValue()

    End Function


    Public Sub DisplayColumnIndex(par_intColumnIndex As Integer)
        ''
        ''Added 4/26/2022 thomas 
        ''
        ''---RscSelectCIBField1.DisplayColumnIndex(par_intColumnIndex)
        LabelHeader.Text = String.Format("{0}. Relevant Field", par_intColumnIndex)

    End Sub ''End of ""Public Sub DisplayColumnIndex(par_intColumnIndex As Integer)""


    Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 2/16/2022 thomas downes
        ''
        ''Is this is an overload function? No, it's not. 
        ''
        ''Dim each_field As ClassFieldAny
        ''For Each each_field In par_cache.ListOfFields_ForEditing()
        ''    comboBoxRelevantFields.Items.Add(each_field.FieldLabelCaption)
        ''Next each_field

        Dim listOfFields As New List(Of ClassFieldAny)
        Dim bLoadStartingValue As Boolean ''Added 4/1/2022 td

        Me.ElementsCache_Deprecated = par_cache ''Added 5/5/2022 td
        bLoadStartingValue = mod_bLoading ''Added 4/1/2022 td
        mod_bLoading = True ''Added 4/1/2022 td

        ''3/19/2022''listOfFields = par_cache.ListOfFields_SC_ForEditing()
        ''5/13/2022 td''listOfFields = par_cache.ListOfFields_SC_ForEditing(True)
        listOfFields = par_cache.ListOfFields_AnyRelevent()

        ''Added 4/13/2022 td
        ''To restore later, let's save the value which is currently selected.
        ''
        ''--Dim objSelectedValue As Object
        ''--objSelectedValue = comboBoxRelevantFields.SelectedValue
        Dim enum_field_saveForLater As EnumCIBFields
        enum_field_saveForLater = CType(comboBoxRelevantFields.SelectedValue, EnumCIBFields)

        ''Added 3/18/2022
        comboBoxRelevantFields.DisplayMember = "FieldLabelCaption"
        comboBoxRelevantFields.ValueMember = "FieldEnumValue"

        ''
        ''Calling this function's original overload!!
        ''
        ''Not needed.----3/18/2022 thomas d''Load_Control(listOfFields, EnumCIBFields.Undetermined)
        comboBoxRelevantFields.DataSource = Nothing ''Clear out the DataSource, to allow the drop-down list to be cleared. ---4/13/2022
        Application.DoEvents()
        comboBoxRelevantFields.DataSource = listOfFields

        ''Restore the value which was previously selected. ---4/13/2022
        Dim enum_field_restore As EnumCIBFields
        enum_field_restore = enum_field_saveForLater
        comboBoxRelevantFields.SelectedValue = enum_field_restore

        ''mod_bLoading = False ''Added 4/1/2022 td
        mod_bLoading = bLoadStartingValue ''Added 4/1/2022 td

    End Sub ''End of "Public Sub Load_Fields()"


    Public Sub Load_FieldsFromList(par_listOfFields As List(Of ClassFieldAny))
        ''
        ''Added 5/12/2022 thomas downes
        ''
        ''Is this is an overload function? No, it's not. 
        ''
        Dim bLoadStartingValue As Boolean ''Added 4/1/2022 td

        bLoadStartingValue = mod_bLoading ''Added 4/1/2022 td
        mod_bLoading = True ''Added 4/1/2022 td

        ''Added 4/13/2022 td
        ''To restore later, let's save the value which is currently selected.
        ''
        Dim enum_field_saveForLater As EnumCIBFields
        enum_field_saveForLater = CType(comboBoxRelevantFields.SelectedValue, EnumCIBFields)

        ''Added 3/18/2022
        comboBoxRelevantFields.DisplayMember = "FieldLabelCaption"
        comboBoxRelevantFields.ValueMember = "FieldEnumValue"

        ''
        ''Calling this function's original overload!!
        ''
        comboBoxRelevantFields.DataSource = Nothing ''Clear out the DataSource, to allow the drop-down list to be cleared. ---4/13/2022
        Application.DoEvents()
        comboBoxRelevantFields.DataSource = par_listOfFields

        ''Restore the value which was previously selected. ---4/13/2022
        Dim enum_field_restore As EnumCIBFields
        enum_field_restore = enum_field_saveForLater
        comboBoxRelevantFields.SelectedValue = enum_field_restore

        mod_bLoading = bLoadStartingValue ''Added 4/1/2022 td

    End Sub ''End of "Public Sub Load_Fields()"


    Public Sub Load_Control(par_list As List(Of ClassFieldAny), Optional par_enum _
                            As ciBadgeInterfaces.EnumCIBFields = EnumCIBFields.Undetermined)
        ''
        ''Added 2/16/2022 thomas downes
        ''
        Dim each_field As ClassFieldAny
        Dim bLoadStartingValue As Boolean ''Added 4/1/2022 td

        bLoadStartingValue = mod_bLoading ''Added 4/1/2022 td
        mod_bLoading = True ''Added 4/1/2022 td

        ''Added 3/18/2022
        ''---comboBoxRelevantFields.ValueMember = "FieldEnumValue"

        For Each each_field In par_list

            ''comboBoxRelevantFields.Items.Add(each_field.FieldLabelCaption)
            comboBoxRelevantFields.Items.Add(each_field)

        Next each_field

        ''mod_bLoading = False ''Added 4/1/2022 td
        mod_bLoading = bLoadStartingValue ''Added 4/1/2022 td

    End Sub ''End of "Public Sub Load_Control()"


    Private Sub LabelHeader_Click(sender As Object, e As EventArgs) Handles LabelHeader.Click
        ''
        '' Added 2/16/2022 thomas downes 
        ''

    End Sub

    Private Sub LinkLabelOnlyRelevant_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOnlyRelevant.LinkClicked
        ''
        ''Added 3/17/2022 Thomas Downes
        ''
        Dim form_ToShow As New DialogListBothTypeFields
        Dim dialog_result As DialogResult ''Added 3/23/2022 td

        ''Added 3/21/2022 td
        form_ToShow.ListOfFields_Standard = Me.ElementsCache_Deprecated.ListOfFields_Standard
        form_ToShow.ListOfFields_Custom = Me.ElementsCache_Deprecated.ListOfFields_Custom

        dialog_result =
           form_ToShow.ShowDialog()

        ''Added 3/23/2022 td
        If (dialog_result = DialogResult.OK) Then
            ''Added 3/23/2022 td
            Me.ElementsCache_Deprecated.SaveToXML()

            ''Added 4/13/2022 td
            Load_FieldsFromCache(Me.ElementsCache_Deprecated)

            ''Added 8/27/2023 td 
            Dim strFieldAddedFirst As String ''Added 8/27/2023 td 
            Dim strFieldAddedLast As String ''Added 8/27/2023 td 

            strFieldAddedFirst = form_ToShow.Output_FieldAddedFirst
            strFieldAddedLast = form_ToShow.Output_FieldAddedLast

        End If ''End of ""If (dialog_result = ...)"


    End Sub

    Private Sub LabelHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles LabelHeader.MouseUp

        ''Added 4/1/2022 thomas downes
        ''RaiseEvent MouseClick(Me, e)
        RaiseEvent RSCMouseUp(Me, e)

    End Sub

    Private Sub RSCSelectCIBField_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp

        ''Added 6/10/2023 thomas downes
        RaiseEvent RSCMouseUp(Me, e)

    End Sub

    Private Sub comboBoxRelevantFields_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboBoxRelevantFields.SelectedValueChanged

        ''Added 4/1/2022 thomas downes
        Dim enum_field As EnumCIBFields

        If (mod_bLoading) Then Exit Sub
        enum_field = CType(comboBoxRelevantFields.SelectedValue, EnumCIBFields)
        RaiseEvent RSCFieldChanged(enum_field)

    End Sub

    Private Sub comboBoxRelevantFields_MouseEnter(sender As Object, e As EventArgs) Handles comboBoxRelevantFields.MouseEnter

        ''Added 4/13/2022
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub RSCSelectCIBField_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
