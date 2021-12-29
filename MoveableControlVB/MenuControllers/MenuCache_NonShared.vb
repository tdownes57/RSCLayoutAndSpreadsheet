''
''Added 10/2/2019 thomas downes  
''
Imports System.Reflection ''Added 10/11/2019 td
Imports ciBadgeInterfaces ''Added 10/14/2019 td 
Imports ciBadgeDesigner ''Added 10/14/2019 td
''----Imports ciBadgeFields ''Added 12/13/2021 thomas d. 

Friend Class MenuCache_NonShared
    Implements ICurrentElement
    ''
    ''Added 12/27/2021 thomas downes
    ''Added 10/2/2019 thomas downes  
    ''
    Public Links_EditElementMenu As New List(Of LinkLabel)
    ''[[[Public Links_ManageGroupedCtls As New List(Of LinkLabel)
    ''[[[Public Links_AlignmentFeatures As New List(Of LinkLabel)
    ''---Public Links_EditBackgroundMenu As New List(Of LinkLabel)

    Public ToolStripContainer1 As New ToolStrip
    ''[[[Public ToolStripContainer2 As New ToolStrip
    ''[[[Public ToolStripContainer3 As New ToolStrip

    Public array_tools1() As ToolStripMenuItem = New ToolStripMenuItem() {}
    ''[[[Public array_tools2() As ToolStripMenuItem = New ToolStripMenuItem() {}
    ''[[[Public array_tools3() As ToolStripMenuItem = New ToolStripMenuItem() {}

    Public Tools_EditElementMenu As New ToolStripItemCollection(ToolStripContainer1, array_tools1) ''10/13 td''List(Of ToolStripMenuItem)
    ''[[[Public Tools_ManageGroupedCtls As New ToolStripItemCollection(ToolStripContainer2, array_tools2) ''10/13 td''''List(Of ToolStripMenuItem)
    ''[[[Public Tools_AlignmentFeatures As New ToolStripItemCollection(ToolStripContainer3, array_tools3) ''10/13 td''''List(Of ToolStripMenuItem)
    ''--Public Tools_EditBackgroundMenu As New List(Of ToolStripMenuItem)

    Friend Tools_MenuHeader0 As ToolStripItem ''Added 12/13/2021
    Friend Tools_MenuHeader1 As ToolStripItem ''Added 12/12/2021
    Friend Tools_MenuHeader2 As ToolStripItem ''Added 12/12/2021 
    Friend Tools_MenuHeader3 As ToolStripItem ''Added 12/13/2021
    Friend Tools_MenuSeparator As ToolStripItem ''Added 12/13/2021 

    ''12/28/2021 td''Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    Public Property CtlCurrentElement As MoveableControlVB Implements ICurrentElement.CtlCurrentElement ''CtlGraphicFldLabel

    Public MyLinkLabel As New LinkLabel ''Added 12/28/2021 td 
    Public MyToolstripItem As New ToolStripMenuItem ''Added 12/28/2021 td 

    Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    ''[[[Public Property Designer As ciBadgeDesigner.ClassDesigner
    ''[[[Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    ''[[[Public Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    ''[[[Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    ''Added 12/12/2021 td 
    ''Public Property CacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 12/12/2021 td

    Public Enum_ElementType As EnumElementType ''Added 12/28/2021 thomas d.
    Public OperationsType As Type ''Added 12/28/2021 thomas d.
    ''12/28/2021 td''Private mod_iCtlCurrentElement As ICurrentElement
    ''Dec28 2021 td''Private Shared mod_operationsGenericEdits As New Operations_Generic ''Added 10/11/2019 td  
    Private Shared mod_operationsGenericEdits As Object ''Added 10/11/2019 td  

    ''[[[Private mod_operationsGenericEdits As New Operations_Generic ''Added 10/11/2019 td  

    Public Sub New(par_enum As EnumElementType, par_typeOperations As Type,
                   par_initializedOperations As Object)
        ''         ''Dec28 2021 td''par_iCurrentElementControl As ICurrentElement,
        ''
        ''Added 12/28/2021 thomas downes
        ''
        Enum_ElementType = par_enum '' par_typeOperations
        OperationsType = par_typeOperations
        ''12/28/2021 td''mod_iCtlCurrentElement = par_iCurrentElementControl
        mod_operationsGenericEdits = par_initializedOperations

        Get_EditElementMenu(par_enum)

    End Sub ''End of "Public Sub New(par_enum As EnumElementType, par_typeOperations As Type)"


    Friend Function Get_EditElementMenu(par_enum As EnumElementType) As ToolStripItemCollection
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        If (par_enum = EnumElementType.Field) Then

            ''Dec28 2021 td''GenerateMenuItems_IfNeeded()
            If (Tools_EditElementMenu Is Nothing) Then

                ''Dec28 2021 td''GenerateMenuItems_IfNeeded()
                ''#2 Dec28 2021 td''Tools_EditElementMenu = GenerateMenuItems_IfNeeded()
                GenerateMenuItems_IfNeeded()

            End If ''end of "If (Tools_EditElementMenu Is Nothing) Then"

            Return Tools_EditElementMenu

        End If ''End of "If (par_enum = EnumElementType.Field) Then"

    End Function ''End of "Private Function Get_EditElementMenu"


    Public Sub GenerateMenuItems_IfNeeded() ''Dec28 2021 td''(par_cacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated)
        ''Dec.12 2021 ''Public Sub GenerateMenuItems_IfNeeded()
        ''
        ''Added 10/2/2019 thomas downes  
        ''
        Dim boolAlreadyPopulated As Boolean ''Added 10/14/2019 thomas downes
        boolAlreadyPopulated = (0 <> Links_EditElementMenu.Count)
        If (boolAlreadyPopulated) Then Exit Sub

        ''12/13/2021''Generate_BasicEdits()
        ''12/28/2021''Generate_BasicEdits(mod_operationsGenericEdits.GetType())
        Generate_BasicEdits(Me.OperationsType)
        Generate_Grouped()
        Generate_Aligning()

        ''
        ''Added 10/1/4/2019 td
        ''
        ''Dec28 2021''With Operations_Edit
        ''#2 Dec28 2021''With mod_operationsGenericEdits
        ''#3 Dec28 2021''With mod_iCtlCurrentElement
        With Me ''#4 Dec28 2021''.CtlCurrentElement

            ''Not needed for _Generic. Dec28 2021''.ColorDialog1 = ColorDialog1
            ''#5 Dec28 2021''.CtlCurrentElement = CtlCurrentElement

            ''Not needed for _Generic. Dec28 2021''.Designer = Designer
            ''Not needed for _Generic. Dec28 2021''.FontDialog1 = FontDialog1
            ''Not needed for _Generic. Dec28 2021''.LayoutFunctions = LayoutFunctions
            ''Not needed for _Generic. Dec28 2021''.SelectingElements = SelectingElements

            ''Added 12/12/2021 td
            ''.Parent_MenuCache = (New MenuCache_ElemFlds())
            ''.ListOfFields_Custom = CacheOfFieldsEtc.ListOfFields_Custom
            ''.ListOfFields_Standard = CacheOfFieldsEtc.ListOfFields_Standard
            ''Dec28 2021 td''.CacheOfFieldsEtc = par_cacheOfFieldsEtc

            ''Added 12/12/2021 td
            ''Dec28 2021 td''Dim bIsLatestCache As Boolean ''Added 12/12/2021 td 
            ''Dec28 2021 td''par_cacheOfFieldsEtc.CheckCacheIsLatestForEdits(bIsLatestCache)
            ''Dec28 2021 td''If (Not bIsLatestCache) Then MessageBox.Show("This cache is not the latest cache.")

        End With ''End of "With Operations_Edit"

    End Sub ''End of "Public Sub GenerateMenuItems_IfNeeded()"

    Private Sub Generate_BasicEdits(par_typeOperations As Type) ''Dec.13 2021'' (par_fieldAny As ciBadgeFields.ClassFieldAny)
        ''
        ''We will use Reflection to build this cache of menu controls.
        ''   ("Dim each_methodInfo As Reflection.MethodInfo") 
        ''   ("For Each each_methodInfo In typeOperationsElement.GetMethods()")
        ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        Dim strList_MenuItems As String = ""

        ''Dim objInfo As Type ''System.Reflection.Assembly
        ''Encapsulated Dec28 2021 td''Dim each_methodInfo As Reflection.MethodInfo
        ''Dim each_eventInfo As Reflection.EventInfo

        ''Dim objClass1 As New ClassMethods
        ''Dim strMethodName As String
        ''Dim strMethodWithSpaces As String
        ''Dim boolHasUnderscore As Boolean  ''Added 9//21/2019 td
        ''Dim objBindingFlags As System.Reflection.BindingFlags ''Added 9/23/2019 td  
        ''Dim boolPropertyGet As Boolean ''Added 9/23/2019 td 
        ''Dim boolPropertySet As Boolean ''Added 9/23/2019 td 
        Dim intExceptionCount_LinkLabels As Integer  ''Added 9/23/2019 td
        Dim intExceptionCount_Toolstrip As Integer  ''Added 9/23/2019 td
        Dim ex_AddEventHandler_LinkLbl As New Exception("Routine initialization")  ''Added 9/23/2019 td
        Dim ex_AddEventHandler_ToolItem As New Exception("Routine initialization")  ''Added 9/23/2019 td
        ''Dim boolProcedureNotUsed As Boolean ''Added 9/23/2019 thomas downes 
        ''Dim intCountLinkLabels As Integer ''Added 10/13/2019 thomas downes 
        ''Dim intCountMethodsAndMembers As Integer ''Added 10/14/2019 td 

        Dim toolMenuItemHeader0 As New ToolStripMenuItem ''Added 12/12/2021 td
        Dim toolMenuItemHeader1 As New ToolStripMenuItem ''Added 12/12/2021 td
        Dim toolMenuItemHeader2 As New ToolStripMenuItem ''Added 12/12/2021 td
        Dim toolMenuItemHeader3 As New ToolStripMenuItem ''Added 12/13/2021 td
        Dim toolMenuItemHeader4a As New ToolStripMenuItem ''Added 12/15/2021 td
        Dim toolMenuItemHeader4b As New ToolStripMenuItem ''Added 12/15/2021 td
        Dim toolMenuItemSeparator As New ToolStripMenuItem ''Added 12/13/2021 td

        ''Added 12/13/2021 td
        ''   Dec.12 2021 td''toolMenuItemHeader1.Text = ("Field " & par_fieldAny.Caption)
        ''
        toolMenuItemHeader0.BackColor = Color.Aqua
        toolMenuItemHeader0.Text = ("Context-Menu for Control: {0}")
        toolMenuItemHeader0.Tag = ("Context-Menu for Control: {0}")  ''More important to set .Tag than .Text, due to using String.Format function.
        toolMenuItemHeader1.BackColor = Color.Aqua
        toolMenuItemHeader1.Text = ("Field: {0} ({1})")
        toolMenuItemHeader1.Tag = ("Field: {0} ({1})") ''More important to set .Tag than .Text here, due to using String.Format function elsewhere.

        toolMenuItemHeader2.BackColor = Color.Aqua
        toolMenuItemHeader3.BackColor = Color.Aqua
        toolMenuItemSeparator.BackColor = Color.Aqua

        ''Added 12/15/2021 td 
        toolMenuItemHeader2.Text = "ContextMenus\MenuCache_ElemFlds.vb"
        toolMenuItemHeader3.Text = "       & ...\Operations_EditElement.vb"
        toolMenuItemHeader4a.Text = "Sub MenuCache_ElemFlds.Generate_BasicEdits()"
        toolMenuItemHeader4b.Text = "... uses Reflection to build the menu below."
        toolMenuItemHeader4a.BackColor = Color.Aqua
        toolMenuItemHeader4b.BackColor = Color.Aqua

        toolMenuItemSeparator.Text = "-----Editing Operations follow------" ''Perhaps this will produce a separator line, just like in the old VB6 days. 

        ''toolMenuItemHeader1 = toolMenuItemHeader1
        Tools_EditElementMenu.Add(toolMenuItemHeader0)
        Tools_EditElementMenu.Add(toolMenuItemHeader1)
        Tools_EditElementMenu.Add(toolMenuItemHeader2)
        Tools_EditElementMenu.Add(toolMenuItemHeader3)
        Tools_EditElementMenu.Add(toolMenuItemHeader4a)
        Tools_EditElementMenu.Add(toolMenuItemHeader4b)
        Tools_EditElementMenu.Add(toolMenuItemSeparator)

        Tools_MenuHeader0 = toolMenuItemHeader0
        Tools_MenuHeader1 = toolMenuItemHeader1
        Tools_MenuHeader2 = toolMenuItemHeader2
        Tools_MenuHeader3 = toolMenuItemHeader3
        Tools_MenuSeparator = toolMenuItemSeparator

        ''objInfo = (TypeOf objClass1)

        ''Dec28, 2021''Generate_ReflectionWork(mod_operationsGenericEdits.GetType())
        Generate_ReflectionWork(par_typeOperations,
                                Links_EditElementMenu,
                                Tools_EditElementMenu)

        ''
        ''Added 9/23/2019 thomas downes
        ''
        If (intExceptionCount_LinkLabels > 0) Then
            ''
            ''Added 9/23/2019 thomas downes
            ''
            MessageBox.Show($"Making LinkLabels, a count of {intExceptionCount_LinkLabels} errors occurred.  The last error is as follows:  " & vbCrLf & vbCrLf &
                            ex_AddEventHandler_LinkLbl.Message, "Generate_BasicEdits",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If ''End of "If (intExceptionCount_LinkLabels > 1) Then"

        ''Added 10/14/2019 thomas downes
        If (intExceptionCount_Toolstrip > 0) Then
            ''Inform user of the error count. 
            MessageBox.Show($"Making ToolstripMenuItems, a count of {intExceptionCount_Toolstrip} errors occurred.  The last error is as follows:  " & vbCrLf & vbCrLf &
                            ex_AddEventHandler_ToolItem.Message, "Generate_BasicEdits",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If ''End of "If (intExceptionCount_Toolstrip > 1) Then"

        ''Modified 10/14/2019 td
        If ("" = strList_MenuItems) Then
            ''Added 10/14/2019 td 
            MessageBox.Show("The procedure to create links & context menu items failed completely. " &
                            vbCrLf & vbCrLf & strList_MenuItems, "Generate_BasicEdits",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            ''MessageBox.Show("The following links & context menu items were created. " &
            ''                vbCrLf & vbCrLf & strList_MenuItems, "Generate_BasicEdits",
            ''                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub ''End of "Private Sub Generate_BasicEdits()"


    Private Sub Generate_ReflectionWork(par_typeOperations As Type,
                                               ByRef par_listLinklabels As List(Of LinkLabel),
                                               ByRef par_listToolItems As ToolStripItemCollection)
        ''
        ''Added 12/28/2021 thomas downes
        ''
        Dim each_methodInfo As Reflection.MethodInfo
        Dim objBindingFlags As System.Reflection.BindingFlags ''Added 9/23/2019 td
        Dim ex_AddEventHandler_LinkLbl As New Exception("Routine initialization")  ''Added 9/23/2019 td
        Dim ex_AddEventHandler_ToolItem As New Exception("Routine initialization")  ''Added 9/23/2019 td

        Dim strMethodName As String
        Dim strMethodWithSpaces As String
        Dim boolHasUnderscore As Boolean  ''Added 9//21/2019 td
        Dim strList_MenuItems As String = ""
        Dim intExceptionCount_LinkLabels As Integer  ''Added 9/23/2019 td
        Dim intExceptionCount_Toolstrip As Integer  ''Added 9/23/2019 td

        ''Encapsulated 12/28/2021 td''Dim objBindingFlags As System.Reflection.BindingFlags ''Added 9/23/2019 td  
        Dim boolPropertyGet As Boolean ''Added 9/23/2019 td 
        Dim boolPropertySet As Boolean ''Added 9/23/2019 td 
        Dim boolProcedureNotUsed As Boolean ''Added 9/23/2019 thomas downes 
        Dim intCountLinkLabels As Integer ''Added 10/13/2019 thomas downes 
        Dim intCountMethodsAndMembers As Integer ''Added 10/14/2019 td 

        objBindingFlags = (BindingFlags.Public Or BindingFlags.Instance)

        ''// Using Reflection to get information of an Assembly  
        ''System.Reflection.Assembly info = TypeOf (System.Int32).Assembly;

        ''Dec12 2021''Dim t As Type = Operations_Edit.GetType
        ''Dec28 2021''Dim typeOperationsElement As Type = Operations_Edit.GetType
        Dim typeOperationsElement As Type = par_typeOperations ''Dec28 2021''Operations_Edit.GetType

        ''10/11/2019 td''mod_methods.ParentForm = Me

        ''
        ''Iterate through each procedure of Operations_EditFieldElement.vb. 
        '' ----12/15/2021 td
        ''
        For Each each_methodInfo In typeOperationsElement.GetMethods()

            intCountMethodsAndMembers += 1 ''Added 10/14/2019 td

            strMethodName = each_methodInfo.Name

            ''Added 9/21/2019 thomas d. 
            boolHasUnderscore = strMethodName.Contains("_")
            If (Not boolHasUnderscore) Then Continue For ''----Exit For

            ''Added 9/21/2019 thomas d. 
            boolPropertyGet = strMethodName.Contains("get_")
            If (boolPropertyGet) Then Continue For ''---Exit For

            ''Added 9/21/2019 thomas d. 
            boolPropertySet = strMethodName.Contains("set_")
            If (boolPropertySet) Then Continue For ''---Exit For

            ''Added 9/21/2019 thomas d. 
            boolProcedureNotUsed = strMethodName.Contains("_NotUsed")
            If (boolProcedureNotUsed) Then Continue For ''---Exit For

            Dim bPublicSubHasGoodParams As Boolean ''Added 10/15/2019 td
            bPublicSubHasGoodParams = each_methodInfo.ToString.Contains("(System.Object, System.EventArgs)")
            If (bPublicSubHasGoodParams) Then
                ''
                ''Great!!  The parameters of the Public Sub are (sender As Object, e As EventArgs)
                ''   which is necessary.  ---10/15/2019 td
                ''
            Else
                ''Added 10/15/2019 td
                MessageBox.Show($"The Public Sub {each_methodInfo.Name} " &
                                "must have params (sender As Object, e As EventArgs).",
                                "MenuCache_ElemFlds - Generate_BasicEdits", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)

            End If ''End of "If (bPublicSubHasGoodParams) Then .... Else .."

            strMethodWithSpaces = strMethodName.Replace("_", " ")

            Dim each_newLinkLabel As New LinkLabel
            each_newLinkLabel.Visible = True
            each_newLinkLabel.Text = strMethodWithSpaces

            ''Added 10/13/2019 td  
            Dim each_toolMenuItem As New ToolStripMenuItem ''Added 10/13/2019 td

            ''Added 10/13/2019 td  
            each_toolMenuItem.Visible = True
            each_toolMenuItem.Text = strMethodWithSpaces

            ''AddHandler each_link.LinkClicked, AddressOf each_member

            ''Dim tt As Type = each_link.GetType

            ''9/23/2019 td''

            ''each_eventInfo = tt.GetEvents()(0)

            ''Dim list_events() As Reflection.EventInfo
            ''9/23/2019 td''

            ''list_events = tt.GetEvents()
            ''For Each each_eventInfo In list_events
            ''    If (each_eventInfo.Name = "LinkClicked") Then Exit For
            ''    System.Diagnostics.Debug.Print(each_eventInfo.Name)
            ''Next
            ''9/23/2019 td''

            ''
            ''
            ''
            ''each_eventInfo.AddEventHandler()
            ''    var p = New Program();
            ''var eventInfo = p.GetType().GetEvent("TestEvent");
            ''var methodInfo = p.GetType().GetMethod("TestMethod");
            ''Delegate handler() = 
            ''     Delegate.CreateDelegate(eventInfo.EventHandlerType,
            ''                             p,
            ''                             methodInfo);
            ''eventInfo.AddEventHandler(p, handler);
            ''p.Test();

            Const c_TryToUseReflectionForHandlers As Boolean = True ''False ''Added 9/23/2019 Thomas DOWNES
            Dim bAddEventHandler_Reflection As Boolean = c_TryToUseReflectionForHandlers ''True

            ''Added 9/23/2019 Thomas DOWNES 
            ''
            ''   https://stackoverflow.com/questions/1121441/addeventhandler-using-reflection
            ''
            If (bAddEventHandler_Reflection) Then
                ''Added 9/23/2019 Thomas DOWNES 
                ''
                ''   https://stackoverflow.com/questions/1121441/addeventhandler-using-reflection
                ''
                ''Dec28 2021 td''Dim type_LinkLabel As Type = mod_operationsGenericEdits.MyLinkLabel.GetType
                Dim type_LinkLabel As Type = Me.MyLinkLabel.GetType
                Dim event_linkClicked As Reflection.EventInfo

                ''
                ''Step 1 of 2:    LinkLabels  
                ''
                Try
                    event_linkClicked = type_LinkLabel.GetEvent("LinkClicked", objBindingFlags)
                    Dim my_click_handler As [Delegate]
                    my_click_handler = [Delegate].CreateDelegate(event_linkClicked.EventHandlerType,
                                                       mod_operationsGenericEdits, each_methodInfo)

                    ''---link_clicked.AddEventHandler(Me, my_handler) '', BindingFlags.Public)
                    ''---link_clicked.AddEventHandler(mod_classMenuMethods, my_handler)
                    ''---link_clicked.AddEventHandler(mod_classMenuMethods.MyLinkLabel, my_handler)

                    event_linkClicked.AddEventHandler(each_newLinkLabel, my_click_handler)

                    ''Added 10/14/2019 td 
                    strList_MenuItems &= (vbCrLf & each_newLinkLabel.Text)

                Catch ex_AddEventHandler_LinkLbl ''As Exception
                    ''
                    ''Step 1 of 2:    LinkLabels  
                    ''                Added 9/23/2019 td 
                    ''
                    intExceptionCount_LinkLabels += 1

                End Try

                ''
                ''Step 2 of 2:    ToolstripMenuItem  
                ''
                ''Dec28 2021 td''Dim type_ToolstripItem As Type = mod_operationsGenericEdits.MyToolstripItem.GetType
                Dim type_ToolstripItem As Type = MyToolstripItem.GetType
                Dim event_toolClicked As Reflection.EventInfo
                Dim boolSuccess_LinkLabel As Boolean = False ''Added 10/14/2019 td

                Try
                    event_toolClicked = type_ToolstripItem.GetEvent("Click", objBindingFlags)
                    Dim my_click_handler As [Delegate]
                    my_click_handler = [Delegate].CreateDelegate(event_toolClicked.EventHandlerType,
                                                      mod_operationsGenericEdits, each_methodInfo)

                    ''---link_clicked.AddEventHandler(Me, my_handler) '', BindingFlags.Public)
                    ''---link_clicked.AddEventHandler(mod_classMenuMethods, my_handler)
                    ''---link_clicked.AddEventHandler(mod_classMenuMethods.MyLinkLabel, my_handler)

                    event_toolClicked.AddEventHandler(each_toolMenuItem, my_click_handler)

                    boolSuccess_LinkLabel = True ''Added 10/14/2019 thomas d. 

                Catch ex_AddEventHandler_ToolItem ''As Exception
                    ''
                    ''Step 2 of 2:    ToolstripMenuItem  
                    ''                Added 9/23/2019 td 
                    ''
                    intExceptionCount_Toolstrip += 1

                End Try

            Else
                ''
                ''Added 9/23/2019 thomas downes  
                ''
                ''Obselete manual process. Too laborious.''mod_operations.AddEventHandlerLinkClicked_NotUsed(each_link)

            End If ''End of "If (bAddEventHandler_Reflection) Then .... Else ...."

            ''mod_handler = New LinkClickedDelegate(each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(LinkClickedDelegate, each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(link_clicked.EventHandlerType, mod_classMenuMethods, each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(link_clicked.EventHandlerType, mod_classMenuMethods, each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(mod_classMenuMethods.GetType, each_methodInfo, True)

            ''link_clicked.AddEventHandler(Me, myDelegate)

            ''Move up a few executable lines. ----9/23/2019 td''mod_classMenuMethods.AddEventHandlerLinkClicked(each_link)

            ''10/11/2019 td''FlowLayoutPanel1.Controls.Add(each_link)
            each_newLinkLabel.Visible = True
            each_toolMenuItem.Visible = True ''Added 10/13/2019 td  

            ''Added 12/15/2021 thomas d
            Dim boolInformative As Boolean
            boolInformative = strMethodWithSpaces.Contains("EE9")
            If (boolInformative) Then each_toolMenuItem.BackColor = Color.Aquamarine ''vs. Color.Aqua (used above)

            ''Added 10/13/2019 thomas downes
            intCountLinkLabels += 1
            ''Dec28 2021 td''MenuCache_Generic.Links_EditElementMenu.Add(each_newLinkLabel)
            ''Dec28 2021 td''MenuCache_Generic.Tools_EditElementMenu.Add(each_toolMenuItem)
            par_listLinklabels.Add(each_newLinkLabel)
            par_listToolItems.Add(each_toolMenuItem)

        Next each_methodInfo

    End Sub ''End of "Private Sub Generate_ReflectionWork()



    Private Sub Generate_Grouped()
        ''
        ''We will use Reflection to build this cache of menu controls. 
        ''
        ''   We will convert the procedures in class ElementEditingMethods to clickable LinkLabels.
        ''
        ''

    End Sub
    Private Sub Generate_Aligning()
        ''
        ''We will use Reflection to build this cache of menu controls. 
        ''
        ''   We will convert the procedures in class Methods_EditElement to clickable LinkLabels.
        ''
        ''

    End Sub

End Class

