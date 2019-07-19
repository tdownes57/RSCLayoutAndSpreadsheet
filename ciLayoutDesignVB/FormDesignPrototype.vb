Option Explicit On
Option Strict On
''
''   Added 5/6/2019 thomas downes 
''
''   https://www.codeproject.com/articles/38137/easy-drag-and-drop-of-controls-at-run-time
''

Public Class FormDesignPrototype
    ''
    ''   https://www.codeproject.com/articles/38137/easy-drag-and-drop-of-controls-at-run-time
    ''
    Dim dragging As Boolean
    Dim startX As Integer
    Dim startY As Integer
    ''Dim mod_document As printing object
    Dim WithEvents mod_PrintDoc As New System.Drawing.Printing.PrintDocument()

    ''Added 6/13/2019 td
    Private mod_ciLayoutPrint As New ciLayoutPrintLib.LayoutPrint

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

        ''Added 6/13/2019 thomas d.
        ''
        With mod_ciLayoutPrint
            .LabelControlForID = Me.labelDefault1
            .LabelControlForName = Me.LabelDefault2

            .PanelLayout = Me.panelLayout ''Added 6/13 td 

            mod_ciLayoutPrint.PictureOfPureWhite = Me.picturePureWhite
            mod_ciLayoutPrint.PicturePersonWithinLayout = Me.PicturePersonInLayout
            mod_ciLayoutPrint.PicturePersonImageLarge = Me.PicturePersonLarge
            mod_ciLayoutPrint.PictureBoxReview = Me.pictureboxReview
        End With

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

    Private Sub GenerateBuildImage(Optional ByRef pref_image As Image = Nothing, Optional ByVal pboolLargeLandscape As Boolean = False)
        ''
        ''Added 5/6/2019 thomas downes  
        ''
        ''panelLayout
        ''
        ''Let's create the image we can write our text on.  
        ''
        ''  https://stackoverflow.com/questions/8022174/how-can-i-write-on-an-image-using-vb-net
        ''
        Dim img_LargeLandscape As System.Drawing.Image
        Dim img_Rotated As Image
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
        Try
            Using graphicsCroppping = Graphics.FromImage(imgPanelCropped)
                graphicsCroppping.DrawImage(imgPanelBackground, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                ''This can be done when the application closes. -----imgPanelBackground.Dispose()
                ''imgPanelCropped.Save(fileName)
            End Using
        Catch ex As Exception
            ''
            ''Added 5/9/2019 td
            ''
            MessageBox.Show("Resizing error, GenerateBuildImage:  " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        img_LargeLandscape = imgPanelCropped

        ''Encapsulated 5/7/2019 td
        Const c_boolCallProcedureForText As Boolean = True

        If (c_boolCallProcedureForText) Then

            ''Encapsulated 5/7/2019 td
            ApplyTextToImage(img_LargeLandscape)
            ApplyMemberPicToImage(img_LargeLandscape)

        Else

            gr = Graphics.FromImage(img_LargeLandscape)

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

        ''Added 5/15/2019 td
        img_Rotated = CType(img_LargeLandscape.Clone, Image)

        ''5/15 td''Dim bm_source As New Bitmap(img_LargeLandscape)
        Dim bm_source As New Bitmap(img_Rotated)
        bm_source.RotateFlip(RotateFlipType.Rotate90FlipNone)

        ''img = ResizeImage(img, pictureboxReview)
        Dim imgResized As Image
        imgResized = ResizeImage(bm_source, pictureboxReview)

        pictureboxReview.Image = imgResized

        ''gr.DrawImage()

        If (pboolLargeLandscape) Then
            pref_image = img_LargeLandscape
        Else
            pref_image = imgResized
        End If

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

        ''Draw white space so that the text can be read more easily. 
        ApplyWhiteSpaceToImage(par_image, labelDefault1)

        gr.DrawString("Person " & txtStudentID.Text,
                      New Font("Tahoma", labelDefault1.Font.SizeInPoints),
                      New SolidBrush(labelDefault1.ForeColor),
                       labelDefault1.Left, labelDefault1.Top)

        ''Draw white space so that the text can be read more easily. 
        ApplyWhiteSpaceToImage(par_image, LabelDefault2)

        gr.DrawString(txtStudentName.Text,
                      New Font("Tahoma", LabelDefault2.Font.SizeInPoints),
                      New SolidBrush(LabelDefault2.ForeColor),
                       LabelDefault2.Left, LabelDefault2.Top)

        gr.Dispose()

    End Sub ''End of ""Private Sub ApplyTextToImage(ByRef par_image As Image)

    Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByVal par_textboxOrLabel As Control)
        ''
        ''Added 5/10/2019 td  
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)

        gr = Graphics.FromImage(par_image)

        With par_textboxOrLabel
            gr.DrawImage(picturePureWhite.Image, .Left, .Top, .Width, .Height)
        End With

        gr.Dispose()

    End Sub ''ENd of "Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByRef par_textboxOrLabel As Control)"

    Private Sub ApplyMemberPicToImage(ByRef par_image As Image)
        ''
        ''Added 5/7/2019 td  
        ''
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim imgPicture As Image
        ''Dim imgResized As Image

        ''-----gr = Graphics.FromImage(par_image)
        imgPicture = PicturePersonLarge.Image

        ''Dim bm_source As New Bitmap(imgPicture)
        ''imgResized = ResizeImage(bm_source, PicturePersonInLayout)

        gr = Graphics.FromImage(par_image)

        ''
        ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
        ''
        With PicturePersonInLayout
            gr.DrawImage(imgPicture, .Left, .Top, .Width, .Height)
        End With

        gr.Dispose()

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
        ''
        ''Encapsulated 5/7/2019 thomas d. 
        ''
        Dim boolUseCIWebLibrary As Boolean ''Added 6/13/2019 td

        boolUseCIWebLibrary = checkUseCiLayoutPrintLib.Checked

        ''6/13/2019 td''GenerateBuildImage()
        If (boolUseCIWebLibrary) Then
            ''Added 6/13/2019 td
            ''
            ''Use the web-friendly library. 
            ''
            mod_ciLayoutPrint.RecipientID = txtStudentID.Text
            mod_ciLayoutPrint.RecipientName = txtStudentName.Text
            mod_ciLayoutPrint.GenerateBuildImage_Master()

        Else
            ''
            ''Don't use the web-friendly library.  
            ''
            GenerateBuildImage()
        End If

        ''Added 5/15/2019 td
        ''
        If (checkboxDisplayWindow.Checked) Then

            Dim objFormToShow As New FormDisplay
            Dim image_Landscape As Image = Nothing
            Dim image_SmallPortrait As Image = Nothing

            If (boolUseCIWebLibrary) Then
                ''Added 6/13/2019 td
                mod_ciLayoutPrint.GenerateBuildImage_Master(image_Landscape, True)
                mod_ciLayoutPrint.GenerateBuildImage_Master(image_SmallPortrait, False)
            Else
                ''From 5/15/2019 td
                GenerateBuildImage(image_Landscape, True)
                GenerateBuildImage(image_SmallPortrait, False)
            End If

            objFormToShow.ImageLarge_OrientLandscape = image_Landscape
            objFormToShow.ImageSmall_OrientPortrait = image_SmallPortrait
            objFormToShow.ShowDialog()

        End If ''End of "If (checkboxDisplayWindow.Checked) Then"

    End Sub

    Private Sub ButtonOpenBrowser_Click(sender As Object, e As EventArgs) Handles ButtonOpenBrowser.Click

        ''If (False) Then
        ''    Convert.ToBase64String(System.IO.File.ReadAllBytes("Test.jpg"))
        ''End If

        Dim img As System.Drawing.Image
        img = pictureboxReview.Image
        img.Save("test.jpg", Imaging.ImageFormat.Jpeg)

        ''5/7/2019 td''System.Diagnostics.Process.Start("Test.html")
        ''5/9/2019 td''System.Diagnostics.Process.Start("test_JpegFile.htm")
        ''5/9/2019 td''System.Diagnostics.Process.Start("test_WorksWellInChrome.htm")

        OpenFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath
        OpenFileDialog1.Filter = "HTML files|*.htm*"
        OpenFileDialog1.ShowDialog()
        If ("" = OpenFileDialog1.FileName) Then Exit Sub
        System.Diagnostics.Process.Start(OpenFileDialog1.FileName)

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
          Handles mod_PrintDoc.PrintPage

        e.Graphics.DrawImage(pictureboxReview.Image, 0, 0)

    End Sub

    Private Sub ButtonPrintBadge_Click(sender As Object, e As EventArgs) Handles ButtonPrintBadge.Click

        ''If PrintDialog1.ShowDialog = DialogResult.OK Then
        mod_PrintDoc.Print()
        ''End If

    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click

    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click

    End Sub

    Private Sub LabelDefault2_MouseEnter(sender As Object, e As EventArgs) Handles LabelDefault2.MouseEnter, labelDefault1.MouseEnter, PicturePersonInLayout.MouseEnter

        Me.Cursor = Cursors.SizeNWSE

    End Sub

    Private Sub LabelDefault2_MouseLeave(sender As Object, e As EventArgs) Handles LabelDefault2.MouseLeave, labelDefault1.MouseLeave, PicturePersonInLayout.MouseLeave

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ButtonSaveAsXML_Click(sender As Object, e As EventArgs) Handles ButtonSaveAsXML.Click
        ''
        ''Added 7/15/2019 thomas downes
        ''
        ''   Copy the elements of the layout to a class which is not a Windows Form
        ''   but which will act as a "container" for the layout-relevant Windows controls.
        ''
        ''   The container class will have Serialize and Deserialize commands. 
        ''
        ''






    End Sub
End Class
