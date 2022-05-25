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
    Public Shared UseBinaryFormat As Boolean = False ''Added 11/29/2019 td 

    '' <summary>
    '' http://net-informations.com/faq/net/serialization.htm
    '' </summary> 
    '' 
    ''9/1/2019 td''Public mod_c_sPathToXML As String = "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.txt"
    ''9/1/2019 td''Public mod_c_sPathToBinary As String = "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Bin.txt"

    Public PathToXML As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Xml.txt"
    ''11/29/2019 td''Public PathToBinary As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Bin.ttxt"
    Public PathToXML_Binary As String = "" ''9/1/2019 td''  "C:\Users\tdown\Documents\CIBadgeWeb\SerializeFile_Bin.ttxt"
    Public PathToXML_Alternate As String = "" ''Added 3/23/2022 thomas downes

    Public TypeOfObject As Type ''Added 9/1/2019 td 
    Public ObjectToSerialize As Object ''Added 9/12/2019 td 

    Public ErrorOccurred As Boolean  ''Added 5/24/2022 td
    Public ErrorMessage As String  ''Added 5/24/2022 td

    ''
    ''serializing the Object
    ''

    Public Sub SerializeToXML(par_TypeOfObject As Type, par_objectToSerialize As Object,
                              pbVerboseSuccess As Boolean,
                              pboolAutoOpenFile As Boolean) ''ByVal sender As System.Object, ByVal e As System.EventArgs) ''Handles ButtonSerializeToXML.Click

        ''7/20/2019 td''Dim srObj As New serializeObject()
        '' 8/31/2019 td''Dim srObj As New ClassParent()

        Const c_bCopyRestoreFileIfNeeded As Boolean = True ''Added 1/25/2022 thomas d. 
        Dim bRestoreFile As Boolean ''Added 1/25/2022 thomas d. 
        Dim bSuccessful As Boolean ''Added 1/25/2022 thomas d. 

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

        ''Added 1/25/2022 thomas d.
        If (c_bCopyRestoreFileIfNeeded) Then
            ''Added 1/25/2022 thomas d.
            If (IO.File.Exists(Me.PathToXML)) Then
                IO.File.Copy(Me.PathToXML, Me.PathToXML & "_temp", True)
            End If ''End of "If (IO.File.Exists(Me.PathToXML)) Then"
        End If ''End of "If (c_bCopyRestoreFileIfNeeded) Then"

        ''9/12 td''Dim fileStream_Xml As Stream = New FileStream(mod_sPathToXML,
        ''                FileMode.Create, FileAccess.Write, FileShare.None)
        ''1/25/2022 td''Dim fileStream_Xml As Stream = New FileStream(Me.PathToXML,
        ''             FileMode.Create, FileAccess.Write, FileShare.None)

        ''Added 3/23/2022 thomas downes
        Dim objParentFolder As System.IO.DirectoryInfo ''Added 3/23/2022 t
        Dim objParentFolder_Alternate As System.IO.DirectoryInfo ''Added 3/23/2022 t
        Dim boolFolderExists As Boolean ''Added 3/23/2022 t
        Dim boolFolderExists_Alternate As Boolean ''Added 3/23/2022 t
        Const c_boolCreateFolderForXML As Boolean = True ''Added 5/24/2022 td

        objParentFolder = IO.Directory.GetParent(Me.PathToXML)
        boolFolderExists = IO.Directory.Exists(objParentFolder.FullName)

        If (boolFolderExists) Then
            ''As expected, the target folder exists.  ---3/23/2022

        ElseIf (Me.PathToXML_Alternate <> "") Then
            ''The primary path is empty. Use the Alternate Path.  
            objParentFolder_Alternate = IO.Directory.GetParent(Me.PathToXML_Alternate)
            boolFolderExists_Alternate = IO.Directory.Exists(objParentFolder_Alternate.FullName)
            If (boolFolderExists_Alternate) Then
                ''As expected, the target folder exists.  ---3/23/2022
            Else
                ''Added 3/23/2022 td
                Throw New Exception("The implied folder path (Alternate) doesn't exist.")
            End If ''End of "If (boolFolderExists_Alternate) Then ... Else..."

        ElseIf (c_boolCreateFolderForXML) Then ''Added 5/24/2022 

            ''Added 5/24/2022
            IO.Directory.CreateDirectory(objParentFolder.FullName)
            For intIndex As Integer = 1 To 7
                System.Threading.Thread.Sleep(100)
                boolFolderExists = IO.Directory.Exists(objParentFolder.FullName)
                If (boolFolderExists) Then Exit For
            Next intIndex

        Else
            ''Added 3/23/2022 td
            ''#1 May24 2022 ''Throw New Exception("The implied folder path doesn't exist.")
            ''#2 May24 2022 ''System.Diagnostics.Debugger.Break()

            ''Added 5/24/2022  
            Me.ErrorOccurred = True
            Me.ErrorMessage = ("The XML folder path doesn't exist.  " &
                "The folder path is as follows:" &
                 vbCrLf & objParentFolder.FullName & vbCrLf &
                "The file path is as follows:" &
                 vbCrLf & Me.PathToXML)
            Exit Sub

        End If ''End of "If (boolFolderExists) Then .... Else ...."

        ''Added the "Using" keyword on 1/25/2022 td 
        Using fileStream_Xml As Stream = New FileStream(Me.PathToXML,
                 FileMode.Create, FileAccess.Write, FileShare.None)

            ''Formatter.Serialize(fileStream_Xml, srObj)
            ''9/12/2019 td''Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(ClassParent))
            ''9/24/2019 td''Dim writer As New System.Xml.Serialization.XmlSerializer(par_TypeOfObject)
            ''12/8/2021 td''Dim writer As New System.Xml.Serialization.XmlSerializer(par_TypeOfObject)
            Dim writer As New XmlSerializer(par_TypeOfObject)

            ''Dim file As New System.IO.StreamWriter("c:\temp\SerializationOverview.xml")
            ''
            ''9/12/2019 td''writer.Serialize(fileStream_Xml, mod_objParent)
            ''9/24/2019 td''writer.Serialize(fileStream_Xml, Me.ObjectToSerialize)
            Try
                writer.Serialize(fileStream_Xml, par_objectToSerialize)
                bSuccessful = True ''Added 1/25/2022 td
            Catch
                bRestoreFile = True ''Added 1/25/2022 td
            Finally
            End Try

            fileStream_Xml.Close()

        End Using

        ''
        ''Issue a success message if appropriate. 
        ''
        If (bSuccessful And pbVerboseSuccess) Then

            ''Jan25 2022''MsgBox("Object Serialized !!", vbInformation, "Serialization")
            MessageBoxTD.Show_Statement("Object is successfully serialized !!")

        ElseIf (c_bCopyRestoreFileIfNeeded And bRestoreFile) Then

            ''Added 1/25/2022 thomas d.
            IO.File.Copy(Me.PathToXML & "_temp", Me.PathToXML, True)
            IO.File.Delete(Me.PathToXML & "_temp")

        End If ''End of "If (bSuccessful and pbVerboseSuccess) Then"

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
        ''11/29/2019 td''Dim fileStream_Bin As Stream = New FileStream(Me.PathToBinary, FileMode.Create, FileAccess.Write, FileShare.None)
        Dim fileStream_Bin As Stream = New FileStream(Me.PathToXML_Binary, FileMode.Create, FileAccess.Write, FileShare.None)

        ''9/24/2019 td''formatter_Bin.Serialize(fileStream_Bin, mod_objParent)
        formatter_Bin.Serialize(fileStream_Bin, par_objectToSerialize)
        fileStream_Bin.Close()

        ''11/29/2019 td''System.Diagnostics.Process.Start(Me.PathToBinary)
        System.Diagnostics.Process.Start(Me.PathToXML_Binary)

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
