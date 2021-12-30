''
'' Added 12/28/2021 thomas downes 
''
Imports __RSCWindowsControlLibrary ''Added 12/29/2021 thomas

Public Class ClassLastControlTouched
    Implements ILastControlTouched

    ''----Dim mod_ctlLastTouched As MoveableControlVB
    Private mod_ctlLastTouched As Control ''Dec29 2021 td''MoveableControlVB

    Private mod_intCountConsecutiveClicks As Integer ''Added 12/29/2021 td

    Public ReactivateMenu As Boolean ''Added 12/29/2021 td 

    Public Property LastControlTouched As Control Implements ILastControlTouched.LastControlTouched
        ''---Public Property LastControlTouched As MoveableControlVB
        ''---     Implements ILastControlTouched.LastControlTouched
        Get
            ''Throw New NotImplementedException()
            Return mod_ctlLastTouched
        End Get

        Set(value As Control)

            ''Set(value As MoveableControlVB)
            ''---Throw New NotImplementedException()

            ''Dim bTwiceInARow As Boolean ''Dec29 2021 
            ''bTwiceInARow = (value Is mod_ctlLastTouched)

            ''If (bTwiceInARow) Then mod_intCountConsecutiveClicks += 1
            ''If (Not bTwiceInARow) Then mod_intCountConsecutiveClicks = 0

            mod_ctlLastTouched = value

            ''Dec29 ''If (2 <= mod_intCountConsecutiveClicks) Then
            ''If (4 <= mod_intCountConsecutiveClicks) Then
            ''    ReactivateMenu = True
            ''    mod_intCountConsecutiveClicks = 0 ''Reinitialize
            ''Else
            ''    ReactivateMenu = False
            ''End If ''End of "If (2 <= mod_intCountConsecutiveClicks) Then ... Else ..."

        End Set
    End Property

    ''
    '' Added 12/28/2021 thomas downes 
    ''



End Class
