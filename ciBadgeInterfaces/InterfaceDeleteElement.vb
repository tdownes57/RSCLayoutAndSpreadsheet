Option Explicit On
Option Strict On
''
''Added 8/15/2022 thomas downes
''
''   This is making use of the Dependency Injection pattern.
''

Public Interface IDeleteElement
    ''
    ''Added 12/27/2021 thomas downes
    ''
    ''   This is making use of the Dependency Injection pattern.
    ''
    ''#1 6/6/2022 Sub RefreshElementImage()
    ''#1 6/6/2022 Sub RefreshElementImage(Optional pbAfterResizingEvent As Boolean = False)
    Sub DeleteElementIfConfirmed()


End Interface

