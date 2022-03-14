''
''Added 2/21/2022 td
''
Imports ciBadgeDesigner
Imports ciBadgeFields ''Added 3/10/2022 thomas downes
Imports ciBadgeInterfaces ''Added 3/11/2022 t__homas d__ownes

Public Class RSCFieldSpreadsheet
    ''
    ''Added 2/21/2022 td
    ''
    Public Designer As ClassDesigner ''Added 3/10/2022 td  
    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(Me.Designer, False, True) ''Added 1/4/2022 td  
    Private mod_colorOfColumnsBackColor As System.Drawing.Color = Drawing.Color.AntiqueWhite ''Added 3/13/2022 thomas downes

    Public Property BackColorOfColumns() As System.Drawing.Color ''Added 3/13/2022 td
        Get
            Return mod_colorOfColumnsBackColor
        End Get
        Set(value As System.Drawing.Color)
            mod_colorOfColumnsBackColor = value
        End Set
    End Property


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
        Dim array_RSCColumns As RSCFieldColumn()
        ReDim array_RSCColumns(intNeededMax)
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
            ''Added 3/12/2022 thomas downes 
            array_RSCColumns(intNeededIndex) = eachColumn

        Next intNeededIndex

        ''
        ''Step 3 of 3.  Link the columns together.  
        ''
        Dim listColumnsRight = New List(Of RSCFieldColumn)
        Dim each_list As List(Of RSCFieldColumn)
        Dim prior_list As List(Of RSCFieldColumn)
        Dim bNotTheRightmostColumn As Boolean

        For intNeededIndex = intNeededMax To 1 Step -1 ''Going backward, i.e. decrementing the index,
            '' i.e. going from right to left (vs. the standard of going left to right).  
            ''     ---3/12/20022 td

            eachColumn = array_RSCColumns(intNeededIndex)
            ''Moved below. 3/13/2022 td''listColumnsRight.Add(eachColumn)

            ''Let's initialize the list "each_list" with the list "listColumnsRight"
            ''   because  we want "each_list" to be a partial listing of the columns.
            ''   By "a partial listing", I mean only those columns which are on the //right-hand//
            ''   side of column #intNeededIndex.      ---3/12/20022 td
            ''   
            each_list = New List(Of RSCFieldColumn)(listColumnsRight) ''Basically, a copy of listColumnsRight.

            ''Added 3/12/2022 thomas d. 
            bNotTheRightmostColumn = (intNeededIndex < intNeededMax)
            If (bNotTheRightmostColumn) Then

                If (each_list.Contains(eachColumn)) Then Throw New Exception("self-referential")
                eachColumn.ListOfColumnsToBumpRight = each_list

            End If ''End of "If (bNotTheRightmostColumn) Then"

            ''Prepare for next iteration.
            prior_list = each_list
            listColumnsRight.Add(eachColumn)

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

        Const c_boolProportional As Boolean = False ''Added 3/11/2022 td 

        objNewColumn = RSCFieldColumn.GetFieldColumn(objGetParametersForGetControl,
                                                         par_objField, Me.ParentForm,
                                                         "RSCFieldColumn" & CStr(par_intFieldIndex),
                                                          Me.Designer, c_boolProportional,
                                                          mod_ctlLasttouched, Me.Designer,
                                                          mod_eventsSingleton)

        ''Added 3/13/2022 thomas downes
        objNewColumn.BackColor = mod_colorOfColumnsBackColor

        Return objNewColumn

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
