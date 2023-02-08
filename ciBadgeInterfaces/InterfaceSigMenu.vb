''
''Added 10/21/2019 td
''

Public Interface ISigMenu
    ''
    ''Added 10/21/2019 td
    ''
    Sub DisplaySigMenu()

    ''
    '' Oops! Interfaces should not contain properties, but rather methods.
    '' ---2/7/2023
    ''
    Property PenEventFile As String

    Property PenWidth As Integer

    Property Personality As Integer

    Property SaveFile As String


    Property SigImageFormat As String

    Property SigLineFile As String

End Interface
