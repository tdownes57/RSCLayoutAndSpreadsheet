Imports ciBadgeSerialize ''Added 11/22/2022 

Public Structure Line
    ''
    ''Added 11/22/2022
    ''
    Public point1 As Point
    Public point2 As Point
End Structure


Public Structure Triangle
    ''
    ''Added 11/22/2022
    ''
    Public line1 As Line
    Public line2 As Line
    Public line3 As Line
End Structure

Public Structure Arrow
    ''
    ''Added 11/22/2022
    ''
    Public NameOfArrow As String
    Public triangle1 As Triangle
    Public triangle2 As Triangle

End Structure

<Serializable>
Public Class ClassListOfArrows

    Public NamedArrows As New List(Of Arrow)


    Public Sub SaveToXML()



    End Sub

    Public Sub LoadFromXML()



    End Sub


End Class
