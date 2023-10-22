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

Public Class RSCRowHeader
    ''
    ''Added 4/6/2022 thomas d
    ''
    Public ParentRSCRowHeaders As RSCRowHeaders
    Public ParentRSCSpreadsheet As RSCFieldSpreadsheet ''Added 9/18/2023 td

    Public Property RowIndex As Integer ''Added 4/24/2022 td

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
            boolOkayStart = (.EmphasisRowIndex_Start = Me.RowIndex)
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
            intRowIndex = Me.RowIndex
        Else
            ''9/12/2023 intRowIndex = Me.ParentRSCRowHeaders.GetRowIndex_OfHeader(Me)
            intRowIndex = Me.RowIndex
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


    Public Function FactoryBuildRowHeader_IfNeeded(pintRowIndex As Integer,
                        pintExpectedNewRowCount As Integer,
                        pboolForceReposition As Boolean,
                        Optional ByRef pboolNewlyBuilt As Boolean = False,
                        Optional ByRef pboolMoreThanOneNew As Boolean = False,
                        Optional ByRef plistRowHeaders As List(Of RSCRowHeader) = Nothing) As RSCRowHeader
        ''
        ''Added 10/18/2023 thomas downes
        ''
        Dim intEachIndex As Integer = 1
        Dim bContinue As Boolean = True
        Dim eachRSCHeader As RSCRowHeader = Me
        Dim priorRSCHeader As RSCRowHeader = Nothing
        Dim output_result As RSCRowHeader = Nothing
        Dim boolBuiltOneAlready As Boolean = False
        Dim newRSCHeader As RSCRowHeader = Nothing ''Added 10/18/2023
        Dim bFoundIndicatedRow As Boolean '' = False
        Dim intNewRowCount As Integer = 0

        Do While (bContinue)

            bFoundIndicatedRow = (intEachIndex = pintRowIndex)
            If (bFoundIndicatedRow) Then ''If (intEachIndex = pintRowIndex) Then
                bContinue = False ''Was previously not really needed, 
                ''  due the "Return" statement below.
                ''10/2023 Return eachRSCHeader
                output_result = eachRSCHeader
            Else
                intEachIndex += 1
                eachRSCHeader = eachRSCHeader.RowHeaderNextBelow
                If (eachRSCHeader Is Nothing) Then
                    ''##bContinue = False
                    pboolNewlyBuilt = True

                    ''Create new RSCHeader.  
                    If (boolBuiltOneAlready) Then
                        ''Administrative work.... :-( 
                        ''  We need to keep track of every new row header that's
                        ''  built.  ---10/18/2023 td
                        If (plistRowHeaders IsNot Nothing) Then
                            plistRowHeaders = New List(Of RSCRowHeader)
                            pboolMoreThanOneNew = True
                        End If ''Create new list.
                        plistRowHeaders.Add(newRSCHeader)
                        ''A bit redundant here...
                        ''---pboolMoreThanOneNew = True
                    End If ''ENd of ""If (boolBuiltOneAlready) Then... Else""

                    ''Create new row header.
                    newRSCHeader = priorRSCHeader.GetBuildNextRowsHeader_Factory(False, True)
                    eachRSCHeader = newRSCHeader ''Prepare for next looping.
                    output_result = newRSCHeader ''Prepare for loop termination.
                    boolBuiltOneAlready = True ''Prepare for next looping.
                    ''Not needed here! boolBuiltOneAlready = True
                    Me.FactoryMaxIndex = intEachIndex
                    intNewRowCount += 1

                End If ''End of ""If (eachRSCHeader Is Nothing) Then""
            End If ''ENd of ""If (bFoundIndicatedRow) Then""

            ''Prepare for the next iteration of the loop,
            ''  in case we come to the end of the looping. 
            priorRSCHeader = eachRSCHeader

        Loop ''End Do While (bContinue)

        ''
        ''Warn the user.
        ''
        If (intNewRowCount <> pintExpectedNewRowCount) Then
            MessageBoxTD.Show_Statement("More new rows than expected...")
        End If

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


    Public Sub RefreshHeightOfHeaders(Optional par_intNumberOfRows As Integer = 0)
        ''
        ''Added 10/21/2023 td 
        ''
        Dim intEachIndex As Integer = 1
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
        Me.ParentRSCRowHeaders.SaveToRecipient(objRecipient, Me.RowIndex,
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
            .EmphasisRowIndex_Start = Me.RowIndex
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
                .MoveTextCaret_IfNeeded(Me.RowIndex)
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
            If (Me.RowIndex <= 0) Then
                Me.RowIndex = Me.ParentRSCRowHeaders.GetRowIndex_OfHeader(Me)
            End If ''End If (Me.RowIndex <= 0) Then

            ''Added 4/25/2022 td
            ParentRSCRowHeaders.HeaderBox_MouseUp(Me, e, Me.RowIndex)

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
            If (Me.RowIndex <= 0) Then System.Diagnostics.Debugger.Break()

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
                        If (Me.RowIndex >= .EmphasisRowIndex_Start) Then
                            .EmphasisRowIndex_End = Me.RowIndex

                        ElseIf (Me.RowIndex < .EmphasisRowIndex_Start) Then
                            .EmphasisRowIndex_End = .EmphasisRowIndex_Start
                            .EmphasisRowIndex_Start = Me.RowIndex
                        End If

                    Else
                        .EmphasisRowIndex_Start = Me.RowIndex
                        .EmphasisRowIndex_End = -1

                    End If ''end of ""If (0 < mod_intEmphasisRowIndex_Start) Then... Else...""

                    ''Added 5/1/2022 thomas downes
                    ''5/1/2022 .EmphasizeRows_Highlight(Me.RowIndex, .EmphasisRowIndex_End)
                    .EmphasizeRows_Highlight(boolUsingShiftKey,
                                             .EmphasisRowIndex_Start,
                                             .EmphasisRowIndex_End)

                Else
                    .EmphasisRowIndex_Start = Me.RowIndex
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
