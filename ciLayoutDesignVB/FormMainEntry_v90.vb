''
''Added 9/8/2019 thomas downes
''
Imports ciBadgeInterfaces ''added 9/8 
''9/9/2019 td''Imports ControlManager
Imports MoveAndResizeControls_Monem
Imports ciLayoutPrintLib ''Added 8/28/2019 thomas d. 
Imports System.Collections.Generic ''Added 9.6.2019 td 
Imports ciBadgeDesigner ''Added 10/3/2019 td  

Public Class FormMainEntry_v90
    Implements ISelectingElements_v90, ILayoutFunctions
    ''
    ''Added 9/8/2019 thomas downes
    ''
    Private WithEvents mod_groupedMove As New GroupMoveEvents_Singleton(CType(Me, ILayoutFunctions)) ''Added 9/17/2019 td
    Private mod_ElementLastTouched As CtlMainEntryBox_v90 ''Added 9/19/2019 td
    Private Const mc_bAddBorderOnlyWhileResizing As Boolean = True ''Added 9/19/2019 td 

    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        ''Added 9/3/2019 thomas downes
        Return Me.BackgroundImage.Width
    End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        ''Added 9/11/2019 Never Forget 
        Return Me.BackgroundImage.Height
    End Function ''End of "Public Function Layout_Height_Pixels() As Integer"

    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsLeft - CInt((Me.Width - Me.BackgroundImage.Width) / 2))
    End Function ''End of "Public Function Layout_Margin_Left_Omit() As Integer"

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsLeft + CInt((Me.Width - Me.BackgroundImage.Width) / 2))
    End Function ''End of "Public Function Layout_Margin_Left_Add() As Integer"

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop - 0)
    End Function ''End of "Public Function Layout_Margin_Top_Omit() As Integer"

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop + 0)
    End Function ''End of "Public Function Layout_Margin_Top_Add() As Integer"

    Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified ''Added 8/9/2019 td
        Get
            ''
            ''Added 9/19/2019 td
            ''
            ''8/12/2019 td''Return mod_FieldControlLastTouched
            Return mod_ControlLastTouched ''Added 8/12/2019 td  
        End Get
        Set(value As Control)
            ''Added 8/9/2019 td
            mod_ControlLastTouched = value ''Added 8/12/2019 td
            mod_ElementLastTouched = value ''Added 9/14/2019 td
            Try
                ''9/9/2019 td''mod_FieldControlLastTouched = value
                mod_FieldControlLastTouched = CType(value, CtlMainEntryBox_v90)

                ''Added 9/11/2019 td  
                If (mc_bAddBorderOnlyWhileResizing) Then
                    mod_FieldControlLastTouched.BorderStyle = BorderStyle.FixedSingle
                End If ''End of "If (mc_bAddBorderOnlyWhileResizing) Then"

            Catch
                ''Not all moveable controls are Field-Label controls. - ----8/12/2019 thomas d.  
            End Try
        End Set
    End Property ''End of Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified 

    Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved ''Added 8/9/2019 td
        Get
            ''
            ''Added 9/20/2019 td
            ''
            Return mod_ControlLastMoved
        End Get
        Set(value As Control)
            ''
            ''Added 9/20/2019 td
            ''
            mod_ControlLastTouched = value ''Added 8/12/2019 td
            mod_ElementLastTouched = value ''Added 9/14/2019 td
            mod_ControlLastMoved = value ''Added 9/20/2019 td 

            Try
                ''9/9/2019 td''mod_FieldControlLastTouched = value
                mod_FieldControlLastTouched = CType(value, CtlMainEntryBox_v90)

                ''Added 9/11/2019 td  
                If (mc_bAddBorderOnlyWhileResizing) Then
                    ''Add a border while a control is being resized.  
                    mod_FieldControlLastTouched.BorderStyle = BorderStyle.FixedSingle
                End If ''End of "If (mc_bAddBorderOnlyWhileResizing) Then"

            Catch
                ''Not all moveable controls are Field-Label controls. - ----8/12/2019 thomas d.  
            End Try
        End Set
    End Property ''End of Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified 

    Public Function OkayToShowFauxContextMenu() As Boolean Implements ILayoutFunctions.OkayToShowFauxContextMenu
        ''
        ''Added 9/19/2019 td 
        ''
        ''OkayToShowFauxContextMenu()
        ''9/19/2019 td''Return DemoModeActiveToolStripMenuItem.Checked

        Return False

    End Function ''End of "Public Function OkayToShowFauxContextMenu() As Boolean"

    Public Sub AutoPreview_IfChecked(Optional par_ctlElement As Control = Nothing,
                                     Optional par_isMoving As Boolean = False) Implements ILayoutFunctions.AutoPreview_IfChecked
        ''
        ''Added 9/19/2019 td 
        ''

    End Sub ''End of "Public Function AutoPreview_IfChecked() As Boolean"

    Public Function RightClickMenu_Parent() As ToolStripMenuItem Implements ILayoutFunctions.RightClickMenu_Parent

        ''Added 9/19/2019 td
        Return Nothing ''RightClickMenuParent

    End Function

    Public Function NameOfForm() As String Implements ILayoutFunctions.NameOfForm
        ''Added 9/19/2019
        Return Me.Name
    End Function

    Public Sub RedrawForm() Implements ILayoutFunctions.RedrawForm
        ''Added 9/23/2019
        Me.Invalidate() ''Causes the form to be re-painted. 
    End Sub

End Class