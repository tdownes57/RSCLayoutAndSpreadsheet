''
''Added 9/9/2019 td  
''

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

End Interface
