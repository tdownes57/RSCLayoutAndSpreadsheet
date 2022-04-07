''
''Added 4/6/2022 thomas d
''
Public Class RSCRowHeader
    ''
    ''Added 4/6/2022 thomas d
    ''
    Public ParentRSCRowHeaders As RSCRowHeaders

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


    Private Sub textRowHeader1_MouseUp(sender As Object, e As MouseEventArgs) Handles textRowHeader1.MouseUp

        ''Added 4/6/2022 thomas d.
        If (e.Button = MouseButtons.Right) Then
            ParentRSCRowHeaders.HeaderBox_MouseUp(Me, e)
        Else
            MessageBoxTD.Show_Statement("The height of this control is: " + Me.Height.ToString,
                                        "The width of this control is: " + Me.Width.ToString)
            Me.Height = (ParentRSCRowHeaders.PixelsFromRowToRow - 1)
        End If ''End of "If (e.Button = MouseButtons.Right) Then .... Else ...."

    End Sub


End Class
