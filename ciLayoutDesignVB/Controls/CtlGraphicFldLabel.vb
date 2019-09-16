Option Explicit On ''Added 8/29/2019 td
Option Strict On ''Added 8/29/2019 td
Option Infer Off ''Added 8/29/2019 td  

''
''Added 7/25/2019 thomas d 
''
Imports ciBadgeInterfaces ''Added 8/28/2019 thomas downes 

Public Class CtlGraphicFldLabel
    ''
    ''Added 7/25/2019 thomas d 
    ''
    ''9/3/2019 td''Public Shared Generator As ClassLabelToImage
    Public Shared LabelToImage As ClassLabelToImage

    ''Added 9/13/2019 td  
    Public Shared UseExampleValues As Boolean

    ''7/26/2019 td''Public FieldInfo As ClassFieldCustomized
    ''7/26/2019 td''Public ElementInfo As ClassElementText
    Public FieldInfo As ICIBFieldStandardOrCustom

    ''#1 8/29/2019 td''Public ElementInfo As ClassElementText
    '' #2 8/29/2019 td''Public ElementInfo_Text As ClassElementText

    Public ElementClass_Obj As ClassElementText ''Added 9/4/2019 thomas downes
    Public ElementInfo_Text As ciBadgeInterfaces.IElement_Text
    Public ElementInfo_Base As ciBadgeInterfaces.IElement_Base

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

        ''9/4/2019 td''Me.ElementInfo_Text = New ClassElementText(Me)

        Dim obj_elementText As ClassElementText ''Added 9/4/2019 thomas d.
        obj_elementText = New ClassElementText(Me) ''Added 9/4/2019 thomas d.
        Me.ElementClass_Obj = obj_elementText ''Added 9/4/2019 thomas d.
        Me.ElementInfo_Base = CType(obj_elementText, IElement_Base) ''Added 9/4/2019 thomas d.
        Me.ElementInfo_Text = CType(obj_elementText, IElement_Text)  ''Added 9/4/2019 thomas d.

    End Sub

    Public Sub New(par_field As ClassFieldStandard,
                   Optional par_formDesigner As FormDesignProtoTwo = Nothing,
                   Optional par_elementText As ClassElementText = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        ''Added 9/3/2019 thomas downes
        ''9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo, IElement_Base)

        ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
        ''9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        If (par_elementText Is Nothing) Then
            Me.ElementClass_Obj = par_field.ElementInfo
            Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
            Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_Text)
        Else
            ''
            ''Added 9/4/2019 thomas d.
            ''
            Me.ElementClass_Obj = par_elementText
            Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
            Me.ElementInfo_Text = CType(par_elementText, IElement_Text)
        End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

        ''Added 8/9/2019 td
        Me.FormDesigner = par_formDesigner

    End Sub

    Public Sub New(par_field As ClassFieldCustomized,
                   Optional par_formDesigner As FormDesignProtoTwo = Nothing,
                   Optional par_elementText As ClassElementText = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        ''Added 9/3/2019 thomas downes
        ''9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo, IElement_Base)

        ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
        ''#1 9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        '' #2 9/4/2019 td''Me.ElementClass_Obj = par_field.ElementInfo
        '' #2 9/4/2019 td''Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
        '' #2 9/4/2019 td''Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        If (par_elementText Is Nothing) Then
            Me.ElementClass_Obj = par_field.ElementInfo
            Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
            Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_Text)
        Else
            ''
            ''Added 9/4/2019 thomas d.
            ''
            Me.ElementClass_Obj = par_elementText
            Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
            Me.ElementInfo_Text = CType(par_elementText, IElement_Text)
        End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

        ''Added 8/9/2019 td
        Me.FormDesigner = par_formDesigner

    End Sub

    Public Sub New(par_field As ICIBFieldStandardOrCustom,
                   Optional par_formDesigner As FormDesignProtoTwo = Nothing,
                   Optional par_elementText As ClassElementText = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ''
        ' Add any initialization after the InitializeComponent() call.
        ''
        Me.FieldInfo = par_field

        ''Added 9/3/2019 td
        ''  9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo_Base, IElement_Base)
        ''  9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo_Text, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        If (par_elementText Is Nothing) Then
            ''9/15/2019 td''Me.ElementClass_Obj = Nothing ''9/4/2019 td''par_field.ElementInfo

            Me.ElementClass_Obj = New ClassElementText

            ''
            ''------ IMPORTANT ------------------
            ''------ POTENTIALLY CONFUSING-------
            ''
            Me.ElementClass_Obj.LoadbyCopyingMembers(par_field.ElementInfo_Base, par_field.ElementInfo_Text)

            ''  9/15/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo_Base, IElement_Base)
            ''  9/15/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo_Text, IElement_Text)

            Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
            Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_Text)

        Else
            ''
            ''Added 9/4/2019 thomas d.
            ''
            Me.ElementClass_Obj = par_elementText
            Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
            Me.ElementInfo_Text = CType(par_elementText, IElement_Text)

        End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

        ''Added 9/3/2019 td
        Me.FormDesigner = par_formDesigner

    End Sub

    Public Sub Refresh_Master()
        ''
        ''Added 9/5/2019 thomas d 
        ''
        Refresh_PositionAndSize()

        ''#1 9/15 td''Refresh_Image
        '' #2 9/15 tdRefresh_Image(False)
        Refresh_Image(False)

    End Sub ''End of "Public Sub Refresh_Master()"

    Public Sub Refresh_PositionAndSize()
        ''
        ''Added 9/5/2019 thomas d 
        ''
        Me.Left = Me.FormDesigner.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = Me.FormDesigner.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Sub Refresh_PositionAndSize()"

    Public Sub Refresh_Image(pbRefreshSize As boolean)
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText(
        ''8/4/2019''If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        ElementInfo_Text.Text = LabelText()

        ''Me.ElementInfo.Width = pictureLabel.Width
        ''Me.ElementInfo.Height = pictureLabel.Height

        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = Me.ParentForm.Font ''Me.Font
        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 25, FontStyle.Italic)

        If (Me.ElementInfo_Text.Font_DrawingClass Is Nothing) Then
            ''
            ''Initialize the font. 
            ''
            ''9/6/2019 tdMe.ElementInfo_Text.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)

            With Me.ElementInfo_Text
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
            Dim boolScaleFontSize As Boolean ''Added 9/15/2019 thomas d. 
            boolScaleFontSize = (Me.ElementInfo_Text.FontSize_ScaleToElementYesNo)
            If (boolScaleFontSize) Then
                ''Added 9/15/2019 thomas d.
                Me.ElementClass_Obj.Font_ScaleAdjustment(Me.ElementInfo_Base.Height_Pixels)
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

        Dim intLayoutWidth As Integer ''Added 9/3/2019 thomas d.
        intLayoutWidth = Me.FormDesigner.Layout_Width_Pixels()

        ''9/4/2019 td''LabelToImage.TextImage(intLayoutWidth, pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        ''
        ''Major call !!
        ''
        pictureLabel.Image =
        LabelToImage.TextImage(intLayoutWidth, Me.ElementInfo_Text,
                               Me.ElementInfo_Base,
                               boolRotated, True)

        ''Added 8/18/2019 td
        Dim intImageWidth As Integer
        intImageWidth = pictureLabel.Image.Width
        If (boolRotated) Then ''Added 8/18/2019 td
            pictureLabel.Height = pictureLabel.Image.Height
            pictureLabel.Width = intImageWidth
            Me.Height = pictureLabel.Height
            Me.Width = pictureLabel.Width
        Else
            ''
            ''Adjust the controls to the image size. ---9/3/2019 td 
            ''
            pictureLabel.Width = pictureLabel.Image.Width
            pictureLabel.Height = pictureLabel.Image.Height
            Me.Height = pictureLabel.Height
            Me.Width = pictureLabel.Width

        End If ''End if "If (boolRotated) Then .... Else ...."

        ''Added 7/31/2019 td
        If (mod_c_boolMustSetBackColor And (ElementInfo_Text IsNot Nothing)) Then
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

        ''8/19/2019 td''pictureLabel.Refresh()
        pictureLabel.Refresh()
        Me.Refresh()

    End Sub ''End of Public Sub Refresh_Image

    Public Sub SaveToModel()
        ''
        ''Added 7/29/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText()

        ''9/5/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
        ''9/5/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

        Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

        ''Added 9/4/2019 thomas downes
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        ''Me.ElementInfo.Font_DrawingClass = Me.Font
        ''Me.ElementInfo.BackColor = Me.BackColor
        ''Me.ElementInfo.FontColor = Me.ForeColor

        ''
        ''Added 9/15/2019 thomas d. 
        ''
        Select Case True
            Case Me.FieldInfo.IsStandard
                ''
                ''Standard field. 
                ''
                ''Added 9/15/2019 thomas d.
                ClassFieldStandard.CopyElementInfo(Me.FieldInfo.FieldIndex,
                                                   Me.ElementInfo_Base, Me.ElementInfo_Text)

            Case Else
                ''
                ''Customized field.
                ''
                ''Added 9/15/2019 thomas d.
                ClassFieldCustomized.CopyElementInfo(Me.FieldInfo.FieldLabelCaption,
                                                   Me.ElementInfo_Base, Me.ElementInfo_Text)

        End Select

    End Sub ''End of Public Sub SaveToModel

    Public Function LabelText() As String
        ''
        ''Added 7/25/2019 thomas d 
        ''
        Select Case True

            Case (UseExampleValues And (Me.FieldInfo.ExampleValue <> ""))

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
        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

        ''Added 9/5/2019 td 
        Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

        ''Added 9/4/2019 td
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

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
        strMessageToUser &= (vbCrLf & $"Element-Info Property (Height): {Me.ElementInfo_Base.Height_Pixels}")
        strMessageToUser &= (vbCrLf & $"Picture control's Image Height: {pictureLabel.Image.Height}")

        MessageBox.Show(strMessageToUser, "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of "Private Sub RefreshElement_Field(sender As Object, e As EventArgs)"

    Private Sub CtlGraphicFldLabel_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ''
        ''Addd 7/31/2019 td
        ''
        ''9/4/2019 td''If (Me.ElementInfo_Text IsNot Nothing) Then
        If (Me.ElementInfo_Base IsNot Nothing) Then

            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height
            ''Me.RefreshImage()

            ''Added 9/5/2019 td 
            Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
            Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

            ''Added 9/4/2019 td
            ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
            Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
            Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        End If ''End of "If (Me.ElementInfo_Base IsNot Nothing) Then"

    End Sub

    Private Sub pictureLabel_DragOver(sender As Object, e As DragEventArgs) Handles pictureLabel.DragOver

    End Sub

    Private Sub TextTypeExample_KeyPress(sender As Object, e As KeyPressEventArgs) ''9/10/2019 td''Handles textTypeExample.KeyPress
        ''
        ''Added 8/10/2019 td
        ''
        ''If (e.KeyChar = ) Then
        ''
        ''End If

    End Sub

    Private Sub TextTypeExample_KeyUp(sender As Object, e As KeyEventArgs) Handles textTypeExample.KeyDown

        ''Added 8/10/2019 thomas downes  
        If (e.KeyCode = Keys.Enter) Then

            Me.FieldInfo.ExampleValue = textTypeExample.Text
            Me.ElementInfo_Text.Text = textTypeExample.Text
            Me.textTypeExample.Visible = False

            ''Added 9/10/2019 td
            Me.Refresh_Master()

        End If ''End If ''End of "If (e.KeyCode = Keys.Enter) Then"

    End Sub
End Class
