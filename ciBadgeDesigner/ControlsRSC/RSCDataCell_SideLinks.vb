
''
''Added 12/25/2023 thomas downes 
''

''' <summary>
''' The purpose of this class is to assist in a sorting "UnDo", by hold a record of the left-right-adjacent cells.
''' </summary>
Public Class RSCDataCell_SideLinks

    Private mod_dataCell As RSCDataCell
    Private mod_dataCell_ToTheLeft As RSCDataCell
    Private mod_dataCell_ToTheRight As RSCDataCell

    ''As a singly-linked list, we need a link to the next item in the column.
    Private mod_dataCell_NextBelow As RSCDataCell_SideLinks


End Class
