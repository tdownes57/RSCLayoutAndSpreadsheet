Option Explicit On
Option Strict On
''
''
''Added 10/17/2019 thomas d. 
''
''
Imports ciBadgeDesigner

Public Enum LoopedOperation

    Undetermined

    UnselectHighlighting '' "Unselect all highlighted elements"
    SelectHighlightAll ''   "Select highlight all"

    RemoveAllFromUse   '' "Remove all from use"
    RestoreAllToUsage   '' "Restore all to usage" 

    MakeAllTransparent
    MakeAllOpaque

    RemoveCtlFromDesigner
    SetBackgroundColor
    SetFontSizeAndFamily
    SetTextOffsetEtc
    RefreshFromElementInfo
    RefreshImage
    SavePositionToElement

End Enum ''End of "Public Enum LoopedOperation"

Public Class ClassLoopedOperations
    ''
    ''Added 10/17/2019 thomas d. 
    ''
    Public ListOfControls_Fld As List(Of CtlGraphicFldLabelV3)
    ''Public ListOfControls_All As List(Of IAllElementControlTypes)
    ''Public ListOfControls_NonFld As List(Of INonFieldControls)

    Public Sub PerformLoopedOperation(par_enum As LoopedOperation)
        ''
        ''Added 10/17/2019 thomas d. 
        ''







    End Sub ''End of "Public Sub PerformLoopedOperation(par_enum As LoopedOperation)"

End Class ''Endo fo "Public Class ClassLoopedOperations"




