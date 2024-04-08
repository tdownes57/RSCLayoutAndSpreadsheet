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
Public Class DLL_OperationV1 ''11/2/2023 (Of TControl)
    Implements IDoublyLinkedItem ''DLL_GetItemNext, DLL_GetItemPrior
    ''
    ''Added 10/30/2023
    ''
    ''Operations are "forward" ("Redo").
    ''
    ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
    ''
    Public ClassTypeToString As String
    Public ClassTypeToChar As Char ''Added 2/01/2024 td

    Public ModeColumns_notRows As Boolean ''Added 11/14/2023 td
    Public ModeRows____notCols As Boolean ''Added  4/08/2024 td

    ''Needed for consistency checks... 10/30/2023
    ''' <summary>
    ''' Tells us the operations is I(Insert), D(Delete), or M(Move).
    ''' </summary>
    Public OperationType As Char = "?" ''E.g. "I" for Insert, "M" for "Move",
    ''  "D" for "Delete", and "S" for "Sort".

    Public InsertItemSingly As IDoublyLinkedItem ''TControl
    Public InsertRangeStart As IDoublyLinkedItem ''TControl
    Public InsertRangeEnd_Null As IDoublyLinkedItem ''Added 1/06/2024 thomas downes

    ''Added 2/5/2024 
    Public Sort_IsAscending As Boolean
    Public Sort_IsDescending As Boolean
    ''Added 2/12/2024 
    Public Sort_IsByQueue As Boolean
    ''Added 2/05/2024 & 2/12/2024 
    Public Queue_ForPredeterminedSort As Queue(Of IDoublyLinkedItem)
    Public Queue_IfNeededForUndo As Queue(Of IDoublyLinkedItem)

    ''Needed for consistency checks...
    Public InsertCount As Integer ''How many linked TControl objects?

    Public MovedRangeStart As IDoublyLinkedItem ''TControl
    Public MovedCount As Integer ''TControl
    Public IsChangeOfEndpoint As Boolean ''Endpoint impacted, start or end. 12/26/2023

    ''' <summary>
    ''' The Moved Range End is suffixed with _Null because it's optional.
    ''' </summary>
    Public MovedRangeEnd_Null As IDoublyLinkedItem = Nothing ''TControl

    ''I don't like this names. ---11/17/2023
    ''  Public Move_LefthandStart As IDoublyLinkedItem ''TControl
    ''  Public Move_RighthandStart As IDoublyLinkedItem ''TControl
    ''  Public Move_LefthandEnd As IDoublyLinkedItem ''TControl
    ''  Public Move_RighthandEnd As IDoublyLinkedItem ''TControl

    ''We need special properties for the Move-Cut operation. 
    Public MoveCut_PriorToRange As IDoublyLinkedItem ''TControl
    Public MoveCut_NextToRange As IDoublyLinkedItem ''TControl

    ''Let's obey Occam's Razor & so use the "Anchor" properties for the Move-Paste(Insertion) operation. 
    ''   --11/17/2023
    ''  Not needed.  Use AnchorLeftToPrior, instead. 11/17/2023 Public MovePaste_InsertAfterItem As IDoublyLinkedItem ''TControl
    ''  Not needed.  Use AnchorRightTerminal, instead. 11/17/2023 Public MovePaste_InsertBeforeItem As IDoublyLinkedItem ''TControl

    ''
    '' Anchors are in the target list, NOT in the range.
    '' AnchorToPrecede...  will be .Prior to the range-first item (or single item).
    '' At most one(1) anchor will be given, for any given operation.
    '' To anchor both sides, the TControl's Next property will be used.
    '' Anchors DO NOT! refer to the pre-existing state of the operation.
    '' Anchors ARE NOT! referenced in DELETE operations, as they are not applicable.
    '' --11/17/2023 t.do.
    ''
    ''#1 11/17/2023 Public AnchorLeftToPrior As IDoublyLinkedItem ''TControl
    ''#2 Public AnchorToPrecedeItemOrRange As IDoublyLinkedItem ''TControl
    ''' <summary>
    ''' The anchor that will have the item or range immediately downstream. 
    ''' Anchors are in the target list, NOT in the selected range.  
    ''' AnchorToPrecede will be .Prior to the range-start item (or single item).  
    ''' At most one(1) anchor will be given, for any given operation. 
    ''' To anchor both sides, the TControl's Next property will be used.  
    ''' Anchors DO NOT! refer to the pre-existing state of the operation. 
    ''' </summary>
    Public AnchorToPrecedeItemOrRange As IDoublyLinkedItem ''TControl

    ''
    '' Anchors are in the target list, NOT in the range.
    '' AnchorToSucceed... will be .Next to the range-last item (or single item).
    '' At most one(1) anchor will be given, for any given operation.
    '' To anchor both sides, the TControl's Next property will be used.
    '' Anchors DO NOT! refer to the pre-existing state of the operation.
    '' Anchors ARE NOT! referenced in DELETE operations, as they are not applicable.
    '' --11/17/2023 t.do.
    ''
    ''#1 11/17/2023 Public AnchorRightTerminal As IDoublyLinkedItem ''TControl
    ''#2 11/17/2023 Public AnchorToSucceedItemOrRange As IDoublyLinkedItem ''TControl
    ''' <summary>
    ''' The anchor that will have the item or range immediately downstream. 
    ''' Anchors are in the target list, NOT in the selected range.  
    ''' AnchorToSucceed will be .Next to the range-last item (or single item).  
    ''' At most one(1) anchor will be given, for any given operation. 
    ''' To anchor both sides, the TControl's Next property will be used.  
    ''' Anchors DO NOT! refer to the pre-existing state of the operation.
    ''' </summary>
    Public AnchorToSucceedItemOrRange As IDoublyLinkedItem ''TControl

    Public DeleteItemSingly As IDoublyLinkedItem ''TControl
    ''Not needed.Public MovedSingly As TControl

    Public DeleteRangeStart As IDoublyLinkedItem ''TControl
    Public DeleteRangeEnd_Null As IDoublyLinkedItem ''Added 1/06/2024 thomas downes

    ''Needed for consistency checks...
    Public DeleteCount As Integer ''How many linked TControl objects?

    ''--------------ADMINISTRATIVE, POSSIBLY CONFUSING-------------------------
    ''------THESE WILL PROVIDE ANCHORS FOR THE UNDO OPERATION----------------
    ''-----------MAYBE I AM WRONG, I HAVE 85% CONFIDENCE---------------------
    ''
    ''1/2/2024 Public DeleteLocation_ItemPrior As IDoublyLinkedItem ''Added 11/25/2023
    ''1/2/2024 Public DeleteLocation_ItemNext As IDoublyLinkedItem ''Added 11/25/2023
    Public DeleteLocation_ItemPriorToItemOrRange As IDoublyLinkedItem ''Added 11/25/2023
    Public DeleteLocation_ItemNextToItemOrRange As IDoublyLinkedItem ''Added 11/25/2023
    ''We need special properties for the Delete operation. 
    ''Redundant. 1/2/2024 Public Delete_PriorToItemOrRange As IDoublyLinkedItem ''TControl
    ''Redundant. 1/2/2024 Public Delete_NextToItemOrRange As IDoublyLinkedItem ''TControl
    ''-----------------------------------------------------------------------

    ''Added 1/1/2024 thomas downes
    Public CreatedAsUndoOperation As Boolean ''Added 1/1/2024 thomas downes
    Public CreatedAsRedoOperation As Boolean ''Added 1/16/2024 thomas downes

    ''Added 1/02/2024 
    Public InverseAnchor_Preceding As IDoublyLinkedItem
    Public InverseAnchor_Following As IDoublyLinkedItem

    ''' <summary>
    ''' This won't be in use, as this is an operation vs. a list item. --2/27/2024
    ''' </summary>
    ''' <returns></returns>
    Public Property Selected As Boolean Implements IDoublyLinkedItem.Selected

    ''
    ''Doubly-Linked List!!!  ---11/14/2023 
    ''
    Private mod_operationPrior As DLL_OperationV1 ''Added 11/14/2023 
    Private mod_operationNext As DLL_OperationV1 ''Added 11/14/2023 

    ''' <summary>
    ''' Default constructor.
    ''' </summary>
    Public Sub New()

        ''12/17/2023
        Me.OperationType = "?"c

    End Sub

    ''' <summary>
    ''' Uncle Bob (R.C. Martin) says that the best functions have no parameters.
    ''' So let's add a constructor, so we can cut down on parameters on other 
    ''' methods.  This object can be passed as a parameter.
    ''' </summary>
    Public Sub New(p_opType As Char, p_firstInRange As IDoublyLinkedItem,
                   p_intCountOfItems As Integer,
                   p_anchorFinalPrior As IDoublyLinkedItem,
                   p_anchorFinalNext As IDoublyLinkedItem)
        ''
        ''Added 12/7/2023  
        ''
        '' Uncle Bob (R.C. Martin) says that the best functions have no parameters.
        '' So let's add a constructor, so we can cut down on parameters on other 
        '' methods.  This object can be passed as a parameter.

        Me.OperationType = p_opType

        If (p_opType = "D"c) Then

            Me.DeleteCount = p_intCountOfItems
            Me.DeleteRangeStart = p_firstInRange
            If (Me.DeleteCount = 1) Then
                Me.DeleteRangeStart = Nothing
                Me.DeleteItemSingly = p_firstInRange
            End If

        ElseIf (p_opType = "I"c) Then

            Me.InsertCount = p_intCountOfItems
            Me.InsertRangeStart = p_firstInRange
            If (Me.InsertCount = 1) Then
                Me.InsertRangeStart = Nothing
                Me.InsertItemSingly = p_firstInRange
            End If

            Me.AnchorToPrecedeItemOrRange = p_anchorFinalPrior
            Me.AnchorToSucceedItemOrRange = p_anchorFinalNext

        End If



    End Sub ''end of ""Public Sub New""

    ''' <summary>
    ''' This creates the "Undo" version of the class-object operation.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUndoVersionOfOperation(Optional pbTestIdempotence As Boolean = False) As DLL_OperationV1 ''11/2/2023 (Of TControl)
        ''
        ''Added 10/30/2023
        ''
        Dim result_newUndoOperation As New DLL_OperationV1() ''11/2/2023 (Of TControl)
        Dim originalOp As DLL_OperationV1 = Me ''12/30/2023

        ''The following are Move(M)-related. 
        Dim tempControlLeft_PreCut As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
        Dim tempControlLeft_PostPaste As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
        Dim tempControlRight_PreCut As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
        Dim tempControlRight_Postpaste As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td

        ''Added 1/18/2024 td
        ''  Calling this "Undo" function implies we have already executed once. 
        ''
        If (pbTestIdempotence) Then
            ''Don't check the endpoints, the check will fail. ---2/18/2024
        Else
            Const AFTER_EXECUTION As Boolean = True
            ''Check the endpoints don't have "dangling" (extraneous, unneeded) references.
            CheckEndpointsAreClean(True, False, AFTER_EXECUTION)
        End If ''Endof ""If (pbTestIdempotence) Then... Else..."

        With result_newUndoOperation ''With objUndo

            ''11/2023 .LefthandAnchor = Me.LefthandAnchor
            ''11/2023 .RighthandAnchor = Me.RighthandAnchor
            ''11/17/2023 .AnchorLeftToPrior = Me.AnchorLeftToPrior
            ''--01/02/2024 .AnchorToPrecedeItemOrRange = originalOp.AnchorToPrecedeItemOrRange
            ''11/17/2023 .AnchorRightTerminal = Me.AnchorRightTerminal
            ''--01/02/2024 .AnchorToSucceedItemOrRange = originalOp.AnchorToSucceedItemOrRange

            ''Added 1/02/2024
            .AnchorToPrecedeItemOrRange = originalOp.InverseAnchor_Preceding
            .AnchorToSucceedItemOrRange = originalOp.InverseAnchor_Following
            ''Added 1/02/2024
            .IsChangeOfEndpoint = originalOp.IsChangeOfEndpoint

            If (originalOp.InsertItemSingly IsNot Nothing) Then
                ''
                ''OperationType "I" (Insert) is the likely input.
                ''
                ''Create an "Delete Singly" opertion (for our Undo op).
                ''
                If (originalOp.OperationType <> "I") Then Debugger.Break()

                .DeleteItemSingly = originalOp.InsertItemSingly ''The "Me." prefix matters.
                .DeleteCount = 1 ''originalOp.InsertCount ''Added 12/29/2023 td
                .DeleteRangeStart = Nothing ''Probably not needed.
                .InsertItemSingly = Nothing ''Important, remove ANY vestigial reference.  (Already Null, but good practice.)
                ''
                ''OperationType - Undo "I"(Insert) with "D"(Delete).
                ''
                If (originalOp.OperationType <> "I"c) Then Debugger.Break()
                .OperationType = "D" '' "D"(Delete) is the Undo-ing of "I"(Insert).

                ''Added 12/30/2023 
                .DeleteLocation_ItemPriorToItemOrRange = originalOp.AnchorToPrecedeItemOrRange
                .DeleteLocation_ItemNextToItemOrRange = originalOp.AnchorToSucceedItemOrRange
                .AnchorToPrecedeItemOrRange = Nothing
                .AnchorToSucceedItemOrRange = Nothing

            ElseIf (originalOp.DeleteItemSingly IsNot Nothing) Then
                ''
                ''OperationType "D"(Delete) is the likely input.
                ''
                ''Create an "Insert Singly" opertion (for our Undo op).
                ''
                .InsertItemSingly = originalOp.DeleteItemSingly ''The "Me." prefix matters.
                .InsertCount = 1 ''originalOp.InsertCount ''Added 12/29/2023 td
                .DeleteItemSingly = Nothing ''Let's remove ANY vestigial reference.  (Already Null, but good practice.)
                .DeleteRangeStart = Nothing ''Probably not needed.
                .InsertRangeStart = Nothing ''Probably not needed.
                ''
                ''OperationType - Undo "D"(Delete) with "I"(Insert).
                ''
                If (originalOp.OperationType <> "D"c) Then Debugger.Break()
                .OperationType = "I" '' "I"(Insert) is the Undo-ing of "D"(Delete)

                ''Added 12/30/2023 
                .AnchorToPrecedeItemOrRange = originalOp.DeleteLocation_ItemPriorToItemOrRange
                .AnchorToSucceedItemOrRange = originalOp.DeleteLocation_ItemNextToItemOrRange
                .DeleteLocation_ItemPriorToItemOrRange = Nothing ''Me.AnchorToPrecedeItemOrRange
                .DeleteLocation_ItemNextToItemOrRange = Nothing ''Me.AnchorToSucceedItemOrRange


            ElseIf (originalOp.InsertRangeStart IsNot Nothing) Then
                ''
                ''OperationType "I" (Insert) is the likely input.
                ''
                ''Create an "Delete Range" operation (for our Undo op).
                ''
                .DeleteRangeStart = originalOp.InsertRangeStart ''The "Me." prefix matters.
                .DeleteCount = originalOp.InsertCount ''Added 12/29/2023 td
                .InsertRangeStart = Nothing ''Let's remove ANY vestigial reference. (Already Null, but good practice.)
                .InsertItemSingly = Nothing ''Probably not needed.
                .DeleteItemSingly = Nothing ''Probably not needed.
                ''
                ''OperationType - Undo "I"(Insert) with "D"(Delete).
                ''
                If (originalOp.OperationType <> "I"c) Then Debugger.Break()
                .OperationType = "D" '' "D"(Delete) is the Undo-ing of "I"(Insert).

                ''Added 11/17/2023 td
                ''  The "Anchor" properties are no longer to be used for delete operations.
                ''  I have added the properties ".Delete_PriorToItemOrRange"
                ''  and ".Delete_
                ''11/17/2023 .Delete_PriorToItemOrRange = .AnchorLeftToPrior
                ''11/17/2023 .Delete_NextToItemOrRange = .AnchorRightTerminal
                ''11/17/2023 .AnchorLeftToPrior = Nothing
                ''11/17/2023 .AnchorRightTerminal = Nothing
                .DeleteLocation_ItemPriorToItemOrRange = originalOp.AnchorToPrecedeItemOrRange
                .DeleteLocation_ItemNextToItemOrRange = originalOp.AnchorToSucceedItemOrRange
                .AnchorToPrecedeItemOrRange = Nothing
                .AnchorToSucceedItemOrRange = Nothing

            ElseIf (originalOp.DeleteRangeStart IsNot Nothing) Then
                ''
                ''OperationType "D"(Delete) is the likely input.
                ''
                ''Create an "Insert Range" operation (for our Undo op).
                ''
                .InsertRangeStart = originalOp.DeleteRangeStart ''The "Me." prefix matters.
                .InsertCount = originalOp.DeleteCount ''Added 12/29/2023 td
                .DeleteRangeStart = Nothing ''Let's remove ANY vestigial reference. (Already Null, but good practice.)
                .DeleteItemSingly = Nothing ''Probably not needed.
                .InsertItemSingly = Nothing ''Probably not needed.
                ''
                ''OperationType - Undo "D"(Delete) with "I"(Insert).
                ''
                If (originalOp.OperationType <> "D"c) Then Debugger.Break()
                .OperationType = "I" '' "I"(Insert) is the Undo-ing of "D"(Delete)

                ''Added 12/30/2023 
                .AnchorToPrecedeItemOrRange = originalOp.DeleteLocation_ItemPriorToItemOrRange
                .AnchorToSucceedItemOrRange = originalOp.DeleteLocation_ItemNextToItemOrRange
                .DeleteLocation_ItemPriorToItemOrRange = Nothing ''Me.AnchorToPrecedeItemOrRange
                .DeleteLocation_ItemNextToItemOrRange = Nothing ''Me.AnchorToSucceedItemOrRange


            ElseIf (originalOp.MovedRangeStart IsNot Nothing) Then
                ''
                ''OperationType "M" (Move) is the likely input.
                ''
                ''OperationType - Undo " M"(Move) with another "M"(Move).
                ''
                If (originalOp.OperationType <> "M"c) Then Debugger.Break()
                .OperationType = "M" '' M for Move.

                ''Add 1/02/2024 
                .MovedCount = originalOp.MovedCount
                .MovedRangeStart = originalOp.MovedRangeStart

                ''Initialize to Nothing. --1/2/2024
                .AnchorToPrecedeItemOrRange = Nothing ''originalOp.InverseAnchor_Preceding
                .AnchorToSucceedItemOrRange = Nothing ''originalOp.InverseAnchor_Following

                ''Per //, the Move-Paste(Insert) operation will leverage the Anchor properties. 
                ''                    ---11/17/2023
                ''//Lefthand side 
                ''//tempControlL = Me.Move_LefthandStart ''The "Me." prefix matters.
                ''//.Move_LefthandStart = Me.Move_LefthandEnd ''The "Me." prefix matters.
                ''//.Move_LefthandEnd = tempControlL
                ''//''Righthand side 
                ''//tempControlR = Me.Move_RighthandStart ''The "Me." prefix matters.
                ''//.Move_RighthandStart = Me.Move_RighthandEnd ''The "Me." prefix matters.
                ''//.Move_RighthandEnd = tempControlR

                '',Dim tempControlL As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
                '',Dim tempControlR As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
                '',''Lefthand, or "Prior", side 
                '',tempControlL = Me.MoveCut_PriorToRange ''The "Me." prefix matters.
                '',.MoveCut_PriorToRange = Me.AnchorToPrecedeItemOrRange ''The "Me." prefix matters.
                '',.AnchorToPrecedeItemOrRange = tempControlL
                '',''Righthand, or "Next" side 
                '',tempControlR = Me.MoveCut_NextToRange ''The "Me." prefix matters.
                '',.MoveCut_NextToRange = Me.AnchorToSucceedItemOrRange ''The "Me." prefix matters.
                '',.AnchorToSucceedItemOrRange = tempControlR

                ''
                ''The "L"("Prior")-suffix side, i.e. "ItemPrior" (Column to the L(Left)) side. 
                ''
                ''top of proc Dim tempControlLeft_PreCut As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
                ''top of proc Dim tempControlLeft_PostPaste As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td

                ''Get references from the Operiginal Operation.
                tempControlLeft_PreCut = originalOp.GetMoveRangeItemPrior_PreCut()
                tempControlLeft_PostPaste = originalOp.GetMoveRangeItemPrior_PostPaste()

                ''
                ''---- DIFFICULT AND CONFUSING-----
                ''Next, we perform the "Undo Switcheroo" (LOL)
                ''
                If (tempControlLeft_PostPaste IsNot Nothing) Then
                    .SetMoveRangeItemPrior_PreCut(tempControlLeft_PostPaste) ''Reverse P.C. with P.P.
                End If
                If (tempControlLeft_PreCut IsNot Nothing) Then
                    .SetMoveRangeItemPrior_PostPaste(tempControlLeft_PreCut) ''Reverse P.P. with P.C.
                End If
                ''Not needed 1/2/2024 ''tempControlLeft_PostPaste = Nothing ''Clear it, not needed now.
                ''Not needed 1/2/2024 ''tempControlLeft_PreCut = Nothing ''Clear it, not needed now.

                ''
                ''The "R"("Next")-suffix side, i.e. "Righthand" ("ItemNext") (Column to the Right) side. 
                ''
                ''top of proc Dim tempControlRight_PreCut As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
                ''top of proc Dim tempControlRight_Postpaste As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td

                ''Get references from the Operiginal Operation.
                tempControlRight_PreCut = originalOp.GetMoveRangeItemNext_PreCut()
                tempControlRight_Postpaste = originalOp.GetMoveRangeItemNext_PostPaste()

                ''---- DIFFICULT AND CONFUSING-----
                ''Next, we perform the "Undo Switcheroo" (LOL)
                ''
                If (tempControlRight_Postpaste IsNot Nothing) Then
                    .SetMoveRangeItemNext_PreCut(tempControlRight_Postpaste) ''Undo (reversal)... Reverse P.C. with P.P.
                End If
                If (tempControlRight_PreCut IsNot Nothing) Then
                    .SetMoveRangeItemNext_PostPaste(tempControlRight_PreCut) ''Undo (reversal)... Reverse P.P. with P.C.
                End If

                ''Not needed 1/2/2024 ''tempControlRight_PP = Nothing ''Clear it, not needed now.
                ''Not needed 1/2/2024 ''tempControlRight_PC = Nothing ''Clear it, not needed now.

            ElseIf (originalOp.OperationType = "S"c) Then
                ''
                ''Sorting
                ''
                ''Added 2/12/2024 thomas downes
                ''-#1--.SetSortOperationOrder(Me.Sort_IsAscending, Me.Sort_IsDescending)
                ''-#1--result_sortingOperation = New DLL_OperationV1()
                ''--#2--.SetSortOperationOrder(Me.Sort_IsAscending, Me.Sort_IsDescending)
                .SetSortingOperationOrder(Me.Sort_IsAscending, Me.Sort_IsDescending,
                                           True, Me.Queue_IfNeededForUndo)

            End If ''End of ""If (Me.InsertedSingly IsNot Nothing) Then... ElseIf..."

            ''Added 1/03/2024 tdownes
            .CreatedAsUndoOperation = True

        End With ''End of ""With result_newUndoOperation""

        ''Added 1/18/2024 td
        ''---result_newUndoOperation.CheckEndpointsAreClean()
        Const BEFORE_EXECUTION As Boolean = True ''If the Undo operation is an Undo of an Insert, 
        ''  and is therefore effectively a Delete, then we have performed the Insert but we have 
        ''  not yet performed the Delete--therefore, the Delete is BEFORE_EXECUTION.
        ''  ---1/20/2024 td
        If (pbTestIdempotence) Then
            ''We don't check endpoints if we are checking for idempotence.
            ''  That's because, it's a testing operation vs. a production 
            ''  operation... therefore we are NOT executing a "Do" operation
            ''  and then (later) executing an "Undo" operation.  
            ''Rather, we are testing in the absence of excecution.
            ''  ---2/18/2024 td
            ''
        Else
            result_newUndoOperation.CheckEndpointsAreClean(True, BEFORE_EXECUTION)
        End If ''End of ""If (pbTestIdempotence) Then... Else..."

        Return result_newUndoOperation ''Return objUndo

    End Function ''End of ""Public Function GetUndoVersion() As DLL_Operation(Of TControl)""


    ''
    ''Will the anchor-item be placed as the range-first item's .DLL_ItemPrior,
    ''  after it's been moved or inserted? (Succeed means follow.)
    ''
    ''' <summary>
    ''' Will the anchor-item be placed as the range-first item's .DLL_ItemPrior, after it's been inserted (or moved)?
    ''' </summary>
    ''' <returns></returns>
    Public Function AnchorWillPrecedeRangeOrItem() As Boolean
        ''---Public Function AnchorIs_LeftToPrevious() As Boolean
        ''Added 11/17/2023 
        ''
        ''  ---- Computer-Science-friendly -----
        ''  This "ToPrevious" suffix indicates that the anchor
        ''  will be the range-first item's .DLL_ItemPrior,
        ''  after it's been moved or inserted...
        ''  assuming that the function returns True, of course.
        ''  --11/2023 td 
        ''
        ''If (AnchorLeftToPrior IsNot Nothing) Then
        If (AnchorToPrecedeItemOrRange IsNot Nothing) Then
            If (AnchorToSucceedItemOrRange Is Nothing) Then
                Return True
            Else
                Debugger.Break()
            End If

        ElseIf (IsForDelete()) Then

            If (DeleteLocation_ItemPriorToItemOrRange IsNot Nothing) Then
                If (DeleteLocation_ItemNextToItemOrRange Is Nothing) Then
                    Return True
                Else
                    Debugger.Break()
                End If
            Else
                If (DeleteLocation_ItemNextToItemOrRange IsNot Nothing) Then
                    Return False
                Else
                    Debugger.Break()
                End If
            End If ''enD OF ""If (Delete_PriorToItemOrRange IsNot Nothing) Then""

        End If ''End of ""If (AnchorLeftToPrior IsNot Nothing) Then""

        Return False

    End Function ''End of ""Public Function AnchorWillPrecedeRangeOrItem()""

    ''
    ''Will the anchor-item be placed as the range-last item's .DLL_NextItem,
    ''  after it's been moved or inserted? (Succeed means follow.)
    ''
    ''' <summary>
    ''' Will the anchor-item be placed as the range-last item's .DLL_NextItem, after it's been moved or inserted? (Succeed means follow.)
    ''' </summary>
    ''' <returns></returns>
    Public Function AnchorWillSucceedRangeOrItem() As Boolean
        ''---Public Function AnchorIs_RightToTerminate() As Boolean
        ''Added 11/17/2023 
        ''
        ''  ---- Computer-Science-friendly -----
        ''  This "ToTerminate" suffix should evoke languages such as 
        ''  C++ and Python, in which ranges are end-exclusive, 
        ''  e.g. (currentIndex < endingIndex) is a loop condition. 
        ''  --11/2023 td 
        ''
        If (AnchorToSucceedItemOrRange IsNot Nothing) Then
            If (AnchorToPrecedeItemOrRange Is Nothing) Then
                Return True
            Else
                Debugger.Break()
            End If
        End If
        Return False
    End Function ''End of ""Public Function AnchorWillSucceedRangeOrItem()""


    Public Function AnchorIs_Missing() As Boolean
        ''Added 11/17/2023 
        ''
        If (AnchorToPrecedeItemOrRange Is Nothing) Then
            If (AnchorToSucceedItemOrRange Is Nothing) Then

                Return True

            End If ''If (AnchorToSucceedItemOrRange Is Nothing) Then
        End If ''If (AnchorToPrecedeItemOrRange Is Nothing) Then

        Return False

    End Function ''ENd of ""Public Function AnchorIs_Missing() As Boolean""


    Public Function ItemIs_HandledSingly() As Boolean
        ''
        ''Added 11/17/2023  
        ''
        ''  (Move Operations are --NOT-- processed via any single-item 
        ''    procedure, they are only processed as ranges with a count
        ''    of one (or more).---11/17/2023) 
        ''
        If (InsertItemSingly IsNot Nothing) Then
            ''
            ''Insert operations
            ''
            If (InsertRangeStart Is Nothing) Then
                If (DeleteRangeStart Is Nothing) Then
                    ''Everything is copacetic.  
                    Return True
                Else
                    Debugger.Break()
                End If
            Else
                Debugger.Break()
            End If

        ElseIf (DeleteItemSingly IsNot Nothing) Then
            ''
            ''Insert operations
            ''
            If (InsertRangeStart Is Nothing) Then
                If (DeleteRangeStart Is Nothing) Then
                    ''Everything is copacetic.  
                    Return True
                Else
                    Debugger.Break()
                End If
            Else
                Debugger.Break()
            End If

        ElseIf (MovedRangeStart IsNot Nothing) Then
            ''  (Move Operations are --NOT-- processed via any single-item 
            ''    procedure, they are only processed as ranges with a count
            ''    of one (or more).---11/17/2023) 
            Return False

        Else
            Debugger.Break()
        End If

        Debugger.Break()
        Return False

    End Function ''End of ""Public Function ItemIs_HandledSingly() As Boolean()


    Public Function IsForRangeOfItems() As Boolean
        ''
        ''For simplicity, let's negate the contrasting function.--11/17/2023  
        ''
        Return (Not ItemIs_HandledSingly())

    End Function ''End of ""Public Function IsForRangeOfItems() As Boolean""


    Public Function IsForDelete() As Boolean
        ''
        ''Is this a delete operation?   (Move operations are 100% _NOT_ delete operations,
        ''     and move operations don't contain "Delete" operations.  Move operations
        ''     start with a "Cut" sub-operation.)
        ''
        If (Testing.TestingByDefault) Then
            If ((OperationType = "D") <> (DeleteRangeStart IsNot Nothing _
                Or DeleteItemSingly IsNot Nothing)) Then
                Debugger.Break()
            End If
        End If ''End of ""If (Testing.TestingByDefault) Then""

        Return (OperationType = "D")

    End Function ''End of ""Public Function IsForRangeOfItems() As Boolean""


    Public Function IsClassTypeByChar(par_charType As Char) As Boolean

        ''Added 2/02/2024
        Dim result_match As Boolean
        result_match = (Me.ClassTypeToChar = par_charType)
        Return result_match

    End Function ''Public Function IsClassTypeByChar


    Public Function GetMoveRangeItemNext_PreCut() As IDoublyLinkedItem
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        Dim bPreCut_RangePrior As Boolean ''Added 1/2/2024
        Dim bPreCut_RangeNext As Boolean ''Added 1/2/2024
        bPreCut_RangePrior = (MoveCut_PriorToRange IsNot Nothing)
        bPreCut_RangeNext = (MoveCut_NextToRange IsNot Nothing)
        Dim bPreCut_Both As Boolean ''Added 1/2/2024
        bPreCut_Both = (bPreCut_RangePrior And bPreCut_RangeNext)
        Dim bBothAreNonnull_MayBeSubtleError As Boolean ''Added 1/2/2024
        bBothAreNonnull_MayBeSubtleError = bPreCut_Both

        If (bBothAreNonnull_MayBeSubtleError) Then
            ''We don't want both Following & Preceding to be NON-NULL.  
            Dim bInverseFollowing As Boolean = (InverseAnchor_Following IsNot Nothing)
            Dim bInversePreceding As Boolean = (InverseAnchor_Preceding IsNot Nothing)
            Dim bInverseBoth As Boolean = (bInverseFollowing And bInversePreceding)
            If (bInverseBoth) Then
                Const NOT_BOTH As Boolean = False ''Let's turn this check/warning OFF. ---1/10/2024
                If (NOT_BOTH And Testing.TestingByDefault) Then
                    Debugger.Break()
                End If ''End of ""If (NOT_BOTH And Testing.TestingByDefault) Then""
            End If ''ENd of ""If (bInverseBoth) Then""

            ''This is a function, after all!
            Return InverseAnchor_Following

        Else
            Return MoveCut_NextToRange

        End If ''End of ""If (bMayBeSubtleError) Then ... Else...""

    End Function ''End of ""Public Function GetMoveRangeItemNext_PreCut()""


    Public Function GetMoveRangeItemPrior_PreCut() As IDoublyLinkedItem
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        ''May be problematic. 1/2/2024 Return MoveCut_PriorToRange
        Return InverseAnchor_Preceding

    End Function ''End of ""Public Function GetMoveRangeItemPrior_PreCut()""


    Public Function GetMoveRangeItemNext_PostPaste() As IDoublyLinkedItem
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        Return AnchorToSucceedItemOrRange

    End Function


    Public Function GetMoveRangeItemPrior_PostPaste() As IDoublyLinkedItem
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        Return AnchorToPrecedeItemOrRange

    End Function ''Public Function GetMoveRangeItemPrior_PostPaste()


    Public Sub SetMoveRangeItemNext_PreCut(par_item As IDoublyLinkedItem)
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        If (par_item Is Nothing) Then Debugger.Break()

        MoveCut_NextToRange = par_item

    End Sub ''Public Sub SetMoveRangeItemNext_PreCut


    Public Sub SetMoveRangeItemPrior_PreCut(par_item As IDoublyLinkedItem)
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        If (par_item Is Nothing) Then Debugger.Break()
        MoveCut_PriorToRange = par_item

    End Sub ''End of ""Public Sub SetMoveRangeItemPrior_PreCut""


    Public Sub SetMoveRangeItemNext_PostPaste(par_item As IDoublyLinkedItem)
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        If (par_item Is Nothing) Then Debugger.Break()
        AnchorToSucceedItemOrRange = par_item

    End Sub ''Endof ""Public Sub SetMoveRangeItemNext_PostPaste""


    Public Sub SetMoveRangeItemPrior_PostPaste(par_item As IDoublyLinkedItem)
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        If (par_item Is Nothing) Then Debugger.Break()
        AnchorToPrecedeItemOrRange = par_item

    End Sub ''End of ""Public Sub SetMoveRangeItemPrior_PostPaste""


    Public Sub SetSortingOperationOrder(pboolAscending As Boolean, pboolDescending As Boolean,
                      pboolSortByQueue_ForUndo As Boolean,
                      Optional par_queueForSorting As Queue(Of IDoublyLinkedItem) = Nothing)
        ''
        ''Added 2/12/2024 thomas downes
        ''
        Me.OperationType = "S"c ''The character 'S' is for Sorting.
        Me.Sort_IsAscending = pboolAscending
        Me.Sort_IsDescending = pboolDescending

        ''
        ''For Undo Operations
        ''
        ''   ("Sort by Queue" = "Sort by the Same Queue that was created,
        ''       just prior to an Ascending or Descending Sort Operation
        ''       was execuated").
        ''
        Me.Sort_IsByQueue = pboolSortByQueue_ForUndo

        If (pboolSortByQueue_ForUndo) Then
            ''Added 2/18/2024 thomas downes
            Dim queueForSorting_Copy As Queue(Of IDoublyLinkedItem)

            If (par_queueForSorting Is Nothing) Then
                Diagnostics.Debugger.Break()
            End If ''End of ""If (par_queueForSorting Is Nothing) Then""

            ''Feb18 2024  Me.Sort___ByQueue = par_queueForSorting
            ''---Me.Queue_ForPredeterminedSort = par_queueForSorting
            queueForSorting_Copy = New Queue(Of IDoublyLinkedItem)(par_queueForSorting)
            Me.Queue_ForPredeterminedSort = queueForSorting_Copy

        End If ''ENd of ""If (pboolSortByQueue_ForUndo) Then""

    End Sub ''End of ""Public Sub SetSortingOperationOrder""


    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem) Implements IDoublyLinkedItem.DLL_SetItemNext
        ''Throw New NotImplementedException()
        mod_operationNext = param
    End Sub

    Public Sub DLL_SetItemPrior(param As IDoublyLinkedItem) Implements IDoublyLinkedItem.DLL_SetItemPrior
        ''Throw New NotImplementedException()
        mod_operationPrior = param
    End Sub

    Public Sub DLL_ClearReferencePrior(par_opType As Char) Implements IDoublyLinkedItem.DLL_ClearReferencePrior
        ''Throw New NotImplementedException()
        Debugger.Break() ''Shouldn't be needed. 
        mod_operationPrior = Nothing
    End Sub

    Public Sub DLL_ClearReferenceNext(par_opType As Char) Implements IDoublyLinkedItem.DLL_ClearReferenceNext
        ''Throw New NotImplementedException()
        Debugger.Break() ''Shouldn't be needed. 
        mod_operationNext = Nothing
    End Sub

    Public Function DLL_NotAnyNext() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyNext
        ''11/2023 Throw New NotImplementedException()
        Dim bNextIsNothing As Boolean
        bNextIsNothing = (mod_operationNext Is Nothing)
        Return bNextIsNothing
    End Function

    Public Function DLL_NotAnyPrior() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyPrior
        ''11/2023 Throw New NotImplementedException()
        Dim bPriorIsNothing As Boolean
        bPriorIsNothing = (mod_operationPrior Is Nothing)
        Return bPriorIsNothing
    End Function


    Public Function DLL_IsEitherEndpoint() As Boolean Implements IDoublyLinkedItem.DLL_IsEitherEndpoint
        ''12/24/2023 Throw New NotImplementedException()
        Dim bConnectsToNothing As Boolean
        bConnectsToNothing = (mod_operationPrior Is Nothing OrElse mod_operationNext Is Nothing)
        Return bConnectsToNothing

    End Function ''Public Function DLL_IsEitherEndpoint()


    Public Function DLL_HasNext() As Boolean Implements IDoublyLinkedItem.DLL_HasNext
        Dim bNextIsSomething As Boolean ''12/17/2023
        bNextIsSomething = (mod_operationNext IsNot Nothing)
        Return bNextIsSomething
    End Function

    Public Function DLL_HasPrior() As Boolean Implements IDoublyLinkedItem.DLL_HasPrior
        Dim bPriorIsSomething As Boolean ''12/17/2023
        bPriorIsSomething = (mod_operationPrior IsNot Nothing)
        Return bPriorIsSomething
    End Function


    Public Function DLL_GetItemNext() As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemNext
        ''11/2023 td''Throw New NotImplementedException()
        Return mod_operationNext

    End Function

    Public Function DLL_GetItemPrior() As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemPrior
        ''11/2023 td''Throw New NotImplementedException()
        Return mod_operationPrior

    End Function


    Public Function DLL_GetValue() As String Implements IDoublyLinkedItem.DLL_GetValue

        ''Added 1/5/2024 
        ''  Not applicable!
        ''Return "N/A"
        Return OperationType.ToString()

    End Function


    ''' <summary>
    ''' Get item following a range (if the implicit parameter is the first item in a range). Sometimes we need the Item which follows the Range, to prepare for a possible Undo.
    ''' </summary>
    ''' <param name="param_rangeSize">This is the item-count of the range, or size of the range.</param>
    ''' <returns>The first item which follows the range.</returns>
    Public Function DLL_GetNextItemFollowingRange(param_rangeSize As Integer, param_mayBeNull As Boolean) As IDoublyLinkedItem _
        Implements IDoublyLinkedItem.DLL_GetNextItemFollowingRange

        ''Added 12/30/2023 
        ''---DIFFICULT AND CONFUSING---
        ''  By CS-related rules of iteration, by moving ahead
        ''  a number of jumps equal to the item-count of the range,
        ''  we get the first post-range item.
        ''                  ---12/30/2023 tdownes
        ''12/2023 Return DLL_GetItemNext(param_rangeSize)

        Dim result As IDoublyLinkedItem
        result = DLL_GetItemNext(param_rangeSize)

        ''Check for Nulls!
        If ((Not param_mayBeNull) AndAlso result Is Nothing) Then
            Debugger.Break()
        End If

        Return result

    End Function ''DLL_GetNextItemFollowingRange


    ''
    ''Important, check for equality.
    ''
    Private Overloads Function Equals_Redundant(lets_check As DLL_OperationV1) As Boolean ''11/2/2023 (Of TControl)) As Boolean
        ''Private Overloads Function Equals_Redundant(lets_check As DLL_OperationV1) As Boolean
        ''Private Function Equals(lets_check As TControl) As Boolean
        ''
        ''This will check the Idempotency of a Undo(Undo()), i.e.
        ''   double-Undo.
        ''
        Dim boolEqual1 As Boolean
        Dim boolEqual2 As Boolean
        Dim boolEqual3 As Boolean
        Dim boolEqual4 As Boolean
        Dim boolEqual5 As Boolean
        Dim boolEqual6 As Boolean
        Dim boolEqual7 As Boolean
        Dim boolEqual8 As Boolean
        Dim boolEqual9 As Boolean

        Dim boolEqual91 As Boolean
        Dim boolEqual92 As Boolean
        Dim boolEqual93 As Boolean
        Dim boolEqual94 As Boolean
        ''Dim boolEqual95 As Boolean

        ''Added 11/17/2023  
        Dim boolEqual96 As Boolean
        Dim boolEqual97 As Boolean
        Dim boolEqual98 As Boolean
        Dim boolEqual99 As Boolean

        With lets_check

            boolEqual1 = (.ClassTypeToString = Me.ClassTypeToString)
            boolEqual2 = (.DeleteCount = Me.DeleteCount)
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual3 = ((.DeleteRangeStart Is Nothing) = (Me.DeleteRangeStart Is Nothing))
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual4 = ((.DeleteItemSingly Is Nothing) = (Me.DeleteItemSingly Is Nothing))
            boolEqual5 = (.InsertCount = Me.InsertCount)
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual6 = ((.InsertRangeStart Is Nothing) = (Me.InsertRangeStart Is Nothing))
            boolEqual7 = ((.InsertItemSingly Is Nothing) = (Me.InsertItemSingly Is Nothing))

            ''boolEqual8 = ((.LefthandAnchor Is Nothing) = (Me.LefthandAnchor Is Nothing))
            ''boolEqual9 = ((.RighthandAnchor Is Nothing) = (Me.RighthandAnchor Is Nothing))
            boolEqual8 = ((.AnchorToPrecedeItemOrRange Is Nothing) = (Me.AnchorToPrecedeItemOrRange Is Nothing))
            boolEqual9 = ((.AnchorToSucceedItemOrRange Is Nothing) = (Me.AnchorToSucceedItemOrRange Is Nothing))

            boolEqual91 = (.MovedCount = Me.MovedCount)
            ''boolEqual92 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))
            ''boolEqual93 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))
            ''boolEqual94 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))
            ''boolEqual95 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))
            boolEqual92 = ((.MoveCut_NextToRange Is Nothing) = (Me.MoveCut_NextToRange Is Nothing))
            boolEqual93 = ((.MoveCut_PriorToRange Is Nothing) = (Me.MoveCut_PriorToRange Is Nothing))
            boolEqual94 = ((.MovedRangeStart Is Nothing) = (Me.MovedRangeStart Is Nothing))

            ''Added 11/17/20 23  
            boolEqual96 = (.AnchorWillPrecedeRangeOrItem() = Me.AnchorWillPrecedeRangeOrItem())
            boolEqual97 = (.AnchorWillSucceedRangeOrItem() = Me.AnchorWillSucceedRangeOrItem())
            boolEqual98 = (.ItemIs_HandledSingly() = Me.ItemIs_HandledSingly())
            boolEqual99 = (.IsForRangeOfItems() = Me.IsForRangeOfItems())

        End With ''End of ""With lets_check""

        Dim bEqual1to5 As Boolean
        Dim bEqual6to9 As Boolean
        ''Dim bEqual91to95 As Boolean
        Dim bEqual91to94 As Boolean
        ''Added 11/17/2023  
        Dim bEqual96to99 As Boolean

        bEqual1to5 = (boolEqual1 And boolEqual2 And boolEqual3 And
                      boolEqual4 And boolEqual5)
        bEqual6to9 = (boolEqual6 And boolEqual7 And boolEqual8 And boolEqual9)
        ''bEqual91to95 = (boolEqual91 And boolEqual92 And boolEqual93 And
        ''                     boolEqual94 And boolEqual95)
        bEqual91to94 = (boolEqual91 And boolEqual92 And boolEqual93 And boolEqual94)

        ''Added 11/17/2023  
        bEqual96to99 = ((boolEqual96 And boolEqual97) And
                        (boolEqual98 And boolEqual99))

        Dim bEqual_All As Boolean
        ''bEqual_All = (bEqual1to5 And bEqual6to9 And bEqual91to95)
        bEqual_All = (bEqual1to5 And bEqual6to9 And
                     (bEqual91to94 And bEqual96to99))
        ''           (bEqual91to95 And bEqual96to99))

        Return bEqual_All

    End Function ''End of Private Function Overrides Equals_Redundant() as Boolean


    Private Function Undo2x_IsIdempotent(lets_check As DLL_OperationV1) As Boolean
        ''
        ''This will check the Idempotency of a Undo(Undo()), i.e.
        ''   double-Undo.
        ''
        Dim objUndo_1st As DLL_OperationV1 ''11/2/2023 (Of TControl)
        Dim objUndo_2nd As DLL_OperationV1 ''11/2/2023 (Of TControl)

        objUndo_1st = lets_check.GetUndoVersionOfOperation()
        objUndo_2nd = objUndo_1st.GetUndoVersionOfOperation()

        Dim boolEqualMatch As Boolean

        boolEqualMatch = lets_check.Equals(objUndo_2nd)
        Return boolEqualMatch

    End Function ''End of ""Private Function Undo2x_IsIdempotent""


    Public Function DLL_GetItemNext(param_iterationsOfNext As Integer) As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()

        ''Added 11/25/2023 td
        Dim result As IDoublyLinkedItem = mod_operationNext ''--Nothing ''--mod_operationNext

        If (param_iterationsOfNext = 0) Then
            System.Diagnostics.Debugger.Break()
            Return Me
        ElseIf (param_iterationsOfNext = 1) Then
            Return result
        ElseIf (param_iterationsOfNext > 1) Then
            For index = 2 To param_iterationsOfNext
                If (result IsNot Nothing) Then
                    result = result.DLL_GetItemNext()
                End If
            Next index
            Return result
        End If

        System.Diagnostics.Debugger.Break()
        Return Nothing ''Not needed.

    End Function ''Public Function DLL_GetItemNext(param_iterationsOfNext As Integer)


    Public Function DLL_GetItemPrior(param_iterationsOfPrior As Integer) As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemPrior

        ''11/2023 Throw New NotImplementedException()
        ''Added 11/25/2023 td
        Dim result As IDoublyLinkedItem = mod_operationPrior ''--Nothing ''--mod_operationNext

        If (param_iterationsOfPrior = 0) Then
            System.Diagnostics.Debugger.Break()
            Return Me
        ElseIf (param_iterationsOfPrior = 1) Then
            Return result
        ElseIf (param_iterationsOfPrior > 1) Then
            For index = 2 To param_iterationsOfPrior
                If (result IsNot Nothing) Then
                    result = result.DLL_GetItemPrior()
                End If
            Next index
            Return result
        End If

        System.Diagnostics.Debugger.Break()
        Return Nothing ''Not needed.

    End Function ''Public Function DLL_GetItemPrior(param_iterationsOfNext As Integer)


    ''' <summary>
    ''' Not implemented for Operations, so don't use. (See list(s) of controls, for usage.)
    ''' </summary>
    ''' <returns></returns>
    Public Function DLL_UnboxControl() As Control Implements IDoublyLinkedItem.DLL_UnboxControl
        ''
        '' Won't be implemented, this class describes an Operation (upon Controls),
        ''   not simply a Control.  12/01/2023 td
        ''
        Throw New NotImplementedException()

    End Function ''end of ""Public Function DLL_UnboxControl()""


    Public Overloads Function Equals(lets_check As DLL_OperationV1) As Boolean
        ''12/2023 Private Overloads Function Equals(lets_check As DLL_Operation(Of TControl)) As Boolean
        ''   Private Function Equals(lets_check As TControl) As Boolean
        ''
        ''This will check the Idempotency of a Undo(Undo()), i.e.
        ''   double-Undo.
        ''
        Dim boolEqual1 As Boolean
        Dim boolEqual2 As Boolean
        Dim boolEqual3 As Boolean
        Dim boolEqual4 As Boolean
        Dim boolEqual5 As Boolean
        Dim boolEqual6 As Boolean
        Dim boolEqual7 As Boolean
        Dim boolEqual8 As Boolean
        Dim boolEqual9 As Boolean

        Dim boolEqual91 As Boolean
        Dim boolEqual92 As Boolean
        Dim boolEqual93 As Boolean
        Dim boolEqual94 As Boolean
        ''Dim boolEqual95 As Boolean

        With lets_check

            boolEqual1 = (.ClassTypeToString = Me.ClassTypeToString)
            boolEqual2 = (.DeleteCount = Me.DeleteCount)

            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual3 = ((.DeleteRangeStart Is Nothing) = (Me.DeleteRangeStart Is Nothing))
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual4 = ((.DeleteItemSingly Is Nothing) = (Me.DeleteItemSingly Is Nothing))
            boolEqual5 = (.InsertCount = Me.InsertCount)
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual6 = ((.InsertRangeStart Is Nothing) = (Me.InsertRangeStart Is Nothing))
            boolEqual7 = ((.InsertItemSingly Is Nothing) = (Me.InsertItemSingly Is Nothing))

            ''12/2023  boolEqual8 = ((.LefthandAnchor Is Nothing) = (Me.LefthandAnchor Is Nothing))
            ''12/2023  boolEqual9 = ((.RighthandAnchor Is Nothing) = (Me.RighthandAnchor Is Nothing))
            boolEqual8 = ((.AnchorToPrecedeItemOrRange Is Nothing) =
                        (Me.AnchorToPrecedeItemOrRange Is Nothing))
            boolEqual9 = ((.AnchorToSucceedItemOrRange Is Nothing) =
                        (Me.AnchorToSucceedItemOrRange Is Nothing))

            boolEqual91 = (.MovedCount = Me.MovedCount)
            ''boolEqual92 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))
            ''boolEqual93 = ((.Move_RighthandEnd Is Nothing) = (Me.Move_RighthandEnd Is Nothing))

            boolEqual92 = ((.MovedRangeStart Is Nothing) = (Me.MovedRangeStart Is Nothing))
            boolEqual93 = ((.MoveCut_PriorToRange Is Nothing) = (Me.MoveCut_PriorToRange Is Nothing))
            boolEqual94 = ((.MoveCut_NextToRange Is Nothing) = (Me.MoveCut_PriorToRange Is Nothing))

        End With ''End of ""With lets_check""

        Dim bEqual1to5 As Boolean
        Dim bEqual6to9 As Boolean
        ''Dim bEqual91to95 As Boolean
        Dim bEqual91to94 As Boolean

        bEqual1to5 = (boolEqual1 And boolEqual2 And boolEqual3 And
                      boolEqual4 And boolEqual5)
        bEqual6to9 = (boolEqual6 And boolEqual7 And boolEqual8 And boolEqual9)
        bEqual91to94 = (boolEqual91 And boolEqual92 And boolEqual93 And
                          boolEqual94) ''boolEqual94 And boolEqual95)

        Dim bEqual_All As Boolean
        ''bEqual_All = (bEqual1to5 And bEqual6to9 And bEqual91to95)
        bEqual_All = (bEqual1to5 And bEqual6to9 And bEqual91to94)

        Return bEqual_All

    End Function ''End of Private Function Overrides Equals() as Boolean


    Public Function GetCopyV2() As DLL_OperationV2
        ''
        ''Added 12/28/2023 
        ''
        Dim result As DLL_OperationV2 = Nothing

        Select Case Me.OperationType

            Case "D"c
                ''
                ''Deletion of a range or item.
                ''
                If (Me.DeleteRangeStart IsNot Nothing) Then
                    ''
                    ''Deleting a range.
                    ''
                    result = New DLL_OperationV2(Me.OperationType, Me.DeleteRangeStart, Me.DeleteCount,
                                                 Nothing, Nothing, Me.IsChangeOfEndpoint)
                    ''                       Delete_PriorToItemOrRange, Delete_NextToItemOrRange,
                    ''                       Me.IsChangeOfEndpoint)

                ElseIf (Me.DeleteItemSingly IsNot Nothing) Then
                    ''
                    ''Deleting an item.
                    ''
                    Const JUST_ONE As Integer = 1
                    result = New DLL_OperationV2(Me.OperationType, Me.DeleteItemSingly, JUST_ONE,
                                                 Nothing, Nothing, Me.IsChangeOfEndpoint)
                    ''                       Delete_PriorToItemOrRange, Delete_NextToItemOrRange,
                    ''                       Me.IsChangeOfEndpoint)
                Else
                    Debugger.Break()

                End If

            Case "I"c
                ''
                ''Insertion of a range (of perhaps a count of 1 item?).
                ''
                If (Me.InsertRangeStart IsNot Nothing) Then
                    ''
                    ''Inserting a range.
                    ''
                    result = New DLL_OperationV2(Me.OperationType, Me.InsertRangeStart, Me.InsertCount,
                                                Me.AnchorToPrecedeItemOrRange,
                                                Me.AnchorToSucceedItemOrRange, Me.IsChangeOfEndpoint)

                ElseIf (Me.InsertItemSingly IsNot Nothing) Then
                    ''
                    ''Inserting an item.
                    ''
                    Const JUST_ONE As Integer = 1
                    result = New DLL_OperationV2(Me.OperationType, Me.InsertItemSingly, JUST_ONE,
                                                 Me.AnchorToPrecedeItemOrRange,
                                                 Me.AnchorToSucceedItemOrRange,
                                                 Me.IsChangeOfEndpoint)

                Else
                    Debugger.Break()

                End If ''End of ""If (Me.InsertRangeStart IsNot Nothing) Then... ElseIf... Else..."

            Case "M"c
                ''
                ''Moving a range of items. 
                ''
                result = New DLL_OperationV2(Me.OperationType, Me.MovedRangeStart, Me.MovedCount,
                                                Me.AnchorToPrecedeItemOrRange,
                                                Me.AnchorToSucceedItemOrRange,
                                                Me.IsChangeOfEndpoint)

            Case Else
                Debugger.Break()

        End Select ''End of ""Select Case Me.OperationType""

        Return result

    End Function ''End of ""Public Function GetCopyV2() As DLL_OperationV2""

    ''Private Function DLL_GetValue() As String Implements IDoublyLinkedItem.DLL_GetValue
    ''    Throw New NotImplementedException()
    ''End Function

    Public Function DLL_CountItemsAllInList() As Integer Implements IDoublyLinkedItem.DLL_CountItemsAllInList
        ''Throw New NotImplementedException()
        Const COUNT_MYSELF As Integer = 1
        Dim countPriorItems As Integer ''= 0
        Dim countNextItems As Integer ''= 0
        countPriorItems = DLL_CountItemsPrior()
        countNextItems = DLL_CountItemsNext()
        Return (countPriorItems + COUNT_MYSELF + countNextItems)

    End Function ''End of ""Public Function DLL_CountItemsAllInList()""


    Public Function DLL_GetIndex() As Integer

        ''Added 1/13/2024 td 
        Dim result_index As Integer

        ''Consider the base case, the very first item.
        ''  There are zero(0) prior items.
        ''  Also, the index is zero(0)...
        ''  (in C++, C#, Java, Python, etc.).
        ''
        Const ADJUSTMENT As Integer = 0
        result_index = (DLL_CountItemsPrior() + ADJUSTMENT)
        Return result_index

    End Function ''End of ""Public Function DLL_GetIndex() As Integer""


    ''' <summary>
    ''' This is called by DLL_CountItemsAllInList, to assist in counting all linked items.
    ''' </summary>
    ''' <returns>How many times can we call DLL_HasItemPrior() and get a result of True?</returns>
    Private Function DLL_CountItemsPrior() As Integer Implements IDoublyLinkedItem.DLL_CountItemsPrior
        ''Throw New NotImplementedException()
        Dim result_count As Integer = 0
        Dim temp As IDoublyLinkedItem = Me.DLL_GetItemPrior
        While temp IsNot Nothing
            result_count += 1
            temp = temp.DLL_GetItemPrior()
        End While ''End of ""While temp IsNot Nothing""
        Return result_count

    End Function ''End of ""Private Function DLL_CountItemsPrior()""


    ''' <summary>
    ''' This is called by DLL_CountItemsAllInList, to assist in counting all linked items.
    ''' </summary>
    ''' <returns>How many times can we call DLL_HasItemNext() and get a result of True?</returns>
    Private Function DLL_CountItemsNext() As Integer ''Implements IDoublyLinkedItem.DLL_CountItemsNext
        ''Throw New NotImplementedException()
        Dim result_count As Integer = 0
        Dim temp As IDoublyLinkedItem = Me.DLL_GetItemNext
        While temp IsNot Nothing
            result_count += 1
            temp = temp.DLL_GetItemNext()
        End While ''End of ""While temp IsNot Nothing""
        Return result_count
    End Function ''End of ""Public Function DLL_CountItemsNext()""


    ''' <summary>
    ''' Check the endpoints don't have "dangling" (extraneous, unneeded) references.
    ''' </summary>
    ''' <param name="pbConditionally"></param>
    ''' <param name="pbBeforeExecution"></param>
    ''' <param name="pbAfterExecution"></param>
    Public Sub CheckEndpointsAreClean(pbConditionally As Boolean,
                                      Optional pbBeforeExecution As Boolean = False,
                                      Optional pbAfterExecution As Boolean = False,
                                      Optional pbPleaseCleanIfNeeded As Boolean = False)
        ''Check the endpoints don't have "dangling" (extraneous, unneeded) references.
        ''Added 1/18/2024 td  
        ''
        Dim bProceedWithCheck_InsertRange As Boolean ''Added 1/20/2024 
        Dim bProceedWithCheck_DeleteRange As Boolean ''Added 1/20/2024 

        ''
        ''Step #1 of 2 -- Create Booleans for Branching.
        ''
        If (pbConditionally) Then
            ''Check the Optional parameters.
            bProceedWithCheck_InsertRange = pbBeforeExecution
            bProceedWithCheck_DeleteRange = pbAfterExecution
        Else
            ''The parameter is false, so we are proceeding unconditionally.
            ''Unconditionally means, the parameters pbBeforeExecution
            ''   & pbAfterExecution are considered moot, i.e. are to be
            ''   ignored (as a code-branching mechanism).
            bProceedWithCheck_InsertRange = (Not pbConditionally)
            bProceedWithCheck_DeleteRange = (Not pbConditionally)
        End If ''End of ""If (pbConditionally) Then... Else..."

        ''
        ''Step #2a of 2 -- Insert Range or Insert Single Item
        ''
        If (bProceedWithCheck_InsertRange) Then
            If (InsertRangeStart IsNot Nothing) Then

                ''Check the Insert Range.
                If InsertRangeStart.DLL_HasPrior() Then

                    Debugger.Break()
                    ''Added 1/31/2024 
                    If (pbPleaseCleanIfNeeded) Then
                        InsertRangeStart.DLL_ClearReferencePrior("I"c)
                    End If ''End of ""If (pbPleaseCleanIfNeeded) Then""

                End If ''End of ""If InsertRangeStart.DLL_HasPrior() Then""

            ElseIf (InsertItemSingly IsNot Nothing) Then

                ''Added 1 /31/2024 thomas downes 
                ''----2/22/2024 Debugger.Break()
                ''Added 1/31/2024 
                If (pbPleaseCleanIfNeeded And pbBeforeExecution) Then
                    InsertItemSingly.DLL_ClearReferencePrior("I"c)
                End If ''End of ""If (pbPleaseCleanIfNeeded And pbBeforeExecution) Then""

            End If ''End of ""If (InsertRangeStart IsNot Nothing) Then ... ElseIf...""
        End If ''end of ""If (bProceedWithCheck_InsertRange) Then""

        ''
        ''Step #2b of 2 -- Delete Range or Delete Item Single 
        ''
        If (bProceedWithCheck_DeleteRange) Then
            ''1/31/2024 If (DeleteRangeStart IsNot Nothing And pbAfterExecution) Then

            ''Check the Delete Range.
            If (DeleteRangeStart IsNot Nothing) Then
                If DeleteRangeStart.DLL_HasPrior() Then
                    Debugger.Break()

                    ''Added 1/31/2024 
                    If (pbPleaseCleanIfNeeded And pbAfterExecution) Then
                        DeleteRangeStart.DLL_ClearReferencePrior("D"c)
                    End If ''End of ""If (pbPleaseCleanIfNeeded) Then""

                End If ''End of ""If DeleteRangeStart.DLL_HasPrior() Then""

            ElseIf (DeleteItemSingly IsNot Nothing) Then

                ''Added 1/31/2024 thomas downes 
                ''----02/22/2024 Debugger.Break()
                ''Added 1/31/2024 
                If (pbPleaseCleanIfNeeded And pbAfterExecution) Then
                    DeleteItemSingly.DLL_ClearReferencePrior("I"c)
                End If ''End of ""If (pbPleaseCleanIfNeeded And pbAfterExecution) Then""

            End If ''End of ""If (DeleteRangeStart IsNot Nothing) Then ...ElseIf...""
        End If ''end of ""If (bProceedWithCheck_DeleteRange) Then""

        ''If (MovedRangeStart IsNot Nothing) Then
        ''    If MovedRangeStart.DLL_HasPrior() Then
        ''        Debugger.Break()
        ''    End If
        ''End If

    End Sub ''End of ""Public Sub CheckEndpointsAreClean()"



End Class
