''
''Added 4/6/2022 thomas d
''
Public Class RSCRowHeader
    ''
    ''Added 4/6/2022 thomas d
    ''
    Public ParentRSCRowHeaders As RSCRowHeaders
    Public Property RowIndex As Integer ''Added 4/24/2022 td

    Public Recipient As ciBadgeRecipients.ClassRecipient ''Added 4/12/2022 td

    ''Added 4/29/2022 td
    ''5/1/2022 Private mod_intEmphasisRowIndex_Start As Integer = -1 ''= par_intRowIndex_Start
    ''5/1/2022 Private mod_intEmphasisRowIndex_End As Integer = -1 ''= par_intRowIndex_End

    ''Private Sub textRowHeader1_Click(sender As Object, e As EventArgs) Handles textRowHeader1.Click
    ''    ''
    ''    ''Added 4/6/2022 thomas d
    ''    ''
    ''End Sub

    Public Overrides Property Text() As String
        Get
            ''Added 4/6/2022 td
            Return textRowHeader1.Text
        End Get
        Set(value As String)
            ''Added 4/6/2022 td
            textRowHeader1.Text = value
        End Set
    End Property

    Public Property Text_RowNumber() As String
        Get
            ''Added 4/6/2022 td
            Return textRowHeader1.Text
        End Get
        Set(value As String)
            ''Added 4/6/2022 td
            textRowHeader1.Text = value
        End Set
    End Property


    Public Overrides Property BackColor() As Drawing.Color
        Get
            ''Added 4/29/2022 td
            Return textRowHeader1.BackColor
        End Get

        Set(value As Drawing.Color)
            ''Added 4/29/2022 td
            textRowHeader1.BackColor = value
            MyBase.BackColor = value
        End Set
    End Property


    Public Sub ShowRecipientsIDCard()
        ''
        ''Added 5/14/2022 thomas downes
        ''




    End Sub ''End of ""Public Sub ShowRecipientsIDCard()""


    Public Sub FocusRelated_EmphasizeRow()
        ''
        ''Added 5/13/2022 td 
        ''
        With Me.ParentRSCRowHeaders
            ''Added 5/13/2022 td 
            .EmphasisRowIndex_Start = Me.RowIndex
            .EmphasisRowIndex_End = -1

            ''Let the user know (via color-coding) that the emphasis has taken place.
            .EmphasizeRows_Highlight(False,
                    .EmphasisRowIndex_Start,
                    .EmphasisRowIndex_End)

            ''Added 5/13/2022
            ''  The DataCell with the blinking TextCaret should change from
            ''  the cell in the previously-focused row to the cell in the 
            ''  currently-focused row. ----5/13/2022 td
            ''
            With .ParentRSCSpreadsheet
                .MoveTextCaret_IfNeeded(Me.RowIndex)
            End With

        End With ''End of ""With Me.ParentRSCRowHeaders""

    End Sub ''eND OF ""Public Sub FocusRelated_EmphasizeRow()""


    Public Function FocusRelated_RowHasEmphasis() As Boolean
        ''
        ''Added 5/13/2022 td 
        ''
        Dim boolOkayStart As Boolean
        Dim boolOkayEnd As Boolean

        With Me.ParentRSCRowHeaders
            ''Added 5/13/2022 td 
            boolOkayStart = (.EmphasisRowIndex_Start = Me.RowIndex)
            boolOkayEnd = (-1 = .EmphasisRowIndex_End)

        End With ''End of ""With Me.ParentRSCRowHeaders""

        Return (boolOkayStart And boolOkayEnd)

    End Function ''eND OF ""Public Sub FocusRelated_RowHasEmphasis()""


    Private Sub textRowHeader1_MouseUp(sender As Object, e As MouseEventArgs) _
        Handles textRowHeader1.MouseUp

        ''Added 4/12/2022 td 
        Const c_bGiveHeightMsg As Boolean = False
        Dim boolUsingShiftKey As Boolean ''And 4/29/2022 thomas

        ''Added 4/6/2022 thomas d.
        If (e.Button = MouseButtons.Right) Then
            ''Added 4/6/2022 thomas d.
            ''4/25/2022 td''ParentRSCRowHeaders.HeaderBox_MouseUp(Me, e)

            ''Added 4/25/2022 td
            If (Me.RowIndex <= 0) Then
                Me.RowIndex = Me.ParentRSCRowHeaders.GetRowIndex_OfHeader(Me)
            End If ''End If (Me.RowIndex <= 0) Then

            ''Added 4/25/2022 td
            ParentRSCRowHeaders.HeaderBox_MouseUp(Me, e, Me.RowIndex)

        ElseIf (c_bGiveHeightMsg) Then
            ''
            ''Added 4/6/2022 td
            ''
            MessageBoxTD.Show_Statement("The height of this control is: " + Me.Height.ToString,
                                        "The width of this control is: " + Me.Width.ToString)
            Me.Height = (ParentRSCRowHeaders.PixelsFromRowToRow - 1)

        Else
            ''
            ''Added 4/28/2022 thomas d.
            ''
            If (Me.RowIndex <= 0) Then System.Diagnostics.Debugger.Break()

            ''
            ''Keep track of the range of emphasized rows.
            ''
            With Me.ParentRSCRowHeaders

                ''Major call!!
                ''May 2 2022 ''.EmphasizeRows_Highlight(Me.RowIndex)

                ''Added 4/29/2022 thomas d.
                If (My.Computer.Keyboard.ShiftKeyDown) Then
                    ''
                    ''Determine the range of selected rows.
                    ''
                    If (0 < .EmphasisRowIndex_Start) Then
                        If (Me.RowIndex >= .EmphasisRowIndex_Start) Then
                            .EmphasisRowIndex_End = Me.RowIndex

                        ElseIf (Me.RowIndex < .EmphasisRowIndex_Start) Then
                            .EmphasisRowIndex_End = .EmphasisRowIndex_Start
                            .EmphasisRowIndex_Start = Me.RowIndex
                        End If

                    Else
                        .EmphasisRowIndex_Start = Me.RowIndex
                        .EmphasisRowIndex_End = -1

                    End If ''end of ""If (0 < mod_intEmphasisRowIndex_Start) Then... Else...""

                    ''Added 5/1/2022 thomas downes
                    ''5/1/2022 .EmphasizeRows_Highlight(Me.RowIndex, .EmphasisRowIndex_End)
                    .EmphasizeRows_Highlight(boolUsingShiftKey,
                                             .EmphasisRowIndex_Start,
                                             .EmphasisRowIndex_End)

                Else
                    .EmphasisRowIndex_Start = Me.RowIndex
                    .EmphasisRowIndex_End = -1
                    .EmphasizeRows_Highlight(boolUsingShiftKey,
                                             .EmphasisRowIndex_Start,
                                             .EmphasisRowIndex_End)

                End If ''End of ""If (My.Computer.Keyboard.ShiftKeyDown) Then ... Else...""

            End With ''End of ""With Me.ParentRSCRowHeaders""

        End If ''End of "If (e.Button = MouseButtons.Right) Then .... ElseIf ... Else ...."

    End Sub

    Private Sub LinkLabelShowID_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelShowID.LinkClicked

        ''Added 5/14/2022
        ShowRecipientsIDCard()

    End Sub


End Class
