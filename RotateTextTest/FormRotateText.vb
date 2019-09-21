Option Explicit On
Option Strict On
''
''Added 9/21/2019 thomas d
''
Imports System.Reflection.Assembly

Public Class FormRotateText
    Private Sub FormRotateText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Dim objInfo As Type ''System.Reflection.Assembly
        Dim each_member As Reflection.MemberInfo

        Dim objClass1 As New ClassMethods
        Dim strMethodName As String
        Dim strMethodWithSpaces As String

        ''objInfo = (TypeOf objClass1)

        ''// Using Reflection to get information of an Assembly  
        ''System.Reflection.Assembly info = TypeOf (System.Int32).Assembly;

        Dim t As Type = objClass1.GetType

        For Each each_member In t.GetMembers()

            strMethodName = each_member.Name

            strMethodWithSpaces = strMethodName.Replace("_", " ")

            Dim each_link As New LinkLabel

            each_link.Visible = True
            each_link.Text = strMethodWithSpaces

            AddHandler each_link.LinkClicked, AddressOf each_member



        Next each_member


    End Sub
End Class
