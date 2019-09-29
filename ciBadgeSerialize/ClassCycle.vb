''
''Added 9/29/2019 td
''

Public Class ClassTestCycle
    ''
    ''Added 9/29/2019 td
    ''
    Private mod_pathToXML As String

    Public Property PathToXML As String
        Get
            Return mod_pathToXML
        End Get
        Set(value As String)

            ''Added 9/29/2019 td
            mod_pathToXML = value
            mod_serial.PathToXML = value
            mod_deserial.PathToXML = value

        End Set
    End Property

    Private mod_serial As New ClassSerial
    Private mod_deserial As New ClassDeserial

    Public Function SaveAndRegenerateObject_XML(par_TypeOfObject As Type, ByRef par_objectToSerialize As Object) As Object
        ''
        ''Added 9/29/2019 td
        ''
        mod_serial.SerializeToXML(par_TypeOfObject, par_objectToSerialize, False, False)

        Dim objDeserialized As Object
        objDeserialized = mod_deserial.deserializeFromXML(par_TypeOfObject, Me.PathToXML)
        Return objDeserialized

    End Function ''End of "Public Function SaveAndRegenerateObject_XML"


End Class
