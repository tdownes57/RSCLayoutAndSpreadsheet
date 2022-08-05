Option Explicit On ''Added 9/29/2019 td 
Option Strict On ''Added 9/29/2019 td 
''
''Added 9/29   /2019 td 
''
Imports System.IO ''Added 9/12/2019 td 
Imports System.Runtime.Serialization
Imports System.Xml.Serialization ''Added 9/1/2019 thomas d. 

Public Class ClassDeserial
    ''
    ''Added 9/29/2019 td 
    ''
    Public PathToXML As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.txt"
    Public PathToXML_Binary As String = "" ''Added 11/29/2019 thomas d. 

    Public Function DeserializeFromXML(par_TypeOfObject As Type, pbVerboseSuccess As Boolean) As Object
        ''
        ''9/30/2019 td''Public Function DeserializeFromXML(par_TypeOfObject As Type, 
        ''                   par_objectToSerialize As Object,
        ''                   pbVerboseSuccess As Boolean) As Object
        ''
        ''Modified 9/1/2019 thomas d.  
        ''
        ''9/29/2019 td''Dim obj_serializer As XmlSerializer = New XmlSerializer(GetType(ClassParent))
        Dim obj_serializer As XmlSerializer = New XmlSerializer(par_TypeOfObject)

        ''9/29/2019 td''Dim srObj As ClassParent
        Dim srObj As Object

        Try
            Using serialStream = New FileStream(Me.PathToXML, FileMode.Open, FileAccess.Read, FileShare.Read)

                ''#1 9/29/2019 td''srObj = DirectCast(obj_serializer.Deserialize(serialStream), ClassParent)
                '' #2 9/29/2019 td''srObj = DirectCast(obj_serializer.Deserialize(serialStream), par_TypeOfObject)

                srObj = obj_serializer.Deserialize(serialStream)

            End Using
        Catch ex_Try As Exception
            ''7/12/2022 td MsgBox("Deserialization failed, Message:  " & ex_Try.Message, vbInformation)
            ''7/12/2022 td MsgBox("Deserialization failed, ToString:  " & ex_Try.ToString, vbInformation)
            Dim strErrorMessage As String ''Added 7/12/2022 
            Dim strErrDescript As String ''Added 7/12/2022 
            strErrorMessage = ex_Try.Message
            strErrDescript = ex_Try.ToString()
            System.Diagnostics.Debugger.Break() ''Added 7/12/2022 
            pbVerboseSuccess = False
            Return Nothing
        End Try

        If (pbVerboseSuccess) Then
            ''Added 9/29/2019 Thomas D. 
            ''9/30/2019 td''MsgBox("Deserialization from binary:  " & vbCrLf & vbCrLf &
            ''     "Type:  " & par_TypeOfObject.ToString() & vbCrLf &
            ''     "Object: " & par_objectToSerialize.ToString, vbInformation)

            MsgBox("Deserialization from binary:  " & vbCrLf & vbCrLf &
                 "Type:  " & par_TypeOfObject.ToString(), vbInformation)

        End If ''End of "If (pbVerboseSuccess) Then"

        Return srObj

    End Function ''End of "Public Function DeserializeFromXML(.....)"


    Public Function DeserializeFromFile(par_TypeOfObject As Type,
                                        par_objFileInfo As IO.FileInfo,
                                        pbVerboseSuccess As Boolean) As Object
        ''
        ''Added 8/5/2022 thomas d.  
        ''
        Dim obj_serializer As XmlSerializer = New XmlSerializer(par_TypeOfObject)

        Dim srObj As Object

        Me.PathToXML = par_objFileInfo.FullName

        Try
            Using serialStream = New FileStream(Me.PathToXML, FileMode.Open, FileAccess.Read, FileShare.Read)

                srObj = obj_serializer.Deserialize(serialStream)

            End Using

        Catch ex_Try As Exception
            ''7/12/2022 td MsgBox("Deserialization failed, Message:  " & ex_Try.Message, vbInformation)
            ''7/12/2022 td MsgBox("Deserialization failed, ToString:  " & ex_Try.ToString, vbInformation)
            Dim strErrorMessage As String ''Added 7/12/2022 
            Dim strErrDescript As String ''Added 7/12/2022 
            strErrorMessage = ex_Try.Message
            strErrDescript = ex_Try.ToString()
            System.Diagnostics.Debugger.Break() ''Added 7/12/2022 
            pbVerboseSuccess = False
            Return Nothing
        End Try

        If (pbVerboseSuccess) Then
            ''Added 9/29/2019 Thomas D. 
            ''9/30/2019 td''MsgBox("Deserialization from binary:  " & vbCrLf & vbCrLf &
            ''     "Type:  " & par_TypeOfObject.ToString() & vbCrLf &
            ''     "Object: " & par_objectToSerialize.ToString, vbInformation)

            MsgBox("Deserialization from binary:  " & vbCrLf & vbCrLf &
                 "Type:  " & par_TypeOfObject.ToString(), vbInformation)

        End If ''End of "If (pbVerboseSuccess) Then"

        Return srObj

    End Function ''End of "Public Function DeserializeFromFile(.....)"


End Class


