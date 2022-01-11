Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/12/2021 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''----Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 

Public Class Operations_Portrait
    Inherits Operations__Graphic
    Implements ICurrentElement ''Added 12/28/2021 td
    Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement

    ''
    ''Added 1/04/2022 td
    ''

End Class
