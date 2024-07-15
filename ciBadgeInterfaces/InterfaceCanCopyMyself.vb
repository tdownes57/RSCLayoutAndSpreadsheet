
Public Interface InterfaceCanCopyMyself(Of TClass)

    ''
    '' Check for circularity
    ''
    Function GetCopyOfMe() As TClass

End Interface


Public Class ClassCanCopyMyself1
    Implements InterfaceCanCopyMyself(Of ClassCanCopyMyself1)

    Public Function GetCopyOfMe() As ClassCanCopyMyself1 _
        Implements InterfaceCanCopyMyself(Of ClassCanCopyMyself1).GetCopyOfMe

        ''This is a shallow copy.  
        Return Me

    End Function


End Class


Public Class ClassCanCopyMyself2
    Implements InterfaceCanCopyMyself(Of ClassCanCopyMyself2)

    Private _someNumber As Integer

    Public Function GetCopyOfMe() As ClassCanCopyMyself2 _
        Implements InterfaceCanCopyMyself(Of ClassCanCopyMyself2).GetCopyOfMe

        ''This is a shallow copy.  
        ''Return Me

        ''This is a deep copy.
        Dim objResult As New ClassCanCopyMyself2
        objResult._someNumber = Me._someNumber
        Return objResult

    End Function


End Class


