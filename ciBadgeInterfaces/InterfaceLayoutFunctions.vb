''
''Added 9/9/2019 td  
''
Imports System.Windows.Forms ''added 9/19/2019 td 

Public Interface ILayoutFunctions
    ''
    ''Added 9/9/2019 td  
    ''
    ''
    '' Well done! Interfaces should not contain properties, but rather methods.
    ''    (Analogously, classes should expose methods, not properties.)  
    '' ---2/07/2023 tcd
    ''
    Property LayoutDebugName As String ''For debugging. --Added 9/3/2022 td
    Property LayoutDebugDescription As String ''For debugging.--Added 9/3/2022 td

    Function Layout_Width_Pixels() As Integer

    Function Layout_Height_Pixels() As Integer ''Added 9/11/2019 td

    Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer

    Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer

    Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer

    Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer

    ''
    ''Added 9/19/2019 td 
    ''
    ''9/19/2019 td''Sub SetControlBeingModified(par_control As Control)
    Property ControlBeingModified() As Control ''Added 9/19/2019 td 
    Property ControlBeingMoved() As Control ''Added 9/20/2019 td 
    Property ControlThatWasClicked() As Control ''Added 8/31/2022 td 

    Function OkayToShowFauxContextMenu() As Boolean ''Added 9/19/2019 td
    ''
    ''11/29/2021 td''Sub AutoPreview_IfChecked() ''Added 9/19/2019 td 
    ''---Dec6 2021---Sub AutoPreview_IfChecked(Optional par_controlElement As Control = Nothing) ''Added 9/19/2019 td 
    Sub AutoPreview_IfChecked(Optional par_controlElement As Control = Nothing, Optional par_stillMoving As Boolean = False) ''Modified 12/06/2019 td 

    Function RightClickMenu_Parent() As ToolStripMenuItem ''Added 9/19/2019 td 

    Function NameOfForm() As String ''Added 9/19/2019 td 

    Sub RedrawForm() ''Added 9/23/2019 td

End Interface
