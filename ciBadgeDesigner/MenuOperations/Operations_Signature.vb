Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/12/2021 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''----Imports ciBadgeElements
Imports System.Windows.Forms ''Added 12/30/2021 td
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 thomas d. 


Public Class Operations_Signature
    Inherits Operations__Graphic
    ''Jan17 2022 ''Implements ICurrentElement ''Added 12/28/2021 td

    ''Jan17 2022 ''Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    ''
    ''Added 12/12/2021 td
    ''
    Public Overrides Property Element_Type As Enum_ElementType = Enum_ElementType.Signature ''Added 1/21/2022 td




End Class
