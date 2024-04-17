''//
''// Added 4/17/2024 thomas downes
''//
Imports ciBadgeInterfaces

Public Class DLLOperationV1(Of TControl_H, TControl_V)
    Inherits DLL_OperationV1
    ''
    ''Added 4/17/2024 td
    ''
    Public InsertItemSingly_H As TControl_H
    Public InsertRangeStart_H As TControl_H ''TControl
    Public InsertRangeEnd_Null_H As TControl_H

    Public InsertItemSingly_V As TControl_V
    Public InsertRangeStart_V As TControl_V ''TControl
    Public InsertRangeEnd_Null_V As TControl_V

    ''
    ''Delete 
    ''
    Public DeleteItemSingly_H As TControl_H
    Public DeleteRangeStart_H As TControl_H ''TControl
    Public DeleteRangeEnd_Null_H As TControl_H

    Public DeleteItemSingly_V As TControl_V
    Public DeleteRangeStart_V As TControl_V ''TControl
    Public DeleteRangeEnd_Null_V As TControl_V

    ''
    ''Move 
    ''
    Public MoveItemSingly_H As TControl_H
    Public MoveRangeStart_H As TControl_H ''TControl
    Public MoveRangeEnd_Null_H As TControl_H

    Public MoveItemSingly_V As TControl_V
    Public MoveRangeStart_V As TControl_V ''TControl
    Public MoveRangeEnd_Null_V As TControl_V



End Class
