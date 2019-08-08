Option Explicit On ''Added 7/31/2019 td 
Option Strict On ''Added 7/31/2019 td 

''
''Added 7/31/2019 thomas d 
''

Public Class CtlGraphicPortrait
    ''
    ''Added 7/31/2019 thomas d 
    ''
    ''7/31/2019 td''Public Shared Generator As ClassLabelToImage
    ''7/31/2019 td''Public FieldInfo As ICIBFieldStandardOrCustom
    ''7/31/2019 td''Public ElementInfo As ClassElementPic

    Public ElementInfo_Pic As IElementPic ''Added 7/31/2019 thomas d 
    Public ElementInfo_Base As IElement_Base ''Added 7/31/2019 thomas d 

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

    Public Sub New(par_infoForPic_Base As IElement_Base, par_infoForPic_Pic As IElementPic)
        ''
        ''Added 7/31/2019 td
        ''
        ' This call is required by the designer.
        InitializeComponent()

        Me.ElementInfo_Base = par_infoForPic_Base
        Me.ElementInfo_Pic = par_infoForPic_Pic

    End Sub

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

        ''7/31/2019 td'If (Me.ElementInfo.Font_AllInfo Is Nothing) Then 
        ''7/31/2019 td'   Me.ElementInfo.Font_AllInfo = New Font("Times New Roman", 15, FontStyle.Regular)
        ''7/31/2019 td''End If ''End of "If (Me.ElementInfo.Font_AllInfo Is Nothing) Then "

        ''7/31/2019 td''If (Generator Is Nothing) Then Generator = New ClassLabelToImage

        ''7/31/2019 td''Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        ''
        ''Added 8/7/2019 thomas downes 
        ''
        Dim image_Pic As Image ''Added 8/7/2019 thomas downes 
        Dim image_Rotated As Image ''Added 8/7/2019 thomas downes  
        Dim bm_rotation As Bitmap ''Added 8/7/2019 thomas downes 
        Dim boolSeemsInPortraitMode As Boolean
        Dim boolLetsRotate90 As Boolean

        Select Case Me.ElementInfo_Pic.OrientationToLayout
            Case "H" '' H = Horizontal   
                ''
                ''Added 8/7/2019 thomas downes 
                ''
                image_Pic = picturePortrait.Image
                boolSeemsInPortraitMode = (image_Pic.Height > image_Pic.Width)
                boolLetsRotate90 = boolSeemsInPortraitMode

                ''Added 8/7/2019 thomas downes 
                If (boolLetsRotate90) Then
                    ''Added 8/7/2019 thomas downes 
                    image_Rotated = CType(image_Pic.Clone, Image)
                    bm_rotation = New Bitmap(image_Rotated)
                    bm_rotation.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    picturePortrait.Image = image_Rotated
                    picturePortrait.Width = image_Rotated.Width
                    picturePortrait.Height = image_Rotated.Height
                    Me.Width = image_Rotated.Width
                    Me.Height = image_Rotated.Height
                End If ''End of "If (boolLetsRotate90) Then"

            Case "P"
                ''
                ''Added 8/7/2019 thomas downes 
                ''

        End Select ''End of "Select Case Me.ElementInfo_Pic.OrientationToLayout "

    End Sub ''End of Public Sub RefreshImage

    Public Sub SaveToModel()
        ''
        ''Added 7/31/2019 thomas d 
        ''
        Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

    End Sub ''End of Public Sub SaveToModel

    Private Sub Rotate90Degrees(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ''Me.ElementInfo_Pic.OrientationToLayout = "L"

        Select Case Me.ElementInfo_Pic.OrientationToLayout
            Case "", " ", "P"
                Me.ElementInfo_Pic.OrientationToLayout = "L"
            Case "L"
                Me.ElementInfo_Pic.OrientationToLayout = "P"
            Case Else
                Me.ElementInfo_Pic.OrientationToLayout = "P"
        End Select

        RefreshImage()
        Me.Refresh()

    End Sub ''eNd of "Private Sub Rotate90()"

    Private Sub PictureLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles picturePortrait.MouseClick
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolRightClick As Boolean

        Dim new_item_rotate90 As ToolStripMenuItem

        boolRightClick = (e.Button = MouseButtons.Right)

        ''Added 7/30/2019 thomas downes
        If (boolRightClick) Then

            ''Added 7/30/2019 thomas downes
            ''ContextMenuStrip1.Items.Clear()

            If (0 = ContextMenuStrip1.Items.Count) Then

                new_item_rotate90 = New ToolStripMenuItem("Browse Field")

                AddHandler new_item_rotate90.Click, AddressOf Rotate90Degrees

                ContextMenuStrip1.Items.Add(new_item_rotate90)

            End If ''End of "If (0 = ContextMenuStrip1.Items.Count) Then"

            ContextMenuStrip1.Show(e.Location.X + Me.Left + Me.ParentForm.Left,
                                   e.Location.Y + Me.Top + Me.ParentForm.Top)

        End If ''End of "If (boolRightClick) Then"

    End Sub

End Class

