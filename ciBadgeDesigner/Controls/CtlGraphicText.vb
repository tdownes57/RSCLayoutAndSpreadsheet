''
''Added 8/01/2019 thomas d 
''
Imports ciBadgeInterfaces ''Added 9/18/2019 td
''10/1/2019 td''Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeElements ''Added 9/18/2019 td  
Imports System.Windows.Forms ''Added 10/1/2019 thomas d.  
Imports System.Drawing ''Added 10/1/2019 td 

Public Class CtlGraphicText
    ''
    ''Added 8/01/2019 thomas d 
    ''
    ''9/3/2019 td''Public Shared Generator As ClassLabelToImage
    Public Shared LabelToImage As ClassLabelToImage

    ''8/29/2019 td''Public ElementInfo As ClassElementText
    Public ElementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 8/29/2019 td
    ''9/18/2019 td''Public ElementInfo_Text As ciBadgeInterfaces.IElement_TextField ''Added 8/29/2019 td
    Public ElementInfo_TextOnly As ciBadgeInterfaces.IElement_TextOnly ''Added 8/29/2019 td

    Public ParentDesignForm As ISelectingElements ''Added 7/31/2019 thomas downes  

    Private Const mod_c_boolMustSetBackColor As Boolean = False ''False, since we have an alternate Boolean 
    ''   below which works fine (i.e. mod_c_bRefreshMustReinitializeImage = True).
    ''   We don't need to set the Background Color of the PictureBox control.  ----7/31/2019 thomas d. 

    Private Const mod_c_bRefreshMustResizeImage As Boolean = True ''True, since otherwise the background color 
    ''  is (frustratingly) limited to the original control size, _NOT_ the resized control's full area
    ''  (enlarged via user click-and-drag), unfortunately.  ----7/31/2019 thomas d.  

    Private mod_strTextToDisplay As String = "This is text which will be the same for everyone." ''Added 10/10/2019 td 

    Public ReadOnly Property Picture_Box As PictureBox
        Get
            ''Added 7/28/2019 td 
            Return Me.pictureLabel
        End Get
    End Property

    Public Property TextToDisplay As String
        Get
            ''Added 10/10/2019 td 
            Return mod_strTextToDisplay
        End Get
        Set(value As String)
            ''Added 10/10/2019 td 
            mod_strTextToDisplay = value
            Me.ElementInfo_TextOnly.Text = value
            textTypeExample.Text = mod_strTextToDisplay
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New_Deprecated(par_element As ClassElementStaticText)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''_Deprecated 9/18/2019 td''''Me.ElementInfo_Text = par_field.ElementFieldClass
        ''9/18/2019 td''Me.ElementInfo_Text = par_element
        Me.ElementInfo_TextOnly = par_element

    End Sub

    ''Public Sub New_Deprecated(par_field As ClassFieldStandard)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''_Deprecated 9/18/2019 td''''Me.ElementInfo_Text = par_field.ElementFieldClass
    ''
    ''End Sub

    ''Public Sub New_Deprecated(par_field As ClassFieldCustomized)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''_Deprecated 9/18/2019 td''Me.ElementInfo_Text = par_field.ElementFieldClass
    ''
    ''End Sub

    Public Sub RefreshImage()
        ''
        ''Added 7/25/2019 thomas d 
        ''
        If (String.IsNullOrEmpty(Me.ElementInfo_TextOnly.Text)) Then ElementInfo_TextOnly.Text = LabelText()

        If (Me.ElementInfo_TextOnly.Font_DrawingClass Is Nothing) Then
            ''
            ''Initialize the font. 
            ''
            ''9/6/2019 td''Me.ElementInfo_TextOnly.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)
            ''9/6/2019 td''Me.ElementInfo_TextOnly.FontSize_Pixels = 15
            ''9/6/2019 td''Me.ElementInfo_TextOnly.FontBold = False
            ''9/6/2019 td''Me.ElementInfo_TextOnly.FontItalics = False

            With Me.ElementInfo_TextOnly
                ''9/6/2019 td''.FontSize = 15
                .FontSize_Pixels = 25 ''9/6/2019 ''15
                .FontBold = False
                .FontItalics = False
                .FontUnderline = False ''Added 9/6/2019 thomas downes
                .FontFamilyName = "Times New Roman"
                ''9/6/2019 td''.Font_DrawingClass = New Font(.FontFamilyName, .FontSize_Pixels, FontStyle.Regular, GraphicsUnit.Pixel)
                .Font_DrawingClass = modFonts.MakeFont(.FontFamilyName, .FontSize_Pixels, .FontBold, .FontItalics, .FontUnderline)
            End With

        End If ''End of "If (Me.ElementInfo_TextOnly.Font_DrawingClass Is Nothing) Then"

        If (LabelToImage Is Nothing) Then LabelToImage = New ClassLabelToImage

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
        ''8/18/2019 td''Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        Dim boolRotated As Boolean ''Added 8/18/2019 td
        ''9/3/2019 td''LabelToImage.TextImage(pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        Dim intLayoutWidth As Integer ''Added 9/3/2019 thomas d.
        ''10/1/2019 td''intLayoutWidth = Me.FormDesigner.Layout_Width_Pixels()
        intLayoutWidth = Me.LayoutFunctions.Layout_Width_Pixels()

        ''9/4/2019 td''LabelToImage.TextImage(intLayoutWidth, pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        pictureLabel.Image =
        LabelToImage.TextImage_Field(intLayoutWidth, Me.ElementInfo_TextOnly,
                               Me.ElementInfo_Base, boolRotated, True)

        ''Added 7/31/2019 td
        If (mod_c_boolMustSetBackColor And (Me.ElementInfo_Base IsNot Nothing)) Then
            ''
            ''A desperate attempt to get the background color to extend to the full, resized control.
            ''
            Dim boolColorDiscrepancy As Boolean = False ''Added 7/31/2019 td

            ''8/29/2019 td''boolColorDiscrepancy = (Me.ElementInfo.BackColor <> Me.ElementInfo.Back_Color)
            If (boolColorDiscrepancy) Then
                MessageBox.Show("Warning, there is a discrepancy in the color information.", "ciLayout",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If ''ENd of "If (boolColorDiscrepancy) Then"

            ''8/29/2019 td''pictureLabel.BackColor = Me.ElementInfo.Back_Color
            pictureLabel.BackColor = Me.ElementInfo_Base.Back_Color

        End If ''End of "If (mod_c_boolMustSetBackColor And (ElementInfo IsNot Nothing)) Then"

        pictureLabel.Refresh()

    End Sub ''End of Public Sub RefreshImage

    Public Sub SaveToModel()
        ''
        ''Added 8/01/2019 thomas d 
        ''
        Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

        ''ADded 9/4/2019 td
        ''
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

    End Sub ''End of Public Sub SaveToModel

    Public Function LabelText() As String
        ''
        ''Added 7/25/2019 thomas d 
        ''
        Return Me.ElementInfo_TextOnly.Text

    End Function ''End of "Public Function LabelText() As String"

    Private Sub RefreshElement_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

        ''Added 9/4/2019 td
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

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
        strMessageToUser &= (vbCrLf & $"Element-Base-Info Property (Height): {Me.ElementInfo_Base.Height_Pixels}")
        strMessageToUser &= (vbCrLf & $"Picture control's Image Height: {pictureLabel.Image.Height}")

        MessageBox.Show(strMessageToUser, "994938", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of "Private Sub RefreshElement_Field(sender As Object, e As EventArgs)"

    Private Sub OpenDialog_Color(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ColorDialog1.ShowDialog()

        ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
        ''8/29/2019 td''Me.ElementInfo.BackColor = ColorDialog1.Color
        Me.ElementInfo_Base.Back_Color = ColorDialog1.Color

        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

        Application.DoEvents()
        Application.DoEvents()

        RefreshImage()
        Me.Refresh()

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub OpenDialog_Font(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        FontDialog1.Font = Me.ElementInfo_TextOnly.Font_DrawingClass
        FontDialog1.ShowDialog()

        Me.ElementInfo_TextOnly.Font_DrawingClass = FontDialog1.Font

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

        ''8/1/2019 td''Dim new_item_fieldname As ToolStripMenuItem
        ''8/1/2019 td''Dim new_item_field As ToolStripMenuItem

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

                new_item_refresh = New ToolStripMenuItem("Refresh Element") ''Added 7/31/2019 td
                new_item_sizeInfo = New ToolStripMenuItem("Size Information") ''Added 7/31/2019 td

                new_item_colors = New ToolStripMenuItem("Set Colors")
                new_item_font = New ToolStripMenuItem("Set Font")

                AddHandler new_item_colors.Click, AddressOf OpenDialog_Color
                AddHandler new_item_font.Click, AddressOf OpenDialog_Font

                AddHandler new_item_refresh.Click, AddressOf RefreshElement_Field ''Added 7/31/2019 thomas d.
                AddHandler new_item_sizeInfo.Click, AddressOf GiveSizeInfo_Field ''Added 7/31/2019 thomas d.

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
            Me.BackColor = Color.Yellow
            pictureLabel.Top = 6
            pictureLabel.Left = 6
            pictureLabel.Width = Me.Width - 2 * 6
            pictureLabel.Height = Me.Height - 2 * 6

        End If ''End of "If (boolRightClick) Then .... Else ...."

    End Sub

    Private Sub CtlGraphicFldLabel_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ''
        ''Addd 7/31/2019 td
        ''
        If (Me.ElementInfo_Base IsNot Nothing) Then

            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height

            ''Added 9/4/2019 td
            ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
            ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
            ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

            Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
            Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

            Me.RefreshImage()

        End If ''End of "If (Me.ElementInfo_Base IsNot Nothing) Then"
    End Sub

    Private Sub PictureLabel_Click(sender As Object, e As EventArgs) Handles pictureLabel.Click




    End Sub
End Class
