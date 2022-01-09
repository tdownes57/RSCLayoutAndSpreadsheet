Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/13/2021 td
''

Imports ciBadgeInterfaces
''Imports ciBadgeDesigner
''---10/15 td----
''----Imports ciBadgeElements
''Imports ciLayoutPrintLib ''Added 10/15/2019 thomas d. 
Imports System.Windows.Forms ''Added 12/27/2021 thomas d. 
Imports System.Drawing ''Added 1/8/2022 thomas downes  


Public Class Operations_EditGraphic
    ''
    ''Added 12/13/2021 td
    ''
    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner
    ''----Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property OpenFileDialog1 As OpenFileDialog ''Added 10/15/2019 td 
    Public Property ColorDialog1 As ColorDialog ''Added 12/13/2021 td 


    Public Sub Select_graphics_image__EG1001(sender As Object, e As EventArgs)
        ''--- Public Sub Select_background_image(sender As Object, e As EventArgs)
        ''
        ''Copied 12/13/2021 from the following:
        ''    Operations_EditBackground  
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
            ''---Me.Designer.BackgroundBox_Front.Image = open_image

        End If ''End of "If ("" = strFullPathToBitmap) Then"

    End Sub ''End of "Public Sub Change_Background_Image()"


    Public Sub Move_Graphic_To_Other_Side_Of_Badge_EG1001(sender As Object, e As EventArgs)
        ''
        ''Added 12/13/2021 thomas d. 
        ''



    End Sub ''End of "Public Sub Move_Graphic_To_Other_Side_Of_Badge_EG1001(sender As Object, e As EventArgs)"


End Class
