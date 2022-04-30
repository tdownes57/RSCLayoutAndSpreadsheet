''
''Added 4/6/2022 thomas d
''
Public Class RSCRowHeader
    ''
    ''Added 4/6/2022 thomas d
    ''
    Public ParentRSCRowHeaders As RSCRowHeaders
    Public Property RowIndex As Integer ''Added 4/24/2022 td

    ''Added 4/29/2022 td
    Private mod_intEmphasisRowIndex_Start As Integer = -1 ''= par_intRowIndex_Start
    Private mod_intEmphasisRowIndex_End As Integer = -1 ''= par_intRowIndex_End

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


    Private Sub textRowHeader1_MouseUp(sender As Object, e As MouseEventArgs) Handles textRowHeader1.MouseUp

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

            ''Major call!!
            Me.ParentRSCRowHeaders.EmphasizeRows_Highlight(Me.RowIndex)

            ''Added 4/29/2022 thomas d.
            If (My.Computer.Keyboard.ShiftKeyDown) Then
                ''
                ''Determine the range of selected rows.
                ''
                If (0 < mod_intEmphasisRowIndex_Start) Then
                    If (Me.RowIndex >= mod_intEmphasisRowIndex_Start) Then
                        mod_intEmphasisRowIndex_End = Me.RowIndex
                    ElseIf (Me.RowIndex < mod_intEmphasisRowIndex_Start) Then
                        mod_intEmphasisRowIndex_End = mod_intEmphasisRowIndex_Start
                        mod_intEmphasisRowIndex_Start = Me.RowIndex
                    End If
                Else
                    mod_intEmphasisRowIndex_Start = Me.RowIndex
                    mod_intEmphasisRowIndex_End = -1
                End If ''end of ""If (0 < mod_intEmphasisRowIndex_Start) Then... Else...""

            Else
                mod_intEmphasisRowIndex_Start = Me.RowIndex
                mod_intEmphasisRowIndex_End = -1
            End If ''End of ""If (My.Computer.Keyboard.ShiftKeyDown) Then ... Else...""


        End If ''End of "If (e.Button = MouseButtons.Right) Then .... ElseIf ... Else ...."

    End Sub


End Class
