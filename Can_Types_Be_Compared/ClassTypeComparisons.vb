''
''Added 5/15/2022 
''
Public Class ClassTypeComarisons
    ''
    ''Added 5/15/2022 
    ''


    Public Shared Function IsStringTypeSameAsInteger_Try1()
        ''
        ''Added 5/15/2022 
        ''
        Dim typeString As Type
        Dim typeInteger As Type

        typeString = GetType(String)
        typeInteger = GetType(Integer)

        Return (typeString = typeInteger)

    End Function ''End of ""Public Shared Function IsStringTypeSameAsInteger_Try1()""


    Public Shared Function IsStringTypeSameAsInteger_Try2()
        ''
        ''Added 5/15/2022 
        ''
        Dim strExampleString As String = "Hello, world!"
        Dim intExampleInteger As Integer = 57

        Dim typeString As Type
        Dim typeInteger As Type

        typeString = strExampleString.GetType() ''GetType(String)
        typeInteger = intExampleInteger.GetType() '' GetType(Integer)

        Return (typeString = typeInteger)

    End Function ''End of ""Public Shared Function IsStringTypeSameAsInteger_Try2()""


    Public Shared Function IsPassedObjectAnException(par_object As Object)
        ''
        ''Added 5/15/2022 
        ''
        Dim boolParIsException As Boolean
        Dim boolParIsObject As Boolean

        boolParIsException = (TypeOf par_object Is System.Exception)
        boolParIsObject = (TypeOf par_object Is System.Object)

        Return boolParIsException

    End Function ''End of ""Public Shared Function IsPassedObjectAnException()""


    Public Shared Function IsPassedTypeAnException(par_type As Type)
        ''
        ''Added 5/15/2022 
        ''
        Dim boolIsException As Boolean

        boolIsException = (par_type = GetType(System.Exception))

        Return boolIsException

    End Function ''End of ""Public Shared Function IsPassedTypeAnException()""


    Public Shared Function IsAFormAUserControl()
        ''
        ''Added 5/15/2022 
        ''
        Dim boolSameType As Boolean




        Return boolSameType

    End Function ''End of ""Public Shared Function IsPassedObjectAnException()""










End Class
