''
''Added 4/6/2022 thomas d
''
Public Class RSCRowHeader
    ''
    ''Added 4/6/2022 thomas d
    ''
    Public ParentRSCRowHeaders As RSCRowHeaders
    Public Property RowIndex As Integer ''Added 4/24/2022 td

    Private Sub textRowHeader1_Click(sender As Object, e As EventArgs) Handles textRowHeader1.Click
        ''
        ''Added 4/6/2022 thomas d
        ''



    End Sub

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


        End If ''End of "If (e.Button = MouseButtons.Right) Then .... ElseIf ... Else ...."

    End Sub


End Class
