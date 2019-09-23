Option Explicit On
Option Strict On
''
''Added 9/21/2019 thomas d
''
Imports System.Reflection
Imports System.Reflection.Assembly

Delegate Sub LinkClickedDelegate(sender As Object, e As LinkLabelLinkClickedEventArgs)

Public Class FormRotateText

    Private mod_handler As LinkClickedDelegate
    Private mod_classMenuMethods As New ClassMenuMethods

    Private Sub FormRotateText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Dim objInfo As Type ''System.Reflection.Assembly
        Dim each_methodInfo As Reflection.MethodInfo
        ''Dim each_eventInfo As Reflection.EventInfo

        ''Dim objClass1 As New ClassMethods
        Dim strMethodName As String
        Dim strMethodWithSpaces As String
        Dim boolHasUnderscore As Boolean  ''Added 9//21/2019 td
        Dim objBindingFlags As System.Reflection.BindingFlags ''Added 9/23/2019 td  
        Dim boolPropertyGet As Boolean ''Added 9/23/2019 td 

        ''objInfo = (TypeOf objClass1)

        objBindingFlags = (BindingFlags.Public Or BindingFlags.Instance)

        ''// Using Reflection to get information of an Assembly  
        ''System.Reflection.Assembly info = TypeOf (System.Int32).Assembly;

        Dim t As Type = mod_classMenuMethods.GetType

        mod_classMenuMethods.ParentForm = Me

        For Each each_methodInfo In t.GetMethods()

            strMethodName = each_methodInfo.Name

            ''Added 9/21/2019 thomas d. 
            boolHasUnderscore = strMethodName.Contains("_")
            If (Not boolHasUnderscore) Then Exit For

            ''Added 9/21/2019 thomas d. 
            boolPropertyGet = strMethodName.Contains("get_")
            If (boolPropertyGet) Then Exit For

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
            '''
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

            Const c_TryToUseReflectionForHandlers As Boolean = False ''Added 9/23/2019 Thomas DOWNES

            ''Added 9/23/2019 Thomas DOWNES 
            ''
            ''   https://stackoverflow.com/questions/1121441/addeventhandler-using-reflection
            ''
            If (c_TryToUseReflectionForHandlers) Then
                ''Added 9/23/2019 Thomas DOWNES 
                ''
                ''   https://stackoverflow.com/questions/1121441/addeventhandler-using-reflection
                ''
                Dim tt As Type = mod_classMenuMethods.MyLinkLabel.GetType
                Dim link_clicked As Reflection.EventInfo
                link_clicked = tt.GetEvent("LinkClicked", objBindingFlags)
                Dim my_handler As [Delegate]
                my_handler = [Delegate].CreateDelegate(link_clicked.EventHandlerType, mod_classMenuMethods, each_methodInfo)
                link_clicked.AddEventHandler(Me, my_handler) '', BindingFlags.Public)
            End If ''End of "If (c_TryToUseReflectionForHandlers) Then"

            ''mod_handler = New LinkClickedDelegate(each_methodInfo)

            ''myDelegate = [Delegate].CreateDelegate(LinkClickedDelegate, each_methodInfo)

            ''myDelegate = [Delegate].CreateDelegate(link_clicked.EventHandlerType, mod_classMenuMethods, each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(link_clicked.EventHandlerType, mod_classMenuMethods, each_methodInfo)
            ''myDelegate = [Delegate].CreateDelegate(mod_classMenuMethods.GetType, each_methodInfo, True)

            ''link_clicked.AddEventHandler(Me, myDelegate)

            mod_classMenuMethods.AddEventHandlerLinkClicked(each_link)

            FlowLayoutPanel1.Controls.Add(each_link)
            each_link.Visible = True

        Next each_methodInfo


    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub
End Class
