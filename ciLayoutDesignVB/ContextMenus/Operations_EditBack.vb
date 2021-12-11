Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/15/2019 td
''

Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''---10/15 td----
''----Imports ciBadgeElements
Imports ciLayoutPrintLib ''Added 10/15/2019 thomas d. 

Public Class Operations_EditBack
    ''
    ''Added 10/15/2019 td
    ''
    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner
    Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property OpenFileDialog1 As OpenFileDialog ''Added 10/15/2019 td 
    Public Property GroupedElements As ClassGroupMove ''Added 10/15/2019 td

    Public Sub Unselect_all_selected_Elements(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''
        Me.Designer.UnselectHighlightedElements()

    End Sub ''End of "Public Sub Unselect_all_highlighted_Elements()"

    Public Sub Try_next_background_image(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''
        Dim boolNoneFound As Boolean ''Added 10/15/2019 td 

        BackImageExamples.CurrentIndex += 1
        BackImageExamples.PathToFolderWithBacks = DiskFolders.PathToFolder_BackExamples
        Me.Designer.BackgroundBox_Front.Image = BackImageExamples.GetCurrentImage(boolNoneFound)



    End Sub ''End of "Public Sub Change_Background_Image()"

    Public Sub Select_background_image(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''
        Dim open_image As Bitmap ''Added 10/15/2019 thomas d. 
        Dim strFullPathToBitmap As String

        If OpenFileDialog1 Is Nothing Then OpenFileDialog1 = New OpenFileDialog
        OpenFileDialog1.ShowDialog()
        strFullPathToBitmap = OpenFileDialog1.FileName

        If ("" <> strFullPathToBitmap) Then
            open_image = New Bitmap(strFullPathToBitmap)
            Me.Designer.BackgroundBox_Front.Image = open_image
        End If ''End of "If ("" = strFullPathToBitmap) Then"

    End Sub ''End of "Public Sub Change_Background_Image()"






End Class
