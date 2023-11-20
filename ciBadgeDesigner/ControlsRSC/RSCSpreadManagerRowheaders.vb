''
'' Added 4/19/2023  
''
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ciBadgeInterfaces
Imports ciBadgeRecipients

Public Class RSCSpreadManagerRowheaders
    Implements IDoublyLinkedList ''Added 11/20/2023 
    ''
    ''Added 4/19/2023  
    ''
    Private mod_controlSpread As RSCFieldSpreadsheet ''Added 4/18/2023 
    Private mod_columnLeftmost As RSCFieldColumnV2
    Private mod_listRowHeaders As RSCRowHeaders ''Added 9/01/2023 thomas downes

    Public Sub New(par_controlSpread As RSCFieldSpreadsheet,
                   par_columnLeftmost As RSCFieldColumnV2,
                   par_listOfRowHeaders As RSCRowHeaders)
        ''
        ''Added 4/18/2023  
        ''
        mod_controlSpread = par_controlSpread
        mod_columnLeftmost = par_columnLeftmost
        ''Added 9/01/2023 
        mod_listRowHeaders = par_listOfRowHeaders

    End Sub ''End of Publice Sub New


    Public Function GetListOfRecipients() As List(Of ClassRecipient)
        ''
        ''Added 8/31/2023  thomas Downes
        ''
        Return mod_listRowHeaders.GetListOfRecipients()


    End Function ''End of ""Public Function GetListOfRecipients() As List(Of ClassRecipient)"" 


    Public Sub ToggleMessage_RowIsEmpty(par_intRowIndex As Integer,
                                        Optional par_bGuaranteeStatus As Boolean = False,
                                        Optional par_bSetRowToEmpty As Boolean = True)
        ''
        ''Added 9/3/2023 
        ''
        mod_controlSpread.ToggleMessage_RowIsEmpty(par_intRowIndex,
                               par_bGuaranteeStatus, par_bSetRowToEmpty)

    End Sub ''End of ""Public Sub ToggleMessage_RowIsEmpty""




End Class
