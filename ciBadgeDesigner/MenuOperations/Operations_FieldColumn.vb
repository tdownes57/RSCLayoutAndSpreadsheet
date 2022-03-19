
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
Public Class Operations_FieldColumn
    Implements ICurrentElement ''Added 3/19/2022 td
    Implements IRightClickMouseInfo ''Added 3/19/2022 td

    Public Overridable Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property ElementsCacheManager As ciBadgeCachePersonality.ClassCacheManagement Implements ICurrentElement.ElementsCacheManager

    ''Added 2/05/2022 td
    Public Property MouseclickX As Integer Implements IRightClickMouseInfo.MouseclickX
    Public Property MouseclickY As Integer Implements IRightClickMouseInfo.MouseclickY


    Public Sub Clear_Data_From_Column_FC2001(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         





    End Sub




End Class
