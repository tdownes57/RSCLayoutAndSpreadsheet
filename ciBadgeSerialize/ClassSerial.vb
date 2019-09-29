Option Explicit On ''Added 9/9/2019 td 
Option Strict On ''Added 9/9/2019 td 
''
''Added 9/9/2019 td 
''
Imports System.IO ''Added 9/12/2019 td 
Imports System.Runtime.Serialization
Imports System.Xml.Serialization ''Added 9/1/2019 thomas d. 

Public Class ClassSerial
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
    Public TypeOfObject As Type ''Added 9/1/2019 td 
    Public ObjectToSerialize As Object ''Added 9/12/2019 td 

    ''
    ''serializing the Object
    ''

    Public Sub SerializeToXML(par_TypeOfObject As Type, par_objectToSerialize As Object,
                              pbVerboseSuccess As Boolean,
                              pboolAutoOpenFile As Boolean) ''ByVal sender As System.Object, ByVal e As System.EventArgs) ''Handles ButtonSerializeToXML.Click

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

        ''9/12 td''Dim fileStream_Xml As Stream = New FileStream(mod_sPathToXML,
        ''                FileMode.Create, FileAccess.Write, FileShare.None)
        Dim fileStream_Xml As Stream = New FileStream(Me.PathToXML,
                     FileMode.Create, FileAccess.Write, FileShare.None)

        ''Formatter.Serialize(fileStream_Xml, srObj)
        ''9/12/2019 td''Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(ClassParent))
        ''9/24/2019 td''Dim writer As New System.Xml.Serialization.XmlSerializer(par_TypeOfObject)
        Dim writer As New System.Xml.Serialization.XmlSerializer(par_TypeOfObject)

        ''Dim file As New System.IO.StreamWriter("c:\temp\SerializationOverview.xml")
        ''
        ''9/12/2019 td''writer.Serialize(fileStream_Xml, mod_objParent)
        ''9/24/2019 td''writer.Serialize(fileStream_Xml, Me.ObjectToSerialize)
        writer.Serialize(fileStream_Xml, par_objectToSerialize)

        fileStream_Xml.Close()

        If (pbVerboseSuccess) Then
            MsgBox("Object Serialized !!", vbInformation, "Serialization")
        End If ''End of "If (pbVerboseSuccess) Then"

        If (pboolAutoOpenFile) Then
            ''9/12/2019 td''System.Diagnostics.Process.Start(mod_sPathToXML)
            System.Diagnostics.Process.Start(Me.PathToXML)
        End If ''End of "If (pboolAutoOpenFile) Then"

    End Sub ''End of "Public Sub SerializeToXML(par_TypeOfObject As Type, par_objectToSerialize As Object) "

    Public Sub SerializeToBinary(par_TypeOfObject As Type, par_objectToSerialize As Object)

        ''---------------------------------
        ''Added 9/24 & 8/2/2019 Thomas DOWNES
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/concepts/serialization/
        ''----------------------------------
        ''
        Dim formatter_Bin As IFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        ''9/24 td''Dim fileStream_Bin As Stream = New FileStream(mod_sPathToBinary, FileMode.Create, FileAccess.Write, FileShare.None)
        Dim fileStream_Bin As Stream = New FileStream(Me.PathToBinary, FileMode.Create, FileAccess.Write, FileShare.None)

        ''9/24/2019 td''formatter_Bin.Serialize(fileStream_Bin, mod_objParent)
        formatter_Bin.Serialize(fileStream_Bin, par_objectToSerialize)
        fileStream_Bin.Close()

        System.Diagnostics.Process.Start(Me.PathToBinary)

    End Sub ''End of "Private Sub SerializeToBinary(par_TypeOfObject As Type, par_objectToSerialize As Object)"

    Public Function SaveAndRegenerateObject_XML_NotInUseHere(par_TypeOfObject As Type, ByRef par_objectToSerialize As Object) As Object
        ''
        ''Added & moved 9/29/2019 td
        ''
        ''See class module ClassCycle. 
        ''
        SerializeToXML(par_TypeOfObject, par_objectToSerialize, False, False)
        Dim objDeserialized As Object = Nothing
        ''9/29/2019 td''objDeserialized = deserializeFromXML(par_TypeOfObject, Me.PathToXML)
        Return objDeserialized

    End Function ''End of "Public Function SaveAndRegenerateObject_XML"


End Class
