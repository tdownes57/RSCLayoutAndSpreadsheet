Option Explicit On
Option Strict On
''
'' Added 2/22/2022 thomas  
''
Imports ciBadgeDesigner ''Added 3/10/2022 t2h2o2m2a2s2 d2o2w2n2e2s
Imports ciBadgeCachePersonality ''added 3/13/2022 

Public Class DialogEditRecipients
    ''
    '' Added 2/22/2022 thomas  
    ''
    Public ElementsCache_Deprecated As ClassElementsCache_Deprecated

    Private mod_designer As ClassDesigner ''Added 3/10/2022 td
    Private mod_stringPastedData As String ''Added 2/22/2022  
    Private mod_cacheColumnWidthsAndData As ciBadgeDesigner.CacheRSCFieldColumnWidthsEtc ''Added 3/16/2022 

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ''-----Please see Public Sub New(par_cache As ClassElementsCache_Deprecated). 3/13/2022
        ''---mod_designer = New ClassDesigner()
        ''---mod_designer.DontAutoRefreshPreview = True ''Added 3/11/2022 td
        ''---RscFieldSpreadsheet1.Designer = mod_designer
        ''---RscFieldSpreadsheet1.ElementsCache_Deprecated = Me.ElementsCache_Deprecated

    End Sub

    Public Sub New(par_cache As ClassElementsCache_Deprecated)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_designer = New ClassDesigner()
        mod_designer.DontAutoRefreshPreview = True ''Added 3/11/2022 td
        RscFieldSpreadsheet1.Designer = mod_designer
        Me.ElementsCache_Deprecated = par_cache
        RscFieldSpreadsheet1.ElementsCache_Deprecated = Me.ElementsCache_Deprecated

    End Sub

    Private Sub ButtonPasteData_Click(sender As Object, e As EventArgs) Handles ButtonPasteData.Click
        ''
        '' Added 2/22/2022 thomas  
        ''
        mod_stringPastedData = Clipboard.GetText()


ExitHandler:
        ''
        ''Pass the data on.  
        ''
        RscFieldSpreadsheet1.PasteData(mod_stringPastedData)

    End Sub


    Private Function ReviewPastedData_IsOkay(par_stringPastedData As String,
                                             ByRef pref_message As String) As Boolean
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

        ''Added 2/22/2022 t4h4o4m4a4s4 d4o4w4n4e4s4
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

        Return (Not boolMismatchedColumnCount)

    End Function ''End of "Private Function ReviewPastedData_IsOkay()"

    Private Sub DialogEditRecipients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 3/10/2022 thomas d.
        ''
        ''---March 11, 2022---mod_designer = New ClassDesigner()

        If (mod_designer Is Nothing) Then
            Throw New Exception
        End If ''ENd of "If (mod_designer Is Nothing) Then"

        ''
        ''Step 1 of 4.  Get the cache object which stores settings for the spreadsheet. 
        ''
        ''Added 3/16/2022 
        Dim strPathToXML As String = DiskFilesVB.PathToFile_XML_RSCFieldSpreadsheet()

        If (IO.File.Exists(strPathToXML)) Then
            Me.mod_cacheColumnWidthsAndData = CacheRSCFieldColumnWidthsEtc.GetCache(strPathToXML)
        Else
            ''
            ''Create the cache from scratch. 
            ''
            Me.mod_cacheColumnWidthsAndData = New CacheRSCFieldColumnWidthsEtc()
            ''March 18, 2022--Me.mod_cacheColumnWidthsAndData.ListOfColumns() = New List(Of ClassColumnWidthAndData)()
            Me.mod_cacheColumnWidthsAndData.ListOfColumns() = New HashSet(Of ClassColumnWidthAndData)()

        End If ''End of "If (IO.File.Exists(strPathToXML)) Then... Else..."

        ''
        ''Step 2 of 4.  Clear out the design-time spreadsheet control. 
        ''
        Dim intSaveLeft As Integer = RscFieldSpreadsheet1.Left
        Dim intSaveTop As Integer = RscFieldSpreadsheet1.Top
        Dim intSaveWidth As Integer = RscFieldSpreadsheet1.Width
        Dim intSaveHeight As Integer = RscFieldSpreadsheet1.Height
        Dim enumSaveAnchor As AnchorStyles = RscFieldSpreadsheet1.Anchor

        RscFieldSpreadsheet1.Visible = False
        Me.Controls.Remove(RscFieldSpreadsheet1)

        ''
        ''Step 3 of 4.  Create the run-time spreadsheet control.  ''Added 3/21/2022 td
        ''
        RscFieldSpreadsheet1 = RSCFieldSpreadsheet.GetRSCSpreadsheet(mod_designer, Me, "RscFieldSpreadsheet1")

        ''Added 3/21/2022 td
        With RscFieldSpreadsheet1
            .Left = intSaveLeft
            .Top = intSaveTop
            .Width = intSaveWidth
            .Height = intSaveHeight
            .Visible = True
            .Anchor = enumSaveAnchor
        End With
        Me.Controls.Add(RscFieldSpreadsheet1)

        ''
        ''Step 3 of 3.  Populate properties & run loading procedures. 
        ''
        With RscFieldSpreadsheet1
            .ParentForm_DesignerDialog = Me ''Added 3/20/2022 td
            .ParentForm = Me ''Added 3/20/2022 td
            .Designer = mod_designer
            .ElementsCache_Deprecated = Me.ElementsCache_Deprecated ''Added 3/21/2022 td
            .ColumnDataCache = mod_cacheColumnWidthsAndData ''Added 3/16/2022 td
            .LoadRuntimeColumns_AfterClearingDesign(mod_designer)
            .Load_Form()
            ''.Invalidate()
            ''.Refresh()
            .RemoveMoveability() ''Added 3/20/2022 td
            ''Doesn't work here.3/25/2022.Refresh()
            ''Doesn't work here.3/25/2022.AlignRowHeadersWithSpreadsheet() ''Added 3/25/2022 thomas downes

        End With ''End of "With RscFieldSpreadsheet1"

        ''Added 3/20/2022 td
        If (mod_cacheColumnWidthsAndData.FormSize.Width > ButtonOK.Width) Then
            Me.Size = mod_cacheColumnWidthsAndData.FormSize
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOpenFieldsDialog.LinkClicked
        ''
        ''We will open the Fields dialog.  
        ''
        MessageBoxTD.Show_Statement("We will open the Fields dialog.")


    End Sub

    Private Sub RscFieldSpreadsheet1_Load(sender As Object, e As EventArgs) Handles RscFieldSpreadsheet1.Load

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 3/18/2022 
        ''
        RscFieldSpreadsheet1.SaveDataColumnByColumn()
        Me.Close()

    End Sub

    Private Sub LinkLabelSaveColumnData_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelSaveColumnData.LinkClicked
        ''
        ''Added 3/17/2022 thomas 
        ''
        Dim objCacheColumnWidthData As CacheRSCFieldColumnWidthsEtc

        ''objCacheColumnWidthData = RscFieldSpreadsheet1.GetCacheOfSavedData()
        RscFieldSpreadsheet1.SaveDataColumnByColumn(True)
        objCacheColumnWidthData = RscFieldSpreadsheet1.ColumnDataCache



    End Sub

    Private Sub LinkLabelAlignBars_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAlignBars.LinkClicked

        ''Added 3/25/2022 td
        RscFieldSpreadsheet1.AlignRowHeadersWithSpreadsheet()

    End Sub
End Class