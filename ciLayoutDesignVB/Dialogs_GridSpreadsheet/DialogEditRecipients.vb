Option Explicit On
Option Strict On
''
'' Added 2/22/2022 thomas  
''
Imports ciBadgeDesigner ''Added 3/10/2022 t2h2o2m2a2s2 d2o2w2n2e2s
Imports ciBadgeCachePersonality ''added 3/13/2022 
Imports ciBadgeInterfaces

Public Class DialogEditRecipients
    ''
    '' Added 2/22/2022 thomas  
    ''
    Public ElementsCache_Deprecated As ClassElementsCache_Deprecated

    ''Moved to RSCFieldSpreadsheet. 4/2023 Public StillHavingColumnTrouble As Boolean = True ''Added 4/11/2023 td

    ''Renamed 7/3/2022 td''Public RecipientsCache As ClassCacheOnePersonalityConfig ''Added 3/29/2022 thomas downes
    Public PersonalityRecipientsCache As CachePersnltyCnfgLRecips ''7/4/2022 ClassCacheOnePersonalityConfig ''Added 3/29/2022 thomas downes

    Private mod_designer As New ClassDesigner ''Added 3/10/2022 td
    Private mod_stringPastedData As String ''Added 2/22/2022  
    ''April 13 2022 ''Private mod_cacheColumnWidthsAndData As ciBadgeDesigner.CacheRSCFieldColumnWidthsEtc ''Added 3/16/2022 
    Private mod_cacheColumnWidthsAndData As ciBadgeCachePersonality.CacheRSCFieldColumnWidthsEtc ''Added 4/13 & 3/16/2022 
    Private Const mod_intRscFieldColumn1_Top As Integer = 19 ''Added 4/3/2022 thomas downes
    ''5/01/2023 Private mod_oGroupSizeEvents As New GroupMoveEvents_Singleton(mod_designer, False) ''Added 5/01/2023 td  
    Private mod_oGroupSizeEvents As New GroupMoveEvents_Singleton(mod_designer, True) ''Added 5/01/2023 td  


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

    Public Sub New(par_cacheElements As ClassElementsCache_Deprecated,
                   Optional par_cacheRecipients As CachePersnltyCnfgLRecips = Nothing) ''7/4/2022 ClassCacheOnePersonalityConfig = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''5/01/2023 mod_designer = New ClassDesigner()
        mod_designer.DontAutoRefreshPreview = True ''Added 3/11/2022 td

        ''Added 5/01/2023 td 
        ''5/01/2023 mod_designer.NameOfForm = "DialogEditRecipients"
        mod_designer.DesignerForm = Me
        ''5/1/2023 mod_designer.LoadDesigner("For spreadsheet", False, False, mod_oGroupSizeEvents, False)
        mod_designer.LoadEvents(Nothing, mod_oGroupSizeEvents)

        RscFieldSpreadsheet1.Designer = mod_designer
        Me.ElementsCache_Deprecated = par_cacheElements
        RscFieldSpreadsheet1.ElementsCache_Deprecated = Me.ElementsCache_Deprecated
        RscFieldSpreadsheet1.ElementsCache = Me.ElementsCache_Deprecated ''Added 4/30/2023 
        ''Added 3/28/2022 td
        RscFieldSpreadsheet1.PersonalityCache_Recipients = par_cacheRecipients
        ''7/4/2022 thomas d'' Me.RecipientsCache = par_cacheRecipients
        Me.PersonalityRecipientsCache = par_cacheRecipients

    End Sub

    Private Sub ButtonPasteData_Click(sender As Object, e As EventArgs) Handles ButtonPasteData.Click
        ''
        '' Added 2/22/2022 thomas  
        ''
        mod_stringPastedData = Clipboard.GetText()

        Dim boolDataIsOkay As Boolean ''Added 5/13/2022 
        Dim strWarningMessage As String = "" ''Added 5/13/2022 

        boolDataIsOkay = ReviewPastedData_IsOkay(mod_stringPastedData, strWarningMessage)

        If (boolDataIsOkay) Then
            ''Great news!!
        Else
            MessageBoxTD.Show_Statement(strWarningMessage)

        End If ''End of ""If (boolDataIsOkay) Then.... Else..."


ExitHandler:
        ''
        ''Pass the data on.  
        ''
        RscFieldSpreadsheet1.PasteData_SecondTry() ''---mod_stringPastedData)

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
        ''Step 1(a) of 4.  Get the cache object which stores settings for the spreadsheet. 
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
            Me.mod_cacheColumnWidthsAndData.ListOfColumns() = New HashSet(Of ClassRSCColumnWidthAndData)()

        End If ''End of "If (IO.File.Exists(strPathToXML)) Then... Else..."

        ''
        ''Step 1(b) of 4.  Get the cache object which stores settings for the spreadsheet. 
        ''
        ''Moved here 4/3/2022 Added 3/20/2022 td
        If (mod_cacheColumnWidthsAndData.FormSize.Width > ButtonOK.Width) Then
            Me.Size = mod_cacheColumnWidthsAndData.FormSize
            Application.DoEvents()
            With RscFieldSpreadsheet1
                .RscFieldColumn1.Top = mod_intRscFieldColumn1_Top ''19
                .RscFieldColumn1.Anchor = AnchorStyles.None
                .RscFieldColumn1.Height = (.Height - mod_intRscFieldColumn1_Top) ''19
            End With

        End If ''End of "If (mod_cacheColumnWidthsAndData.FormSize.Width....

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
            ''7/03/2022 td''.RecipientsCache = Me.RecipientsCache ''Added 3/29/2022 thomas downes
            ''7/04/2022 td''.PersonalityCache_Recipients = Me.RecipientsCache ''Added 3/29/2022 thomas downes
            .PersonalityCache_Recipients = Me.PersonalityRecipientsCache ''Added 3/29/2022 thomas downes

            ''Added 3/31/2023 td
            .NumberOfRowsNeededToStart = Me.PersonalityRecipientsCache.ListOfRecipients.Count
            If (.NumberOfRowsNeededToStart = 0) Then
                .NumberOfRowsNeededToStart = Me.PersonalityRecipientsCache.GetRowCount()
            End If ''end of ""If (.NumberOfRowsNeededToStart = 0) Then""

            .ColumnDataCache = mod_cacheColumnWidthsAndData ''Added 3/16/2022 td

            ''4/11/2023 If (Me.StillHavingColumnTrouble) Then ''Added 4/11/2023
            If (RSCFieldSpreadsheet.StillHavingColumnTrouble) Then ''Added 4/11/2023
                ''
                ''Don't call these loading procedures, they might be doing
                '' wacky things. 4/11/2023 
                ''
            Else
                .LoadRuntimeColumns_AfterClearingDesign(mod_designer)
                .Load_Form()

            End If ''End of ""If (RSCFieldSpreadsheet.StillHavingColumnTrouble) Then... Else...

            ''.Invalidate()
            ''.Refresh()
            .RemoveMoveability() ''Added 3/20/2022 td
            ''Doesn't work here.3/25/2022.Refresh()
            ''Doesn't work here.3/25/2022.AlignRowHeadersWithSpreadsheet() ''Added 3/25/2022 thomas downes
            ''Doesn't work here.4/06/2022.AlignRowHeadersWithSpreadsheet() ''Added 3/25/2022 thomas downes

        End With ''End of "With RscFieldSpreadsheet1"

        ''Added 3/20/2022 td
        If (mod_cacheColumnWidthsAndData.FormSize.Width > ButtonOK.Width) Then
            Me.Size = mod_cacheColumnWidthsAndData.FormSize
        End If

        ''Added 5/13/2022 td
        ButtonOK.BringToFront()

    End Sub

    Private Sub LinkLabelOpenFields_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOpenFieldsDialog.LinkClicked
        ''
        ''We will open the Fields dialog.  
        ''
        RscFieldSpreadsheet1.ReviewRelevantFieldsViaDialogForm() ''Encapsulated 4/13/2022 td

        ''Static s_bMsgOnce As Boolean
        ''If (Not s_bMsgOnce) Then
        ''    MessageBoxTD.Show_Statement("We will open the Fields dialog.", "((one-time message)")
        ''    s_bMsgOnce = True
        ''End If

        ''''Major call!!!!   4/13/2022 thomas 
        ''''Dim obj_show As DialogListBothTypeFields
        ''''obj_show = New DialogListBothTypeFields()
        ''''obj_show.ShowDialog()
        ''''RscFieldSpreadsheet1.RefreshFieldDropdowns()

        ''Dim form_ToShow As New DialogListBothTypeFields
        ''Dim dialog_result As DialogResult ''Added 4/13 & 3/23/2022 td

        ''''Added 4/13 & 3/21/2022 td
        ''form_ToShow.ListOfFields_Standard = Me.ElementsCache_Deprecated.ListOfFields_Standard
        ''form_ToShow.ListOfFields_Custom = Me.ElementsCache_Deprecated.ListOfFields_Custom

        ''dialog_result =
        ''   form_ToShow.ShowDialog()

        ''''Added 4/13 & 3/23/2022 td
        ''If (dialog_result = DialogResult.OK) Then
        ''    ''Added 3/23/2022 td
        ''    Me.ElementsCache_Deprecated.SaveToXML()

        ''End If ''End of ""If (dialog_result = ...)"

        ''''Refresh the list of fields above each column. 
        ''RscFieldSpreadsheet1.RefreshFieldDropdowns()

    End Sub

    Private Sub RscFieldSpreadsheet1_Load(sender As Object, e As EventArgs) Handles RscFieldSpreadsheet1.Load

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.DialogResult = DialogResult.Cancel ''Added 3/31/2022 td
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 3/18/2022 
        ''
        Dim dialog_result As DialogResult

        ''Added 5/13/2022 td
        With Me.RscFieldSpreadsheet1

            ''Added 5/13/2022 
            dialog_result = .ReviewColumnDisplayForRelevantFields_1to1(True)

            ''Added 5/13/2022 
            If (dialog_result = DialogResult.Cancel) Then
                MessageBoxTD.Show_Statement("User has opted to stay in the Edit-Recipients dialog.", "", "")
                Exit Sub
            End If ''End of ""If (dialog_result = DialogResult.Cancel) Then""

            ''7/4/2022 thomas d''RscFieldSpreadsheet1.SaveDataColumnByColumnXML()
            RscFieldSpreadsheet1.SaveDataColumnByColumnXML()

        End With ''End of ""With Me.RscFieldSpreadsheet1""

        ''7/4/2022 td''Me.RecipientsCache.SaveToXML() ''Added 4/12/2022 td
        Me.PersonalityRecipientsCache.SaveToXML() ''Added 4/12/2022 td
        Me.DialogResult = DialogResult.OK ''Added 3/31/2022 td
        Me.Close()

    End Sub

    Private Sub LinkLabelSaveColumnData_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelSaveColumnData.LinkClicked
        ''
        ''Added 3/17/2022 thomas 
        ''
        Dim objCacheColumnWidthData As CacheRSCFieldColumnWidthsEtc

        ''objCacheColumnWidthData = RscFieldSpreadsheet1.GetCacheOfSavedData()
        ''RscFieldSpreadsheet1.SaveDataColumnByColumn(True)
        ''July12 2022 td''RscFieldSpreadsheet1.SaveDataColumnByColumn(False)
        RscFieldSpreadsheet1.SaveDataColumnByColumnXML(False)

        objCacheColumnWidthData = RscFieldSpreadsheet1.ColumnDataCache



    End Sub

    Private Sub AlignRowHeadersWithSpreadsheet() ''Added 3/25/2022 thomas downes
        ''Added 3/25/2022 td

        Const c_boolSimpleWay As Boolean = True
        Const c_boolAdvanced As Boolean = False

        If (c_boolSimpleWay) Then
            RscFieldSpreadsheet1.AlignRowHeadersWithSpreadsheet()

        ElseIf c_boolAdvanced Then

            ''Added 3/25/2022
            RscFieldSpreadsheet1.RscFieldColumn1.AlignBottomBars_EvenlySpaced()
            ''4/9/2022 td''RscFieldSpreadsheet1.RscFieldColumn1.AlignTextboxes_ToBottomBars()
            RscFieldSpreadsheet1.RscFieldColumn1.AlignRSCDataCells_ToBottomBars()
            ''RscFieldSpreadsheet1.AlignTextboxesWithBottomBars()
            ''RscFieldSpreadsheet1.RscRowHeaders1.AlignBottomBars_WithColumnOne(RscFieldSpreadsheet1.RscFieldColumn1)
            ''RscFieldSpreadsheet1.RscRowHeaders1.AlignTextBoxes_ToBottomBars(RscFieldSpreadsheet1.RscFieldColumn1)

        End If ''End of ""If (c_boolSimpleWay) Then.... ElseIf ...."

    End Sub

    Private Sub LinkLabelAlignBars_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAlignBars.LinkClicked

        ''Added 3/25/2022 td
        RscFieldSpreadsheet1.AlignRowHeadersWithSpreadsheet()

    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        ''Added 3/25/2022 td
        RscFieldSpreadsheet1.Load_Recipients()

    End Sub

    Private Sub ButtonScrollUp_Click(sender As Object, e As EventArgs) Handles ButtonScrollUp.Click

        ''Added 3/31/2022 thomas downes
        ''
        ''   https://stackoverflow.com/questions/16466787/set-autoscrollposition-of-horizontal-scrollbar-on-tabpage
        ''   tabpage1.AutoScrollPosition = New Point(-tabpage1.AutoScrollPosition.X, 0)
        ''
        With RscFieldSpreadsheet1
            Try
                .AutoScrollPosition = New Point(0, CInt(-0.5 * .AutoScrollPosition.Y))
            Catch
            End Try
        End With

    End Sub


    Private Sub ButtonScrollDown20_Click(sender As Object, e As EventArgs) Handles ButtonScrollDown20.Click
        ''Added 3/31/2022 thomas downes
        ''
        ''   https://stackoverflow.com/questions/16466787/set-autoscrollposition-of-horizontal-scrollbar-on-tabpage
        ''   tabpage1.AutoScrollPosition = New Point(-tabpage1.AutoScrollPosition.X, 0)
        ''
        With RscFieldSpreadsheet1
            Try
                Dim intNewPointY As Integer
                Dim intOldPointY As Integer
                Dim intIncreaseY As Integer
                intOldPointY = .AutoScrollPosition.Y
                intIncreaseY = CInt(2.0 * .Height) ''CInt(0.9 * .Height) ''CInt(0.5 * .Height)
                ''---intNewPointY = intIncreaseY ''(intOldPointY + intIncreaseY)
                intNewPointY = .RscFieldColumn1.Top + .RscFieldColumn1.Height
                ''.AutoScrollPosition = New Point(0, CInt(-1.0 * .AutoScrollPosition.Y))
                ''.AutoScrollPosition = New Point(0, intNewPointY)
                ''.AutoScrollPosition = New Point(0, -20 + .AutoScrollPosition.Y)
                .AutoScrollPosition = New Point(0, 20 * 3 + -1 * .AutoScrollPosition.Y)
                .Refresh()

            Catch ex_scroll As Exception
                Throw
            End Try

        End With ''End of "With RscFieldSpreadsheet1"

    End Sub

    Private Sub ButtonScrollDown5_Click(sender As Object, e As EventArgs) Handles ButtonScrollDown5.Click
        ''Added 3/31/2022 thomas downes
        ''
        ''   https://stackoverflow.com/questions/16466787/set-autoscrollposition-of-horizontal-scrollbar-on-tabpage
        ''   tabpage1.AutoScrollPosition = New Point(-tabpage1.AutoScrollPosition.X, 0)
        ''
        With RscFieldSpreadsheet1
            Try
                Dim intNewPointY As Integer
                Dim intOldPointY As Integer
                Dim intIncreaseY As Integer
                intOldPointY = .AutoScrollPosition.Y
                intIncreaseY = CInt(2.0 * .Height) ''CInt(0.9 * .Height) ''CInt(0.5 * .Height)
                ''---intNewPointY = intIncreaseY ''(intOldPointY + intIncreaseY)
                intNewPointY = .RscFieldColumn1.Top + .RscFieldColumn1.Height
                ''.AutoScrollPosition = New Point(0, CInt(-1.0 * .AutoScrollPosition.Y))
                ''.AutoScrollPosition = New Point(0, intNewPointY)
                ''3/31/2022 td''.AutoScrollPosition = New Point(0, -5 + .AutoScrollPosition.Y)
                ''3/31/2022 td''.AutoScrollPosition = New Point(0, 5 + -1 * .AutoScrollPosition.Y)
                .AutoScrollPosition = New Point(0, 5 * 3 + -1 * .AutoScrollPosition.Y)
                ''.Refresh()

            Catch ex_scroll As Exception
                Throw
            End Try

        End With ''End of "With RscFieldSpreadsheet1"

    End Sub

    Private Sub LinkRefreshRowHeaderHeights_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRefreshRowHeaderHeights.LinkClicked

        ''Added 4/6/2022 thomas downes
        RscFieldSpreadsheet1.RefreshHeightOfRowHeaders()

    End Sub
End Class