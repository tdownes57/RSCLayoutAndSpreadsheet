''
'' Added 12/13/2021 thomas downes  
''

Public Module ModEnumsAndStructs

    ''
    ''Moved to ciBadgeInterfaces on 12/13/2021. --- thomas.
    ''Added 12/8/2021 Thomas 
    ''
    Public Enum EnumWhichSideOfCard
        Undetermined
        EnumFrontside
        EnumBackside

    End Enum


    ''Added 1/19/2022 thomas downes
    Public Structure StructWhichSideOfCard
        ''Added 1/19/2022 thomas downes
        Dim EnumSide As EnumWhichSideOfCard
        Dim Backside As Boolean
    End Structure


    ''
    ''On 1/19/2022, I found the below code by copying the following Public Enum definition
    ''  from __RSC WindowsControlLibrary.Module1Enumerations.EnumElementType.
    ''
    ''  See __RSC WindowsControlLibrary.Module1Enumerations to see the original code. 
    ''   ----1/19/2022 td
    ''
    Public Enum Enum_ElementType

        Undetermined
        Field
        Portrait
        QRCode
        Signature
        StaticText
        StaticGraphic

        ''This allows for the users to create a sub-section of elements, which 
        ''  can be moved around as a unit (without having to re-select all of
        ''  the sub-elements, each time the user wants to move them around as a unit).
        ''  -----Thomas Downes, 1/21/2022 td
        LayoutSection ''Added 1/21/2022 td

        __Background ''Added 1/15/2022 td
        __Desktop ''Added 1/15/2022 td

    End Enum





End Module
