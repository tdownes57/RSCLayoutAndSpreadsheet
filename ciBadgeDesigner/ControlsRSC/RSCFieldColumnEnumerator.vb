''
''Added 5/8/2023
''
''Links:
'' https://dotnetcodr.com/2017/11/15/implementing-an-enumerator-for-a-custom-object-in-net-c-3/
'' https://www.dotnetperls.com/ienumerable-vbnet
'' https://learn.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/control-flow/walkthrough-implementing-ienumerable-of-t
''

Public Class RSCFieldColumnEnumerator
    Implements IEnumerator(Of RSCFieldColumnV2)

    Private disposedValue As Boolean
    Private mod_columnCurrent As RSCFieldColumnV2 ''Added 5/8/2023 
    Private mod_columnFirst As RSCFieldColumnV2 ''Added 5/8/2023 

    Public Sub New(par_columnFirst As RSCFieldColumnV2)

        mod_columnFirst = par_columnFirst

    End Sub

    Public ReadOnly Property Current As RSCFieldColumnV2 Implements IEnumerator(Of RSCFieldColumnV2).Current
        Get
            ''Throw New NotImplementedException()
            Return mod_columnCurrent
        End Get
    End Property

    Private ReadOnly Property IEnumerator_Current As Object Implements IEnumerator.Current
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Sub Reset() Implements IEnumerator.Reset
        ''Throw New NotImplementedException()
        mod_columnCurrent = Nothing
    End Sub

    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        Throw New NotImplementedException()
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
