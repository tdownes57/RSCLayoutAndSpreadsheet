Option Explicit On
Option Strict On

''
''Added 9/21/2019 td
''
Imports System.Reflection.Assembly

Friend Class ClassMenuMethods
    ''
    ''Added 9/21/2019 td
    ''
    ''9/23/2019 td''
    Public WithEvents MyLinkLabel As New LinkLabel

    Public ParentForm As FormRotateText

    Public Sub Add_Text_Image(sender As Object, e As LinkLabelLinkClickedEventArgs)

        ''System.Diagnostics.Debugger.Break()

        ParentForm.BackgroundImage = New Bitmap(250, 30) '', Color.White)

        ''ParentForm.BackgroundImageLayout = ImageLayout.Tile
        ParentForm.BackgroundImageLayout = ImageLayout.None

        Dim gm_back As Graphics ''----New Bitmap(ParentForm.BackgroundImage)

        gm_back = Graphics.FromImage(ParentForm.BackgroundImage)
        ''---ParentForm.BackgroundImage
        gm_back.Clear(Color.White)
        ParentForm.Invalidate()

    End Sub ''End of "Public Sub Add_Text_Image(sender As Object, e As LinkLabelLinkClickedEventArgs)"

    Public Sub Add_a_horizontal_line(sender As Object, e As LinkLabelLinkClickedEventArgs)
        ''
        ''Added 9/23/2019 thomas downes
        ''
        Dim gm_back As Graphics ''----New Bitmap(ParentForm.BackgroundImage)
        Dim g_pen_black As New Pen(Color.Black)

        Dim pt_start As New Point(0, 15)
        Dim pt_end As New Point(200, 15)

        gm_back = Graphics.FromImage(ParentForm.BackgroundImage)

        gm_back.DrawLine(g_pen_black, pt_start, pt_end)

        ParentForm.Invalidate()

    End Sub ''End of "Public Sub Add_a_horizontal_line(sender As Object, e As LinkLabelLinkClickedEventArgs)"


    Public Sub Create_a_Rotated_Image(sender As Object, e As LinkLabelLinkClickedEventArgs)

        Dim bm_rotation As Bitmap ''Added 9/23/2019 td

        bm_rotation = New Bitmap(ParentForm.BackgroundImage)
        bm_rotation.RotateFlip(RotateFlipType.Rotate90FlipNone)

        ParentForm.BackgroundImage = bm_rotation

        ParentForm.Invalidate()

    End Sub ''End of "Public Sub Create_a_Rotated_Image(sender As Object, e As LinkLabelLinkClickedEventArgs)"

    Public Sub This_is_awesome(sender As Object, e As LinkLabelLinkClickedEventArgs)

        System.Diagnostics.Debugger.Break()

    End Sub

    Public Sub This_is_fun(sender As Object, e As LinkLabelLinkClickedEventArgs)

        System.Diagnostics.Debugger.Break()

    End Sub

    ''9/23/2019 td''Private Sub MyLinkLabelLinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles MyLinkLabel.LinkClicked
    ''9/23/2019 td''
    ''9/23/2019 td''End Sub

    Public Sub AddEventHandlerLinkClicked_NotUsed(par_link As LinkLabel)
        ''
        ''Added 9/22/2019 thomas d. 
        ''
        Throw New NotImplementedException("We use Reflection instead.  Find [.AddEventHandler] in this project.")

        Select Case par_link.Text.ToUpper

            Case "Add Text Image".ToUpper

                AddHandler par_link.LinkClicked,
                    AddressOf Add_Text_Image

            Case "Create A Rotated Image".ToUpper

                AddHandler par_link.LinkClicked,
                    AddressOf Me.Create_a_Rotated_Image

            Case Else
                MessageBox.Show($"The link [{par_link.Text}] is unpaired with a class method." & vbCrLf & vbCrLf &
                                "Please inform the software developer.", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Select ''End of "Select Case par_link.Text.ToUpper"

    End Sub ''End of "Public Sub AddEventHandlerLinkClicked(par_link As LinkLabel)"



End Class
