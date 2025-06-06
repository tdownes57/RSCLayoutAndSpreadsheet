﻿''
''Added 1/19/2025 
''
Imports ciBadgeInterfaces
Imports RSCLibraryDLLOperations

Public Class DLLUserControlRichbox
    Implements IDoublyLinkedItem(Of DLLUserControlRichbox)
    ''
    ''Added 1/19/2025 
    ''
    ''
    ''Added 1/24/2025 td
    ''
    Public WithEvents DLLItem As DLLItemAndManager(Of DLLUserControlRichbox)

    ''Added 4/12/2025 td
    Public ColumnLetter As String ''Added 4/12/2025 td
    ''Apr2025 Public Event DLLUserClickedControlBox(col_name As String, row_number_base1 As Integer) ''Added 4/12/2025 td 
    Public Event DLLUserClickedControlBox(sender As Object,
                                          isUserPressingShiftKey As Boolean,
                                          column_name As String, row_number_base1 As Integer) ''Added 4/12/2025 td 
    ''
    ''Added 5/03/2025
    ''
    Public Event NotifyInFocus(param As Object) Implements _
        IDoublyLinkedItem(Of DLLUserControlRichbox).Notify_InFocus

    ''
    ''Added 1/19/2025 
    ''
    ''' <summary>
    ''' This won't be in use, as this is an operation vs. a list item. --2/27/2024
    ''' </summary>
    ''' <returns></returns>
    Public Property Selected() As Boolean Implements IDoublyLinkedItem.Selected
        Get
            Return DLLItem.Selected
        End Get
        Set(value As Boolean)
            DLLItem.Selected = value
        End Set
    End Property

    ''' <summary>
    ''' This won't be in use, as this is an operation vs. a list item. --2/27/2024
    ''' </summary>
    ''' <returns></returns>
    Public Property HighlightInBlue() As Boolean Implements IDoublyLinkedItem.HighlightInBlue
        Get
            Return DLLItem.HighlightInBlue
        End Get
        Set(value As Boolean)
            DLLItem.HighlightInBlue = value
        End Set
    End Property

    Public Property HighlightInGreen() As Boolean Implements IDoublyLinkedItem.HighlightInGreen
        Get
            Return DLLItem.HighlightInGreen
        End Get
        Set(value As Boolean)
            DLLItem.HighlightInGreen = value
        End Set
    End Property

    Public Property HighlightInRed() As Boolean Implements IDoublyLinkedItem.HighlightInRed
        Get
            Return DLLItem.HighlightInRed
        End Get
        Set(value As Boolean)
            DLLItem.HighlightInRed = value
        End Set
    End Property

    Public Property HighlightInCyan() As Boolean Implements IDoublyLinkedItem.HighlightInCyan
        Get
            Return DLLItem.HighlightInCyan
        End Get
        Set(value As Boolean)
            DLLItem.HighlightInCyan = value
        End Set
    End Property

    ''---Apr2025 Private Const ENFORCE_BIDIRECTIONAL As Boolean = True ''Added 12/08/2024 

    ''Jan24 2025 Friend mod_prior As DLLUserControlRichbox ''Using 'Friend' will allow sub-classes to access it.  12/12/2024 Private mod_prior
    ''Jan24 2025 Friend mod_next As DLLUserControlRichbox ''Using 'Friend' will allow sub-classes to access it.  ''12/12/2024 Private mod_next 

    ''
    ''Added 1/24/2025 td
    ''
    ''Moved above.  ---Public DLL As DLLItemManager(Of DLLUserControlRichbox)

    ''DIFFICULT AND CONFUSING -- 12/12/2024 TD
    ''April 2025  Friend mod_next_priorSortOrder As DLLUserControlRichbox ''Added 12/12/2024 TD


    Public Overrides Property Text() As String
        Get
            ''Added 1/19/2025 td
            Return TextBox1.Text
        End Get
        Set(par_value As String)
            ''Added 1/19/2025 td
            TextBox1.Text = par_value
        End Set
    End Property


    ''
    ''Added 5/03/2025
    ''
    ''Public Event Event_NotifyInFocus(param As Object) Implements _
    ''    IDoublyLinkedItem(Of DLLUserControlRichbox).Notify_InFocus


    Public Sub New() ''// , par_prior As TwoCharacterDLLItem)

        ''Added 2/01/2025 thomas downes 
        InitializeComponent()

        ''Added 1/21/2025 thomas downes 
        TextBox1.Text = "01" ''---par_twoChars

        ''Added 1/24/2025 td
        Me.DLLItem = New DLLItemAndManager(Of DLLUserControlRichbox)(Me)

    End Sub

    Public Sub New(par_twoChars As String) ''// , par_prior As TwoCharacterDLLItem)

        ''Added 2/01/2025 thomas downes 
        InitializeComponent()

        ''Added 1/21/2025 thomas downes 
        TextBox1.Text = par_twoChars

        ''Added 1/24/2025 td
        Me.DLLItem = New DLLItemAndManager(Of DLLUserControlRichbox)(Me)

    End Sub


    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem) _
           Implements IDoublyLinkedItem.DLL_SetItemNext

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()

        ''Jan24 2025 mod_next = param
        DLLItem.DLL_SetItemNext(param)

    End Sub ''End of ""Public Sub DLL_SetItemNext(...) ...""


    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem, pboolAllowNulls As Boolean, pboolDoublyLink As Boolean) Implements IDoublyLinkedItem.DLL_SetItemNext
        ''
        ''Added 12/22/2024 
        ''
        DLLItem.DLL_SetItemNext(param, pboolAllowNulls, pboolDoublyLink)

    End Sub ''End of ""Public Sub DLL_SetItemNext(param As IDoublyLinkedItem, ...)


    Public Sub DLL_SetItemPrior(param As IDoublyLinkedItem) _
           Implements IDoublyLinkedItem.DLL_SetItemPrior

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        ''Jan24 2025  mod_prior = param
        DLLItem.DLL_SetItemPrior(param)

    End Sub ''End of ""Public Sub DLL_SetItemPrior(...)""



    Public Overloads Sub DLL_SetItemNext_OfT(param As DLLUserControlRichbox) _
           Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_SetItemNext_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()
        ''Jan24 2025 mod_next = param
        DLLItem.DLL_SetItemNext_OfT(param)

    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""


    Public Sub DLL_SetItemPrior_OfT(paramItem As DLLUserControlRichbox) _
           Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_SetItemPrior_OfT

        ''Throw New NotImplementedException()
        If (paramItem Is Me) Then System.Diagnostics.Debugger.Break()
        ''---mod_next = param
        ''Jan24 2025 mod_prior = paramItem
        ''Mar22 2025 DLL.DLL_SetItemNext_OfT(paramItem)
        DLLItem.DLL_SetItemPrior_OfT(paramItem)

        ''
        '' Adding bidirectionality.  ---12/08/2024 td
        ''
        ''If (ENFORCE_BIDIRECTIONAL) Then
        ''    ''
        ''    ''Set the "mod_prior" item for this parameter item,
        ''    ''  to be the present class (i.e. the procedure's implicit parameter).
        ''    ''
        ''    paramItem.mod_next = Me

        ''End If ''end of "" If (ENFORCE_BIDIRECTIONAL) Then""

    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""


    Public Sub DLL_SetItemPrior_OfT(param As DLLUserControlRichbox, pbAllowNulls As Boolean) _
           Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_SetItemPrior_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()

        ''11/4/2024 mod_next = param
        ''Jan24 2025 If (param Is Nothing And pbAllowNulls) Then
        ''    mod_prior = Nothing
        ''Else
        ''    mod_prior = param
        ''End If

        DLLItem.DLL_SetItemPrior_OfT(param, pbAllowNulls)

    End Sub ''End of ""Public Sub DLL_SetItemPrior_OfT(...)""


    Public Overloads Sub DLL_SetItemNext_OfT(param As DLLUserControlRichbox, pbAllowNulls As Boolean) _
           Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_SetItemNext_OfT

        ''Throw New NotImplementedException()
        If (param Is Me) Then System.Diagnostics.Debugger.Break()

        DLLItem.DLL_SetItemNext_OfT(param, pbAllowNulls)


    End Sub ''End of ""Public Sub DLL_SetItemNext_OfT(...) ...""


    Public Sub DLL_ClearReferencePrior(par_typeOp As Char) Implements IDoublyLinkedItem.DLL_ClearReferencePrior
        ''Throw New NotImplementedException()
        ''Jan24 2025 mod_prior = Nothing
        DLLItem.DLL_ClearReferencePrior(par_typeOp)

    End Sub ''End of ""Public Sub DLL_ClearReferencePrior(...)""


    Public Sub DLL_ClearReferenceNext(par_typeOp As Char) Implements IDoublyLinkedItem.DLL_ClearReferenceNext
        ''Throw New NotImplementedException()
        ''mod_next = Nothing
        ''April 2025 ''DLLItem.DLL_ClearReferencePrior(par_typeOp)
        DLLItem.DLL_ClearReferenceNext(par_typeOp)

    End Sub ''End of ""Public Sub DLL_ClearReferenceNext(...)""


    ''' <summary>
    ''' Indicate that this item will serve as the final item in a list.
    ''' </summary>
    Public Sub DLL_MarkAsEndOfList(Optional pleaseRemoveMarkFromPrior As Boolean = True,
                            Optional pleaseRemoveMarkFromThis As Boolean = False) Implements IDoublyLinkedItem.DLL_MarkAsEndOfList

        ''Added 4/17/2025
        ''---DLLItem.DLL_MarkAsEndOfList()
        DLLItem.DLL_MarkAsEndOfList(pleaseRemoveMarkFromPrior, pleaseRemoveMarkFromThis)

    End Sub ''End of ""Public Sub DLL_MarkAsEndOfList()""

    Public Function DLL_NotAnyNext() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyNext
        ''Throw New NotImplementedException()
        ''Return (mod_next Is Nothing)
        Return DLLItem.DLL_NotAnyNext()

    End Function ''End of ""Public Function DLL_NotAnyNext()""


    Public Function DLL_NotAnyPrior() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyPrior
        ''Throw New NotImplementedException()
        ''Return (mod_prior Is Nothing)
        Return DLLItem.DLL_NotAnyPrior()

    End Function ''End of ""Public Function DLL_NotAnyPrior()""


    Public Sub DLL_NotifyOfFocus() Implements IDoublyLinkedItem.DLL_NotifyOfFocus
        ''
        ''Added 5/03/2025 
        ''
        ''---DLLItem.DLL_NotifyOfFocus()

    End Sub ''End of "" Public Sub DLL_NotifyOfFocus()""


    Public Function DLL_HasNext() As Boolean Implements IDoublyLinkedItem.DLL_HasNext
        ''Throw New NotImplementedException()
        ''Return (mod_next IsNot Nothing)
        Return DLLItem.DLL_HasNext()

    End Function ''End of ""Public Function DLL_HasNext()""


    Public Function DLL_HasPrior() As Boolean Implements IDoublyLinkedItem.DLL_HasPrior
        ''Throw New NotImplementedException()
        ''Return (mod_prior IsNot Nothing)
        Return DLLItem.DLL_HasPrior()

    End Function ''End of ""Public Function DLL_HasPrior()""


    Public Function DLL_GetItemNext_OfT() As DLLUserControlRichbox _
           Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()

        ''If (mod_next Is Me) Then System.Diagnostics.Debugger.Break()
        ''Return mod_next
        Return DLLItem.DLL_GetItemNext_OfT()

    End Function ''End of ""Public Function DLL_GetItemNext_OfT()""


    ''Public Function DLL_GetItemNext() As IDoublyLinkedItem _
    ''       Implements IDoublyLinkedItem.DLL_GetItemNext
    ''    ''Throw New NotImplementedException()
    ''
    ''    If (mod_next Is Me) Then System.Diagnostics.Debugger.Break()
    ''
    ''    Return mod_next
    ''
    ''End Function ''End of ""Public Function DLL_GetItemNext()""


    Public Function DLL_GetItemNext() As IDoublyLinkedItem _
           Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()

        ''If (mod_next Is Me) Then System.Diagnostics.Debugger.Break()
        ''Return mod_next
        Return DLLItem.DLL_GetItemNext()

    End Function ''End of ""Public Function DLL_GetItemNext()""


    Public Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As DLLUserControlRichbox _
           Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()

        ''Dim tempNext As DLLUserControlRichbox = mod_next
        ''If (param_iterationsOfNext > 1) Then
        ''    For index = 2 To param_iterationsOfNext
        ''        If (tempNext Is Nothing) Then Exit For ''12/9/2024 Debugger.Break() ''12/31/2023
        ''        tempNext = tempNext.mod_next
        ''    Next index
        ''End If ''End of ""If (param_iterationsOfNext > 1) Then""
        ''If (param_iterationsOfNext = 0) Then Return Me
        ''If (param_iterationsOfNext = 1) Then Return mod_next
        ''Return tempNext

        ''Feb2025 td''DLL.DLL_GetItemNext_OfT(param_iterationsOfNext)
        Return DLLItem.DLL_GetItemNext_OfT(param_iterationsOfNext)

    End Function ''End of ""Public Function DLL_GetItemNext_OfT""


    Public Function DLL_GetItemNext(param_iterationsOfNext As Integer) As IDoublyLinkedItem _
           Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()

        ''Dim tempNext As DLLUserControlRichbox = mod_next
        ''If (param_iterationsOfNext > 1) Then
        ''    For index = 2 To param_iterationsOfNext
        ''        If (tempNext Is Nothing) Then Debugger.Break() ''12/31/2023
        ''        tempNext = tempNext.mod_next
        ''    Next index
        ''End If ''End of ""If (param_iterationsOfNext > 1) Then""
        ''If (param_iterationsOfNext = 0) Then Return Me
        ''If (param_iterationsOfNext = 1) Then Return mod_next
        ''Return tempNext

        Return DLLItem.DLL_GetItemNext(param_iterationsOfNext)

    End Function ''End of ""Public Function DLL_GetItemNext""


    ''' <summary>
    ''' Get item following a range (if the implicit parameter is the first item in a range). Sometimes we need the Item which follows the Range, to prepare for a possible Undo.
    ''' </summary>
    ''' <param name="param_rangeSize">This is the item-count of the range, or size of the range.</param>
    ''' <returns>The first item which follows the range.</returns>
    Public Function DLL_GetNextItemFollowingRange(param_rangeSize As Integer,
                                                  param_mayBeNull As Boolean) As IDoublyLinkedItem _
        Implements IDoublyLinkedItem.DLL_GetNextItemFollowingRange

        ''Added 12/30/2023 
        ''---DIFFICULT AND CONFUSING---
        ''  By CS-related rules of iteration, by moving ahead
        ''  a number of jumps equal to the item-count of the range,
        ''  we get the first post-range item.
        ''                  ---12/30/2023 tdownes
        ''12/2023 Return DLL_GetItemNext(param_rangeSize)
        ''Dim result As IDoublyLinkedItem
        ''result = DLL_GetItemNext(param_rangeSize)
        ''
        ''''Check for Nulls!
        ''If ((Not param_mayBeNull) AndAlso result Is Nothing) Then
        ''    Debugger.Break()
        ''End If
        ''
        ''Return result

        Return DLLItem.DLL_GetNextItemFollowingRange_OfT(param_rangeSize, param_mayBeNull)

    End Function ''DLL_GetNextItemFollowingRange


    Public Function DLL_GetItemPrior() As IDoublyLinkedItem _
           Implements IDoublyLinkedItem.DLL_GetItemPrior

        ''Throw New NotImplementedException()

        ''If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()
        ''Return mod_prior
        ''Feb2025 DLL.DLL_GetItemPrior()
        Return DLLItem.DLL_GetItemPrior()

    End Function ''End of ""Public Function DLL_GetItemPrior()""


    Public Function DLL_GetItemPrior(param_iterationsOfPrior As Integer) As IDoublyLinkedItem _
           Implements IDoublyLinkedItem.DLL_GetItemPrior

        ''Throw New NotImplementedException()

        ''If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()
        ''Return mod_prior
        ''Feb2025 td DLL.DLL_GetItemPrior(param_iterationsOfPrior)
        Return DLLItem.DLL_GetItemPrior(param_iterationsOfPrior)

    End Function ''End of ""Public Function DLL_GetItemPrior()""


    Public Function DLL_GetItemPrior_OfT() As DLLUserControlRichbox _
           Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemPrior_OfT

        ''Throw New NotImplementedException()

        ''If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()
        ''Return mod_prior

        Return DLLItem.DLL_GetItemPrior_OfT()

    End Function ''End of ""Public Function DLL_GetItemPrior_OfT()""


    Public Function DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As DLLUserControlRichbox _
          Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemPrior_OfT

        ''Throw New NotImplementedException()
        ''If (mod_prior Is Me) Then System.Diagnostics.Debugger.Break()
        ''
        ''Dim tempPrior As DLLUserControlRichbox = mod_prior
        ''
        ''If (param_iterationsOfPrior > 1) Then
        ''    For index = 2 To param_iterationsOfPrior
        ''        tempPrior = tempPrior.mod_prior
        ''    Next index
        ''End If
        ''If (param_iterationsOfPrior = 0) Then Return Me
        ''Return tempPrior
        ''
        ''Return mod_prior

        Return DLLItem.DLL_GetItemPrior_OfT(param_iterationsOfPrior)

    End Function ''End of ""Public Function DLL_GetItemPrior_OfT()""


    ''' <summary>
    ''' Returns the item at the specified index in the parent list. 
    ''' </summary>
    ''' <param name="par_index_b0">This is a 0-based index.</param>
    ''' <returns>Returns the item at the specified index.</returns>
    Public Function DLL_GetItemAtIndex_base0(par_index_b0 As Integer) As DLLUserControlRichbox Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemAtIndex_base0
        ''
        ''added 1/07/2024
        ''
        ''Dim objFirst As DLLUserControlRichbox ''= DLL_GetItemFirst()
        ''Dim objResult As DLLUserControlRichbox
        ''
        ''objFirst = DLL_GetItemFirst()
        ''''----objResult = objFirst.DLL_GetItemNext_OfT(par_index_b0)
        ''Dim intIterationsOfNext As Integer = par_index_b0 ''Added 1/16/2025
        ''
        ''objResult = objFirst.DLL_GetItemNext_OfT(intIterationsOfNext)
        ''
        ''''1/16/2025 Return objFirst
        ''Return objResult ''Fixed 1/16/2025

        Return DLLItem.DLL_GetItemAtIndex_base0(par_index_b0)

    End Function ''End of ""Public Function DLL_GetItemAtIndex_b0(par_index_b0 As Integer) As UserControlTextbox""


    ''' <summary>
    ''' Returns the item at the specified index in the parent list. 
    ''' </summary>
    ''' <param name="par_index_b1">This is a 1-based index.</param>
    ''' <returns>Returns the item at the specified index.</returns>
    Public Function DLL_GetItemAtIndex_b1(par_index_b1 As Integer) As DLLUserControlRichbox Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemAtIndex_base1
        ''
        ''added 1/07/2024
        ''
        ''Dim objResult As DLLUserControlRichbox
        ''objResult = DLL_GetItemAtIndex_b0(-1 + par_index_b1)
        ''Return objResult

        Return DLLItem.DLL_GetItemAtIndex_base1(par_index_b1)

    End Function ''End of ""Public Function DLL_GetItemAtIndex_b1(par_index_b1 As Integer) As UserControlTextbox""


    Public Function DLL_UnboxControl() As Control ''Jan24 2025 Implements IDoublyLinkedItem.DLL_UnboxControl

        ''Throw New NotImplementedException()
        Return Me

    End Function ''End of ""Public Function DLL_UnboxControl()""


    Public Function DLL_UnboxControl_OfT() As DLLUserControlRichbox
        ''Jan24 2025  Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_UnboxControl_OfT

        ''//Throw New NotImplementedException()
        Return Me

    End Function ''End of ""Public Function DLL_UnboxControl_OfT()""


    Public Function DLL_IsEitherEndpoint() As Boolean Implements IDoublyLinkedItem.DLL_IsEitherEndpoint

        ''Throw New NotImplementedException()
        ''Return ((mod_next Is Nothing) Or (mod_prior Is Nothing))
        Return DLLItem.DLL_IsEitherEndpoint()

    End Function ''ENd of ""Public Function DLL_IsEitherEndpoint() ""


    Public Overrides Function ToString() As String

        ''Added 12/26/2023
        ''July2024 Return mod_twoChars
        ''Feb2025  Return (TextBox1.Text) ''(mod_char1 + mod_char2)

        ''Added 2/15/2025 thomas
        If (Me.DLL_HasNext()) Then

            ''Feb15 2025 Return (Me.TextBox1.Text & " " & Me.DLL_GetItemNext_OfT().ToString(False)) ''(mod_char1 + mod_char2)
            Dim strDescribeNext As String ''Added 2/2025 td
            strDescribeNext = Me.DLL_GetItemNext_OfT().ToString(False) ''(mod_char1 + mod_char2)
            Return (Me.TextBox1.Text & " followed by " & strDescribeNext)

        Else
            Return (Me.TextBox1.Text & " - No next item.")

        End If ''End of ""If (Me.DLL_HasNext()) Then... Else..."

    End Function ''Public Overrides Function ToString() As String


    Public Overloads Function ToString(pboolDescribeNext As Boolean) As String Implements IDoublyLinkedItem(Of DLLUserControlRichbox).ToString
        ''---Feb2025---Public Overrides Function ToString() As String

        ''Added 2/15/2025 
        If (pboolDescribeNext) Then
            ''
            ''Check to see if there's another item following.
            ''
            If (Me.DLL_HasNext()) Then
                ''Feb2025 Return (Me.TextBox1.Text & " followed by " & Me.DLL_GetItemNext_OfT().ToString(False)) ''(mod_char1 + mod_char2)
                Dim strDescribeNext As String ''Added 2/2025 td
                strDescribeNext = Me.DLL_GetItemNext_OfT().ToString(False) ''(mod_char1 + mod_char2)
                Return (Me.TextBox1.Text & " followed by " & strDescribeNext)

            Else
                Return (Me.TextBox1.Text & " - No next item.")

            End If ''End of ""If (pboolDescribeNext) Then... Else..."

        Else
            Return (Me.TextBox1.Text) ''--- & " - No next item.")

        End If ''ENd of ""If (pboolDescribeNext) Then ... Else..."

    End Function ''Public Overrides Function ToString() As String


    Public Function DLL_GetValue() As String Implements IDoublyLinkedItem.DLL_GetValue

        ''Throw New NotImplementedException()
        ''July2024 Return mod_twoChars

        ''not needed 4/14/2025  Return DLL.DLL_GetValue()
        Return (TextBox1.Text) ''(mod_char1 + mod_char2)

    End Function ''end of ""Public Function DLL_GetValue() As String""


    Public Function DLL_CountItemsAllInList() As Integer Implements IDoublyLinkedItem.DLL_CountItemsAllInList

        ''---Throw New NotImplementedException()
        ''Debugger.Break()

        ''Return -1

        ''Coded 11/29/2024 thoma.s downe.s
        Dim intItemsPrior As Integer = DLL_CountItemsPrior()
        Dim intItemsAfter As Integer = DLL_CountItemsAfter()
        Return (1 + intItemsPrior + intItemsAfter)

    End Function ''Public Function DLL_CountItemsAllInList() 


    Public Function DLL_CountItemsPrior() As Integer Implements IDoublyLinkedItem.DLL_CountItemsPrior

        ''---Throw New NotImplementedException()
        ''Dim result_count As Integer = 0
        ''Dim temp As IDoublyLinkedItem = Me.DLL_GetItemPrior()
        ''While temp IsNot Nothing
        ''    result_count += 1
        ''    temp = temp.DLL_GetItemPrior()
        ''End While ''End of ""While temp IsNot Nothing""
        ''Return result_count

        Return DLLItem.DLL_CountItemsPrior()

    End Function ''ENd of ""Public Function DLL_CountItemsPrior()""


    Public Function DLL_CountItemsAfter() As Integer Implements IDoublyLinkedItem.DLL_CountItemsAfter

        ''---Throw New NotImplementedException()
        ''Dim result_count As Integer = 0
        ''Dim temp As IDoublyLinkedItem = Me.DLL_GetItemNext()
        ''While temp IsNot Nothing
        ''    result_count += 1
        ''    temp = temp.DLL_GetItemNext()
        ''End While ''End of ""While temp IsNot Nothing""
        ''Return result_count

        Return DLLItem.DLL_CountItemsAfter()

    End Function ''ENd of ""Public Function DLL_CountItemsAfter()""


    Public Function DLL_GetItemFirst() As DLLUserControlRichbox Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemFirst
        ''
        ''Added 12/29/2024
        ''
        ''Dim temp As IDoublyLinkedItem = Me ''.DLL_GetItemNext()
        ''Dim temp_result As IDoublyLinkedItem = Me ''.DLL_GetItemNext()
        ''
        ''While temp.DLL_HasPrior()
        ''    temp = temp.DLL_GetItemPrior()
        ''End While ''End of ""While temp.DLL_HasNext()""
        ''temp_result = temp
        ''Return temp_result

        Return DLLItem.DLL_GetItemFirst()

    End Function ''ENd of ""Public Function DLL_GetItemFirst() As UserControlTextbox""


    Public Function DLL_GetItemLast() As DLLUserControlRichbox Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemLast
        ''
        ''Added 12/12/2024
        ''
        Return DLLItem.DLL_GetItemLast()

        ''Dim temp As IDoublyLinkedItem = Me ''.DLL_GetItemNext()
        ''Dim temp_result As IDoublyLinkedItem = Me ''.DLL_GetItemNext()
        ''
        ''While temp.DLL_HasNext()
        ''    temp = temp.DLL_GetItemNext()
        ''End While ''End of ""While temp.DLL_HasNext()""
        ''temp_result = temp
        ''Return temp_result


    End Function ''ENd of ""Public Function DLL_GetItemLast() As UserControlTextbox""


    Public Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As DLLUserControlRichbox _
           Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetNextItemFollowingRange_OfT
        ''
        ''Added 7/11/2024 
        ''
        ''----Return DLL_GetItemNext_OfT(param_rangeSize) '', param_mayBeNull)
        Return DLLItem.DLL_GetNextItemFollowingRange_OfT(param_rangeSize, param_mayBeNull)

    End Function ''End of ""Public Function DLL_GetNextItemFollowingRange_OfT""


    Public Function DLL_GetDistanceTo(paramItem As DLLUserControlRichbox) As Integer Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetDistanceTo
        ''
        ''Added 11/18/2024  
        ''
        ''Jan24 2025 Dim bLocated As Boolean
        ''Jan24 2025 Dim result As Integer
        ''Jan24 2025         ''result = DLL_GetDistanceTo(paramItem, bLocated)
        ''Jan 24 2025 If (Not bLocated) Then System.Diagnostics.Debugger.Break()
        ''Jan24 2025 Return result
        Return DLLItem.DLL_GetDistanceTo(paramItem)

    End Function ''ENd of ""Public Function DLL_GetDistanceTo(paramItem As UserControlTextbox)""


    Public Function DLL_GetDistanceTo(paramItem As DLLUserControlRichbox, ByRef pbLocatedItem As Boolean) As Integer Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetDistanceTo
        ''
        '' Added "ByRef pbLocated As Boolean" on 11/18/2024
        ''
        Return DLLItem.DLL_GetDistanceTo(paramItem, pbLocatedItem)

    End Function ''End of Public Function DLL_GetDistanceTo 


    Public Function SelectedAnyItemToFollow() As Boolean
        ''
        ''Added 11/12/2024  
        ''
        Return DLLItem.SelectedAnyItemToFollow()

    End Function ''ENd of ""Public Function SelectedAnyItemToFollow()""


    ''' <summary>
    ''' This index is 1-based, not 0-based. 
    ''' </summary>
    ''' <returns>Returns a positive integer, starting with 1 (1-based).</returns>
    Public Function DLL_GetItemIndex_base1() As Integer Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemIndex_base1
        ''
        ''Added 11/12/2024  
        ''
        '' This index is 1-based, not 0-based. 
        ''
        Return DLLItem.DLL_GetItemIndex_base1()

    End Function ''end of Public Function GetItemIndex_b1() As Integer


    ''' <summary>
    ''' This index is 0-based, not 1-based. 
    ''' </summary>
    ''' <returns>Returns a non-negative integer, starting with 0 (0-based).</returns>
    Public Function DLL_GetItemIndex_base0() As Integer Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_GetItemIndex_base0
        ''
        ''Added 11/12/2024  
        ''
        '' This index is 1-based, not 0-based. 
        ''
        ''Dim result_index As Integer = 0
        ''result_index = (-1 + DLL_GetItemIndex_b1())
        ''Return result_index

        Return DLLItem.DLL_GetItemIndex_base0()

    End Function ''end of Public Function GetItemIndex_b1() As Integer


    Public Sub DLL_InsertItemToNext(param As DLLUserControlRichbox, pbDoubleLink As Boolean) _
          Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_InsertItemToNext
        ''
        '' This will take some weight off, from DLL_List(Of TControl). 
        ''
        DLLItem.DLL_InsertItemToNext(param, pbDoubleLink)

    End Sub ''End of ""Public Sub DLL_InsertItemToNext(...)""


    Public Sub DLL_InsertItemToPrior(param As DLLUserControlRichbox,
                                     pbSetDoubleLink As Boolean) _
         Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_InsertItemToPrior
        ''
        '' This will take some weight off, from DLL_List(Of TControl). 
        ''
        DLLItem.DLL_InsertItemToPrior(param, pbSetDoubleLink)

    End Sub ''End of ""Public Sub DLL_InsertItemToPrior(...)""


    ''
    ''
    ''DIFFICULT AND CONFUSING -- PRIOR SORT ORDERS -- Added 12/12/2024
    ''
    ''
    ''Public Function DLL_GetItemNext_PriorSortOrder() As UserControlTextbox Implements IDoublyLinkedItem(Of UserControlTextbox).DLL_GetItemNext_PriorSortOrder
    ''    ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
    ''    Return mod_next_priorSortOrder
    ''End Function
    ''
    ''Public Sub DLL_SetItemNext_PriorSortOrder(param As UserControlTextbox) Implements IDoublyLinkedItem(Of UserControlTextbox).DLL_SetItemNext_PriorSortOrder        ''Throw New NotImplementedException()
    ''    ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
    ''    mod_next_priorSortOrder = param
    ''End Sub

    ''' <summary>
    ''' DIFFICULT AND CONFUSING -- PRIOR SORT ORDERS
    ''' </summary>
    ''' <param name="pbExecuteInCascade"></param>
    Public Sub DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade As Boolean) Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_SaveCurrentSortOrder_ToPrior

        ''Added 12/ 29/2024 
        DLLItem.DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Sub DLL_RestorePriorSortOrder(par_countdownItems As Integer) Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_RestorePriorSortOrder

        ''''Added 12/29/2024 
        ''Dim strThisItem As String = Me.DLL_GetValue() ''This may help in the debugging process.
        ''Dim preRestoration_next As DLLUserControlRichbox = mod_next ''Added 12/29/2024 thomas d.
        ''Dim bNotDoneYet As Boolean ''Added 12/29/2024 thomas d.

        DLLItem.DLL_RestorePriorSortOrder(par_countdownItems)

    End Sub ''End of ""Public Sub DLL_RestorePriorSortOrder()""


    Public Sub DLL_ClearPriorSortOrder(pbExecuteInCascade As Boolean) Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_ClearPriorSortOrder

        ''DIFFICULT AND CONFUSING -- Added 12/12/2024 
        DLLItem.DLL_ClearPriorSortOrder(pbExecuteInCascade)

    End Sub ''End of ""Public Sub DLL_SaveCurrentSortOrder_ToPrior()""


    Public Overloads Sub DLL_SetItemNext_OfT(param As DLLUserControlRichbox, paramAllowNulls As Boolean, paramDoublyLinkIt As Boolean) _
        Implements IDoublyLinkedItem(Of DLLUserControlRichbox).DLL_SetItemNext_OfT

        ''Added 12/22/2024 

        DLLItem.DLL_SetItemNext_OfT(param, paramAllowNulls, paramDoublyLinkIt)

    End Sub ''ENd of '"Public Overloads Sub DLL_SetItemNext_OfT""


    Public Function GetConvertToGeneric_OfT(Of T_BaseOrParallel As IDoublyLinkedItem(Of T_BaseOrParallel))(par_firstItem As T_BaseOrParallel) _
              As T_BaseOrParallel Implements IDoublyLinkedItem(Of DLLUserControlRichbox).GetConvertToGeneric_OfT
        ''
        ''Added 1/07/2025 
        ''
        Return DLLItem.GetConvertToGeneric_OfT(Of T_BaseOrParallel)(par_firstItem)

        ''Dim intIndex_b0 As Integer
        ''intIndex_b0 = DLL_GetItemIndex_b0()
        ''firstItem = firstItem.DLL_GetItemFirst()
        ''Return firstItem.DLL_GetItemAtIndex_b0(intIndex_b0)

    End Function ''Public Function GetConvertToGeneric_OfT


    Public Function GetConvertToArray() As DLLUserControlRichbox() Implements IDoublyLinkedItem(Of DLLUserControlRichbox).GetConvertToArray

        ''Throw New NotImplementedException
        Return DLLItem.GetConvertToArray()

        ''Dim intCount As Integer = DLL_CountItemsAllInList()
        ''Dim arrResult(intCount - 1) As DLLUserControlRichbox
        ''Dim temp As DLLUserControlRichbox ''= Me.DLL_GetItemFirst()

        ''temp = Me.DLL_GetItemFirst()
        ''For index = 0 To intCount - 1
        ''    arrResult(index) = temp
        ''    temp = temp.DLL_GetItemNext_OfT()
        ''Next index
        ''Return arrResult

    End Function ''End of Public Function GetConvertToArray() As UserControlTextbox()


    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick

        ''Added 4/20/2025 td
        TextBox1.BackColor = Color.Yellow
        Me.Selected = Not Me.Selected
        TextBox1.BackColor = IIf(Me.Selected, Color.Yellow, Color.White) ''Color.Transparent)

        ''Added 2/29/2024
        Dim bShiftingKey As Boolean = Control.ModifierKeys = Keys.Shift

        ''Added 4/20/2025 td
        ''Apr2025  RaiseEvent DLLUserClickedControlBox(Me.ColumnLetter, Me.DLL_GetItemIndex_b1())
        ''May2025  RaiseEvent DLLUserClickedControlBox(bShiftingKey, Me.ColumnLetter, Me.DLL_GetItemIndex_base1())
        RaiseEvent DLLUserClickedControlBox(Me, bShiftingKey, Me.ColumnLetter, Me.DLL_GetItemIndex_base1())

    End Sub


    Public Sub DLL_DrawColors() Implements IDoublyLinkedItem.DLL_DrawColors
        ''
        ''Added 4/21/2024
        '' 
        If (Me.Selected) Then TextBox1.BackColor = Color.Yellow
        If (Not Me.Selected) Then TextBox1.BackColor = Color.White ''Yellow

        ''Added 05/04/2025 
        If (Me.HighlightInBlue) Then TextBox1.BackColor = Color.Blue
        If (Me.HighlightInCyan) Then TextBox1.BackColor = Color.Cyan
        If (Me.HighlightInGreen) Then TextBox1.BackColor = Color.Green
        If (Me.HighlightInRed) Then TextBox1.BackColor = Color.Red

    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus

        ''Added 5/04/2025 td
        ''---RaiseEvent NotifyInFocus(Me)
        ''---RaiseEvent DLLItem.Notify_ItemInFocus(Me)

        ''---DLLItem.DLL_NotifyOfFocus()
        RaiseEvent NotifyInFocus(Me)

    End Sub

    Private Sub DLLItem_Notify_InFocus(sender As Object) Handles DLLItem.Notify_InFocus

        ''Added 5/04/2025 td


    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter

        ''Added 5/07/2025 td
        RaiseEvent NotifyInFocus(Me)

    End Sub

    Private Sub TextBox1_SelectionChanged(sender As Object, e As EventArgs) Handles TextBox1.SelectionChanged

        ''Added 5/07/2025 td
        RaiseEvent NotifyInFocus(Me)

    End Sub

    Private Sub TextBox1_MouseEnter(sender As Object, e As EventArgs) Handles TextBox1.MouseEnter

        ''Added 5/18/2025 td

        ''---May2025 This causes the wrong list to be sorted, unfortunately.
        ''---May2025      RaiseEvent NotifyInFocus(Me)

    End Sub

    Private Sub DLLUserControlRichbox_Click(sender As Object, e As EventArgs) Handles MyBase.Click

        ''Added 5/18/2025 td
        RaiseEvent NotifyInFocus(Me)

    End Sub

    Private Sub DLLUserControlRichbox_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter

        ''Added 5/18/2025 td
        RaiseEvent NotifyInFocus(Me)

    End Sub

    Private Sub DLLUserControlRichbox_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp

        ''Added 5/18/2025 td
        RaiseEvent NotifyInFocus(Me)

    End Sub

    Private Sub TextBox1_Paint(sender As Object, e As PaintEventArgs) Handles TextBox1.Paint

        ''Added 5/18/2025 td
        RaiseEvent NotifyInFocus(Me)

    End Sub

    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDown

        ''Added 5/18/2025 td
        RaiseEvent NotifyInFocus(Me)

    End Sub
End Class

