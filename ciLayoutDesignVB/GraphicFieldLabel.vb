''
''Added 7/25/2019 thomas d 
''

Public Class GraphicFieldLabel
    ''
    ''Added 7/25/2019 thomas d 
    ''
    Public Shared Generator As ClassLabelToImage
    ''7/26/2019 td''Public FieldInfo As ClassFieldCustomized
    ''7/26/2019 td''Public ElementInfo As ClassElementText
    Public FieldInfo As ICIBFieldStandardOrCustom
    Public ElementInfo As ClassElementText

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New(par_field As ICIBFieldStandardOrCustom)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field
        Me.ElementInfo = New ClassElementText(Me)

    End Sub

    Public Sub RefreshImage()
        ''
        ''Added 7/25/2019 thomas d 
        ''
        Me.ElementInfo.Info.Text = LabelText()

        pictureLabel.Image = Generator.TextImage(Me.ElementInfo, Me.ElementInfo)

    End Sub ''End of Public Sub RefreshImage

    Public Function LabelText() As String
        ''
        ''Added 7/25/2019 thomas d 
        ''
        Select Case True

            Case (Me.FieldInfo.ExampleValue <> "")

                ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                Return Me.FieldInfo.ExampleValue

            Case (Me.FieldInfo.FieldLabelCaption <> "")

                ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                Return Me.FieldInfo.ExampleValue

            Case Else

                ''Default value.
                Me.ElementInfo.Info.Text = $"Field #{Me.FieldInfo.FieldIndex}"

        End Select ''End of "Select Case True"

        Return "Field Information"

    End Function ''End of "Public Function LabelText() As String"


End Class
