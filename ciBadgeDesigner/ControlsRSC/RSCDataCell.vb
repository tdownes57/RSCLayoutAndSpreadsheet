''
''Added 4/7/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
''Imports ciBadgeElements ''Added 9/18/2019 td 
''Imports ciBadgeDesigner ''Added 3/8/2022 td  
''Imports System.Drawing ''Added 10/01/2019 td 
''Imports __RSCWindowsControlLibrary ''Added 1/4/2022 td
''Imports ciBadgeFields ''Added 3/8/2022 thomas downes
''Imports ciBadgeCachePersonality ''Added 3/14/2022 
Imports ciBadgeRecipients ''Added 3/22/2022 td

Public Class RSCDataCell
    ''
    ''Added 4/7/2022 thomas downes
    ''
    Public ParentColumn As RSCFieldColumnV2 ''Added 4/12/2022 td
    Public Recipient As ciBadgeRecipients.ClassRecipient ''Added 4/12/2022 td
    Public Shared CellOfKeyDownTabKey As RSCDataCell ''Added 4/12/2022 td
    Public RowIndex_NeededIfDeleted As Integer ''Added 4/25/2022 td
    Public Event GotFocus_Cell(sender As Object, e As EventArgs) ''Added 5/13/2022

    Public Shared BackColor_NoEmphasis As System.Drawing.Color = System.Drawing.Color.White
    Public Shared BackColor_WithEmphasisOnRow As System.Drawing.Color = System.Drawing.Color.LightGray
    Public Shared BackColor_WithCellFocus As System.Drawing.Color = System.Drawing.Color.White
    ''W.E. = with emphasis ---5/2/2022
    Public Shared BackColor_RowHeaderWE As System.Drawing.Color = System.Drawing.Color.LightGray
    ''N.E. = no emphasis ---5/2/2022
    Public Shared BackColor_RowHeaderNE As System.Drawing.Color = System.Drawing.SystemColors.ButtonFace

    Public Overrides Property Text() As String
        Get
            ''Added 4/6/2022 td
            Return Textbox1a.Text
        End Get
        Set(value As String)
            ''Added 4/6/2022 td
            Textbox1a.Text = value
        End Set
    End Property


    Public Overrides Property BackColor() As Drawing.Color
        Get
            ''Added 4/28/2022 td
            Return Textbox1a.BackColor
        End Get

        Set(value As Drawing.Color)
            ''Added 4/28/2022 td
            ''---MyBase.BackColor = value
            ''May 1, 2022 ''Textbox1a.BackColor = value

            ''Added 4/30/2022 td
            Dim boolHasFocus As Boolean ''Added 4/30/2022 td
            boolHasFocus = Textbox1a.Focused

            If (boolHasFocus And (value = Backcolor_WithEmphasisOnRow)) Then
                ''Added 4/30/2022 td
                Textbox1a.BackColor = Backcolor_WithCellFocus

            Else
                Textbox1a.BackColor = value

            End If

        End Set
    End Property


    Public Property BorderStyle_Textbox() As BorderStyle
        Get
            ''Added 4/28/2022 td
            Return Textbox1a.BorderStyle
        End Get

        Set(value As BorderStyle)
            ''Added 4/28/2022 td
            Textbox1a.BorderStyle = value
        End Set
    End Property


    Public Property Text_CellValue() As String
        Get
            ''Added 4/6/2022 td
            Return Textbox1a.Text
        End Get
        Set(value As String)
            ''Added 4/6/2022 td
            Textbox1a.Text = value
        End Set
    End Property


    ''Public Overrides Property Tag() As Object
    ''    Get
    ''        ''Added 4/6/2022 td
    ''        Return Textbox1a.Text
    ''    End Get
    ''    Set(value As String)
    ''        ''Added 4/6/2022 td
    ''        Textbox1a.Text = value
    ''    End Set
    ''End Property


    Public Property Tag_Text() As String
        Get
            ''Added 4/11/2022 td
            If (Textbox1a Is Nothing) Then Return ""
            If (Textbox1a.Tag Is Nothing) Then Return ""
            Return Textbox1a.Tag.ToString()
        End Get
        Set(value As String)
            ''Added 4/11/2022 td
            Textbox1a.Tag = value
        End Set
    End Property


    Public Function GetNextCell_Right(Optional ByRef pboolEdge As Boolean = False) As RSCDataCell
        ''
        ''4/12/2022 td
        ''
        Dim objRSCDataCell_Right As RSCDataCell
        Dim objRSCDataColumn_Right As RSCFieldColumnV2
        Dim intCurrentRowIndex As Integer

        objRSCDataColumn_Right = Me.ParentColumn.GetNextColumn_Right()
        If (objRSCDataColumn_Right Is Nothing) Then
            pboolEdge = True
            Return Nothing
        End If ''End of ""If (objRSCDataColumn_Left Is Nothing) Then""
        intCurrentRowIndex = Me.ParentColumn.GetRowIndexOfCell(Me)
        objRSCDataCell_Right = objRSCDataColumn_Right.GetCellWithRowIndex(intCurrentRowIndex)
        Return objRSCDataCell_Right

    End Function ''End of ""Public Function GetNextCell_Right() As RSCDataCell""


    Public Function GetNextCell_Left(Optional ByRef pboolEdge As Boolean = False) As RSCDataCell
        ''
        ''4/12/2022 td
        ''
        Dim objRSCDataCell_Left As RSCDataCell
        Dim objRSCDataColumn_Left As RSCFieldColumnV2
        Dim intCurrentRowIndex As Integer

        objRSCDataColumn_Left = Me.ParentColumn.GetNextColumn_Left()
        If (objRSCDataColumn_Left Is Nothing) Then
            pboolEdge = True
            Return Nothing
        End If ''End of ""If (objRSCDataColumn_Left Is Nothing) Then""
        intCurrentRowIndex = Me.ParentColumn.GetRowIndexOfCell(Me)
        objRSCDataCell_Left = objRSCDataColumn_Left.GetCellWithRowIndex(intCurrentRowIndex)
        Return objRSCDataCell_Left

    End Function ''End of ""Public Function GetNextCell_Left() As RSCDataCell""


    Public Function GetNextCell_Up(Optional ByRef pboolEdge As Boolean = False,
                                   Optional par_intNumRowsToSkip As Integer = 1) As RSCDataCell
        ''
        ''4/12/2022 td
        ''
        Dim intCurrentRowIndex As Integer
        Dim objRSCDataCell_Up As RSCDataCell
        intCurrentRowIndex = Me.ParentColumn.GetRowIndexOfCell(Me)
        If (intCurrentRowIndex = 1) Then
            pboolEdge = True
            Return Nothing
        End If ''End of ""If (intCurrentRowIndex = 1) Then""

        Dim boolAboveTopEdge As Boolean ''Added 5/1/2022
        boolAboveTopEdge = (1 > (intCurrentRowIndex - par_intNumRowsToSkip))

        If (boolAboveTopEdge And par_intNumRowsToSkip > 1) Then
            ''Get the top row of the spreadsheet. ---5/1/2022 td
            Const intIndexOfTopRow As Integer = 1
            objRSCDataCell_Up = Me.ParentColumn.GetCellWithRowIndex(intIndexOfTopRow)

        ElseIf (par_intNumRowsToSkip > 1) Then ''Added 5/1/2022 td
            ''Added 5/1/2022 td
            objRSCDataCell_Up =
                Me.ParentColumn.GetCellWithRowIndex(intCurrentRowIndex - par_intNumRowsToSkip)

        Else
            objRSCDataCell_Up = Me.ParentColumn.GetCellWithRowIndex(-1 + intCurrentRowIndex)
        End If

        Return objRSCDataCell_Up

    End Function ''End of "" Public Function GetNextCell_Up() As RSCDataCell""


    Public Function GetNextCell_Down(Optional ByRef pboolEdge As Boolean = False,
                                    Optional par_intNumRowsToSkip As Integer = 1) As RSCDataCell
        ''
        ''4/12/2022 td
        ''
        Dim intCurrentRowIndex As Integer
        Dim intMaximumRowIndex As Integer ''Added 4/2022
        Dim objRSCDataCell_Down As RSCDataCell
        Dim boolBelowBottomEdge As Boolean ''Added 5/1/2022

        intCurrentRowIndex = Me.ParentColumn.GetRowIndexOfCell(Me)
        intMaximumRowIndex = Me.ParentColumn.ParentSpreadsheet.RscRowHeaders1.CountOfRows()
        boolBelowBottomEdge = (intMaximumRowIndex < (intCurrentRowIndex + par_intNumRowsToSkip))

        If (boolBelowBottomEdge) Then
            ''Added 5/12022 
            objRSCDataCell_Down = Me.ParentColumn.GetCellWithRowIndex(intMaximumRowIndex)

        ElseIf (intCurrentRowIndex = Me.ParentColumn.CountOfRows()) Then
            pboolEdge = True
            Return Nothing
        End If ''End of ""If (intCurrentRowIndex = 1) Then""

        ''April 2022''objRSCDataCell_Down = Me.ParentColumn.GetCellWithRowIndex(1 + intCurrentRowIndex)
        If (boolBelowBottomEdge And par_intNumRowsToSkip > 1) Then
            ''Get the bottom row of the spreadsheet. ---5/1/2022 td
            ''5/1/2022 ''Const intIndexOfBottomRow As Integer = 1
            objRSCDataCell_Down = Me.ParentColumn.GetCellWithRowIndex(intMaximumRowIndex)

        ElseIf (par_intNumRowsToSkip > 1) Then ''Added 5/1/2022 td
            ''Added 5/1/2022 td
            objRSCDataCell_Down =
                Me.ParentColumn.GetCellWithRowIndex(intCurrentRowIndex + par_intNumRowsToSkip)

        Else
            objRSCDataCell_Down = Me.ParentColumn.GetCellWithRowIndex(1 + intCurrentRowIndex)

        End If ''End of ""If (boolBelowBottomEdge And par_intNumRowsToSkip > 1) Then... ElseIf... Else...""

        Return objRSCDataCell_Down

    End Function ''End of ""Public Function GetNextCell_Down() As RSCDataCell""


    Public Function GetFirstCell_NextRowDown(Optional ByRef pboolEdge As Boolean = False) As RSCDataCell
        ''
        ''4/12/2022 td
        ''
        Dim intCurrentRowIndex As Integer
        Dim objRSCDataCell_Down As RSCDataCell
        Dim objRSCDataColumn_First As RSCFieldColumnV2

        intCurrentRowIndex = Me.ParentColumn.GetRowIndexOfCell(Me)
        If (intCurrentRowIndex = Me.ParentColumn.CountOfRows()) Then
            pboolEdge = True
            Return Nothing
        End If ''End of ""If (intCurrentRowIndex = 1) Then""

        objRSCDataColumn_First = Me.ParentColumn.GetFirstRSCFieldColumn()
        If (objRSCDataColumn_First Is Nothing) Then Throw New Exception
        objRSCDataCell_Down = objRSCDataColumn_First.GetCellWithRowIndex(1 + intCurrentRowIndex)
        Return objRSCDataCell_Down

    End Function ''End of ""Public Function GetFirstCell_NextRowDown() As RSCDataCell""


    Public Function HasFocus() As Boolean

        ''Added 4/30/2022 td
        Dim boolHasFocus As Boolean ''Added 4/30/2022 td
        boolHasFocus = Textbox1a.Focused

    End Function ''End of ""Public Function HasFocus() As Boolean""  


    Public Sub SaveDataToRecipientField(par_enumCIBField As EnumCIBFields)
        ''
        ''Added 4/12/2022 
        ''
        If (Me.Recipient Is Nothing) Then
            Throw New Exception("Recipient is a null reference")
        End If ''End of ""If (Me.Recipient Is Nothing) Then""

        ''4/12/2022 td''Me.Recipient.SaveDataByField(par_enumCIBField, Textbox1a.Text)
        Me.Recipient.SaveTextValue(par_enumCIBField, Textbox1a.Text)

        ''Let's indicate that the data has been saved. 
        Textbox1a.Tag = Textbox1a.Text

    End Sub ''End of ""Public Sub SaveDataToRecipientField(enumCIBField As EnumCIBFields)""


    Public Sub LoadDelimitedData(par_strDelimited As String,
                      Optional pbCountCarriageReturns As Boolean = False)
        ''
        ''Added 4/26/2022 thomas downes
        ''
        Dim boolHasCrLfCharacter As Boolean ''Added 4/12/2022 td
        Dim boolHasCrCharacter As Boolean ''Added 4/12/2022 td
        Dim boolHasLfCharacter As Boolean ''Added 4/30/2022 td
        Dim strRemainingAfterDelimiter As String ''Added 4/26/2022 td 
        Dim bLastCharIs_CrLf As Boolean ''Added 4/30/2022 td
        Dim bLastCharIsCr As Boolean ''Added 4/30/2022 td
        Dim bLastCharIsLf As Boolean ''Added 4/30/2022 td
        Dim intCountCRs As Integer ''Added 5/1/2022 td
        Dim intRowIndex As Integer ''Added 5/1/2022 td

        ''Cleaning. 
        par_strDelimited = par_strDelimited.Trim()

        ''More cleaning. #1 of 2
        With par_strDelimited
            ''Added 4/30/2022 td
            bLastCharIsCr = (.LastIndexOf(vbCr) = (.Length - 1 - vbCr.Length + 1))
            bLastCharIsLf = (.LastIndexOf(vbLf) = (.Length - 1 - vbLf.Length + 1))
            bLastCharIs_CrLf = (bLastCharIsCr Or bLastCharIsLf)
            ''If needed, remove the final line-feed character. 
            If (bLastCharIsLf) Then par_strDelimited = .Substring(0, .LastIndexOf(vbLf))
        End With

        ''More cleaning. #2 of 2  
        With par_strDelimited
            bLastCharIsCr = (.LastIndexOf(vbCr) = (.Length - 1 - vbCr.Length + 1))
            ''If needed, remove the final Carriage-Return character. 
            If (bLastCharIsCr) Then par_strDelimited = .Substring(0, .LastIndexOf(vbCr))
        End With

        With par_strDelimited

            boolHasCrLfCharacter = par_strDelimited.Contains(vbCrLf) ''//Then
            boolHasCrCharacter = par_strDelimited.Contains(vbCr) ''//Then
            boolHasLfCharacter = par_strDelimited.Contains(vbLf) ''//Then
            ''Added 4/30/2022 
            ''---Not needed.---boolHasCrLfCharacter = (boolHasCrLfCharacter Or boolHasCrCharacter Or boolHasLfCharacter)

            If (boolHasCrLfCharacter) Then

                ''Added 5/1/2022 td
                ''  Let's count the carriage returns.
                ''
                If (pbCountCarriageReturns) Then
                    intCountCRs = CountCarriageReturns(par_strDelimited)
                    intRowIndex = Me.ParentColumn.GetRowIndexOfCell(Me)
                    With Me.ParentColumn.ParentSpreadsheet.RscRowHeaders1
                        .Load_EmptyRows(intRowIndex + intCountCRs - 1)
                    End With
                End If ''End of ""If (pbCountCarriageReturns) Then""

                ''Parse the tabbed values.  
                strRemainingAfterDelimiter = .Substring(1 + .IndexOf(vbCrLf))
                    Dim objNextCell As RSCDataCell
                    objNextCell = Me.GetNextCell_Down()

                    ''Add an additional row. ----4/30/2022 td
                    If (objNextCell Is Nothing) Then
                        ''4/30/2022 ''Me.ParentColumn.AddRowToBottomOfSpreadsheet()
                        AddToEdgeOfSpreadsheet_Row()
                        objNextCell = Me.GetNextCell_Down()
                    End If ''End of ""If (objNextCell Is Nothing) Then""

                    If (objNextCell IsNot Nothing) Then
                        objNextCell.LoadDelimitedData(strRemainingAfterDelimiter)
                    End If ''End of ""If (objNextCell IsNot Nothing) Then""

                    ''Textbox1a.Text = .Substring(0, .IndexOf(vbCrLf))
                    LoadTabbedData(.Substring(0, .IndexOf(vbCrLf)))

                ElseIf (boolHasCrCharacter) Then

                    ''Parse the tabbed values.  
                    strRemainingAfterDelimiter = .Substring(1 + .IndexOf(vbCr))
                    Dim objNextCell As RSCDataCell
                    objNextCell = Me.GetNextCell_Down()
                    If (objNextCell IsNot Nothing) Then objNextCell.LoadDelimitedData(strRemainingAfterDelimiter)
                    ''Textbox1a.Text = .Substring(0, .IndexOf(vbCr))
                    LoadTabbedData(.Substring(0, .IndexOf(vbCr)))

                Else

                    LoadTabbedData(par_strDelimited)

            End If ''End of ""If (boolHasCrLfCharacter) Then .... ElseIf .... Else...

        End With ''End of ""With par_strDelimited""


    End Sub ''End of ""Public Sub LoadDelimitedData(par_strDelimited As String)""


    Public Sub LoadTabbedData(par_strTabbed As String)
        ''
        ''Added 4/13/2022 thomas downes
        ''
        Dim boolHasTabCharacter As Boolean ''Added 4/12/2022 td
        Dim strPostTabLine As String ''Added 4/12/2022 td

        boolHasTabCharacter = par_strTabbed.Contains(vbTab) ''//Then
        If (boolHasTabCharacter) Then
            ''
            ''Check to see if the user has typed the text value and then pressed
            ''   the "Enter" key, as if to finalize the cell-editing work.
            ''   ---4/12/2022 td
            ''
            ''April 30, 2022 ''Dim bTabIsLastChar As Boolean ''Added 4/12/2022 td
            Dim bNextTabIsLastChar As Boolean ''Added 4/12/2022 td

            With par_strTabbed
                ''#1 4/30/2022 ''bTabIsLastChar = (.IndexOf(vbTab) = (.Length - 1 - vbTab.Length + 1))
                ''#2 4/30/2022 ''bTabIsLastChar = (.LastIndexOf(vbTab) = (.Length - 1 - vbTab.Length + 1))
                bNextTabIsLastChar = (.IndexOf(vbTab) = (.Length - 1 - vbTab.Length + 1))
                If bNextTabIsLastChar Then
                    ''Don't (_NOT_) try to parse the tabbed values.  However,
                    ''  we should remove the final tab character.
                    ''  ----4/13/2022 td
                    ''4/30/2022 ''Textbox1a.Text = .Substring(0, .IndexOf(vbTab))
                    ''5/01/2022 ''Textbox1a.Text = .Substring(0, .LastIndexOf(vbTab))
                    Textbox1a.Text = .Substring(0, .LastIndexOf(vbTab)).Trim()

                Else
                    ''Parse the tabbed values.  
                    strPostTabLine = .Substring(1 + .IndexOf(vbTab))
                    Dim objNextCell As RSCDataCell
                    objNextCell = Me.GetNextCell_Right()
                    ''4/30/2022''If (objNextCell IsNot Nothing) Then objNextCell.LoadTabbedData(strPostTabLine)
                    If (objNextCell Is Nothing) Then
                        AddToEdgeOfSpreadsheet_Column()
                        objNextCell = Me.GetNextCell_Right()
                    End If ''End of ""If (objNextCell Is Nothing) Then""
                    objNextCell.LoadTabbedData(strPostTabLine)
                    ''5/01/2022 ''Textbox1a.Text = .Substring(0, .IndexOf(vbTab))
                    Textbox1a.Text = .Substring(0, .IndexOf(vbTab)).Trim()

                End If ''End of ""If bNextTabIsLastChar Then.... Else ...""
            End With ''End of ""With par_strTabbed""

        Else
            ''
            ''No Tab character. 
            ''
            ''5/01/2022 td ''Textbox1a.Text = par_strTabbed
            Textbox1a.Text = par_strTabbed.Trim()

        End If ''End of ""If (boolHasTabCharacter) Then... Else....""

    End Sub ''End of "Public Sub LoadTabbedData()"


    Public Sub SetFocus()
        ''
        ''Added 4/12/2022 td
        ''
        Textbox1a.Focus()
        Textbox1a.SelectAll()

    End Sub ''End of ""Public Sub SetFocus()""


    Public Sub ReviewForAbnormalLengthValues(ByRef pboolHasAbnormalLength As Boolean)
        ''
        ''Added 4/26/2022 td
        ''
        Dim bAbnormal_Lengthy As Boolean
        Dim bAbnormal_Shorter As Boolean
        Dim boolAbnormal As Boolean

        bAbnormal_Lengthy = Me.ParentColumn.ValueIsAbnormal_Lengthy(Me.Text_CellValue)
        bAbnormal_Shorter = Me.ParentColumn.ValueIsAbnormal_Shorter(Me.Text_CellValue)
        boolAbnormal = (bAbnormal_Lengthy Or bAbnormal_Shorter)
        pboolHasAbnormalLength = boolAbnormal

        ''--LinkLabelOutlier_LinkClicked(LinkLabelOutlier, event_args)
        LinkLabelOutlier.Visible = boolAbnormal

        If (bAbnormal_Lengthy) Then Textbox1a.BackColor = Drawing.Color.Beige
        If (bAbnormal_Shorter) Then Textbox1a.BackColor = Drawing.Color.LightCoral

    End Sub ''End of ""Public Sub ReviewForAbnormalValues()""


    Private Sub AddToEdgeOfSpreadsheet_Row()
        ''Added 4/30/2020 thomas d.
        ''4/30/2022 td''Me.ParentColumn.AddRowToBottomOfSpreadsheet()
        Me.ParentColumn.AddToEdgeOfSpreadsheet_Row()

    End Sub ''end of ""Private Sub AddToEdgeOfSpreadsheet_Row()""


    Private Sub AddToEdgeOfSpreadsheet_Column()
        ''Added 4/30/2020 thomas d.
        Me.ParentColumn.AddToEdgeOfSpreadsheet_Column()

    End Sub ''end of ""Private Sub AddToEdgeOfSpreadsheet_Column()""


    Private Function CountCarriageReturns(par_delimiteddata As String) As Integer
        ''Added 5/1/2022 thomas downes
        Dim intCountCRs As Integer = 0
        For Each each_char As Char In par_delimiteddata
            If (each_char = vbCr) Then intCountCRs += 1
        Next each_char
        Return intCountCRs

    End Function


    Public Sub PasteDataFromClipboard(pbUserConfirmedOverwrite As Boolean)
        ''
        ''Added 5/13/2022 td 
        ''
        Dim boolHasDataAlready As Boolean
        Dim boolUserConfirmedPaste As Boolean
        Dim boolCheckWithUser As Boolean

        boolHasDataAlready = (Not String.IsNullOrWhiteSpace(Me.Text_CellValue))
        boolCheckWithUser = (boolHasDataAlready And (Not pbUserConfirmedOverwrite))

        If (boolCheckWithUser) Then

            boolUserConfirmedPaste = MessageBoxTD.Show_Confirmed("Overwrite existing data?", "", False)

        Else
            boolUserConfirmedPaste = True ''Force to True, since we don't anticipate
            ''  any problems of overwriting data, as no data has been detected. 

        End If ''End of ""If (boolCheckWithUser) Then... Else...""

        ''
        ''Proceed w/ the pasting of the clipboard data, if all is okay.
        ''
        If (boolUserConfirmedPaste) Then
            ''Major call!! 
            Text_CellValue = Clipboard.GetText
        End If ''end of ""If (boolUserConfirmedPaste) Then""


    End Sub ''End of ""Public Sub PasteDataFromClipboard()""



    Private Sub Textbox1a_TextChanged(sender As Object, e As EventArgs) Handles Textbox1a.TextChanged
        ''
        ''Added 4/12/2022 td
        ''
        Dim boolHasCrCharacter As Boolean ''Added 4/27/2022 td
        Dim boolHasTabCharacter As Boolean ''Added 4/12/2022 td
        ''Dim strPostTabLine As String ''Added 4/12/2022 td

        boolHasCrCharacter = Textbox1a.Text.Contains(vbCr) ''//Then
        boolHasTabCharacter = Textbox1a.Text.Contains(vbTab) ''//Then

        If (boolHasCrCharacter) Then
            ''
            ''Added 4/27/2022
            ''
            ''4/2022 td ''LoadDelimitedData(Textbox1a.Text)
            LoadDelimitedData(Textbox1a.Text, True)

        ElseIf (boolHasTabCharacter) Then
            ''
            ''Check to see if the user has typed the text value and then pressed
            ''   the "Enter" key, as if to finalize the cell-editing work.
            ''   ---4/12/2022 td
            ''
            LoadTabbedData(Textbox1a.Text)

            ''Dim bTabIsLastChar As Boolean ''Added 4/12/2022 td

            ''With Textbox1a.Text
            ''    bTabIsLastChar = (.IndexOf(vbTab) = (.Length - 1 - vbTab.Length + 1))
            ''    If bTabIsLastChar Then
            ''        ''
            ''        ''Don't (_NOT_) try to parse the tabbed values.  
            ''        ''
            ''    Else
            ''        ''Parse the tabbed values.  
            ''        strPostTabLine = .Substring(1 + .IndexOf(vbTab))
            ''        ''----Me.GetNextCell_Right().LoadTabbedData(strPostTabLine)
            ''        Dim objNextCell As RSCDataCell
            ''        objNextCell = Me.GetNextCell_Right()
            ''        If (objNextCell IsNot Nothing) Then objNextCell.LoadTabbedData(strPostTabLine)
            ''        Textbox1a.Text = .Substring(0, .IndexOf(vbTab))

            ''    End If ''End of ""If bTabIsLastChar Then.... Else ...""
            ''End With ''End of ""With Textbox1a.Text""

        End If ''End of ""If (boolHasTabCharacter) Then""

        ''Dim boolHasCrLf As Boolean ''Added 4/12/2022 td
        ''boolHasCrLf = Textbox1a.Text.Contains(vbCr) ''//Then
        ''If (boolHasCrLf) Then
        ''    ''
        ''    ''Check to see if the user has typed the text value and then pressed
        ''    ''   the "Enter" key, as if to finalize the cell-editing work.
        ''    ''   ---4/12/2022 td
        ''    ''
        ''    Dim bCrLfIsLastChars As Boolean ''Added 4/12/2022 td

        ''    With Textbox1a.Text
        ''        bCrLfIsLastChars = (.IndexOf(vbCrLf) = (.Length - 1 - vbCrLf.Length + 1))
        ''        If bCrLfIsLastChars Then
        ''            ''Remove the Cr-Lf combination of characters.
        ''            Textbox1a.Text = .Substring(0, .Length - vbCrLf.Length)
        ''            ''Move the focus to the next cell below. 
        ''            GetNextCell_Down().SetFocus()
        ''            Exit Sub
        ''        Else
        ''            LinkLabelCrLf.Visible = boolHasCrLf
        ''        End If ''End of ""If bCrLfIsLastChars Then.... Else ....""
        ''    End With ''End of ""With Textbox1a.Text""

        ''    ''Moved into condition above. ''LinkLabelCrLf.Visible = boolHasCrLf

        ''End If ''End of ""If (boolHasCrLf) Then""

    End Sub


    Private Sub LinkLabelCrLf_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        ''Added 4/12/2022 thomas downes 
        MessageBoxTD.Show_Statement("There are multiple (>1) lines in this textbox.",
           "Use the up-down arrow keys to view the text of each line.")


    End Sub


    Private Sub Textbox1a_KeyUp(sender As Object, e As KeyEventArgs) Handles Textbox1a.KeyUp
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Dim objNextCell As RSCDataCell = Nothing
        Dim intRowIndex_Me As Integer
        Dim intRowIndex_Sender As Integer
        Dim intRowIndex_TabDown As Integer
        Dim bJumpedToNextRowSuprisingly As Boolean
        Dim bEdgeUp As Boolean
        Dim bEdgeDn As Boolean
        Dim bEdgeLt As Boolean
        Dim bEdgeRt As Boolean
        Dim bEdgeTb As Boolean

        intRowIndex_Me = Me.ParentColumn.GetRowIndexOfCell(Me)

        intRowIndex_Sender = Me.ParentColumn.GetRowIndexOfTextbox(CType(sender, TextBox))
        intRowIndex_TabDown = Me.ParentColumn.GetRowIndexOfCell(CellOfKeyDownTabKey)
        bJumpedToNextRowSuprisingly = (intRowIndex_Me = 1 + intRowIndex_Sender) Or
                 (intRowIndex_Me = 1 + intRowIndex_TabDown)
        Const c_bTabCausesRowJump As Boolean = True
        bJumpedToNextRowSuprisingly = (bJumpedToNextRowSuprisingly Or c_bTabCausesRowJump)

        ''If e.KeyCode = Keys.Up Then objNextCell = GetNextCell_Up() ''.SetFocus
        ''If e.KeyCode = Keys.Down Then objNextCell = GetNextCell_Down() ''.SetFocus()
        ''If e.KeyCode = Keys.Left Then objNextCell = GetNextCell_Left() ''.SetFocus
        ''If e.KeyCode = Keys.Right Then objNextCell = GetNextCell_Right() ''.SetFocus
        ''If e.KeyCode = Keys.Tab Then objNextCell = GetNextCell_Right() ''.SetFocus

        Select Case e.KeyCode
            Case Keys.Up : objNextCell = GetNextCell_Up(bEdgeUp) ''.SetFocus
            Case Keys.Down : objNextCell = GetNextCell_Down(bEdgeDn) ''.SetFocus()
            Case Keys.Left : objNextCell = GetNextCell_Left(bEdgeLt) ''.SetFocus
            Case Keys.Right
                ''We might be in the last column of the spreadsheet. ----4/12/2022 td
                objNextCell = GetNextCell_Right(bEdgeRt) ''.SetFocus
                If bEdgeRt Then
                    ''Let's go to the first column of the next row.
                    objNextCell = GetFirstCell_NextRowDown()
                End If

            Case Keys.PageUp : objNextCell = GetNextCell_Up(bEdgeUp, 25) ''.SetFocus
            Case Keys.PageDown : objNextCell = GetNextCell_Down(bEdgeDn, 25) ''.SetFocus()

            Case Keys.Tab
                objNextCell = GetNextCell_Right(bEdgeTb) ''.SetFocus
                ''Added 4/12/2022 
                If (bJumpedToNextRowSuprisingly And Not bEdgeTb) Then
                    objNextCell = objNextCell.GetNextCell_Up()
                ElseIf bEdgeTb Then
                    ''Let's go to the first column of the next row.
                    objNextCell = GetFirstCell_NextRowDown()
                    If (bJumpedToNextRowSuprisingly) Then
                        If (objNextCell IsNot Nothing) Then
                            objNextCell = objNextCell.GetNextCell_Up()
                        End If ''If (objNextCell IsNot Nothing) Then
                    End If ''If (bJumpedToNextRowSuprisingly) Then
                End If ''End of ""If (bJumpedToNextRowSuprisingly And Not boolEdge) Then... ElseIf...""

            Case Else

                ''Added 4/28/2022 td
                ''  Put a border around the box. 
                ''----Moved below.---Textbox1a.BorderStyle = BorderStyle.FixedSingle


        End Select ''End of ""Select Case e.KeyCode""

        ''
        ''Check to see if the user might like to see additional, hidden lines
        ''  of text (in case the Textbox value contains carriage-return 
        ''  characters).  
        ''
        Dim boolHasCrLf As Boolean
        Dim bPressedUpOrDownKey As Boolean
        Dim bMaybeUserNeedsToReviewLines As Boolean
        boolHasCrLf = Textbox1a.Text.Contains(vbCr)
        bPressedUpOrDownKey = ((e.KeyCode = Keys.Up) Or (e.KeyCode = Keys.Down))
        bMaybeUserNeedsToReviewLines = (boolHasCrLf And bPressedUpOrDownKey)

        If (bMaybeUserNeedsToReviewLines) Then
            ''
            ''Do nothing. Allow the textbox to perform its default behavior,
            ''  which is to display the next line of CrLf-separated text. 
            ''  ----4/26/2022 td
            ''
        ElseIf (objNextCell Is Nothing) Then

            ''Added 4/28/2022 td 
            ''
            ''Emphasis the current cell. 
            ''
            Textbox1a.BorderStyle = BorderStyle.FixedSingle ''Add a border to the current cell.

        ElseIf (objNextCell IsNot Nothing) Then

            ''Goto the next cell. 
            Textbox1a.BorderStyle = BorderStyle.None ''Clear the border of the current cell.
            objNextCell.SetFocus()
            objNextCell.BorderStyle_Textbox = BorderStyle.FixedSingle ''4/28/2022 td
            Me.ParentColumn.ClearBorderStyle_PriorCell(objNextCell)

        End If ''End of "If (objNextCell IsNot Nothing) Then"

        ''
        ''Check to see if something was pasted to the cell??? 
        ''

    End Sub

    Private Sub Textbox1a_KeyDown(sender As Object, e As KeyEventArgs) Handles Textbox1a.KeyDown

        ''Added 4/12/2022 td
        If (e.KeyCode = Keys.Tab) Then
            CellOfKeyDownTabKey = Me
        End If ''If (e.KeyCode = Keys.Tab) Then

    End Sub

    Private Sub LinkLabelOutlier_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOutlier.LinkClicked

        ''Added 4/26/2022 thomas downes 
        Dim bAbnormal_Lengthy As Boolean
        Dim bAbnormal_Shorter As Boolean
        Dim boolAbnormal As Boolean
        Dim strAbnormalWord As String = ""

        bAbnormal_Lengthy = Me.ParentColumn.ValueIsAbnormal_Lengthy(Me.Text_CellValue)
        bAbnormal_Shorter = Me.ParentColumn.ValueIsAbnormal_Shorter(Me.Text_CellValue)
        boolAbnormal = (bAbnormal_Lengthy Or bAbnormal_Shorter)

        If (bAbnormal_Lengthy) Then strAbnormalWord = "many"
        If (bAbnormal_Shorter) Then strAbnormalWord = "few"

        If (boolAbnormal) Then

            ''Added 4/26/2022 thomas downes 
            MessageBoxTD.Show_InsertWordFormat_Line1(strAbnormalWord,
                "There are unexpectedly {0} characters in this box.",
                "(This is only a warning, not a mandatory fix.)")

        Else
            ''Added 4/26/2022 thomas downes 
            Textbox1a.BackColor = Drawing.Color.White
            LinkLabelOutlier.Visible = False ''The linklabel should NOT appear here.
            MessageBoxTD.Show_Statement("Sorry..." &
                "This message doesn't apply.",
                "(The value has a normal length. The hyperlink is removed.)")

        End If ''End of ""If (boolAbnormal) Then... Else..."

    End Sub

    Private Sub LinkLabelCrLf_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCrLf.LinkClicked
        ''
        ''Added 4/26/2022 thomas downes
        ''
        ''Added 4/26/2022 thomas downes
        MessageBoxTD.Show_Statement("The data cell contains line-break characters." &
                                    "  (CR = Carriage Return, LF = Line Feed)",
                                    "The data cell contains the following: " & vbCrLf_Deux &
                                    Textbox1a.Text)

        Dim strEditedValue As String = ""
        Dim diag_result As DialogResult = DialogResult.None
        Dim boolConfirmWhitespace As Boolean

        diag_result =
        MessageBoxTD.Show_Editor("The data cell contains the following.  " &
                                 "(Edit & click ""OK"" change the cell value.)",
                                  Textbox1a.Text,
                                  1.0, 1.0,
                                  strEditedValue)

        ''
        ''Evaluate the user's actions. 
        ''
        If (diag_result = DialogResult.OK) Then

            If (String.IsNullOrWhiteSpace(strEditedValue)) Then
                ''Double-check w/ the user. 
                boolConfirmWhitespace =
                    MessageBoxTD.Show_Confirmed("Oops!? You have no visible characters.",
                                      "Hit ""Cancel"" to stop & try again.", False)

            Else
                ''Textbox1a.Text = strEditedValue
                boolConfirmWhitespace = True

            End If ''End of ""If (String.IsNullOrWhiteSpace(strEditedValue)) Then""

            ''
            ''Store the edited value in the data cell (if whitespace, then only
            ''  if it's been confirmed).
            ''
            If (boolConfirmWhitespace) Then
                ''Implement the edited value.  
                Textbox1a.Text = strEditedValue
                LinkLabelCrLf.Visible = strEditedValue.Contains(vbCr)

            End If ''ENd of "If (boolConfirmWhitespace) Then"

        End If ''End of ""If (diag_result = DialogResult.OK) Then""



    End Sub

    Private Sub Textbox1a_Click(sender As Object, e As EventArgs) Handles Textbox1a.Click

        ''Added 4/28/2022
        Textbox1a.BorderStyle = BorderStyle.FixedSingle ''Add a border to the current cell.
        Textbox1a.BackColor = Drawing.Color.White ''Added 4/29/2022 
        Me.ParentColumn.ClearBorderStyle_PriorCell(Me)

    End Sub

    Private Sub Textbox1a_GotFocus(sender As Object, e As EventArgs) Handles Textbox1a.GotFocus

        ''Added 5/13/2022 td 
        RaiseEvent GotFocus_Cell(sender, e)

        ''Added 5/13/2022 td 
        Me.ParentColumn.Handle_CellHasFocus(sender, e)

    End Sub
End Class
