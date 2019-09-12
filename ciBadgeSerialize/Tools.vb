Option Explicit On ''Added 9/9/2019 td 
Option Strict On ''Added 9/9/2019 td 
''
''Added 9/9/2019 td 
''

Public Class Tools
    ''
    ''Added 9/9/2019 td 
    ''
    ''   https://stackoverflow.com/questions/5005900/how-to-serialize-listt
    ''


    '' <summary>
    '' http://net-informations.com/faq/net/serialization.htm
    '' </summary> 
    '' 
    ''9/1/2019 td''Public mod_c_sPathToXML As String = "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.txt"
    ''9/1/2019 td''Public mod_c_sPathToBinary As String = "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Bin.txt"

    Public PathToXML As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.txt"
    Public PathToBinary As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Bin.ttxt"

    ''
    ''serializing the Object
    ''
    Public Sub SerializeToXML() ''ByVal sender As System.Object, ByVal e As System.EventArgs) ''Handles ButtonSerializeToXML.Click

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






End Class
