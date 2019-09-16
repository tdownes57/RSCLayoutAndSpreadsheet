Option Explicit On
Option Strict On
Option Infer Off
''
''Added 9/16/2019 thomas downes
''

Public Class ClassElementsCache
    ''
    ''Added 9/16/2019 thomas downes
    ''
    Private mod_listElementFields As New List(Of ClassElementField)
    Private mod_listElementPics As New List(Of ClassElementPic)
    Private mod_listElementStatics As New List(Of ClassElementStaticText)

    Public Function FieldElements() As List(Of ClassElementField)
        ''
        ''Added 9/16/2019 thomas downes
        ''
        Return mod_listElementFields

    End Function ''End of "Public Function FieldElements() As List(Of ClassElementText)"

    Public Function PicElement() As ClassElementPic
        ''
        ''Added 9/16/2019 thomas downes
        ''
        Return mod_listElementPics(0)

    End Function

    Public Function StaticTextElements() As List(Of ClassElementStaticText)
        ''
        ''Added 9/16/2019 thomas downes
        ''
        Return mod_listElementStatics

    End Function ''End of "Public Function StaticTextElements() As List(Of ClassElementStaticText)"

    Public Sub LoadFieldElements()
        ''
        ''Added 9/16/2019 thomas d. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''
        ''Part 1 of 2.  Initialize the lists. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''Standard Fields (Initialize the list) 
        ''
        ClassFieldStandard.InitializeHardcodedList_Students(True)

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Initialize the list)  
        ''
        ClassFieldCustomized.InitializeHardcodedList_Students(True)

        ''----------------------------------------------------------------------------------------------------
        ''
        ''End of "Part 1 of 2.  Initialize the lists." 
        ''
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''
        ''Part 2 of 2.  Collect the list items. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''Standard Fields (Collect the list items)  
        ''
        For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

            mod_listElementFields.Add(field_standard.ElementFieldClass)

        Next field_standard
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Collect the list items) 
        ''
        For Each field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

            mod_listElementFields.Add(field_custom.ElementFieldClass)

        Next field_custom
        ''----------------------------------------------------------------------------------------------------


    End Sub ''ENd of "Public Sub LoadFieldElements()"



End Class
