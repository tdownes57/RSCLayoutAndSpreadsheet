''
''Added 12/25/2023 thomas downes 
''

''' <summary>
''' The purpose of this class is to record the current sort of a column, to enable a sorting "UnDo", by holding the shallow copies of RSC Data Cells, which hold a record of the left-right-adjacent cells.
''' </summary>
Public Class RSCFieldColumn_ShallowCopyForSideLinks

    ''' <summary>
    ''' This is a shallow copy of a RSCData Cell. The left-right-adjacent cells will be links to non-copy RSC Data Cells.
    ''' </summary>
    Private mod_topRSCDataCell As RSCDataCell

    ''' <summary>
    ''' This is a shell version of a RSCData Cell. The left-right-adjacent cells will be links to RSC Data Cells.
    ''' </summary>
    Private mod_topRSCDataCell_Sidelinks As RSCDataCell_SideLinks







End Class
