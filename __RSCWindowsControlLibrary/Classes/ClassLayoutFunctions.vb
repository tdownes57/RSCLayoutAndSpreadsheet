Imports ciBadgeInterfaces

Public Class ClassLayoutFunctions
    Implements ciBadgeInterfaces.ILayoutFunctions

    ''Added 9/03/2022 thomas downes
    Public Property LayoutDebugName As String Implements ILayoutFunctions.LayoutDebugName
    Public Property LayoutDebugDescription As String Implements ILayoutFunctions.LayoutDebugDescription

    Public Property ControlBeingModified As Control Implements ILayoutFunctions.ControlBeingModified
        Get
            ''Throw New NotImplementedException()
            '9/1/2022 Throw New NotImplementedException()
            System.Diagnostics.Debugger.Break()
            __RSC_Error_Logging.RSCErrorLogging.Log(101, "Public Prop ControlBeingModified",
                  "Prop is not implemented") ''Added 11/16/2022

        End Get
        Set(value As Control)
            ''Throw New NotImplementedException()
            __RSC_Error_Logging.RSCErrorLogging.Log(102,
                                                    "Public Prop ControlBeingModified",
                  "Prop is not implemented") ''Added 11/16/2022
        End Set
    End Property

    Public Property ControlBeingMoved As Control Implements ILayoutFunctions.ControlBeingMoved
        Get
            ''Throw New NotImplementedException()
            '9/1/2022 Throw New NotImplementedException()
            System.Diagnostics.Debugger.Break()
            __RSC_Error_Logging.RSCErrorLogging.Log(103, "Property ControlBeingMoved",
                  "Property Get is not implemented") ''Added 11/16/2022

        End Get
        Set(value As Control)
            ''Throw New NotImplementedException()
            __RSC_Error_Logging.RSCErrorLogging.Log(104, "Property ControlBeingMoved",
                  "Property Set is not implemented") ''Added 11/16/2022
        End Set
    End Property

    Public Property ControlThatWasClicked As Control Implements ILayoutFunctions.ControlThatWasClicked
        ''Added 9/01/2022
        Get
            ''Added 9/01/2022
            ''Throw New NotImplementedException()
            ''9/1/2022 Throw New NotImplementedException()
            System.Diagnostics.Debugger.Break()
            __RSC_Error_Logging.RSCErrorLogging.Log(105,
                                                    "Property ControlThatWasClicked",
                  "Property Get is not implemented") ''Added 11/16/2022

        End Get
        Set(value As Control)
            ''Throw New NotImplementedException()
            __RSC_Error_Logging.RSCErrorLogging.Log(106,
                                                    "Property ControlThatWasClicked",
                  "Property Set is not implemented") ''Added 11/16/2022
        End Set
    End Property

    Public Sub AutoPreview_IfChecked(Optional par_controlElement As Control = Nothing, Optional par_stillMoving As Boolean = False) Implements ILayoutFunctions.AutoPreview_IfChecked
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
        __RSC_Error_Logging.RSCErrorLogging.Log(107, "Public Sub AutoPreview_IfChecked",
                  "AutoPreview_IfChecked is not implemented") ''Added 11/16/2022

    End Sub

    Public Sub RedrawForm() Implements ILayoutFunctions.RedrawForm
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
        __RSC_Error_Logging.RSCErrorLogging.Log(108, "Public Sub RedrawForm",
                  "Property Set is not implemented") ''Added 11/16/2022

    End Sub

    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
        __RSC_Error_Logging.RSCErrorLogging.Log(109,
                  "Public Function Layout_Width_Pixels",
                  "Function is not implemented") ''Added 11/16/2022
    End Function

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
        __RSC_Error_Logging.RSCErrorLogging.Log(110, "Public Fun Layout_Height_Pixels",
                  "Function is not implemented") ''Added 11/16/2022
    End Function

    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
        __RSC_Error_Logging.RSCErrorLogging.Log(111, "Public Fun Layout_Height_Pixels",
                  "Function is not implemented") ''Added 11/16/2022
    End Function

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function

    Public Function OkayToShowFauxContextMenu() As Boolean Implements ILayoutFunctions.OkayToShowFauxContextMenu
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function

    Public Function RightClickMenu_Parent() As ToolStripMenuItem Implements ILayoutFunctions.RightClickMenu_Parent
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function

    Public Function NameOfForm() As String Implements ILayoutFunctions.NameOfForm
        ''Throw New NotImplementedException()
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function
End Class
