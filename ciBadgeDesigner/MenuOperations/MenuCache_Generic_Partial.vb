Imports System.Reflection ''Added 1/21/2022 thomas D. 

Partial Public Class MenuCache_Generic_NotUsed


    Private Sub Generate_ReflectionWork_Deprecated(par_typeOperations As Type,
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
            If (boolInformative) Then
                each_toolMenuItem.BackColor = System.Drawing.Color.Aquamarine ''vs. Color.Aqua (used above)
            End If ''ENd of "If (boolInformative) Then"

            ''Added 10/13/2019 thomas downes
            intCountLinkLabels += 1
            ''Dec28 2021 td''MenuCache_Generic.Links_EditElementMenu.Add(each_newLinkLabel)
            ''Dec28 2021 td''MenuCache_Generic.Tools_EditElementMenu.Add(each_toolMenuItem)
            par_listLinklabels.Add(each_newLinkLabel)
            par_listToolItems.Add(each_toolMenuItem)

        Next each_methodInfo

        ''
        ''
        ''
        ''Let's take an inventory of the output of our [For Each--Next] loop above. 
        ''
        ''
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

    End Sub ''End of "Private Sub Generate_ReflectionWork_Deprecated()


End Class
