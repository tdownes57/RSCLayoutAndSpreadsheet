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
    ''
    ''Added 5/8/2023
    ''
    ''Links:
    '' https://dotnetcodr.com/2017/11/15/implementing-an-enumerator-for-a-custom-object-in-net-c-3/
    '' https://www.dotnetperls.com/ienumerable-vbnet
    '' https://learn.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/control-flow/walkthrough-implementing-ienumerable-of-t
    ''
    Private disposedValue As Boolean
    Private mod_columnCurrent As RSCFieldColumnV2 ''Added 5/8/2023 
    Private mod_columnFirstLeft As RSCFieldColumnV2 ''Added 5/8/2023 

    Public Sub New(par_columnFirst As RSCFieldColumnV2)
        ''
        ''Added 5/8/2023
        ''
        mod_columnFirstLeft = par_columnFirst
        mod_columnCurrent = Nothing ''Added 5/9/2023 

    End Sub ''End of ""Public Sub New(par_columnFirst As RSCFieldColumnV2)""


    Public ReadOnly Property Current As RSCFieldColumnV2 Implements IEnumerator(Of RSCFieldColumnV2).Current
        ''
        ''Added 5/8/2023
        ''
        Get
            ''Throw New NotImplementedException()
            Return mod_columnCurrent
        End Get
    End Property

    Private ReadOnly Property IEnumerator_Current As Object Implements IEnumerator.Current
        ''
        ''Added 5/8/2023
        ''
        Get
            ''Throw New NotImplementedException()
            Return mod_columnCurrent
        End Get
    End Property


    Public Sub Reset() Implements IEnumerator.Reset
        ''
        ''Added 5/8/2023
        ''
        ''Throw New NotImplementedException()
        mod_columnCurrent = Nothing

    End Sub


    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        ''
        ''Added 5/9/2023
        ''
        ''Throw New NotImplementedException()

        If (mod_columnCurrent Is Nothing) Then

            mod_columnCurrent = mod_columnFirstLeft
            Return True ''mod_columnCurrent

        Else

            Dim bNotDone As Boolean
            mod_columnCurrent = mod_columnCurrent.FieldColumnNextRight
            bNotDone = (mod_columnCurrent IsNot Nothing)
            Return bNotDone ''True ''mod_columnCurrent

        End If ''End of""If (mod_columnCurrent Is Nothing) Then... Else...""

    End Function ''End of ""Public Function MoveNext() As Boolean""


    Protected Overridable Sub Dispose(disposing As Boolean)
        ''
        ''Auto-generated code, 5/8/2023
        ''
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ''
    ''Auto-generated code, 5/8/2023
    ''
    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ''
        ''Auto-generated code, 5/8/2023
        ''
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

End Class
