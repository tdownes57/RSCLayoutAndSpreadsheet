''
''Added 10/30/2023
''
Imports System.CodeDom
Imports System.Drawing.Text
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Xml.XPath

''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/07/2023 thomas dow_nes 
''-----------------------------------------------------------
Public Class DLL_OperationV1(Of TControlH, TControlV) ''11/2/2023 (Of TControl)
    Inherits DLL_OperationV1_Deprecated
    Implements IDoublyLinkedItem ''DLL_GetItemNext, DLL_GetItemPrior

    ''
    ''Added 4/8/2024 thomas d.
    ''
    ''Public Function DLL_UnboxControl_OfT() As TControl Implements IDoublyLinkedItem(Of TControl).DLL_UnboxControl_OfT
    ''    ''
    ''    ''Added 4/8/2024 thomas d.
    ''    ''
    ''    ''Return MyBase.DLL_UnboxControl()
    ''    Throw New NotImplementedException()

    ''End Function ''END OF ""Public Function DLL_UnboxControl_OfT()""






End Class
