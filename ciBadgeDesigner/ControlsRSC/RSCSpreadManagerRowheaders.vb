''
'' Added 4/19/2023  
''
Public Class RSCSpreadManagerRowheaders
    ''
    ''Added 4/19/2023  
    ''
    Private mod_controlSpread As RSCFieldSpreadsheet ''Added 4/18/2023 
    Private mod_columnLeftmost As RSCFieldColumnV2

    Public Sub New(par_controlSpread As RSCFieldSpreadsheet,
                   par_columnLeftmost As RSCFieldColumnV2)
        ''
        ''Added 4/18/2023  
        ''
        mod_controlSpread = par_controlSpread
        mod_columnLeftmost = par_columnLeftmost


    End Sub ''End of Publice Sub New


End Class
