''
''Added 10/30/2023
''
Imports System.Drawing.Text
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Xml.XPath

Public Class DLL_Operation ''11/2/2023 (Of TControl)
    Implements IDoublyLinkedItem ''DLL_GetItemNext, DLL_GetItemPrior
    ''
    ''Added 10/30/2023
    ''
    ''Operations are "forward" ("Redo").
    ''
    Public ClassTypeToString As String
    Public ModeColumnsNotRows As Boolean ''Added 11/14/2023 td

    ''Needed for consistency checks... 10/30/2023
    ''' <summary>
    ''' Tells us the operations is I(Insert), D(Delete), or M(Move).
    ''' </summary>
    Public OperationType As Char = "?" ''E.g. "I" for Insert, "M" for "Move", "D" is Delete

    Public ItemInsertSingly As IDoublyLinkedItem ''TControl
    Public ItemDeleteSingly As IDoublyLinkedItem ''TControl
    ''Not needed.Public MovedSingly As TControl

    Public DeleteRangeStart As IDoublyLinkedItem ''TControl
    ''Needed for consistency checks...
    Public DeleteCount As Integer ''How many linked TControl objects?

    ''--------------ADMINISTRATIVE, POSSIBLY CONFUSING-------------------------
    ''------THESE WILL PROVIDE ANCHORS FOR THE UNDO OPERATION----------------
    ''-----------MAYBE I AM WRONG, I HAVE 85% CONFIDENCE---------------------
    ''
    Public DeleteLocation_ItemPrior As IDoublyLinkedItem ''Added 11/25/2023
    Public DeleteLocation_ItemNext As IDoublyLinkedItem ''Added 11/25/2023
    ''-----------------------------------------------------------------------

    Public InsertRangeStart As IDoublyLinkedItem ''TControl
    ''Needed for consistency checks...
    Public InsertCount As Integer ''How many linked TControl objects?

    Public MovedRangeStart As IDoublyLinkedItem ''TControl
    Public MovedCount As Integer ''TControl

    ''I don't like this names. ---11/17/2023
    ''  Public Move_LefthandStart As IDoublyLinkedItem ''TControl
    ''  Public Move_RighthandStart As IDoublyLinkedItem ''TControl
    ''  Public Move_LefthandEnd As IDoublyLinkedItem ''TControl
    ''  Public Move_RighthandEnd As IDoublyLinkedItem ''TControl

    ''We need special properties for the Move-Cut operation. 
    Public MoveCut_PriorToRange As IDoublyLinkedItem ''TControl
    Public MoveCut_NextToRange As IDoublyLinkedItem ''TControl

    ''We need special properties for the Delete operation. 
    Public Delete_PriorToItemOrRange As IDoublyLinkedItem ''TControl
    Public Delete_NextToItemOrRange As IDoublyLinkedItem ''TControl

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
    ''' Anchors are in the target list, NOT in the range.  AnchorToPrecede will be .Prior to the range-start item (or single item).  At most one(1) anchor will be given, for any given operation. To anchor both sides, the TControl's Next property will be used.  Anchors DO NOT! refer to the pre-existing state of the operation. 
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
    ''' Anchors are in the target list, NOT in the range.  AnchorToSucceed will be .Next to the range-last item (or single item).  At most one(1) anchor will be given, for any given operation. To anchor both sides, the TControl's Next property will be used.  Anchors DO NOT! refer to the pre-existing state of the operation.
    ''' </summary>
    Public AnchorToSucceedItemOrRange As IDoublyLinkedItem ''TControl

    ''
    ''Doubly-Linked List!!!  ---11/14/2023 
    ''
    Private mod_operationPrior As DLL_Operation ''Added 11/14/2023 
    Private mod_operationNext As DLL_Operation ''Added 11/14/2023 

    ''' <summary>
    ''' This creates the "Undo" version of the class-object operation.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUndoVersionOfOperation() As DLL_Operation ''11/2/2023 (Of TControl)
        ''
        ''Added 10/30/2023
        ''
        Dim objUndo As New DLL_Operation ''11/2/2023 (Of TControl)

        With objUndo

            ''11/2023 .LefthandAnchor = Me.LefthandAnchor
            ''11/2023 .RighthandAnchor = Me.RighthandAnchor
            ''11/17/2023 .AnchorLeftToPrior = Me.AnchorLeftToPrior
            .AnchorToPrecedeItemOrRange = Me.AnchorToPrecedeItemOrRange
            ''11/17/2023 .AnchorRightTerminal = Me.AnchorRightTerminal
            .AnchorToSucceedItemOrRange = Me.AnchorToSucceedItemOrRange

            If (Me.ItemInsertSingly IsNot Nothing) Then
                ''
                ''Create an "Delete Singly" opertion (for our Undo op).
                ''
                If (Me.OperationType <> "I") Then Debugger.Break()
                .ItemDeleteSingly = Me.ItemInsertSingly ''The "Me." prefix matters.
                .ItemInsertSingly = Nothing ''Important, remove ANY vestigial reference.  (Already Null, but good practice.)
                .OperationType = "D"

            ElseIf (Me.ItemDeleteSingly IsNot Nothing) Then
                ''
                ''Create an "Insert Singly" opertion (for our Undo op).
                ''
                .ItemInsertSingly = Me.ItemDeleteSingly ''The "Me." prefix matters.
                .ItemDeleteSingly = Nothing ''Let's remove ANY vestigial reference.  (Already Null, but good practice.)
                .OperationType = "I"

            ElseIf (Me.InsertRangeStart IsNot Nothing) Then
                ''
                ''Create an "Delete Range" operation (for our Undo op).
                ''
                .DeleteRangeStart = Me.InsertRangeStart ''The "Me." prefix matters.
                .InsertRangeStart = Nothing ''Let's remove ANY vestigial reference. (Already Null, but good practice.)
                .OperationType = "D"

                ''Added 11/17/2023 td
                ''  The "Anchor" properties are no longer to be used for delete operations.
                ''  I have added the properties ".Delete_PriorToItemOrRange"
                ''  and ".Delete_
                ''11/17/2023 .Delete_PriorToItemOrRange = .AnchorLeftToPrior
                .Delete_PriorToItemOrRange = .AnchorToPrecedeItemOrRange
                ''11/17/2023 .Delete_NextToItemOrRange = .AnchorRightTerminal
                .Delete_NextToItemOrRange = .AnchorToSucceedItemOrRange
                ''11/17/2023 .AnchorLeftToPrior = Nothing
                .AnchorToPrecedeItemOrRange = Nothing
                ''11/17/2023 .AnchorRightTerminal = Nothing
                .AnchorToSucceedItemOrRange = Nothing

            ElseIf (Me.DeleteRangeStart IsNot Nothing) Then
                ''
                ''Create an "Delete Range" operation (for our Undo op).
                ''
                .InsertRangeStart = Me.DeleteRangeStart ''The "Me." prefix matters.
                .DeleteRangeStart = Nothing ''Let's remove ANY vestigial reference. (Already Null, but good practice.)
                .OperationType = "D"

            ElseIf (Me.MovedRangeStart IsNot Nothing) Then

                .OperationType = "M" '' M for Move.

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
                Dim tempControlL_PC As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
                Dim tempControlL_PP As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
                tempControlL_PC = Me.GetMoveRangeItemPrior_PreCut()
                tempControlL_PP = Me.GetMoveRangeItemPrior_PostPaste()
                Me.SetMoveRangeItemPrior_PreCut(tempControlL_PP) ''Reverse P.C. with P.P.
                Me.SetMoveRangeItemPrior_PostPaste(tempControlL_PC) ''Reverse P.P. with P.C.
                tempControlL_PP = Nothing ''Clear it, not needed now.
                tempControlL_PC = Nothing ''Clear it, not needed now.

                ''
                ''The "R"("Next")-suffix side, i.e. "Righthand" ("ItemNext") (Column to the Right) side. 
                ''
                Dim tempControlR_PC As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
                Dim tempControlR_PP As IDoublyLinkedItem ''11/2023 TControl ''Added 10/30/2023 td
                tempControlR_PC = Me.GetMoveRangeItemNext_PreCut()
                tempControlR_PP = Me.GetMoveRangeItemNext_PostPaste()
                Me.SetMoveRangeItemNext_PreCut(tempControlR_PP) ''Reverse P.C. with P.P.
                Me.SetMoveRangeItemNext_PostPaste(tempControlR_PC) ''Reverse P.P. with P.C.
                tempControlR_PP = Nothing ''Clear it, not needed now.
                tempControlR_PC = Nothing ''Clear it, not needed now.

            End If ''End of ""If (Me.InsertedSingly IsNot Nothing) Then... ElseIf..."

        End With ''End of ""With objUndo""

        Return objUndo

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

            If (Delete_PriorToItemOrRange IsNot Nothing) Then
                If (Delete_NextToItemOrRange Is Nothing) Then
                    Return True
                Else
                    Debugger.Break()
                End If
            Else
                If (Delete_NextToItemOrRange IsNot Nothing) Then
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
        If (ItemInsertSingly IsNot Nothing) Then
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

        ElseIf (ItemDeleteSingly IsNot Nothing) Then
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
                Or ItemDeleteSingly IsNot Nothing)) Then
                Debugger.Break()
            End If
        End If ''End of ""If (Testing.TestingByDefault) Then""

        Return (OperationType = "D")

    End Function ''End of ""Public Function IsForRangeOfItems() As Boolean""


    Public Function GetMoveRangeItemNext_PreCut() As IDoublyLinkedItem
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        Return MoveCut_NextToRange

    End Function


    Public Function GetMoveRangeItemPrior_PreCut() As IDoublyLinkedItem
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        Return MoveCut_PriorToRange

    End Function


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

    End Function


    Public Sub SetMoveRangeItemNext_PreCut(par_item As IDoublyLinkedItem)
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        If (par_item Is Nothing) Then Debugger.Break()

        MoveCut_NextToRange = par_item

    End Sub


    Public Sub SetMoveRangeItemPrior_PreCut(par_item As IDoublyLinkedItem)
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        If (par_item Is Nothing) Then Debugger.Break()
        MoveCut_PriorToRange = par_item

    End Sub


    Public Sub SetMoveRangeItemNext_PostPaste(par_item As IDoublyLinkedItem)
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        If (par_item Is Nothing) Then Debugger.Break()
        AnchorToSucceedItemOrRange = par_item

    End Sub


    Public Sub SetMoveRangeItemPrior_PostPaste(par_item As IDoublyLinkedItem)
        ''
        ''This function is to improve comprehensibility when generating
        ''  an "Undo" version of a Move operation. 
        ''
        If (par_item Is Nothing) Then Debugger.Break()
        AnchorToPrecedeItemOrRange = par_item

    End Sub


    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem) Implements IDoublyLinkedItem.DLL_SetItemNext
        ''Throw New NotImplementedException()
        mod_operationNext = param
    End Sub

    Public Sub DLL_SetItemPrior(param As IDoublyLinkedItem) Implements IDoublyLinkedItem.DLL_SetItemPrior
        ''Throw New NotImplementedException()
        mod_operationPrior = param
    End Sub

    Public Sub DLL_ClearReferencePrior() Implements IDoublyLinkedItem.DLL_ClearReferencePrior
        ''Throw New NotImplementedException()
        Debugger.Break() ''Shouldn't be needed. 
        mod_operationPrior = Nothing
    End Sub

    Public Sub DLL_ClearReferenceNext() Implements IDoublyLinkedItem.DLL_ClearReferenceNext
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

    Public Function DLL_GetItemNext() As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemNext
        ''11/2023 td''Throw New NotImplementedException()
        Return mod_operationNext

    End Function

    Public Function DLL_GetItemPrior() As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemPrior
        ''11/2023 td''Throw New NotImplementedException()
        Return mod_operationPrior

    End Function


    ''
    ''Important, check for equality.
    ''
    Private Overloads Function Equals(lets_check As DLL_Operation) As Boolean ''11/2/2023 (Of TControl)) As Boolean
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
        Dim boolEqual95 As Boolean

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
            boolEqual4 = ((.ItemDeleteSingly Is Nothing) = (Me.ItemDeleteSingly Is Nothing))
            boolEqual5 = (.InsertCount = Me.InsertCount)
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual6 = ((.InsertRangeStart Is Nothing) = (Me.InsertRangeStart Is Nothing))
            boolEqual7 = ((.ItemInsertSingly Is Nothing) = (Me.ItemInsertSingly Is Nothing))

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

            ''Added 11/17/20 23  
            boolEqual96 = (.AnchorWillPrecedeRangeOrItem() = Me.AnchorWillPrecedeRangeOrItem())
            boolEqual97 = (.AnchorWillSucceedRangeOrItem() = Me.AnchorWillSucceedItemOrRange())
            boolEqual98 = (.ItemIs_HandledSingly() = Me.ItemIs_HandledSingly())
            boolEqual99 = (.IsForRangeOfItems() = Me.IsForRangeOfItems())

        End With ''End of ""With lets_check""

        Dim bEqual1to5 As Boolean
        Dim bEqual6to9 As Boolean
        Dim bEqual91to95 As Boolean
        ''Added 11/17/2023  
        Dim bEqual96to99 As Boolean

        bEqual1to5 = (boolEqual1 And boolEqual2 And boolEqual3 And
                      boolEqual4 And boolEqual5)
        bEqual6to9 = (boolEqual6 And boolEqual7 And boolEqual8 And boolEqual9)
        bEqual91to95 = (boolEqual91 And boolEqual92 And boolEqual93 And
                          boolEqual94 And boolEqual95)

        ''Added 11/17/2023  
        bEqual96to99 = ((boolEqual96 And boolEqual97) And
                        (boolEqual98 And boolEqual99))

        Dim bEqual_All As Boolean
        ''bEqual_All = (bEqual1to5 And bEqual6to9 And bEqual91to95)
        bEqual_All = (bEqual1to5 And bEqual6to9 And
                     (bEqual91to95 And bEqual96to99))

        Return bEqual_All

    End Function ''End of Private Function Overrides Equals() as Boolean


    Private Function Undo2x_IsIdempotent(lets_check As DLL_Operation) As Boolean
        ''
        ''This will check the Idempotency of a Undo(Undo()), i.e.
        ''   double-Undo.
        ''
        Dim objUndo_1st As DLL_Operation ''11/2/2023 (Of TControl)
        Dim objUndo_2nd As DLL_Operation ''11/2/2023 (Of TControl)

        objUndo_1st = lets_check.GetUndoVersionOfOperation()
        objUndo_2nd = objUndo_1st.GetUndoVersionOfOperation()

        Dim boolEqualMatch As Boolean

        boolEqualMatch = lets_check.Equals(objUndo_2nd)
        Return boolEqualMatch

    End Function ''End of ""Private Function Undo2x_IsIdempotent""

    Public Function DLL_GetItemNext(param_iterationsOfNext As Integer) As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()

        ''Added 11/25/2025 td
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
        ''Added 11/25/2025 td
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


End Class
