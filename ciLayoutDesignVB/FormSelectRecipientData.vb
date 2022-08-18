Public Class FormSelectRecipientData
    ''
    ''Added 8/17/2022 thomas downes
    ''
    Public Output_CopyFile As Boolean
    Public Output_IgnoreFile As Boolean
    Public Output_UseFile As Boolean
    Public Output_UserCancelled As Boolean

    Private mod_strPathToRecipientXML As String = "" ''Added 8/17/2022 thomas d.
    Private mod_strPathToNewLayoutXML As String = "" ''Added 8/17/2022 thomas d.

    Public Sub New(pstrPathToNewLayoutXML As String,
                   pstrPathToRecipientXML As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''
        ''Added 8/17/2022 thomas downes
        ''
        mod_strPathToNewLayoutXML = pstrPathToNewLayoutXML
        mod_strPathToRecipientXML = pstrPathToRecipientXML

    End Sub



    Private Sub buttonIgnore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 8/17/2022 thomas downes
        ''
        txtPathToRecipientFile.Text = mod_strPathToRecipientXML


    End Sub


    Private Sub OpenFolderAndFile(par_strPathToXML As String,
                                  Optional pboolJustFolder As Boolean = False,
                                  Optional pboolJustFile As Boolean = False)
        ''
        ''Added 8/17/2022 thomas downes
        ''         
        Dim file_info As IO.FileInfo
        file_info = New IO.FileInfo(par_strPathToXML)

        If (par_strPathToXML = "") Then
            ''Added 8/17/2022 thomas downes
            MessageBoxTD.Show_StatementLongform("Path is blank",
                                                "Personality Recipients XML path is blank.",
                                                0.7, 0.7)
            Exit Sub
        End If ''End of ""If (strPathToXML = "") Then""

        If (IO.File.Exists(par_strPathToXML)) Then
            ''Create file-info object. 
            file_info = New IO.FileInfo(par_strPathToXML)
            ''
            ''Open file and/or folder. 
            ''
            If (pboolJustFile) Then
                System.Diagnostics.Process.Start(file_info.FullName)
            ElseIf (pboolJustFolder) Then
                System.Diagnostics.Process.Start(file_info.DirectoryName)
            Else
                System.Diagnostics.Process.Start(file_info.DirectoryName)
                System.Diagnostics.Process.Start(file_info.FullName)
            End If ''End of ""If (pboolJustFile) Then...ElseIf... Else..."

        Else
            ''Added 8/17/2022 thomas downes
            MessageBoxTD.Show_StatementLongform("Path is corrupted/invalid",
                                                "Personality Recipients XML path is invalid/incorrect." &
                                                vbCrLf_Deux &
                                                par_strPathToXML,
                                                1.4, 0.8)

        End If ''Endof ""If (IO.File.Exists(strPathToXML)) Then... Else..."

    End Sub ''End of ""Private Sub OpenFolderAndFile(par_strPathToXML As String)""

    Private Sub linkOpenFolderAndFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkOpenFolderAndFile.LinkClicked

        ''Added 8/17/2022  
        OpenFolderAndFile(mod_strPathToRecipientXML)


    End Sub


    Private Sub linkOpenFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkOpenFile.LinkClicked

        ''Added 8/17/2022 td
        OpenFolderAndFile(mod_strPathToRecipientXML, False, True)


    End Sub

    Private Sub linkOpenFolder_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkOpenFolder.LinkClicked

        ''Added 8/17/2022 td
        OpenFolderAndFile(mod_strPathToRecipientXML, True, False)


    End Sub
End Class