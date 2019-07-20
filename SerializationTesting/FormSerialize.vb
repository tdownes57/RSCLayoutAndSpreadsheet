
Imports System.Runtime.Serialization
Imports System.IO
''
''   http://net-informations.com/faq/net/serialization.htm
''
''
Public Class FormSerialize
    Inherits Form
    Private Sub FormSerialize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''' <summary>
    ''' http://net-informations.com/faq/net/serialization.htm
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    'serializing the object
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim srObj As New serializeObject()
        srObj.srString = ".Net serialization test !!"
        srObj.srInt = 1000
        Dim formatter As IFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim fileStream As Stream = New FileStream("c:\SerializeFile.bin", FileMode.Create, FileAccess.Write, FileShare.None)
        formatter.Serialize(fileStream, srObj)
        fileStream.Close()
        MsgBox("Object Serialized !!")
    End Sub

    ' De-serializing the object
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim formatter As IFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim serialStream As Stream = New FileStream("c:\SerializeFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read)
        Dim srObj As serializeObject = DirectCast(formatter.Deserialize(serialStream), serializeObject)
        serialStream.Close()
        MsgBox(srObj.srString + "      " + srObj.srInt.ToString())
    End Sub



End Class


