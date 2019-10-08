''
''Added 10/8/2019 td 
''

Public Class CtlGraphicSignature
    ''
    ''Added 10/8/2019 td 
    ''
    Public Sub OpenSignaturePad()
        ''
        ''Added 10/8/2019 td 
        ''
        ''4/9/2019 td''Dim SigMenu1 As New SigPlus_NET.SigMenu
        ''10/7/2019 td''Dim SigMenu1 As New ciSigPlus_NET40.SigMenu

        Dim SigMenu1 As New ciSigPlus_NET45.SigMenu

        ''If txtPersonality.Text.Length = 0 Then
        ''    txtPersonality.Text = "1"
        ''Else
        ''    SigMenu1.Personality = CInt(txtPersonality.Text)
        ''End If
        SigMenu1.Personality = 1 ''10/8/2019 td ''CInt(txtPersonality.Text)

        ''10/8/2019 td''SigMenu1.SaveFile = txtSaveFile.Text '' C:\CI Solutions\CI Badge\Data\Test.bmp
        SigMenu1.SaveFile = "C:\CI Solutions\CI Badge\Data\Test.bmp"  ''10/8/2019 td''  txtSaveFile.Text '' C:\CI Solutions\CI Badge\Data\Test.bmp
        SigMenu1.SigLineFile = "C:\CI Solutions\CI Badge\sigline.bmp"  ''10/8/2019 td''  "txtSigLineFile.Text  '' C:\CI Solutions\CI Badge\sigline.bmp  
        SigMenu1.PenEventFile = "C:\CI Solutions\CI Badge\Data\Test.sig"   ''10/8/2019 td''  txtPenEventFile.Text ''C:\CI Solutions\CI Badge\Data\Test.sig 

        ''10/8/2019 td''If txtPenWidth.Text.Length = 0 Then
        ''10/8/2019 td''    txtPenWidth.Text = "15"
        ''10/8/2019 td''Else
        SigMenu1.PenWidth = 5 ''10/8/2019 td''CInt(txtPenWidth.Text)
        ''10/8/2019 td''End If ''ENdof "If txtPenWidth.Text.Length = 0 Then .... Else ..."

        SigMenu1.DisplaySigMenu()

    End Sub ''End of "Public Sub OpenSignaturePad()"

End Class
