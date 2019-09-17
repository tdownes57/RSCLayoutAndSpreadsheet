Option Explicit On ''Added 7/31/2019 td 
Option Strict On ''Added 7/31/2019 td 

''
''Added 7/31/2019 thomas d 
''
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 

Public Class CtlGraphicPortrait
    ''
    ''Added 7/31/2019 thomas d 
    ''
    ''7/31/2019 td''Public Shared Generator As ClassLabelToImage
    ''7/31/2019 td''Public FieldInfo As ICIBFieldStandardOrCustom
    ''7/31/2019 td''Public ElementInfo As ClassElementPic

    Public ElementClass_Obj As ClassElementPic ''Added 9/17/2019 thomas downes
    Public ElementInfo_Pic As IElementPic ''Added 7/31/2019 thomas d 
    Public ElementInfo_Base As IElement_Base ''Added 7/31/2019 thomas d 

    ''9/9/2019 td''Public FormDesigner As FormDesignProtoTwo ''Added 9/4/2019 td
    Public FormDesigner As ILayoutFunctions ''Modified 9/9/2019 td

    Public ReadOnly Property Picture_Box As PictureBox
        Get
            ''Added 7/31/2019 td 
            Return Me.picturePortrait
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New(par_elementPic As ClassElementPic, par_formLayout As ILayoutFunctions)
        ''
        ''Added 9/17/2019 td
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ''9/17/2019 td''Me.ElementInfo_Base = par_infoForPic_Base
        ''9/17/2019 td''Me.ElementInfo_Pic = par_infoForPic_Pic

        Me.ElementClass_Obj = par_elementPic
        Me.ElementInfo_Base = CType(par_elementPic, IElement_Base)
        Me.ElementInfo_Pic = CType(par_elementPic, IElementPic)
        Me.FormDesigner = par_formLayout ''Added 9/4/2019 td

        ''
        ''Added 8/12/2019 thomas downes 
        ''
        ''8/22/2019 td''picturePortrait.Image = ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex)

        Dim strErrorMessage As String = "" ''Added 8/22/2019 td

        ''9/17/2019 td''picturePortrait.Image =
        ''   ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex, strErrorMessage)

        picturePortrait.Image =
            ciPictures_VB.PictureExamples.GetImageByIndex(par_elementPic.PicFileIndex, strErrorMessage)

        If ("" <> strErrorMessage) Then
            ''Added 8/22/2019  
            MessageBox.Show(strErrorMessage, "192032",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If ''End of "If ("" <> strErrorMessage) Then"

        ''
        ''Rotate the image 90 degrees, as many times as needed.  ---8/12/2019 td  
        ''
        Me.RefreshImage()

    End Sub ''End of "Public Sub New(par_elementPic As ClassElementPic, par_formLayout As ILayoutFunctions)"

    Public Sub New_Deprecated(par_infoForPic_Base As IElement_Base, par_infoForPic_Pic As IElementPic, par_formLayout As ILayoutFunctions)
        ''
        ''Added 7/31/2019 td
        ''
        ' This call is required by the designer.
        InitializeComponent()

        Me.ElementInfo_Base = par_infoForPic_Base
        Me.ElementInfo_Pic = par_infoForPic_Pic
        Me.FormDesigner = par_formLayout ''Added 9/4/2019 td

        ''
        ''Added 8/12/2019 thomas downes 
        ''
        ''8/22/2019 td''picturePortrait.Image = ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex)

        Dim strErrorMessage As String = "" ''Added 8/22/2019 td
        picturePortrait.Image =
            ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex, strErrorMessage)

        If ("" <> strErrorMessage) Then
            ''Added 8/22/2019  
            MessageBox.Show(strErrorMessage, "192032",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If ''End of "If ("" <> strErrorMessage) Then"

        ''
        ''Rotate the image 90 degrees, as many times as needed.  ---8/12/2019 td  
        ''
        Me.RefreshImage()

    End Sub ''End of "Public Sub New_Deprecated(par_infoForPic_Base As IElement_Base, par_infoForPic_Pic As IElementPic, par_formLayout As ILayoutFunctions)"

    Public Sub Refresh_Master()
        ''
        ''Added 9/17 & 9/5/2019 thomas d 
        ''
        Refresh_PositionAndSize()

        ''#1 9/15 td''Refresh_Image
        '' #2 9/15 tdRefresh_Image(False)
        Refresh_Image(False)

    End Sub ''End of "Public Sub Refresh_Master()"

    Public Sub Refresh_PositionAndSize()
        ''
        ''Added 9/17 & 9/5/2019 thomas d 
        ''
        Me.Left = Me.FormDesigner.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = Me.FormDesigner.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Sub Refresh_PositionAndSize()"

    Public Sub Refresh_Image(pbRefreshSize As Boolean)
        ''
        ''Added 9/17/2019 thomas d 
        ''



    End Sub ''ENd of "Public Sub Refresh_Image(pbRefreshSize As Boolean)"

    Private Sub DisplayAnotherImage(sender As Object, e As EventArgs)
        ''
        ''Added 8/18/2019 td
        ''
        Me.ElementInfo_Pic.PicFileIndex += 1

        ''8/22/2019 td''picturePortrait.Image = ciPictures_VB.PictureExamples.GetImageByIndex(Me.ElementInfo_Pic.PicFileIndex)

        Dim strErrorMessage As String = ""
        picturePortrait.Image = ciPictures_VB.PictureExamples.GetImageByIndex(Me.ElementInfo_Pic.PicFileIndex, strErrorMessage)

        ''Added 8/22/2019 td
        If ("" <> strErrorMessage) Then MessageBox.Show(strErrorMessage, "229124",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation)

    End Sub ''End of "Private Sub DisplayAnotherImage(sender As Object, e As EventArgs)"

    ''7/31/2019 td''Public Sub New_NotInUse(par_field As ICIBFieldStandardOrCustom)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''7/31/2019 td''Me.FieldInfo = par_field
    ''
    ''    ''7/31/2019 td''Me.ElementInfo = New ClassElementText(Me)
    ''    Me.ElementInfo = New ClassElementPic(Me)
    ''
    ''End Sub

    ''7/31/2019 td'Public Sub New(par_field As ClassFieldStandard)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''7/31/2019 td'Me.FieldInfo = par_field
    ''
    ''    ''7/31/2019 td''Me.ElementInfo = par_field.ElementInfo
    ''    Me.ElementInfo = New ClassElementPic(Me)
    ''
    ''End Sub

    ''7/31/2019 td'Public Sub New(par_field As ClassFieldCustomized)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    Me.FieldInfo = par_field
    ''
    ''    Me.ElementInfo = par_field.ElementInfo
    ''
    ''End Sub

    Public Sub RefreshImage()
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''7/31/2019 td'If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        ''7/31/2019 td'If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then 
        ''7/31/2019 td'   Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)
        ''7/31/2019 td''End If ''End of "If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then "

        ''7/31/2019 td''If (Generator Is Nothing) Then Generator = New ClassLabelToImage

        ''7/31/2019 td''Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        ''
        ''Added 8/7/2019 thomas downes 
        ''
        Dim image_Pic As Image ''Added 8/7/2019 thomas downes 
        ''Dim image_Rotated As Image ''Added 8/7/2019 thomas downes  
        Dim bm_rotation As Bitmap ''Added 8/7/2019 thomas downes 
        Dim boolSeemsInPortraitMode As Boolean
        Dim boolLetsRotate90 As Boolean
        Dim intStarting_Width As Integer ''Added 8/8/2019 thomas 
        Dim intStarting_Height As Integer ''Added 8/8/2019 thomas

        intStarting_Width = picturePortrait.Width
        intStarting_Height = picturePortrait.Height

        ''9/2/2019''Select Case Me.ElementInfo_Pic.OrientationToLayout
        Select Case Me.ElementInfo_Base.OrientationToLayout
            Case "H", "L", "P", "", " " '' H = Horizontal, P = Portrait     
                ''
                ''Added 8/7/2019 thomas downes 
                ''
                image_Pic = picturePortrait.Image
                boolSeemsInPortraitMode = (image_Pic.Height > image_Pic.Width)
                boolLetsRotate90 = True ''boolSeemsInPortraitMode
                boolLetsRotate90 = (Me.ElementInfo_Base.OrientationInDegrees > 0)

                ''Added 8/7/2019 thomas downes 
                If (boolLetsRotate90) Then

                    Dim intRotateIndex As Integer ''Added 8/18/2019 td  

                    For intRotateIndex = 1 To CInt(Me.ElementInfo_Base.OrientationInDegrees / 90)

                        ''Added 8/7/2019 thomas downes 
                        ''8/7 td''image_Rotated = CType(image_Pic.Clone, Image)

                        image_Pic = picturePortrait.Image
                        bm_rotation = New Bitmap(image_Pic)
                        bm_rotation.RotateFlip(RotateFlipType.Rotate90FlipNone)

                        ''8/7 td''picturePortrait.Image = image_Rotated

                        ''8/7 td''picturePortrait.Width = image_Rotated.Width
                        ''8/7 td''picturePortrait.Height = image_Rotated.Height

                        ''8/8 td''picturePortrait.Width = bm_rotation.Width
                        ''8/8 td''picturePortrait.Height = bm_rotation.Height

                        picturePortrait.Width = intStarting_Height ''Switching!! Height & Width are switched.
                        picturePortrait.Height = intStarting_Width ''Switching!! Height & Width are switched.

                        Me.Width = intStarting_Height ''Switching!!  Height & Width are switched. ---8/8/2019 td
                        Me.Height = intStarting_Width ''Switching!!  Height & Width are switched. ---8/8/2019 td 

                        picturePortrait.Refresh()

                        picturePortrait.Image = bm_rotation
                        picturePortrait.SizeMode = PictureBoxSizeMode.Zoom
                        picturePortrait.Refresh()

                        ''8/7 td''Me.Width = image_Rotated.Width
                        ''8/7 td'' Me.Height = image_Rotated.Height

                        ''8/7 td'' Me.Width = picturePortrait.Width
                        ''8/7 td'' Me.Height = picturePortrait.Height

                    Next intRotateIndex

                End If ''End of "If (boolLetsRotate90) Then"

            Case "n/a" '' "P" ----Anything can be rotated by the program code above.  The operations are exactly the same !!
                ''
                ''Added 8/7/2019 thomas downes 
                ''

        End Select ''End of "Select Case Me.ElementInfo_Pic.OrientationToLayout "

    End Sub ''End of Public Sub RefreshImage

    Public Sub SaveToModel()
        ''
        ''Added 7/31/2019 thomas d 
        ''
        If (Me.ElementInfo_Base IsNot Nothing) Then

            ''9/10/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
            ''9/10/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

            Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
            Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Left)

            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height

            ''Added 9/4/2019 td
            ''9/12 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
            Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
            Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        End If ''End of "If (Me.ElementInfo_Base IsNot Nothing) Then"

    End Sub ''End of Public Sub SaveToModel

    Private Sub Rotate90Degrees(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''  
        ''Me.ElementInfo_Pic.OrientationToLayout = "L"

        ''9/2/2019 td''Select Case Me.ElementInfo_Pic.OrientationToLayout
        Select Case Me.ElementInfo_Base.OrientationToLayout
            Case "", " ", "P"
                Me.ElementInfo_Base.OrientationToLayout = "L"
            Case "L"
                Me.ElementInfo_Base.OrientationToLayout = "P"
            Case Else
                Me.ElementInfo_Base.OrientationToLayout = "P"
        End Select

        ''Added 8/12/2019 thomas downes 
        ''   Increment by 90 degrees.  
        ''   This will enable the badge to be printed with the element oriented
        ''   correctly (with one out of four choices of orientation). 
        ''
        ''9/2/2019 td''Me.ElementInfo_Pic.OrientationDegrees += 90
        Me.ElementInfo_Base.OrientationInDegrees += 90

        RefreshImage()
        Me.Refresh()

    End Sub ''eNd of "Private Sub Rotate90()"

    Private Sub PictureLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles picturePortrait.MouseClick
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolRightClick As Boolean

        Dim new_item_rotate90 As ToolStripMenuItem
        Dim new_item_changePic As ToolStripMenuItem

        boolRightClick = (e.Button = MouseButtons.Right)

        ''Added 7/30/2019 thomas downes
        If (boolRightClick) Then

            ''Added 7/30/2019 thomas downes
            ''ContextMenuStrip1.Items.Clear()

            If (0 = ContextMenuStrip1.Items.Count) Then

                new_item_rotate90 = New ToolStripMenuItem("Rotate 90 Degrees")
                ''Added 8/18/2019 td
                new_item_changePic = New ToolStripMenuItem("Change Example Pic")

                AddHandler new_item_rotate90.Click, AddressOf Rotate90Degrees

                ''Added 8/18/2019 td
                AddHandler new_item_changePic.Click, AddressOf DisplayAnotherImage

                ContextMenuStrip1.Items.Add(new_item_rotate90)
                ContextMenuStrip1.Items.Add(new_item_changePic) ''Added 8/18/2019 td

            End If ''End of "If (0 = ContextMenuStrip1.Items.Count) Then"

            ContextMenuStrip1.Show(e.Location.X + Me.Left + Me.ParentForm.Left,
                                   e.Location.Y + Me.Top + Me.ParentForm.Top)

        End If ''End of "If (boolRightClick) Then"

    End Sub

End Class

