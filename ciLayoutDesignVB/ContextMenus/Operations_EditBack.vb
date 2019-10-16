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

    Public Sub Change_Background_Image(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''
        OpenFileDialog1.ShowDialog()



    End Sub ''End of "Public Sub Change_Background_Image()"







End Class
