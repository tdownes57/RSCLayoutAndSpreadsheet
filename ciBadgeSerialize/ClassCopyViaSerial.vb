''
''Added 8/4/2022 thomas downes
''
Public Class ClassCopyViaSerial
    ''
    ''Added 8/4/2022 thomas downes
    ''
    Public Function CopyViaSerial(par_TypeOfObject As Type, par_objectToSerialize As Object,
                              pbVerboseSuccess As Boolean) As Object
        ''
        ''Added 8/4/2022 thomas downes
        ''
        Dim objSerial As New ClassSerial
        Dim objDerial As New ClassDeserial
        Dim objRandomFile As IO.FileInfo
        Dim objCopy As Object

        objRandomFile = objSerial.SerializeToRandomFile(par_TypeOfObject,
                                                        par_objectToSerialize, False)

        objCopy =
        objDerial.DeserializeFromFile(par_TypeOfObject, objRandomFile, False)

        Return objCopy

    End Function ''Public Function CopyViaSerial 



End Class
