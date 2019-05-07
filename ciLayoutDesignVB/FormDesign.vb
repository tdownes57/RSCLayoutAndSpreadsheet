Option Explicit On
Option Strict On
''
''   Added 5/6/2019 thomas downes 
''
''   https://www.codeproject.com/articles/38137/easy-drag-and-drop-of-controls-at-run-time
''

Public Class FormDesign
    ''
    ''   https://www.codeproject.com/articles/38137/easy-drag-and-drop-of-controls-at-run-time
    ''
    Dim dragging As Boolean
    Dim startX As Integer
    Dim startY As Integer

    Private Sub Form1_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 
        ''NorthwindDataSet.Employees' table. You can move, or remove it, as needed.
        ''Me.EmployeesTableAdapter.Fill(Me.NorthwindDataSet.Employees)

        ''5/6/2019 td''For Each Control As Control In Me.Controls
        For Each each_control As Control In Me.panelLayout.Controls
            AddHandler each_control.MouseDown, AddressOf startDrag
            AddHandler each_control.MouseMove, AddressOf whileDragging
            AddHandler each_control.MouseUp, AddressOf endDrag
        Next

        If (My.Settings.controlLocations Is Nothing) Then My.Settings.controlLocations = New Specialized.StringCollection

        ''5/6/2019 td''For Each Control As Control In Me.Controls
        For Each Control As Control In Me.panelLayout.Controls
            For Each itemString As String In My.Settings.controlLocations
                If Split(itemString, "!")(0) = Control.Name Then
                    Control.Location = New Point(Integer.Parse(Split(itemString, "!")(1)),
                        Integer.Parse(Split(itemString, "!")(2)))
                End If
            Next
        Next


    End Sub

    Private Sub startDrag(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs)
        dragging = True
        startX = e.X
        startY = e.Y
    End Sub

    Private Sub whileDragging(ByVal sender As System.Object,
        ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim sender_control As Control = CType(sender, Control)

        If dragging = True Then
            Try
                sender_control.Location = New Point(sender_control.Location.X +
        e.X - startX, sender_control.Location.Y + e.Y - startY)
                Me.Refresh()
            Catch ex As Exception

                StatusLabel1.Text = ex.Message

            End Try
        End If
    End Sub

    Private Sub endDrag(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dragging = False

        My.Settings.controlLocations.Clear()

        ''5/6/2019 td''For Each Control As Control In Me.Controls
        For Each each_control As Control In Me.panelLayout.Controls
            My.Settings.controlLocations.Add(each_control.Name & "!" _
            & each_control.Location.X & "!" & each_control.Location.Y)
        Next

        My.Settings.Save()

    End Sub

    Private Sub ButtonMakeFile_Click(sender As Object, e As EventArgs) Handles ButtonMakeFile.Click

        ''Added 5/7/2019 td  
        Dim img As System.Drawing.Image

        img = pictureboxReview.Image
        ''5/7/2019 td''img.Save("Test.jpg", Imaging.ImageFormat.Png)
        img.Save("Test.png", Imaging.ImageFormat.Png)
        ''5/7/2019 td''System.Diagnostics.Process.Start("Test.jpg")
        System.Diagnostics.Process.Start("Test.png")

    End Sub

    Private Sub GenerateBuildImage()
        ''
        ''Added 5/6/2019 thomas downes  
        ''
        ''panelLayout
        ''
        ''Let's create the image we can write our text on.  
        ''
        ''  https://stackoverflow.com/questions/8022174/how-can-i-write-on-an-image-using-vb-net
        ''
        Dim img As System.Drawing.Image
        Dim imgPanelBackground As System.Drawing.Image
        Dim imgPanelCropped As System.Drawing.Image
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim CropRect As New Rectangle(0, 0, panelLayout.Width, panelLayout.Height)

        ''labelDefault1.Visible = False
        ''LabelDefault2.Visible = False

        imgPanelBackground = panelLayout.BackgroundImage
        ''imgPanelCropped = imgPanelBackground
        imgPanelCropped = New Bitmap(CropRect.Width, CropRect.Height)

        ''Crop the image to what you see in the Panel Layout.
        ''
        ''   (I have removed the Zoom And StretchImage from the PictureBox, 
        ''   so part of the image might lie outside of the PanelLayout area. ---5/7/2019 td)
        ''
        Using graphicsCroppping = Graphics.FromImage(imgPanelCropped)
            graphicsCroppping.DrawImage(imgPanelBackground, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            imgPanelBackground.Dispose()
            ''imgPanelCropped.Save(fileName)
        End Using

        img = imgPanelCropped

        ''Encapsulated 5/7/2019 td
        Const c_boolCallProcedureForText As Boolean = True

        If (c_boolCallProcedureForText) Then

            ''Encapsulated 5/7/2019 td
            ApplyTextToImage(img)
            ApplyMemberPicToImage(img)

        Else

            gr = Graphics.FromImage(img)

            ''
            ''Resizing Images in VB.NET
            ''  https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net
            ''

            ''gr.DrawString("Drawing text",
            ''              New Font("Tahoma", 14),
            ''              New SolidBrush(Color.Green),
            ''              10, 10)

            gr.DrawString("Person " & txtStudentID.Text,
                          New Font("Tahoma", labelDefault1.Font.SizeInPoints),
                          New SolidBrush(labelDefault1.ForeColor),
                           labelDefault1.Left, labelDefault1.Top)

            gr.DrawString(txtStudentName.Text,
                          New Font("Tahoma", LabelDefault2.Font.SizeInPoints),
                          New SolidBrush(LabelDefault2.ForeColor),
                           LabelDefault2.Left, LabelDefault2.Top)

            gr.Dispose()

        End If ''End of "If (c_boolCallProcedureForText) Then ..... Else ...."

        ''panelLayout.Refresh()
        ''img.Save("Test.jpg", Imaging.ImageFormat.Png)
        ''System.Diagnostics.Process.Start("Test.jpg")

        If (False) Then
            Convert.ToBase64String(System.IO.File.ReadAllBytes("Test.jpg"))
        End If

        labelDefault1.Visible = True
        LabelDefault2.Visible = True

        Dim bm_source As New Bitmap(img)
        bm_source.RotateFlip(RotateFlipType.Rotate90FlipNone)

        ''img = ResizeImage(img, pictureboxReview)
        Dim imgResized As Image
        imgResized = ResizeImage(bm_source, pictureboxReview)

        pictureboxReview.Image = imgResized

        ''gr.DrawImage()

    End Sub ''End of "Private Sub GenerateBuildImage()"

    Private Sub ApplyTextToImage(ByRef par_image As Image)
        ''
        ''Added 5/7/2019 td  
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        gr = Graphics.FromImage(par_image)

        ''
        ''Resizing Images in VB.NET
        ''  https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net
        ''

        ''gr.DrawString("Drawing text",
        ''              New Font("Tahoma", 14),
        ''              New SolidBrush(Color.Green),
        ''              10, 10)

        gr.DrawString("Person " & txtStudentID.Text,
                      New Font("Tahoma", labelDefault1.Font.SizeInPoints),
                      New SolidBrush(labelDefault1.ForeColor),
                       labelDefault1.Left, labelDefault1.Top)

        gr.DrawString(txtStudentName.Text,
                      New Font("Tahoma", LabelDefault2.Font.SizeInPoints),
                      New SolidBrush(LabelDefault2.ForeColor),
                       LabelDefault2.Left, LabelDefault2.Top)

        gr.Dispose()

    End Sub ''End of ""Private Sub ApplyTextToImage(ByRef par_image As Image)

    Private Sub ApplyMemberPicToImage(ByRef par_image As Image)
        ''
        ''Added 5/7/2019 td  
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim imgPicture As Image
        Dim imgResized As Image

        ''-----gr = Graphics.FromImage(par_image)
        imgPicture = PicturePersonLarge.Image

        Dim bm_source As New Bitmap(imgPicture)
        imgResized = ResizeImage(bm_source, PicturePersonInLayout)

ExitHandler:
        ''------gr.Dispose()

    End Sub ''End of ""Private Sub ApplyMemberPicToImage(ByRef par_image As Image)

    Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image
        ''
        ''https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net 
        ''
        ''5/7/2019 td''Return New Bitmap(InputImage, New Size(64, 64))
        Return New Bitmap(InputImage, New Size(parSizingBox.Width, parSizingBox.Height))

    End Function ''Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image

    Private Sub buttonGenerate_Click(sender As Object, e As EventArgs) Handles buttonGenerate.Click

        ''Encapsulated 5/7/2019 thomas d. 
        ''
        GenerateBuildImage()

    End Sub

    Private Sub ButtonOpenBrowser_Click(sender As Object, e As EventArgs) Handles ButtonOpenBrowser.Click

        ''If (False) Then
        ''    Convert.ToBase64String(System.IO.File.ReadAllBytes("Test.jpg"))
        ''End If

        Dim img As System.Drawing.Image
        img = pictureboxReview.Image
        img.Save("test.jpg", Imaging.ImageFormat.Jpeg)

        ''5/7/2019 td''System.Diagnostics.Process.Start("Test.html")
        System.Diagnostics.Process.Start("test_JpegFile.htm")

    End Sub
End Class
