Imports ciBadgeInterfaces
''
''Added 12/28/2021 thomas downes
''

Public Class ClassSaveToModel
    Implements ciBadgeInterfaces.ISaveToModel
    ''
    ''Added 12/28/2021 thomas downes
    ''
    Private mod_datetimeSaved As DateTime ''Added 12/28/2021 td 

    Public Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''Throw New NotImplementedException()
        mod_datetimeSaved = DateTime.Now ''Added 12/28/2021 td 

    End Sub

End Class
