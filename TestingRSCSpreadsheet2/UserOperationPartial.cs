using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSCLibraryDLLOperations;  // Added 8/14/2024 thomas


namespace TestingRSCSpreadsheet2
{
    public partial class UserOperationPartial : UserControl
    {
         //''Added 3/29/2024
        public bool ModeColumns;  // As Boolean //''Columns are arranged horizontally.
        public bool Mode___Rows; // As Boolean //''Rows are arranged vertically.

        //''Added 3/29/2024
        public Color ModeColumns_Color; // As Color //''Columns are arranged horizontally.
        public Color Mode___Rows_Color; // As Color //''Rows are arranged vertically.

        public DLLOperation<TwoCharacter, TwoCharacter> DLLOperationHorizontal; // As DLL_OperationV2
        public DLLOperation<TwoCharacter, TwoCharacter> DLLOperationVertical; // As DLL_OperationV2 ''Added 3/2/2024 td



        //''Added 1/4/2024
        public TwoCharacterDLLItem Lists_Endpoint; // As TwoCharacterDLLItem; //''Added 1/4/2024
        public TwoCharacterDLLItem Lists_Penultimate; // As TwoCharacterDLLItem; //''Added 1/4/2024
        public StructEndPoint Struct_endpoint;  // As StructEndPoint;  ''Added 1/5/2024

    //''Added 12/23/2023
    //''' <summary>
    //''' In case of an UNDO-OF-DELETE operation, we will need to know the
    //''' pre-deletion connecting node(s).  (Obviously, these node are NOT deleted.) 
    //''' </summary>
    Public DLL_InverseAnchor_PriorToRange As TwoCharacterDLLItem = Nothing ''Added 12/23/2023
    //''' <summary>
    //''' In case of an UNDO-OF-DELETE operation, we will need to know the
    //''' pre-deletion connecting node(s).  (Obviously, these node are NOT deleted.) 
    //''' </summary>
    Public DLL_InverseAnchor_NextToRange As TwoCharacterDLLItem = Nothing ''Added 12/23/2023

    //''' <summary>
    //''' This will communicate the details of an INSERT operation, 
    //''' which the user has requested, and which hasn't yet been performed.
    //''' </summary>
    //''' <param name="par_operation">Gives detail of operation.</param>
    //''3/2024 td Public Event DLLOperationCreated_Insert(par_operation As DLL_OperationV1)
    Public Event DLLOperationCreated_Insert(par_operation As DLL_OperationV1)
    Public Event DLLOperationCreated_InsertRow(par_operation As DLL_OperationV1)
    Public Event DLLOperationCreated_InsertCol(par_operation As DLL_OperationV1)

    ''Adde 8/4/2024 td
    Public Event DLLOperationV2_Insert(par_operation As DLLOperation(Of TwoCharacterDLLHorizontal, TwoCharacterDLLVertical),
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)


    Public Event DLLOperationCreated_Delete(par_operation As DLL_OperationV1)

    ''' <summary>
    ''' This will communicate the details of an INSERT operation, 
    ''' which the user has requested, and which hasn't yet been performed.
    ''' </summary>
    ''' <param name="par_operation">Gives detail of operation.</param>
    ''' <param name="par_inverseAnchor_PriorToRange">Needed in case of a later UNDO-OF-DELETE.</param>
    ''' <param name="par_inverseAnchor_NextToRange">Needed in case of a later UNDO-OF-DELETE.</param>
    ''Public Event DLLOperationCreated_Delete(par_operation As DLL_OperationV1,
    ''                            par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
    ''                            par_inverseAnchor_NextToRange As TwoCharacterDLLItem)
    Public Event DLLOperationV1_Delete(par_operation As DLL_OperationV1,
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)

    Public Event DLLOperationV2_Delete(par_operation As DLLOperation(Of TwoCharacterDLLHorizontal, TwoCharacterDLLVertical),
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)

    ''' <summary>
    ''' This will communicate the details of an INSERT operation, 
    ''' which the user has requested, and which hasn't yet been performed.
    ''' </summary>
    ''' <param name="par_operation">Gives detail of operation.</param>
    Public Event DLLOperationCreated_MoveRange(par_operationV1 As DLL_OperationV1,
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)

    ''Added 1/1/2024 thomas
    Public Event DLLOperationCreated_UndoOfInsert(par_operationV1 As DLL_OperationV1,
                                par_isUndoOfInsert As Boolean)
    Public Event DLLOperationCreated_UndoOfDelete(par_operationV1 As DLL_OperationV1,
                                par_isUndoOfDelete As Boolean)
    Public Event DLLOperationCreated_UndoOfMove(par_operation As DLL_OperationV1,
                                par_isUndoOfMove As Boolean)

    ''Added 2/10/2024 thomas
    Public Event DLLOperationCreated_SortAscending(par_operationV1 As DLL_OperationV1,
                                par_isUndoOfSort As Boolean)
    Public Event DLLOperationCreated_SortDescending(par_operationV1 As DLL_OperationV1,
                                par_isUndoOfSort As Boolean)

    ''Added 1/1/2024 thomas
    Public Event UndoOfDelete_NoParams()
    Public Event UndoOfInsert_NoParams()
    Public Event UndoOfMoveRange_NoParams()

    ''Added 1/1/2024 thomas
    Public Event Sort_Ascending()
    Public Event Sort_Descending()

    ''Added 1/01/2024 td
    Private mod_lastPriorOpV2 As DLL_OperationV2 = Nothing ''Added 1/01/2024 td
    Private mod_intCountOperations As Integer = 0 ''Added 1/1/2024



        public UserOperationPartial()
        {
            InitializeComponent();
        }
    }
}
