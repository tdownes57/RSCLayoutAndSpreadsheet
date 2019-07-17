Option Explicit On
Option Strict On
''
''Added 7/16/2019 thomas downes  
''


Public Class ClassCustomField
    ''
    ''Added 7/16/2019 thomas d. 
    ''
    ''Public TextFieldId As Integer
    Public Property TextFieldId As Integer = 1

    Public Property DateFieldId As Integer = 0
    Public Property IsDateField As Boolean = False

    Public Property Text_orDate As String = "Text"

    Public Property LabelCaption As String = ""
    Public Property ExampleValueToUseInLayout As String = ""


End Class
