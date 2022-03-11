''
''Added 2/21/2022 td
''
Imports ciBadgeDesigner
Imports ciBadgeFields ''Added 3/10/2022 thomas downes

Public Class RSCFieldSpreadsheet
    ''
    ''Added 2/21/2022 td
    ''
    Public Designer As ClassDesigner ''Added 3/10/2022 td  

    Public Sub PasteData(par_stringPastedData As String)
        ''
        ''Added 2/22/2022 td
        ''




    End Sub

    Private Function ReviewPastedData_IsOkay(par_stringPastedData As String,
                                             ByRef pref_message As String,
                                             ByRef pref_numLines As Integer,
                                             ByRef pref_numColumns As Integer) As Boolean
        ''
        ''Added 2/22/2022 Thomas Downes  
        ''
        Dim boolOneMoreLines As Boolean
        Dim intNumberOfColumns As Integer
        Dim intNumberOfColumns_Prior As Integer
        Dim boolOneOrMoreColumns As Boolean
        Dim array_rows As String()
        Dim array_values As String()
        Dim boolMismatchedColumnCount As Boolean
        Dim intRowIndex As Integer

        par_stringPastedData = "" ''Added 2/22/2022 

        ''Added 2/22/2022 thomas downes
        If (String.IsNullOrEmpty(par_stringPastedData)) Then
            pref_message = "Pasted data is null or zero-length string."
            Return False
        End If ''End of "If (String.IsNullOrEmpty(par_stringPastedData)) Then"

        array_rows = par_stringPastedData.Split(New String() {vbCrLf, vbCr, vbLf}, StringSplitOptions.None)

        For Each each_row As String In array_rows

            intRowIndex += 1
            array_values = each_row.Split(New String() {vbTab}, StringSplitOptions.None)
            intNumberOfColumns = array_values.Count()
            If (intNumberOfColumns_Prior > 0) Then
                If (intNumberOfColumns <> intNumberOfColumns_Prior) Then
                    boolMismatchedColumnCount = True
                    pref_message = String.Format("Irregular data set. The number of columns goes from {0} to {1}, in row {2} of {3}.",
                             intNumberOfColumns_Prior, intNumberOfColumns,
                             intRowIndex, array_rows.Count())
                    Exit For
                End If
            End If
            intNumberOfColumns_Prior = intNumberOfColumns
        Next each_row

        pref_numColumns = CInt(IIf(boolMismatchedColumnCount, -1, intNumberOfColumns))
        pref_numLines = array_rows.Count
        Return (Not boolMismatchedColumnCount)

    End Function ''End of "Private Function ReviewPastedData_IsOkay()"

    Private Sub RSCFieldSpreadsheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 3/10/2022 
        ''
        Const c_boolLetsAutoLoadColumns As Boolean = False ''False, as it may cause weird design-time behavior.

        If (c_boolLetsAutoLoadColumns) Then
            ''
            ''We might not have a designer object at load-time.... set the parameter to Nothing. 
            ''
            Dim objDesigner As ClassDesigner = Nothing
            LoadRuntimeColumns_AfterClearingDesign(objDesigner)

        End If ''End of " If (c_boolLetsAutoLoadColumns) Then"


    End Sub

    Public Sub LoadRuntimeColumns_AfterClearingDesign(par_designer As ClassDesigner)
        ''
        ''Added 3/8/2022 thomas downes 
        ''
        ''Step 1 of 2.  Remove design-time columns..... Clearing (removing) design-time columns (which are placed
        ''   to give a visual preview of how the run-time columns will look). 
        ''
        RemoveRSCColumnsFromDesignTime()

        ''
        ''Step 2 of 2.  Load run- time columns. 
        ''
        ''Added a Number N of Required Columns. 
        ''
        Dim intNeededIndex As Integer = 1
        Dim eachColumn As RSCFieldColumn
        Dim intCurrentPropertyLeft As Integer = 0
        Dim intNextPropertyLeft As Integer = 0
        Const intNeededMax As Integer = 4
        Dim each_field As ciBadgeFields.ClassFieldAny

        For intNeededIndex = 1 To intNeededMax

            each_field = New ciBadgeFields.ClassFieldAny()
            each_field.FieldEnumValue = ciBadgeInterfaces.EnumCIBFields.Undetermined
            eachColumn = GenerateRSCColumn(each_field, intNeededIndex)
            intCurrentPropertyLeft = intNextPropertyLeft
            eachColumn.Left = intCurrentPropertyLeft
            eachColumn.Visible = True
            ''Prepare for next iteration. 
            intNextPropertyLeft = (eachColumn.Left + eachColumn.Width + 3)
            Me.Controls.Add(eachColumn)

        Next intNeededIndex

    End Sub ''End of Private Sub RSCFieldSpreadsheet_Load


    Private Function GenerateRSCColumn(par_objField As ClassFieldAny, par_intFieldIndex As Integer) As RSCFieldColumn
        ''
        ''Added 3/8/2022 td
        ''
        Dim objNewColumn As RSCFieldColumn ''Added 3/8/2022 td

        ''March9 2022 ''objNewColumn = RSCFieldColumn.GetFieldColumn()
        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = Me.Designer.GetParametersToGetElementControl()

        objNewColumn = RSCFieldColumn.GetFieldColumn(objGetParametersForGetControl,
                                                         par_objField, Me, "RSCFieldColumn" & CStr(par_intFieldIndex),
                                                          Me.Designer, True, mod_ctlLasttouched, mod_designer,
                                                          mod_eventsSingleton)

        Return objNew

    End Function ''End of "Private Function GenerateRSCColumn() As RSCFieldColumn"


    Private Sub RemoveRSCColumnsFromDesignTime()
        ''
        ''Added 3/8/2022 thomas d
        ''
        Dim listRSCColumns As New List(Of RSCFieldColumn)

        For Each each_control As Control In Me.Controls
            If (TypeOf each_control Is RSCFieldColumn) Then

                each_control.Dispose()
                each_control.Visible = False
                listRSCColumns.Add(CType(each_control, RSCFieldColumn))

            End If
        Next each_control

        For Each each_control As RSCFieldColumn In listRSCColumns

            Me.Controls.Remove(each_control)

        Next each_control

    End Sub




End Class
