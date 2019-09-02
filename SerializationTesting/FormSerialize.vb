
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Xml.Serialization ''Added 9/1/2019 thomas d. 

''
''   http://net-informations.com/faq/net/serialization.htm
''
''
Public Class FormSerialize
    Inherits Form
    '' <summary>
    '' http://net-informations.com/faq/net/serialization.htm
    '' </summary> 
    '' 
    ''9/1/2019 td''Public mod_c_sPathToXML As String = "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.txt"
    ''9/1/2019 td''Public mod_c_sPathToBinary As String = "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Bin.txt"

    Public mod_sPathToXML As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.txt"
    Public mod_sPathToBinary As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Bin.ttxt"

    Private mod_objParent As New ClassParent()

    Private Sub FormSerialize_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With mod_objParent
            .ElementType = "Text"
            .LayoutWidth = 200
            .LeftEdge = 50
            .TopEdge = 40

            With .MyChild

                .FontFamily = "Ariana Sans"
                .FontSize = 12
                .FontColor = Color.AliceBlue
                .BackColor = Color.Aqua

            End With

        End With

        mod_sPathToBinary = My.Settings.PathToSerialFile_bin
        mod_sPathToXML = My.Settings.PathToSerialFile_xml

    End Sub

    Private Sub SerializeToBinary(sender As Object, e As EventArgs) Handles ButtonSerializeToBinary.Click

        ''---------------------------------
        ''Added 8/2/2019 Thomas DOWNES
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/concepts/serialization/
        ''----------------------------------
        ''
        Dim formatter_Bin As IFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim fileStream_Bin As Stream = New FileStream(mod_sPathToBinary, FileMode.Create, FileAccess.Write, FileShare.None)

        formatter_Bin.Serialize(fileStream_Bin, mod_objParent)
        fileStream_Bin.Close()

        System.Diagnostics.Process.Start(mod_sPathToBinary)

    End Sub

    'serializing the object
    Private Sub SerializeToXML(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSerializeToXML.Click

        ''7/20/2019 td''Dim srObj As New serializeObject()
        '' 8/31/2019 td''Dim srObj As New ClassParent()

        ''7/20/2019 td''srObj.srString = ".Net serialization test !!"
        ''7/20/2019 td''srObj.srInt = 1000

        '' 8/31/2019 td''srObj.ElementType = "Text"
        '' 8/31/2019 td''srObj.LayoutWidth = 200
        '' 8/31/2019 td''srObj.LeftEdge = 50
        '' 8/31/2019 td''srObj.TopEdge = 40

        ''----------------------------------
        ''Added 8/2/2019 Thomas DOWNES
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/concepts/serialization/
        ''----------------------------------
        ''
        ''8/2 td''Dim formatter_Xml As IFormatter = New System.Runtime.Serialization.Formatters.()
        ''8/31 td''Dim fileStream_Xml As Stream = New FileStream("C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.xml",
        ''8/31 td''   FileMode.Create, FileAccess.Write, FileShare.None)

        Dim fileStream_Xml As Stream = New FileStream(mod_sPathToXML,
                     FileMode.Create, FileAccess.Write, FileShare.None)

        ''Formatter.Serialize(fileStream_Xml, srObj)
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(ClassParent))
        ''Dim file As New System.IO.StreamWriter("c:\temp\SerializationOverview.xml")

        writer.Serialize(fileStream_Xml, mod_objParent)
        fileStream_Xml.Close()

        MsgBox("Object Serialized !!", vbInformation, "Serialization")
        System.Diagnostics.Process.Start(mod_sPathToXML)

    End Sub

    ' De-serializing the object
    Private Sub DeserializeBinary(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeserializeBin.Click

        Dim obj_formatter As IFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        ''8/31 td'Dim serialStream As Stream = New FileStream("c:\SerializeFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read)
        Dim serialStream As Stream = New FileStream(mod_sPathToBinary, FileMode.Open, FileAccess.Read, FileShare.Read)

        ''7/20/2019 td''Dim srObj As serializeObject = DirectCast(formatter.Deserialize(serialStream), serializeObject)

        Dim srObj As ClassParent = DirectCast(obj_formatter.Deserialize(serialStream), ClassParent) ''7/20/2019 td'' serializeObject)

        serialStream.Close()

        ''7/20/2019 td''MsgBox(srObj.srString + "      " + srObj.srInt.ToString())

        MsgBox("Deserialization from binary:  " & vbCrLf & vbCrLf &
               srObj.ElementType + "      " + srObj.LeftEdge.ToString(), vbInformation)

    End Sub

    Private Sub DeserializeFromXML(sender As Object, e As EventArgs) Handles ButtonDeserializeXML.Click
        ''
        ''Modified 9/1/2019 thomas d.  
        ''
        Dim obj_serializer As XmlSerializer = New XmlSerializer(GetType(ClassParent))

        Dim srObj As ClassParent

        Using serialStream = New FileStream(mod_sPathToXML, FileMode.Open, FileAccess.Read, FileShare.Read)

            srObj = DirectCast(obj_serializer.Deserialize(serialStream), ClassParent)

        End Using

        MsgBox("Deserialization from binary:  " & vbCrLf & vbCrLf &
               srObj.ElementType + "      " + srObj.LeftEdge.ToString(), vbInformation)

    End Sub


End Class


