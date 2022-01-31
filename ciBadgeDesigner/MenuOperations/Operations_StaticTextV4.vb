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
Imports __RSCWindowsControlLibrary ''Added 1/08/2022 thomas d.

Public Class Operations_StaticTextV4
    Inherits Operations__Text
    ''
    ''Added 1/31/2022 td
    ''

    Public Property CtlCurrentElementStaticText As ciBadgeDesigner.CtlGraphicStaticTextV4
    Public Property ElementStaticText As ciBadgeElements.ClassElementStaticTextV3 ''Added 1/19/2022
    Public Property ElementInfo_TextOnly As IElement_TextOnly ''Added 1/19/2022

    Public Overrides Property Element_Type As Enum_ElementType = Enum_ElementType.StaticGraphic ''Added 1/21/2022 td

    Public Property Parent_MenuCache As MenuCache_Generic ''Modified 12/30/2021 td 

    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    ''Added 1/25/2022 td''Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner
    Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    Public Property CacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated

    ''1/18/2022 td''Public Overrides Property CtlCurrentElement As CtlGraphicStaticText




End Class
