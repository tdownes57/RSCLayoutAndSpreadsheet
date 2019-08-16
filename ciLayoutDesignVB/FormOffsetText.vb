''
''Added 8/15/2019 thomas downes 
''

Public Class FormOffsetText
    ''
    ''Added 8/15/2019 thomas downes 
    ''
    Public FieldInfo As ICIBFieldStandardOrCustom
    Public ElementInfo As ClassElementText
    Public GroupEdits As ISelectingElements ''Added 8/15/2019 thomas downes  
    Public FormDesigner As FormDesignProtoTwo ''Added 8/15/2019 td  
    Public OriginalElementControl As CtlGraphicFldLabel ''Added 8/15/2019 td  

    Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo,
                                par_originalCtl As CtlGraphicFldLabel)

        Me.FieldInfo = par_field

        Me.ElementInfo = par_field.ElementInfo

        ''Added 8/15/2019 td
        Me.FormDesigner = par_formDesigner
        Me.OriginalElementControl = par_originalCtl

        With CtlGraphicFldLabel1
            .FieldInfo = par_field
            .ElementInfo = par_field.ElementInfo
            .FormDesigner = par_formDesigner
            .RefreshImage()
        End With

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    Private Sub CenterTheFieldControl()
        ''
        ''Position it at the center horizontally. 
        ''8/15/2019 td
        ''
        With CtlGraphicFldLabel1

            .Left = CInt((Me.Width - .Width) / 2)

        End With

    End Sub

    Private Sub FormOffsetText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class