''
'' Added 12/28/2021 thomas downes 
''
Imports __RSCWindowsControlLibrary ''Added 12/29/2021 thomas

Public Class ClassLastControlTouched
    Implements ILastControlTouched

    Dim mod_ctlLastTouched As MoveableControlVB

    Public Property LastControlTouched As Control Implements ILastControlTouched.LastControlTouched
        ''---Public Property LastControlTouched As MoveableControlVB
        ''---     Implements ILastControlTouched.LastControlTouched
        Get
            ''Throw New NotImplementedException()
            Return mod_ctlLastTouched
        End Get
        Set(value As Control)
            ''Set(value As MoveableControlVB)
            ''Throw New NotImplementedException()
            mod_ctlLastTouched = value
        End Set
    End Property

    ''
    '' Added 12/28/2021 thomas downes 
    ''



End Class
