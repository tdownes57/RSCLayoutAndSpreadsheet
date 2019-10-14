''
''Added 10/2/2019 thomas downes  
''
Imports System.Reflection ''Added 10/11/2019 td  

Public Class MenuCache_ElemFlds
    ''
    ''Added 10/2/2019 thomas downes  
    ''
    Public Shared Links_EditElementMenu As New List(Of LinkLabel)
    Public Shared Links_ManageGroupedCtls As New List(Of LinkLabel)
    Public Shared Links_AlignmentFeatures As New List(Of LinkLabel)
    ''---Public Shared Links_EditBackgroundMenu As New List(Of LinkLabel)

    Public Shared ToolStripContainer1 As New ToolStrip
    Public Shared ToolStripContainer2 As New ToolStrip
    Public Shared ToolStripContainer3 As New ToolStrip

    Public Shared array_tools1() As ToolStripMenuItem = New ToolStripMenuItem() {}
    Public Shared array_tools2() As ToolStripMenuItem = New ToolStripMenuItem() {}
    Public Shared array_tools3() As ToolStripMenuItem = New ToolStripMenuItem() {}

    Public Shared Tools_EditElementMenu As New ToolStripItemCollection(ToolStripContainer1, array_tools1) ''10/13 td''List(Of ToolStripMenuItem)
    Public Shared Tools_ManageGroupedCtls As New ToolStripItemCollection(ToolStripContainer2, array_tools2) ''10/13 td''''List(Of ToolStripMenuItem)
    Public Shared Tools_AlignmentFeatures As New ToolStripItemCollection(ToolStripContainer3, array_tools3) ''10/13 td''''List(Of ToolStripMenuItem)
    ''--Public Shared Tools_EditBackgroundMenu As New List(Of ToolStripMenuItem)

    Private Shared mod_operations As New Operations_EditElement ''Added 10/11/2019 td  

    Public Shared Sub GenerateMenuItems()
        ''
        ''Added 10/2/2019 thomas downes  
        ''
        Generate_BasicEdits()
        Generate_Grouped()
        Generate_Aligning()

    End Sub ''End of "Public Shared Sub GenerateMenuItems()"

    Private Shared Sub Generate_BasicEdits()
        ''
        ''We will use Reflection to build this cache of menu controls. 
        ''
        ''   We will convert the procedures in class Methods_EditElement to clickable LinkLabels.
        ''
        Dim strList_MenuItems As String = ""

        ''Dim objInfo As Type ''System.Reflection.Assembly
        Dim each_methodInfo As Reflection.MethodInfo
        ''Dim each_eventInfo As Reflection.EventInfo

        ''Dim objClass1 As New ClassMethods
        Dim strMethodName As String
        Dim strMethodWithSpaces As String
        Dim boolHasUnderscore As Boolean  ''Added 9//21/2019 td
        Dim objBindingFlags As System.Reflection.BindingFlags ''Added 9/23/2019 td  
        Dim boolPropertyGet As Boolean ''Added 9/23/2019 td 
        Dim boolPropertySet As Boolean ''Added 9/23/2019 td 
        Dim intExceptionCount As Integer  ''Added 9/23/2019 td
        Dim ex_AddEventHandler As New Exception("Routine initialization")  ''Added 9/23/2019 td
        Dim boolProcedureNotUsed As Boolean ''Added 9/23/2019 thomas downes 
        Dim intCountLinkLabels As Integer ''Added 10/13/2019 thomas downes 

        ''objInfo = (TypeOf objClass1)

        objBindingFlags = (BindingFlags.Public Or BindingFlags.Instance)

        ''// Using Reflection to get information of an Assembly  
        ''System.Reflection.Assembly info = TypeOf (System.Int32).Assembly;

        Dim t As Type = mod_operations.GetType

        ''10/11/2019 td''mod_methods.ParentForm = Me

        For Each each_methodInfo In t.GetMethods()

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

            strMethodWithSpaces = strMethodName.Replace("_", " ")

            Dim each_link As New LinkLabel
            each_link.Visible = True
            each_link.Text = strMethodWithSpaces

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
                Dim type_LinkLabel As Type = mod_operations.MyLinkLabel.GetType
                Dim event_linkClicked As Reflection.EventInfo

                ''
                ''Step 2 of 2:    LinkLabels  
                ''
                Try
                    event_linkClicked = type_LinkLabel.GetEvent("LinkClicked", objBindingFlags)
                    Dim my_click_handler As [Delegate]
                    my_click_handler = [Delegate].CreateDelegate(event_linkClicked.EventHandlerType, mod_operations, each_methodInfo)

                    ''---link_clicked.AddEventHandler(Me, my_handler) '', BindingFlags.Public)
                    ''---link_clicked.AddEventHandler(mod_classMenuMethods, my_handler)
                    ''---link_clicked.AddEventHandler(mod_classMenuMethods.MyLinkLabel, my_handler)

                    event_linkClicked.AddEventHandler(each_link, my_click_handler)

                Catch ex_AddEventHandler ''As Exception
                    ''
                    ''Added 9//23/2019 td 
                    ''
                    intExceptionCount += 1

                End Try

                ''
                ''Step 2 of 2:    ToolstripMenuItem  
                ''
                Dim type_ToolstripItem As Type = mod_operations.MyToolstripItem.GetType
                Dim event_toolClicked As Reflection.EventInfo

                Try
                    event_toolClicked = type_ToolstripItem.GetEvent("Click", objBindingFlags)
                    Dim my_click_handler As [Delegate]
                    my_click_handler = [Delegate].CreateDelegate(event_toolClicked.EventHandlerType,
                                                                 mod_operations, each_methodInfo)

                    ''---link_clicked.AddEventHandler(Me, my_handler) '', BindingFlags.Public)
                    ''---link_clicked.AddEventHandler(mod_classMenuMethods, my_handler)
                    ''---link_clicked.AddEventHandler(mod_classMenuMethods.MyLinkLabel, my_handler)

                    event_toolClicked.AddEventHandler(each_link, my_click_handler)

                Catch ex_AddEventHandler ''As Exception
                    ''
                    ''Added 9//23/2019 td 
                    ''
                    intExceptionCount += 1

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
            each_link.Visible = True
            each_toolMenuItem.Visible = True ''Added 10/13/2019 td  

            ''Added 10/13/2019 thomas downes
            intCountLinkLabels += 1
            MenuCache_ElemFlds.Links_EditElementMenu.Add(each_link)
            MenuCache_ElemFlds.Tools_EditElementMenu.Add(each_toolMenuItem)

        Next each_methodInfo

        ''
        ''Added 9/23/2019 thomas downes
        ''
        If (intExceptionCount > 1) Then
            ''
            ''Added 9/23/2019 thomas downes
            ''
            MessageBox.Show($"A count of {intExceptionCount} errors occurred.  The last error is as follows:  " & vbCrLf & vbCrLf &
                            ex_AddEventHandler.Message, "RotateTextTest",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If ''End of "If (intExceptionCount > 1) Then"



        MessageBox.Show("The following links & context menu items were created. " & vbCrLf & vbCrLf & strList_MenuItems)




    End Sub ''End of "Private Shared Sub Generate_BasicEdits()"

    Private Shared Sub Generate_Grouped()
        ''
        ''We will use Reflection to build this cache of menu controls. 
        ''
        ''   We will convert the procedures in class ElementEditingMethods to clickable LinkLabels.
        ''
        ''

    End Sub
    Private Shared Sub Generate_Aligning()
        ''
        ''We will use Reflection to build this cache of menu controls. 
        ''
        ''   We will convert the procedures in class Methods_EditElement to clickable LinkLabels.
        ''
        ''

    End Sub

End Class
