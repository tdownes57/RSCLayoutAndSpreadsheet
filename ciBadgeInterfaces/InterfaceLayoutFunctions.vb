''
''Added 9/9/2019 td  
''
Imports System.Windows.Forms ''added 9/19/2019 td 

Public Interface ILayoutFunctions
    ''
    ''Added 9/9/2019 td  
    ''
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
    Function OkayToShowFauxContextMenu() As Boolean ''Added 9/19/2019 td 
    Sub AutoPreview_IfChecked() ''Added 9/19/2019 td 

End Interface
