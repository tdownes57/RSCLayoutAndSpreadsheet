
Option Explicit On
Option Strict On
Option Infer Off

''
''Added 3/13/2022 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 
Imports ciBadgeCachePersonality ''Added 1/18/2022 td
Imports System.Drawing ''Added 1/26/2022 td

''
'' Added 3/13/2022 thomas downes
''
Public Class Operations_FieldSpreadsheet
    Implements ICurrentElement ''Added 3/19/2022 td
    Implements IRightClickMouseInfo ''Added 3/19/2022 td

    ''
    ''Added 3/29/2022 td
    ''
    Public Property Element_Type As Enum_ElementType = Enum_ElementType.FieldSheetColumn ''Added 1/21/2022 td

    ''Added 1/25/2022 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner ''Added 1/25/2022 td

    Public Property EventsForMoveability_Single As GroupMoveEvents_Singleton ''Suffixed 1/11/2022 Added 1/3/2022 td 
    Public Property EventsForMoveability_Group As GroupMoveEvents_Singleton ''Added 1/11/2022 td 
    Public Property LayoutFunctions As ILayoutFunctions ''Added 1/4/2022 td

    Public Property CtlCurrentControl As Control ''---Implements ICurrentElement.CtlCurrentElement


    Public Overridable Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property ElementsCacheManager As ciBadgeCachePersonality.ClassCacheManagement Implements ICurrentElement.ElementsCacheManager

    ''Added 2/05/2022 td
    Public Property MouseclickX As Integer Implements IRightClickMouseInfo.MouseclickX
    Public Property MouseclickY As Integer Implements IRightClickMouseInfo.MouseclickY
    Public Property ParentSpreadsheet As RSCFieldSpreadsheet ''Added 3/20/2022 td
    Public Property ColumnIndex As Integer ''Added 3/20/2022 td


End Class
