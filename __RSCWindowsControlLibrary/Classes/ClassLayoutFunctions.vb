Imports ciBadgeInterfaces

Public Class ClassLayoutFunctions
    Implements ciBadgeInterfaces.ILayoutFunctions

    Public Property ControlBeingModified As Control Implements ILayoutFunctions.ControlBeingModified
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Control)
            ''Throw New NotImplementedException()
        End Set
    End Property

    Public Property ControlBeingMoved As Control Implements ILayoutFunctions.ControlBeingMoved
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Control)
            ''Throw New NotImplementedException()
        End Set
    End Property

    Public Sub AutoPreview_IfChecked(Optional par_controlElement As Control = Nothing, Optional par_stillMoving As Boolean = False) Implements ILayoutFunctions.AutoPreview_IfChecked
        Throw New NotImplementedException()
    End Sub

    Public Sub RedrawForm() Implements ILayoutFunctions.RedrawForm
        Throw New NotImplementedException()
    End Sub

    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
        Throw New NotImplementedException()
    End Function

    Public Function OkayToShowFauxContextMenu() As Boolean Implements ILayoutFunctions.OkayToShowFauxContextMenu
        Throw New NotImplementedException()
    End Function

    Public Function RightClickMenu_Parent() As ToolStripMenuItem Implements ILayoutFunctions.RightClickMenu_Parent
        Throw New NotImplementedException()
    End Function

    Public Function NameOfForm() As String Implements ILayoutFunctions.NameOfForm
        Throw New NotImplementedException()
    End Function
End Class
