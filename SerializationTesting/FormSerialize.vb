
Imports System.Runtime.Serialization
Imports System.IO
''
''   http://net-informations.com/faq/net/serialization.htm
''
''
Public Class FormSerialize
    Inherits Form
    ''' <summary>
    ''' http://net-informations.com/faq/net/serialization.htm
    ''' </summary> 
    Private Sub FormSerialize_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'serializing the object
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ''7/20/2019 td''Dim srObj As New serializeObject()
        Dim srObj As New ClassParent()

        ''7/20/2019 td''srObj.srString = ".Net serialization test !!"
        ''7/20/2019 td''srObj.srInt = 1000

        srObj.ElementType = "Text"
        srObj.LayoutWidth = 200
        srObj.LeftEdge = 50
        srObj.TopEdge = 40

        ''---------------------------------
        ''Added 8/2/2019 Thomas DOWNES
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/concepts/serialization/
        ''----------------------------------
        ''
        Dim formatter_Bin As IFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim fileStream_Bin As Stream = New FileStream("C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Bin.bin",
                                                  FileMode.Create, FileAccess.Write, FileShare.None)

        formatter_Bin.Serialize(fileStream_Bin, srObj)
        fileStream_Bin.Close()

        ''----------------------------------
        ''Added 8/2/2019 Thomas DOWNES
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/concepts/serialization/
        ''----------------------------------
        ''
        ''8/2 td''Dim formatter_Xml As IFormatter = New System.Runtime.Serialization.Formatters.()
        Dim fileStream_Xml As Stream = New FileStream("C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.xml",
                                                  FileMode.Create, FileAccess.Write, FileShare.None)

        ''Formatter.Serialize(fileStream_Xml, srObj)
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(ClassParent))
        ''Dim file As New System.IO.StreamWriter("c:\temp\SerializationOverview.xml")
        writer.Serialize(fileStream_Xml, srObj)
        fileStream_Xml.Close()

        MsgBox("Object Serialized !!")

    End Sub

    ' De-serializing the object
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim formatter As IFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim serialStream As Stream = New FileStream("c:\SerializeFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read)

        ''7/20/2019 td''Dim srObj As serializeObject = DirectCast(formatter.Deserialize(serialStream), serializeObject)

        Dim srObj As ClassParent = DirectCast(formatter.Deserialize(serialStream), ClassParent) ''7/20/2019 td'' serializeObject)

        serialStream.Close()

        ''7/20/2019 td''MsgBox(srObj.srString + "      " + srObj.srInt.ToString())

        MsgBox(srObj.ElementType + "      " + srObj.LeftEdge.ToString())

    End Sub



End Class


