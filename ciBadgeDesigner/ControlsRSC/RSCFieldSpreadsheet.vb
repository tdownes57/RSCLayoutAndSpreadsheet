''
''Added 2/21/2022 td
''
Imports System.Drawing ''Added 3/20/2022 thomas downes
Imports __RSC_Error_Logging
Imports __RSCWindowsControlLibrary
Imports ciBadgeCachePersonality ''Added 3/14/2.0.2.2. t.//downes
''4/2023 Imports ciBadgeElements
Imports ciBadgeFields ''Added 3/10/2.0.2.2. thomas downes
Imports ciBadgeInterfaces ''Added 3/11/2022 t__homas d__ownes
Imports ciBadgeRecipients

Public Class RSCFieldSpreadsheet
    ''
    ''Added 2/21/2022 td
    ''
    Public Shared StillHavingColumnTrouble As Boolean = False ''5/01/2023 True ''Added 4/11/2023 td

    Public ParentForm_DesignerDialog As Form ''ciBadgeDesigner.DialogEditRecipients 
    Public Designer As ClassDesigner ''Added 3/10/2022 td
    Public ElementsCache_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 3/10/2022 td
    ''April 13 2022 ''Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''ClassColumnWidthsEtc ''Added 3/15/2022 td

    ''Public RscFieldColumn1 As RSCFieldColumn ''Added 3/25/2022 td
    ''Renamed 7/03/2022 td''Public RecipientsCache As ClassCacheOnePersonalityConfig ''Added 3/28/2022 thomas downes
    Public PersonalityCache_Recipients As CachePersnltyCnfgLRecips ''7/4/2022 ClassCacheOnePersonalityConfig ''Added 3/28/2022 thomas downes
    Public NumberOfRowsNeededToStart As Integer ''Added 4/1/2023 

    Private mod_intRowDisplayCardHeight As Integer = 0 ''= 0 ''Added 5/30/2022 td
    Private mod_colorOfColumnsBackColor As System.Drawing.Color = Drawing.Color.AntiqueWhite ''Added 3/13/2022 thomas downes

    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td
    Private WithEvents mod_eventsSingleton As New GroupMoveEvents_Singleton(Me.Designer, False, True) ''Added 1/4/2022 td  

    Private Const mc_intPixelsFromRowToRow As Integer = 24 ''Added 4/05/2022 td
    Private Const mc_boolKeepUILookingClean As Boolean = True ''Moved to module-level 5/30/2022

    ''Added 4/29/2022 td
    Private mod_intEmphasisRowIndex_Start As Integer = -1 ''= par_intRowIndex_Start
    Private mod_intEmphasisRowIndex_End As Integer = -1 ''= par_intRowIndex_End

    ''Added 8/27/2023
    ''    Store the horizontal lines, one corresponding to the
    ''    unique .Top property of each spreadsheet row's 1st-column cell 
    Private mod_listHorizontalLines As List(Of Integer)

    Public ColumnDataCache As ciBadgeCachePersonality.CacheRSCFieldColumnWidthsEtc ''ClassColumnWidthsEtc ''Added 3/15/2022 td

    ''5/31/2023 td Public LoadByReadingColumnCache As Boolean ''Added 5/22/2023 thomas
    Public LoadColumnListByReadingColumnCache As Boolean ''Added 5/31/2023 thomas
    Public LoadColumnDataByReadingColumnCache As Boolean ''Added 5/31/2023 thomas
    Public LoadColumnDataByReadingRecipients As Boolean ''Added 5/31/2023 thomas

    ''Added 4/18/2023 td
    Private mod_managerRowsCols As RSCSpreadManagerRowsCols

    Private Const DefaultBlankRowCount As Integer = 18 ''20 ''Added 4/4/2023 td


    Public Shared Function GetListOfRecipients(par_cache As CacheRSCFieldColumnWidthsEtc) As List(Of ciBadgeRecipients.ClassRecipient)
        ''
        ''Added 7/10/2022 thomas downes
        ''
        ''We will fill a spreadsheet but not display it. We will then call
        ''  a spreadsheet function which will create Recipient objects 
        ''  from each of the rows. ----7/10/2022 td 
        ''






    End Function ''End of ""Public Shared Function GetListOfRecipients""


    Public Property RowDisplayCardHeight As Integer ''= 0 ''Added 5/30/2022 td
        ''= 0 ''Added 5/30/2022 td
        Get
            Return mod_intRowDisplayCardHeight
        End Get
        Set(value As Integer)
            mod_intRowDisplayCardHeight = value
            ''RscRowHeaders1.RowDisplayCardHeight = value
        End Set
    End Property


    Public Function RSCFieldColumn_Leftmost() As RSCFieldColumnV2
        ''Added 3/31/2022 td
        Return RscFieldColumn1
    End Function


    Public Function ListOfColumns() As List(Of RSCFieldColumnV2)

        ''Added 4/18/2023 
        Return mod_managerRowsCols.Cols.ListOfColumns()

    End Function ''End of ""Public Function ListOfColumns() As List(Of RSCFieldColumn)""


    ''Public Function ListOfColumns_NotInUse() As List(Of RSCFieldColumnV2)
    ''
    ''    ''Added 3/21/2022 thomas downes
    ''    ''\\---Return New List(Of RSCFieldColumn)(mod_array_RSCColumns)
    ''    Dim oList As List(Of RSCFieldColumnV2)
    ''    ''4/17/2023 oList = New List(Of RSCFieldColumnV2)(mod_array_RSCColumns)
    ''    oList = New List(Of RSCFieldColumnV2)(mod_dict_RSCColumns.Values)
    ''    oList.Remove(Nothing) ''Item #0 is Nothing, so let's omit the Null reference. 
    ''    Return oList
    ''
    ''End Function ''End of ""Public Function ListOfColumns_NotInUse() As List(Of RSCFieldColumn)""


    Public Shared Function GetRSCSpreadsheet(par_designer As ClassDesigner,
                                       par_formParent As Form,
                                      par_nameOfControl As String) As RSCFieldSpreadsheet
        ''
        ''Added 3/21/2022 td
        ''
        Dim objParametersGetElementCtl As ClassGetElementControlParams
        objParametersGetElementCtl = par_designer.GetParametersToGetElementControl()

        ''Added 5/30/2022 td
        Dim objElementForSpreadsheet As New ciBadgeElements.ClassElementBase
        objParametersGetElementCtl.ElementObject = objElementForSpreadsheet

        Return GetRSCSpreadsheet(objParametersGetElementCtl, par_formParent, par_nameOfControl,
                                    par_designer, False,
                                    CType(par_designer.ControlLastTouched, ILastControlTouched),
                                    CType(par_designer, IRecordElementLastTouched),
                                    par_designer.GroupMoveEvents)

    End Function ''End of "Public Shared Function GetRSCSpreadsheet"

    Public Shared Function GetRSCSpreadsheet(par_parametersGetElementControl As ClassGetElementControlParams,
                                       par_formParent As Form,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                      par_bProportionSizing As Boolean,
                                      par_iControlLastTouched As ILastControlTouched,
                                     par_iRecordLastControl As IRecordElementLastTouched,
                                     par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton) _
                                     As RSCFieldSpreadsheet
        ''
        ''Added 3/20/2022 td
        ''
        ''Unused. Jan17 2022''Const c_enumElemType As EnumElementType = EnumElementType.Portrait
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsFieldSheet As Operations_RSCSpreadsheet ''Modified 3/13/2022 td 
        Dim sizeElementPortrait As New Size() ''Added 1/26/2022 td

        ''Added 1/5/2022 td
        ''If (par_field Is Nothing) Then Throw New Exception("The Field is missing!")

        ''Instantiate the Operations Object. 
        ''
        objOperationsFieldSheet = New Operations_RSCSpreadsheet() ''Added 3/20/2022 td
        typeOps = objOperationsFieldSheet.GetType()
        objOperations = objOperationsFieldSheet

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.RSCSheetSpreadsheet ''March 23 2022''.FieldSheetSpreadsheet

        ''Create the control. 
        Dim CtlFieldSheet1 = New RSCFieldSpreadsheet(par_parametersGetElementControl,
                                                     par_formParent,
                                        par_iLayoutFun,
                                        par_parametersGetElementControl.iRefreshPreview,
                                        sizeElementPortrait,
                                        par_bProportionSizing,
                                        typeOps, objOperations,
                                        bAddFunctionalitySooner,
                                        bAddFunctionalitySooner,
                                        bAddFunctionalitySooner,
                                        par_iControlLastTouched,
                                        par_oMoveEventsForGroupedCtls)
        ''Jan2 2022 ''        ''Jan2 2022 ''par_iSaveToModel, typeOps,

        With CtlFieldSheet1
            .Name = par_nameOfControl
            ''1/11/2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            ''03/20/2022 ''If (bAddFunctionalityLater) Then .AddMoveability(par_iLayoutFun,
            ''                               par_oMoveEventsForGroupedCtls, Nothing)
            If (bAddFunctionalityLater) Then .AddClickability()

            .RightclickMouseInfo = objOperationsFieldSheet ''Added 3/5/2022 td

        End With ''eNd of "With CtlPortrait1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        With objOperationsFieldSheet

            .CtlCurrentControl = CtlFieldSheet1
            .CtlCurrentElement = CtlFieldSheet1
            ''.Designer = par_oMoveEventsForGroupedCtls.
            .Designer = par_parametersGetElementControl.DesignerClass
            ''.ElementInfo_Base = Nothing ''3/9/2022 t*d*''par_elementPortrait
            .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager
            ''Feb3 2022 td''.Element_Type = Enum_ElementType.StaticGraphic
            .Element_Type = Enum_ElementType.RSCSheetSpreadsheet ''Added 3/20/2022 thomas d.
            .EventsForMoveability_Group = Nothing ''par_oMoveEventsForGroupedCtls
            .EventsForMoveability_Single = Nothing
            ''Added 1/24/2022 thomas downes
            .LayoutFunctions = .Designer

            ''Added 3/20/2022 thomas dRRoRRwRRnRReRRsRR
            .ParentSpreadsheet = CtlFieldSheet1 ''----par_oSpreadsheet
            ''.ColumnIndex = par_intColumnIndex

        End With ''End of "With objOperationsFieldSheet"

        ''
        ''Return output value.
        ''
        Return CtlFieldSheet1

    End Function ''end of "Public Shared Function GetRSCSpreadsheet() As RSCFieldSpreadsheet"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub New(par_parameters As IGetElementControlParameters,
                   par_oParentForm As Form,
                   par_iLayoutFun As ILayoutFunctions,
                   par_iRefreshPreview As IRefreshCardPreview,
                   par_iSizeDesired As Size,
                  pboolResizeProportionally As Boolean,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddSizeability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveEvents As GroupMoveEvents_Singleton)
        ''
        ''Added 3/20/2022 td
        ''
        ''May2022 MyBase.New(EnumElementType.RSCSheetSpreadsheet, Nothing,
        MyBase.New(EnumElementType.RSCSheetSpreadsheet,
                   par_parameters.ElementObject,
                   par_parameters.ElementsCache,
                   par_oParentForm,
                   pboolResizeProportionally,
                        par_iLayoutFun, par_iRefreshPreview, par_iSizeDesired,
                        par_operationsType, par_operationsAny,
                        pboolAddMoveability, pboolAddSizeability, pboolAddClickability,
                        par_iLastTouched, par_oMoveEvents,
                        CSng(100 / 150))
        ''          Jan2 2022'' par_iSaveToModel, par_iLayoutFun,

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''
        ''The spreadsheet doesn't need any moveability. ---3/20/2022 thomas 
        ''
        MyBase.RemoveMoveability() ''Added 3/20/2022 td

        ''Encapsulated 12/30/2021 td
        ''New_RSCFieldSheet(par_field, par_iLayoutFun)

    End Sub


    Public Property BackColorOfColumns() As System.Drawing.Color ''Added 3/13/2022 td
        Get
            Return mod_colorOfColumnsBackColor
        End Get
        Set(value As System.Drawing.Color)
            mod_colorOfColumnsBackColor = value
        End Set
    End Property


    Public Sub PasteData_FirstTry_NotInUse(par_stringPastedData As String)
        ''
        ''Added 2/22/2022 td
        ''
        Dim boolDataIsOkay As Boolean
        Dim strWarningMessage As String = ""
        Dim intNumRowLines As Integer = 0
        Dim intNumColumns As Integer = 0

        boolDataIsOkay = ReviewPastedData_IsOkay(Clipboard.GetText(), strWarningMessage,
              intNumRowLines, intNumColumns)

        ''
        ''Not completed.  See Public Sub PasteData_SecondTry()
        ''
        System.Diagnostics.Debugger.Break()

    End Sub ''ENd of "Public Sub PasteData(par_stringPastedData As String)"


    Public Sub PasteData_SecondTry()
        ''
        ''Added 5/13/2022 thomas downes  
        ''
        Dim columnLeftHandMost As RSCFieldColumnV2 = Nothing
        Dim boolException As Boolean
        Dim exceptionRSC As Exception
        Dim bColumnHasFocus As Boolean
        Dim boolDataIsOkay As Boolean
        Dim strWarningMsg As String = ""
        Dim intNumLines As Integer
        Dim intNumColumns As Integer

        boolDataIsOkay = ReviewPastedData_IsOkay(Clipboard.GetText(), strWarningMsg,
                                                 intNumLines, intNumColumns)

        Try
            ''columnLeftHandMost = mod_dict_RSCColumns(0)
            ''If (columnLeftHandMost Is Nothing) Then
            ''    columnLeftHandMost = mod_dict_RSCColumns(1)
            ''End If ''End of ""If (columnLeftHandMost Is Nothing) Then""
            columnLeftHandMost = mod_managerRowsCols.Cols.LeftHandColumn()

        Catch exceptionRSC
            boolException = True
        End Try

        ''---bColumnHasFocus = columnLeftHandMost.HasFocus
        Const c_bNeedsToHaveTextCaret As Boolean = False ''Added 5/13/2022
        bColumnHasFocus = columnLeftHandMost.FocusRelated_ColumnHasCellFocus(c_bNeedsToHaveTextCaret)

        If (bColumnHasFocus) Then
            ''Major data.  
            columnLeftHandMost.PasteDataFromClipboard()

        Else
            ''Modified 5/13/2022 thomas downes
            MessageBoxTD.Show_Statement("To use the Paste button, " +
                                        "please select the left-most column.",
               "(To select a column, click one of the cells inside the column.)" + vbCrLf_Deux +
               "(Alternatively, you may perform the CTRL-V operation from inside any data cell.")

        End If ''End of ""If (bColumnHasFocus) Then... Else..."

    End Sub ''End of ""Public Sub PasteData_SecondTry()""


    Public Sub MoveTextCaret_IfNeeded(par_intNewRowIndex As Integer)
        ''
        ''Added 5/13/2022 thomas downes
        ''
        mod_managerRowsCols.Cols.MoveTextCaret_IfNeeded(par_intNewRowIndex)

    End Sub



    Public Sub SaveToRecipient(par_objRecipient As ciBadgeRecipients.ClassRecipient,
                               par_iRowIndex As Integer,
                               Optional ByRef pboolFailure As Boolean = False,
                               Optional ByRef pintHowManyColumnsFailed As Integer = 0)
        ''
        ''Encapsulated 4/26/2023  
        ''
        mod_managerRowsCols.Cols.SaveToRecipient(par_objRecipient, par_iRowIndex,
                                         pboolFailure, pintHowManyColumnsFailed)

    End Sub



    Public Function GetRecipientByRowIndex(par_intRowIndex As Integer) As ciBadgeRecipients.ClassRecipient
        ''
        ''Added 4/14/2022 td
        ''
        ''May 20, 2022 Return RecipientsCache.ListOfRecipients(par_intRowIndex)
        With PersonalityCache_Recipients.ListOfRecipients
            If (par_intRowIndex >= .Count) Then
                Return Nothing
            Else
                Return .Item(par_intRowIndex)
            End If ''End of ""If (par_intRowIndex >= .count) Then... Else...""
        End With

    End Function ''End of ""Public Function GetRecipientByRowIndex""


    Public Function GetIndexOfColumn(par_column As RSCFieldColumnV2) As Integer
        ''
        ''Added 4/15/2022 td
        ''
        Return mod_managerRowsCols.Cols.GetIndexOfColumn(par_column)

    End Function ''end of Public Function GetIndexOfColumn(par_column As RSCFieldColumnV2) As Integer



    Public Function RunChecksAtClose_Okay() As Boolean
        ''
        ''Alias function added 6/29/2022 thomas 
        ''
        Return CheckAllOkay_AtClose()

    End Function ''End of ""Public Function RunChecksAtClose_Okay() As Boolean""


    Public Function Okay_ChecksForClosing() As Boolean
        ''
        ''Alias function added 6/29/2022 thomas 
        ''
        Return CheckAllOkay_AtClose()

    End Function ''End of ""Public Function Okay_ChecksForClosing() As Boolean""


    Public Function CheckAllOkay_AtClose(Optional pboolSaveToXML As Boolean = True) As Boolean
        ''
        ''Added 6/28/2022 thomas downes  
        ''
        Dim intCountUnassigned As Integer
        Dim boolMatchesRecips As Boolean
        Dim boolOutputOkay As Boolean
        Dim objTestSpreadsheet As New RSCFieldSpreadsheet()

        ''Save to XML, if requested. 
        If (pboolSaveToXML) Then
            ''Save to XML, as requested. 
            SaveDataColumnByColumnXML()
            SaveToRecipientsCacheXML()
        End If ''Endof ""If (pboolSaveToXML) Then"" 

        intCountUnassigned = CountOfColumnsWithoutFields()
        boolMatchesRecips = Equals_RecipientListAtClose()

        boolOutputOkay = boolMatchesRecips And (0 = intCountUnassigned)

        If (boolOutputOkay) Then

            MessageBoxTD.Show_Statement("Spreadsheet data matches Recipient List.")

        ElseIf (GlobalSettings.ShowWarnings Or GlobalSettings.Debugging) Then

            MessageBoxTD.Show_Warning("Warning, spreadsheet data doesn't match Recipient List.")

        End If



    End Function ''End of "Public Function CheckAllOkay_AtClose() As Boolean"



    Public Function CountOfColumnsWithoutFields(Optional ByRef pref_intCountAllColumns As Integer = 0) As Integer
        ''
        '' Added 5/25/2022  
        ''
        mod_managerRowsCols.Cols.CountOfColumnsWithoutFields()

    End Function ''End of ""Public Function CountOfColumnsWithoutFields() As Integer""



    Public Function ReviewColumnDisplayForRelevantFields_1to1(pboolMessageUser As Boolean) As DialogResult
        ''
        ''Encapsulated 4/26/2023
        ''
        Dim bUserWantsFieldsManager As Boolean

        Return mod_managerRowsCols.Cols.ReviewColumnDisplayForRelevantFields_1to1(pboolMessageUser,
                                    bUserWantsFieldsManager)

        If (bUserWantsFieldsManager) Then ShowFieldsManagement()

    End Function ''End of ""Public Function ReviewColumnDisplayForRelevantFields_1to1""




    Private Sub ShowFieldsManagement()
        ''
        ''Added 5/13/2022 td
        ''
        Dim form_ToShow As New DialogListBothTypeFields
        Dim dialog_result As DialogResult ''Added 3/23/2022 td

        ''Added 3/21/2022 td
        form_ToShow.ListOfFields_Standard = Me.ElementsCache_Deprecated.ListOfFields_Standard
        form_ToShow.ListOfFields_Custom = Me.ElementsCache_Deprecated.ListOfFields_Custom

        dialog_result =
           form_ToShow.ShowDialog()

        ''Added 3/23/2022 td
        If (dialog_result = DialogResult.OK) Then
            ''Added 3/23/2022 td
            Me.ElementsCache_Deprecated.SaveToXML()

            ''Added 4/13/2022 td
            ''----For Each each_colV2 As RSCFieldColumnV2 In mod_array_RSCColumns

            Load_FieldsFromCache(Me.ElementsCache_Deprecated)

            ''---Next each_colV2

        End If ''End of ""If (dialog_result = ...)"


    End Sub ''End of ""Private Sub ShowFieldsManagement()""


    Public Sub ShowRecipientsIDCard_All()
        ''
        ''Added 5/19/2022 thomas d
        ''
        Dim listRowHeaders0of2 As RSCRowHeaders
        Dim listRowHeaders1of2 As RSCSpreadManagerRowheaders
        Dim listRowHeaders2of2 As List(Of RSCRowHeader)

        listRowHeaders1of2 = mod_managerRowsCols.RowHeaders
        listRowHeaders2of2 = RscRowHeaders1.ListOfRowHeaders_TopToBottom

        For Each each_rowHdr As RSCRowHeader In listRowHeaders2of2

55555 =====


        Next each_row


    End Sub ''End of ""Public Sub ShowRecipientsIDCard_All()""


    Public Sub ShowRecipientsIDCard(par_objRecipient As ciBadgeRecipients.ClassRecipient)
        ''
        ''Added 5/19/2022 thomas d
        ''
        Dim objBadgeSideElementsFront As ClassBadgeSideLayoutV1
        Dim objBadgeSideElementsBackside As ClassBadgeSideLayoutV1
        Dim objBadgeSideElems As ClassBadgeSideLayoutV1
        ''May21 2022 ''Dim obj_generator As ciBadgeGenerator.ClassMakeBadge
        Dim obj_generator As ciBadgeGenerator.ClassMakeBadge2022
        Dim dialog_ToShow As DialogDisplayIDCardSides
        Dim objbadgeLayoutClass As New BadgeLayoutDimensionsClass
        Dim objBadgeImageFront As Drawing.Image = Nothing
        Dim objBadgeImageBackside As Drawing.Image = Nothing

        With objbadgeLayoutClass
            dialog_ToShow = New DialogDisplayIDCardSides
            .Width_Pixels = dialog_ToShow.pictureBadgeFrontside.Width
            .Height_Pixels = dialog_ToShow.pictureBadgeFrontside.Height
        End With

        With Me.ElementsCache_Deprecated
            ''5/20/2022 objBadgeSideElementsFront = .GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumFrontside)
            ''5/20/2022 objBadgeSideElementsBackside = .GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumBackside)
            objBadgeSideElementsFront = .GetAllBadgeSideLayoutElementsV1(EnumWhichSideOfCard.EnumFrontside, objbadgeLayoutClass)
            objBadgeSideElementsBackside = .GetAllBadgeSideLayoutElementsV1(EnumWhichSideOfCard.EnumBackside, objbadgeLayoutClass)
        End With

        ''May21 2022 thomas downes''obj_generator = New ciBadgeGenerator.ClassMakeBadge_Corrupt
        obj_generator = New ciBadgeGenerator.ClassMakeBadge2022

        ''
        ''Major call !!
        ''
        ''
        ''Step #1 of 2. Frontside of the card.  
        ''
        objBadgeSideElems = objBadgeSideElementsFront

        ''Aded 5/20/2022 thomas downes
        If (objBadgeSideElems.BackgroundImage Is Nothing) Then
            Dim bHasImageTitle = (0 < objBadgeSideElems.BackgroundImage_FTitle.Length)
            If (bHasImageTitle) Then
                ''Aded 5/20/2022 thomas downes
                MessageBoxTD.Show_Statement("Problem loading the background image. (Front of card)")
                ''May20 2022 ''Exit Sub
            End If ''End of "If (0 < objBadgeSideElems.BackgroundImage_FTitle.Length) Then"
        End If ''End of ""If (objBadgeSideElems.BackgroundImage Is Nothing) Then"

        ''
        ''Major call!!  
        ''
        objBadgeImageFront = obj_generator.MakeBadgeImage_AnySide(objbadgeLayoutClass,
                        objBadgeSideElems, Me.ElementsCache_Deprecated,
                        dialog_ToShow.pictureBadgeFrontside.Width,
                        dialog_ToShow.pictureBadgeFrontside.Height,
                        par_objRecipient,
                        Nothing, Nothing, Nothing, Nothing, Nothing)

        ''
        ''Step #2 of 2. Backside of the card.  
        ''
        Dim boolBacksideExists As Boolean ''Added 5/20/2022 td 
        boolBacksideExists = Me.ElementsCache_Deprecated.BadgeHasTwoSidesOfCard

        If (boolBacksideExists) Then

            objBadgeSideElems = objBadgeSideElementsBackside

            ''Aded 5/20/2022 thomas downes
            If (objBadgeSideElems.BackgroundImage Is Nothing) Then
                ''Aded 5/20/2022 thomas downes
                MessageBoxTD.Show_Statement("Problem loading the background image.  (Backside of card)")
                ''May20 2022 ''Exit Sub
            End If ''End of ""If (objBadgeSideElems.BackgroundImage Is Nothing) Then"

            ''
            ''Major call !! 
            ''
            objBadgeImageBackside = obj_generator.MakeBadgeImage_AnySide(objbadgeLayoutClass,
                            objBadgeSideElems, Me.ElementsCache_Deprecated,
                            dialog_ToShow.pictureBadgeFrontside.Width,
                            dialog_ToShow.pictureBadgeFrontside.Height,
                            par_objRecipient,
                            Nothing, Nothing, Nothing, Nothing, Nothing)

        End If ''End of ""If (boolBacksideExists) Then""

        Dim bNullOrEmpty As Boolean ''Added  8/27/2023
        Dim bIsWhitespace As Boolean ''Added  8/27/2023
        Dim bUnsubstantive As Boolean ''Added  8/27/2023
        Dim bSubstantialMessage As Boolean ''Added  8/27/2023

        ''Added  8/27/2023
        bNullOrEmpty = String.IsNullOrEmpty(obj_generator.Messages)
        bIsWhitespace = String.IsNullOrWhiteSpace(obj_generator.Messages)
        bUnsubstantive = (bNullOrEmpty Or bIsWhitespace)
        bSubstantialMessage = (Not bUnsubstantive)

        ''Added 1/23/2022 td
        ''Aud2023 If (Not String.IsNullOrEmpty(obj_generator.Messages)) Then
        If (bSubstantialMessage) Then
            ''Added 1/23/2022 td
            MessageBoxTD.Show_Statement(obj_generator.Messages)
        End If ''End of "If (bSubstantial) Then"

        ''Added 5/19/2022
        dialog_ToShow.BadgeImage_FrontSide = objBadgeImageFront
        dialog_ToShow.BadgeImage_BackSide = objBadgeImageBackside
        dialog_ToShow.ShowDialog()


    End Sub ''End of ""Public Sub ShowRecipientsIDCard""



    Private Function ReviewPastedData_IsOkay(par_stringPastedData As String,
                                             ByRef pref_message As String,
                                             ByRef pref_numLines As Integer,
                                             ByRef pref_numColumns As Integer) As Boolean
        ''
        ''Added 2/22/2022 Thomas Downes  
        ''
        Dim boolOneMoreLines As Boolean
        Dim intNumberOfColumns As Integer
        Dim intNumberOfColumns_Prior As Integer
        Dim boolOneOrMoreColumns As Boolean
        Dim array_rowsPasted As String()
        Dim array_values As String()
        Dim boolMismatchedColumnCount As Boolean
        Dim intRowIndex As Integer

        par_stringPastedData = "" ''Added 2/22/2022 

        ''Added 2/22/2022 thomas downes   
        If (String.IsNullOrEmpty(par_stringPastedData)) Then
            ''Messaging 
            pref_message = "Pasted data is null or zero-length string."
            Return False
        End If ''End of "If (String.IsNullOrEmpty(par_stringPastedData)) Then"

        array_rowsPasted = par_stringPastedData.Split(New String() {vbCrLf, vbCr, vbLf}, StringSplitOptions.None)

        ''
        ''Iterate through the rows of pasted data. 
        ''
        For Each each_row As String In array_rowsPasted

            intRowIndex += 1
            array_values = each_row.Split(New String() {vbTab}, StringSplitOptions.None)
            intNumberOfColumns = array_values.Count()
            If (intNumberOfColumns_Prior > 0) Then
                If (intNumberOfColumns <> intNumberOfColumns_Prior) Then
                    boolMismatchedColumnCount = True
                    pref_message = String.Format("Irregular data set. The number of columns goes from {0} to {1}, in row {2} of {3}.",
                             intNumberOfColumns_Prior, intNumberOfColumns,
                             intRowIndex, array_rowsPasted.Count())
                    Exit For
                End If ''end of "If (intNumberOfColumns <> intNumberOfColumns_Prior) Then"
            End If ''end of "If (intNumberOfColumns_Prior > 0) Then"
            intNumberOfColumns_Prior = intNumberOfColumns
        Next each_row

        pref_numColumns = CInt(IIf(boolMismatchedColumnCount, -1, intNumberOfColumns))
        pref_numLines = array_rowsPasted.Count
        Return (Not boolMismatchedColumnCount)

    End Function ''End of "Private Function ReviewPastedData_IsOkay()"


    Public Function GetNextColumn_RightOf(par_column As RSCFieldColumnV2) As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Return mod_managerRowsCols.Cols.GetNextColumn_RightOf(par_column)

        ''Dim each_column As RSCFieldColumnV2
        ''Dim boolMatches As Boolean
        ''Dim boolMatches_Prior As Boolean
        ''For Each each_column In mod_dict_RSCColumns.Values
        ''    boolMatches = (each_column Is par_column)
        ''    If (boolMatches_Prior) Then Return each_column
        ''    ''Prepare for the next iteration. 
        ''    boolMatches_Prior = boolMatches
        ''Next each_column
        ''Return Nothing

    End Function ''End of ""Public Function GetNextColumn_RightOf(....)""


    Public Function GetNextColumn_LeftOf(par_column As RSCFieldColumnV2) As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Return mod_managerRowsCols.Cols.GetNextColumn_LeftOf(par_column)

        ''Dim each_column As RSCFieldColumnV2
        ''Dim prior_column As RSCFieldColumnV2 = Nothing
        ''Dim boolMatches As Boolean
        ''Dim boolMatches_Prior As Boolean
        ''For Each each_column In mod_dict_RSCColumns.Values
        ''    boolMatches = (each_column Is par_column)
        ''    If (boolMatches) Then Return prior_column
        ''    ''
        ''    ''Prepare for the next iteration.
        ''    ''
        ''    prior_column = each_column
        ''    boolMatches_Prior = boolMatches
        ''Next each_column
        ''Return Nothing
    End Function ''End of ""Public Function GetNextColumn_LeftOf(....)""


    Public Function GetFirstColumn() As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Return mod_managerRowsCols.Cols.GetFirstColumn()

        ''4/2023 If (0 = mod_array_RSCColumns.Length) Then Return Nothing
        ''If (0 = mod_dict_RSCColumns.Values.Count) Then Return Nothing
        ''If (mod_dict_RSCColumns(0) Is Nothing) Then Return mod_dict_RSCColumns(1)
        ''Return mod_dict_RSCColumns(0)

    End Function ''End of ""Public Function GetNextColumn_RightOf(....)""


    Public Function GetRowHeaderByRowIndex(par_intRowIndex As Integer) As RSCRowHeader

        ''Added 5/13/2002 
        Dim objRowHeader As RSCRowHeader

        objRowHeader =
        RscRowHeaders1.GetRowHeaderByRowIndex(par_intRowIndex)

        Return objRowHeader

    End Function ''Endof ""Public Function GetRowHeaderByRowIndex""


    Private Sub RSCFieldSpreadsheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 3/10/2022 
        ''



    End Sub ''End of event handler Private Sub RSCFieldSpreadsheet_Load

    Public Sub Load_Form()
        ''
        ''Encapsulated 3/15/2022 & 3/10/2022 
        ''
        Const c_boolLetsAutoLoadColumns As Boolean = False ''False, as it may cause
        ''  weird design-time behavior.

        ''added 3/14/2022 td
        ''If (Me.ElementsCache_Deprecated Is Nothing) Then
        ''    ''Throw New Exception("Cache is missing")
        ''    MessageBoxTD.Show_Statement("Cache is missing")
        ''End If ''end of ""If (Me.ElementsCache_Deprecated Is Nothing) Then"'

        If (c_boolLetsAutoLoadColumns) Then
            ''
            ''We might not have a designer object at load-time.... set the parameter to Nothing. 
            ''
            Dim objDesigner As ClassDesigner = Nothing
            objDesigner = Me.Designer  ''Added 3/14/2022 td

            ''
            ''Major call!!
            ''
            If (StillHavingColumnTrouble) Then
                ''We need to find the loading procedure(s) which are causing problems. --4/11/2023
            Else
                ''5/31/2023 LoadRuntimeColumns_AfterClearingDesign(objDesigner)
                Const c_bLoadColumnListByCache As Boolean = True ''Added 5/31/2023
                Const c_bLoadColumnDataByCache As Boolean = True ''Added 5/31/2023
                LoadRuntimeColumns_AfterClearingDesign(objDesigner,
                                                       c_bLoadColumnListByCache,
                                                        c_bLoadColumnDataByCache, False)

            End If ''End of ""If (StillHavingColumnTrouble) Then... Else..."

        End If ''End of " If (c_boolLetsAutoLoadColumns) Then"

        ''
        ''Added 3/28/'2022 thomas downes 
        ''
        If (StillHavingColumnTrouble) Then
            ''We need to find the loading procedure(s) which are causing problems. --4/11/2023
        Else
            Load_Recipients()
        End If ''End of ""If (StillHavingColumnTrouble) Then... Else..."

        ''''
        ''''Added 4/11/2022 td
        ''''
        ''Dim intTopOfGrid As Integer
        ''intTopOfGrid = (RscFieldColumn1.Top + RscFieldColumn1.GetFirstRSCDataCell().Top)
        ''8/26/2023 RscRowHeaders1.Top = intTopOfGrid

    End Sub ''End of event handler Private Sub RSCFieldSpreadsheet_Load


    Public Sub Load_Recipients()
        ''
        ''Added 3/28/'2022 thomas downes 
        ''
        If (Me.PersonalityCache_Recipients Is Nothing) Then

            ''Added 3/29/2022 thomas d.
            MessageBoxTD.Show_Statement("Not any recipients cache.")

        Else
            ''
            ''Added 3/28/2022 thomas downes
            ''
            Dim bAreData_DangerOfOverwritten As Boolean
            Dim bColumnHasNoField As Boolean
            Dim bListHasNoRecipients As Boolean
            Dim list_columns As List(Of RSCFieldColumnV2)
            Dim intNumberOfRecipients As Integer ''Added 4/5/2022

            list_columns = ListOfColumns() ''Added 3/30/2022 thomas d. 

            ''Added 4/5/2022 td
            ''
            ''Create row headers. 
            ''
            intNumberOfRecipients = Me.PersonalityCache_Recipients.ListOfRecipients.Count
            RscRowHeaders1.Load_EmptyRows(intNumberOfRecipients)
            ''Moved below. 4/6/2022 ''RscRowHeaders1.RefreshHeightOfHeaders(intNumberOfRecipients) ''Added 4/6/2022 td

            ''
            ''Load the data into the RSCRowHeaders control.---5/14/2022
            ''
            RscRowHeaders1.ListRecipients = Me.PersonalityCache_Recipients.ListOfRecipients
            RscRowHeaders1.LoadRecipientList(bListHasNoRecipients)

            ''
            ''Fill each of the columns. 
            ''
            For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()

                ''Added 3/29/2022 thomas d.
                ''
                ''Clear out the existing data from the column.
                ''
                ''March29 2022 td''If (each_column.CountOfBoxesWithData() > 0) Then
                bAreData_DangerOfOverwritten = (0 < each_column.CountOfBoxesWithData())
                If (bAreData_DangerOfOverwritten) Then
                    ''3/29/2022 td''each_column.ClearDataFromColumn_Do()
                    Dim bUserCancelled As Boolean ''March29 2022
                    ''April 1, 2022 td'' Me.ClearDataFromSpreadsheet_1stConfirm(bUserCancelled)
                    ''April 15, 2022''Me.ClearDataFromSpreadsheet_NoConfirm() '' (bUserCancelled)
                    ''April 15, 2022''Threading.Thread.Sleep(500)
                    Application.DoEvents()
                    If (bUserCancelled) Then Exit Sub
                End If ''End of ""If (bAreData_DangerOfOverwritten) Then""

                ''Add an needed object reference. ----3/29/2022 thomas d.
                each_column.ListRecipients = Me.PersonalityCache_Recipients.ListOfRecipients

                bAreData_DangerOfOverwritten = False ''Reinitialize.

                ''Added 3/28/2022 thomas d.
                ''
                ''Load the data into the column.
                ''
                each_column.LoadRecipientList(bAreData_DangerOfOverwritten,
                                              bColumnHasNoField, bListHasNoRecipients)

                If (bAreData_DangerOfOverwritten) Then
                    Exit For
                End If

                If (bColumnHasNoField) Then
                    Continue For
                End If

                If (bListHasNoRecipients) Then
                    Exit For
                End If

            Next each_column


            ''Added 4/6/2022 thomas downes
            RscRowHeaders1.RefreshHeightOfHeaders(intNumberOfRecipients) ''Added 4/6/2022 td

            ''
            ''Ensure the needed # of RSCDataCells are present across all columns.----4/15/2022
            ''
            ''4/26/2023 Load_EmptyRowsToAllNewColumns()
            mod_managerRowsCols.Rows.Load_EmptyRowsToAllNewColumns()

            ''Dim intEachRowCount As Integer = 1
            ''Dim intMaxRowCount As Integer = 1
            ''For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
            ''    intEachRowCount = each_column.CountOfRows()
            ''    If (intEachRowCount > intMaxRowCount) Then intMaxRowCount = intEachRowCount
            ''Next each_column

            ''For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
            ''    each_column.Load_EmptyRows(intMaxRowCount)
            ''Next each_column


        End If ''End of ""If (Me.RecipientsCache Is Nothing) Then.... Else....""


    End Sub ''End of event handler Private Sub RSCFieldSpreadsheet_Load



    Public Sub ClearBorderStyle_PriorCell(par_objNextCell As RSCDataCell)
        ''Added 4/28/2022 td
        Static s_objPriorCell As RSCDataCell
        If (s_objPriorCell IsNot Nothing) Then
            If (s_objPriorCell IsNot par_objNextCell) Then
                s_objPriorCell.BorderStyle_Textbox = BorderStyle.None
                ''Added 4/29/2022 thomas downes
                SetBackColor_ToRowDefault(s_objPriorCell)

            End If ''End of ""If (s_objPriorCell IsNot par_objNextCell) Then""
        End If ''End of ""If (s_objPriorCell IsNot Nothing) Then""

        ''Prepare for next calling to this procedure.
        If (s_objPriorCell Is Nothing) Then
            s_objPriorCell = par_objNextCell
        ElseIf (s_objPriorCell IsNot par_objNextCell) Then
            ''Only assign the object reference if it's different than the existing reference.
            s_objPriorCell = par_objNextCell
        End If ''End of ""If (s_objPriorCell IsNot par_objNextCell) Then""

    End Sub ''End of ""Public Sub ClearBorderStyle_PriorCellaaa(par_objNextCell As RSCDataCell)""


    Public Sub SetBackColor_ToRowDefault(par_objDataCell As RSCDataCell,
                         Optional pboolCheckForEmphasis As Boolean = True)
        ''
        ''Added 4/29/2022 td
        ''
        Dim intRowEmphasis_Start As Integer
        Dim intRowEmphasis_End As Integer
        Dim intRowOfDataCell As Integer

        If (pboolCheckForEmphasis) Then

            intRowEmphasis_Start = mod_intEmphasisRowIndex_Start
            intRowEmphasis_End = mod_intEmphasisRowIndex_End

            ''4/27/2023 td For Each each_column As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
            ''    If (each_column Is Nothing) Then Continue For
            ''    intRowOfDataCell = -1
            ''    intRowOfDataCell = each_column.GetRowIndexOfCell(par_objDataCell)
            ''    If (intRowOfDataCell > 0) Then Exit For
            ''Next each_column

            intRowOfDataCell = mod_managerRowsCols.GetRowIndexOfCell(par_objDataCell)

            Dim boolRowHasEmphasis As Boolean

            If (intRowEmphasis_Start > 0 And intRowOfDataCell > 0) Then
                ''Check that the Data-Cell Row is within the range of emphasis.
                If (intRowEmphasis_End = -1) Then intRowEmphasis_End = intRowEmphasis_Start
                boolRowHasEmphasis = (intRowEmphasis_Start <= intRowOfDataCell) And
                                 (intRowOfDataCell <= intRowEmphasis_End)
            End If ''End of ""If (intRowEmphasis_Start > 0) Then""

            If (boolRowHasEmphasis) Then

                ''--par_objDataCell.BackColor = RSCDataCell.BackColorWithEmphasis
                par_objDataCell.BackColor = RSCDataCell.BackColor_WithEmphasisOnRow

            Else
                par_objDataCell.BackColor = RSCDataCell.BackColor_NoEmphasis

            End If ''End of ""If (boolRowHasEmphasis) Then... Else...""

        Else
            par_objDataCell.BackColor = RSCDataCell.BackColor_NoEmphasis

        End If ''End of ""If (pboolCheckForEmphasis) Then ... Else ...."

    End Sub ''Endof ""Public Sub SetBackColor_ToRowDefault(par_objDataCell As RSCDataCell)""


    Public Sub ClearDataFromSpreadsheet_1stConfirm(Optional ByRef pboolUserCancelled As Boolean = False)
        ''
        ''Added 3/29/2022 thomas downes
        ''
        ''4/26/2023 Dim objRSCFieldColumn As RSCFieldColumnV2
        Dim boolConfirmed As Boolean

        boolConfirmed = (MessageBoxTD.Show_Confirmed("Clear all data from this spreadsheet?",
                          "(To undo this later, right-click & select Undo Clear Data.)", True))

        If (boolConfirmed) Then
            ''Confirmed, so clear the data from each column.  
            ''4/26/2023 For Each each_column As RSCFieldColumnV2 In Me.ListOfColumns
            ''    objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
            ''    objRSCFieldColumn.ClearDataFromColumn_Do()
            ''Next each_column
            mod_managerRowsCols.Cols.ClearDataFromSpreadsheet_NoConfirm()

        Else
            ''Added 3/29/2022 td
            pboolUserCancelled = True

        End If ''End of "If (boolConfirmed) Then"

    End Sub ''End of ""Public Sub ClearDataFromSpreadsheet_1stConfirm()""


    ''4/27/2023 Public Sub ClearDataFromSpreadsheet_NoConfirm()
    ''    ''
    ''    ''Added 4/01/2022 thomas downes
    ''    ''
    ''    Dim objRSCFieldColumn As RSCFieldColumnV2
    ''    Dim boolConfirmed As Boolean

    ''    For Each each_column As RSCFieldColumnV2 In Me.ListOfColumns
    ''        objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
    ''        objRSCFieldColumn.ClearDataFromColumn_Do()
    ''    Next each_column

    ''End Sub ''End of ""Public Sub ClearDataFromSpreadsheet_NoConfirm()""


    Public Sub ClearHighlightingOfSelectedColumns()
        ''
        ''Added 5/13/2022 thomas downes
        ''
        ''4/26/2023 Dim objRSCFieldColumn As RSCFieldColumnV2
        ''For Each each_column As RSCFieldColumnV2 In Me.ListOfColumns
        ''    objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
        ''    objRSCFieldColumn.FocusRelated_UserHasSelectedColumn = False
        ''    objRSCFieldColumn.FocusRelated_SetHighlightingOff()
        ''Next each_column
        mod_managerRowsCols.Cols.ClearHighlightingOfSelectedColumns()

    End Sub ''End of ""Public Sub ClearHighlightingOfSelectedColumns()""



    Public Sub LoadRuntimeColumns_AfterClearingDesign(par_designer As ClassDesigner,
                    par_bLoadColumnListByReadingColumnCache As Boolean,
                    par_bLoadColumnDataByReadingColumnCache As Boolean,
                    par_bLoadColumnDataByListOfRecipients As Boolean)
        ''
        ''Added 3/8/2022 thomas downes 
        ''
        ''Major call!!
        ''
        If (mod_managerRowsCols Is Nothing) Then
            ''Add new column-and-row manager.  ---4/30/2023 thomas downes
            mod_managerRowsCols = New RSCSpreadManagerRowsCols(Me, par_designer, RscFieldColumn1,
                  Me.ElementsCache_Deprecated, Me.ColumnDataCache,
                    par_bLoadColumnListByReadingColumnCache,
                    par_bLoadColumnDataByReadingColumnCache,
                    par_bLoadColumnDataByListOfRecipients)
        End If ''End of ""If (mod_manager Is Nothing) Then""

        ''4/26/2023 mod_manager.Cols.LoadRuntimeColumns_AfterClearingDesign(par_designer)
        mod_managerRowsCols.Cols.LoadRuntimeColumns_AfterClearingDesign(par_designer,
                                                     mc_intPixelsFromRowToRow,
                                                par_bLoadColumnListByReadingColumnCache,
                                                par_bLoadColumnDataByReadingColumnCache,
                                                par_bLoadColumnDataByListOfRecipients)
        ''Probably not needed. mod_manager.Rows = mod_manager.GetSpreadManagerRows()

        ''
        ''Step 1b of 5.  Load run-time row-header control (RSCRowHeaders1). ----3/24/2022 
        ''
        ''   Step 1b(1):  Remove design-time control
        ''   Step 1b(2):  Load run-time control
        ''
        mod_managerRowsCols.LoadRowHeadersControl(mc_intPixelsFromRowToRow)

        ''---Dim mod_array_RSCColumns As RSCFieldColumn()
        Dim intNeededMaxCols As Integer
        intNeededMaxCols = mod_managerRowsCols.Cols.Count()
        If (intNeededMaxCols > 1) Then ''Added 5/30/2022
            ''added 5/30/2022 & 5/13/2022
            If mc_boolKeepUILookingClean Then
                ''Hide the buttons which formerly occupied the blank area
                '' of the spreadsheet. ---5/13/2022 
                ButtonAddColumns2.Visible = False
                ButtonPasteData2.Visible = False
            End If ''End of ""If c_boolKeepUILookingClean Then""
        End If ''End of ""If (intNeededMax > 1) Then""

        ''
        ''Step 6 of 6.  Resize the form itself. 
        ''
        ''4/2023 If (Me.ColumnDataCache.FormSize.Width > mc_ColumnWidthDefault) Then
        If (Me.ColumnDataCache.FormSize.Width > RscFieldColumn1.Width) Then
            ''
            ''Resize the form based on the save form size.
            ''
            Me.ParentForm_DesignerDialog.Size = Me.ColumnDataCache.FormSize

        End If ''end of ""If Me.ColumnDataCache.FormSize.Width > 100 Then""

        ''
        ''Step 8 of 8.  Make sure that the Row Headers match the longest column of data
        ''       inside the cache collection Me.ColumnDataCache. 
        ''       ----6/22/2022 thomas d. 
        ''
        ''5/31/2023  With Me.ColumnDataCache
        ''
        ''    RscRowHeaders1.ColumnDataCache = Me.ColumnDataCache
        ''
        ''    ''5/31/2023 If (Me.LoadByReadingColumnCache) Then
        ''    If (Me.LoadColumnListByReadingColumnCache) Then
        ''        ''
        ''        ''Does this load prior session's data into the columns, e.g. "Robin Forbes", etc.?  
        ''        ''  ---5/22/2023
        ''#1 5/31/2023 RscRowHeaders1.Load_ColumnListDataToColumnEtc() ''What is this for??  Only to determine the number of row headers?---5/31/2023
        ''#2 5/31/2023 RscRowHeaders1.Load_ColumnListDataToColumnEtc_DepricatedJune2023() ''What is this for??  Only to determine the number of row headers?---5/31/2023
        ''
        ''    End If ''ENd of ""If (Me.LoadByReadingColumnCache) Then""
        ''
        ''End With ''End of""With Me.ColumnDataCache""

        ''
        ''Step 9 of 11. 
        ''
        ''Moved to Row Manager, RSCSpreadManagerRows.  4/26/2023
        ''4/26/2023  Load_EmptyRowsToAllNewColumns()
        mod_managerRowsCols.Rows.Load_EmptyRowsToAllNewColumns()

    End Sub  ''End of ""Public Sub LoadRuntimeColumns_AfterClearingDesign(par_designer As ClassDesigner)""



    Public Sub AddToEdgeOfSpreadsheet_Row()

        ''Added 4/24/2023 thomas downes
        mod_managerRowsCols.Rows.AddToEdgeOfSpreadsheet_Row()

    End Sub ''End of ""Public Sub AddToEdgeOfSpreadsheet_Row()""


    Public Sub AddToEdgeOfSpreadsheet_Column()

        ''Added 4/18/2023 thomas downes
        mod_managerRowsCols.Cols.AddToEdgeOfSpreadsheet_Column(mc_intPixelsFromRowToRow)

        ''Added 4/26/2023 thomas downes
        If mc_boolKeepUILookingClean Then
            ''Hide the buttons which formerly occupied the blank area
            '' of the spreadsheet. ---5/13/2022 
            ButtonAddColumns2.Visible = False
            ButtonPasteData2.Visible = False
        End If ''End of ""If mc_boolKeepUILookingClean Then""

    End Sub ''End of ""Public Sub AddToEdgeOfSpreadsheet_Column()""



    Public Sub AlignRowHeadersWithSpreadsheet()
        ''
        ''Added 3/25/2022 thomas downes
        ''
        ''3/25/2022 td''RscRowHeaders1.AlignControlsWithSpreadsheet()
        ''4/09/2022 td''Dim listBoxesColumn As List(Of TextBox)
        Dim listBoxesColumn As List(Of RSCDataCell)
        ''4/5/2022 Dim listBoxesRowHeader As List(Of TextBox)
        ''4/6/2022 Dim listBoxesRowHeader As List(Of Label)
        Dim listBoxesRowHeader As List(Of RSCRowHeader)

        ''4/09/2022 td ''listBoxesColumn = RscFieldColumn1.ListOfTextBoxes_TopToBottom()
        listBoxesColumn = RscFieldColumn1.ListOfRSCDataCells_TopToBottom()
        listBoxesRowHeader = RscRowHeaders1.ListOfRowHeaders_TopToBottom()

        ''March25 2022''RscRowHeaders1.AlignControlsWithSpreadsheet(listBoxesColumn)
        RscRowHeaders1.AlignControlsWithSpreadsheet(RscFieldColumn1)

    End Sub ''End of "Public Sub AlignRowHeadersWithSpreadsheet()"


    Public Sub RefreshHeightOfRowHeaders()
        ''
        ''Added 4/6/2022 thomas d.
        ''
        RscRowHeaders1.RefreshHeightOfHeaders()

    End Sub ''End of "Public Sub RefreshHeightOfRowHeaders()"


    Public Sub RefreshLeftEdgeOfColumns()
        ''
        ''Added 4/6/2022 thomas d.
        ''
        mod_managerRowsCols.Cols.RefreshAllColumnsLeftProperty()

    End Sub ''End of ""Public Sub RefreshLeftEdgeOfColumns()""


    Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 2/16/2022 thomas downes
        ''
        Const c_bLoadColumnListByCache As Boolean = True ''Added 5/31/2023
        Const c_bLoadColumnDataByCache As Boolean = True ''Added 5/31/2023

        ''5/31/2023 LoadRuntimeColumns_AfterClearingDesign(Nothing)
        LoadRuntimeColumns_AfterClearingDesign(Nothing,
            c_bLoadColumnListByCache,
              c_bLoadColumnDataByCache, False) ''mod_designer)

    End Sub ''end of sub "Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)"


    Public Sub EmphasizeCol_Highlight(par_column As RSCFieldColumnV2,
                                       Optional pboolDemphasizeOthers As Boolean = False)
        ''
        ''Added 6/10/2023
        ''
        mod_managerRowsCols.Cols.EmphasizeColumn_Highlight(par_column, pboolDemphasizeOthers)

    End Sub ''End of ""Public Sub EmphasizeCol_High light""



    Public Sub EmphasizeRows_Highlight(par_intRowIndex_Start As Integer,
                     Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/29/2022 td
        ''
        mod_intEmphasisRowIndex_Start = par_intRowIndex_Start
        mod_intEmphasisRowIndex_End = par_intRowIndex_End
        If (-1 = mod_intEmphasisRowIndex_End) Then
            mod_intEmphasisRowIndex_End = mod_intEmphasisRowIndex_Start
        End If

        ''Encapsulated 4/28/2023 
        mod_managerRowsCols.EmphasizeRows_Highlight(par_intRowIndex_Start, par_intRowIndex_End)

        ''4/28/2023 For Each each_col As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        ''
        ''    If (each_col Is Nothing) Then Continue For ''Added 4/29/2022 thomas d
        ''
        ''    ''---each_col.PaintEmphasisOfRows(par_intRowIndex_Start, par_intRowIndex_End)
        ''    each_col.EmphasizeRows_Highlight(par_intRowIndex_Start, par_intRowIndex_End)
        ''
        ''Next each_col


    End Sub ''End of ""Public Sub EmphasizeRows_Highlight"


    Public Sub DeemphasizeRows_NoHighlight(par_intRowIndex_Start As Integer,
                      Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/29/2022 td
        ''
        mod_managerRowsCols.Cols.DeemphasizeRows_NoHighlight(par_intRowIndex_Start, par_intRowIndex_End)

        ''4/26/2023 For Each each_col As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        ''    If (each_col Is Nothing) Then Continue For ''Added 4/29/2022 td 
        ''    each_col.DeemphasizeRows_NoHighlight(par_intRowIndex_Start, par_intRowIndex_End)
        ''Next each_col

    End Sub ''End of ""Public Sub EmphasizeRows_Highlight"


    Public Function HasIdentifyingData() As Boolean
        ''
        ''Added 5/14/2022 thomas downes 
        ''
        Return mod_managerRowsCols.Cols.HasIdentifyingData()

        ''4/28/2028 Dim each_column As RSCFieldColumnV2
        ''Dim bColHasIdentifyingData As Boolean
        ''For Each each_column In mod_dict_RSCColumns.Values
        ''    If (each_column Is Nothing) Then Continue For
        ''    bColHasIdentifyingData = each_column.HasIdentifyingData()
        ''    If (bColHasIdentifyingData) Then Return True
        ''Next each_column
        ''Return False

    End Function ''End of ""Public Function HasIdentifyingData() As Boolean""


    Private Sub RemoveRSCColumnsFromDesignTime()
        ''
        ''Added 3/8/2022 thomas d
        ''
        mod_managerRowsCols.Cols.RemoveRSCColumnsFromDesignTime()

    End Sub ''End of ""Private Sub RemoveRSCColumnsFromDesignTime()""


    Public Sub AddColumnsToRighthandSide(par_intNumber As Integer)
        ''
        ''Added 3/16/2022 Thomas Downes 
        ''
        mod_managerRowsCols.Cols.AddColumnsToRighthandSide(par_intNumber, mc_intPixelsFromRowToRow)

    End Sub ''ENd of "Public Sub AddColumnsToRighthandSide(par_intNumber As Integer)""





    Public Sub SaveDataColumnByColumnXML(Optional pboolOpenXML As Boolean = False)

        ''Added 8/26/2023 
        mod_managerRowsCols.Cols.RefreshColumnsInDataCache()

        ''Encapsulated 4/26/2023 td
        mod_managerRowsCols.Cols.SaveDataColumnByColumnXML(pboolOpenXML)

        ''
        ''Resize the form based on the save form size.---3/20/2022
        ''
        Const c_bUpdateAfterSave_Useless As Boolean = True ''False
        If (c_bUpdateAfterSave_Useless) Then
            Me.ColumnDataCache.FormSize = Me.ParentForm_DesignerDialog.Size
            ''Added 5/6/2023 td
            Me.ColumnDataCache.FormLocation = Me.ParentForm_DesignerDialog.Location
        End If ''End of ""If (c_bUpdateAfterSave_Useless) Then""

    End Sub ''End of "Public Sub SaveDataColumnByColumnXML()"


    Public Sub SaveToRecipientsCacheXML()
        ''
        ''Added 7/01/2022 thomas downes 
        ''
        Dim objCachePersonalRecips As CachePersnltyCnfgLRecips ''7/4/2022 ciBadgeCachePersonality.ClassCacheOnePersonalityConfig
        Dim objCacheRecips As New ClassCacheListRecipients
        Dim objListRecips As List(Of ciBadgeRecipients.ClassRecipient)

        objCachePersonalRecips = Me.PersonalityCache_Recipients
        objListRecips = Me.PersonalityCache_Recipients.ListOfRecipients

        objCachePersonalRecips.SaveToXML() ''Added 7/4/2022 thomas downes



    End Sub ''End of ""Public Sub SaveToRecipientsCacheXML()""


    Public Sub InsertNewColumnByIndex(par_intColumnIndex As Integer)
        ''    ''
        ''    ''Added 3/20/2022 thomas downes 
        ''    ''
        mod_managerRowsCols.Cols.InsertNewColumnByIndex(par_intColumnIndex, mc_intPixelsFromRowToRow)

    End Sub ''End of ""Public Sub InsertNewColumnByIndex(par_intColumnIndex As Integer)""


    Public Sub InsertColumnLeftOfSpecified(par_column As RSCFieldColumnV2)
        ''    
        ''Added 5/08/2023 thomas downes 
        ''    
        mod_managerRowsCols.Cols.InsertColumnLeftOfSpecified(par_column, mc_intPixelsFromRowToRow)

    End Sub ''End of ""Public Sub InsertColumnLeftOfSpecified(par_intColumnIndex As Integer)""


    Public Sub SwitchColumnToLeftOfSpecified(par_column As RSCFieldColumnV2)
        ''    
        ''Added 6/18/2023 thomas downes 
        ''    
        ''mod_manager.Cols.SwitchColumnToTheLeft(par_column)
        ''mod_manager.Cols.ShiftColumnToTheLeft(par_column)
        ''mod_manager.Cols.MoveColumnToTheLeft(par_column)
        mod_managerRowsCols.Cols.SwitchColumnWithOneToTheLeft(par_column)

    End Sub ''End of ""Public Sub SwitchColumnToLeftOfSpecified(par_column As RSCFieldColumnV2)""


    Public Sub SwitchColumnToRightOfSpecified(par_column As RSCFieldColumnV2)
        ''    
        ''Added 6/18/2023 thomas downes 
        ''    
        ''mod_manager.Cols.SwitchColumnToTheRight(par_column)
        ''mod_manager.Cols.ShiftColumnToTheRight(par_column)
        ''mod_manager.Cols.MoveColumnToTheRight(par_column)
        mod_managerRowsCols.Cols.SwitchColumnWithOneToTheRight(par_column)

    End Sub ''End of ""Public Sub SwitchColumnToLeftOfSpecified(par_column As RSCFieldColumnV2)""


    Public Sub InsertColumnRightOfSpecified(par_column As RSCFieldColumnV2,
                                            Optional pint_howManyNewColumns As Integer = 1)
        ''    
        ''Added 5/20/2023 thomas downes 
        ''    
        ''5/22/2023 mod_manager.Cols.InsertColumnRightOfSpecified(par_column, mc_intPixelsFromRowToRow)

        ''By default, this For-Next loop runs for exactly one(1) iteration. ---5/22/2023
        For indexNew As Integer = 1 To pint_howManyNewColumns

            ''By default, this Insert procedure exactly one(1) time. ---5/22/2023
            mod_managerRowsCols.Cols.InsertColumnRightOfSpecified(par_column, mc_intPixelsFromRowToRow)

        Next indexNew

    End Sub ''End of ""Public Sub InserColumnRightOfSpecified(par_intColumnIndex As Integer)""


    Public Sub DeleteRecipientFromCache(par_recipient As ciBadgeRecipients.ClassRecipient)
        ''
        ''Added 5/1/2022 td
        ''
        Me.PersonalityCache_Recipients.ListOfRecipients.Remove(par_recipient)

    End Sub ''End of ""Public Sub DeleteRecipientFromCache(....)""


    Public Sub DeleteColumnByIndex(par_intColumnIndex As Integer)
        ''
        ''Added 4/18/2022 thomas downes 
        ''
        mod_managerRowsCols.Cols.DeleteColumnByIndex(par_intColumnIndex)

    End Sub ''ENd of ""Public Sub DeleteColumnByIndex""


    Public Sub DeleteColumn(par_columnToDelete As RSCFieldColumnV2, par_intColumnIndex As Integer)
        ''
        ''Added 4/18/2022 thomas downes 
        ''
        ''5/7/2023 mod_manager.Cols.DeleteColumnByIndex(par_intColumnIndex)
        mod_managerRowsCols.Cols.DeleteColumn(par_columnToDelete, par_intColumnIndex)

    End Sub ''ENd of ""Public Sub DeleteColumnByIndex""


    Public Sub UndoLastColumnDeletion()
        ''
        ''Added 5/9/2023 
        ''
        mod_managerRowsCols.Cols.UndoLastColumnDeletion()

    End Sub ''ENd of ""Public Sub UndoLastColumnDeletion()""

    Public Sub ReviewRelevantFieldsViaDialogForm()
        ''
        ''We will open the All-Fields dialog (Standard & Custom fields).  ---4/13/2022 td
        ''
        Static s_bMsgOnce As Boolean
        If (Not s_bMsgOnce) Then
            ''Added 4/13/2022 td
            MessageBoxTD.Show_Statement("We will open the Fields dialog, " &
                  "to allow the user to add more fields." & vbCrLf_Deux &
                  "Hit the Relevant checkbox to include the field.",
                   "((one-time message)")
            s_bMsgOnce = True
        End If ''End of ""If (Not s_bMsgOnce) Then""

        ''Major call!!!!   4/13/2022 thomas 
        ''Dim obj_show As DialogListBothTypeFields
        ''obj_show = New DialogListBothTypeFields()
        ''obj_show.ShowDialog()
        ''RscFieldSpreadsheet1.RefreshFieldDropdowns()

        Dim form_ToShow As New DialogListBothTypeFields
        Dim dialog_result As DialogResult ''Added 4/13 & 3/23/2022 td

        ''Added 4/13 & 3/21/2022 td
        form_ToShow.ListOfFields_Standard = Me.ElementsCache_Deprecated.ListOfFields_Standard
        form_ToShow.ListOfFields_Custom = Me.ElementsCache_Deprecated.ListOfFields_Custom

        dialog_result =
           form_ToShow.ShowDialog()

        ''Added 4/13 & 3/23/2022 td
        If (dialog_result = DialogResult.OK) Then
            ''Added 3/23/2022 td
            Me.ElementsCache_Deprecated.SaveToXML()

            ''Refresh the list of fields above each column. 
            RefreshFieldDropdowns()

        End If ''End of ""If (dialog_result = ...)"


    End Sub ''End of ""Public Sub ReviewRelevantFieldsViaDialogForm()""


    Public Sub RefreshFieldDropdowns()
        ''
        ''Added 4/13/2022 thomas downes
        ''
        mod_managerRowsCols.Cols.RefreshFieldDropdowns()

        ''4/2023 For Each each_column As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        ''    ''Added 4/13/2022 thomas downes
        ''    If (each_column IsNot Nothing) Then
        ''        each_column.RefreshFieldDropdown()
        ''    End If ''end of "If (each_column IsNot Nothing) Then"

        ''Next each_column

    End Sub ''End of "Public Sub RefreshFieldDropdowns()"


    Public Sub SwitchColumnPositions(par_column As RSCFieldColumnV2, par_doSwitchLeft As Boolean)
        ''
        ''Added 8/25/2023 
        ''
        Try
            If (par_doSwitchLeft) Then
                mod_managerRowsCols.Cols.SwitchColumnWithOneToTheLeft(par_column)
            Else
                mod_managerRowsCols.Cols.SwitchColumnWithOneToTheRight(par_column)
            End If

        Catch ex_switch As Exception
            ''
            ''Added 8/26/2023
            ''
            RSCErrorLogging.Log(345, "SwitchColumnPositions", ex_switch.Message)

        End Try

    End Sub ''Public Sub SwitchColumnPositions



    Public Function ToString_ByRow(par_intRowIndex As Integer,
                        Optional pboolRowIndices As Boolean = False) As String
        ''
        ''Added 4/03/2022
        ''
        Return mod_managerRowsCols.Cols.ToString_ByRow(par_intRowIndex, pboolRowIndices)

        ''Dim intCountColumns As Integer
        ''Dim list_columns As List(Of RSCFieldColumnV2)
        ''Dim each_column As RSCFieldColumnV2
        ''Dim strValue As String
        ''Dim strLine As String = ""
        ''If (pboolRowIndices) Then strLine = par_intRowIndex.ToString
        ''list_columns = ListOfColumns()
        ''intCountColumns = list_columns.Count()
        ''For intColIndex As Integer = 0 To intCountColumns - 1
        ''    each_column = list_columns(intColIndex)
        ''    strValue = each_column.ToString_ByRow(par_intRowIndex)
        ''    If (strValue = "") Then
        ''        strLine &= (strValue)
        ''    Else
        ''        strLine &= (vbTab & strValue)
        ''    End If
        ''Next intColIndex
        ''Return strLine

    End Function ''End of ""Public Function ToString_ByRow()""


    Public Function Equals_RecipientListAtClose() As Boolean
        ''
        ''Added 6/28/2022 thomas downes  
        ''
        Dim exampleColumnMaxCells As RSCFieldColumnV2
        Dim exampleColumnMaxVals As ClassRSCColumnWidthAndData
        Dim list_enumsRelevant As List(Of EnumCIBFields)
        Dim list_recipients As List(Of ciBadgeRecipients.ClassRecipient) = Nothing ''Added 7/4/2022
        Dim intHowManyRecips As Integer
        Dim intHowManyDataValues As Integer
        Dim intHowManyRowHeaders As Integer
        Dim intHowManyCellRows As Integer

        If Me.PersonalityCache_Recipients Is Nothing Then System.Diagnostics.Debugger.Break()
        If Me.PersonalityCache_Recipients.ListOfRecipients Is Nothing Then
            System.Diagnostics.Debugger.Break()
        Else
            ''Added 7/4/2022 thomas downes
            list_recipients = Me.PersonalityCache_Recipients.ListOfRecipients
        End If ''End of ""If Me.PersonalityCache_Recipients.ListOfRecipients Is Nothing Then... Else..."

        list_enumsRelevant = ElementsCache.ListOfFieldEnums_Relevant()

        exampleColumnMaxVals = Me.ColumnDataCache.RSCColumnWithMaximalDataCells()
        ''4/2023 exampleColumnMaxCells = mod_dict_RSCColumns(0)
        exampleColumnMaxCells = mod_managerRowsCols.Cols.GetFirstColumn()

        intHowManyCellRows = exampleColumnMaxCells.CountOfRows()
        intHowManyDataValues = exampleColumnMaxVals.ColumnData.Count
        intHowManyRecips = Me.PersonalityCache_Recipients.ListOfRecipients.Count
        intHowManyRowHeaders = RscRowHeaders1.CountOfRows()

        If (intHowManyCellRows <> intHowManyDataValues) Then
            System.Diagnostics.Debugger.Break()
        ElseIf (intHowManyCellRows <> intHowManyCellRows) Then
            System.Diagnostics.Debugger.Break()
        ElseIf (intHowManyCellRows <> intHowManyRowHeaders) Then
            System.Diagnostics.Debugger.Break()
        ElseIf (intHowManyDataValues <> intHowManyRecips) Then
            System.Diagnostics.Debugger.Break()
        ElseIf (intHowManyRecips <> intHowManyRowHeaders) Then
            System.Diagnostics.Debugger.Break()
        End If

        ''4/2023 Dim each_column As RSCFieldColumnV2
        ''4/2023 Dim each_match1of2 As Boolean
        Dim sum_matches1of2 As Boolean = True ''Default to true

        ''
        ''Matching-Checks routine #1 of 2--Column by Column  
        ''
        sum_matches1of2 = mod_managerRowsCols.Cols.Equals_RecipientListAtClose(list_recipients)

        ''4/2023 For Each each_column In mod_dict_RSCColumns.Values
        ''    If (each_column Is Nothing) Then Continue For
        ''    each_match1of2 = each_column.Equals_RecipientListAtClose(list_recipients)
        ''    sum_matches1of2 = (sum_matches1of2 And each_match1of2)
        ''Next each_column

        ''
        ''Matching-Checks routine #2 of 2--Row by Row    
        ''
        Dim each_match2of2 As Boolean
        Dim sum_matches2of2 As Boolean = True ''Default to true

        Dim each_recip As ciBadgeRecipients.ClassRecipient
        Dim each_RowHeaderRecipient As ciBadgeRecipients.ClassRecipient
        Dim each_strGuid6 As String

        For Each each_recip In Me.PersonalityCache_Recipients.ListOfRecipients()

            If (each_recip Is Nothing) Then Continue For
            each_strGuid6 = each_recip.ID_Guid6chars
            each_RowHeaderRecipient = Me.RscRowHeaders1.GetRecipient_ByGuid6(each_strGuid6).Recipient

            If (each_RowHeaderRecipient Is Nothing) Then
                System.Diagnostics.Debugger.Break()
            End If

            each_match2of2 = each_recip.Equals(each_RowHeaderRecipient, list_enumsRelevant)
            sum_matches2of2 = (sum_matches2of2 And each_match2of2)

        Next each_recip




    End Function ''ENd of ""Public Function Equals_RecipientListAtClose() As Boolean""


    Private Sub RSCFieldSpreadsheet_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        Static s_priorAutoScrollPositionX As Integer
        Static s_priorAutoScrollPositionY As Integer

        Dim intAutoscrollPositionX As Integer
        Dim intAutoscrollPositionY As Integer

        intAutoscrollPositionX = Me.AutoScrollPosition.X
        intAutoscrollPositionY = Me.AutoScrollPosition.Y

        If (0 <> intAutoscrollPositionY) Then
            s_priorAutoScrollPositionX = intAutoscrollPositionX
            s_priorAutoScrollPositionY = intAutoscrollPositionY
        End If

    End Sub


    Private Sub LinkLabelReviewFields_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelReviewFields.LinkClicked

        ''Added 4/13/2022
        ReviewRelevantFieldsViaDialogForm()

    End Sub


    Private Sub LinkLabelRightClickMenu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelRightClickMenu.LinkClicked

        ''Added 4/13/2022 thomas downes 
        Static s_bMsgOnce As Boolean
        If (Not s_bMsgOnce) Then
            MessageBoxTD.Show_Statement("Right-clicking spreadsheet " &
                                        "items will often display a menu.",
                                     "(one-time message)")
        End If ''End of "If (Not s_bMsgOnce) Then"

        ''Added 4/13/2022 td
        Dim new_args As MouseEventArgs
        new_args = New MouseEventArgs(MouseButtons.Right, 1,
                                      LinkLabelRightClickMenu.Left,
                                      LinkLabelRightClickMenu.Top, 0)
        ''Major call....
        MyBase.MoveableControl_MouseUp(Me, new_args)

    End Sub


    Private Sub ButtonAddColumns_Click(sender As Object, e As EventArgs) _
        Handles ButtonAddColumns1.Click, ButtonAddColumns2.Click
        ''
        ''Added 5/13/2022 thomas downes  
        ''
        Dim intHowMany As Integer
        Dim boolCancelled As Boolean = False
        Const c_intDefaultValue As Integer = 1 ''Added 8/17/2022

        ''8/17/2022 intHowMany = MessageBoxTD.AskHowMany("How many columns do you want?",
        ''        1.0, 1.0, 1, 9,
        ''        False, False, boolCancelled)
        intHowMany = MessageBoxTD.AskHowMany("How many columns do you want?",
                1.0, 1.0, 1, 9,
                c_intDefaultValue,
                False, False, boolCancelled)

        If (boolCancelled) Then
            MessageBoxTD.Show_Statement("User has cancelled.")
        Else
            ''Major call!!
            AddColumnsToRighthandSide(intHowMany)

            ''added 5/13/2022
            If mc_boolKeepUILookingClean Then
                ''Hide the buttons which formerly occupied the blank area
                '' of the spreadsheet. ---5/13/2022 
                ButtonAddColumns2.Visible = False
                ButtonPasteData2.Visible = False
            End If ''End of ""If c_boolKeepUILookingClean Then""

        End If ''End of""If (boolCancelled) Then.... Else...."

        ''Dim columnRighHandMost As RSCFieldColumnV2 = Nothing
        ''Dim boolException As Boolean
        ''Dim exceptionRSC As Exception

        ''Try
        ''    columnLeftHandMost = mod_array_RSCColumns(0)
        ''    If (columnLeftHandMost Is Nothing) Then
        ''        columnLeftHandMost = mod_array_RSCColumns(1)
        ''    End If
        ''Catch exceptionRSC
        ''    boolException = True
        ''End Try

        ''AddColumns(5)

    End Sub

    Private Sub ButtonPasteData_Click(sender As Object, e As EventArgs) _
        Handles ButtonPasteData1.Click, ButtonPasteData2.Click
        ''
        ''Added 5/13/2022 thomas downes  
        ''
        PasteData_SecondTry()

    End Sub

    Private Sub RSCFieldSpreadsheet_Click(sender As Object, e As EventArgs) Handles Me.Click
        ''
        ''Added 4/10/2023
        ''
        ''8/26/2023 MessageBoxTD.Show_Statement("Spreadsheet..." & Me.Name)

    End Sub


    Private Sub mod_eventsSingleton_Resizing_EndV2(par_iSave As ISaveToModel, par_iRefreshElement As IRefreshElementImage, par_iRefreshCardPreview As IRefreshCardPreview, par_bHeightResized As Boolean) Handles mod_eventsSingleton.Resizing_EndV2
        ''
        ''Added 4/10/2023
        ''
        mod_managerRowsCols.Cols.RefreshAllColumnsLeftProperty()

    End Sub

    Private Sub linkDisplayAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkDisplayAll.LinkClicked
        ''
        ''Added 8/28/2023
        ''
        ShowRecipientsIDCard_All()


    End Sub
End Class


