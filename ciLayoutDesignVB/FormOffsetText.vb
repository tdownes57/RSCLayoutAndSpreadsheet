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
    Public FormDesigner As FormDesignProtoTwo ''Added 8/9/2019 td  

    Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)

        Me.FieldInfo = par_field

        Me.ElementInfo = par_field.ElementInfo

        ''Added 8/9/2019 td
        Me.FormDesigner = par_formDesigner

        With CtlGraphicFldLabel1
            .FieldInfo = par_field
            .ElementInfo = par_field.ElementInfo
            .FormDesigner = par_formDesigner
            .RefreshImage()
        End With

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    Private Sub FormOffsetText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class