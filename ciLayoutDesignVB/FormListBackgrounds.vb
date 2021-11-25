''
''Added 11/25/2021 thomas downes
''
Public Class FormListBackgrounds

    Public ImageFilePath As String
    Public ImageFileInfo As System.IO.FileInfo

    Public TemporarySelectedFileInfo As System.IO.FileInfo

    ''
    ''Added 11/25/2021 thomas downes
    ''
    Public Sub LoadSelection(par_controlBack As CtlBackground)
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Dim boolNotParameter As Boolean

        Me.TemporarySelectedFileInfo = par_controlBack.ImageFileInfo

        For Each ctlBack As CtlBackground In FlowLayoutPanel1.Controls

            boolNotParameter = (ctlBack IsNot par_controlBack)
            If (boolNotParameter) Then ctlBack.LoadIsSelectedValue(False)

        Next ctlBack

    End Sub

    Private Sub FormListBackgrounds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 11/25/2021 thomas downes
        ''
        LoadControlsFromFolderImagesBack()

    End Sub

    Private Sub buttonOK_Click(sender As Object, e As EventArgs) Handles buttonOK.Click
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Me.ImageFileInfo = Me.TemporarySelectedFileInfo
        Me.ImageFilePath = Me.TemporarySelectedFileInfo.FullName
        Me.Close()

    End Sub
End Class