Option Explicit On
Option Strict On
''
''Added 9/21/2019 thomas d
''
Imports System.Reflection
Imports System.Reflection.Assembly

Public Class FormRotateText
    Private Sub FormRotateText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Dim objInfo As Type ''System.Reflection.Assembly
        Dim each_methodInfo As Reflection.MethodInfo
        ''Dim each_eventInfo As Reflection.EventInfo

        Dim objClass1 As New ClassMethods
        Dim strMethodName As String
        Dim strMethodWithSpaces As String
        Dim boolHasUnderscore As Boolean  ''Added 9//21/2019 td

        ''objInfo = (TypeOf objClass1)

        ''// Using Reflection to get information of an Assembly  
        ''System.Reflection.Assembly info = TypeOf (System.Int32).Assembly;

        Dim t As Type = objClass1.GetType

        For Each each_methodInfo In t.GetMethods()

            strMethodName = each_methodInfo.Name

            ''Added 9/21/2019 thomas d. 
            boolHasUnderscore = strMethodName.Contains("_")
            If (Not boolHasUnderscore) Then Exit For

            strMethodWithSpaces = strMethodName.Replace("_", " ")

            Dim each_link As New LinkLabel

            each_link.Visible = True
            each_link.Text = strMethodWithSpaces

            ''AddHandler each_link.LinkClicked, AddressOf each_member

            Dim tt As Type = each_link.GetType

            ''each_eventInfo = tt.GetEvents()(0)

            ''Dim list_events() As Reflection.EventInfo
            Dim link_clicked As Reflection.EventInfo

            ''list_events = tt.GetEvents()
            ''For Each each_eventInfo In list_events
            ''    If (each_eventInfo.Name = "LinkClicked") Then Exit For
            ''    System.Diagnostics.Debug.Print(each_eventInfo.Name)
            ''Next
            link_clicked = tt.GetEvent("LinkClicked")

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

            Dim myDelegate As [Delegate]
            myDelegate = [Delegate].CreateDelegate(link_clicked.EventHandlerType, each_methodInfo)
            link_clicked.AddEventHandler(Me, myDelegate) '', BindingFlags.Public)

            FlowLayoutPanel1.Controls.Add(each_link)

        Next each_methodInfo


    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub
End Class
