
Option Explicit On
Option Strict On
''
''Added 10/1/2019 & 9/21/2019 thomas d
''
Imports System.Reflection
Imports System.Reflection.Assembly
Imports System.Windows.Forms ''Added 10/13/2019 td  

Delegate Sub LinkClickedDelegate(sender As Object, e As LinkLabelLinkClickedEventArgs)

Module c_modReflection
    ''
    ''Added 10/1/2019 & 9/21/2019 thomas d
    ''

    ''10/2/2019 td''Public Class FormRotateText

    Private mod_handler As LinkClickedDelegate
    Private WithEvents mod_classMenuMethods As New ClassMenuMethods

    Public Function LinkProceduresToLinkLabels(par_objSubprocedures As Object,
                                          par_form As Form) As List(Of LinkLabel)
        ''10/13/2019 td'' par_FlowLayoutPanel As FlowLayoutPanel)
        ''10/1/2019 td'' Sub FormRotateText_Load(sender As Object, e As EventArgs) ''10/2/2019 td''Handles MyBase.Load

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
        Dim obj_listLinks As New List(Of LinkLabel) ''Added 10/13/2019 td 

        ''objInfo = (TypeOf objClass1)

        objBindingFlags = (BindingFlags.Public Or BindingFlags.Instance)

        ''// Using Reflection to get information of an Assembly  
        ''System.Reflection.Assembly info = TypeOf (System.Int32).Assembly;

        ''10/1/2019 td''Dim t As Type = mod_classMenuMethods.GetType
        Dim t As Type = par_objSubprocedures.GetType

        mod_classMenuMethods.ParentForm = par_form ''10/1/2019 td''Me

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
                Dim type_LinkLabel As Type = mod_classMenuMethods.MyLinkLabel.GetType
                Dim event_linkClicked As Reflection.EventInfo

                Try
                    event_linkClicked = type_LinkLabel.GetEvent("LinkClicked", objBindingFlags)
                    Dim my_click_handler As [Delegate]
                    my_click_handler = [Delegate].CreateDelegate(event_linkClicked.EventHandlerType, mod_classMenuMethods, each_methodInfo)

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

            Else
                ''Added 9/23/2019 thomas downes  
                mod_classMenuMethods.AddEventHandlerLinkClicked_NotUsed(each_link)

            End If ''End of "If (bAddEventHandler_Reflection) Then .... Else ...."

            ''mod_handler = New LinkClickedDelegate(each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(LinkClickedDelegate, each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(link_clicked.EventHandlerType, mod_classMenuMethods, each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(link_clicked.EventHandlerType, mod_classMenuMethods, each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(mod_classMenuMethods.GetType, each_methodInfo, True)

            ''link_clicked.AddEventHandler(Me, myDelegate)

            ''Move up a few executable lines. ----9/23/2019 td''mod_classMenuMethods.AddEventHandlerLinkClicked(each_link)

            ''10/1/2019 td''FlowLayoutPanel1.Controls.Add(each_link)
            ''10/13/2019 td''par_FlowLayoutPanel.Controls.Add(each_link)

            each_link.Visible = True

            obj_listLinks.Add(each_link)

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

        Return obj_listLinks

    End Function ''End of "Public Function LinkProceduresToLinkLabels"

    ''10/1/2019 td''Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    ''10/1/2019 td''End Sub

    ''10/1/2019 td''End Class

End Module
