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

    Public Sub New(par_field As ClassFieldStandard)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        Me.ElementInfo = par_field.ElementInfo

    End Sub

    Public Sub New(par_field As ClassFieldCustomized)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        Me.ElementInfo = par_field.ElementInfo

    End Sub

    Public Sub RefreshImage()
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText(
        If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

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
            ''Destroy & recreate the .Image member from scratch, to allow for a new size. ----7/31/2019 td
            pictureLabel.Image = Nothing
            pictureLabel.Image = (New Bitmap(pictureLabel.Width, pictureLabel.Height))
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

    Private Sub OpenDialog_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ''7/30/2019 td''ColorDialog1.ShowDialog()
        Dim form_ToShow As New FormCustomFieldsFlow

        ''Can (should) we just show a single field? ''form_ToShow.JustOneField = Me.FieldInfo
        form_ToShow.JustOneField_Index = Me.FieldInfo.FieldIndex

        form_ToShow.Show()

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub OpenDialog_Color(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ColorDialog1.ShowDialog()

        ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
        Me.ElementInfo.BackColor = ColorDialog1.Color
        Me.ElementInfo.Back_Color = ColorDialog1.Color

        Me.ElementInfo.Width_Pixels = Me.Width
        Me.ElementInfo.Height_Pixels = Me.Height

        Application.DoEvents()
        Application.DoEvents()

        RefreshImage()
        Me.Refresh()

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub OpenDialog_Font(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        FontDialog1.Font = Me.ElementInfo.Font_AllInfo ''Added 7/31/2019 td  

        FontDialog1.ShowDialog()

        Me.ElementInfo.Font_AllInfo = FontDialog1.Font

        Application.DoEvents()
        Application.DoEvents()

        RefreshImage()
        Me.Refresh()

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub PictureLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureLabel.MouseClick
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolRightClick As Boolean
        Dim boolHoldingCtrlKey As Boolean ''Added 7/31/2019 thomas downes  

        Dim new_item_fieldname As ToolStripMenuItem
        Dim new_item_field As ToolStripMenuItem
        Dim new_item_colors As ToolStripMenuItem
        Dim new_item_font As ToolStripMenuItem
        Dim new_item_refresh As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_sizeInfo As ToolStripMenuItem ''Added 7/31/2019 td

        boolRightClick = (e.Button = MouseButtons.Right)

        ''I need to be able to determine if the SHIFT or CTRL keys were pressed when the application is launched
        ''     https://stackoverflow.com/questions/22476342/how-to-determine-if-the-shift-or-ctrl-key-was-pressed-when-launching-the-applica
        ''
        boolHoldingCtrlKey = (My.Computer.Keyboard.CtrlKeyDown) ''Added 7/31/2019 td

        ''Added 7/30/2019 thomas downes
        If (boolRightClick) Then

            ''Added 7/30/2019 thomas downes
            ''ContextMenuStrip1.Items.Clear()

            If (0 = ContextMenuStrip1.Items.Count) Then

                new_item_fieldname = New ToolStripMenuItem("Field " & Me.FieldInfo.FieldLabelCaption)
                new_item_refresh = New ToolStripMenuItem("Refresh Element") ''Added 7/31/2019 td
                new_item_sizeInfo = New ToolStripMenuItem("Size Information") ''Added 7/31/2019 td
                new_item_field = New ToolStripMenuItem("Browse Field")

                new_item_colors = New ToolStripMenuItem("Set Colors")
                new_item_font = New ToolStripMenuItem("Set Font")

                AddHandler new_item_field.Click, AddressOf OpenDialog_Field
                AddHandler new_item_colors.Click, AddressOf OpenDialog_Color
                AddHandler new_item_font.Click, AddressOf OpenDialog_Font

                AddHandler new_item_refresh.Click, AddressOf RefreshElement_Field ''Added 7/31/2019 thomas d.
                AddHandler new_item_sizeInfo.Click, AddressOf GiveSizeInfo_Field ''Added 7/31/2019 thomas d.

                ContextMenuStrip1.Items.Add(new_item_fieldname)
                ContextMenuStrip1.Items.Add(new_item_field)

                ContextMenuStrip1.Items.Add(new_item_colors)
                ContextMenuStrip1.Items.Add(new_item_font)

                ContextMenuStrip1.Items.Add(new_item_refresh) ''Added 7/31/2019 thomas d.  
                ContextMenuStrip1.Items.Add(new_item_sizeInfo) ''Added 7/31/2019 thomas d.  

            End If ''End of "If (0 = ContextMenuStrip1.Items.Count) Then"

            ContextMenuStrip1.Show(e.Location.X + Me.ParentForm.Left,
                                   e.Location.Y + Me.Top + Me.ParentForm.Top)


        ElseIf (boolHoldingCtrlKey) Then ''Added 7/31/2019 thomas downes
            ''
            ''Added 7/31/2019 thomas downes  
            ''
            ''pictureLabel.BorderStyle = BorderStyle.FixedSingle
            ''
            ''Place a 6-pixel margin around the control, with a yellow color.
            ''   (This will indicate selection.)   ----7/3/2019
            ''
            Dim boolNotIncludedYet As Boolean = (Not mod_includedInGroupEdit) ''Added 8/1/2019
            Dim boolIncludedAlready As Boolean = (mod_includedInGroupEdit)

            If (boolNotIncludedYet) Then

                mod_includedInGroupEdit = True

                Me.GroupEdits.LabelsDesignList_Add(Me) ''Added 8/1/2019 td

                Me.BackColor = Color.Yellow
                pictureLabel.Top = 6
                pictureLabel.Left = 6
                pictureLabel.Width = Me.Width - 2 * 6
                pictureLabel.Height = Me.Height - 2 * 6

            ElseIf (boolIncludedAlready) Then
                ''
                ''Undo the selection. 
                ''
                mod_includedInGroupEdit = False

                Me.GroupEdits.LabelsDesignList_Remove(Me) ''Added 8/1/2019 td

                Me.BackColor = Me.ElementInfo.BackColor
                pictureLabel.Top = 0
                pictureLabel.Left = 0
                pictureLabel.Width = Me.Width ''- 2 * 6
                pictureLabel.Height = Me.Height ''- 2 * 6

            End If ''Endo f ""If (....) Then .... ElseIf (....) Then....

        End If ''End of "If (boolRightClick) Then .... Else ...."

    End Sub

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
