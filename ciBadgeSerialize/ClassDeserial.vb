Option Explicit On ''Added 9/29/2019 td 
Option Strict On ''Added 9/29/2019 td 
''
''Added 9/29/2019 td 
''
Imports System.IO ''Added 9/12/2019 td 
Imports System.Runtime.Serialization
Imports System.Xml.Serialization ''Added 9/1/2019 thomas d. 

Public Class ClassDeserial
    ''
    ''Added 9/29/2019 td 
    ''
    Public PathToXML As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.txt"

    Public Function DeserializeFromXML(par_TypeOfObject As Type, par_objectToSerialize As Object,
                              pbVerboseSuccess As Boolean,
                              pboolAutoOpenFile As Boolean) As Object
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


    End Function

End Class
