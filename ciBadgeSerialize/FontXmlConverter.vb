Option Explicit On
Option Strict On
''
''Added 6/6/2022 thomas downes
''
''  https://stackoverflow.com/questions/1940127/how-to-xmlserialize-system-drawing-font-class?noredirect=1&lq=1
''
''  Answered by Elad https://stackoverflow.com/users/138585/elad
''
''---Imports System.Xml.Serialization ''Added 6/06/2022  thomas 
Imports System.Drawing
Imports System.ComponentModel

Public Class FontXmlConverter
    ''
    ''Added 6/6/2022 thomas downes
    ''
    ''  https://stackoverflow.com/questions/1940127/how-to-xmlserialize-system-drawing-font-class?noredirect=1&lq=1
    ''
    ''  Answered by Elad https://stackoverflow.com/users/138585/elad
    ''
    Public Shared Function ConvertToString(par_objFont As Font) As String
        ''
        ''Added 6/6/2022 thomas downes
        ''
        ''  https://stackoverflow.com/questions/1940127/how-to-xmlserialize-system-drawing-font-class?noredirect=1&lq=1
        ''
        ''  Answered by Elad https://stackoverflow.com/users/138585/elad
        ''
        Try
            If (par_objFont IsNot Nothing) Then
                ''--C#--TypeConverter Converter = TypeDescriptor.GetConverter(TypeOf (Font));
                ''--C#--Return Converter.ConvertToString(Font);

                Dim objConverter As TypeConverter
                objConverter = TypeDescriptor.GetConverter(GetType(Font))
                Return objConverter.ConvertToString(par_objFont)

            Else
                Return Nothing

            End If

        Catch ex As Exception

            System.Diagnostics.Debug.WriteLine("Unable to convert")
            System.Diagnostics.Debugger.Break()

        End Try

        Return Nothing

    End Function ''ENd of ""Public Shared Function ConvertToString""


    Public Shared Function ConvertToFont(par_stringFont As String) As Font
        ''
        ''Added 6/6/2022 thomas downes
        ''
        ''  https://stackoverflow.com/questions/1940127/how-to-xmlserialize-system-drawing-font-class?noredirect=1&lq=1
        ''
        ''  Answered by Elad https://stackoverflow.com/users/138585/elad
        ''

        Try

            Dim objConverter As TypeConverter
            objConverter = TypeDescriptor.GetConverter(GetType(Font))
            Return CType(objConverter.ConvertFromString(par_stringFont), Font)

        Catch ex As Exception

            System.Diagnostics.Debug.WriteLine("Unable to convert")
            System.Diagnostics.Debugger.Break()

        End Try

        Return Nothing

    End Function ''End of "Public Shared Function ConvertToFont"








End Class
