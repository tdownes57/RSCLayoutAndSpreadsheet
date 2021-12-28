Imports ciBadgeInterfaces

Public Class ClassSaveToModel
    Implements ciBadgeInterfaces.ISaveToModel

    Private mod_saved As Boolean ''Added 12/27/2021 td

    Public Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''Throw New NotImplementedException()
        mod_saved = True ''Added 12/27/2021 thomas downes

    End Sub
End Class
