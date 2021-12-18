''
''Added 8/01/2019 thomas d 
''
Imports ciBadgeInterfaces ''Added 9/18/2019 td
''10/1/2019 td''Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeElements ''Added 9/18/2019 td  
Imports System.Windows.Forms ''Added 10/1/2019 thomas d.  
Imports System.Drawing ''Added 10/1/2019 td 
Imports ciBadgeElemImage ''Added 10/12/2019 td

Public Class CtlGraphicStaticText
    Implements ISaveToModel ''Added 12/17/2021 td 
    Implements IMoveableElement ''Added 12/17/2021 td
    ''
    ''Added 8/01/2019 thomas d 
    ''
    ''9/3/2019 td''Public Shared Generator As ClassLabelToImage
    Public Shared LabelToImage As ClassLabelToImage

    ''8/29/2019 td''Public ElementInfo As ClassElementText
    Public Element_StaticText As New ClassElementStaticText ''Added 10/11/2019 td
    Public ElementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 8/29/2019 td
    ''9/18/2019 td''Public ElementInfo_Text As ciBadgeInterfaces.IElement_TextField ''Added 8/29/2019 td
    Public ElementInfo_TextOnly As ciBadgeInterfaces.IElement_TextOnly ''Added 8/29/2019 td

    Public ParentDesignForm As ISelectingElements ''Added 7/31/2019 thomas downes  

    Public Event ElementStatic_RightClicked(par_control As CtlGraphicStaticText) ''Added 12/15/2021 td

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

            If (Me.ElementInfo_TextOnly Is Nothing) Then Me.ElementInfo_TextOnly = Me.Element_StaticText
            Me.ElementInfo_TextOnly.Text_Static = value

            textTypeExample.Text = mod_strTextToDisplay
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 10/11/2019 thomas downes
        ''
        Me.Element_StaticText = New ClassElementStaticText
        Me.ElementInfo_Base = CType(Me.Element_StaticText, IElement_Base)
        Me.ElementInfo_TextOnly = CType(Me.Element_StaticText, IElement_TextOnly)

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


    Public Sub Refresh_Image(pbRefreshSize As Boolean,
                             Optional pboolResizeLabelControl As Boolean = True,
                             Optional pboolRefreshLabelControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional par_intBadgeLayoutWidth As Integer = 681)
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText(
        ''8/4/2019''If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        Dim boolScaleFontSize As Boolean ''Added 9/15/2019 thomas d. 

        ''Added 10/12/2019 td
        If (Me.ElementInfo_TextOnly Is Nothing) Then Me.ElementInfo_TextOnly = Me.Element_StaticText

        ElementInfo_TextOnly.Text_Static = LabelText()

        ''Me.ElementInfo.Width = pictureLabel.Width
        ''Me.ElementInfo.Height = pictureLabel.Height

        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = Me.ParentForm.Font ''Me.Font
        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 25, FontStyle.Italic)

        boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_ScaleToElementYesNo)
        If (boolScaleFontSize And Me.Element_StaticText Is Nothing) Then
            ''Added 9/19/2019 td 
            MessageBox.Show("Where is the Element-Field Class???   We will need it to scale the Font.", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If ''End of "If (boolScaleFontSize) Then"

        If (Me.ElementInfo_TextOnly.Font_DrawingClass Is Nothing) Then
            ''
            ''Initialize the font. 
            ''
            ''9/6/2019 tdMe.ElementInfo_Text.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)

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

        End If ''end of " If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then"

        ''Me.ElementInfo.BackColor = Me.ParentForm.BackColor
        ''Me.ElementInfo.FontColor = Me.ParentForm.ForeColor

        ''Added 8/18/2019 thomas downes 
        If (pbRefreshSize) Then
            ''
            ''Adjust the size of the label graphic. 
            ''
            pictureLabel.Width = Me.ElementInfo_Base.Width_Pixels
            pictureLabel.Height = Me.ElementInfo_Base.Height_Pixels

            ''Added 9/15/2019 thomas d.
            boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_ScaleToElementYesNo)
            If (boolScaleFontSize) Then
                ''Added 9/15/2019 thomas d.
                Me.Element_StaticText.Font_ScaleAdjustment(Me.ElementInfo_Base.Height_Pixels)
            End If ''End of "If (boolScaleFontSize) Then"

        End If ''end if "If (pbRefreshSize) then"

        If (LabelToImage Is Nothing) Then LabelToImage = New ClassLabelToImage

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
        ''8/18/2019 td''Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        Dim boolRotated As Boolean ''Added 8/18/2019 td

        ''Added 8/18/2019 td
        ''9/3/2019 td''LabelToImage.TextImage(pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        Dim intBadgeLayoutWidth As Integer ''Added 9/3/2019 thomas d.

        ''9/19/2019 td''intLayoutWidth = Me.FormDesigner.Layout_Width_Pixels()
        If (Me.LayoutFunctions IsNot Nothing) Then
            intBadgeLayoutWidth = Me.LayoutFunctions.Layout_Width_Pixels()
        Else
            ''Added 11/24/2021 td
            intBadgeLayoutWidth = par_intBadgeLayoutWidth
        End If

        ''9/4/2019 td''LabelToImage.TextImage(intLayoutWidth, pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        ''
        ''Major call !!
        ''
        Dim newTextImage As Image ''Added 9/20/2019 td  

        ''Added 11/24/2021 thomas d. 
        If (0 = Me.ElementInfo_Base.BadgeLayout.Width_Pixels) Then
            ''Added 11/24/2021 thomas d. 
            Me.ElementInfo_Base.BadgeLayout.Width_Pixels = 681
            Me.ElementInfo_Base.BadgeLayout.Height_Pixels = 425
        End If ''End of "If (0 = Me.ElementInfo_Base.BadgeLayout.Width_Pixels) Then"

        Const c_boolUseNewestProjectReference As Boolean = True ''False ''True ''False ''True ''Added 9/20/2019 td 
        If (c_boolUseNewestProjectReference) Then

            newTextImage =
            modGenerate.TextImage_ByElemInfo(Me.Element_StaticText.Text_Static,
                                             intBadgeLayoutWidth,
                                   Me.ElementInfo_TextOnly,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)
        Else
            ''9/20/2019 td''pictureLabel.Image =
            newTextImage =
            LabelToImage.TextImage_Field(intBadgeLayoutWidth,
                                    Me.ElementInfo_TextOnly,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)
        End If ''End of "If (c_boolUseNewestProjectReference) Then ..... Else ...."

        ''Added 9/20/2019 td
        pictureLabel.Image = newTextImage

        ''Added 9/23/2019 td
        Application.DoEvents() ''Give the PictureBox control time to make any adjustments it might want to do. 

ExitHandler:
        If (pboolResizeLabelControl) Then ''Added9/23/2019 td 

            ''Added 8/18/2019 td
            Dim intNewImageWidth As Integer ''Added 8/18/2019 td
            Dim intNewImageHeight As Integer ''Added 9/20/2019 td

            ''9/20/2019 td''intNewImageWidth = pictureLabel.Image.Width
            intNewImageWidth = newTextImage.Width ''Added 9/20/2019 td
            intNewImageHeight = newTextImage.Height ''Added 9/20/2019 td

            If (boolRotated) Then ''Added 8/18/2019 td
                ''
                ''Rotated Images ---  Any special programming needed? 
                ''
                ''Adjust the controls to the image size.
                ''   Is there any special programming for rotated images?   Probably not! ---9/3/2019 td 
                ''
                ''9/20/2019 td''pictureLabel.Width = pictureLabel.Image.Width
                ''9/20/2019 td''pictureLabel.Height = pictureLabel.Image.Height
                pictureLabel.Width = intNewImageWidth ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td
                Application.DoEvents()
                pictureLabel.Height = intNewImageHeight ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td 
                Application.DoEvents()
                pictureLabel.Invalidate() ''Forces it to be repainted.  

                Me.Height = pictureLabel.Height
                Application.DoEvents()
                Me.Width = pictureLabel.Width
            Else
                ''
                ''Adjust the controls to the image size. ---9/3/2019 td 
                ''
                ''9/20/2019 td''pictureLabel.Width = pictureLabel.Image.Width
                ''9/20/2019 td''pictureLabel.Height = pictureLabel.Image.Height
                pictureLabel.Width = intNewImageWidth
                Application.DoEvents()
                pictureLabel.Height = intNewImageHeight
                Application.DoEvents()
                Me.Height = pictureLabel.Height
                Application.DoEvents()
                Me.Width = pictureLabel.Width

            End If ''End if "If (boolRotated) Then .... Else ...."

        End If ''End of "If (par_boolResizeLabelControl) Then ..... Else ...."

        ''Added 7/31/2019 td
        If (mod_c_boolMustSetBackColor And (ElementInfo_TextOnly IsNot Nothing)) Then
            ''
            ''A desperate attempt to get the background color to extend to the full, resized control.
            ''
            Dim boolColorDiscrepancy As Boolean = False ''Added 7/31/2019 td
            ''8/29 td''boolColorDiscrepancy = (Me.ElementInfo_Text.BackColor <> Me.ElementInfo_Text.Back_Color)

            If (boolColorDiscrepancy) Then
                MessageBox.Show("Warning, there is a discrepancy in the color information.", "ciLayout",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If ''ENd of "If (boolColorDiscrepancy) Then"

            pictureLabel.BackColor = Me.ElementInfo_Base.Back_Color
            ''8/29/2019 td''pictureLabel.BackColor = Me.ElementInfo_Text.BackColor
            pictureLabel.BackColor = Me.ElementInfo_Base.Back_Color

        End If ''End of "If (mod_c_boolMustSetBackColor And (ElementInfo IsNot Nothing)) Then"

        If (pboolRefreshLabelControl) Then
            ''8/19/2019 td''pictureLabel.Refresh()
            pictureLabel.Invalidate() ''Forces it to be re-painted. ---9/21/2019 td 
            pictureLabel.Refresh()
        End If ''End of "If (par_boolRefreshLabelControl) Then"

        If (pboolRefreshUserControl) Then
            Me.Refresh()
        End If ''ENd of "If (par_boolRefreshUserControl) Then"

    End Sub ''End of Public Sub Refresh_Image


    Public Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''
        ''Added 8/01/2019 thomas d 
        ''
        ''Dec17 2021''Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
        ''Dec17 2021''Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

        ''Added 12/17/2021 td 
        Dim strLeftEdge_WasBefore As String = ""
        strLeftEdge_WasBefore = Me.ElementInfo_Base.LeftEdge_Pixels.ToString

        Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

        Dim strLeftEdge_IsNow As String = ""
        strLeftEdge_IsNow = Me.ElementInfo_Base.LeftEdge_Pixels.ToString

        ''Added 12/17/2021 td
        MessageBox.Show(String.Format("The left edge was {0}, is now {1}.",
                                      strLeftEdge_WasBefore, strLeftEdge_IsNow))

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
        Return Me.ElementInfo_TextOnly.Text_Static

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
        Me.Refresh_Image(True)
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

    End Sub ''End of "Private Sub GiveSizeInfo_Field(sender As Object, e As EventArgs)"

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

        Refresh_Image(True)
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

        Refresh_Image(True)
        Me.Refresh()

    End Sub ''eNd of "Private Sub opendialog_Color()"


    Private Sub SaveInfo_ToModel(sender As Object, e As EventArgs)
        ''
        ''Added 12/17/2019 thomas downes
        ''
        SaveToModel()

    End Sub ''eNd of "Private Sub Save_ToModel()"


    Private Sub PictureLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureLabel.MouseClick
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolRightClick As Boolean
        Dim boolHoldingCtrlKey As Boolean ''Added 7/31/2019 thomas downes  

        ''8/1/2019 td''Dim new_item_fieldname As ToolStripMenuItem
        ''8/1/2019 td''Dim new_item_field As ToolStripMenuItem

        Dim new_item_menuHeader1 As ToolStripMenuItem ''Added 12/15/2021 td
        Dim new_item_menuHeader2 As ToolStripMenuItem ''Added 12/15/2021 td
        Dim new_item_menuHeader3 As ToolStripMenuItem ''Added 12/15/2021 td
        Dim new_item_separator As ToolStripMenuItem ''Added 12/15/2021 td

        Dim new_item_colors As ToolStripMenuItem
        Dim new_item_font As ToolStripMenuItem
        Dim new_item_refresh As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_sizeInfo As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_saveToModel As ToolStripMenuItem ''Added 12/17/2021 td

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
                ''
                ''Information about programmatical context. 
                ''
                new_item_menuHeader1 = New ToolStripMenuItem("CtlGraphicStaticText.vb")
                new_item_menuHeader2 = New ToolStripMenuItem("  (in ciBadgeDesigner\Controls\ )")
                new_item_menuHeader3 = New ToolStripMenuItem("  (Private Sub pictureLabel_MouseClick)")
                new_item_separator = New ToolStripMenuItem("-----------")

                new_item_menuHeader1.BackColor = Color.Aqua
                new_item_menuHeader2.BackColor = Color.Aqua
                new_item_menuHeader3.BackColor = Color.Aqua
                new_item_separator.BackColor = Color.Aqua

                new_item_refresh = New ToolStripMenuItem("Refresh Element - EST100") ''Added 7/31/2019 td
                new_item_sizeInfo = New ToolStripMenuItem("Size Information - EST101") ''Added 7/31/2019 td
                new_item_saveToModel = New ToolStripMenuItem("Save Position To Model - EST102") ''Added 12/13/2021 td

                new_item_colors = New ToolStripMenuItem("Set Colors - EST102")
                new_item_font = New ToolStripMenuItem("Set Font - EST103")

                AddHandler new_item_colors.Click, AddressOf OpenDialog_Color
                AddHandler new_item_font.Click, AddressOf OpenDialog_Font

                AddHandler new_item_refresh.Click, AddressOf RefreshElement_Field ''Added 7/31/2019 thomas d.
                AddHandler new_item_sizeInfo.Click, AddressOf GiveSizeInfo_Field ''Added 7/31/2019 thomas d.

                ''Added 12/17/2021 td
                AddHandler new_item_saveToModel.Click, AddressOf SaveInfo_ToModel ''Added 12/17/2021 thomas d.

                ''Added 12/15/2021 td
                ContextMenuStrip1.Items.Add(new_item_menuHeader1) ''Added 12/15/2021 thomas d. 
                ContextMenuStrip1.Items.Add(new_item_menuHeader2) ''Added 12/15/2021 thomas d. 
                ContextMenuStrip1.Items.Add(new_item_menuHeader3) ''Added 12/15/2021 thomas d. 
                ContextMenuStrip1.Items.Add(new_item_separator) ''Added 12/15/2021 thomas d.

                ContextMenuStrip1.Items.Add(new_item_colors)
                ContextMenuStrip1.Items.Add(new_item_font)

                ContextMenuStrip1.Items.Add(new_item_refresh) ''Added 7/31/2019 thomas d.  
                ContextMenuStrip1.Items.Add(new_item_sizeInfo) ''Added 7/31/2019 thomas d.  
                ContextMenuStrip1.Items.Add(new_item_saveToModel) ''Added 12/17/2021 thomas d.  

            End If ''End of "If (0 = ContextMenuStrip1.Items.Count) Then"

            ''Dec.15 2021''ContextMenuStrip1.Show(e.Location.X + Me.ParentForm.Left,
            ''Dec.15 2021''                       e.Location.Y + Me.Top + Me.ParentForm.Top)
            ContextMenuStrip1.Show(e.Location.X + Me.Left + Me.ParentForm.Left,
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

            If (Me.LayoutFunctions IsNot Nothing) Then
                Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
                Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()
            End If ''End of "If (Me.LayoutFunctions IsNot Nothing) Then"

            Me.Refresh_Image(True)

        End If ''End of "If (Me.ElementInfo_Base IsNot Nothing) Then"
    End Sub

    Private Sub PictureLabel_Click(sender As Object, e As EventArgs) Handles pictureLabel.Click

        ''Added 12/15/2021 td
        ''
        ''  See "Handles pictureLabel.MouseClick()".  ----12/15/2021 td 
        ''
        If (False) Then PictureLabel_MouseClick(sender, e)

    End Sub

    Public Sub EnableDragAndDrop_Moveable() Implements IMoveableElement.EnableDragAndDrop_Moveable
        ''Added 12/17/2021 td  
        Throw New NotImplementedException()
    End Sub

    Public Sub DisableDragAndDrop_Unmoveable() Implements IMoveableElement.DisableDragAndDrop_Unmoveable
        ''Added 12/17/2021 td  
        Throw New NotImplementedException()
    End Sub

    Public Function GetPictureBox() As PictureBox Implements IMoveableElement.GetPictureBox
        ''Added 12/17/2021 td  
        ''---Throw New NotImplementedException()
        Return pictureLabel

    End Function
End Class
