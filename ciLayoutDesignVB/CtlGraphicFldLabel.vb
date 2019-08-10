''
''Added 7/25/2019 thomas d 
''

Public Class CtlGraphicFldLabel
    ''
    ''Added 7/25/2019 thomas d 
    ''
    Public Shared Generator As ClassLabelToImage
    ''7/26/2019 td''Public FieldInfo As ClassFieldCustomized
    ''7/26/2019 td''Public ElementInfo As ClassElementText
    Public FieldInfo As ICIBFieldStandardOrCustom
    Public ElementInfo As ClassElementText
    Public GroupEdits As ISelectingElements ''Added 7/31/2019 thomas downes  
    Public SelectedHighlighting As Boolean ''Added 8/2/2019 td

    Private mod_includedInGroupEdit As Boolean ''Added 8/1/2019 thomas downes 

    Private Const mod_c_boolMustSetBackColor As Boolean = False ''False, since we have an alternate Boolean 
    ''   below which works fine (i.e. mod_c_bRefreshMustReinitializeImage = True).
    ''   We don't need to set the Background Color of the PictureBox control.  ----7/31/2019 thomas d. 

    Private Const mod_c_bRefreshMustResizeImage As Boolean = True ''True, since otherwise the background color 
    ''  is (frustratingly) limited to the original control size, _NOT_ the resized control's full area
    ''  (enlarged via user click-and-drag), unfortunately.  ----7/31/2019 thomas d.  

    Public ReadOnly Property Picture_Box As PictureBox
        Get
            ''Added 7/28/2019 td 
            Return Me.pictureLabel
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New_NotInUse(par_field As ICIBFieldStandardOrCustom)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        Me.ElementInfo = New ClassElementText(Me)

    End Sub

    Public Sub New(par_field As ClassFieldStandard, Optional par_formDesigner As FormDesignProtoTwo = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        Me.ElementInfo = par_field.ElementInfo

        ''Added 8/9/2019 td
        Me.FormDesigner = par_formDesigner

    End Sub

    Public Sub New(par_field As ClassFieldCustomized, Optional par_formDesigner As FormDesignProtoTwo = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        Me.ElementInfo = par_field.ElementInfo

        ''Added 8/9/2019 td
        Me.FormDesigner = par_formDesigner

    End Sub

    Public Sub RefreshImage()
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText(
        ''8/4/2019''If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        ElementInfo.Text = LabelText()

        ''Me.ElementInfo.Width = pictureLabel.Width
        ''Me.ElementInfo.Height = pictureLabel.Height

        ''7/30/2019 td''Me.ElementInfo.Font_AllInfo = Me.ParentForm.Font ''Me.Font
        ''7/30/2019 td''Me.ElementInfo.Font_AllInfo = New Font("Times New Roman", 25, FontStyle.Italic)
        If (Me.ElementInfo.Font_AllInfo Is Nothing) Then _
            Me.ElementInfo.Font_AllInfo = New Font("Times New Roman", 15, FontStyle.Regular)

        ''Me.ElementInfo.BackColor = Me.ParentForm.BackColor
        ''Me.ElementInfo.FontColor = Me.ParentForm.ForeColor

        If (Generator Is Nothing) Then Generator = New ClassLabelToImage

        ''
        ''Added 7/31/2019 thomas 
        ''
        Dim boolReinitializeImage As Boolean ''Added 7/31/2019 thomas
        Const c_bMustReinitializeToResize As Boolean = True ''Added 7/31/2019 thomas
        boolReinitializeImage = (c_bMustReinitializeToResize And mod_c_bRefreshMustResizeImage)

        If (boolReinitializeImage) Then
            ''
            ''Destroy & recreate the .Image member from scratch, to allow for a new size. ----7/31/2019 td
            ''
            pictureLabel.Image = Nothing

            If (pictureLabel.Width > 0 And pictureLabel.Height > 0) Then
                pictureLabel.Image = (New Bitmap(pictureLabel.Width, pictureLabel.Height))
            ElseIf (pictureLabel.Width > 0 And pictureLabel.Height = 0) Then
                ''Don't allow a run-time error to occur, due to a parameter of Height = Zero (0). ----8/3/2019 td
                pictureLabel.Image = (New Bitmap(pictureLabel.Width, 15))
            ElseIf (pictureLabel.Width = 0 And pictureLabel.Height > 0) Then
                ''Don't allow a run-time error to occur, due to a parameter of Width = Zero (0).  ----8/3/2019 td
                pictureLabel.Image = (New Bitmap(15, pictureLabel.Height))
            End If

        End If ''End of "If (boolReinitializeImage) Then"

        ''7/29/2019 td''pictureLabel.Image = Generator.TextImage(Me.ElementInfo, Me.ElementInfo)
        Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        ''Added 7/31/2019 td
        If (mod_c_boolMustSetBackColor And (ElementInfo IsNot Nothing)) Then
            ''
            ''A desperate attempt to get the background color to extend to the full, resized control.
            ''
            Dim boolColorDiscrepancy As Boolean ''Added 7/31/2019 td
            boolColorDiscrepancy = (Me.ElementInfo.BackColor <> Me.ElementInfo.Back_Color)
            If (boolColorDiscrepancy) Then
                MessageBox.Show("Warning, there is a discrepancy in the color information.", "ciLayout",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If ''ENd of "If (boolColorDiscrepancy) Then"

            pictureLabel.BackColor = Me.ElementInfo.Back_Color
            pictureLabel.BackColor = Me.ElementInfo.BackColor

        End If ''End of "If (mod_c_boolMustSetBackColor And (ElementInfo IsNot Nothing)) Then"

        pictureLabel.Refresh()

    End Sub ''End of Public Sub RefreshImage

    Public Sub SaveToModel()
        ''
        ''Added 7/29/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText()

        Me.ElementInfo.TopEdge_Pixels = Me.Top
        Me.ElementInfo.LeftEdge_Pixels = Me.Left

        Me.ElementInfo.Width_Pixels = Me.Width
        Me.ElementInfo.Height_Pixels = Me.Height

        ''Me.ElementInfo.Font_AllInfo = Me.Font
        ''Me.ElementInfo.BackColor = Me.BackColor
        ''Me.ElementInfo.FontColor = Me.ForeColor

    End Sub ''End of Public Sub SaveToModel

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
                Return Me.FieldInfo.FieldLabelCaption

            Case Else

                ''Default value.
                ''7/29 td''Me.ElementInfo.Info.Text = $"Field #{Me.FieldInfo.FieldIndex}"
                Return $"Field #{Me.FieldInfo.FieldIndex}"

        End Select ''End of "Select Case True"

        Return "Field Information"

    End Function ''End of "Public Function LabelText() As String"

    Private Sub RefreshElement_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Me.ElementInfo.Width_Pixels = Me.Width
        Me.ElementInfo.Height_Pixels = Me.Height
        Application.DoEvents()
        Me.RefreshImage()
        Application.DoEvents()
        Me.Refresh()

    End Sub ''End of "Private Sub RefreshElement_Field(sender As Object, e As EventArgs)"

    Private Sub GiveSizeInfo_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim strMessageToUser As String = ""

        strMessageToUser &= (vbCrLf & $"Height of Picture control: {pictureLabel.Height}")
        strMessageToUser &= (vbCrLf & $"Height of Custom Graphics control: {Me.Height}")
        strMessageToUser &= (vbCrLf & $"Element-Info Property (Height): {Me.ElementInfo.Height_Pixels}")
        strMessageToUser &= (vbCrLf & $"Picture control's Image Height: {pictureLabel.Image.Height}")

        MessageBox.Show(strMessageToUser, "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of "Private Sub RefreshElement_Field(sender As Object, e As EventArgs)"

    Private Sub CtlGraphicFldLabel_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ''
        ''Addd 7/31/2019 td
        ''
        If (Me.ElementInfo IsNot Nothing) Then

            Me.ElementInfo.Width_Pixels = Me.Width
            Me.ElementInfo.Height_Pixels = Me.Height
            Me.RefreshImage()

        End If ''End of "If (Me.ElementInfo IsNot Nothing) Then"
    End Sub

    Private Sub pictureLabel_DragOver(sender As Object, e As DragEventArgs) Handles pictureLabel.DragOver

    End Sub
End Class
