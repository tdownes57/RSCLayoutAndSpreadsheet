Option Explicit On
Option Strict On
''
''Added 1/26/2022 thomas downes
''
''   This is making use of the Dependency Injection pattern.
''

Public Interface IRefreshElementImage
    ''
    ''Added 12/27/2021 thomas downes
    ''
    ''   This is making use of the Dependency Injection pattern.
    ''
    ''#1 6/6/2022 Sub RefreshElementImage()
    ''#1 6/6/2022 Sub RefreshElementImage(Optional pbAfterResizingEvent As Boolean = False)
    ''
    '' Well done! Interfaces should not contain properties, but rather methods.
    ''    (Analogously, classes should expose methods, not properties.)  
    '' ---2/07/2023 tcd
    ''
    Sub RefreshElementImage(Optional pbAfterResizingHeight As Boolean = False)


End Interface
