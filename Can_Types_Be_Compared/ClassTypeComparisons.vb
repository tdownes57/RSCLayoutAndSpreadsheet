''
''Added 5/15/2022 
''
Imports System.Windows.Forms ''Added 5/15/2022 

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


    Public Shared Function IsAFormAUserControl_TypeOf()
        ''
        ''Added 5/15/2022 
        ''
        Dim boolSameType1 As Boolean
        Dim boolSameType2 As Boolean
        Dim boolSameType3 As Boolean
        Dim boolSameType4 As Boolean

        Dim objForm As New System.Windows.Forms.Form
        Dim objUserControl As New System.Windows.Forms.UserControl
        Dim objObject As New Object

        ''Doesn't compile. ''boolSameType1 = (TypeOf objUserControl Is Form)
        ''Doesn't compile. ''boolSameType2 = (TypeOf objForm Is UserControl)
        boolSameType3 = (TypeOf objForm Is Object)
        boolSameType4 = (TypeOf objObject Is Object)

        ''---Return boolSameType1
        Return boolSameType3

    End Function ''End of ""Public Shared Function IsAFormAUserControl_TypeOf()""


    Public Shared Function IsArgumentExceptionAnException_TypeOf()
        ''
        ''Added 5/15/2022 
        ''
        Dim boolSameType1 As Boolean

        Dim objException As Exception

        objException = New ArgumentException()

        boolSameType1 = (TypeOf objException Is Exception)

        ''---Return boolSameType1
        Return boolSameType1

    End Function ''End of ""Public Shared Function IsArgumentExceptionAnException_TypeOf()""


    Public Shared Function IsExceptionAnArgumentException_TypeOf()
        ''
        ''Added 5/15/2022 
        ''
        Dim boolSameType1 As Boolean

        Dim objException As Exception

        objException = New ApplicationException

        boolSameType1 = (TypeOf objException Is ArgumentException)

        ''---Return boolSameType1
        Return boolSameType1

    End Function ''End of ""Public Shared Function IsExceptionAnArgumentException_TypeOf()""








End Class
