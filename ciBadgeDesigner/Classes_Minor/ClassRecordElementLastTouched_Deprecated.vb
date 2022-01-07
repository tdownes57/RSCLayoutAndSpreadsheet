Option Explicit On
Option Strict On
Imports ciBadgeInterfaces

Public Class ClassRecordElementLastTouched_Deprecated
    Implements IRecordElementLastTouched
    ''
    ''Added 1/4/2022 td 
    ''
    ''    Deprecated. Use a reference to an instance of ClassDesigner, instead of this class. 
    ''
    ''    Deprecated. Use a reference to an instance of ClassDesigner, instead of this class. 
    ''
    ''    Deprecated. Use a reference to an instance of ClassDesigner, instead of this class. 
    ''
    ''    Deprecated. Use a reference to an instance of ClassDesigner, instead of this class. 
    ''
    ''    Deprecated. Use a reference to an instance of ClassDesigner, instead of this class. 
    ''
    ''
    Public Sub RecordElementLastTouched(par_elementMoved As IMoveableElement, par_elementClicked As IClickableElement) Implements IRecordElementLastTouched.RecordElementLastTouched
        Throw New NotImplementedException()
    End Sub

    Public Sub Remove_Moveability(par_elementMoved As IMoveableElement) Implements IRecordElementLastTouched.Remove_Moveability
        Throw New NotImplementedException()
    End Sub

    Public Sub Remove_Clickability(par_elementClicked As IClickableElement) Implements IRecordElementLastTouched.Remove_Clickability
        Throw New NotImplementedException()
    End Sub

    Public Sub Add_Moveability(par_control As Control, par_iSave As ISaveToModel, par_elementMoved As IMoveableElement, par_resizeProportionally As Boolean) Implements IRecordElementLastTouched.Add_Moveability
        Throw New NotImplementedException()
    End Sub

    Public Sub Add_Clickability(par_elementClicked As IClickableElement) Implements IRecordElementLastTouched.Add_Clickability
        Throw New NotImplementedException()
    End Sub
    ''
    ''Added 1/4/2022 td
    ''


End Class
