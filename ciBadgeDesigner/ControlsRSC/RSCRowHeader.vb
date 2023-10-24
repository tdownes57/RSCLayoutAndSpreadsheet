Option Explicit On ''Added 5/19/2022 
Option Strict On ''Added 5/19/2022
''
''Added 4/6/2022 thomas d
''
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Threading
Imports __RSC_Error_Logging
Imports ciBadgeInterfaces ''Added 5/19/2022 thomas 
Imports ciBadgeRecipients
Imports MathNet.Numerics.LinearAlgebra.Storage

Public Class RSCRowHeader
    ''
    ''Added 4/6/2022 thomas d
    ''
    Public ParentRSCRowHeaders As RSCRowHeaders
    Public ParentRSCSpreadsheet As RSCFieldSpreadsheet ''Added 9/18/2023 td

    Public Property RowIndex_Denigrated As Integer ''Added 4/24/2022 td

    Public Recipient As ciBadgeRecipients.ClassRecipient ''Added 4/12/2022 td

    ''Added 5/17/2023
    ''  This will help it to be a doubly-linked list. 
    Public RowHeaderNextAbove As RSCRowHeader
    Public RowHeaderNextBelow As RSCRowHeader
    Public FactoryMaxIndex As Integer ''Added 10/18/2023

    ''Added 4/29/2022 td
    ''5/1/2022 Private mod_intEmphasisRowIndex_Start As Integer = -1 ''= par_intRowIndex_Start
    ''5/1/2022 Private mod_intEmphasisRowIndex_End As Integer = -1 ''= par_intRowIndex_End

    ''Private Sub textRowHeader1_Click(sender As Object, e As EventArgs) Handles textRowHeader1.Click
    ''    ''
    ''    ''Added 4/6/2022 thomas d
    ''    ''
    ''End Sub

    Public Overrides Property Text() As String
        Get
            ''Added 4/6/2022 td
            Return textRowHeader1.Text
        End Get
        Set(value As String)
            ''Added 4/6/2022 td
            textRowHeader1.Text = value
        End Set
    End Property

    Public Property Text_RowNumber() As String
        Get
            ''Added 4/6/2022 td
            Return textRowHeader1.Text
        End Get
        Set(value As String)
            ''Added 4/6/2022 td
            textRowHeader1.Text = value
        End Set
    End Property


    Public Overrides Property BackColor() As Drawing.Color
        Get
            ''Added 4/29/2022 td
            Return textRowHeader1.BackColor
        End Get

        Set(value As Drawing.Color)
            ''Added 4/29/2022 td
            textRowHeader1.BackColor = value
            MyBase.BackColor = value
        End Set
    End Property



    Public Function FocusRelated_RowHasEmphasis() As Boolean
        ''
        ''Added 5/13/2022 td 
        ''
        Dim boolOkayStart As Boolean
        Dim boolOkayEnd As Boolean

        With Me.ParentRSCRowHeaders
            ''Added 5/13/2022 td 
            boolOkayStart = (.EmphasisRowIndex_Start = Me.RowIndex_Denigrated)
            boolOkayEnd = (-1 = .EmphasisRowIndex_End)

        End With ''End of ""With Me.ParentRSCRowHeaders""

        Return (boolOkayStart And boolOkayEnd)

    End Function ''eND OF ""Public Sub FocusRelated_RowHasEmphasis()""


    Public Function GetRecipient(Optional ByRef pboolAnyFieldsFailed As Boolean = False,
                                 Optional ByRef pboolRowIsEmpty As Boolean = False) As ClassRecipient
        ''
        ''Added 8/29/2023 td
        ''
        Dim objRecipient As ClassRecipient
        Dim intRowIndex As Integer
        Dim bFailure As Boolean
        Dim intCountOfFailedColumns As Integer ''Added 9/01/2023

        objRecipient = Me.Recipient
        If (objRecipient Is Nothing) Then
            objRecipient = New ClassRecipient
            Me.Recipient = objRecipient
        End If ''End ""If (objRecipient Is Nothing) Then

        ''Minor call
        If (Me.ParentRSCRowHeaders Is Nothing) Then
            ''9/12/2023 Return Nothing ''Added 9/12/2023 td
            intRowIndex = Me.RowIndex_Denigrated
        Else
            ''9/12/2023 intRowIndex = Me.ParentRSCRowHeaders.GetRowIndex_OfHeader(Me)
            intRowIndex = Me.RowIndex_Denigrated
        End If

        ''Added 8/29/2023 
        If (intRowIndex < 0) Then
            System.Diagnostics.Debugger.Break()
            RSCErrorLogging.Log(34, "GetRecipient", "RowIndex is -1.")
            Return Nothing ''Added 8/29/2023 td
        Else
            ''Major call
            Me.ParentRSCRowHeaders.SaveToRecipient(objRecipient, intRowIndex,
                                                   bFailure, intCountOfFailedColumns,
                                                   pboolRowIsEmpty)

            If (bFailure) Then
                pboolAnyFieldsFailed = bFailure
                Return Nothing
            End If ''Eng of ""If (bFailure) Then""

        End If ''Endof ""If (intRowIndex < 0) Then...Else
        Return objRecipient

    End Function ''End of ""Public Function GetRecipient()""


    Public Function GetBuildNextRowsHeader_Factory(pbOverwriteExisting As Boolean,
               Optional pbThrowErrorIfAlreadyExists As Boolean = False,
               Optional pbDisplayNewHeader As Boolean = True,
               Optional pref_bIsNew As Boolean = False) As RSCRowHeader
        ''
        ''Added 10/6/2023 td 
        ''
        ''Administrative code.  --10/2023
        If (Not pbOverwriteExisting) Then
            If (Me.RowHeaderNextBelow IsNot Nothing) Then
                If (pbThrowErrorIfAlreadyExists) Then
                    Throw New InvalidOperationException("Row Header already exists")
                End If ''If (pbThrowErrorIfAlreadyExists) Then
                Return Me.RowHeaderNextBelow
            End If ''If (Me.RowHeaderNextBelow IsNot Nothing) Then
        End If ''End of ""If (Not pbOverwriteExisting) Then""

        ''
        ''
        '' Factory / Building New RSCRowHeader
        ''
        ''
        ''Substantive code. 
        pref_bIsNew = True
        Dim objNewHeader = New RSCRowHeader With {
          .Text = CStr(1 + Integer.Parse(Me.Text)),
          .Left = Me.Left,
          .Width = Me.Width,
          .Height = Me.Height,
          .RowHeaderNextAbove = Me,
          .Visible = True
        }

        ''Record a reference to the new object, so this object can allow
        ''   parent objects to find the new RowHeader. 
        Me.RowHeaderNextBelow = objNewHeader

        Return objNewHeader

    End Function ''End of ""Public Function GetBuildNextRowsHeader""  


    Public Sub FactoryBuildNextRowsHeader(pbOverwriteExisting As Boolean,
               Optional pbThrowErrorIfAlreadyExists As Boolean = False,
               Optional pbDisplayNewHeader As Boolean = True)
        ''
        ''Added 10/6/2023
        ''
        Dim boolIsBrandNew As Boolean

        ''Added 10/6/2023 td 
        ''Call the function, but we don't need to pass the new RowHeader 
        '' back to the calling procedure.  Presumably, the calling 
        '' procedure doesn't require a reference to the new RowHeader. 
        ''  --10/2023 
        GetBuildNextRowsHeader_Factory(pbOverwriteExisting,
                               pbThrowErrorIfAlreadyExists,
                               pbDisplayNewHeader,
                               boolIsBrandNew)

        If (boolIsBrandNew And pbDisplayNewHeader) Then

            ''Added 10/2023
            ''--DIFFICULT AND CONFUSING---
            Throw New Exception("Suggestion, use GetBuild instead, as the new RowHeader " &
            " will VERY likely be invisble!! it must be added to the " &
            "parent control's control collection.")

        End If ''If     `-/  /(boolIsBrandNew And pbDisplayNewHeader) Then

    End Sub ''End of ""Public Sub FactoryBuildNextRowsHeader""  


    Public Function FactoryBuildNextRowHeader_IfNeeded(pintRowIndex As Integer,
                        pintExpectedNewRowsCount As Integer,
                        pboolForceReposition As Boolean,
                        Optional ByRef pref_bNewlyBuiltAtLeastOne As Boolean = False,
                        Optional ByRef pref_bMoreThanOneNewlyBuilt As Boolean = False,
                        Optional ByRef pref_intNumberRowsCreated As Integer = 0) As RSCRowHeader
        ''------------- Optional ByRef plistRowHeaders As List(Of RSCRowHeader) = Nothing) As RSCRowHeader
        ''
        ''Added 10/18/2023 thomas downes
        ''
        Dim intEachIndex As Integer = 1
        Dim bContinue As Boolean = True
        Dim eachRSCHeader As RSCRowHeader = Me
        Dim priorRSCHeader As RSCRowHeader = Nothing
        Dim output_result As RSCRowHeader = Nothing
        ''Not needed. Dim boolBuiltOneAlready As Boolean = False
        Dim newRSCHeader As RSCRowHeader = Nothing ''Added 10/18/2023
        Dim bFoundIndicatedRow As Boolean '' = False
        ''Not needed. Dim intNewRowCount As Integer = 0

        If (Me.ParentRSCRowHeaders Is Nothing) Then
            Debugger.Break()
            ''Throw New Exception("The Parent reference should be supplied prior to calling this.")
        End If ''End of ""If (Me.ParentRSCRowHeaders Is Nothing) Then""

        pref_intNumberRowsCreated = 0 ''Initialize. 10/24/2023

        ''
        ''We may need to create several rows, so a loop is needed.
        ''
        Do While (bContinue)

            ''Does it match the desired row index? 
            bFoundIndicatedRow = (intEachIndex = pintRowIndex)

            If (bFoundIndicatedRow) Then ''If (intEachIndex = pintRowIndex) Then
                bContinue = False ''Was previously not really needed, 
                ''  due the "Return" statement below.
                ''10/2023 Return eachRSCHeader
                output_result = eachRSCHeader
            Else
                intEachIndex += 1
                eachRSCHeader = eachRSCHeader.RowHeaderNextBelow

                ''
                ''Administrative work--check if we've reached the end of rows. 
                ''
                If (eachRSCHeader Is Nothing) Then
                    ''##bContinue = False

                    ''
                    ''Create new row header!!!!
                    ''
                    newRSCHeader = priorRSCHeader.GetBuildNextRowsHeader_Factory(False, True)

                    pref_bNewlyBuiltAtLeastOne = True
                    eachRSCHeader = newRSCHeader ''Prepare for next looping.
                    output_result = newRSCHeader ''Prepare for loop termination.
                    ''Not needed. 10/2023boolBuiltOneAlready = True ''Prepare for next looping.

                    ''Not needed here! boolBuiltOneAlready = True
                    Me.FactoryMaxIndex = intEachIndex
                    pref_intNumberRowsCreated += 1

                    ''Added 10/23/2023 td
                    newRSCHeader.ParentRSCRowHeaders = Me.ParentRSCRowHeaders
                    If (priorRSCHeader Is Nothing) Then
                        ''
                        ''Maintain the chain!!!  Link in both directions!!!
                        ''
                        newRSCHeader.RowHeaderNextAbove = priorRSCHeader
                        priorRSCHeader.RowHeaderNextBelow = newRSCHeader
                    End If ''End of ""If (priorRSCHeader Is Nothing) Then""

                End If ''End of ""If (eachRSCHeader Is Nothing) Then""
            End If ''ENd of ""If (bFoundIndicatedRow) Then""

            ''Prepare for the next iteration of the loop,
            ''  in case we come to the end of the looping. 
            priorRSCHeader = eachRSCHeader

        Loop ''End Do While (bContinue)

        ''
        ''Warn the user.
        ''
        If (pref_intNumberRowsCreated <> pintExpectedNewRowsCount) Then
            MessageBoxTD.Show_Statement("More new rows than expected. Count " &
                                        pref_intNumberRowsCreated & " created.")
        End If

        pref_bMoreThanOneNewlyBuilt = (1 < pref_intNumberRowsCreated)

        Return output_result

    End Function ''Public Function BuildRowHeader_IfNeeded


    Public Function GetRowHeader_ByIndex(pintRowIndex As Integer,
                                         pbCallingFromFirstRow As Boolean) As RSCRowHeader
        ''Added 10/06/2023
        ''
        If (Not pbCallingFromFirstRow) Then
            Throw New Exception("Calling from first-row header works, all else beware!")
        End If

        Dim intEachIndex As Integer = 1
        Dim bContinue As Boolean = True
        Dim eachRSCHeader As RSCRowHeader = Me

        Do While (bContinue)

            If (intEachIndex = pintRowIndex) Then
                bContinue = False
                Return eachRSCHeader
            Else
                intEachIndex += 1
                eachRSCHeader = eachRSCHeader.RowHeaderNextBelow
                If (eachRSCHeader Is Nothing) Then bContinue = False
            End If

        Loop ''End Do While (bContinue)

        Return Nothing ''Added 10/12/2023

    End Function ''Public Function GetRowHeader_ByIndex


    Public Sub ToggleEmptyRowMessage_AllRowHdrs(pbIsTopRowHeader As Boolean,
                                     par_manager_cols As RSCSpreadManagerCols)
        ''
        ''Added 10/23/2023 td
        ''
        Dim bContinue As Boolean = True
        Dim eachRSCHeader As RSCRowHeader = Me
        Dim intRowIndex As Integer

        If (pbIsTopRowHeader) Then
            intRowIndex = 1
        Else
            Debugger.Break()
            ''Throw New Exception("This is not the top row header!!")
        End If ''End of ""If (pbIsTopRowHeader) Then... Else...""

        Do While (bContinue)

            eachRSCHeader = eachRSCHeader.RowHeaderNextBelow
            intRowIndex += 1
            If (eachRSCHeader Is Nothing) Then
                bContinue = False
            Else
                ''Toggle the Empty Row Message.
                eachRSCHeader.ToggleEmptyRowMessage(intRowIndex, par_manager_cols)
            End If ''End of ""If (eachRSCHeader Is Nothing) Then... Else...""

        Loop ''End Do While (bContinue)

    End Sub ''ENd of ""Public Sub ToggleEmptyRowMessage_AllRowHdrs()""


    Public Sub ToggleEmptyRowMessage(pintCurrentRowIndex As Integer,
                                     par_manager_cols As RSCSpreadManagerCols)
        ''
        ''Added 10/23/2023 thomas d.
        ''
        Dim rowIndex As Integer = Me.RowIndex_Denigrated
        Dim recipient As ClassRecipient = Me.GetRecipient(False)
        Dim bIsRecipientEmpty As Boolean = recipient.IsEmpty()
        Dim bIsSpreadsheetRowEmpty As Boolean ''= par_dlist_columns.IsRowEmpty(rowIndex)
        bIsSpreadsheetRowEmpty = par_manager_cols.IsRowEmpty(rowIndex)
        Dim bCompletelyEmpty As Boolean = (bIsRecipientEmpty And bIsSpreadsheetRowEmpty)

        If (bCompletelyEmpty) Then
            ''
            ''Row is completely empty. 
            ''
            par_manager_cols.ToggleMessage_RowIsEmpty(rowIndex,
                     True, bCompletelyEmpty)
        Else
            par_manager_cols.ToggleMessage_RowIsEmpty(rowIndex,
                     True, bCompletelyEmpty)
        End If ''End of ""If (each_bCompletelyEmpty) Then... Else"

    End Sub ''ENd of ""Public Sub ToggleEmptyRowMessage()""


    Public Sub GetListOfRecipients_AllHdrs(plistOfRecipients As List(Of ClassRecipient))
        ''
        ''Added 10/23/2023
        ''
        Dim bContinue As Boolean = True
        Dim eachRSCHeader As RSCRowHeader = Me
        ''Dim intRowIndex As Integer
        Dim eachRecipient As ClassRecipient

        plistOfRecipients.Add(Me.GetRecipient())

        Do While (bContinue)
            eachRSCHeader = eachRSCHeader.RowHeaderNextBelow
            If (eachRSCHeader Is Nothing) Then
                bContinue = False
            Else
                ''Toggle the Empty Row Message.
                eachRecipient = eachRSCHeader.GetRecipient()
                If (eachRecipient IsNot Nothing) Then
                    plistOfRecipients.Add(eachRecipient)
                End If
            End If ''End of ""If (eachRSCHeader Is Nothing) Then... Else...""
        Loop ''End Do While (bContinue)

    End Sub ''End of Public Sub GetListOfRecipients_AllHdrs


    Public Sub RefreshHeightOfHeaders(Optional par_intNumberOfRows As Integer = 0)
        ''
        ''Added 10/21/2023 td 
        ''
        ''Dim intEachIndex As Integer = 1
        Dim bContinue As Boolean = True
        Dim eachRSCHeader As RSCRowHeader = Me
        Dim bCountRows As Boolean = (par_intNumberOfRows > 0)
        Dim intCountRowsRefreshed As Integer = 0

        Do While (bContinue)

            If (bCountRows And (intCountRowsRefreshed > par_intNumberOfRows)) Then
                bContinue = False
            Else
                eachRSCHeader = eachRSCHeader.RowHeaderNextBelow
                If (eachRSCHeader Is Nothing) Then
                    bContinue = False
                Else
                    ''Set the height to be the height of the current RowHeader.
                    eachRSCHeader.Height = Me.Height
                    intCountRowsRefreshed += 1
                End If ''End of ""If (eachRSCHeader Is Nothing) Then... Else...""
            End If

        Loop ''End Do While (bContinue)

    End Sub ''End of Public Sub RefreshHeightOfHeaders(Optional par_intNumberOfRows As Integer = 0)


    Public Sub ShowRecipientsIDCard(Optional ByRef pref_boolFailure As Boolean = False,
                                Optional ByVal pboolVerboseFailure As Boolean = False,
                                Optional ByVal pboolVerboseWarning As Boolean = False)
        ''
        ''Added 5/14/2022 thomas downes
        ''
        Dim objRecipient As ciBadgeRecipients.ClassRecipient
        Dim intCountColsFailed As Integer ''Added 5/25/2022 td
        Dim intCountColsWithoutFields As Integer ''Added 5/25/2022 td
        ''Dim obj_image As System.Drawing.Image
        Dim intCountAllCols As Integer = 0

        LinkLabelShowID.Visible = True ''Added 5/20/2022 td 

        objRecipient = Me.Recipient

        If objRecipient Is Nothing Then

            objRecipient = New ciBadgeRecipients.ClassRecipient
            ''June28 2022 ''objRecipient.ID_Guid = Guid.NewGuid()
            objRecipient.PopulateGuid_IfNeeded()

        End If ''End of ""If objRecipient Is Nothing Then"" 

        ''Added 5/25/2022
        intCountColsWithoutFields = Me.ParentRSCRowHeaders.CountOfColumnsWithoutFields(intCountAllCols)
        If (pboolVerboseWarning And 0 < intCountColsWithoutFields) Then
            ''Added 5/25/2022
            MessageBoxTD.Show_FormatNumbers("Please be aware that {0} of {1} columns have no field selected.",
                                            intCountColsFailed, intCountAllCols)
        End If ''eND OF ""If (pboolVerboseWarning and 0 < intCountColsWithoutFields) Then""

        ''#1 5/25/2022 Me.ParentRSCRowHeaders.SaveToRecipient(objRecipient, Me.RowIndex)
        ''#2 5/25/2022 Me.ParentRSCRowHeaders.SaveToRecipient(objRecipient, Me.RowIndex, pboolFailure)
        Me.ParentRSCRowHeaders.SaveToRecipient(objRecipient, Me.RowIndex_Denigrated,
                                               pref_boolFailure, intCountColsFailed)

        ''Added 5/25/2022
        If (pref_boolFailure And pboolVerboseFailure) Then
            ''Added 5/25/2022
            MessageBoxTD.Show_FormatNumbers("Please be aware that {0} columns have unusable data... " & vbCrLf &
                                           "likely due to lack of field-selection.",
                                            intCountColsFailed)
        End If ''eND OF ""If (pref_boolFailure And pboolVerboseFailure) Then""

        ''
        ''Added 5/19/2022 td  
        ''
        Me.ParentRSCRowHeaders.ShowRecipientsIDCard(objRecipient)

        ''Dim obj_image As System.Drawing.Image
        ''obj_image = Me.ParentRSCRowHeaders.ShowRecipientsIDCard(objRecipient)

        ''Dim imageBadge As System.Drawing.Image
        ''Dim objBadgeSideFront As ClassBadgeSideLayoutV1
        ''Dim objBadgeSideBackside As ClassBadgeSideLayoutV1
        ''Dim obj_generator As ciBadgeGenerator.ClassMakeBadge

        ''objBadgeSideFront = .GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.)
        ''obj_generator = New ciBadgeGenerator.ClassMakeBadge

        ''''
        ''''Major call !!
        ''''
        ''obj_image = obj_generator.MakeBadgeImage_AnySide(Me.BadgeLayout_Class,
        ''                   par_objMakeBadgeElements, Me.ElementsCache_UseEdits,
        ''                   Me.PreviewBox.Width,
        ''                   Me.PreviewBox.Height,
        ''                   par_recipient,
        ''                   Nothing, Nothing, Nothing, par_recentlyMoved)

        ''''Added 1/23/2022 td
        ''If (Not String.IsNullOrEmpty(obj_generator.Messages)) Then
        ''    ''Added 1/23/2022 td
        ''    MessageBoxTD.Show_Statement(obj_generator.Messages)
        ''End If ''End of "If (boolGeneratorMessageExists) Then"


    End Sub ''End of ""Public Sub ShowRecipientsIDCard()""


    Public Sub SaveToRecipient(par_objRecipient As ciBadgeRecipients.ClassRecipient,
                               par_iRowIndex As Integer,
                               Optional ByRef pref_bAnyFailure As Boolean = False,
                               Optional ByRef pref_intCountFailures As Integer = 0,
                               Optional ByRef pref_bRowIsEmpty As Boolean = False)
        ''
        ''Added 9/18/2023 & 5/19/2022 
        ''
        ''#1 5/25/2022 Me.ParentRSCSpreadsheet.SaveToRecipient(par_objRecipient, par_iRowIndex)
        ''#2 5/25/2022 Me.ParentRSCSpreadsheet.SaveToRecipient(par_objRecipient, par_iRowIndex, pboolFailure)
        Me.ParentRSCSpreadsheet.SaveToRecipient(par_objRecipient, par_iRowIndex,
                                                pref_bAnyFailure, pref_intCountFailures)

    End Sub ''End of ""Public Sub SaveToRecipient(...)""


    Public Sub SetBackColor(pintRowIndex_Start As Integer,
                            par_colorBackground As System.Drawing.Color,
                            Optional pintRowIndex_End As Integer = -1)
        ''
        ''Added 10/12/2023 Thomas Downes
        ''
        Dim intEachIndex As Integer = 1
        Dim bContinue As Boolean = True
        Dim eachRSCHeader As RSCRowHeader = Me
        Dim bIndexMatches As Boolean ''Added 10/12/2023 thomas d

        If (pintRowIndex_End = -1) Then
            ''This is how the following algorithm will work.  We don't have to 
            ''  have any special one-row-only commands.
            pintRowIndex_End = pintRowIndex_Start
        End If

        Do While (bContinue)

            bIndexMatches = (pintRowIndex_Start <= intEachIndex And
                                                   intEachIndex <= pintRowIndex_End)

            If (bIndexMatches) Then
                ''bContinue = False
                ''Return eachRSCHeader
                eachRSCHeader.BackColor = par_colorBackground

            ElseIf (intEachIndex > pintRowIndex_End) Then

                ''We can exit the loop now now.
                bContinue = False

            Else
                intEachIndex += 1
                eachRSCHeader = eachRSCHeader.RowHeaderNextBelow
                If (eachRSCHeader Is Nothing) Then bContinue = False

            End If ''ENd of ""If (bIndexMatches) Then... ElseIf ... Else ..."

        Loop ''End of ""Do While (bContinue)"" 

    End Sub ''End of ""Public Sub SetBackColor""


    Public Sub FocusRelated_EmphasizeRow()
        ''
        ''Added 5/13/2022 td 
        ''
        LinkLabelShowID.Visible = True ''Added 5/20/2022 td 

        With Me.ParentRSCRowHeaders
            ''Added 5/13/2022 td 
            .EmphasisRowIndex_Start = Me.RowIndex_Denigrated
            .EmphasisRowIndex_End = -1

            ''Let the user know (via color-coding) that the emphasis has taken place.
            .EmphasizeRows_Highlight(False,
                    .EmphasisRowIndex_Start,
                    .EmphasisRowIndex_End)

            ''Added 5/13/2022
            ''  The DataCell with the blinking TextCaret should change from
            ''  the cell in the previously-focused row to the cell in the 
            ''  currently-focused row. ----5/13/2022 td
            ''
            With .ParentRSCSpreadsheet
                .MoveTextCaret_IfNeeded(Me.RowIndex_Denigrated)
            End With

        End With ''End of ""With Me.ParentRSCRowHeaders""

    End Sub ''eND OF ""Public Sub FocusRelated_EmphasizeRow()""


    ''Public Function FocusRelated_RowHasEmphasis() As Boolean
    ''    ''
    ''    ''Added 5/13/2022 td 
    ''    ''
    ''    Dim boolOkayStart As Boolean
    ''    Dim boolOkayEnd As Boolean

    ''    With Me.ParentRSCRowHeaders
    ''        ''Added 5/13/2022 td 
    ''        boolOkayStart = (.EmphasisRowIndex_Start = Me.RowIndex)
    ''        boolOkayEnd = (-1 = .EmphasisRowIndex_End)

    ''    End With ''End of ""With Me.ParentRSCRowHeaders""

    ''    Return (boolOkayStart And boolOkayEnd)

    ''End Function ''eND OF ""Public Sub FocusRelated_RowHasEmphasis()""


    ''Public Function GetRecipient(Optional ByRef pboolAnyFieldsFailed As Boolean = False,
    ''                             Optional ByRef pboolRowIsEmpty As Boolean = False) As ClassRecipient
    ''    ''
    ''    ''Added 8/29/2023 td
    ''    ''
    ''    Dim objRecipient As ClassRecipient
    ''    Dim intRowIndex As Integer
    ''    Dim bFailure As Boolean
    ''    Dim intCountOfFailedColumns As Integer ''Added 9/01/2023

    ''    objRecipient = Me.Recipient
    ''    If (objRecipient Is Nothing) Then
    ''        objRecipient = New ClassRecipient
    ''        Me.Recipient = objRecipient
    ''    End If ''End ""If (objRecipient Is Nothing) Then

    ''    ''Minor call
    ''    If (Me.ParentRSCRowHeaders Is Nothing) Then
    ''        ''9/12/2023 Return Nothing ''Added 9/12/2023 td
    ''        intRowIndex = Me.RowIndex
    ''    Else
    ''        ''9/12/2023 intRowIndex = Me.ParentRSCRowHeaders.GetRowIndex_OfHeader(Me)
    ''        intRowIndex = Me.RowIndex
    ''    End If

    ''    ''Added 8/29/2023 
    ''    If (intRowIndex < 0) Then
    ''        System.Diagnostics.Debugger.Break()
    ''        RSCErrorLogging.Log(34, "GetRecipient", "RowIndex is -1.")
    ''        Return Nothing ''Added 8/29/2023 td
    ''    Else
    ''        ''Major call
    ''        Me.ParentRSCRowHeaders.SaveToRecipient(objRecipient, intRowIndex,
    ''                                               bFailure, intCountOfFailedColumns,
    ''                                               pboolRowIsEmpty)

    ''        If (bFailure) Then
    ''            pboolAnyFieldsFailed = bFailure
    ''            Return Nothing
    ''        End If ''Eng of ""If (bFailure) Then""

    ''    End If ''Endof ""If (intRowIndex < 0) Then...Else
    ''    Return objRecipient

    ''End Function ''End of ""Public Function GetRecipient()""


    Private Sub textRowHeader1_MouseUp(sender As Object, e As MouseEventArgs) _
        Handles textRowHeader1.MouseUp

        ''Added 4/12/2022 td 
        Const c_bGiveHeightMsg As Boolean = False
        Dim boolUsingShiftKey As Boolean ''And 4/29/2022 thomas

        LinkLabelShowID.Visible = True ''Added 5/20/2022 td 

        ''Added 4/6/2022 thomas d.
        If (e.Button = MouseButtons.Right) Then
            ''Added 4/6/2022 thomas d.
            ''4/25/2022 td''ParentRSCRowHeaders.HeaderBox_MouseUp(Me, e)

            ''Added 4/25/2022 td
            If (Me.RowIndex_Denigrated <= 0) Then
                Me.RowIndex_Denigrated = Me.ParentRSCRowHeaders.GetRowIndex_OfHeader(Me)
            End If ''End If (Me.RowIndex <= 0) Then

            ''Added 4/25/2022 td
            ParentRSCRowHeaders.HeaderBox_MouseUp(Me, e, Me.RowIndex_Denigrated)

        ElseIf (c_bGiveHeightMsg) Then
            ''
            ''Added 4/6/2022 td
            ''
            MessageBoxTD.Show_Statement("The height of this control is: " + Me.Height.ToString,
                                        "The width of this control is: " + Me.Width.ToString)
            Me.Height = (ParentRSCRowHeaders.PixelsFromRowToRow - 1)

        Else
            ''
            ''Added 4/28/2022 thomas d.
            ''
            If (Me.RowIndex_Denigrated <= 0) Then System.Diagnostics.Debugger.Break()

            ''
            ''Keep track of the range of emphasized rows.
            ''
            With Me.ParentRSCRowHeaders

                ''Major call!!
                ''May 2 2022 ''.EmphasizeRows_Highlight(Me.RowIndex)

                ''Added 4/29/2022 thomas d.
                If (My.Computer.Keyboard.ShiftKeyDown) Then
                    ''
                    ''Determine the range of selected rows.
                    ''
                    If (0 < .EmphasisRowIndex_Start) Then
                        If (Me.RowIndex_Denigrated >= .EmphasisRowIndex_Start) Then
                            .EmphasisRowIndex_End = Me.RowIndex_Denigrated

                        ElseIf (Me.RowIndex_Denigrated < .EmphasisRowIndex_Start) Then
                            .EmphasisRowIndex_End = .EmphasisRowIndex_Start
                            .EmphasisRowIndex_Start = Me.RowIndex_Denigrated
                        End If

                    Else
                        .EmphasisRowIndex_Start = Me.RowIndex_Denigrated
                        .EmphasisRowIndex_End = -1

                    End If ''end of ""If (0 < mod_intEmphasisRowIndex_Start) Then... Else...""

                    ''Added 5/1/2022 thomas downes
                    ''5/1/2022 .EmphasizeRows_Highlight(Me.RowIndex, .EmphasisRowIndex_End)
                    .EmphasizeRows_Highlight(boolUsingShiftKey,
                                             .EmphasisRowIndex_Start,
                                             .EmphasisRowIndex_End)

                Else
                    .EmphasisRowIndex_Start = Me.RowIndex_Denigrated
                    .EmphasisRowIndex_End = -1
                    .EmphasizeRows_Highlight(boolUsingShiftKey,
                                             .EmphasisRowIndex_Start,
                                             .EmphasisRowIndex_End)

                End If ''End of ""If (My.Computer.Keyboard.ShiftKeyDown) Then ... Else...""

            End With ''End of ""With Me.ParentRSCRowHeaders""

        End If ''End of "If (e.Button = MouseButtons.Right) Then .... ElseIf ... Else ...."

    End Sub ''End of ""Private Sub textRowHeader1_MouseUp""


    Private Sub LinkLabelShowID_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelShowID.LinkClicked

        Dim boolFailure As Boolean

        ''Added 5/14/2022

        ''5/25/2022 ''ShowRecipientsIDCard()
        ShowRecipientsIDCard(boolFailure)

        ''Ad
        If (boolFailure) Then



        End If ''endof ""If (boolFailure) Then""



    End Sub ''End of ""Private Sub LinkLabelShowID_LinkClicked""





End Class
